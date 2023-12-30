## Problem: Module Communication Network Pulse Analysis

### Part One: Counting Pulses After Repeated Button Presses

#### Context:
- A network of modules communicates using high and low pulses.
- The network includes various types of modules like Flip-flop (%), Conjunction (&), and a broadcaster.
- The "button module" triggers a low pulse to the broadcaster, which then propagates through the network.

#### Module Behaviors:
- **Flip-flop (%):** Initially off. Ignores high pulses. Flips state on low pulse and sends a pulse (high if turned on, low if turned off).
- **Conjunction (&):** Remembers the most recent pulse type from each input. Sends low if all inputs are high; otherwise, sends high.
- **Broadcaster:** Sends the received pulse to all its destination modules.

#### Puzzle Input:
- Configuration of modules and their connections.
- Example:
`broadcaster -> a, b, c
%a -> b
%b -> c
%c -> inv
&inv -> a`

#### Task:
- Determine the number of low and high pulses sent after pushing the button 1000 times.
- Each button push sends a low pulse to the broadcaster.
- Calculate the total number of low and high pulses sent after 1000 button pushes.
- Return the product of these totals.

### Example Scenario:
- With a given network configuration, analyze the sequence of pulse transmissions.
- Example:
`broadcaster -> a
%a -> inv, con
&inv -> b
%b -> con
&con -> output`
- Trace the pulses for each button press and observe the changes in the module states.

### Part Two: Targeting a Specific Module

#### Additional Context:
- The final machine (module named rx) activates with a single low pulse.
- Reset all modules to their default states.

#### Task:
- Determine the minimum number of button presses required to deliver a single low pulse to the module named rx.
- Ensure all pulses from a button press are fully handled before the next press.
