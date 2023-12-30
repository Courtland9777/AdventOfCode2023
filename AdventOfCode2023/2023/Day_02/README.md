## Problem: Cube Game Analysis

### Part One: Identifying Possible Games

#### Context:
- A cube game involves guessing the number of colored cubes (red, green, blue) in a bag.

#### Task:
- Determine which games are possible with a specific number of cubes in the bag.

#### Given Configuration:
- Bag contains 12 red, 13 green, and 14 blue cubes.

#### Methodology:
1. **Assessment**: For each game, evaluate if the revealed cubes could come from the given bag configuration.
2. **Criteria**: A game is possible if, at no point, the number of revealed cubes of a color exceeds the number in the bag.
3. **Goal**: Find games that are possible with the given cube numbers.

#### Example:
`Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green`

- Check if each game's cube reveals fit within the bag's capacity.
- Sum the IDs of all possible games.

### Part Two: Minimum Cubes Required

#### New Task:
- Calculate the fewest number of cubes needed for each game to be possible.

#### Methodology:
1. **Analysis**: For each game, determine the minimum number of each color required.
2. **Calculation**: The "power" of a set of cubes is the product of the numbers of red, green, and blue cubes.
3. **Objective**: Calculate the total sum of powers for the minimum sets of all games.

#### Example Analysis:
`Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green`

- Find the minimum number of cubes for each color.
- Calculate the power of each game's minimum set.
- Sum the powers of all games' minimum sets.
