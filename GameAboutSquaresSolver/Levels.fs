module GameAboutSquares.Levels
    open GameAboutSquares.Game
    let startState = {triangles=[]; circles=[]; squares=[]; stepsTakenRev=[]}
    
    let level0 = // Min 2
        { startState with
            circles= [{location=(0y,2y);color=Red}] 
            squares= [{location=(0y,0y);color=Red;direction=Down}]
        }

    let level1 = // Min 2
        { startState with
            circles= [{location=(0y,2y);color=Red}; {location=(0y,1y);color=Blue}] 
            squares= [{location=(0y,0y);color=Blue;direction=Down}; {location=(0y,3y);color=Red;direction=Up}];
        }

    let level2 = // Min 6
        { startState with
            circles= [{location=(0y,0y);color=Blue}; {location=(1y,0y);color=Red}; {location=(0y,1y);color=Black}] 
            squares= [{location=(-1y,0y);color=Red;direction=Right}; {location=(0y,2y);color=Blue;direction=Up}; {location=(2y,1y);color=Black;direction=Left}];
        }

    let level3 = // Min 9
        { startState with
            circles= [{location=(0y,3y);color=Red}; {location=(2y,5y);color=Blue};] 
            squares= [{location=(2y,0y);color=Blue;direction=Down}; {location=(4y,2y);color=Red;direction=Left}];
        }

    let level4 = // Min 5
        { startState with
            circles= [{location=(0y,0y);color=Red}; {location=(1y,1y);color=Black}; {location=(2y,2y);color=Blue}] 
            squares= [{location=(-1y,0y);color=Blue;direction=Right}; {location=(0y,-1y);color=Red;direction=Down}; {location=(1y,0y);color=Black;direction=Down}];
        }

    let level5 = // Min 5
        { startState with
            circles= [{location=(0y,0y);color=Red}; {location=(1y,1y);color=Blue}; {location=(2y,2y);color=Black}] 
            squares= [{location=(-1y,0y);color=Blue;direction=Right}; {location=(0y,-1y);color=Red;direction=Down}; {location=(1y,0y);color=Black;direction=Down}];
        }

    let level6 = // Min 8
        { startState with
            circles= [{location=(0y,0y);color=Black}; {location=(1y,1y);color=Blue}; {location=(2y,3y);color=Red}] 
            squares= [{location=(2y,2y);color=Black;direction=Up}; {location=(3y,0y);color=Red;direction=Down}; {location=(4y,1y);color=Blue;direction=Left}];
        }

    let level7 = // Min 6
        { startState with
            triangles= [{location=(0y,2y);direction=Right}; {location=(2y,2y);direction=Up} ] 
            circles=   [{location=(2y,0y);color=Blue} ] 
            squares=   [{location=(0y,0y);color=Blue;direction=Down} ] 
        }

    let level8 = // Min 9
        { startState with
            triangles= [{location=(0y,2y);direction=Right}; {location=(2y,2y);direction=Up} ] 
            circles=   [{location=(2y,0y);color=Orange}; {location=(3y,0y);color=Black}] 
            squares=   [{location=(0y,0y);color=Orange;direction=Down}; {location=(0y,2y);color=Black;direction=Right}] 
        }
    
    let level9 = // Min 5
        { startState with
            triangles= [{location=(0y,1y);direction=Right}; {location=(2y,1y);direction=Up}; {location=(3y,1y);direction=Left}] 
            circles=   [{location=(1y,0y);color=Orange}; {location=(2y,0y);color=Blue}] 
            squares=   [{location=(0y,1y);color=Orange;direction=Right}; {location=(2y,1y);color=Blue;direction=Up}] 
        }

    let level10 = // Min 8
        { startState with
            triangles= [{location=(0y,0y);direction=Right}];
            circles=   [{location=(-2y,0y);color=Black}; {location=(-1y,0y);color=Red}; {location=(1y,0y);color=Blue}];
            squares=   [{location=(0y,2y);color=Black;direction=Up}; {location=(0y,-2y);color=Red;direction=Down}; {location=(2y,0y);color=Blue;direction=Left};];
        }

    let level11 = // Min 14?
        { startState with
            triangles= [{location=(2y,0y);direction=Down}];
            circles=   [{location=(1y,2y);color=Red}; {location=(2y,2y);color=Blue}; {location=(3y,2y);color=Black}];
            squares=   [{location=(0y,0y);color=Red;direction=Right}; {location=(4y,0y);color=Blue;direction=Left}; {location=(2y,4y);color=Black;direction=Up};];
        } 

    let level12 = // Min 9
        { startState with
            triangles= [{location=(0y,-1y);direction=Down}; {location=(2y,0y);direction=Left}];
            circles=   [{location=(0y,0y);color=Black}; {location=(0y,1y);color=Orange}];
            squares=   [{location=(-1y,1y);color=Orange;direction=Right}; {location=(1y,2y);color=Black;direction=Up}];
        } 

    let level13 = // Min 10
        { startState with
            triangles= [{location=(0y,-1y);direction=Down}];
            circles=   [{location=(0y,0y);color=Blue}; {location=(-1y,2y);color=Orange}; {location=(0y,-2y);color=Black}];
            squares=   [{location=(0y,-1y);color=Black;direction=Down}; {location=(2y,1y);color=Orange;direction=Left}; {location=(1y,3y);color=Blue;direction=Up}];
        } 

    let level14 = // Min 9
        { startState with
            circles= [{location=(0y,0y);color=Red}; {location=(1y,1y);color=Blue}; {location=(2y,0y);color=Orange}; {location=(2y,2y);color=Black}] 
            squares= [{location=(1y,0y);color=Black;direction=Down}; {location=(0y,1y);color=Orange;direction=Right}; {location=(2y,1y);color=Red;direction=Left}; {location=(1y,2y);color=Blue;direction=Up}];
        }
 
    let level15 = // Min 13
        { startState with
            triangles= [{location=(0y,0y);direction=Down}; {location=(3y,0y);direction=Left}; {location=(0y,1y);direction=Right}];
            circles=   [{location=(1y,1y);color=Red}; {location=(1y,2y);color=Blue} ] 
            squares=   [{location=(0y,0y);color=Red;direction=Down}; {location=(2y,2y);color=Blue;direction=Up}];
        }
    
    let level16 =  // Min 14
        { startState with
            triangles= [{location=(0y,0y);direction=Right}; {location=(2y,0y);direction=Down}; {location=(2y,1y);direction=Left}; {location=(1y,2y);direction=Up}];
            circles=   [{location=(0y,1y);color=Red}; {location=(3y,1y);color=Blue} ] 
            squares=   [{location=(0y,0y);color=Red;direction=Right}; {location=(2y,1y);color=Blue;direction=Left}];
        }

    let level17 =  // Min 20
        { startState with
            triangles= [{location=(0y,0y);direction=Down}; {location=(0y,1y);direction=Right}; {location=(2y,2y);direction=Up}; {location=(3y,0y);direction=Left}];
            circles=   [{location=(1y,1y);color=Red}; {location=(2y,1y);color=Black}; {location=(3y,1y);color=Blue}] 
            squares=   [{location=(0y,0y);color=Red;direction=Down}; {location=(0y,1y);color=Black;direction=Right}; {location=(3y,0y);color=Blue;direction=Left}];
        }

    let level18 = // Min 18
        { startState with
            triangles= [{location=(0y,0y);direction=Down}; {location=(0y,1y);direction=Right}; {location=(2y,2y);direction=Up}; {location=(3y,0y);direction=Left}];
            circles=   [{location=(1y,1y);color=Red}; {location=(2y,1y);color=Black}; {location=(3y,1y);color=Blue}] 
            squares=   [{location=(0y,0y);color=Black;direction=Down}; {location=(0y,1y);color=Red;direction=Right}; {location=(3y,0y);color=Blue;direction=Left}];
        }

    let level19 = // Min 43
        { startState with
            triangles= [{location=(0y,0y);direction=Down}; {location=(0y,3y);direction=Right}; {location=(3y,3y);direction=Up}; {location=(3y,1y);direction=Left}; {location=(1y,1y);direction=Down}; {location=(1y,2y);direction=Right}; {location=(2y,2y);direction=Up}];
            circles=   [{location=(2y,-3y);color=Red}; {location=(2y,1y);color=Black}; {location=(2y,-1y);color=Blue}] 
            squares=   [{location=(0y,0y);color=Red;direction=Down}; {location=(1y,1y);color=Blue;direction=Down}; {location=(2y,2y);color=Black;direction=Up}];
        }

    let level20 = // Min 38
        { startState with
            triangles= [{location=(-1y,-1y);direction=Down}; {location=(1y,-1y);direction=Left}; {location=(-1y,1y);direction=Right}; {location=(1y,1y);direction=Up}; {location=(-1y,3y);direction=Up};];
            circles=   [{location=(-1y, 0y);color=Black}; {location=(1y,0y);color=Gray}; {location=(0y,1y);color=Purple}; {location=(0y,-1y);color=Green}] 
            squares=   [{location=(-1y,-1y);color=Black;direction=Down}; {location=(-1y,1y);color=Green;direction=Right}; {location=(1y,1y);color=Gray;direction=Up}; {location=(1y,-1y);color=Purple;direction=Left}];
        }

    let level21 = // Min 42
        { startState with
            triangles= [{location=(0y,0y);direction=Down}; {location=(0y,2y);direction=Up}; {location=(0y,3y);direction=Down}; {location=(0y,4y);direction=Right}; {location=(2y,4y);direction=Up}; {location=(0y,4y);direction=Left}];
            circles=   [{location=(0y,1y);color=Gray}; {location=(2y,1y);color=Red}; {location=(2y,2y);color=Green}; {location=(2y,3y);color=Orange}] 
            squares=   [{location=(0y,0y);color=Gray;direction=Down}; {location=(0y,4y);color=Red;direction=Right}; {location=(2y,0y);color=Orange;direction=Left}; {location=(2y,4y);color=Green;direction=Up}];
        }

    let level22 = // Min 17
        { startState with
            triangles= [{location=(0y,0y);direction=Down}; {location=(-1y,2y);direction=Right}; {location=(0y,4y);direction=Up}; {location=(3y,3y);direction=Left}];
            circles=   [{location=(1y,0y);color=Red}] 
            squares=   [{location=(0y,0y);color=Blue;direction=Down}; {location=(-1y,2y);color=Red;direction=Right}; {location=(3y,1y);color=Black;direction=Down}];
        }

    let level23 = // Min 17
        { startState with
            triangles= [{location=(0y,0y);direction=Down}; {location=(-2y,2y);direction=Right}; {location=(2y,1y);direction=Left}; {location=(0y,4y);direction=Up}];
            circles=   [{location=(-1y,3y);color=Red}; {location=(0y,3y);color=Blue}; {location=(1y,3y);color=Black}] 
            squares=   [{location=(-1y,0y);color=Blue;direction=Down}; {location=(-2y,2y);color=Black;direction=Right}; {location=(2y,1y);color=Red;direction=Left}];
        }

    let level24 = // Min 23
        { startState with
            triangles= [{location=(0y,0y);direction=Down}; {location=(0y,3y);direction=Right}; {location=(3y,3y);direction=Up}; {location=(3y,1y);direction=Left}; {location=(1y,1y);direction=Down}; {location=(1y,2y);direction=Right}; {location=(2y,2y);direction=Up}];
            circles=   [{location=(0y,-2y);color=Red}; {location=(1y,-1y);color=Blue}; {location=(2y,0y);color=Black}] 
            squares=   [{location=(0y,0y);color=Red;direction=Down}; {location=(1y,1y);color=Blue;direction=Down}; {location=(2y,2y);color=Black;direction=Up}];
        }

    let level25 = // Min 24
        { startState with
            triangles= [{location=(0y,0y);direction=Down}; {location=(3y,0y);direction=Left}; {location=(2y,0y);direction=Right}; {location=(2y,2y);direction=Up}];
            circles=   [{location=(0y,-1y);color=Red}; {location=(1y,-1y);color=Blue}; {location=(2y,-1y);color=Black}] 
            squares=   [{location=(0y,0y);color=Blue;direction=Down}; {location=(2y,0y);color=Black;direction=Right}; {location=(2y,2y);color=Red;direction=Up}];
        }

    let level26 = // Min 24
        { startState with
            triangles= [{location=(1y,0y);direction=Down}; {location=(3y,1y);direction=Left}; {location=(0y,2y);direction=Right}; {location=(2y,2y);direction=Up}];
            circles=   [{location=(0y,1y);color=Blue}; {location=(2y,0y);color=Orange}; {location=(3y,2y);color=Black}; {location=(1y,3y);color=Red}];
            squares=   [{location=(1y,0y);color=Orange;direction=Down}; {location=(3y,1y);color=Black;direction=Left}; {location=(0y,2y);color=Blue;direction=Right}; {location=(2y,3y);color=Red;direction=Up}];
        }

    let level27 = // Min 28
        { startState with
            triangles= [{location=(0y,2y);direction=Right}; {location=(3y,0y);direction=Down}; {location=(3y,4y);direction=Up}; {location=(4y,1y);direction=Left}];
            circles=   [{location=(1y,3y);color=Red}; {location=(2y,3y);color=Blue}; {location=(3y,3y);color=Black}] 
            squares=   [{location=(1y,0y);color=Black;direction=Down}; {location=(4y,1y);color=Blue;direction=Left}; {location=(0y,2y);color=Red;direction=Right}];
        }

    let level28 = // Min 18
        { startState with
            triangles= [{location=(1y,0y);direction=Down}; {location=(0y,2y);direction=Right}; {location=(1y,4y);direction=Up}; {location=(4y,3y);direction=Left}];
            circles=   [{location=(0y,1y);color=Blue}] 
            squares=   [{location=(1y,0y);color=Blue;direction=Down}; {location=(2y,0y);color=Red;direction=Right}; {location=(4y,1y);color=Black;direction=Down}];
        }

    let level29 = // Min 22
        { startState with
            triangles= [{location=(0y,-2y);direction=Down}; {location=(0y,2y);direction=Up}; {location=(2y,0y);direction=Right}];
            circles=   [{location=(-1y,0y);color=Orange}; {location=(0y,-1y);color=Red}; {location=(1y,0y);color=Blue}; {location=(0y,1y);color=Black}] 
            squares=   [{location=(-2y,0y);color=Red;direction=Right}; {location=(0y,-2y);color=Blue;direction=Down}; {location=(2y,0y);color=Black;direction=Left}; {location=(0y,2y);color=Orange;direction=Up}];
        }

    let level30 = // Min 41
        { startState with
            triangles= [{location=(0y,0y);direction=Down}; {location=(3y,0y);direction=Left}; {location=(0y,3y);direction=Right}; {location=(2y,3y);direction=Up}];
            circles=   [{location=(1y,0y);color=Black}; {location=(0y,1y);color=Blue}; {location=(0y,2y);color=Red}] 
            squares=   [{location=(0y,0y);color=Black;direction=Down}; {location=(0y,3y);color=Red;direction=Right}; {location=(2y,3y);color=Blue;direction=Up}];
        }

    let level31 = // Min 21
        { startState with
            triangles= [{location=(0y,-2y);direction=Down}; {location=(-1y,-1y);direction=Right}; {location=(1y,0y);direction=Left}; {location=(0y,2y);direction=Up}];
            circles=   [{location=(-2y,0y);color=Blue}; {location=(0y,0y);color=Red}; {location=(2y,0y);color=Black}] 
            squares=   [{location=(0y,-2y);color=Blue;direction=Down}; {location=(-1y,-1y);color=Black;direction=Right}; {location=(1y,0y);color=Red;direction=Left}];
        }

    let level32 = // Min 33
        { startState with
            triangles= [{location=(0y,0y);direction=Down}; {location=(-1y,-1y);direction=Right}; {location=(1y,0y);direction=Left}; {location=(0y,2y);direction=Up}];
            circles=   [{location=(-2y,0y);color=Blue}; {location=(0y,0y);color=Red}; {location=(2y,0y);color=Black}] 
            squares=   [{location=(0y,-2y);color=Blue;direction=Down}; {location=(-1y,-1y);color=Black;direction=Right}; {location=(1y,0y);color=Red;direction=Left}];
        }

    let level33 = // Min 45
        { startState with
            triangles= [{location=(0y,0y);direction=Down}; {location=(-1y,2y);direction=Right}; {location=(3y,3y);direction=Left}; {location=(0y,4y);direction=Up}];
            circles=   [{location=(-1y,1y);color=Blue}; {location=(0y,1y);color=Red};] 
            squares=   [{location=(-1y,2y);color=Red;direction=Right}; {location=(0y,0y);color=Blue;direction=Down}; {location=(3y,1y);color=Black;direction=Down}];
        }

    let level34 = // Min 33
        { startState with
            triangles= [{location=(0y,0y);direction=Down}; {location=(3y,0y);direction=Left}; {location=(2y,2y);direction=Up}; {location=(0y,1y);direction=Right}];
            circles=   [{location=(1y,2y);color=Black}; {location=(2y,1y);color=Red}; {location=(3y,2y);color=Blue};] 
            squares=   [{location=(0y,0y);color=Black;direction=Down}; {location=(0y,1y);color=Red;direction=Right}; {location=(3y,0y);color=Blue;direction=Left}];
        }

    let level35 = // Min 39
       { startState with
            triangles= [{location=(1y,0y);direction=Down}; {location=(4y,1y);direction=Left}; {location=(3y,4y);direction=Up}; {location=(0y,3y);direction=Right}];
            circles=   [{location=(0y,2y);color=Black}; {location=(0y,3y);color=Red}; {location=(0y,4y);color=Orange};] 
            squares=   [{location=(0y,4y);color=Orange;direction=Right}; {location=(1y,4y);color=Red;direction=Right}; {location=(2y,4y);color=Black;direction=Right}];
        }

    let level n = 
        match n with
            | 0 -> level0
            | 1 -> level1
            | 2 -> level2
            | 3 -> level3
            | 4 -> level4
            | 5 -> level5
            | 6 -> level6
            | 7 -> level7
            | 8 -> level8
            | 9 -> level9
            |10 -> level10
            |11 -> level11
            |12 -> level12
            |13 -> level13
            |14 -> level14
            |15 -> level15
            |16 -> level16
            |17 -> level17
            |18 -> level18
            |19 -> level19
            |20 -> level20
            |21 -> level21
            |22 -> level22
            |23 -> level23
            |24 -> level24
            |25 -> level25
            |26 -> level26
            |27 -> level27
            |28 -> level28
            |29 -> level29
            |30 -> level30
            |31 -> level31
            |32 -> level32
            |33 -> level33
            |34 -> level34
            |35 -> level35

            |_-> failwith "Unknown level"

    let hi = level0
    let hi3 = level1
    let order2 = level2
    let push = level3
    let stairs = level4
    let stairs2 = level5
    let lift = level6
    let presq = level7
    let sq = level8
    let nobrainer = level9
    let crosst = level10
    let t = level11
    let rotation = level12
    let assym = level13
    let clover = level14
    let preduced = level15
    let herewego = level16
    let reduced = level17
    let reduced2 = level18
    let spiral2 = level19
    let recycle2 = level20
    let recycle3 = level21
    let shirt = level22
    let shuttle = level23
    let spiral = level24
    let splinter = level25
    let elegant = level26
    let shuttle2 = level27
    let shirt2 = level28
    let windmill = level29
    let paper = level30
    let shuttle5 = level31
    let shirtDouble = level32
    let splinter2 = level33
    let reduced3 = level34
    let elegant2 = level35
