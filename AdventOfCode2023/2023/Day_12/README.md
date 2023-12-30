## Problem: Determining Possible Arrangements of Spring Conditions

### Part One: Analyzing Damaged Spring Records

#### Context:
- Springs are arranged in rows and categorized as operational (.) or damaged (#).
- Condition records show each spring's state and sizes of contiguous groups of damaged springs.

#### Puzzle Input:
- Rows of springs with operational, damaged, or unknown (?) conditions.
- List of sizes of contiguous groups of damaged springs.
- Example Input:
`#.#.### 1,1,3
.#...#....###. 1,1,3
.#.###.#.###### 1,3,1,6
####.#...#... 4,1,1
#....######..#####. 1,6,5
.###.##....# 3,2,1`

#### Task:
- Determine how many different arrangements of operational and broken springs fit the given criteria for each row.
- Consider unknown spring conditions (?) and the listed sizes of contiguous damaged groups.

#### Example:
- `???.### 1,1,3` - Calculate the number of arrangements where there are separate groups of one, one, and three broken springs in that order.
- Sum the total possible arrangements for all rows.

### Part Two: Unfolding the Spring Condition Records

#### Modified Input Format:
- Replace the list of spring conditions with five copies of itself, separated by '?'.
- Replace the list of contiguous damaged groups with five copies of itself, separated by ','.
- Example Modification:
- Original Row: `.# 1`
- Modified Row: `.#?.#?.#?.#?.# 1,1,1,1,1`

#### New Task:
- Recalculate the number of possible arrangements for each row using the unfolded condition records.
- Determine the total sum of possible arrangement counts after unfolding.

#### Example:
- `???.### 1,1,3` becomes `???.###????.###????.###????.###????.### 1,1,3,1,1,3,1,1,3,1,1,3,1,1,3`.
- Calculate the new sum of possible arrangement counts for all rows.
