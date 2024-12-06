namespace AdventOfCode2024
{
    public class DayOne : DaySolution
    {
        private List<int>[] _toCompareLists = new List<int>[2];

        public DayOne(string day, string inputData) : base(day, inputData)
        {
            Day = day;
            InputData = inputData;
        }

        protected override void Initialize()
        {
            base.Initialize();

            for (int i = 0; i < _toCompareLists.Length; i++)
            {
                _toCompareLists[i] = new List<int>();
            }
        }

        protected override void ProcessData()
        {
            base.ProcessData();

            ParseInputData(InputData);

            if (!CompareTwoNewLists())
            {
                throw new Exception("Two lists don't have the same amount of members. Check your input source");
            }

            Console.WriteLine($"The result is: {GetTheTotalDifferencesFromTwoLists()}");
        }

        protected override void ParseInputData(string filePath)
        {
            string[] content = File.ReadAllLines(filePath);

            Console.WriteLine("Parsing input data into two numerical lists...");

            foreach (string line in content)
            {
                ParseEachLine(line);
            }
        }

        protected override void ParseEachLine(string line)
        {
            string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 2)
            {
                throw new Exception("Invalid data format. Ensure your input data has exactly two numbers per line.");
            }

            for (int i = 0; i < _toCompareLists.Length; i++)
            {
                _toCompareLists[i].Add(ConvertToNumber(parts[i]));
            }
        }

        private bool CompareTwoNewLists()
        {
            return _toCompareLists[0].Count == _toCompareLists[1].Count;
        }

        private int GetTheTotalDifferencesFromTwoLists()
        {
            SortListsAscending();

            int totalDifference = 0;

            Console.WriteLine("Getting the total differences from those two lists...");
            for (int i = 0; i < _toCompareLists[0].Count; i++)
            {
                totalDifference += Math.Abs(_toCompareLists[0][i] - _toCompareLists[1][i]);
            }

            return totalDifference;
        }

        private void SortListsAscending()
        {
            Console.WriteLine("Sorting those lists ascending...");
            for (int i = 0; i < _toCompareLists.Length; i++)
            {
                _toCompareLists[i] = SortAListAscending(_toCompareLists[i]);
            }
        }

        private List<int> SortAListAscending(List<int> inputList)
        {
            return inputList.OrderBy(i => i).ToList();
        }
    }
}