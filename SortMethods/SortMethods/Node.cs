namespace SortMethods
{
    public class Node
    {
        private object? _data;
        public Node Next { get; set; }

        public object? Data => _data;

        public Node(object? data)
        {
            _data = data;
        }
    }
}
