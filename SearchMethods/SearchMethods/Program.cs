namespace SearchMethods
{
    public class Program
    {
        public static void Main()
        {
            var array = new int[] { 11, -5, 3, 2, -7, 9, 10 };
            //var array = new double[] { 1.7, 5.0, 3.8, 2.3 };
            //var array = new string[] { "a", "as", "h", "tyu"};
            //var array = new bool[] { true, false, true, true, false };

            array.BubbleSort();
            array.Print();
            Console.WriteLine();

            var searchElement = 10;
            Console.WriteLine(array.SequentalSearch(searchElement));
            Console.WriteLine(array.BinarySearch(searchElement));
            Console.WriteLine(array.FibonachiSearch(searchElement));

            var hashTable = new HashTable();
            hashTable.Insert("45retb", 123);
            hashTable.Insert("ednsyt9gr", "bla");
            hashTable.Insert("98yerg", 1.6);
            hashTable.Insert("7fasd", true);

            Console.WriteLine(hashTable.Search("ednsyt9gr"));

            hashTable.PrintTable();
        }
    }
}