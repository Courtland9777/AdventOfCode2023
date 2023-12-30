## Problem: Extrapolating Values from Historical Data

### Part One: Predicting the Next Value in Each History

#### Context:
- You have a set of historical data sequences (your puzzle input).
- Each line contains the history of a value and its changes over time.

#### Task:
- Predict the next value in each historical sequence.

#### Method:
1. **Create Difference Sequences:** Generate new sequences from the difference at each step of the history. 
2. **Iterate Until All Zeros:** Repeat this process until a sequence consists entirely of zeroes.
3. **Extrapolate the Next Value:** 
    - Add a zero to the end of the zero sequence.
    - Calculate the next value in each sequence from the bottom up, using the values to the left and below.

#### Example:
- Given History: `0 3 6 9 12 15`
- Difference Sequences: 
  - `3 3 3 3 3` 
  - `0 0 0 0`
- Extrapolated Next Value: `18`

#### Objective:
- Calculate the sum of the next extrapolated values for all given histories.

### Part Two: Extrapolating Previous Values

#### New Challenge:
- Now, extrapolate the previous value for each history.

#### Modified Method:
1. **Add Zero to the Beginning:** Instead of adding a zero to the end, add it to the beginning of the zero sequence.
2. **Fill in New First Values:** Calculate new first values for each previous sequence from bottom to top.

#### Example:
- Given History: `10 13 16 21 30 45`
- Difference Sequences: 
  - `3 3 5 9 15`
  - `0 2 4 6`
  - `2 2 2`
  - `0 0`
- Extrapolated Previous Value: `5`

#### Objective:
- Calculate the sum of the extrapolated previous values for all given histories.
