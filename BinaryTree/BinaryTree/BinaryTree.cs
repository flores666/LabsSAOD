namespace BinaryTree
{
    public class BinaryTree<Type>
    {
        private Node _node;

        public Node Node => _node;

        private int Compare(object? item1, object? item2)
        {
            var comparableItem = (IComparable)item1;
            return comparableItem.CompareTo(item2);
        }

        public void Insert(Type data)
        {
            if (_node == null)
            {
                _node = new Node(data);
            }
            else
            {
                Add(data, _node);
            }     
        }
        
        private void Add(Type data, Node node)
        {
            if (Compare(data, _node.data) < 0)
            {
                if (node.left == null)
                {
                    node.left = new Node(data);
                }
                else
                {
                    Add(data, node.left);
                }
            }
            else
            {
                if (node.right == null)
                {
                    node.right = new Node(data);
                }
                else
                {
                    Add(data, node.right);
                }
            }
        }

        private void PreOrderTraversal(Node node)
        {
            if (node != null)
            {
                Console.Write(node.data + " ");
                PreOrderTraversal(node.left);
                PreOrderTraversal(node.right);
            }
        }

        public void PreOrderTraversal()
        {
            PreOrderTraversal(_node);
        }

        private void PostOrderTraversal(Node node)
        {
            if (node != null)
            {
                PostOrderTraversal(node.left);
                PostOrderTraversal(node.right);
                Console.Write(node.data + " ");
            }
        }
        public void PostOrderTraversal()
        {
            PostOrderTraversal(_node);
        }

        private void InOrderTraversal(Node node)
        {
            if (node != null)
            {
                InOrderTraversal(node.left);
                Console.Write(node.data + " "); // action()
                InOrderTraversal(node.right);
            }
        }
        public void InOrderTraversal()
        {
            InOrderTraversal(_node);
        }

        public void Print()
        {
            if (_node == null) return;

            Console.WriteLine(_node.data);

            var level = 0;
            Print(_node.left, level + 3);
            Print(_node.right, level);
        }

        private void Print(Node node, int level = 0)
        {
            if (node == null) return;

            for (var i = 0; i < level; i++)
            {
                Console.Write(" ");
            }

            Console.WriteLine(node.data);

            Print(node.left, level + 3);
            Print(node.right, level);
        }
    }
}