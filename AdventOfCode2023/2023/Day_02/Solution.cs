using System.Text.RegularExpressions;
using AdventOfCode2023.Interfaces;

namespace AdventOfCode2023._2023.Day_02;

public class Solution(string input) : ISolution
{
    public string PartOne() =>
        input.Split('\n').Select(ParseGame).Where(game => game is { Red: <= 12, Green: <= 13, Blue: <= 14 })
            .Select(game => game.Id).Sum().ToString();

    public string PartTwo() =>
        input.Split('\n').Select(ParseGame).Select(game => game.Red * game.Blue * game.Green)
            .Sum().ToString();

    private static Game ParseGame(string line) =>
        new(
            ParseNumbers(line, @"Game (\d+)").First(),
            ParseNumbers(line, @"(\d+) red").Max(),
            ParseNumbers(line, @"(\d+) green").Max(),
            ParseNumbers(line, @"(\d+) blue").Max()
        );

    private static IEnumerable<int> ParseNumbers(string st, string rx) =>
        Regex.Matches(st, rx).Select(m => int.Parse(m.Groups[1].Value));
}

internal record Game(int Id, int Red, int Green, int Blue);