namespace BinaryTree
{
    public class Program 
    {
        public static void Main()
        {
            var tree = new BinaryTree<int>();

            tree.Insert(10);
            tree.Insert(2);
            tree.Insert(35);
            tree.Insert(4);

            Console.WriteLine("Tree: ");
            tree.Print();
            Console.WriteLine();

            Console.Write("PreOrder: ");
            tree.PreOrderTraversal();
            Console.WriteLine();

            Console.Write("PostOrder: ");
            tree.PostOrderTraversal();
            Console.WriteLine();

            Console.Write("InOrder: ");
            tree.InOrderTraversal();
            Console.WriteLine();
        }
    }
}