module GameAboutSquares.Levels
    open GameAboutSquares.Game
    let startState = {triangles=[]; circles=[]; squares = []; stepsTakenRev=[]}
    
    let level0 = // Min 2y
        { startState with
            circles= [{location=(0y,2y); color=Red}] 
            squares= [{location=(0y,0y); color=Red; direction=Down}]
        }

    let level1 = // Min 2y
        { startState with
            circles= [{location=(0y,2y); color=Red}; {location=(0y,1y); color=Blue}] 
            squares= [{location=(0y,0y); color=Blue; direction=Down}; {location=(0y,3y); color=Red; direction=Up}];
        }

    let level2 = // Min 6
        { startState with
            circles= [{location=(0y,0y); color=Blue}; {location=(1y,0y); color=Red}; {location=(0y,1y); color=Black}] 
            squares= [{location=(-1y,0y); color=Red; direction=Right}; {location=(0y,2y); color=Blue; direction=Up}; {location=(2y,1y); color=Black; direction=Left}];
        }

    let level3 = // Min 9
        { startState with
            circles= [{location=(0y,3y); color=Red}; {location=(2y,5y); color=Blue};] 
            squares= [{location=(2y,0y); color=Blue; direction=Down}; {location=(4y,2y); color=Red; direction=Left}];
        }

    let level4 = // Min 5y
        { startState with
            circles= [{location=(0y,0y); color=Red}; {location=(1y,1y); color=Black}; {location=(2y,2y); color=Blue}] 
            squares= [{location=(-1y,0y); color=Blue; direction=Right}; {location=(0y,-1y); color=Red; direction=Down}; {location=(1y,0y); color=Black; direction=Down}];
        }

    let level5 = // Min 5y
        { startState with
           circles= [{location=(0y,0y); color=Red}; {location=(1y,1y); color=Blue}; {location=(2y,2y); color=Black}] 
           squares= [{location=(-1y,0y); color=Blue; direction=Right}; {location=(0y,-1y); color=Red; direction=Down}; {location=(1y,0y); color=Black; direction=Down}];
        }

    let level6 = // Min 8
        { startState with
           circles= [{location=(0y,0y); color=Black}; {location=(1y,1y); color=Blue}; {location=(2y,3y); color=Red}] 
           squares= [{location=(2y,2y); color=Black; direction=Up}; {location=(3y,0y); color=Red; direction=Down}; {location=(4y,1y); color=Blue; direction=Left}];
        }

    let level7 = // Min 6
        { startState with
            triangles= [{location=(0y,2y); direction=Right}; {location=(2y,2y); direction=Up} ] 
            circles=   [{location=(2y,0y); color=Blue} ] 
            squares=   [{location=(0y,0y); color=Blue; direction=Down} ] 
        }

    let level8 = // Min 9
        { startState with
            triangles= [{location=(0y,2y); direction=Right}; {location=(2y,2y); direction=Up} ] 
            circles=   [{location=(2y,0y); color=Orange}; {location=(3y,0y); color=Black}] 
            squares=   [{location=(0y,0y); color=Orange; direction=Down}; {location=(0y,2y); color=Black; direction=Right}] 
        }
    
    let level9 = // Min 5y
        { startState with
            triangles= [{location=(0y,1y); direction=Right}; {location=(2y,1y); direction=Up}; {location=(3y,1y); direction=Left}] 
            circles=   [{location=(1y,0y); color=Orange}; {location=(2y,0y); color=Blue}] 
            squares=   [{location=(0y,1y); color=Orange; direction=Right}; {location=(2y,1y); color=Blue; direction=Up}] 
        }

    let level10 = // Min 8
        { startState with
            triangles= [{location=(0y,0y); direction=Right}]; 
            circles=   [{location=(-2y,0y); color=Black}; {location=(-1y,0y); color=Red};{location=(1y,0y); color=Blue}]; 
            squares=   [{location=(0y,2y); color=Black; direction=Up}; {location=(0y,-2y); color=Red; direction=Down};{location=(2y,0y); color=Blue; direction=Left};];
        }

    let level11 = // Min 1y4y
        { startState with
            triangles= [{location=(2y,0y); direction=Down}]; 
            circles=   [{location=(1y,2y); color=Red}; {location=(2y,2y); color=Blue};{location=(3y,2y); color=Black}]; 
            squares=   [{location=(0y,0y); color=Red; direction=Right}; {location=(4y,0y); color=Blue; direction=Left};{location=(2y,4y); color=Black; direction=Up};];
        } 

    let level12 = // Min 9
        { startState with
            triangles= [{location=(0y,-1y); direction=Down}; {location=(2y,0y); direction=Left}]; 
            circles=   [{location=(0y,0y); color=Black}; {location=(0y,1y); color=Orange}]; 
            squares=   [{location=(-1y,1y); color=Orange; direction=Right}; {location=(1y,2y); color=Black; direction=Up}];
        } 

    let level13 = // Min 1y0y
        { startState with
            triangles= [{location=(0y,-1y); direction=Down}]; 
            circles=   [{location=(0y,0y); color=Blue}; {location=(-1y,2y); color=Orange}; {location=(0y,-2y); color=Black}]; 
            squares=   [{location=(0y,-1y); color=Black; direction=Down}; {location=(2y,1y); color=Orange; direction=Left}; {location=(1y,3y); color=Blue; direction=Up}];
        } 

    let level14 = // Min 9
        { startState with
            circles= [{location=(0y,0y); color=Red}; {location=(1y,1y); color=Blue};{location=(2y,0y); color=Orange}; {location=(2y,2y); color=Black}] 
            squares= [{location=(1y,0y); color=Black; direction=Down}; {location=(0y,1y); color=Orange; direction=Right};{location=(2y,1y); color=Red; direction=Left};{location=(1y,2y); color=Blue; direction=Up}];
        }
 
    let level15 = // Min 1y3y
        { startState with
            triangles= [{location=(0y,0y); direction=Down}; {location=(3y,0y); direction=Left}; {location=(0y,1y); direction=Right}]; 
            circles=   [{location=(1y,1y); color=Red}; {location=(1y,2y); color=Blue} ] 
            squares=   [{location=(0y,0y); color=Red; direction=Down}; {location=(2y,2y); color=Blue; direction=Up}];
        }
    
    let level16 =  // Min 1y4y
        { startState with
            triangles= [{location=(0y,0y); direction=Right}; {location=(2y,0y); direction=Down}; {location=(2y,1y); direction=Left}; {location=(1y,2y); direction=Up}]; 
            circles=   [{location=(0y,1y); color=Red}; {location=(3y,1y); color=Blue} ] 
            squares=   [{location=(0y,0y); color=Red; direction=Right}; {location=(2y,1y); color=Blue; direction=Left}];
        }

    let level17 =  // Min 2y0y
        { startState with
            triangles= [{location=(0y,0y); direction=Down};{location=(0y,1y); direction=Right}; {location=(2y,2y); direction=Up};{location=(3y,0y); direction=Left}]; 
            circles=   [{location=(1y,1y); color=Red}; {location=(2y,1y); color=Black};{location=(3y,1y); color=Blue}] 
            squares=   [{location=(0y,0y); color=Red; direction=Down}; {location=(0y,1y); color=Black; direction=Right};{location=(3y,0y); color=Blue; direction=Left}];
        }

    let level18 = // Min 2y1y 
        { startState with
            triangles= [{location=(0y,0y); direction=Down};{location=(0y,1y); direction=Right}; {location=(2y,2y); direction=Up};{location=(3y,0y); direction=Left}]; 
            circles=   [{location=(1y,1y); color=Red}; {location=(2y,1y); color=Black};{location=(3y,1y); color=Blue}] 
            squares=   [{location=(0y,0y); color=Black; direction=Down}; {location=(0y,1y); color=Red; direction=Right};{location=(0y,3y); color=Blue; direction=Left}];
        }

    let level19 = // Min 4y3y
        None

    let level20 = // Min 3y8
        None

    let level21 = // Min 4y2y
        None

    let level22 = // Min 1y7
        None

    let level23 = // Min 1y7
        None

    let level24 = // Min 2y3y
        None

    let level25 = // Min 2y4y
        None

    let level26 = // Min 2y4y
        None

    let level27 = // Min 2y8
        None

    let level28 = // Min 1y8
        None

    let level29 = // Min 2y2y
        { startState with
            triangles= [{location=(0y,-2y); direction=Down};{location=(0y,2y); direction=Up};{location=(2y,0y); direction=Right}]; 
            circles=   [{location=(-1y,0y); color=Orange}; {location=(0y,-1y); color=Red};{location=(1y,0y); color=Blue};{location=(0y,1y); color=Black}] 
            squares=   [{location=(-2y,0y); color=Red; direction=Right}; {location=(0y,-2y); color=Blue; direction=Down}; {location=(2y,0y); color=Black; direction=Left}; {location=(0y,2y); color=Orange; direction=Up}];
        }

    let level30 = // Min 4y1y
        None

    let level31 = // Min 2y1y
        None

    let level32 = // Min 3y3y
        None

    let level33 = // Min 4y5y
        { startState with
            triangles= [{location=(0y,0y); direction=Down};{location=(0y,2y); direction=Right}; {location=(2y,2y); direction=Up};{location=(3y,0y); direction=Left}]; 
            circles=   [{location=(-1y,-1y); color=Blue}; {location=(0y,-1y); color=Red};{location=(1y,-1y); color=Black}] 
            squares=   [{location=(0y,0y); color=Blue; direction=Down}; {location=(0y,2y); color=Black; direction=Right};{location=(2y,2y); color=Red; direction=Up}];
        }

    let level34 = // Min 3y3y
        None

    let level35 = // Min 3y9
        None

    let level n = 
        match n with
            |0 -> level0
            |1 -> level1
            |2 -> level2
            |3 -> level3
            |4 -> level4
            |5 -> level5
            |6 -> level6
            |7 -> level7
            |8 -> level8
            |9 -> level9
            |10 -> level10
            |11 -> level11
            |12 -> level12
            |13 -> level13
            |14 -> level14
            |15 -> level15
            |16 -> level16
            |17 -> level17
            |18 -> level18
//            |19 -> level19
//            |20 -> level20
//            |21 -> level21
//            |22 -> level22
//            |23 -> level23
//            |24 -> level24
//            |25 -> level25
//            |26 -> level26
//            |27 -> level27
//            |28 -> level28
            |29 -> level29
//            |30 -> level30
//            |31 -> level31
//            |32 -> level32
            |33 -> level33
//            |34 -> level34
//            |35 -> level35

            |_-> failwith "Unknown level"
