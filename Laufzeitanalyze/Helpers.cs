namespace Laufzeitanalyze
{
    public class Helpers
    {
        public static IList<int> GetRandomList(int size, int min = 1, int max = 1000)
        {
            Random rnd = new Random();
            return Enumerable.Range(0, size).Select(x => rnd.Next(min, max)).ToList();
        }

        public static void PrintList(IList<int> list)
        {
            Console.WriteLine(list.Aggregate("", (str, elem) => str + elem + " "));
        }

        public static double MeasureSortingTime(IList<int> list, Func<IList<int>, IList<int>> sortingMethod)
        {
            var copiedList = new List<int>(list);

            var start = DateTime.Now;
            sortingMethod(copiedList);
            var end = DateTime.Now;

            return (end - start).TotalMilliseconds;
        }

        public static string GetTable(IList<double> bubbleTimes, IList<double> selectionTimes, IList<double> insertionTimes)
        {
            string table = "";

            table += GetTimeRow("", Enumerable.Range(1, 10).Select(x => 1000.0 * x).ToList());
            table += GetTimeRow("Bubble Sort", bubbleTimes, "0.00 ms");
            table += GetTimeRow("Selection Sort", selectionTimes, "0.00 ms");
            table += GetTimeRow("Insertion Sort", insertionTimes, "0.00 ms");

            return table;
        }

        private static string GetTimeRow(string name, IList<double> times, string format = "0.#")
        {
            int nameLength = 15;
            int numberLength = 11;

            return times.Aggregate(string.Format($"{{0,{nameLength}}}", name), (str, elem) =>
            {
                return str + string.Format($"{{0,{numberLength}:{format}}}", elem);
            }) + '\n';
        }
    }
}