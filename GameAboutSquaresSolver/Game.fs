module GameAboutSquares.Game
    open System
    open System.Threading
    open Microsoft.FSharp.Quotations

    //    ... ... ...
    //   +---+---+---+
    // ..-1,0|0,0|2,0|..
    //   +---+---+---+
    // ..-1,0|0,1|2,1|..
    //   +---+---+---+
    //    ... ... ... 

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

    let makeMoves (gameState : GameState)(color : Color) : GameState = 
        let rec moves (moveSq : Square)(direction : Direction) (gameState : GameState) =
            let moveSquare (square:Square)(direction:Direction) : Square = {   
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

            let movedSquare = moveSquare moveSq direction |> orientSquare gameState.triangles 
            let nextSquares = gameState.squares 
                            |> List.map (
                                fun sq -> if sq=moveSq then movedSquare else sq
                            )
            let otherSquare = nextSquares |> List.tryFind(fun other -> (not(movedSquare.color = other.color) && other.location = movedSquare.location))
            match otherSquare with
                |Some _-> moves otherSquare.Value direction { stepsTakenRev = gameState.stepsTakenRev; triangles = gameState.triangles; circles = gameState.circles; squares = nextSquares}
                |None -> nextSquares

        let squareToMove = gameState.squares |> List.find(fun s -> s.color = color)
        {
            GameState.circles = gameState.circles;
            triangles = gameState.triangles;        
            stepsTakenRev = color :: gameState.stepsTakenRev;
            squares = moves squareToMove squareToMove.direction gameState;
        } 

    let subsequentGameStates gameState : GameState seq =
        seq { for moveSq in gameState.squares do yield  {
                    stepsTakenRev = moveSq.color :: gameState.stepsTakenRev 
                    triangles  = gameState.triangles; 
                    circles    = gameState.circles;
                    squares    = (makeMoves gameState moveSq.color).squares // moves moveSq moveSq.direction gameState;
               }
        }
 