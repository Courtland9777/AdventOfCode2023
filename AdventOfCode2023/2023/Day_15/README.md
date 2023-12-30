## Problem: Managing Lenses in the Lava Production Facility

### Part One: Running the HASH Algorithm on Initialization Steps

#### Context:
- The facility uses a special HASH (Holiday ASCII String Helper) algorithm.
- This algorithm turns strings into a number between 0 and 255.

#### HASH Algorithm Procedure:
1. Start with a current value of 0.
2. For each character in the string:
   - Determine the ASCII code for the character.
   - Increase the current value by this ASCII code.
   - Multiply the current value by 17.
   - Set the current value to the remainder of itself divided by 256.
3. The final current value is the output of the HASH algorithm.

#### Task:
- Run the HASH algorithm on each step in the initialization sequence.
- The sequence consists of comma-separated steps.
- Calculate the sum of the HASH algorithm results for each step.

#### Example:
- Initialization Sequence: `rn=1,cm-,qp=3,cm=2,qp-,pc=4,ot=9,ab=5,pc-,pc=6,ot=7`
- Expected Output: Calculate the sum of HASH algorithm results for each step.

### Part Two: Organizing Lenses According to the HASHMAP Procedure

#### Context:
- The facility contains 256 boxes, each with slots for lenses.
- Lenses are organized by focal length (1 through 9).
- Each step in the initialization sequence includes a lens label and an operation.

#### HASHMAP Procedure for Each Step:
- The HASH algorithm result on the label indicates the box number.
- The operation character (`=` or `-`) determines the action:
  - `=`: Insert a lens with the given label and focal length.
  - `-`: Remove the lens with the given label.
- Lenses in a box are listed from front to back.
  
#### Task:
- Perform each step in the initialization sequence according to HASHMAP.
- Calculate the total focusing power of all lenses:
  - Focusing power of a lens = (1 + Box number) * (Slot number) * (Focal length).

#### Example:
- Given the initialization sequence from Part One, determine the total focusing power of the resulting lens configuration.
