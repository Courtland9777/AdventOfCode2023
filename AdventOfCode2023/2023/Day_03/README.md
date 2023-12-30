## Problem: Analyzing Engine Schematics

### Part One: Summing Part Numbers

#### Context:
- Assistance is required to identify a missing engine part using an engine schematic.

#### Task:
- Calculate the sum of all part numbers in the engine schematic.

#### Methodology:
1. **Identification**: Part numbers are digits adjacent to symbols in the schematic (diagonal adjacency counts).
2. **Exclusion**: Periods (.) are not considered symbols.
3. **Goal**: Sum all identified part numbers.

#### Example:
`467..114..
...*......
..35..633.
......#...
617*......
.....+.58.
..592.....
......755.
...$.*....
.664.598..`
- Identify part numbers adjacent to symbols.
- Exclude numbers not adjacent to symbols (e.g., 114, 58).
- Add up the part numbers.

### Part Two: Calculating Gear Ratios

#### New Task:
- Identify gears in the schematic and calculate their ratios.

#### Gear Identification:
- A gear is represented by a * symbol adjacent to exactly two part numbers.

#### Gear Ratio Calculation:
- Multiply the two adjacent part numbers to get the gear ratio.

#### Example Revised:
`467..114..
...*......
..35..633.
......#...
617*......
.....+.58.
..592.....
......755.
...$.*....
.664.598..`

- Identify gears (e.g., * adjacent to 467 and 35).
- Calculate gear ratios (e.g., 467 * 35).
- Add up all gear ratios.

#### Objective:
- Determine the sum of gear ratios for all gears in the schematic.
