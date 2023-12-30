## Problem: Workflow-Based Sorting System for Machine Parts

### Part One: Sorting Specific Parts Based on Workflows

#### Context:
- Machine parts are rated in four categories: x, m, a, s.
- Each part goes through workflows with rules determining the part's acceptance or rejection.

#### Workflow System:
- Workflows consist of rules using the format `{condition:destination}`.
- Conditions involve comparisons with part ratings.
- Destinations include other workflows, acceptance (A), or rejection (R).
- Parts follow the first matching rule in a workflow and immediately proceed to the indicated destination.
- A part stops processing once accepted (A) or rejected (R).

#### Puzzle Input:
- Workflows with their rules.
- Rated parts to be sorted.
- Example of Workflows:
`px{a<2006:qkq,m>2090:A,rfg}
pv{a>1716:R,A}
lnx{m>1548:A,A}
rfg{s<537:gd,x>2440:R,A}
qs{s>3448:A,lnx}
qkq{x<1416:A,crn}
crn{x>2662:A,R}
in{s<1351:px,qqz}
qqz{s>2770:qs,m<1801:hdj,R}
gd{a>3333:R,R}
hdj{m>838:A,pv}`

- Example of Parts:
`{x=787,m=2655,a=1222,s=2876}
{x=1679,m=44,a=2067,s=496}
{x=2036,m=264,a=79,s=2244}
{x=2461,m=1339,a=466,s=291}
{x=2127,m=1623,a=2188,s=1013}`

#### Task:
- Determine the outcome (accepted or rejected) for each given part based on the workflows.
- For accepted parts, sum up their ratings (x, m, a, s).

#### Example Scenario:
- Trace the path of each part through the workflows.
- Calculate the total sum of ratings for all accepted parts.

### Part Two: Analyzing All Possible Rating Combinations

#### Context:
- Instead of sorting individual parts, predict the outcome for all possible rating combinations.
- Ratings (x, m, a, s) range from 1 to 4000.

#### Task:
- Determine how many distinct combinations of ratings will be accepted by the given workflows.
- Consider only the workflows; the specific parts from Part One are not relevant here.

#### Objective:
- Calculate the total number of distinct rating combinations that would be accepted.
