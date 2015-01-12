module GameAboutSqares.Program

open GameAboutSquares.Game
open GameAboutSquares.Solver
open GameAboutSquares.Levels
open System 

let defaultMaxDepth = 45

let solveLevel levelNumber maxDepth = 
    printfn "Trying to solve level %A in %A steps" levelNumber maxDepth
    let stopWatch = Diagnostics.Stopwatch.StartNew()
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
        printfn "Elapsed: %A\n" stopWatch.Elapsed

let inputFromCommandLine (args : string []) = 
    let levelNumber = Int32.Parse(args.[0])    
    let maxDepth = 
        if args.Length > 1 then Int32.Parse(args.[1])
        else defaultMaxDepth
    solveLevel levelNumber maxDepth

let rec repeatedInputFromConsole (lastResult : int) : int = 
    Console.WriteLine("Select a level to solve (0-35) or 'q' to quit")
    let readLine = Console.ReadLine()
    if (String.IsNullOrWhiteSpace(readLine) || readLine = "q" || readLine = "Q") then lastResult
    else repeatedInputFromConsole (solveLevel (Int32.Parse(readLine)) defaultMaxDepth)

[<EntryPoint>]
let main (args) = 
    if args.Length > 0 then inputFromCommandLine args
    else repeatedInputFromConsole 0
