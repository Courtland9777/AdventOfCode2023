using AdventOfCode2023._2023.Day_19;

namespace AdventOfCode2023Tests;

public class Day19Tests
{
    [Fact]
    public void PartOne_ReturnsCorrectValue()
    {
        // Arrange
        const string input = """

                             px{a<2006:qkq,m>2090:A,rfg}
                             pv{a>1716:R,A}
                             lnx{m>1548:A,A}
                             rfg{s<537:gd,x>2440:R,A}
                             qs{s>3448:A,lnx}
                             qkq{x<1416:A,crn}
                             crn{x>2662:A,R}
                             in{s<1351:px,qqz}
                             qqz{s>2770:qs,m<1801:hdj,R}
                             gd{a>3333:R,R}
                             hdj{m>838:A,pv}

                             {x=787,m=2655,a=1222,s=2876}
                             {x=1679,m=44,a=2067,s=496}
                             {x=2036,m=264,a=79,s=2244}
                             {x=2461,m=1339,a=466,s=291}
                             {x=2127,m=1623,a=2188,s=1013}

                             """;
        const string expectedValues = "19114";
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

                             px{a<2006:qkq,m>2090:A,rfg}
                             pv{a>1716:R,A}
                             lnx{m>1548:A,A}
                             rfg{s<537:gd,x>2440:R,A}
                             qs{s>3448:A,lnx}
                             qkq{x<1416:A,crn}
                             crn{x>2662:A,R}
                             in{s<1351:px,qqz}
                             qqz{s>2770:qs,m<1801:hdj,R}
                             gd{a>3333:R,R}
                             hdj{m>838:A,pv}

                             {x=787,m=2655,a=1222,s=2876}
                             {x=1679,m=44,a=2067,s=496}
                             {x=2036,m=264,a=79,s=2244}
                             {x=2461,m=1339,a=466,s=291}
                             {x=2127,m=1623,a=2188,s=1013}

                             """;

        const string expectedWinnings = "167409079868000";
        var solution = new Solution(input.Trim().Replace("\r", string.Empty));
        // Act
        var actualWinnings = solution.PartTwo();
        // Assert
        Assert.Equal(expectedWinnings, actualWinnings);
    }
}