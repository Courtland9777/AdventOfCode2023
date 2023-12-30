using AdventOfCode2023.Interfaces;

namespace AdventOfCode2023._2023.Day_22;

internal record Range(int Begin, int End);

internal record Block(Range X, Range Y, Range Z)
{
    public int Top => Z.End;
    public int Bottom => Z.Begin;
}

internal record Supports(
    Dictionary<Block, HashSet<Block>> BlocksAbove,
    Dictionary<Block, HashSet<Block>> BlocksBelow
);

public class Solution(string input) : ISolution
{
    public string PartOne() => Kaboom(input).Count(x => x == 0).ToString();

    public string PartTwo() => Kaboom(input).Sum().ToString();

    private static IEnumerable<int> Kaboom(string input)
    {
        var blocks = Fall(ParseBlocks(input));
        var supports = GetSupports(blocks);
        foreach (var disintegratedBlock in blocks)
        {
            var fallingBlocksCount = GetFallingBlocksCount(disintegratedBlock, supports);
            yield return fallingBlocksCount;
        }
    }

    private static int GetFallingBlocksCount(Block disintegratedBlock, Supports supports)
    {
        var q = new Queue<Block>();
        q.Enqueue(disintegratedBlock);
        var falling = new HashSet<Block>();
        while (q.TryDequeue(out var block))
        {
            falling.Add(block);
            EnqueueFallingBlocks(block, supports, q, falling);
        }

        return falling.Count - 1;
    }

    private static void EnqueueFallingBlocks(Block block, Supports supports, Queue<Block> q, HashSet<Block> falling)
    {
        var blocksStartFalling = supports.BlocksAbove[block]
            .Where(blockT => supports.BlocksBelow[blockT].IsSubsetOf(falling));
        foreach (var blockT in blocksStartFalling)
            q.Enqueue(blockT);
    }


    private static Block[] Fall(Block[] blocks)
    {
        blocks = [.. blocks.OrderBy(block => block.Bottom)];

        for (var i = 0; i < blocks.Length; i++)
        {
            var newBottom = 1;
            for (var j = 0; j < i; j++)
                if (IntersectsXy(blocks[i], blocks[j]))
                    newBottom = Math.Max(newBottom, blocks[j].Top + 1);
            var fall = blocks[i].Bottom - newBottom;
            blocks[i] = blocks[i] with
            {
                Z = new Range(blocks[i].Bottom - fall, blocks[i].Top - fall)
            };
        }

        return blocks;
    }

    private static Supports GetSupports(Block[] blocks)
    {
        var blocksAbove = blocks.ToDictionary(b => b, _ => new HashSet<Block>());
        var blocksBelow = blocks.ToDictionary(b => b, _ => new HashSet<Block>());
        for (var i = 0; i < blocks.Length; i++)
        for (var j = i + 1; j < blocks.Length; j++)
        {
            var zNeighbours = blocks[j].Bottom == 1 + blocks[i].Top;
            if (!zNeighbours || !IntersectsXy(blocks[i], blocks[j])) continue;
            blocksBelow[blocks[j]].Add(blocks[i]);
            blocksAbove[blocks[i]].Add(blocks[j]);
        }

        return new Supports(blocksAbove, blocksBelow);
    }

    private static bool IntersectsXy(Block blockA, Block blockB) =>
        Intersects(blockA.X, blockB.X) && Intersects(blockA.Y, blockB.Y);

    private static bool Intersects(Range r1, Range r2) => r1.Begin <= r2.End && r2.Begin <= r1.End;

    private static Block[] ParseBlocks(string input) => input.Split('\n')
        .Select(line => new { line, numbers = line.Split(',', '~').Select(int.Parse).ToArray() })
        .Select(t => new Block(new Range(t.numbers[0], t.numbers[3]), new Range(t.numbers[1], t.numbers[4]),
            new Range(t.numbers[2], t.numbers[5]))).ToArray();
}