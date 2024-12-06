namespace AdventOfCode2024
{
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

            public bool IsSafe()
            {
                if (_levels == null || _levels.Count < 2)
                {
                    throw new Exception("Invalid report data. Please check your input.");
                }

                return (IsLevelsDecreasing() || IsLevelsIncreasing()) &&
                       IsAnyTwoAdjacentLevelsDifferByAtLeastOneAndAtMostThree();
            }

            private bool IsLevelsIncreasing()
            {
                for (int i = 0; i < _levels.Count - 1; i++)
                {
                    if (_levels[i] >= _levels[i + 1])
                    {
                        return false;
                    }
                }

                return true;
            }

            private bool IsLevelsDecreasing()
            {
                for (int i = 0; i < _levels.Count - 1; i++)
                {
                    if (_levels[i] <= _levels[i + 1])
                    {
                        return false;
                    }
                }

                return true;
            }

            private bool IsAnyTwoAdjacentLevelsDifferByAtLeastOneAndAtMostThree()
            {
                for (int i = 0; i < _levels.Count - 1; i++)
                {
                    int difference = Math.Abs(_levels[i] - _levels[i + 1]);
                    if (difference < 1 || difference > 3)
                    {
                        return false;
                    }
                }

                return true;
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

            ParseInputData(InputData);

            Console.WriteLine($"There are {_reports.Count} reports.");
            Console.WriteLine($"There are {CountSafeReport()} safe reports.");
        }

        protected override void ParseInputData(string filePath)
        {
            string[] content = File.ReadAllLines(filePath);

            Console.WriteLine("Parsing input data into reports...");

            foreach (string line in content)
            {
                ParseEachLine(line);
            }
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

        private int CountSafeReport()
        {
            int safeCount = 0;

            foreach (Report report in _reports)
            {
                if (report.IsSafe())
                {
                    safeCount++;
                }
            }

            return safeCount;
        }
    }
}