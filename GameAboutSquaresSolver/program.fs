module GameAboutSqares.Program
    open GameAboutSquares.Game
    open GameAboutSquares.Solver
    open GameAboutSquares.Levels

    
    [<EntryPoint>]
    let main(args) = 
        //Level 15: [Red; Red; Red; Blue; Red; Blue; Red; Red; Blue; Red; Red; Red; ]
        //printfn "%A" sizeof<Color>
        let startState = level 15
        let maxDepth = 23
        let stopWatch = System.Diagnostics.Stopwatch.StartNew()
        try 
            match solve startState maxDepth with
            |None -> 
                printfn "No solution found in depth %d" maxDepth  
                1
            |Some solution -> 
                printfn "Solution found: " 
                printfn "%A" solution
                //replaySolution startState solution |> ignore
                printfn "(%A steps)" solution.Length
                0
        finally
            stopWatch.Stop()
            printfn "Elapsed: %A" stopWatch.Elapsed
