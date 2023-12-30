using System.Text.RegularExpressions;
using AdventOfCode2023.Interfaces;

namespace AdventOfCode2023._2023.Day_24;

internal record Vec2(decimal X0, decimal X1);

internal record Vec3(decimal X0, decimal X1, decimal X2);

internal record Particle2(Vec2 Pos, Vec2 Vel);

internal record Particle3(Vec3 Pos, Vec3 Vel);

public class Solution(string input) : ISolution
{
    public string PartOne()
    {
        var particles = Project(ParseParticles(input), v => (v.X0, v.X1));

        var res = 0;
        for (var i = 0; i < particles.Length; i++)
        for (var j = i + 1; j < particles.Length; j++)
        {
            var pos = Intersection(particles[i], particles[j]);
            if (pos != null &&
                InRange(pos.X0) &&
                InRange(pos.X1) &&
                InFuture(particles[i], pos) &&
                InFuture(particles[j], pos)
               )
                res++;
        }

        return res.ToString();

        bool InFuture(Particle2 p, Vec2 pos) => Math.Sign(pos.X0 - p.Pos.X0) == Math.Sign(p.Vel.X0);

        bool InRange(decimal d) => d is >= 2e14m and <= 4e14m;
    }

    public string PartTwo()
    {
        var particles = ParseParticles(input);
        var stoneXy = Solve2D(Project(particles, vec => (vec.X0, vec.X1)));
        var stoneXz = Solve2D(Project(particles, vec => (vec.X0, vec.X2)));
        return Math.Round(stoneXy.X0 + stoneXy.X1 + stoneXz.X1).ToString();
    }

    private static Vec2 Solve2D(Particle2[] particles)
    {
        const int s = 500;
        for (var v1 = -s; v1 < s; v1++)
        for (var v2 = -s; v2 < s; v2++)
        {
            var vel = new Vec2(v1, v2);

            var stone = Intersection(
                TranslateV(particles[0], vel),
                TranslateV(particles[1], vel)
            );
            if (stone is null) continue;

            if (particles.All(p => Hits(TranslateV(p, vel), stone))) return stone;
        }

        throw new Exception();

        static Particle2 TranslateV(Particle2 p, Vec2 vel) =>
            new(p.Pos, new Vec2(p.Vel.X0 - vel.X0, p.Vel.X1 - vel.X1));
    }

    private static bool Hits(Particle2 p, Vec2 pos)
    {
        var d = (pos.X0 - p.Pos.X0) * p.Vel.X1 - (pos.X1 - p.Pos.X1) * p.Vel.X0;
        return Math.Abs(d) < (decimal)0.0001;
    }

    private static Vec2? Intersection(Particle2 p1, Particle2 p2)
    {
        var determinant = p1.Vel.X0 * p2.Vel.X1 - p1.Vel.X1 * p2.Vel.X0;
        if (determinant == 0) return null;

        var b0 = p1.Vel.X0 * p1.Pos.X1 - p1.Vel.X1 * p1.Pos.X0;
        var b1 = p2.Vel.X0 * p2.Pos.X1 - p2.Vel.X1 * p2.Pos.X0;

        return new Vec2(
            (p2.Vel.X0 * b0 - p1.Vel.X0 * b1) / determinant,
            (p2.Vel.X1 * b0 - p1.Vel.X1 * b1) / determinant
        );
    }

    private static Particle3[] ParseParticles(string input) =>
    [
        .. input.Split('\n')
            .Select(line => new { line, v = ParseNum(line) })
            .Select(t => new Particle3(new Vec3(t.v[0], t.v[1], t.v[2]), new Vec3(t.v[3], t.v[4], t.v[5])))
    ];

    private static decimal[] ParseNum(string l) =>
    [
        .. Regex.Matches(l, @"-?\d+").Select(m => decimal.Parse(m.Value))
    ];

    private static Particle2[] Project(Particle3[] ps, Func<Vec3, (decimal, decimal)> proj) =>
    [
        .. ps.Select(p => new Particle2(new Vec2(proj(p.Pos).Item1, proj(p.Pos).Item2),
            new Vec2(proj(p.Vel).Item1, proj(p.Vel).Item2)))
    ];
}