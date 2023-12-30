using System.Globalization;
using System.Text.RegularExpressions;
using AdventOfCode2023.Interfaces;

namespace AdventOfCode2023._2023.Day_04;

public class Solution(string input) : ISolution
{
    public string PartOne()
    {
        var parsedCards = input.Split('\n').Select(line => new { line, card = ParseCard(line) });
        var cardsWithMatches = parsedCards.Where(t => t.card.Matches > 0);
        var calculatedValues = cardsWithMatches.Select(t => Math.Pow(2, t.card.Matches - 1));
        var sum = calculatedValues.Sum();
        return sum.ToString(CultureInfo.InvariantCulture);
    }


    public string PartTwo()
    {
        var cards = input.Split('\n').Select(ParseCard).ToArray();
        var counts = cards.Select(_ => 1).ToArray();
        for (var i = 0; i < cards.Length; i++)
        {
            var (card, count) = (cards[i], counts[i]);
            for (var j = 0; j < card.Matches; j++) counts[i + j + 1] += count;
        }

        return counts.Sum().ToString();
    }


    private static Card ParseCard(string line)
    {
        var parts = line.Split(':', '|');
        var leftNumbers = ExtractNumbers(parts[1]);
        var rightNumbers = ExtractNumbers(parts[2]);
        var commonNumbersCount = leftNumbers.Intersect(rightNumbers).Count();
        return new Card(commonNumbersCount);
    }

    private static IEnumerable<string> ExtractNumbers(string part)
    {
        return Regex.Matches(part, @"\d+").Select(match => match.Value);
    }
}

internal record Card(int Matches);