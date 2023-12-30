## Problem: Evaluating Scratchcards

### Part One: Calculating Scratchcard Points

#### Context:
- You're assisting an Elf in understanding the value of a pile of scratchcards.

#### Task:
- Determine the total points of all scratchcards.

#### Methodology:
1. **Identification**: Each scratchcard has two lists separated by a vertical bar (|) - a list of winning numbers and a list of numbers you have.
2. **Scoring System**: 
   - First match gives 1 point.
   - Each subsequent match doubles the card's points.
3. **Goal**: Calculate the total points for the pile of scratchcards.

#### Example:
`Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19
Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1
Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83
Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36
Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11`

- Determine matches between the two lists.
- Calculate each card's points.
- Sum up the points for all cards.

### Part Two: Winning Additional Scratchcards

#### New Rule:
- Winning numbers result in winning more scratchcards, not points.

#### Mechanics:
- The number of matches on a card determines how many additional scratchcards are won from the ones below it.
- New scratchcards are scored and can win further scratchcards.

#### Example Revised:
`Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19
Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1
Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83
Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36
Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11`

- Card 1 with four matches wins copies of the next four cards.
- Continue the process with each new card won.

#### Objective:
- Process all original and copied scratchcards.
- Count the total number of scratchcards, including the originals and those won.

#### Task:
- Calculate the total number of scratchcards obtained after processing the entire pile as per the new rule.
