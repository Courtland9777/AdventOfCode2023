using AdventOfCode2023._2023.Day_22;

namespace AdventOfCode2023Tests;

public class Day22Tests
{
    [Fact]
    public void PartOne_ReturnsCorrectValue()
    {
        // Arrange
        const string input = """

                             1,0,1~1,2,1
                             0,0,2~2,0,2
                             0,2,3~2,2,3
                             0,0,4~0,2,4
                             2,0,5~2,2,5
                             0,1,6~2,1,6
                             1,1,8~1,1,9

                             """;
        const string expectedValues = "5";
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

                             1,0,1~1,2,1
                             0,0,2~2,0,2
                             0,2,3~2,2,3
                             0,0,4~0,2,4
                             2,0,5~2,2,5
                             0,1,6~2,1,6
                             1,1,8~1,1,9

                             """;

        const string expectedWinnings = "7";
        var solution = new Solution(input.Trim().Replace("\r", string.Empty));
        // Act
        var actualWinnings = solution.PartTwo();
        // Assert
        Assert.Equal(expectedWinnings, actualWinnings);
    }
}