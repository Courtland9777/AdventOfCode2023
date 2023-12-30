## Problem: Winning Toy Boat Races

### Part One: Multiple Short Races

#### Context:
- You are participating in toy boat races.
- Each boat's speed increases by 1 mm/ms for each millisecond the button is held at the race start.
- The goal is to travel farther than the current record within the race time.

#### Task:
- Calculate the number of ways to beat the record in each race.

#### Race Mechanics:
- The button hold time at the start of the race determines the boat's speed.
- The race time is fixed, and the distance record needs to be beaten.
- Holding the button consumes race time.

#### Example Input:
`Time: 7 15 30
Distance: 9 40 200`

- Calculate winning strategies for each race and multiply the number of ways together.

### Part Two: A Single, Longer Race

#### Updated Challenge:
- The race times and distances are a single continuous number, not separate races.

#### New Input Interpretation:
`Time: 71530
Distance: 940200`

- Determine the range of button hold times that can beat the record in this longer race.

#### Objective:
- Calculate the total number of ways to beat the record in the long race.
