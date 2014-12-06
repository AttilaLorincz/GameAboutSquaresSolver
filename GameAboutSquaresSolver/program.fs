module GameAboutSqares.Program

open GameAboutSquares.Game
open GameAboutSquares.Solver
open GameAboutSquares.Levels

let replaySolution (startState) (solution : Color list) : GameState = 
    (startState, solution) ||> List.fold (fun acc step -> 
                                   (let newState = makeMoves acc step
                                    printf "%A" newState
                                    newState))

[<EntryPoint>]
let main (args) = 
    let levelNumber = 
        if args.Length > 0 then System.Int32.Parse(args.[0])
        else 
            System.Console.WriteLine("Select a level to solve (0-35)")
            System.Int32.Parse(System.Console.ReadLine())
    
    let maxDepth = 
        if args.Length > 1 then System.Int32.Parse(args.[1])
        else 45

    printfn "Trying to solve level %A in %A steps" levelNumber maxDepth

    let stopWatch = System.Diagnostics.Stopwatch.StartNew()
    try 
        let startState = level levelNumber
        match solve startState maxDepth with
        | None -> 
            printfn "No solution found in depth %d" maxDepth
            1
        | Some solution -> 
            printfn "Solution found: "
            printfn "%A" solution
            //replaySolution startState solution |> ignore
            printfn "(%A steps)" solution.Length
            0
    finally
        stopWatch.Stop()
        printfn "Elapsed: %A" stopWatch.Elapsed
