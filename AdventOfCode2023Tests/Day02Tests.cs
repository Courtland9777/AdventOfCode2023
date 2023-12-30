using AdventOfCode2023._2023.Day_02;

namespace AdventOfCode2023Tests;

public class Day02Tests
{
    [Fact]
    public void PartOne_ReturnsCorrectValue()
    {
        // Arrange
        const string input = """

                             Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
                             Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
                             Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
                             Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
                             Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green

                             """;
        const string expectedValues = "8";
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

                             Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
                             Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
                             Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
                             Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
                             Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green

                             """;

        const string expectedWinnings = "2286";
        var solution = new Solution(input.Trim().Replace("\r", string.Empty));
        // Act
        var actualWinnings = solution.PartTwo();
        // Assert
        Assert.Equal(expectedWinnings, actualWinnings);
    }
}