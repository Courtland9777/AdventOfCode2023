using AdventOfCode2023._2023.Day_07;

namespace AdventOfCode2023Tests;

public class Day07Tests
{
    [Fact]
    public void PartOne_ReturnsCorrectValue()
    {
        // Arrange
        const string input = """

                             32T3K 765
                             T55J5 684
                             KK677 28
                             KTJJT 220
                             QQQJA 483

                             """;
        const string expectedWinnings = "6440";
        var solution = new Solution(input.Trim().Replace("\r", string.Empty));
        // Act
        var actualWinnings = solution.PartOne();
        // Assert
        Assert.Equal(expectedWinnings, actualWinnings);
    }

    [Fact]
    public void PartTwo_ReturnsCorrectValue()
    {
        const string input = """

                             32T3K 765
                             T55J5 684
                             KK677 28
                             KTJJT 220
                             QQQJA 483

                             """;

        const string expectedWinnings = "5905";
        var solution = new Solution(input.Trim().Replace("\r", string.Empty));
        // Act
        var actualWinnings = solution.PartTwo();
        // Assert
        Assert.Equal(expectedWinnings, actualWinnings);
    }
}