using AdventOfCode2023.Interfaces;

namespace AdventOfCode2023._2023.Day_14;

using Map = char[][];

public class Solution(string input) : ISolution
{
    public string PartOne() => Measure(Tilt(Parse(input))).ToString();

    public string PartTwo() => Measure(Iterate(Parse(input), Cycle, 1_000_000_000)).ToString();

    private static Map Parse(string input) => input.Split('\n').Select(line => line.ToCharArray()).ToArray();

    private static int CRow(IReadOnlyCollection<char[]> map) => map.Count;
    private static int CColumn(IReadOnlyList<char[]> map) => map[0].Length;

    private static Map Iterate(Map map, Func<Map, Map> cycle, int count)
    {
        var history = new List<string>();
        while (count > 0)
        {
            map = cycle(map);
            count--;

            var mapString = string.Join("\n", map.Select(line => new string(line)));
            var idx = history.IndexOf(mapString);
            if (idx < 0)
            {
                history.Add(mapString);
            }
            else
            {
                var loopLength = history.Count - idx;
                var remainder = count % loopLength;
                return Parse(history[idx + remainder]);
            }
        }

        return map;
    }

    private static Map Cycle(Map map)
    {
        for (var i = 0; i < 4; i++) map = Rotate(Tilt(map));
        return map;
    }

    private static Map Tilt(Map map)
    {
        for (var iColumn = 0; iColumn < CColumn(map); iColumn++)
        {
            var iRowT = 0;
            for (var iRowS = 0; iRowS < CRow(map); iRowS++)
                if (map[iRowS][iColumn] == '#')
                {
                    iRowT = iRowS + 1;
                }
                else if (map[iRowS][iColumn] == 'O')
                {
                    map[iRowS][iColumn] = '.';
                    map[iRowT][iColumn] = 'O';
                    iRowT++;
                }
        }

        return map;
    }

    private static Map Rotate(IReadOnlyList<char[]> src)
    {
        var rowCount = CRow(src);
        var columnCount = CColumn(src);
        var dst = new char[rowCount][];
        for (var iRow = 0; iRow < columnCount; iRow++)
        {
            dst[iRow] = new char[columnCount];
            for (var iColumn = 0; iColumn < rowCount; iColumn++)
            {
                var sourceRow = rowCount - iColumn - 1;
                dst[iRow][iColumn] = src[sourceRow][iRow];
            }
        }

        return dst;
    }

    private static int Measure(IReadOnlyCollection<char[]> map) =>
        map.Select((row, iRow) => (CRow(map) - iRow) * row.Count(ch => ch == 'O')).Sum();
}