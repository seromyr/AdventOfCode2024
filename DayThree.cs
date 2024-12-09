using System.Text.RegularExpressions;

namespace AdventOfCode2024;

public class DayThree : DaySolution
{
    public DayThree(string day, string inputData) : base(day, inputData)
    {
        Day = day;
        InputData = inputData;
    }

    private string[] exportData;
    private List<int> _mults = new List<int>();

    // Regex pattern to match "mul(?,?)" where ? is one or more digits
    string _pattern = @"mul\((\d+),(\d+)\)";

    protected override void ProcessData()
    {
        base.ProcessData();

        ParseInputData(InputData, "Parsing input data into reports...");
        Console.WriteLine($"The total of the multiplications is {GetTotalMultiplications()}");
    }

    protected override void ParseEachLine(string line)
    {
        exportData = line.Split();

        foreach (string part in exportData)
        {
            MatchCollection matches = Regex.Matches(part, _pattern);

            foreach (Match match in matches)
            {
                int mult = ConvertToNumber(match.Groups[1].Value) * ConvertToNumber(match.Groups[2].Value);
                _mults.Add(mult);
            }
        }
    }

    private int GetTotalMultiplications()
    {
        int result = 0;

        foreach (var t in _mults)
        {
            result += t;
        }

        return result;
    }
}