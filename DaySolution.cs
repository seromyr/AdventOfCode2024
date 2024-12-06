namespace AdventOfCode2024
{
    public abstract class DaySolution
    {
        protected string InputData;
        protected string Day;

        public DaySolution(string day, string inputData)
        {
            Day = day;
            InputData = inputData;
        }

        public void ShowResult()
        {
            Console.WriteLine($"Advent Of Code - Day {Day} - Solution");
            Initialize();
            ProcessData();
        }

        protected virtual void Initialize()
        {
            Console.WriteLine("Initialize solution...");
        }

        protected virtual void ProcessData()
        {
            Console.WriteLine("Processing data...");
            if (!CheckFileExist(InputData))
            {
                throw new FileNotFoundException($"The file '{InputData}' was not found.");
            }
        }
        
        private static bool CheckFileExist(string filePath)
        {
            return File.Exists(filePath);
        }
        
        protected static int ConvertToNumber(string value)
        {
            if (int.TryParse(value, out int result))
            {
                return result;
            }

            throw new Exception($"Value '{value}' is not a valid number.");
        }

        protected abstract void ParseInputData(string filePath);
        protected abstract void ParseEachLine(string line);
    }
}