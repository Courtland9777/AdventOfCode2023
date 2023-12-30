## Problem: Analyzing Pipe Maze to Find Farthest Points and Enclosed Area

### Part One: Identifying Farthest Point in the Pipe Loop

#### Context:
- A maze of pipes is sketched, consisting of vertical, horizontal, and bending pipes.
- The pipes form a continuous loop.

#### Pipe Types:
- **Vertical Pipe (|):** Connects north and south.
- **Horizontal Pipe (-):** Connects east and west.
- **Bend Pipes (L, J, 7, F):** 90-degree bends connecting two directions.
- **Empty Space (.):** No pipe present.
- **Start Position (S):** Pipe location of an animal, type unknown.

#### Puzzle Input:
- A grid representing the arrangement of pipes.
- Example:
`.....
.F-7.
.|.|.
.L-J.
.....`

#### Task:
- Determine the longest number of steps along the pipe loop from the starting position (S).
- Steps are counted along the pipe, turning at bends and junctions.

#### Example:
- In the given pipe layout, calculate the farthest point from the start in terms of steps along the pipe.

### Part Two: Calculating Enclosed Area by the Pipe Loop

#### Objective:
- Determine the area enclosed by the pipe loop.
- Enclosed tiles are those surrounded by the loop, considering the loop's connectivity.

#### Considerations:
- Any tile not part of the main loop can be enclosed by it.
- Enclosed area includes tiles not occupied by the pipes themselves.

#### Example:
- Calculate how many tiles are enclosed within the loop of the given pipe layout.
