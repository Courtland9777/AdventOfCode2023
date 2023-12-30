## Problem: Calculating Load on Parabolic Reflector Dish

### Part One: Tilting Rocks North

#### Context:
- A parabolic reflector dish's focus is controlled by rocks on a platform.
- Rounded rocks (O) roll when tilted, cube-shaped rocks (#) stay in place.

#### Puzzle Input:
- A grid representing the positions of empty spaces (.), rounded rocks (O), and cube-shaped rocks (#).
- Example:
`O....#....
O.OO#....#
.....##...
OO.#O....O
.O.....O#.
O.#..O.#.#
..O..#O..O
.......O..
#....###..
#OO..#....`

#### Task:
- Tilt the platform north so all rounded rocks roll as far as they go.
- Calculate the total load on the north support beams.

#### Load Calculation:
- The load of each rounded rock is the number of rows from the rock to the south edge, including the rock's row.
- Cube-shaped rocks do not contribute to the load.
- Total load is the sum of loads from all rounded rocks.

#### Example:
- After tilting north, calculate the total load on the north support beams.

### Part Two: Running Spin Cycle for Extended Period

#### New Challenge:
- Run the "spin cycle" which tilts the platform north, west, south, and east in sequence.
- Rounded rocks roll to the extent possible with each tilt.

#### Procedure:
- Perform the spin cycle for 1,000,000,000 cycles.
- Each cycle consists of four tilts in the specified order.

#### Objective:
- Determine the total load on the north support beams after 1,000,000,000 cycles.
