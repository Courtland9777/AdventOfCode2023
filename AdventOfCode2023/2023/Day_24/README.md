## Problem: Hailstone Trajectory Analysis and Collision Optimization

### Part One: Identifying Hailstone Path Intersections

#### Context:
- Hailstones are following linear trajectories in a 3D space.
- Their initial positions and constant velocities are known (puzzle input).

#### Task:
- Analyze the hailstones' paths to find intersections within a specific test area.
- Consider only the X and Y axes; ignore the Z axis.
- The test area is defined by minimum and maximum X and Y coordinates.

#### Puzzle Input Format:
- A list of strings representing hailstones.
- Each string: `px, py, pz @ vx, vy, vz` (position and velocity).
- Example: `"19, 13, 30 @ -2, 1, -2"`, `"18, 19, 22 @ -1, -1, -2"`, etc.

#### Test Area:
- For the example: X and Y positions each between 7 and 27.
- For actual data: X and Y positions each between 200000000000000 and 400000000000000.

#### Objective:
- Count the number of hailstone path intersections within the test area.

### Part Two: Optimal Rock Throw for Hailstone Collision

#### Task:
- Find a position and velocity to throw a rock so it collides with every hailstone.
- Include the Z axis in this analysis.
- The rock's velocity and direction remain constant after the throw.

#### Puzzle Input:
- Same as Part One.

#### Collision Calculation:
- Determine the time and position at which the rock will collide with each hailstone.
- Find a common point and time where all hailstones can be hit.

#### Expected Output:
- The sum of the X, Y, and Z coordinates of the initial position from where the rock should be thrown for an optimal collision with all hailstones.
