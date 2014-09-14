module GameAboutSquares.Solver
    open System
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
    type MutableQueue = System.Collections.Generic.Queue<GameState>
    //type MutableQueue = System.Collections.Concurrent.ConcurrentQueue<GameState>
    type MutableSet = System.Collections.Generic.List<GameState>
    //type MutableSet = System.Collections.Concurrent.ConcurrentQueue<GameState>
    
    let compareSequences s1 s2 = (s1, s2) ||> Seq.forall2 (=)

    let compareColors  (c1:Color) (c2:Color) : int =
        if c1 < c2 then -1
        else if c1 = c2 then 0
        else 1
    
    let compareCircleColors (c1:Circle) (c2:Circle) : int =
      compareColors c1.color c2.color

    let compareSquareColors  (s1:Square) (s2:Square) : int =
      compareColors s1.color s2.color

    let isEndState gameState =
            compareSequences                               
                (gameState.squares |> List.sortWith compareSquareColors |> List.map (fun x->x.location))  
                (gameState.circles |> List.sortWith compareCircleColors |> List.map (fun x->x.location))

    let areStatesEqual (gameState1)(gameState2):bool=
            compareSequences                               
                (gameState1.squares |> List.sortWith compareSquareColors |> List.map (fun x->x.location))  
                (gameState2.squares |> List.sortWith compareSquareColors |> List.map (fun x->x.location))

    let moveSquare (square:Square) (direction:Direction): Square = {   
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

    let rec moves (moveSq : Square) (direction : Direction) (gameState : GameState) =
        let movedSquare = moveSquare moveSq direction |> orientSquare gameState.triangles 
        let nextSquares = gameState.squares 
                        |> List.map (
                            fun sq -> if sq=moveSq then movedSquare else sq
                        )
        let otherSquare = nextSquares |> List.tryFind(fun other -> ((movedSquare.color < other.color || movedSquare.color > other.color ) && other.location = movedSquare.location))
        match otherSquare with
            |Some _-> moves otherSquare.Value direction { stepsTakenRev = gameState.stepsTakenRev; triangles = gameState.triangles; circles = gameState.circles; squares = nextSquares}
            |None -> nextSquares

    let makeMoves(gameState : GameState) (color : Color) : GameState = 
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

    let insideBounds(gameState: GameState): bool = 
        let locations = 
                List.append 
                    (gameState.squares |> List.map (fun sq->sq.location))
                    (gameState.circles |> List.map (fun x->x.location))
                |> List.append (gameState.triangles |> List.map (fun x->x.location))
        let minx,miny,maxx,maxy = 
           locations |> List.fold (fun (mx,my,Mx,My) (ax,ay) -> 
                     min mx ax, min my ay,
                     max Mx ax, max My ay) (Int32.MaxValue, Int32.MaxValue, Int32.MinValue, Int32.MinValue)
        
        let n = gameState.squares.Length
        //let n = 1         
        let outOfBoundsSquare = 
            gameState.squares  |>
                List.tryFind ( fun sq->
                    match sq.location with 
                        |(x, y) when x > maxx + n-1 || x < minx - n+1 || y > maxy + n-1 || y < miny - n+1 -> true
                        |_ ->false
                 )
        outOfBoundsSquare.IsNone

    let prune (gameStates: GameState seq): GameState seq = 
        gameStates 
        |> Seq.filter insideBounds

    let isVisited ( gameState: GameState) (visited:MutableSet)  =
        let v = visited.FindIndex( fun s -> areStatesEqual gameState s ) 
        v > -1

    let rec solveRec (queue:MutableQueue) (visited:MutableSet) (maxDepth:int): Color list option =   
        if queue.Count =  0 then None
        else 
            //let (b, gameState) = queue.TryDequeue()
            //if not(b) then failwith "TryDequeue failed"  
            let gameState = queue.Dequeue()
            if not(isVisited gameState visited) then
                visited.Add(gameState)
                
            if (isEndState gameState) then
                Some gameState.stepsTakenRev
            else
                if gameState.stepsTakenRev.Length < maxDepth then
                    for s in  prune(subsequentGameStates gameState) do
                        queue.Enqueue(s)
                solveRec queue visited maxDepth

    let solve(gameState:GameState)(maxDepth:int): Color list option =
        let mutable q = MutableQueue()
        let mutable v = MutableSet()
        q.Enqueue(gameState)
        match solveRec q v maxDepth with
           | None -> None
           | Some list -> Some (List.rev list)
  