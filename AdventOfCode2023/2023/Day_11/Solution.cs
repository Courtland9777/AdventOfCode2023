using AdventOfCode2023.Interfaces;

namespace AdventOfCode2023._2023.Day_11;

public class Solution(string input) : ISolution
{
    public string PartOne() => Solve(input, 1).ToString();

    public string PartTwo() => Solve(input, 999999).ToString();

    private static long Solve(string input, int expansion)
    {
        // Determine which rows and columns are empty
        var inputArray = input.Split('\n');
        Func<int, bool> isRowEmpty = EmptyRows(inputArray).ToHashSet().Contains;
        Func<int, bool> isColEmpty = EmptyCols(inputArray).ToHashSet().Contains;
        // Find all galaxies
        var galaxies = FindAll(inputArray, '#');
        // Calculate the total Distance between all galaxies, taking into account empty rows and columns
        return galaxies.SelectMany(firstGalaxy => galaxies, (firstGalaxy, secondGalaxy) =>
        {
            var rowDistance = CalculateDistance(firstGalaxy.Irow, secondGalaxy.Irow, expansion, isRowEmpty);
            var colDistance = CalculateDistance(firstGalaxy.Icol, secondGalaxy.Icol, expansion, isColEmpty);
            return rowDistance + colDistance;
        }).Sum() / 2;
    }

    private static long CalculateDistance(int point1, int point2, int expansion, Func<int, bool> isEmpty)
    {
        var minPoint = Math.Min(point1, point2);
        var distance = Math.Abs(point1 - point2);
        var emptySpaces = Enumerable.Range(minPoint, distance).Count(isEmpty);
        return distance + expansion * emptySpaces;
    }

    private static IEnumerable<int> EmptyRows(IReadOnlyList<string> map) =>
        Enumerable.Range(0, map.Count).Where(iRow => map[iRow].All(ch => ch == '.'));

    private static IEnumerable<int> EmptyCols(IReadOnlyList<string> map) =>
        Enumerable.Range(0, map[0].Length).Where(iCol => map.All(row => row[iCol] == '.'));

    private static IEnumerable<Position> FindAll(IReadOnlyList<string> map, char ch) =>
        Enumerable.Range(0, map.Count)
            .SelectMany(_ => Enumerable.Range(0, map[0].Length), (iRow, iCol) => new { irow = iRow, icol = iCol })
            .Where(t => map[t.irow][t.icol] == ch)
            .Select(t => new Position(t.irow, t.icol));
}

internal record Position(int Irow, int Icol);