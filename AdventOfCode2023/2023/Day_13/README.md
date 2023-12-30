## Problem: Identifying Lines of Reflection in Mirror Patterns

### Part One: Analyzing Mirror Reflection Patterns

#### Context:
- You encounter a valley filled with mirrors and need to identify where the mirrors are.
- Patterns of ash (.) and rocks (#) indicate the presence of mirrors.

#### Puzzle Input:
- A series of patterns represented by grids of ash and rocks.
- Example:
`#.##..##.
..#.##.#.
##......#
##......#
..#.##.#.
..##..##.
#.#.##.#.`

#### Task:
- Determine the line of reflection in each pattern, which could be either vertical or horizontal.
- A pattern reflects across a line if the opposite sides of the line mirror each other.

#### Reflection Identification:
- **Vertical Line of Reflection:**
- Between two columns where each column on one side mirrors its counterpart on the other side.
- Example: The line between columns 5 and 6 in the first pattern.
- **Horizontal Line of Reflection:**
- Between two rows where each row on one side mirrors its counterpart on the other side.
- Example: The line between rows 4 and 5 in the second pattern.

#### Summarization:
- For each vertical line of reflection, add the number of columns to its left.
- For each horizontal line of reflection, add 100 times the number of rows above it.
- Calculate the total sum for all patterns.

#### Example:
- In the given example, the total is 405 (5 columns to the left of the vertical line plus 100 times 4 rows above the horizontal line).

### Objective:
- Identify the line of reflection in each pattern and calculate the summarized number for all patterns.
