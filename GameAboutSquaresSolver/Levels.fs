module GameAboutSquares.Levels
    open GameAboutSquares.Solver
    let startState = {triangles =[]; circles=[]; squares = []; stepsTakenRev=[]}

    let level1 =  
        { startState with
            circles=[{location=(0,2); color=Red}; {location=(0,1); color=Blue}] 
            squares=[{location=(0,0); color=Blue; direction=Down}; {location=(0,3); color=Red; direction=Up}];
        }
 

    let level7 = 
        { startState with
            triangles = [{location=(0,2); direction=Right}; {location=(2,2); direction=Up} ] 
            circles=    [{location=(2,0); color=Blue} ] 
            squares=    [{location=(0,0); color=Blue; direction=Down} ] 
        }
 

    let level7b = 
        { startState with
            triangles = [{location=(0,3); direction=Right}; {location=(2,3); direction=Up}] 
            circles=[    {location=(2,1); color=Blue};      {location=(2,0); color=Red}] 
            squares=[    {location=(0,1); color=Blue; direction=Down}; {location=(0,2); color=Red; direction=Down} ]
        }
 
    let level10 = 
        { startState with
            triangles = [{location=(0,0); direction=Right}]; 
            circles=[ {location=(-2,0); color=Black}; {location=(-1,0); color=Red};{location=(1,0); color=Blue}]; 
            squares=[ {location=(0,2); color=Black; direction=Up}; {location=(0,-2); color=Red; direction=Down};{location=(2,0); color=Blue; direction=Left};];
        }

    let level11 = 
        { startState with
            triangles = [{location=(2,0); direction=Down}]; 
            circles=[ {location=(1,2); color=Red}; {location=(2,2); color=Blue};{location=(3,2); color=Black}]; 
            squares=[ {location=(0,0); color=Red; direction=Right}; {location=(4,0); color=Blue; direction=Left};{location=(2,4); color=Black; direction=Up};];
        } 

    let level14 =  
        { startState with
            circles=[ {location=(0,0); color=Red}; {location=(1,1); color=Blue};{location=(2,0); color=Orange}; {location=(2,2); color=Black}] 
            squares=[ {location=(1,0); color=Black; direction=Down}; {location=(0,1); color=Orange; direction=Right};{location=(2,1); color=Red; direction=Left};{location=(1,2); color=Blue; direction=Up}];
        }
 
 
    let level15 =  
        { startState with
            triangles = [{location=(0,0); direction=Down}; {location=(3,0); direction=Left}; {location=(0,1); direction=Right}]; 
            circles=[ {location=(1,1); color=Red}; {location=(1,2); color=Blue} ] 
            squares=[ {location=(0,0); color=Red; direction=Down}; {location=(2,2); color=Blue; direction=Up}];
        }
 
    
    let level17 =  
        { startState with
            triangles = [{location=(0,0); direction=Down};{location=(0,1); direction=Right}; {location=(2,2); direction=Up};{location=(3,0); direction=Left}]; 
            circles=[ {location=(1,1); color=Red}; {location=(2,1); color=Black};{location=(3,1); color=Blue}] 
            squares=[ {location=(0,0); color=Red; direction=Down}; {location=(0,1); color=Black; direction=Right};{location=(3,0); color=Blue; direction=Left}];
        }
 

    let level33 = 
        { startState with
            triangles = [{location=(0,0); direction=Down};{location=(0,2); direction=Right}; {location=(2,2); direction=Up};{location=(3,0); direction=Left}]; 
            circles=[ {location=(-1,-1); color=Blue}; {location=(0,-1); color=Red};{location=(1,-1); color=Black}] 
            squares=[ {location=(0,0); color=Blue; direction=Down}; {location=(0,2); color=Black; direction=Right};{location=(2,2); color=Red; direction=Up}];
        }
 
    let level n = 
        match n with
            |1 -> level1
            |10 -> level10
            |11 -> level11
            |14 -> level14
            |15 -> level15
            |17 -> level17
            |33 -> level33
            |_-> failwith "Unknown level"
