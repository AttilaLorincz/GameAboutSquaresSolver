module GameAboutSquares.Solver
    open System
    open System.Threading
    open GameAboutSquares.Game
    type linq = System.Linq.Enumerable

    //type MutableQueue = System.Collections.Generic.Queue<GameState>
    type MutableQueue = System.Collections.Concurrent.ConcurrentQueue<GameState>
    //type MutableSet = System.Collections.Generic.List<GameState>
    type MutableSet = System.Collections.Concurrent.ConcurrentDictionary<Square list, unit>
    
    let (<&>) f g = (fun x -> f x && g x)
    
    module Globals = 
        let mutable startState : GameState = {squares=[];triangles=[];circles=[];stepsTakenRev=[]}
        let solutions = System.Collections.Concurrent.ConcurrentQueue<Color list option>()
    
    let locationsOfTrianglesAndCirclesAndSquares = lazy ( 
        let startState = Globals.startState
        List.append 
            (List.append 
                (startState.triangles |> List.map (fun x->x.location))
                (startState.circles   |> List.map (fun x->x.location)))
            (startState.squares |> List.map (fun sq->sq.location))
    )

    let locationsOfTrianglesAndCircles = lazy ( 
        let startState = Globals.startState
        List.append 
                (startState.triangles |> List.map (fun x->x.location))
                (startState.circles   |> List.map (fun x->x.location)))
    let bounds  = lazy (
            locationsOfTrianglesAndCirclesAndSquares.Value |> List.fold (fun (mx,my,Mx,My) (ax,ay) -> 
                    min mx ax, min my ay,
                    max Mx ax, max My ay) (Int32.MaxValue, Int32.MaxValue, Int32.MinValue, Int32.MinValue)
        )

    let allSquaresInsideBounds gameState =
        match (bounds.Value) with
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
    let stricterbounds  = lazy (
            locationsOfTrianglesAndCircles.Value |> List.fold (fun (mx,my,Mx,My) (ax,ay) -> 
                    min mx ax, min my ay,
                    max Mx ax, max My ay) (Int32.MaxValue, Int32.MaxValue, Int32.MinValue, Int32.MinValue)
        )
    let allSquaresInsideStricterBounds gameState =
        match (stricterbounds.Value) with
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

    let notVisited (visited:MutableSet) (gameState: GameState)  =
        not(visited.ContainsKey(gameState.squares))

    let prune (currentState: GameState, gameStates: GameState seq, visited: MutableSet): GameState seq = 
        gameStates 
        |> Seq.filter (notVisited(visited) <&> if allSquaresInsideStricterBounds currentState then allSquaresInsideStricterBounds else allSquaresInsideBounds)

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
                else
                    None
 
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
        Globals.startState <- gameState
        let cancellationSource = new CancellationTokenSource() 
        let monitor = Async.StartAsTask( async {
            while true do
                System.Console.Write(DateTime.Now.ToString("s").Replace("T"," ") + " visited: " + visited.Count.ToString() + "\t")
                let (b, head) = queue.TryPeek()                
                if b then
//                    printf "Length of queue %d:2" queue.Count  
                    System.Console.Write("("+head.stepsTakenRev.Length.ToString()+")")
                System.Console.WriteLine()
                do! Async.Sleep(2000)
        },  cancellationToken = cancellationSource.Token)

        let worker = async {
            return solveRec queue visited maxDepth
        } 

        //let task = Async.StartAsTask(computation = worker, cancellationToken = cancellationSource.Token)
        try
            for i in 1..1 do 
                Async.StartWithContinuations(
                                             computation = worker, 
                                             continuation=(fun solution -> 
                                                if solution.IsSome then 
                                                    //printf "%A" solution; 
                                                    Globals.solutions.Enqueue(solution);
                                                    cancellationSource.Cancel(); 
                                                else 
                                                    ()
                                             ),
                                             exceptionContinuation=(fun _->()),
                                             cancellationContinuation=(fun _->()),
                                             cancellationToken = cancellationSource.Token)
            monitor.Wait() 
        with
            | :? AggregateException as e->if linq.Where(e.InnerExceptions, fun(ie) -> not(ie:? OperationCanceledException)) |> linq.Any then reraise()
                                               
        let (b,steps)= Globals.solutions.TryDequeue()
        if b then steps else None