using System.Numerics;
using AdventOfCode2023.Interfaces;

namespace AdventOfCode2023._2023.Day_21;

public class Solution(string input) : ISolution
{
    public string PartOne() => Steps(ParseMap(input)).ElementAt(64).ToString();

    public string PartTwo()
    {
        var steps = Steps(ParseMap(input)).Take(328).ToArray();

        (decimal x0, decimal y0) = (65, steps[65]);
        (decimal x1, decimal y1) = (196, steps[196]);
        (decimal x2, decimal y2) = (327, steps[327]);

        var y01 = (y1 - y0) / (x1 - x0);
        var y12 = (y2 - y1) / (x2 - x1);
        var y012 = (y12 - y01) / (x2 - x0);

        const int n = 26501365;
        return ((long)(y0 + y01 * (n - x0) + y012 * (n - x0) * (n - x1))).ToString();
    }

    private static IEnumerable<long> Steps(IReadOnlySet<Complex> map)
    {
        var positions = new HashSet<Complex> { new(65, 65) };
        while (true)
        {
            yield return positions.Count;
            positions = Step(map, positions);
        }
    }

    private static HashSet<Complex> Step(IReadOnlySet<Complex> map, HashSet<Complex> positions)
    {
        Complex[] dirs = [1, -1, Complex.ImaginaryOne, -Complex.ImaginaryOne];

        var res = new HashSet<Complex>();
        foreach (var posT in positions.SelectMany(pos => dirs, (pos, dir) => pos + dir)
                     .Select(posT => new { posT, tileCol = Mod(posT.Real, 131) })
                     .Select(t => new { t, tileRow = Mod(t.posT.Imaginary, 131) })
                     .Where(t => map.Contains(new Complex(t.t.tileCol, t.tileRow)))
                     .Select(t => t.t.posT)) res.Add(posT);

        return res;
    }

    private static double Mod(double n, int m) => (n % m + m) % m;

    private static HashSet<Complex> ParseMap(string inputString)
    {
        var lines = inputString.Split("\n");
        return Enumerable.Range(0, lines.Length)
            .SelectMany(iRow => Enumerable.Range(0, lines[0].Length), (iRow, iCol) => new { iRow, iCol })
            .Where(t => lines[t.iRow][t.iCol] != '#')
            .Select(t => new Complex(t.iCol, t.iRow)).ToHashSet();
    }
}