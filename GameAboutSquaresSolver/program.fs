module GameAboutSqares.Program
    open GameAboutSquares.Game
    open GameAboutSquares.Solver
    open GameAboutSquares.Levels
    open System
    
    let replaySolution (startState) (solution: Color list) : GameState =
                (startState, solution) 
                    ||> List.fold (fun acc step -> (
                                                    let newState = makeMoves acc step
                                                    printf "%A" newState
                                                    newState
                                                   )
                ) 
    
    [<EntryPoint>]
    let main(args) = 
        //Level 15: [Red; Red; Red; Blue; Red; Blue; Red; Red; Blue; Red; Red; Red; ]
        let startState = level16
        let maxDepth = 17
        let stopWatch = System.Diagnostics.Stopwatch.StartNew()
        try 
            match solve startState maxDepth with
            |None -> 
                printfn "No solution found in depth %d" maxDepth  
                1
            |Some solution -> 
                printf "Solution found: " 
                printfn "%A" solution
                //replaySolution startState solution |> ignore
                printfn "(%A steps)" solution.Length
                0
        finally
            stopWatch.Stop()
            printfn "Elapsed: %A" stopWatch.Elapsed
