## Problem: Elf Trebuchet Calibration

### Part One: Basic Calibration

#### Context:
- Tasked to restore global snow production.
- Need to check 50 locations marked with stars by December 25th.
- Puzzles grant stars for progress.

#### Task:
- Calculate the sum of calibration values from the Elves' document.

#### Calibration Method:
1. **Document Format**: Each line contains text with a calibration value.
2. **Value Extraction**: Combine the first and last digit on each line to form a two-digit number.
3. **Summation**: Add all these two-digit numbers to find the total calibration value.

#### Example:
`1abc2
pqr3stu8vwx
a1b2c3d4e5f
treb7uchet`

- Total Calibration Value = 12 + 38 + 15 + 77 = 142

### Part Two: Enhanced Calibration

#### New Challenge:
- Some digits are spelled out as words (one, two, three, etc.).

#### Enhanced Calibration Method:
1. **Updated Extraction**: Identify both numerical and spelled-out digits.
2. **Combination**: Combine the first and last digit (numerical or spelled out) into a two-digit number.
3. **Summation**: Add all these two-digit numbers for the total calibration value.

#### Example:
`two1nine -> Calibration value: 29
eightwothree -> Calibration value: 83
abcone2threexyz-> Calibration value: 13
xtwone3four -> Calibration value: 24
4nineeightseven2 -> Calibration value: 42
zoneight234 -> Calibration value: 14
7pqrstsixteen -> Calibration value: 76`

- Total Calibration Value = 29 + 83 + 13 + 24 + 42 + 14 + 76 = 281