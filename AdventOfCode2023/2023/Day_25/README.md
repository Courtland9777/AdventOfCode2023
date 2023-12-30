## Problem: Component Disconnection for Power Load Reduction

### Context:
- A massive snow-producing apparatus on Snow Island is causing a power overload (Error 2023).
- The system is connected with hundreds of components and only three wires can be disconnected.
- The goal is to divide the components into two separate, disconnected groups to reduce power load.
- A wiring diagram (the puzzle input) details the connections between components.

### Task:
- Given a list of component connections, identify three wires to disconnect.
- Disconnecting these wires should divide the system into two separate groups of components.
- The connections are bidirectional and unique (no repeated connections).
- Calculate the product of the sizes of the two resulting groups.

### Puzzle Input:
- The input is a list of strings, where each string represents a component and its connections.
- Each string follows the format: `component_name: connected_component1 connected_component2 ...`
- Example: `"jqt: rhn xhk nvd", "rsh: frs pzl lsr", ...`

### Objective:
- Determine which three wires to disconnect.
- Calculate the product of the sizes of the two groups formed after disconnection.

### Example:
- Given Input:

`
jqt: rhn xhk nvd
rsh: frs pzl lsr
xhk: hfx
cmg: qnr nvd lhk bvb
rhn: xhk bvb hfx
bvb: xhk hfx
pzl: lsr hfx nvd
qnr: nvd
ntq: jqt hfx bvb xhk
nvd: lhk
lsr: lhk
rzs: qnr cmg lsr rsh
frs: qnr lhk lsr
`

### Solution Approach:
- Find and disconnect three wires.
- Result in two groups: one with 9 components, another with 6 components.
- Example Disconnections: hfx/pzl, bvb/cmg, nvd/jqt.
- Resulting Product: 54 (9 components * 6 components).

### Expected Output:
- The product of the sizes of the two groups after disconnection.