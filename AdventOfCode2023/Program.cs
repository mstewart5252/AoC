using System.Diagnostics;
using AdventOfCode2023.Solutions;

namespace AdventOfCode2023;

public static class Program
{
    public static void Main()
    {
        #region Day1
        
        Console.WriteLine();
        Console.WriteLine("Day 1:");
        PrintResults(Day1.Part1, Day1.Part2);
        
        #endregion
    }

    private static void PrintResults(Func<string> part1, Func<string> part2)
    {
        Console.WriteLine("*******************************************************************");
        var sw = new Stopwatch();
        sw.Start();
        var part1Result = part1();
        sw.Stop();
        var part1Time = sw.ElapsedMilliseconds;
        Console.WriteLine($"Part 2: {part1Result}, Took: {part1Time}ms");
        
        sw.Restart();
        var part2Result = part2();
        sw.Stop();
        var part2Time = sw.ElapsedMilliseconds;
        Console.WriteLine($"Part 2: {part2Result}, Took: {part2Time}ms");
        
        Console.WriteLine($"Total Took: {part1Time + part2Time}ms");
        Console.WriteLine("*******************************************************************");
    }
}