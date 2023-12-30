using AdventOfCode2023.Interfaces;

namespace AdventOfCode2023._2023.Day_25;

public class Solution(string input) : ISolution
{
    public string PartOne()
    {
        var r = new Random();
        var (cutSize, c1, c2) = FindCut(input, r);
        while (cutSize != 3) (cutSize, c1, c2) = FindCut(input, r);
        return (c1 * c2).ToString();
    }

    public string PartTwo() => "All Done!";

    private static (int size, int c1, int c2) FindCut(string input, Random r)
    {
        var graph = Parse(input);
        var componentSize = graph.Keys.ToDictionary(k => k, _ => 1);

        while (graph.Count > 2)
        {
            var u = graph.Keys.ElementAt(r.Next(graph.Count));
            var v = graph[u][r.Next(graph[u].Count)];

            foreach (var neighbour in graph[v].ToArray())
            {
                graph[neighbour].Remove(v);
                graph[neighbour].Add(u);
            }

            graph[u] = [.. graph[u], .. graph[v]];

            graph[u] = [.. graph[u].Where(n => n != u)];

            componentSize[u] += componentSize[v];

            graph.Remove(v);
            componentSize.Remove(v);
        }

        var nodeA = graph.Keys.First();
        var nodeB = graph.Keys.Last();
        return (graph[nodeA].Count, componentSize[nodeA], componentSize[nodeB]);
    }

    private static Dictionary<string, List<string>> Parse(string input)
    {
        Dictionary<string, List<string>> res = [];

        foreach (var line in input.Split('\n'))
        {
            var parts = line.Split(": ");
            var u = parts[0];
            var nodes = parts[1].Split(' ');
            foreach (var v in nodes)
            {
                RegisterEdge(u, v);
                RegisterEdge(v, u);
            }
        }

        return res;

        void RegisterEdge(string u, string v)
        {
            if (!res.ContainsKey(u)) res[u] = [];
            res[u].Add(v);
        }
    }
}