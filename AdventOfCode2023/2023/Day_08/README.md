## Problem: Navigating a Network of Nodes

### Part One: Single Path Navigation

#### Context:
- You have a sequence of left/right instructions and a network of labeled nodes (your puzzle input).
- Your goal is to reach the node labeled ZZZ starting from AAA.

#### Network Format:
- Each node is defined with two connected nodes.
- Example:
`AAA = (BBB, CCC)
BBB = (DDD, EEE)
CCC = (ZZZ, GGG)
DDD = (DDD, DDD)
EEE = (EEE, EEE)
GGG = (GGG, GGG)
ZZZ = (ZZZ, ZZZ)`

#### Task:
- Use the left/right instructions to navigate from AAA to ZZZ.
- If you run out of instructions, repeat them from the beginning.
- Calculate the number of steps required to reach ZZZ.

#### Example:
- Given Instructions: `RL`
- Network:
`AAA = (BBB, CCC)
BBB = (DDD, EEE)
CCC = (ZZZ, GGG)
DDD = (DDD, DDD)
EEE = (EEE, EEE)
GGG = (GGG, GGG)
ZZZ = (ZZZ, ZZZ)`
- 
- Determine the number of steps to reach ZZZ.

### Part Two: Multi-Path Navigation for Ghosts

#### New Challenge:
- Simultaneously navigate from all nodes ending in A to all nodes ending in Z.

#### Modified Navigation:
- Start at every node ending with A.
- Follow the left/right instructions simultaneously from each starting node.
- Continue until all current nodes end with Z.

#### Example:
- Given Instructions: `LR`
- Network:
`11A = (11B, XXX)
11B = (XXX, 11Z)
11Z = (11B, XXX)
22A = (22B, XXX)
22B = (22C, 22C)
22C = (22Z, 22Z)
22Z = (22B, 22B)
XXX = (XXX, XXX)`

- Calculate the number of steps until all paths lead to nodes ending with Z.
