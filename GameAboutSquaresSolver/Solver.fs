module GameAboutSquares.Solver
    open System
    open System.Threading
    open Microsoft.FSharp.Quotations
    // 0,0   1,0  Coordinate system
    // 0,1   1,1
    type Direction =
        | Up
        | Down
        | Left
        | Right
    type Color =
        | Red
        | Black
        | Blue
        | Orange 
    type Location = int * int

    type Square =    {location: Location; color:Color; direction: Direction}
    type Circle =    {location: Location; color:Color}
    type Triangle =  {location: Location; direction:Direction}
    type GameState = {squares: List<Square>; triangles: Triangle list; circles: Circle list; stepsTakenRev: Color list}
    
    // todo: switch to concurrent collection
    //type MutableQueue = System.Collections.Generic.Queue<GameState>
    type MutableQueue = System.Collections.Concurrent.ConcurrentQueue<GameState>
    //type MutableSet = System.Collections.Generic.List<GameState>
    type MutableSet = System.Collections.Concurrent.ConcurrentDictionary<List<Square>, unit>
    
    module Globals = let map = System.Collections.Generic.Dictionary<_,_>()

    let compareSequences s1 s2 = (s1, s2) ||> Seq.forall2 (=)

    let compareColors(c1:Color)(c2:Color) : int =
        if c1 < c2 then -1
        else if c1 = c2 then 0
        else 1
    
    let compareCircleColors(c1:Circle)(c2:Circle) : int =
      compareColors c1.color c2.color

    let compareSquareColors(s1:Square)(s2:Square) : int =
      compareColors s1.color s2.color

    let isEndState gameState =
            compareSequences                               
                (gameState.squares (*|> List.sortWith compareSquareColors  *) |> List.map (fun x->x.location))
                (gameState.circles (*|> List.sortWith compareCircleColors  *) |> List.map (fun x->x.location))

    let areStatesEqual (gameState1)(gameState2):bool=
            compareSequences                               
                (gameState1.squares |> List.map (fun x->x.location))  
                (gameState2.squares |> List.map (fun x->x.location))

    let moveSquare(square:Square)(direction:Direction): Square = {   
            direction=square.direction; 
            color=square.color; 
            location= match square.location with 
                        (x,y) -> match direction with
                                 |Up ->   (x,y-1)
                                 |Down -> (x,y+1)
                                 |Left -> (x-1,y)
                                 |Right ->(x+1,y);
        }

    let orientSquare(triangles:Triangle seq)(square:Square) : Square =
        match triangles |> Seq.tryFind (fun t -> t.location = square.location) with
        |None -> square
        |Some t -> {location=square.location; direction=t.direction; color=square.color;}

    let rec moves (moveSq : Square)(direction : Direction) (gameState : GameState) =
        let movedSquare = moveSquare moveSq direction |> orientSquare gameState.triangles 
        let nextSquares = gameState.squares 
                        |> List.map (
                            fun sq -> if sq=moveSq then movedSquare else sq
                        )
        let otherSquare = nextSquares |> List.tryFind(fun other -> (not(movedSquare.color = other.color) && other.location = movedSquare.location))
        match otherSquare with
            |Some _-> moves otherSquare.Value direction { stepsTakenRev = gameState.stepsTakenRev; triangles = gameState.triangles; circles = gameState.circles; squares = nextSquares}
            |None -> nextSquares

    let makeMoves(gameState : GameState)(color : Color) : GameState = 
        let moveSq = gameState.squares |> List.find(fun s -> s.color = color)
        {
            GameState.circles = gameState.circles;
            triangles = gameState.triangles;        
            stepsTakenRev = color :: gameState.stepsTakenRev;
            squares = moves moveSq moveSq.direction gameState;
        } 

    let subsequentGameStates gameState : GameState seq =
        seq { for moveSq in gameState.squares do yield  {
                    stepsTakenRev = moveSq.color :: gameState.stepsTakenRev 
                    triangles  = gameState.triangles; 
                    circles    = gameState.circles;
                    squares    = moves moveSq moveSq.direction gameState;
               }
        }
 
    let locations = lazy ( 
            let (b,startState) = Globals.map.TryGetValue("startState")
            List.append 
                (startState.triangles |> List.map (fun x->x.location))
                (startState.circles   |> List.map (fun x->x.location))
    )
    
    let locationsIncludingSquares  = lazy ( 
            let (b,startState) = Globals.map.TryGetValue("startState")
            List.append 
                (locations.Value)
                (startState.squares |> List.map (fun sq->sq.location))
    )

    let boundsOf (loclist: Lazy<Location list>) = 
        loclist.Value |> List.fold (fun (mx,my,Mx,My) (ax,ay) -> 
                    min mx ax, min my ay,
                    max Mx ax, max My ay) (Int32.MaxValue, Int32.MaxValue, Int32.MinValue, Int32.MinValue)
     
    
    let insideBounds(gameState: GameState): bool = 
        match (boundsOf locations) with
        | (minx, miny, maxx, maxy) ->
            let n = gameState.squares.Length
            //let n = 1         
            let outOfBoundsSquare = 
                gameState.squares  |>
                    List.tryFind ( fun sq->
                        match sq.location with 
                            |(x, y) when x > maxx + n-1 || x < minx - n+1 || y > maxy + n-1 || y < miny - n+1 -> true
                            //  |(x, y) when x > maxx || x < minx || y > maxy || y < miny - 1 -> true // level11
                            |_ ->false
                     )
            outOfBoundsSquare.IsNone

    let insideBoundsIncludingSquares(gameState: GameState): bool = 
        match (boundsOf locationsIncludingSquares) with
        | (minx, miny, maxx, maxy) ->
            let n = gameState.squares.Length
            //let n = 1         
            let outOfBoundsSquare = 
                gameState.squares  |>
                    List.tryFind ( fun sq->
                        match sq.location with 
                            |(x, y) when x > maxx + n-1 || x < minx - n+1 || y > maxy + n-1 || y < miny - n+1 -> true
                            //  |(x, y) when x > maxx || x < minx || y > maxy || y < miny - 1 -> true // level11
                            |_ ->false
                     )
            outOfBoundsSquare.IsNone

//
//    let isVisited (visited:MutableSet) (gameState: GameState)  =
//        //let v = visited.FindIndex( fun s -> areStatesEqual gameState s )
//        //v > -1
//        visited.ContainsKey(gameState)
//    
    let notVisited (visited:MutableSet) (gameState: GameState)  =
        not(visited.ContainsKey(gameState.squares))

    let prune (currentState: GameState, gameStates: GameState seq, visited: MutableSet): GameState seq = 
        let inside = gameStates |> Seq.filter (if insideBounds currentState then insideBounds else insideBoundsIncludingSquares)
        let iv = notVisited(visited) 
        Seq.filter iv inside

    let rec solveRec (queue:MutableQueue) (visited:MutableSet) (maxDepth:int): Color list option =   
        let (b, gameState) = queue.TryDequeue()
        if not(b) then
            Thread.Sleep(2)
            solveRec queue visited maxDepth
        else
            if notVisited visited gameState then
                visited.TryAdd(gameState.squares, ()) |> ignore
                
            if (isEndState gameState) then
                Some (List.rev gameState.stepsTakenRev)
            else
                if gameState.stepsTakenRev.Length < maxDepth then
                    for s in  prune(gameState, subsequentGameStates gameState, visited) do
                        queue.Enqueue(s)
                solveRec queue visited maxDepth
 
    let solve (startState:GameState) (maxDepth:int) : Color list option =
        let queue = MutableQueue()
        let visited = MutableSet()
        let gameState = {
            triangles = startState.triangles;
            squares = startState.squares |> List.sortWith compareSquareColors  
            circles = startState.circles |> List.sortWith compareCircleColors 
            stepsTakenRev = startState.stepsTakenRev
        }
        queue.Enqueue(gameState)
        Globals.map.Add("startState", gameState)
        let cancellationSource = new CancellationTokenSource() 
        let monitor = Async.StartAsTask( async {
            while true do
                System.Console.WriteLine(DateTime.Now.ToString() + " " + visited.Count.ToString()) 
               
                // printf "%A - " DateTime.Now
                //let (b, head) = queue.TryPeek()                
                //if b then
                        //printf "Length of queue %A" queue.Count  
                    //printf "move %A"  head.stepsTakenRev.Length
                //printfn
                Thread.Sleep(2000)
        },  cancellationToken = cancellationSource.Token)
        let worker = async {
                let solution = solveRec queue visited maxDepth
                //printfn "%A" solution
                if (solution.IsSome) then 
                    cancellationSource.CancelAfter(99111)
                return solution;
        } 
        //for i in 1..2 do 
        let task = Async.StartAsTask(computation = worker, cancellationToken = cancellationSource.Token)
        task.Wait()
        //monitor.Wait();
        task.Result
      