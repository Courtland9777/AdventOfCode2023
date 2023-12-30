## Problem: Optimizing Agricultural Production

### Part One: Mapping Seeds to Locations

#### Context:
- You are helping a gardener to optimize food production.
- An almanac lists seeds and maps showing how to convert seeds to soil, fertilizer, water, light, temperature, humidity, and finally location.

#### Task:
- Determine the lowest location number that corresponds to any of the initial seeds.

#### Process:
1. **Seed-to-Soil Mapping**: Convert each seed number to a soil number.
2. **Subsequent Mappings**: Map soil numbers to fertilizer, then to water, light, temperature, humidity, and location.
3. **Final Objective**: Find the lowest location number for the given seeds.

#### Example Input:
`seeds: 79 14 55 13`

`seed-to-soil map:
50 98 2
52 50 48`

`soil-to-fertilizer map:
0 15 37
37 52 2
39 0 15`

`fertilizer-to-water map:
49 53 8
0 11 42
42 0 7
57 7 4`

`water-to-light map:
88 18 7
18 25 70`

`light-to-temperature map:
45 77 23
81 45 19
68 64 13`

`temperature-to-humidity map:
0 69 1
1 0 69`

`humidity-to-location map:
60 56 37
56 93 4`

- Convert seed numbers through the maps to find their corresponding location numbers.
- Find the smallest location number among the initial seeds.

### Part Two: Expanded Seed Ranges

#### Updated Challenge:
- The initial `seeds:` line describes ranges, not individual seeds.

#### New Interpretation:
`Seeds: 79 14 55 13`

- Represents two ranges: 79-92 and 55-67.

#### Expanded Task:
- Consider all seed numbers within the provided ranges.
- Determine the lowest location number for this expanded list of seeds.

#### Objective:
- Calculate the lowest location number that corresponds to any seed number in the given ranges.
