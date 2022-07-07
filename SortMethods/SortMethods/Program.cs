namespace SortMethods
{
    public static class Program
    {
        public static void Main()
        {
            var array = new int[] { 9, 2, -7, 1, 5, 5, 1, 0 };
            //var array = new double[] { 6.1, 9.3, 4.4, 4.4, 7.9 };
            //var array = new string[] { "asd", "urt", "a", "ga"};

            //array.ShellSort();
            //array.QuickSort();
            //array.HeapSort();
            //array.RadixSort(); // int
            //array.CountSort(); // int
            array.MergeSort();

            array.Print();
            Console.WriteLine();

            var list = new LinkedList<int>();
            list.Push(2);
            list.Push(7);
            list.Push(1);
            list.Push(9);
            list.Push(0);

            //list.InsertionSort();
            list.MergeSort(list.Head);

            list.PrintList();
        }

        public static void PrintList<Type>(this LinkedList<Type> list)
        {
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
        }
    }
}