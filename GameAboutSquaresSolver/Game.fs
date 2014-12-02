module GameAboutSquares.Game
    // Basic data types
    type Location = sbyte * sbyte
    //    Coordinates:              Directions:
    //   ... |   |1,-1..
    //   +---+---+---+               > right              
    // ..-1,0|0,0|1,0|..             < left
    //   +---+---+---+               ^ up
    // ..-1,1|0,1|1,1|..             ˇ down
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
        | Green
        | Gray
        | Purple
    
    // Components of the game state
    type Square =    {location: Location; color:Color; direction: Direction}
    type Circle =    {location: Location; color:Color}
    type Triangle =  {location: Location; direction:Direction}
    
    // The complex data type describing a current state and the moves made to get here from the starting state
    type GameState = {squares: Square list; triangles: Triangle list; circles: Circle list; stepsTakenRev: Color list}
    
    // Utility functions
    let compareSequences s1 s2 = (s1, s2) ||> Seq.forall2 (=)

    let compareColors(c1:Color)(c2:Color) : int =
        if c1 < c2 then -1
        else if c1 = c2 then 0
        else 1
    
    (* 
    // Alternative comparison makes isEndState colorblind
    // any square is good on any circle
    // Useful for solving the second half of levels 
    // that can be decomposed into two parts: 1. reorder squares in a loop 2. move to circles
    let compareLocations(l1:Location)(l2:Location) : int =
        if l1 < l2 then -1
        else if l1 = l2 then 0
        else 1
    let compareCircleLocations(c1:Circle)(c2:Circle) : int =
      compareLocations c1.location c2.location
    let compareSquareLocations(c1:Square)(c2:Square) : int =
      compareLocations c1.location c2.location
    *)

    let compareCircleColors(c1:Circle)(c2:Circle) : int =
      compareColors c1.color c2.color
    let compareSquareColors(s1:Square)(s2:Square) : int =
      compareColors s1.color s2.color
    
    // Game mechanics
    let isEndState gameState =
        // The order of items in the lists does not matter so we should sort before comparing or use order-agnostic comparison, but
        // for performance reason exploit the fact that we sort the squares and circles at the beginning and then keep their order
        compareSequences 
            (gameState.squares (* |> List.sortWith compareSquareLocations  *) |>  List.map (fun x->x.location))
            (gameState.circles (* |> List.sortWith compareCircleLocations  *) |>  List.map (fun x->x.location))
    
    //  Given the currnt state and the color of the square to move returns the state with that move mad
    let makeMoves (gameState : GameState)(color : Color) : GameState = 
        let rec moves (moveSq : Square)(direction : Direction) (gameState : GameState) =
            let moveSquare (square:Square)(direction:Direction) : Square = {   
                direction=square.direction; 
                color=square.color; 
                location= match square.location with 
                            (x,y) -> match direction with
                                        |Up ->   (x,y-1y)
                                        |Down -> (x,y+1y)
                                        |Left -> (x-1y,y)
                                        |Right ->(x+1y,y);
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
        {GameState.circles = gameState.circles;
            triangles = gameState.triangles;        
            stepsTakenRev = color :: gameState.stepsTakenRev;
            squares = moves squareToMove squareToMove.direction gameState;
        } 
    
    // Returns the sequence of game states reachable from the current state by making a valid move
    let subsequentGameStates gameState : GameState seq =
        seq { 
            for moveSq in gameState.squares do yield  { (makeMoves gameState moveSq.color) with stepsTakenRev = moveSq.color :: gameState.stepsTakenRev }
        }
 