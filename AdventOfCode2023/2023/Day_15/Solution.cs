using AdventOfCode2023.Interfaces;

namespace AdventOfCode2023._2023.Day_15;

using Boxes = List<Lens>[];

internal record Lens(string Label, int FocalLength);

internal record Step(string Label, int? FocalLength);

public class Solution(string input) : ISolution
{
    public string PartOne() => input.Split(',').Select(Hash).Sum().ToString();

    public string PartTwo() => ParseSteps(input)
        .Aggregate(MakeBoxes(256), UpdateBoxes, GetFocusingPower).ToString();

    private static Boxes UpdateBoxes(Boxes boxes, Step step)
    {
        var box = boxes[Hash(step.Label)];
        var iLens = box.FindIndex(lens => lens.Label == step.Label);
        if (step.FocalLength.HasValue)
        {
            if (iLens >= 0)
                box[iLens] = new Lens(step.Label, step.FocalLength.Value);
            else
                box.Add(new Lens(step.Label, step.FocalLength.Value));
        }
        else if (iLens >= 0)
        {
            box.RemoveAt(iLens);
        }

        return boxes;
    }


    private static IEnumerable<Step> ParseSteps(string input) =>
        input.Split(',')
            .Select(item => new { item, parts = item.Split('-', '=') })
            .Select(t => new Step(t.parts[0], t.parts[1] == "" ? null : int.Parse(t.parts[1])));

    private static Boxes MakeBoxes(int count) =>
        Enumerable.Range(0, count).Select(_ => new List<Lens>()).ToArray();

    private static int GetFocusingPower(Boxes boxes) => Enumerable.Range(0, boxes.Length)
        .SelectMany(iBox => Enumerable.Range(0, boxes[iBox].Count),
            (iBox, iLens) => (iBox + 1) * (iLens + 1) * boxes[iBox][iLens].FocalLength).Sum();

    private static int Hash(string st) => st.Aggregate(0, (ch, a) => (ch + a) * 17 % 256);
}