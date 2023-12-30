using AdventOfCode2023._2023.Day_25;

namespace AdventOfCode2023Tests;

public class Day25Tests
{
    [Fact]
    public void PartOne_ReturnsCorrectValue()
    {
        // Arrange
        const string input = """

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

                             """;
        const string expectedValues = "54";
        var solution = new Solution(input.Trim().Replace("\r", string.Empty));
        // Act
        var actualValues = solution.PartOne();
        // Assert
        Assert.Equal(expectedValues, actualValues);
    }
}