using System.Text.RegularExpressions;
using AdventOfCode2023.Interfaces;

namespace AdventOfCode2023._2023.Day_20;

using Signal = (string sender, string receiver, bool value);

internal record Gate(string[] Inputs, Func<Signal, IEnumerable<Signal>> Handle);

public class Solution(string input) : ISolution
{
    public string PartOne()
    {
        var gates = ParseGates(input);
        var values = Enumerable.Range(0, 1000).SelectMany(_ => Trigger(gates), (_, signal) => signal.value).ToArray();
        return (values.Count(v => v) * values.Count(v => !v)).ToString();
    }

    public string PartTwo()
    {
        var gates = ParseGates(input);
        var nAnd = gates["rx"].Inputs.Single();
        var branches = gates[nAnd].Inputs;
        return branches.Aggregate(1L, (m, branch) => m * LoopLength(string.Join('\n', input), branch)).ToString();
    }

    private static int LoopLength(string input, string output)
    {
        var gates = ParseGates(input);
        for (var i = 1;; i++)
        {
            var signals = Trigger(gates);
            if (signals.Any(s => s.sender == output && s.value)) return i;
        }
    }

    private static IEnumerable<Signal> Trigger(IReadOnlyDictionary<string, Gate> gates)
    {
        var q = new Queue<Signal>();
        q.Enqueue(new Signal("button", "broadcaster", false));

        while (q.TryDequeue(out var signal))
        {
            yield return signal;

            var handler = gates[signal.receiver];
            foreach (var signalT in handler.Handle(signal)) q.Enqueue(signalT);
        }
    }

    private static Dictionary<string, Gate> ParseGates(string input)
    {
        input += "\nrx ->";
        var descriptions = ParseDescriptions(input);
        Func<string, string[]> getInputs = name => descriptions
            .Where(d => d.outputs.Contains(name))
            .Select(d => d.name)
            .ToArray();
        var gates = descriptions.ToDictionary(
            description => description.name,
            description => CreateGate(description, getInputs)
        );
        return gates;
    }


    private static IEnumerable<(char kind, string name, string[] outputs)> ParseDescriptions(string input) =>
        input.Split('\n')
            .Select(line =>
            {
                var words = Regex.Matches(line, "\\w+").Select(m => m.Value).ToArray();
                return (kind: line[0], name: words.First(), outputs: words[1..]);
            });

    private static Gate CreateGate((char kind, string name, string[] outputs) description,
        Func<string, string[]> inputs) =>
        description.kind switch
        {
            '&' => NandGate(description.name, inputs(description.name), description.outputs),
            '%' => FlipFlop(description.name, inputs(description.name), description.outputs),
            _ => Repeater(description.name, inputs(description.name), description.outputs)
        };


    private static Gate NandGate(string name, string[] inputs, string[] outputs)
    {
        var state = inputs.ToDictionary(input => input, _ => false);

        return new Gate(inputs, signal =>
        {
            state[signal.sender] = signal.value;
            var value = !state.Values.All(b => b);
            return outputs.Select(o => new Signal(name, o, value));
        });
    }

    private static Gate FlipFlop(string name, string[] inputs, string[] outputs, bool state = false) =>
        new(inputs, signal =>
        {
            if (signal.value) return [];
            state = !state;
            return outputs.Select(o => new Signal(name, o, state));
        });

    private static Gate Repeater(string name, string[] inputs, string[] outputs) =>
        new(inputs, s => outputs.Select(o => new Signal(name, o, s.value)));
}