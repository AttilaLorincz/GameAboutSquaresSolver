module GameAboutSqares.Program
    open GameAboutSquares.Solver
    open GameAboutSquares.Levels
    
    
    let replaySolution (startState) (solution: Color list) :unit =
                (startState, solution) ||> List.fold (fun acc step -> (
                                                                        let newState = makeMoves acc step
                                                                        printfn "%A" newState
                                                                        newState
                                                                      )
                ) |> ignore
    
    [<EntryPoint>]
    let main(args) = 
        let startState = level17
        let maxDepth = 20
        match solve startState maxDepth with
            |None -> 
                printf "No solution found in depth %d" maxDepth  
                0
            |Some solution -> 
                printf "\n" 
                printf "Solution found:"
                printf "%A" solution
                //replaySolution startState solution
                1

