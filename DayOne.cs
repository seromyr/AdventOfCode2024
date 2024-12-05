namespace AdventOfCode2024
{
    public class DayOne
    {
        private const string InputData = "Data/day-one-input.txt";
        private List<int>[] _toCompareLists = new List<int>[2];
        
        public void ShowResult()
        {
            Console.WriteLine("Advent Of Code - Day One - Solution");
            Initialize();
            ProcessData();
        }
        
        private void Initialize()
        {
            Console.WriteLine("Preparing data...");
            for (int i = 0; i < _toCompareLists.Length; i++)
            {
                _toCompareLists[i] = new List<int>();
            }
        }

        private void ProcessData()
        {
            Console.WriteLine("Processing data...");
            if (!CheckFileExist(InputData))
            {
                throw new FileNotFoundException($"The file '{InputData}' was not found.");
            }

            ParseInputData(InputData);

            if (!CompareTwoNewLists())
            {
                throw new Exception("Two lists don't have the same amount of members. Check your input source");
            }
            
            Console.WriteLine($"The result is: {GetTheTotalDifferencesFromTwoLists()}");
        }

        private bool CheckFileExist(string filePath)
        {
            return File.Exists(filePath);
        }

        private void ParseInputData(string filePath)
        {
            string[] content = File.ReadAllLines(filePath);

            Console.WriteLine("Parsing input data into two numerical lists...");
            
            foreach (string line in content)
            {
                ParseEachLine(line);
            }
        }

        private void ParseEachLine(string line)
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

        private int ConvertToNumber(string value)
        {
            if (int.TryParse(value, out int result))
            {
                return result;
            }

            throw new Exception($"Value '{value}' is not a valid number.");
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