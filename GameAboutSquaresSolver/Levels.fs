module GameAboutSquares.Levels
    open GameAboutSquares.Solver
    let startState = {triangles=[]; circles=[]; squares = []; stepsTakenRev=[]}
    
    let level0 = // Min 2
        { startState with
            circles= [{location=(0,2); color=Red}] 
            squares= [{location=(0,0); color=Red; direction=Down}]
        }

    let level1 =  // Min 2
        { startState with
            circles= [{location=(0,2); color=Red}; {location=(0,1); color=Blue}] 
            squares= [{location=(0,0); color=Blue; direction=Down}; {location=(0,3); color=Red; direction=Up}];
        }

    let level2 = // Min 6
        { startState with
            circles= [{location=(0,0); color=Blue}; {location=(1,0); color=Red}; {location=(0,1); color=Black}] 
            squares= [{location=(-1,0); color=Red; direction=Right}; {location=(0,2); color=Blue; direction=Up}; {location=(2,1); color=Black; direction=Left}];
        }

    let level3 = // Min 9
        { startState with
            circles= [{location=(0,3); color=Red}; {location=(2,5); color=Blue};] 
            squares= [{location=(2,0); color=Blue; direction=Down}; {location=(4,2); color=Red; direction=Left}];
        }

    let level4 = // Min 5
        { startState with
            circles=[{location=(0,0); color=Red}; {location=(1,1); color=Black}; {location=(2,2); color=Blue}] 
            squares=[{location=(-1,0); color=Blue; direction=Right}; {location=(0,-1); color=Red; direction=Down}; {location=(1,0); color=Black; direction=Down}];
        }

    let level5 = // Min 5
        { startState with
           circles= [{location=(0,0); color=Red}; {location=(1,1); color=Blue}; {location=(2,2); color=Black}] 
           squares= [{location=(-1,0); color=Blue; direction=Right}; {location=(0,-1); color=Red; direction=Down}; {location=(1,0); color=Black; direction=Down}];
        }

    let level6 = // Min 8
        { startState with
           circles= [{location=(0,0); color=Black}; {location=(1,1); color=Blue}; {location=(2,3); color=Red}] 
           squares= [{location=(2,2); color=Black; direction=Up}; {location=(3,0); color=Red; direction=Down}; {location=(4,1); color=Blue; direction=Left}];
        }

    let level7 = // Min 6
        { startState with
            triangles= [{location=(0,2); direction=Right}; {location=(2,2); direction=Up} ] 
            circles=   [{location=(2,0); color=Blue} ] 
            squares=   [{location=(0,0); color=Blue; direction=Down} ] 
        }

    let level8 = // Min 9
        { startState with
            triangles= [{location=(0,2); direction=Right}; {location=(2,2); direction=Up} ] 
            circles=   [{location=(2,0); color=Orange}; {location=(3,0); color=Black}] 
            squares=   [{location=(0,0); color=Orange; direction=Down}; {location=(0,2); color=Black; direction=Right}] 
        }
    
    let level9 = // Min 5
        { startState with
            triangles= [{location=(0,1); direction=Right}; {location=(2,1); direction=Up}; {location=(3,1); direction=Left}] 
            circles=   [{location=(1,0); color=Orange}; {location=(2,0); color=Blue}] 
            squares=   [{location=(0,1); color=Orange; direction=Right}; {location=(2,1); color=Blue; direction=Up}] 
        }

    let level10 = // Min 8
        { startState with
            triangles= [{location=(0,0); direction=Right}]; 
            circles=   [{location=(-2,0); color=Black}; {location=(-1,0); color=Red};{location=(1,0); color=Blue}]; 
            squares=   [{location=(0,2); color=Black; direction=Up}; {location=(0,-2); color=Red; direction=Down};{location=(2,0); color=Blue; direction=Left};];
        }

    let level11 = // Min 14
        { startState with
            triangles= [{location=(2,0); direction=Down}]; 
            circles=   [{location=(1,2); color=Red}; {location=(2,2); color=Blue};{location=(3,2); color=Black}]; 
            squares=   [{location=(0,0); color=Red; direction=Right}; {location=(4,0); color=Blue; direction=Left};{location=(2,4); color=Black; direction=Up};];
        } 

    let level12 = // Min 9
        { startState with
            triangles= [{location=(0,-1); direction=Down}; {location=(2,0); direction=Left}]; 
            circles=   [{location=(0,0); color=Black}; {location=(0,1); color=Orange}]; 
            squares=   [{location=(-1,1); color=Orange; direction=Right}; {location=(1,2); color=Black; direction=Up}];
        } 

    let level13 = // Min 10
        { startState with
            triangles= [{location=(0,-1); direction=Down}]; 
            circles=   [{location=(0,0); color=Blue}; {location=(-1,2); color=Orange}; {location=(0,-2); color=Black}]; 
            squares=   [{location=(0,-1); color=Black; direction=Down}; {location=(2,1); color=Orange; direction=Left}; {location=(1,3); color=Blue; direction=Up}];
        } 

    let level14 = // Min 9
        { startState with
            circles= [{location=(0,0); color=Red}; {location=(1,1); color=Blue};{location=(2,0); color=Orange}; {location=(2,2); color=Black}] 
            squares= [{location=(1,0); color=Black; direction=Down}; {location=(0,1); color=Orange; direction=Right};{location=(2,1); color=Red; direction=Left};{location=(1,2); color=Blue; direction=Up}];
        }
 
    let level15 =  // Min 13
        { startState with
            triangles= [{location=(0,0); direction=Down}; {location=(3,0); direction=Left}; {location=(0,1); direction=Right}]; 
            circles=   [{location=(1,1); color=Red}; {location=(1,2); color=Blue} ] 
            squares=   [{location=(0,0); color=Red; direction=Down}; {location=(2,2); color=Blue; direction=Up}];
        }
    
    let level16 =  // Min 14
        { startState with
            triangles= [{location=(0,0); direction=Right}; {location=(2,0); direction=Down}; {location=(2,1); direction=Left}; {location=(1,2); direction=Up}]; 
            circles=   [{location=(0,1); color=Red}; {location=(3,1); color=Blue} ] 
            squares=   [{location=(0,0); color=Red; direction=Right}; {location=(2,1); color=Blue; direction=Left}];
        }   
    let level17 =  // Min 20
        { startState with
            triangles= [{location=(0,0); direction=Down};{location=(0,1); direction=Right}; {location=(2,2); direction=Up};{location=(3,0); direction=Left}]; 
            circles=   [{location=(1,1); color=Red}; {location=(2,1); color=Black};{location=(3,1); color=Blue}] 
            squares=   [{location=(0,0); color=Red; direction=Down}; {location=(0,1); color=Black; direction=Right};{location=(3,0); color=Blue; direction=Left}];
        }

    let level29 = // Min 22
        { startState with
            triangles= [{location=(0,-2); direction=Down};{location=(0,2); direction=Up};{location=(2,0); direction=Right}]; 
            circles=   [{location=(-1,0); color=Orange}; {location=(0,-1); color=Red};{location=(1,0); color=Blue};{location=(0,1); color=Black}] 
            squares=   [{location=(-2,0); color=Red; direction=Right}; {location=(0,-2); color=Blue; direction=Down}; {location=(2,0); color=Black; direction=Left}; {location=(0,2); color=Orange; direction=Up}];
        }

    let level33 = // Min 45
        { startState with
            triangles= [{location=(0,0); direction=Down};{location=(0,2); direction=Right}; {location=(2,2); direction=Up};{location=(3,0); direction=Left}]; 
            circles=   [{location=(-1,-1); color=Blue}; {location=(0,-1); color=Red};{location=(1,-1); color=Black}] 
            squares=   [{location=(0,0); color=Blue; direction=Down}; {location=(0,2); color=Black; direction=Right};{location=(2,2); color=Red; direction=Up}];
        }

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
            |33 -> level33
            |_-> failwith "Unknown level"
