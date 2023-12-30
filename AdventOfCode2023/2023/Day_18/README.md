## Problem: Calculating Lava Lagoon Capacity from Dig Plans

### Part One: Original Dig Plan Analysis

#### Context:
- Elves are creating a lava lagoon using a dig plan, which includes digging directions and color codes.
- The dig plan specifies how to dig trenches for the lagoon.

#### Dig Plan Format:
- Each line in the plan includes a direction (U, D, L, R) and distance in meters, followed by a color code in RGB hexadecimal format.
- Example Plan:
`R 6 (#70c710)
D 5 (#0dc571)
L 2 (#5713f0)
D 2 (#d2c081)
R 2 (#59c680)
D 2 (#411b91)
L 5 (#8ceee2)
U 2 (#caa173)
L 1 (#1b58a2)
U 2 (#caa171)
R 2 (#7807d2)
U 3 (#a77fa3)
L 2 (#015232)
U 2 (#7a21e3)`

#### Task:
- Calculate the lagoon's capacity in cubic meters based on the original dig plan.
- The digger starts in a 1-meter cube and digs trenches according to the plan.
- Trenches are one meter deep, and the interior is also dug out to the same depth.
- Example Output: For the given plan, the lagoon holds 62 cubic meters of lava.

#### Procedure:
- Create a grid representation of the dig plan.
- Calculate the total area covered by the trenches and the interior.
- Multiply by the depth (1 meter) to get the lagoon's capacity in cubic meters.

### Part Two: Decoding Correct Instructions from Color Codes

#### New Context:
- There's an error in the dig plan: color codes and instructions are swapped.
- The correct instructions are encoded in the color codes.

#### Decoding Instructions:
- Each color code (hexadecimal) has two parts:
- The first five digits represent the distance in meters.
- The last digit represents the direction (0 for R, 1 for D, 2 for L, 3 for U).
- Example Conversion:
`#70c710 = R 461937
#0dc571 = D 56407
#5713f0 = R 356671
#d2c081 = D 863240
#59c680 = R 367720
#411b91 = D 266681
#8ceee2 = L 577262
#caa173 = U 829975
#1b58a2 = L 112010
#caa171 = D 829975
#7807d2 = L 491645
#a77fa3 = U 686074
#015232 = L 5411
#7a21e3 = U 500254`

#### Revised Task:
- Decode the true instructions from the hexadecimal color codes.
- Calculate the lagoon's capacity using the corrected dig plan.

#### Objective:
- Determine the new capacity of the lagoon in cubic meters using the decoded dig plan.
