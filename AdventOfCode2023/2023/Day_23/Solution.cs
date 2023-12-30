using System.Numerics;
using AdventOfCode2023.Interfaces;

namespace AdventOfCode2023._2023.Day_23;

using Map = Dictionary<Complex, char>;
using Node = long;

internal record Edge(Node Start, Node End, int Distance);

public class Solution(string input) : ISolution
{
    private static readonly Complex Up = -Complex.ImaginaryOne;
    private static readonly Complex Down = Complex.ImaginaryOne;
    private static readonly Complex Left = -1;
    private static readonly Complex Right = 1;
    private static readonly Complex[] Dirs = [Up, Down, Left, Right];

    private readonly Dictionary<char, Complex[]> _exits = new()
    {
        ['<'] = [Left],
        ['>'] = [Right],
        ['^'] = [Up],
        ['v'] = [Down],
        ['.'] = Dirs,
        ['#'] = []
    };

    public string PartOne() => Solve(input).ToString();

    public string PartTwo() => Solve(RemoveSlopes(input)).ToString();

    private static string RemoveSlopes(string st) =>
        string.Join("", st.Select(ch => ">v<^".Contains(ch) ? '.' : ch));

    private int Solve(string inputString)
    {
        var (nodes, edges) = MakeGraph(inputString);
        var (start, goal) = (nodes.First(), nodes.Last());

        var cache = new Dictionary<(Node, Node), int>();

        return LongestPath(start, 0);

        int LongestPath(Node node, Node visited)
        {
            if (node == goal)
                return 0;
            if ((visited & node) != 0) return int.MinValue;
            var key = (node, visited);
            if (!cache.ContainsKey(key))
                cache[key] = edges
                    .Where(e => e.Start == node)
                    .Select(e => e.Distance + LongestPath(e.End, visited | node))
                    .Max();
            return cache[key];
        }
    }

    private (Node[], Edge[]) MakeGraph(string inputString)
    {
        var map = ParseMap(inputString);

        var nodePos = map.Keys.OrderBy(pos => pos.Imaginary)
            .ThenBy(pos => pos.Real)
            .Where(pos => IsFree(map, pos) && !IsRoad(map, pos)).ToArray();

        var nodes = Enumerable.Range(0, nodePos.Length).Select(i => 1L << i).ToArray();

        var edges = Enumerable.Range(0, nodePos.Length)
            .SelectMany(i => Enumerable.Range(0, nodePos.Length), (i, j) => new { i, j })
            .Where(t => t.i != t.j)
            .Select(t => new { t, distance = Distance(map, nodePos[t.i], nodePos[t.j]) })
            .Where(t => t.distance > 0)
            .Select(t => new Edge(nodes[t.t.i], nodes[t.t.j], t.distance)).ToArray();

        return (nodes, edges);
    }

    private int Distance(Map map, Complex crossroadA, Complex crossroadB)
    {
        var q = new Queue<(Complex, int)>();
        q.Enqueue((crossroadA, 0));

        var visited = new HashSet<Complex> { crossroadA };
        while (q.Count != 0)
        {
            var (pos, dist) = q.Dequeue();
            foreach (var dir in _exits[map[pos]])
            {
                var posT = pos + dir;
                if (posT == crossroadB) return dist + 1;

                if (IsRoad(map, posT) && visited.Add(posT)) q.Enqueue((posT, dist + 1));
            }
        }

        return -1;
    }

    private static bool IsFree(Map map, Complex p) =>
        map.ContainsKey(p) && map[p] != '#';

    private static bool IsRoad(Map map, Complex p) =>
        IsFree(map, p) && Dirs.Count(d => IsFree(map, p + d)) == 2;

    private static Map ParseMap(string input)
    {
        var lines = input.Split('\n');
        return Enumerable.Range(0, lines.Length)
            .SelectMany(iRow => Enumerable.Range(0, lines[0].Length), (iRow, iCol) => new { iRow, iCol })
            .Select(t => new { t, pos = new Complex(t.iCol, t.iRow) })
            .Select(t => new KeyValuePair<Complex, char>(t.pos, lines[t.t.iRow][t.t.iCol])).ToDictionary();
    }
}