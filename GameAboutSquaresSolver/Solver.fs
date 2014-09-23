module GameAboutSquares.Solver
    open System
    open System.Threading
    open Microsoft.FSharp.Quotations
    open GameAboutSquares.Game
      
    //type MutableQueue = System.Collections.Generic.Queue<GameState>
    type MutableQueue = System.Collections.Concurrent.ConcurrentQueue<GameState>
    //type MutableSet = System.Collections.Generic.List<GameState>
    type MutableSet = System.Collections.Concurrent.ConcurrentDictionary<List<Square>, unit>
    
    module Globals = 
        let states = System.Collections.Generic.Dictionary<string,GameState>()
        let solutions = System.Collections.Generic.Dictionary<string,Color list option>()

    let allSquaresInsideBounds gameState locations =
        let boundsOf (loclist: Lazy<Location list>) = 
            loclist.Value |> List.fold (fun (mx,my,Mx,My) (ax,ay) -> 
                    min mx ax, min my ay,
                    max Mx ax, max My ay) (Int32.MaxValue, Int32.MaxValue, Int32.MinValue, Int32.MinValue)
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

    let insideBounds(gameState: GameState): bool = 
        let locationsOfTrianglesAndCircles = lazy ( 
            let (b,startState) = Globals.states.TryGetValue("startState")
            List.append 
                (startState.triangles |> List.map (fun x->x.location))
                (startState.circles   |> List.map (fun x->x.location))
        )
        allSquaresInsideBounds gameState locationsOfTrianglesAndCircles

    let insideBoundsIncludingSquares(gameState: GameState): bool = 
        let locationsOfTrianglesAndCirclesAndSquares  = lazy ( 
            let (b,startState) = Globals.states.TryGetValue("startState")
            List.append 
                (List.append 
                    (startState.triangles |> List.map (fun x->x.location))
                    (startState.circles   |> List.map (fun x->x.location)))
                (startState.squares |> List.map (fun sq->sq.location))
        )
        allSquaresInsideBounds gameState locationsOfTrianglesAndCirclesAndSquares

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
        Globals.states.Add("startState", gameState)
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
                do! Async.Sleep(1000)
        },  cancellationToken = cancellationSource.Token)
        let worker = async {
                let solution = solveRec queue visited maxDepth
                //printfn "%A" solution
//                if (solution.IsSome) then 
//                    cancellationSource.Cancel()
                return solution;
        } 

        //let task = Async.StartAsTask(computation = worker, cancellationToken = cancellationSource.Token)
        try
            for i in 1..2 do 
                Async.StartWithContinuations(
                                             computation = worker, 
                                             continuation=(fun solution -> 
                                                if solution.IsSome then 
                                                    //printf "%A" solution; 
                                                    Globals.solutions.Add("solution",solution);
                                                    cancellationSource.Cancel(); 
                                                else ();
                                             ),
                                             exceptionContinuation=(fun _->()),
                                             cancellationContinuation=(fun _->()),
                                             cancellationToken = cancellationSource.Token)
            monitor.Wait() 
        with
            | :? OperationCanceledException  -> ()
            | :? AggregateException-> ()
        let (b,steps)= Globals.solutions.TryGetValue("solution")
        if b then steps else None