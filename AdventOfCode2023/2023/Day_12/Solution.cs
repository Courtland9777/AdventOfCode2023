using System.Collections.Immutable;
using AdventOfCode2023.Interfaces;

namespace AdventOfCode2023._2023.Day_12;

using Cache = Dictionary<(string, ImmutableStack<int>), long>;

public class Solution(string input) : ISolution
{
    public string PartOne() => Solve(input, 1).ToString();

    public string PartTwo() => Solve(input, 5).ToString();

    private static long Solve(string input, int repeat) =>
        input.Split('\n')
            .Select(line => ParseLine(line, repeat))
            .Select(data => Compute(data.Pattern, ImmutableStack.CreateRange(data.Numbers.Reverse()), []))
            .Sum();

    private static (string Pattern, IEnumerable<int> Numbers) ParseLine(string line, int repeat)
    {
        var parts = line.Split(" ");
        var pattern = Unfold(parts[0], '?', repeat);
        var numString = Unfold(parts[1], ',', repeat);
        var numbers = numString.Split(',').Select(int.Parse);
        return (pattern, numbers);
    }

    private static string Unfold(string st, char join, int unfold) =>
        string.Join(join, Enumerable.Repeat(st, unfold));

    private static long Compute(string pattern, ImmutableStack<int> numbers, Cache cache)
    {
        if (!cache.ContainsKey((pattern, numbers))) cache[(pattern, numbers)] = Dispatch(pattern, numbers, cache);
        return cache[(pattern, numbers)];
    }

    private static long Dispatch(string pattern, ImmutableStack<int> numbers, Cache cache) =>
        pattern.FirstOrDefault() switch
        {
            '.' => ProcessDot(pattern, numbers, cache),
            '?' => ProcessQuestion(pattern, numbers, cache),
            '#' => ProcessHash(pattern, numbers, cache),
            _ => ProcessEnd(pattern, numbers, cache)
        };

    private static long ProcessEnd(string _, ImmutableStack<int> numbers, Cache __) =>
        !numbers.IsEmpty
            ? 0
            : 1;

    private static long ProcessDot(string pattern, ImmutableStack<int> numbers, Cache cache) =>
        Compute(pattern[1..], numbers, cache);

    private static long ProcessQuestion(string pattern, ImmutableStack<int> numbers, Cache cache) =>
        Compute("." + pattern[1..], numbers, cache) + Compute("#" + pattern[1..], numbers, cache);

    private static long ProcessHash(string pattern, ImmutableStack<int> numbers, Cache cache)
    {
        if (numbers.IsEmpty)
            return 0;
        const char deadSpring = '#';
        const char unknownSpring = '?';
        var currentNumber = numbers.Peek();
        numbers = numbers.Pop();
        var deadOrUnknownSpringCount = pattern.TakeWhile(s => s is deadSpring or unknownSpring).Count();
        if (deadOrUnknownSpringCount < currentNumber)
            return 0;
        if (pattern.Length == currentNumber)
            return Compute("", numbers, cache);
        return pattern[currentNumber] switch
        {
            deadSpring => 0,
            _ => Compute(pattern[(currentNumber + 1)..], numbers, cache)
        };
    }
}