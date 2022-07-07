namespace StackAndQueue
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("-----ArrayStack-----");

            var arrayStack = new ArrayStack<string>();

            if (arrayStack.Empty)
            {
                Console.WriteLine("Empty!");
            }

            arrayStack.Push("AA");
            arrayStack.Push("VVS");
            arrayStack.Push("GHS");

            arrayStack.Print();

            Console.WriteLine($"{Environment.NewLine}Deleting: " + arrayStack.Pop());

            arrayStack.Print();

            Console.WriteLine($"{Environment.NewLine}Peek: {arrayStack.Peek}");

            if(arrayStack.Contains("AA"))
            {
                Console.WriteLine("AA is found");
            }

            arrayStack.Clear();

            arrayStack.Print();

            Console.WriteLine("-----ArrayQueue-----");

            var arrayQueue = new ArrayQueue<string>();

            if (arrayQueue.Empty)
            {
                Console.WriteLine("Empty!");
            }

            arrayQueue.Enqueue("AA");
            arrayQueue.Enqueue("VVS");
            arrayQueue.Enqueue("GHS");

            arrayQueue.Print();

            Console.WriteLine($"{Environment.NewLine}Deleting: " + arrayQueue.Dequeue());

            arrayQueue.Print();

            Console.WriteLine($"{Environment.NewLine}Front: {arrayQueue.Peek}");

            if (arrayStack.Contains("AA"))
            {
                Console.WriteLine("AA is found");
            }

            arrayQueue.Clear();

            arrayQueue.Print();

            Console.WriteLine("-----ListStack-----");

            var listStack = new ListStack<string>();

            if (listStack.Empty)
            {
                Console.WriteLine("Empty!");
            }

            listStack.Push("AA");
            listStack.Push("VVS");
            listStack.Push("GHS");

            listStack.Print();

            Console.WriteLine($"{Environment.NewLine}Deleting: " + listStack.Pop());

            listStack.Print();

            Console.WriteLine($"{Environment.NewLine}Peek: {listStack.Peek}");

            if (listStack.Contains("AA"))
            {
                Console.WriteLine("AA is found");
            }

            listStack.Clear();

            listStack.Print();

            Console.WriteLine("-----ListQueue-----");

            var listQueue = new ListQueue<string>();

            if (listQueue.Empty)
            {
                Console.WriteLine("Empty!");
            }

            listQueue.Enqueue("AA");
            listQueue.Enqueue("VVS");
            listQueue.Enqueue("GHS");

            listQueue.Print();

            Console.WriteLine($"{Environment.NewLine}Deleting: " + listQueue.Dequeue());

            listQueue.Print();

            Console.WriteLine($"{Environment.NewLine}Front: {listQueue.Front}");

            if (listQueue.Contains("AA"))
            {
                Console.WriteLine("AA is found");
            }

            listQueue.Clear();

            listQueue.Print();

            Console.WriteLine("-----TwoStacksInArray-----");

            var twoStacks = new TwoStacksInArray<int>(10);
            twoStacks.FirstPush(5);
            twoStacks.FirstPush(1);

            twoStacks.SecondPush(9);
            twoStacks.SecondPush(8);
            twoStacks.SecondPush(-6);
            twoStacks.SecondPush(-5);

            twoStacks.Print();

            Console.WriteLine();

            twoStacks.SecondPop();
            twoStacks.FirstPop();
            twoStacks.FirstPop();

            twoStacks.Print();
            Console.WriteLine();

            Console.WriteLine("-----StackByTwoQueue-----");

            var stackByTwoQueue = new StackByTwoQueue<int>();

            stackByTwoQueue.Push(1);
            stackByTwoQueue.Push(6);
            stackByTwoQueue.Push(9);
            stackByTwoQueue.Push(11);

            stackByTwoQueue.Print();
        }
    }
}