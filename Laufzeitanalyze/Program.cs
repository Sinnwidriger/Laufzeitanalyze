using Laufzeitanalyze;

public class Program
{
    public static void Main(string[] args)
    {
        Console.SetBufferSize(130, 30);

        // List of lists with random values and different sizes from 1000 to 10000
        var lists = Enumerable.Range(1, 10).Select(x => Helpers.GetRandomList(1000 * x));

        // Making Test runs due to "list's native caching mechanism" that impacts on measure times
        var bubbleTimesTestRun = lists.Select(x => Helpers.MeasureSortingTime(x, SortingMethods.BubbleSort)).ToList();
        var selectionTimesTestRun = lists.Select(x => Helpers.MeasureSortingTime(x, SortingMethods.SelectionSort)).ToList();
        var insertionTimesTestRun = lists.Select(x => Helpers.MeasureSortingTime(x, SortingMethods.InserionSort)).ToList();

        // Actual measurements
        var bubbleTimes = lists.Select(x => Helpers.MeasureSortingTime(x, SortingMethods.BubbleSort)).ToList();
        var selectionTimes = lists.Select(x => Helpers.MeasureSortingTime(x, SortingMethods.SelectionSort)).ToList();
        var insertionTimes = lists.Select(x => Helpers.MeasureSortingTime(x, SortingMethods.InserionSort)).ToList();

        Console.WriteLine(Helpers.GetTable(bubbleTimes, selectionTimes, insertionTimes));
    }
}