using System.Text.RegularExpressions;
using AdventOfCode2023.Interfaces;

namespace AdventOfCode2023._2023.Day_01;

public class Solution(string input) : ISolution
{
    private const string PartOnePattern = @"\d";
    private const string PartTwoPattern = @"\d|one|two|three|four|five|six|seven|eight|nine";

    public string PartOne() => CalculateCalibrationValue(input, PartOnePattern).ToString();

    public string PartTwo() =>
        CalculateCalibrationValue(input, PartTwoPattern).ToString();

    private static int CalculateCalibrationValue(string lines, string pattern) =>
        lines.Split('\n').Select(line => new { line, first = Regex.Match(line, pattern) })
            .Select(t => new { t, last = Regex.Match(t.line, pattern, RegexOptions.RightToLeft) })
            .Select(t => ParseMatch(t.t.first.Value) * 10 + ParseMatch(t.last.Value)).Sum();

    private static int ParseMatch(string numberString) =>
        numberString switch
        {
            "one" => 1,
            "two" => 2,
            "three" => 3,
            "four" => 4,
            "five" => 5,
            "six" => 6,
            "seven" => 7,
            "eight" => 8,
            "nine" => 9,
            _ => int.Parse(numberString)
        };
}