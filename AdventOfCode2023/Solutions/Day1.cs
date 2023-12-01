namespace AdventOfCode2023.Solutions;

public static class Day1
{
    private static string[] _file;
    
    static Day1()
    {
        _file = File.ReadAllLines($"../../../Data/Day1.txt");
    }

    public static string Part1()
    {
        var vals = new List<int>();
        foreach (var line in _file)
        {
            int? first = null;
            int? last = null;
            foreach (var c in line)
            {
                if (int.TryParse(c.ToString(), out var temp))
                {
                    if (first == null)
                        first = temp;
                    else
                        last = temp;
                }
            }

            if (last == null)
                last = first;
            
            vals.Add(int.Parse($"{first}{last}"));
        }

        return vals.Sum().ToString();
    }

    public static string Part2()
    {
        var vals = new List<int>();
        var numStrings = new List<(string Word, int Value)>();
        numStrings.Add(("one", 1));
        numStrings.Add(("two", 2));
        numStrings.Add(("three", 3));
        numStrings.Add(("four", 4));
        numStrings.Add(("five", 5));
        numStrings.Add(("six", 6));
        numStrings.Add(("seven", 7));
        numStrings.Add(("eight", 8));
        numStrings.Add(("nine", 9));
        foreach (var line in _file)
        {
            var lineVals = new List<(int Val, int Pos)>();
            foreach (var numString in numStrings)
            {
                lineVals.AddRange(GetLineValues(line, numString));
            }

            lineVals = lineVals.OrderBy(l => l.Pos).ToList();
            var first = lineVals.First().Val;
            var last = lineVals.Last().Val;
            
            vals.Add(int.Parse($"{first}{last}"));
        }

        return vals.Sum().ToString();
    }

    private static List<(int Val, int Pos)> GetLineValues(string line,
        (string Word, int Value) numString, int? startIndex = null)
    {
        var lineVals = new List<(int Val, int Pos)>();
        int pos;
        
        if(startIndex == null)
            pos = line.IndexOf(numString.Word);
        else
            pos = line.IndexOf(numString.Word, startIndex.Value, StringComparison.Ordinal);
        if (pos != -1)
        {
            lineVals.Add(new (numString.Value, pos));
            
            lineVals.AddRange(GetLineValues(line, numString, pos + 1));
        }

        if(startIndex == null)
            pos = line.IndexOf(numString.Value.ToString());
        else
            pos = line.IndexOf(numString.Value.ToString(), startIndex.Value, StringComparison.Ordinal);
        if (pos != -1)
        {
            lineVals.Add(new (numString.Value, pos));
            
            lineVals.AddRange(GetLineValues(line, numString, pos + 1));
        }

        return lineVals;
    }
}