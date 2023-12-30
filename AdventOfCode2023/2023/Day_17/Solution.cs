using System.Numerics;
using AdventOfCode2023.Interfaces;

namespace AdventOfCode2023._2023.Day_17;

using Map = Dictionary<Complex, int>;

public record Crucible(Complex Pos, Complex Dir, int StraightMoves);

public class Solution(string input) : ISolution
{
    public string PartOne() => HeatLoss(input, 0, 3).ToString();

    public string PartTwo() => HeatLoss(input, 4, 10).ToString();

    private static int HeatLoss(string input, int minStraight, int maxStraight)
    {
        var map = ParseMap(input);
        var goal = GetGoalPosition(map);
        var queue = InitializeQueue();
        var seen = new HashSet<Crucible>();
        while (queue.TryDequeue(out var crucible, out var heatLoss))
        {
            if (IsGoalReached(crucible, goal, minStraight)) return heatLoss;
            EnqueueNextMoves(crucible, minStraight, maxStraight, map, seen, queue, heatLoss);
        }

        throw new Exception("Goal not reachable");
    }

    private static Complex GetGoalPosition(Map map) =>
        map.Keys.MaxBy(pos => pos.Imaginary + pos.Real);

    private static PriorityQueue<Crucible, int> InitializeQueue()
    {
        var queue = new PriorityQueue<Crucible, int>();
        queue.Enqueue(new Crucible(0, 1, 0), 0);
        queue.Enqueue(new Crucible(0, Complex.ImaginaryOne, 0), 0);
        return queue;
    }

    private static bool IsGoalReached(Crucible crucible, Complex goal, int minStraight) =>
        crucible.Pos == goal && crucible.StraightMoves >= minStraight;

    private static void EnqueueNextMoves(Crucible crucible, int minStraight, int maxStraight, Map map,
        HashSet<Crucible> seen, PriorityQueue<Crucible, int> queue, int heatLoss)
    {
        foreach (var next in Moves(crucible, minStraight, maxStraight))
            if (map.TryGetValue(next.Pos, out var value) && seen.Add(next))
                queue.Enqueue(next, heatLoss + value);
    }

    public static IEnumerable<Crucible> Moves(Crucible crucible, int minStraight, int maxStraight)
    {
        if (crucible.StraightMoves < maxStraight)
            yield return crucible with
            {
                Pos = crucible.Pos + crucible.Dir,
                StraightMoves = crucible.StraightMoves + 1
            };

        if (crucible.StraightMoves < minStraight) yield break;
        var dir = crucible.Dir * Complex.ImaginaryOne;
        yield return new Crucible(crucible.Pos + dir, dir, 1);
        yield return new Crucible(crucible.Pos - dir, -dir, 1);
    }

    private static Map ParseMap(string input)
    {
        var lines = input.Split('\n');
        return Enumerable.Range(0, lines.Length)
            .SelectMany(iRow => Enumerable.Range(0, lines[0].Length), (iRow, iCol) => new { iRow, iCol })
            .Select(t => new { t, cell = int.Parse(lines[t.iRow].Substring(t.iCol, 1)) })
            .Select(t => new { t, pos = new Complex(t.t.iCol, t.t.iRow) })
            .Select(t => new KeyValuePair<Complex, int>(t.pos, t.t.cell)).ToDictionary();
    }
}