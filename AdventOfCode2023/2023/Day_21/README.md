## Problem: Calculating Reachable Garden Plots with Limited Steps

### Part One: Fixed Map with Limited Steps

#### Context:
- A gardener needs to know which garden plots he can reach by walking exactly a specific number of steps.
- The map shows the gardener's starting position (S), garden plots (.), and rocks (#).

#### Task:
- Determine the number of distinct garden plots reachable from the starting position with exactly 64 steps.
- The gardener can move north, south, east, or west, but only onto garden plot tiles.

#### Puzzle Input:
- A grid representing the map.
- Each cell of the grid is either a garden plot (.), a rock (#), or the starting position (S).
- Example:

`...........
.....###.#.
.###.##..#.
..#.#...#..
....#.#....
.##..S####.
.##..#...#.
.......##..
.##.#.####.
.##..##.##.
...........`

#### Movement Rules:
- One step equals moving to an adjacent garden plot tile.
- Cannot move diagonally or onto rock tiles.

#### Objective:
- Calculate the total number of unique garden plots the gardener can reach in exactly 64 steps starting from (S).

### Part Two: Infinite Repetitive Map with Large Step Count

#### Adjusted Task:
- The gardener actually needs to walk 26,501,365 steps.
- The map repeats infinitely in all directions.

#### Infinite Map Representation:
- The finite map provided is a single tile in an infinitely repeating grid.
- The starting position (S) only exists in the central tile of the infinite grid; elsewhere, it's a garden plot (.)

#### Objective:
- Determine the number of unique garden plots reachable in exactly 26,501,365 steps on this infinite map.
