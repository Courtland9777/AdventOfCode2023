## Problem: Optimizing Crucible Routes for Minimum Heat Loss

### Part One: Normal Crucible Navigation

#### Context:
- Elves are transporting lava in top-heavy crucibles through a city.
- The crucibles are hard to steer straight for long distances.
- A map indicates heat loss for each city block.

#### Crucible Movement Constraints:
- The crucible can move at most three blocks in a straight line before turning 90 degrees left or right.
- It cannot reverse direction.
- After entering each city block, it may only turn left, continue straight, or turn right.

#### Map Format:
- Each city block is represented by a digit indicating heat loss.
- Starting point: top-left city block.
- Destination: bottom-right city block.
- Example:
`2413432311323
3215453535623
3255245654254
3446585845452
4546657867536
1438598798454
4457876987766
3637877979653
4654967986887
4564679986453
1224686865563
2546548887735
4322674655533`

#### Task:
- Find the path from the starting point to the destination that incurs the least heat loss.
- Follow the movement constraints for the crucible.

### Part Two: Ultra Crucible Navigation

#### New Constraints for Ultra Crucibles:
- The ultra crucible must move a minimum of four blocks in one direction before turning.
- It can move a maximum of ten consecutive blocks without turning.

#### Objective:
- Calculate the path for the ultra crucible that results in the minimum possible heat loss.

#### Example:
- Given map:
`111111111111
999999999991
999999999991
999999999991
999999999991`

- Find the optimal route considering the new constraints for ultra crucibles.
