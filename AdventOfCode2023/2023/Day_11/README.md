## Problem: Calculating Shortest Paths Between Galaxies in an Expanding Universe

### Part One: Cosmic Expansion with Doubling Empty Rows and Columns

#### Context:
- An image of the universe includes empty space (.) and galaxies (#).
- Rows and columns without galaxies expand due to cosmic expansion.

#### Puzzle Input:
- A grid representing galaxies and empty space.
- Example:
`...#......
.......#..
#.........
..........
......#...
.#........
.........#
..........
.......#..
#...#.....`

#### Task:
- Double the size of any row or column that contains no galaxies.
- Calculate the sum of the shortest paths between every pair of galaxies.
- Shortest paths can move up, down, left, or right through any space.

#### Shortest Path Calculation:
- Determine the shortest path length between each pair of galaxies.
- Sum these lengths for all unique galaxy pairs.
- Example: In a 9-galaxy grid, there are 36 unique pairs.

### Part Two: Massive Cosmic Expansion

#### New Expansion Rule:
- Replace each empty row or column with 1,000,000 empty rows or columns.

#### Objective:
- Expand the universe according to the new rules.
- Calculate the sum of the shortest paths between every pair of galaxies with the expanded universe.
