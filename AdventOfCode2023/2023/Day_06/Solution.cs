using System.Text.RegularExpressions;
using AdventOfCode2023.Interfaces;

namespace AdventOfCode2023._2023.Day_06;

public class Solution(string input) : ISolution
{
    public string PartOne() =>
        CalculateRecordBeatingRaces(input.Split('\n')).ToString();

    public string PartTwo() =>
        CalculateRecordBeatingRaces(input.Split('\n').Take(2).Select(s => s.Replace(" ", string.Empty)).ToArray())
            .ToString();

    private static long CalculateRecordBeatingRaces(IReadOnlyList<string> input)
    {
        var times = Parse(input[0]);
        var records = Parse(input[1]);
        var totalWinningMoves = times
            .Zip(records, WinningMoves)
            .Aggregate(1L, (acc, winningMoves) => acc * winningMoves);
        return totalWinningMoves;
    }

    private static long WinningMoves(long time, long record)
    {
        var (root1, root2) = SolveQuadraticEquation(-1, time, -record);
        var maxRoot = (long)Math.Ceiling(root2) - 1;
        var minRoot = (long)Math.Floor(root1) + 1;
        return maxRoot - minRoot + 1;
    }

    private static (double, double) SolveQuadraticEquation(long a, long b, long c)
    {
        var discriminant = Math.Sqrt(b * b - 4 * a * c);
        var denominator = 2 * a;
        var root1 = (-b - discriminant) / denominator;
        var root2 = (-b + discriminant) / denominator;
        var minRoot = Math.Min(root1, root2);
        var maxRoot = Math.Max(root1, root2);
        return (minRoot, maxRoot);
    }


    private static long[] Parse(string input) =>
        Regex.Matches(input, @"\d+").Select(m => long.Parse(m.Value)).ToArray();
}