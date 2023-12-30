using AdventOfCode2023._2023.Day_23;

namespace AdventOfCode2023Tests;

public class Day23Tests
{
    [Fact]
    public void PartOne_ReturnsCorrectValue()
    {
        // Arrange
        const string input = """

                             #.#####################
                             #.......#########...###
                             #######.#########.#.###
                             ###.....#.>.>.###.#.###
                             ###v#####.#v#.###.#.###
                             ###.>...#.#.#.....#...#
                             ###v###.#.#.#########.#
                             ###...#.#.#.......#...#
                             #####.#.#.#######.#.###
                             #.....#.#.#.......#...#
                             #.#####.#.#.#########v#
                             #.#...#...#...###...>.#
                             #.#.#v#######v###.###v#
                             #...#.>.#...>.>.#.###.#
                             #####v#.#.###v#.#.###.#
                             #.....#...#...#.#.#...#
                             #.#########.###.#.#.###
                             #...###...#...#...#.###
                             ###.###.#.###v#####v###
                             #...#...#.#.>.>.#.>.###
                             #.###.###.#.###.#.#v###
                             #.....###...###...#...#
                             #####################.#

                             """;
        const string expectedValues = "94";
        var solution = new Solution(input.Trim().Replace("\r", string.Empty));
        // Act
        var actualValues = solution.PartOne();
        // Assert
        Assert.Equal(expectedValues, actualValues);
    }

    [Fact]
    public void PartTwo_ReturnsCorrectValue()
    {
        const string input = """

                             #.#####################
                             #.......#########...###
                             #######.#########.#.###
                             ###.....#.>.>.###.#.###
                             ###v#####.#v#.###.#.###
                             ###.>...#.#.#.....#...#
                             ###v###.#.#.#########.#
                             ###...#.#.#.......#...#
                             #####.#.#.#######.#.###
                             #.....#.#.#.......#...#
                             #.#####.#.#.#########v#
                             #.#...#...#...###...>.#
                             #.#.#v#######v###.###v#
                             #...#.>.#...>.>.#.###.#
                             #####v#.#.###v#.#.###.#
                             #.....#...#...#.#.#...#
                             #.#########.###.#.#.###
                             #...###...#...#...#.###
                             ###.###.#.###v#####v###
                             #...#...#.#.>.>.#.>.###
                             #.###.###.#.###.#.#v###
                             #.....###...###...#...#
                             #####################.#

                             """;

        const string expectedWinnings = "154";
        var solution = new Solution(input.Trim().Replace("\r", string.Empty));
        // Act
        var actualWinnings = solution.PartTwo();
        // Assert
        Assert.Equal(expectedWinnings, actualWinnings);
    }
}