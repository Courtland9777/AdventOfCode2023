using AdventOfCode2023.Interfaces;

namespace AdventOfCode2023._2023.Day_03;

public class Solution(string input) : ISolution
{
    private readonly (int dx, int dy)[] _directions =
        [(-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 1), (1, -1), (1, 0), (1, 1)];

    public string PartOne() =>
        SumOfPartNumbers(input.Split('\n'), _directions).ToString();

    public string PartTwo() => SumOfGearRatios(input.Split('\n'), _directions).ToString();

    private static int SumOfPartNumbers(IReadOnlyList<string> engineSchematic, (int dx, int dy)[] directions)
    {
        var sum = 0;
        for (var i = 0; i < engineSchematic.Count; i++)
        {
            var line = engineSchematic[i];
            for (var j = 0; j < line.Length; j++)
            {
                if (!char.IsDigit(line[j])) continue;
                var end = FindEndOfNumber(line, j);
                var number = ParseNumberFromLine(line, j, end);
                if (IsAdjacentToSymbol(engineSchematic, i, j, end, directions)) sum += number;
                j = end - 1;
            }
        }

        return sum;
    }

    private static bool IsAdjacentToSymbol(IReadOnlyList<string> engineSchematic, int row, int startColumn,
        int endColumn, IEnumerable<(int dx, int dy)> directions)
    {
        foreach (var (dx, dy) in directions)
            for (var column = startColumn; column < endColumn; column++)
            {
                var newRow = row + dx;
                var newColumn = column + dy;
                if (IsOutOfBounds(engineSchematic, newRow, newColumn)) continue;
                var cell = engineSchematic[newRow][newColumn];
                if (cell != '.' && !char.IsDigit(cell))
                    return true;
            }

        return false;
    }

    private static long SumOfGearRatios(IReadOnlyList<string> engineSchematic, (int dx, int dy)[] directions)
    {
        long sum = 0;
        for (var i = 0; i < engineSchematic.Count; i++)
        for (var j = 0; j < engineSchematic[i].Length; j++)
            if (engineSchematic[i][j] == '*')
            {
                var adjacentNumbers = GetAdjacentNumbers(engineSchematic, i, j, directions);
                if (adjacentNumbers.Count == 2) sum += (long)adjacentNumbers[0] * adjacentNumbers[1];
            }

        return sum;
    }

    private static List<int> GetAdjacentNumbers(IReadOnlyList<string> engineSchematic, int i, int j,
        IEnumerable<(int dx, int dy)> directions)
    {
        var numbers = new List<int>();
        var addedNumbers = new HashSet<(int, int)>();
        foreach (var (dx, dy) in directions)
        {
            var ni = i + dx;
            var nj = j + dy;
            if (IsOutOfBounds(engineSchematic, ni, nj) || !char.IsDigit(engineSchematic[ni][nj]) ||
                addedNumbers.Contains((ni, nj)))
                continue;
            var (start, end) = FindNumberBounds(engineSchematic, ni, nj);
            var numberStr = engineSchematic[ni].Substring(start, end - start + 1);
            numbers.Add(int.Parse(numberStr));
            for (var pos = start; pos <= end; pos++)
                addedNumbers.Add((ni, pos));
        }

        return numbers;
    }

    private static bool IsOutOfBounds(IReadOnlyList<string> engineSchematic, int i, int j) =>
        i < 0 || i >= engineSchematic.Count || j < 0 || j >= engineSchematic[i].Length;

    private static (int start, int end) FindNumberBounds(IReadOnlyList<string> engineSchematic, int rowIndex,
        int columnIndex)
    {
        var start = FindStartIndex(engineSchematic, rowIndex, columnIndex);
        var end = FindEndIndex(engineSchematic, rowIndex, columnIndex);
        return (start, end);
    }

    private static int FindStartIndex(IReadOnlyList<string> engineSchematic, int rowIndex, int columnIndex)
    {
        while (columnIndex > 0 && char.IsDigit(engineSchematic[rowIndex][columnIndex - 1]))
            columnIndex--;
        return columnIndex;
    }

    private static int FindEndIndex(IReadOnlyList<string> engineSchematic, int rowIndex, int columnIndex)
    {
        while (columnIndex < engineSchematic[rowIndex].Length - 1 &&
               char.IsDigit(engineSchematic[rowIndex][columnIndex + 1]))
            columnIndex++;
        return columnIndex;
    }

    private static int FindEndOfNumber(string line, int start)
    {
        var end = start;
        while (end < line.Length && char.IsDigit(line[end])) end++;
        return end;
    }

    private static int ParseNumberFromLine(string line, int start, int end)
    {
        var numberStr = line[start..end];
        return int.Parse(numberStr);
    }
}