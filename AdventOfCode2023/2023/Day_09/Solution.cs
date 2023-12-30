using AdventOfCode2023.Interfaces;

namespace AdventOfCode2023._2023.Day_09;

public class Solution(string input) : ISolution
{
    public string PartOne() => Solve(input, ExtrapolateRight).ToString();

    public string PartTwo() => Solve(input, ExtrapolateLeft).ToString();

    private static long Solve(string input, Func<long[], long> extrapolate) =>
        input.Split("\n").Select(ParseNumbers).Select(extrapolate).Sum();

    private static long[] ParseNumbers(string line) =>
        line.Split(" ").Select(long.Parse).ToArray();

    private static long[] Diff(long[] numbers) =>
        numbers.Zip(numbers.Skip(1)).Select(p => p.Second - p.First).ToArray();

    private static long ExtrapolateRight(long[] numbers) =>
        numbers.Length == 0 ? 0 : ExtrapolateRight(Diff(numbers)) + numbers.Last();

    private static long ExtrapolateLeft(long[] numbers) =>
        ExtrapolateRight(numbers.Reverse().ToArray());
}