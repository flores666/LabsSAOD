namespace BinaryTree
{
    public class Node
    {
        public Node left;
        public Node right;

        public object? data;

        public Node() {}

        public Node(object? data) 
        {
            this.data = data;
        }
    }
}
