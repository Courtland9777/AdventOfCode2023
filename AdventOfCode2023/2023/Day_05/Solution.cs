using System.Text.RegularExpressions;
using AdventOfCode2023.Interfaces;

namespace AdventOfCode2023._2023.Day_05;

public class Solution(string input) : ISolution
{
    public string PartOne() => Solve(input, PartOneRanges).ToString();

    public string PartTwo() => Solve(input, PartTwoRanges).ToString();

    private static long Solve(string input, Func<IEnumerable<long>, IEnumerable<Range>> parseRanges)
    {
        var blocks = input.Split("\n\n");
        var seedRanges = parseRanges(ParseNumbers(blocks[0])).ToList();
        var maps = blocks.Skip(1).Select(ParseMap).ToArray();
        return GetMinimumBeginValue(seedRanges, maps);
    }

    private static long GetMinimumBeginValue(List<Range> seedRanges, IEnumerable<Dictionary<Range, Range>> maps) =>
        maps.Aggregate(seedRanges, Project).Select(r => r.Begin).Min();

    private static List<Range> Project(List<Range> inputRanges, Dictionary<Range, Range> map)
    {
        var inputQueue = new Queue<Range>(inputRanges);
        var outputRanges = new List<Range>();
        while (inputQueue.Count != 0)
        {
            var currentRange = inputQueue.Dequeue();
            var intersectingSourceRange = map.Keys.FirstOrDefault(src => Intersects(src, currentRange));
            if (intersectingSourceRange == null)
                outputRanges.Add(currentRange);
            else
                ProcessIntersectingRanges(inputQueue, outputRanges, currentRange, intersectingSourceRange, map);
        }

        return outputRanges;
    }

    private static void ProcessIntersectingRanges(Queue<Range> inputQueue, List<Range> outputRanges, Range currentRange,
        Range intersectingSourceRange, IReadOnlyDictionary<Range, Range> map)
    {
        if (IsRangeWithinSourceRange(currentRange, intersectingSourceRange))
            ShiftRangeWithinSourceRange(outputRanges, currentRange, intersectingSourceRange, map);
        else if (IsRangeStartBeforeSourceRange(currentRange, intersectingSourceRange))
            SplitRangeBeforeSourceRange(inputQueue, currentRange, intersectingSourceRange);
        else
            SplitRangeAfterSourceRange(inputQueue, currentRange, intersectingSourceRange);
    }

    private static bool IsRangeWithinSourceRange(Range currentRange, Range intersectingSourceRange) =>
        intersectingSourceRange.Begin <= currentRange.Begin && currentRange.End <= intersectingSourceRange.End;

    private static void ShiftRangeWithinSourceRange(List<Range> outputRanges, Range currentRange,
        Range intersectingSourceRange, IReadOnlyDictionary<Range, Range> map)
    {
        var destinationRange = map[intersectingSourceRange];
        var shift = destinationRange.Begin - intersectingSourceRange.Begin;
        outputRanges.Add(new Range(currentRange.Begin + shift, currentRange.End + shift));
    }

    private static bool IsRangeStartBeforeSourceRange(Range currentRange, Range intersectingSourceRange) =>
        currentRange.Begin < intersectingSourceRange.Begin;

    private static void SplitRangeBeforeSourceRange(Queue<Range> inputQueue, Range currentRange,
        Range intersectingSourceRange)
    {
        inputQueue.Enqueue(currentRange with { End = intersectingSourceRange.Begin - 1 });
        inputQueue.Enqueue(new Range(intersectingSourceRange.Begin, currentRange.End));
    }

    private static void SplitRangeAfterSourceRange(Queue<Range> inputQueue, Range currentRange,
        Range intersectingSourceRange)
    {
        inputQueue.Enqueue(new Range(currentRange.Begin, intersectingSourceRange.End));
        inputQueue.Enqueue(currentRange with { Begin = intersectingSourceRange.End + 1 });
    }

    private static bool Intersects(Range r1, Range r2) => r1.Begin <= r2.End && r2.Begin <= r1.End;

    private static IEnumerable<Range> PartOneRanges(IEnumerable<long> numbers) => numbers.Select(n => new Range(n, n));

    private static IEnumerable<Range> PartTwoRanges(IEnumerable<long> numbers) =>
        numbers.Chunk(2).Select(n => new Range(n[0], n[0] + n[1] - 1));

    private static IEnumerable<long> ParseNumbers(string input) =>
        Regex.Matches(input, @"\d+").Select(m => long.Parse(m.Value));

    private static Dictionary<Range, Range> ParseMap(string input) => input.Split("\n")
        .Skip(1)
        .Select(line => new { line, parts = ParseNumbers(line).ToArray() })
        .Select(t => new KeyValuePair<Range, Range>(new Range(t.parts[1], t.parts[2] + t.parts[1] - 1),
            new Range(t.parts[0], t.parts[2] + t.parts[0] - 1))).ToDictionary();
}

internal record Range(long Begin, long End);