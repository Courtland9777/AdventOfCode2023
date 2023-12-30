## Problem: Maximizing Energized Tiles in a Beam Reflection Grid

### Part One: Default Beam Path Analysis

#### Context:
- A beam of light is reflected and split by mirrors and splitters in a grid contraption.
- The goal is to determine how many tiles become energized by the beam.

#### Contraption Layout:
- The grid contains empty spaces (.), mirrors (/ and \), and splitters (| and -).
- The beam enters from the top-left corner, moving right.
- Behavior on encountering different objects:
  - **Empty space (.):** Continues in the same direction.
  - **Mirror (/ or \\):** Reflected 90 degrees.
  - **Pointy end of splitter (| or -):** Passes through like empty space.
  - **Flat side of splitter (| or -):** Splits into two beams in the directions the splitter points.

#### Puzzle Input:
- A grid representing the contraption layout.
- Example:
`.|...\....
|.-.\.....
.....|-...
........|.
..........
.........\
..../.\\..
.-.-/..|..
.|....-|.\
..//.|....`

#### Task:
- Calculate the number of tiles that get energized by the beam.
- Energized tiles are those where the beam passes through, reflects, or splits.

### Part Two: Finding Optimal Beam Entry Point

#### New Challenge:
- The beam can now enter from any edge tile of the grid.
- Determine the entry point that results in the maximum number of energized tiles.

#### Procedure:
- Test all possible starting points for the beam:
- Top row: Beam heading downward.
- Bottom row: Beam heading upward.
- Leftmost column: Beam heading right.
- Rightmost column: Beam heading left.
- Corner tiles have two possible directions.

#### Objective:
- Identify the initial beam configuration that energizes the most tiles.
- Calculate the total number of energized tiles for this optimal configuration.
