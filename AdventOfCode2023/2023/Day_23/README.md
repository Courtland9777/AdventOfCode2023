## Problem: Optimal Hiking Path Calculation

### Part One: Hiking on Icy Trails

#### Context:
- A map represents hiking trails, forests, and slopes.
- Trails are marked as `.` (path), forests as `#`, and slopes as `^`, `>`, `v`, `<`.
- The goal is to travel from the top row to the bottom row of the map.

#### Task:
- Calculate the longest possible hike from the starting position (top row) to the destination (bottom row).
- Slopes (`^`, `>`, `v`, `<`) are icy: must move downhill in the direction of the arrow.
- Avoid stepping on the same tile twice to ensure a scenic hike.

#### Puzzle Input:
- A grid representing the hiking map.
- Each cell of the grid is a character: `.`, `#`, `^`, `>`, `v`, `<`.
- Example:
`#.#####################
#.......#########...###
#######.#########.#.###
###.....#.>.>.###.#.###
###v#####.#v#.###.#.###
###.>...#.#.#.....#...#
###v###.#.#.#########.#
###...#.#.#.......#...#
#####.#.#.#######.#.###
#.....#.#.#.......#...#
#.#####.#.#.#########v#
#.#...#...#...###...>.#
#.#.#v#######v###.###v#
#...#.>.#...>.>.#.###.#
#####v#.#.###v#.#.###.#
#.....#...#...#.#.#...#
#.#########.###.#.#.###
#...###...#...#...#.###
###.###.#.###v#####v###
#...#...#.#.>.>.#.>.###
#.###.###.#.###.#.#v###
#.....###...###...#...#
#####################.#`

#### Objective:
- Find the longest path from the start to the end without repeating tiles.
- Count the total number of steps in this longest path.

### Part Two: Hiking on Dry Trails

#### Adjusted Task:
- Treat all slopes as normal paths (`.`).
- The rest of the map remains unchanged.
- Still avoid stepping on the same tile twice.

#### Objective:
- Recalculate the longest possible hiking path under these new conditions.
- Determine the total number of steps in this new longest path.
