namespace AdventOfCode2024;

public class DayTwo : DaySolution
{
    private class Report
    {
        private List<int> _levels = new List<int>();

        public int Count => _levels.Count;

        public void AddLevel(int level)
        {
            _levels.Add(level);
        }

        public bool IsSafe(List<int> levels = null)
        {
            levels = levels ?? _levels;

            if (_levels == null || _levels.Count < 2)
            {
                throw new ArgumentException("List must contain at least two elements.");
            }

            bool increasing = true;
            bool initialized = false;

            for (int i = 0; i < levels.Count - 1; i++)
            {
                int difference = levels[i + 1] - levels[i];
                int absDiff = Math.Abs(difference);

                if (absDiff < 1 || absDiff > 3)
                {
                    return false;
                }

                if (!initialized)
                {
                    if (difference > 0)
                    {
                        increasing = true;
                        initialized = true;
                    }
                    else if (difference < 0)
                    {
                        increasing = false;
                        initialized = true;
                    }
                }
                else
                {
                    if ((difference > 0 && !increasing) || (difference < 0 && increasing))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool IsSafeWithDampener(int index = 0)
        {
            if (index >= _levels.Count)
            {
                // Base case: if we've checked all possible indices
                return false;
            }

            var copy = new List<int>(_levels);
            copy.RemoveAt(index);

            if (IsSafe(copy))
            {
                return true;
            }

            // Recursively check the next index
            return IsSafeWithDampener(index + 1);
        }
    }

    private List<Report> _reports = new List<Report>();

    public DayTwo(string day, string inputData) : base(day, inputData)
    {
        Day = day;
        InputData = inputData;
    }

    protected override void ProcessData()
    {
        base.ProcessData();

        ParseInputData(InputData, "Parsing input data into reports...");

        Console.WriteLine($"There are {_reports.Count} reports.");
        Console.WriteLine($"There are {CountSafeReport(false)} safe reports.");
        Console.WriteLine($"There are {CountSafeReport(true)} safe reports actually (with Problem Dampener ON).");
    }

    protected override void ParseEachLine(string line)
    {
        string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        Report report = new Report();

        foreach (string part in parts)
        {
            report.AddLevel(ConvertToNumber(part));
        }

        if (parts.Length != report.Count)
        {
            throw new Exception("Mismatch data when parsing a line into report data");
        }

        _reports.Add(report);
    }

    private int CountSafeReport(bool problemDampener)
    {
        int safeCount = 0;

        foreach (Report report in _reports)
        {
            bool isSafe = problemDampener ? report.IsSafeWithDampener() : report.IsSafe();

            if (isSafe)
            {
                safeCount++;
            }
        }

        return safeCount;
    }
}
