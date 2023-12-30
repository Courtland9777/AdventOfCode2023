using AdventOfCode2023._2023.Day_01;
using AdventOfCode2023.Helpers;
using AdventOfCode2023.Interfaces;

namespace AdventOfCode2023.Managers;

public sealed class SolutionManager : ISolutionManager
{
    private readonly Lazy<ISolution> _day01 = new(() => new Solution(FileReader.ReadInputToString(1)));
    private readonly Lazy<ISolution> _day02 = new(() => new _2023.Day_02.Solution(FileReader.ReadInputToString(2)));
    private readonly Lazy<ISolution> _day03 = new(() => new _2023.Day_03.Solution(FileReader.ReadInputToString(3)));
    private readonly Lazy<ISolution> _day04 = new(() => new _2023.Day_04.Solution(FileReader.ReadInputToString(4)));
    private readonly Lazy<ISolution> _day05 = new(() => new _2023.Day_05.Solution(FileReader.ReadInputToString(5)));
    private readonly Lazy<ISolution> _day06 = new(() => new _2023.Day_06.Solution(FileReader.ReadInputToString(6)));
    private readonly Lazy<ISolution> _day07 = new(() => new _2023.Day_07.Solution(FileReader.ReadInputToString(7)));
    private readonly Lazy<ISolution> _day08 = new(() => new _2023.Day_08.Solution(FileReader.ReadInputToString(8)));
    private readonly Lazy<ISolution> _day09 = new(() => new _2023.Day_09.Solution(FileReader.ReadInputToString(9)));
    private readonly Lazy<ISolution> _day10 = new(() => new _2023.Day_10.Solution(FileReader.ReadInputToString(10)));
    private readonly Lazy<ISolution> _day11 = new(() => new _2023.Day_11.Solution(FileReader.ReadInputToString(11)));
    private readonly Lazy<ISolution> _day12 = new(() => new _2023.Day_12.Solution(FileReader.ReadInputToString(12)));
    private readonly Lazy<ISolution> _day13 = new(() => new _2023.Day_13.Solution(FileReader.ReadInputToString(13)));
    private readonly Lazy<ISolution> _day14 = new(() => new _2023.Day_14.Solution(FileReader.ReadInputToString(14)));
    private readonly Lazy<ISolution> _day15 = new(() => new _2023.Day_15.Solution(FileReader.ReadInputToString(15)));
    private readonly Lazy<ISolution> _day16 = new(() => new _2023.Day_16.Solution(FileReader.ReadInputToString(16)));
    private readonly Lazy<ISolution> _day17 = new(() => new _2023.Day_17.Solution(FileReader.ReadInputToString(17)));
    private readonly Lazy<ISolution> _day18 = new(() => new _2023.Day_18.Solution(FileReader.ReadInputToString(18)));
    private readonly Lazy<ISolution> _day19 = new(() => new _2023.Day_19.Solution(FileReader.ReadInputToString(19)));
    private readonly Lazy<ISolution> _day20 = new(() => new _2023.Day_20.Solution(FileReader.ReadInputToString(20)));
    private readonly Lazy<ISolution> _day21 = new(() => new _2023.Day_21.Solution(FileReader.ReadInputToString(21)));
    private readonly Lazy<ISolution> _day22 = new(() => new _2023.Day_22.Solution(FileReader.ReadInputToString(22)));
    private readonly Lazy<ISolution> _day23 = new(() => new _2023.Day_23.Solution(FileReader.ReadInputToString(23)));
    private readonly Lazy<ISolution> _day24 = new(() => new _2023.Day_24.Solution(FileReader.ReadInputToString(24)));
    private readonly Lazy<ISolution> _day25 = new(() => new _2023.Day_25.Solution(FileReader.ReadInputToString(25)));

    public ISolution Day1 => _day01.Value;
    public ISolution Day2 => _day02.Value;
    public ISolution Day3 => _day03.Value;
    public ISolution Day4 => _day04.Value;
    public ISolution Day5 => _day05.Value;
    public ISolution Day6 => _day06.Value;
    public ISolution Day7 => _day07.Value;
    public ISolution Day8 => _day08.Value;
    public ISolution Day9 => _day09.Value;
    public ISolution Day10 => _day10.Value;
    public ISolution Day11 => _day11.Value;
    public ISolution Day12 => _day12.Value;
    public ISolution Day13 => _day13.Value;
    public ISolution Day14 => _day14.Value;
    public ISolution Day15 => _day15.Value;
    public ISolution Day16 => _day16.Value;
    public ISolution Day17 => _day17.Value;
    public ISolution Day18 => _day18.Value;
    public ISolution Day19 => _day19.Value;
    public ISolution Day20 => _day20.Value;
    public ISolution Day21 => _day21.Value;
    public ISolution Day22 => _day22.Value;
    public ISolution Day23 => _day23.Value;
    public ISolution Day24 => _day24.Value;
    public ISolution Day25 => _day25.Value;

    public ISolution GetSolution(int day) =>
        day switch
        {
            1 => Day1,
            2 => Day2,
            3 => Day3,
            4 => Day4,
            5 => Day5,
            6 => Day6,
            7 => Day7,
            8 => Day8,
            9 => Day9,
            10 => Day10,
            11 => Day11,
            12 => Day12,
            13 => Day13,
            14 => Day14,
            15 => Day15,
            16 => Day16,
            17 => Day17,
            18 => Day18,
            19 => Day19,
            20 => Day20,
            21 => Day21,
            22 => Day22,
            23 => Day23,
            24 => Day24,
            25 => Day25,
            _ => throw new ArgumentException("Invalid day")
        };
}