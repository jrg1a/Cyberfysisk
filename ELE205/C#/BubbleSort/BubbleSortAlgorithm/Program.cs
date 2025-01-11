namespace BubbleSortAlgorithm;

class Program
{
    static void Main(string[] args)
    {
        // Eksempel: usortert liste
        int[] numbers = { 64, 34, 25, 12, 22, 11, 90 };

        Console.WriteLine("Usortert array:");
        PrintArray(numbers);

        // Sorter arrayet
        BubbleSort(numbers);

        Console.WriteLine("\nSortert array:");
        PrintArray(numbers);
    }

    static void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    // Bytt plass på arr[j] og arr[j+1]
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    static void PrintArray(int[] arr)
    {
        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}