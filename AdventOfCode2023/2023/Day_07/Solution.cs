using AdventOfCode2023.Interfaces;

namespace AdventOfCode2023._2023.Day_07;

public class Solution(string input) : ISolution
{
    public string PartOne() =>
        Solve(input, Part1Points).ToString();

    public string PartTwo() =>
        Solve(input, Part2Points).ToString();

    private static (long, long) Part1Points(string hand) =>
        (PatternValue(hand), CardValue(hand, "123456789TJQKA"));

    private static (long, long) Part2Points(string hand)
    {
        const string cards = "J123456789TQKA";
        var patternValue = cards.Select(ch => PatternValue(hand.Replace('J', ch))).Max();
        return (patternValue, CardValue(hand, cards));
    }

    private static long CardValue(string hand, string cardOrder) =>
        Pack(hand.Select(card => cardOrder.IndexOf(card)));

    private static long PatternValue(string hand) =>
        Pack(hand.Select(card => hand.Count(x => x == card)).OrderDescending());

    private static long Pack(IEnumerable<int> numbers) =>
        numbers.Aggregate(1L, (a, v) => a * 256 + v);

    private static int Solve(string input, Func<string, (long, long)> getPoints)
    {
        var bidsByRanking = input.Split('\n')
            .Select(line => line.Split(" "))
            .Select(parts => new { Hand = parts[0], Bid = int.Parse(parts[1]) })
            .OrderBy(x => getPoints(x.Hand))
            .Select(x => x.Bid);
        return bidsByRanking.Select((bid, rank) => (rank + 1) * bid).Sum();
    }
}