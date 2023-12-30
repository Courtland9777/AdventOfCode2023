## Problem: Safe Brick Disintegration in a Stacked Structure

### Context:
- A stack of sand bricks (represented as 3D line segments) needs to be disintegrated into sand for water filtration.
- Disintegrating the wrong brick could cause a dangerous toppling of the stack.

### Task:
- Analyze which bricks can be safely disintegrated without causing any other bricks to fall.

### Puzzle Input:
- Each line represents a brick's position in 3D space.
- Format: `x1,y1,z1~x2,y2,z2`, where `x`, `y`, `z` are coordinates of the brick's ends.
- Bricks can be horizontal or vertical.
- Example Input: 
`1,0,1~1,2,1
0,0,2~2,0,2
0,2,3~2,2,3
0,0,4~0,2,4
2,0,5~2,2,5
0,1,6~2,1,6
1,1,8~1,1,9`

### Bricks Arrangement:
- Bricks are initially free-falling and will come to rest upon the first other brick or the ground they encounter.
- Bricks do not rotate and occupy unique positions.
- Ground level is at `z=0`.

### Task Details:
- Determine the final resting positions of all bricks.
- Analyze the stability of the stack after all bricks have settled.
- Identify bricks that can be safely disintegrated without causing any bricks above them to fall.
- A brick can be disintegrated if removing it doesn't cause any other bricks to fall further downward.
- Count the number of bricks able to be safely disintegrated.

### Considerations:
- Bricks can be disintegrated even if surrounded by other bricks.
- Focus on vertical stability; a brick is only supported if it's directly above another brick or ground.

### Objective:
- After simulating the final arrangement of the bricks, determine how many bricks could be safely disintegrated without affecting the stability of the remaining structure.
