using AdventOfCode2023._2023.Day_16;

namespace AdventOfCode2023Tests;

public class Day16Tests
{
    [Fact]
    public void PartOne_ReturnsCorrectValue()
    {
        // Arrange
        const string input = """

                             .|<2<\....
                             |v-v\^....
                             .v.v.|->>>
                             .v.v.v^.|.
                             .v.v.v^...
                             .v.v.v^..\
                             .v.v/2\\..
                             <-2-/vv|..
                             .|<<<2-|.\
                             .v//.|.v..

                             """;
        const string expectedValues = "46";
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

                             .|<2<\....
                             |v-v\^....
                             .v.v.|->>>
                             .v.v.v^.|.
                             .v.v.v^...
                             .v.v.v^..\
                             .v.v/2\\..
                             <-2-/vv|..
                             .|<<<2-|.\
                             .v//.|.v..

                             """;

        const string expectedWinnings = "51";
        var solution = new Solution(input.Trim().Replace("\r", string.Empty));
        // Act
        var actualWinnings = solution.PartTwo();
        // Assert
        Assert.Equal(expectedWinnings, actualWinnings);
    }
}