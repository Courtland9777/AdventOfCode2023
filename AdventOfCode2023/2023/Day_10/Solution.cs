using System.Numerics;
using AdventOfCode2023.Interfaces;

namespace AdventOfCode2023._2023.Day_10;

using Map = Dictionary<Complex, char>;

public class Solution(string input) : ISolution
{
    private static readonly Complex Up = -Complex.ImaginaryOne;
    private static readonly Complex Down = Complex.ImaginaryOne;
    private static readonly Complex Left = -Complex.One;
    private static readonly Complex Right = Complex.One;
    private static readonly Complex[] Dirs = [Up, Right, Down, Left];

    private static readonly Dictionary<char, Complex[]> Exits = new()
    {
        { '7', [Left, Down] },
        { 'F', [Right, Down] },
        { 'L', [Up, Right] },
        { 'J', [Up, Left] },
        { '|', [Up, Down] },
        { '-', [Left, Right] },
        { 'S', [Up, Down, Left, Right] },
        { '.', [] }
    };

    public string PartOne() => (LoopPositions(ParseMap(input)).Count / 2).ToString();

    public string PartTwo()
    {
        var map = ParseMap(input);
        var loop = LoopPositions(map);
        return map.Keys.Count(position => IsPositionInsideLoop(position, map, loop)).ToString();
    }

    private static HashSet<Complex> LoopPositions(Map map)
    {
        var startPosition = map.Keys.Single(k => map[k] == 'S');
        var positions = new HashSet<Complex>();
        var direction = Dirs.First(dir => Exits[map[startPosition + dir]].Contains(-dir));
        while (true)
        {
            positions.Add(startPosition);
            startPosition += direction;
            if (map[startPosition] == 'S') break;
            direction = Exits[map[startPosition]].Single(exit => exit != -direction);
        }

        return positions;
    }

    private static bool IsPositionInsideLoop(Complex position, IReadOnlyDictionary<Complex, char> map,
        IReadOnlySet<Complex> loop)
    {
        if (IsPositionPartOfLoop(position, loop)) return false;
        var isInsideLoop = false;
        position = MovePositionToLeft(position);
        while (IsPositionInMap(position, map))
        {
            if (IsPositionPartOfLoop(position, loop) && IsExitUpwardsFromPosition(position, map))
                isInsideLoop = !isInsideLoop;
            position = MovePositionToLeft(position);
        }

        return isInsideLoop;
    }

    private static bool IsPositionPartOfLoop(Complex position, IReadOnlySet<Complex> loop) => loop.Contains(position);

    private static Complex MovePositionToLeft(Complex position) => position + Left;

    private static bool IsPositionInMap(Complex position, IReadOnlyDictionary<Complex, char> map) =>
        map.ContainsKey(position);

    private static bool IsExitUpwardsFromPosition(Complex position, IReadOnlyDictionary<Complex, char> map) =>
        Exits[map[position]].Contains(Up);

    private static Map ParseMap(string inputLines)
    {
        var lines = inputLines.Split('\n');
        return Enumerable.Range(0, lines.Length)
            .SelectMany(_ => Enumerable.Range(0, lines[0].Length),
                (rowIndex, columnIndex) => new { rowIndex, columnIndex })
            .Select(t => new { t, position = new Complex(t.columnIndex, t.rowIndex) })
            .Select(t => new { t, cellValue = lines[t.t.rowIndex][t.t.columnIndex] })
            .Select(t => new KeyValuePair<Complex, char>(t.t.position, t.cellValue))
            .ToDictionary(pair => pair.Key, pair => pair.Value);
    }
}