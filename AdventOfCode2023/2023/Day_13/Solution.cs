using System.Numerics;
using AdventOfCode2023.Interfaces;

namespace AdventOfCode2023._2023.Day_13;

using Map = Dictionary<Complex, char>;

public class Solution(string input) : ISolution
{
    private readonly Complex _down = Complex.ImaginaryOne;
    private readonly Complex _right = 1;

    public string PartOne() => Solve(input, 0).ToString();

    public string PartTwo() => Solve(input, 1).ToString();
    private Complex Ortho(Complex dir) => dir == _right ? _down : _right;

    private double Solve(string inputArray, int allowedSmudges) => inputArray.Split("\n\n")
        .Select(block => new { block, map = ParseMap(block) })
        .Select(t => GetScore(t.map, allowedSmudges)).Sum();

    private double GetScore(Map map, int allowedSmudges) => new[] { _right, _down }
        .SelectMany(dir => GeneratePositions(map, dir, dir), (dir, mirror) => new { dir, mirror })
        .Where(t => FindSmudges(map, t.mirror, t.dir) == allowedSmudges)
        .Select(t => t.mirror.Real + 100 * t.mirror.Imaginary).First();

    private int FindSmudges(Map map, Complex mirror, Complex rayDir) => GeneratePositions(map, mirror, Ortho(rayDir))
        .Select(ray0 => new { ray0, rayA = GeneratePositions(map, ray0, rayDir) })
        .Select(t => new { t, rayB = GeneratePositions(map, t.ray0 - rayDir, -rayDir) })
        .Select(t => t.t.rayA.Zip(t.rayB).Count(p => map[p.First] != map[p.Second])).Sum();

    private static IEnumerable<Complex> GeneratePositions(Map map, Complex startPosition, Complex direction)
    {
        for (var position = startPosition; map.ContainsKey(position); position += direction) yield return position;
    }

    private static Map ParseMap(string input)
    {
        var rows = input.Split("\n");
        return Enumerable.Range(0, rows.Length)
            .SelectMany(_ => Enumerable.Range(0, rows[0].Length), (irow, icol) => new { irow, icol })
            .Select(t => new { t, pos = new Complex(t.icol, t.irow) })
            .Select(t => new { t, cell = rows[t.t.irow][t.t.icol] })
            .Select(t => new KeyValuePair<Complex, char>(t.t.pos, t.cell)).ToDictionary();
    }
}