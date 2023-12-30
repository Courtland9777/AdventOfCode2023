using System.Globalization;
using System.Numerics;
using AdventOfCode2023.Interfaces;

namespace AdventOfCode2023._2023.Day_18;

public class Solution(string input) : ISolution
{
    public string PartOne() => CalculateArea(Steps1(input)).ToString(CultureInfo.InvariantCulture);

    public string PartTwo() => CalculateArea(Steps2(input)).ToString(CultureInfo.InvariantCulture);

    private static IEnumerable<Complex> Steps1(string input) =>
        input.Split('\n')
            .Select(line => new { line, parts = line.Split(' ') })
            .Select(t => new
            {
                t,
                dir = t.parts[0] switch
                {
                    "R" => Complex.One,
                    "U" => -Complex.ImaginaryOne,
                    "L" => -Complex.One,
                    "D" => Complex.ImaginaryOne,
                    _ => throw new Exception()
                }
            })
            .Select(t => new { t, dist = int.Parse(t.t.parts[1]) })
            .Select(t => t.t.dir * t.dist);

    private static IEnumerable<Complex> Steps2(string input) =>
        input.Split('\n')
            .Select(line => new { line, hex = line.Split(' ')[2] })
            .Select(t => new
            {
                t,
                dir = t.hex[7] switch
                {
                    '0' => Complex.One,
                    '1' => -Complex.ImaginaryOne,
                    '2' => -Complex.One,
                    '3' => Complex.ImaginaryOne,
                    _ => throw new Exception()
                }
            })
            .Select(t => new { t, dist = Convert.ToInt32(t.t.hex[2..7], 16) })
            .Select(t => t.t.dir * t.dist);

    private static double CalculateArea(IEnumerable<Complex> steps)
    {
        var stepsList = steps.ToList();
        var vertices = GetVertices(stepsList).ToList();
        var area = CalculateShoelaceArea(vertices);
        var boundary = CalculateBoundary(stepsList);
        var interior = CalculateInterior(area, boundary);
        return CalculateTotalArea(boundary, interior);
    }

    private static double CalculateBoundary(IEnumerable<Complex> steps) =>
        steps.Select(x => x.Magnitude).Sum();

    private static double CalculateInterior(double area, double boundary) =>
        area - boundary / 2 + 1;

    private static double CalculateTotalArea(double boundary, double interior) =>
        boundary + interior;

    private static IEnumerable<Complex> GetVertices(IEnumerable<Complex> steps)
    {
        var position = Complex.Zero;
        foreach (var step in steps)
        {
            position += step;
            yield return position;
        }
    }

    private static double CalculateShoelaceArea(IReadOnlyList<Complex> vertices)
    {
        var shiftedVertices = vertices.Skip(1).Append(vertices[0]);
        var shoelaces = vertices.Zip(shiftedVertices)
            .Select(points => new { points, firstPoint = points.First })
            .Select(t => new { t, secondPoint = t.points.Second })
            .Select(t =>
                t.t.firstPoint.Real * t.secondPoint.Imaginary - t.t.firstPoint.Imaginary * t.secondPoint.Real);
        return Math.Abs(shoelaces.Sum()) / 2;
    }
}