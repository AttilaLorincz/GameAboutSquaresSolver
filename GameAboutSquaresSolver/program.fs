module GameAboutSqares.Program
    open GameAboutSquares.Solver
    open GameAboutSquares.Levels
    open System
    
    let replaySolution (startState) (solution: Color list) :unit =
                (startState, solution) ||> List.fold (fun acc step -> (
                                                                        let newState = makeMoves acc step
                                                                        printfn "%A" newState
                                                                        newState
                                                                      )
                ) |> ignore
    
    [<EntryPoint>]
    let main(args) = 
        let startState = level 15
        let maxDepth = 14
        let stopWatch = System.Diagnostics.Stopwatch.StartNew()
        try 
            match solve startState maxDepth with
                |None -> 
                    printfn "No solution found in depth %d" maxDepth  
                    1
                |Some solution -> 
                    printf "Solution found:"
                    printfn "%A" solution
                    //replaySolution startState solution
                    0
        finally
            printf "Elapsed: %A" stopWatch.Elapsed
