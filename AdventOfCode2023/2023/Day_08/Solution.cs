using System.Text.RegularExpressions;
using AdventOfCode2023.Interfaces;
using Map = System.Collections.Generic.Dictionary<string, (string Left, string Right)>;

namespace AdventOfCode2023._2023.Day_08;

public class Solution(string input) : ISolution
{
    public string PartOne() =>
        Solve(input, "AAA", "ZZZ").ToString();

    public string PartTwo() =>
        Solve(input, "A", "Z").ToString();

    private static long Solve(string input, string startMarker, string endMarker)
    {
        var lines = input.Split('\n');
        var directions = lines[0];
        var map = ParseMap(string.Join('\n', lines[2..]));
        return CalculateSteps(map, startMarker, endMarker, directions);
    }

    private static long CalculateSteps(Map map, string startMarker, string endMarker, string directions) =>
        map.Keys
            .Where(node => node.EndsWith(startMarker))
            .Select(node => CalculateStepsToMarker(node, endMarker, directions, map))
            .Aggregate(1L, Lcm);

    private static long CalculateStepsToMarker(string currentNode, string endMarker, string directions,
        IReadOnlyDictionary<string, (string Left, string Right)> map)
    {
        var stepCount = 0;
        while (!currentNode.EndsWith(endMarker))
        {
            var direction = directions[stepCount % directions.Length];
            currentNode = direction == 'L' ? map[currentNode].Left : map[currentNode].Right;
            stepCount++;
        }

        return stepCount;
    }

    private static long Lcm(long a, long b) => a * b / Gcd(a, b);

    private static long Gcd(long a, long b)
    {
        while (true)
        {
            if (b == 0) return a;
            var a1 = a;
            a = b;
            b = a1 % b;
        }
    }

    private static Map ParseMap(string input)
    {
        var lines = input.Split("\n");
        var map = new Map();
        foreach (var line in lines)
        {
            var matches = Regex.Matches(line, "[A-Z]+");
            if (matches.Count != 3)
                throw new ArgumentException(
                    $"Each line must contain exactly three parts separated by spaces. The offending line: {line}");
            var key = matches[0].Value;
            var leftValue = matches[1].Value;
            var rightValue = matches[2].Value;
            map[key] = (leftValue, rightValue);
        }

        return map;
    }
}