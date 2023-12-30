using System.Numerics;
using AdventOfCode2023.Interfaces;

namespace AdventOfCode2023._2023.Day_16;

using Map = Dictionary<Complex, char>;
using Beam = (Complex pos, Complex dir);

public class Solution(string input) : ISolution
{
    private static readonly Complex Up = -Complex.ImaginaryOne;
    private static readonly Complex Down = Complex.ImaginaryOne;
    private static readonly Complex Left = -Complex.One;
    private static readonly Complex Right = Complex.One;

    public string PartOne() => EnergizedCells(ParseMap(input), (Complex.Zero, Right)).ToString();

    public string PartTwo()
    {
        var map = ParseMap(input);
        return StartBeams(map).Select(beam => EnergizedCells(map, beam)).Max().ToString();
    }

    private static int EnergizedCells(Map map, Beam beam)
    {
        var queue = new Queue<Beam>(new[] { beam });
        var seenBeams = new HashSet<Beam>();
        while (queue.Count != 0)
        {
            beam = queue.Dequeue();
            seenBeams.Add(beam);
            var possibleDirections = Exits(map[beam.pos], beam.dir);
            foreach (var direction in possibleDirections)
            {
                var newPosition = beam.pos + direction;
                var newBeam = (newPosition, direction);
                if (map.ContainsKey(newPosition) && !seenBeams.Contains(newBeam)) queue.Enqueue(newBeam);
            }
        }

        return seenBeams.Select(b => b.pos).Distinct().Count();
    }

    private static IEnumerable<Beam> StartBeams(Map map)
    {
        var (tl, br) = (TopLeft(), BottomRight(map));
        return
        [
            .. Positions(map, tl, Right).Select(pos => (pos, Down)),
            .. Positions(map, tl, Down).Select(pos => (pos, Right)),
            .. Positions(map, br, Left).Select(pos => (pos, Up)),
            .. Positions(map, br, Up).Select(pos => (pos, Left))
        ];
    }

    private static Map ParseMap(string input)
    {
        var lines = input.Split('\n');
        return Enumerable.Range(0, lines.Length)
            .SelectMany(iRow => Enumerable.Range(0, lines[0].Length), (iRow, iCol) => new { iRow, iCol })
            .Select(t => new { t, pos = new Complex(t.iCol, t.iRow) })
            .Select(t => new { t, cell = lines[t.t.iRow][t.t.iCol] })
            .Select(t => new KeyValuePair<Complex, char>(t.t.pos, t.cell)).ToDictionary();
    }

    private static Complex TopLeft() => Complex.Zero;
    private static Complex BottomRight(Map map) => map.Keys.MaxBy(pos => pos.Imaginary + pos.Real);

    private static IEnumerable<Complex> Positions(Map map, Complex start, Complex dir)
    {
        for (var pos = start; map.ContainsKey(pos); pos += dir) yield return pos;
    }

    private static IEnumerable<Complex> Exits(char cell, Complex dir)
    {
        var p = (cell, dir);
        return
            p == ('-', Up) ? [Left, Right] :
            p == ('-', Down) ? [Left, Right] :
            p == ('|', Left) ? [Up, Down] :
            p == ('|', Right) ? [Up, Down] :
            p == ('/', Left) ? [Down] :
            p == ('/', Right) ? [Up] :
            p == ('/', Up) ? [Right] :
            p == ('/', Down) ? [Left] :
            p == ('\\', Left) ? [Up] :
            p == ('\\', Right) ? [Down] :
            p == ('\\', Up) ? [Left] :
            p == ('\\', Down) ? [Right] :
            /* otherwise */ [p.dir];
    }
}