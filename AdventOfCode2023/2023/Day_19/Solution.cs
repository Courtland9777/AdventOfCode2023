using System.Collections.Immutable;
using System.Numerics;
using System.Text.RegularExpressions;
using AdventOfCode2023.Interfaces;

namespace AdventOfCode2023._2023.Day_19;

using Rules = Dictionary<string, string>;
using Cube = ImmutableArray<Range>;

internal record Range(int Begin, int End);

internal record Cond(int Dim, char Op, int Num, string State);

public class Solution(string input) : ISolution
{
    public string PartOne()
    {
        var parts = input.Split("\n\n");
        var rules = ParseRules(parts[0]);
        return ParseUnitCube(parts[1])
            .Where(cube => AcceptedVolume(rules, cube) == 1)
            .Select(cube => cube.Select(r => r.Begin).Sum()).Sum().ToString();
    }

    public string PartTwo()
    {
        var parts = input.Split("\n\n");
        var rules = ParseRules(parts[0]);
        var cube = Enumerable.Repeat(new Range(1, 4000), 4).ToImmutableArray();
        return AcceptedVolume(rules, cube).ToString();
    }

    private static BigInteger AcceptedVolume(Rules rules, Cube cube)
    {
        var queue = new Queue<(Cube cube, string state)>();
        queue.Enqueue((cube, "in"));
        BigInteger result = 0;
        while (queue.Count != 0)
        {
            (cube, var state) = queue.Dequeue();
            if (CubeHasInvalidCoordinates(cube))
                continue;
            switch (state)
            {
                case "R":
                    continue;
                case "A":
                    result += CalculateVolume(cube);
                    break;
                default:
                    ProcessState(rules, ref cube, state, queue);
                    break;
            }
        }

        return result;
    }

    private static bool CubeHasInvalidCoordinates(Cube cube)
    {
        return cube.Any(coordinate => coordinate.End < coordinate.Begin);
    }

    private static void ProcessState(Rules rules, ref Cube cube, string state, Queue<(Cube cube, string state)> queue)
    {
        foreach (var statement in rules[state].Split(","))
        {
            var condition = TryParseCondition(statement);
            if (condition == null)
                queue.Enqueue((cube, statement));
            else
                ProcessCondition(ref cube, condition, queue);
        }
    }

    private static void ProcessCondition(ref Cube cube, Cond condition, Queue<(Cube cube, string state)> queue)
    {
        if (condition.Op == '<')
        {
            var (cube1, cube2) = CutCube(cube, condition.Dim, condition.Num - 1);
            queue.Enqueue((cube1, condition.State));
            cube = cube2;
        }
        else if (condition.Op == '>')
        {
            var (cube1, cube2) = CutCube(cube, condition.Dim, condition.Num);
            cube = cube1;
            queue.Enqueue((cube2, condition.State));
        }
    }


    private static BigInteger CalculateVolume(Cube cube) =>
        cube.Aggregate(BigInteger.One, (m, r) => m * (r.End - r.Begin + 1));

    private static (Cube lo, Cube hi) CutCube(Cube cube, int dim, int num)
    {
        var r = cube[dim];
        return (
            cube.SetItem(dim, r with { End = Math.Min(num, r.End) }),
            cube.SetItem(dim, r with { Begin = Math.Max(r.Begin, num + 1) })
        );
    }

    private static Cond? TryParseCondition(string st) =>
        st.Split('<', '>', ':') switch
        {
            ["x", var num, var state] => new Cond(0, st[1], int.Parse(num), state),
            ["m", var num, var state] => new Cond(1, st[1], int.Parse(num), state),
            ["a", var num, var state] => new Cond(2, st[1], int.Parse(num), state),
            ["s", var num, var state] => new Cond(3, st[1], int.Parse(num), state),
            _ => null
        };

    private static Rules ParseRules(string input) => input.Split('\n')
        .Select(line => new { line, parts = line.Split('{', '}') })
        .Select(t => new KeyValuePair<string, string>(t.parts[0], t.parts[1])).ToDictionary();

    private static IEnumerable<Cube> ParseUnitCube(string input) =>
        input.Split('\n')
            .Select(line => new { line, numbers = Regex.Matches(line, @"\d+").Select(m => int.Parse(m.Value)) })
            .Select(t => t.numbers.Select(n => new Range(n, n)).ToImmutableArray());
}