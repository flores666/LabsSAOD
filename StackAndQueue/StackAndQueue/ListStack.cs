namespace StackAndQueue
{
    public class ListStack<Type>
    {
        private Node _head;
        private Node _peak;

        public bool Empty => _head == null;
        public Type Peek => (Type)_peak.data;

        public void Push(Type data)
        {
            var element = new Node();
            element.data = data;

            if (_head == null)
            {
                _head = element;
                _peak = element;
            }
            else
            {
                _peak.next = element;
                _peak = element;
            }
        }

        public Type Pop()
        {
            if (_head  == null && _peak == null)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            Node element = _head;

            if (_head == _peak)
            {
                _head = null;
                _peak = null;
                return (Type)element.data;
            }

            while (element != null)
            {
                if (element.next == _peak)
                {
                    var tempData = (Type)element.next.data;
                    _peak = element;
                    _peak.next = null;
                    return tempData;
                }
                element = element.next;
            }

            return (Type)element.data;
        }

        private int Compare(object? item1, object? item2)
        {
            var comparableItem = (IComparable)item1;
            return comparableItem.CompareTo(item2);
        }

        public bool Contains(Type element)
        {
            var node = _head;

            while (node != null)
            {
                if (Compare(node.data, element) == 0)
                {
                    return true;
                }
                node = node.next;
            }

            return false;
        }

        public void Clear()
        {
            var node = _head;

            while (node != null)
            {
                Pop();
                node = node.next;
            }

            Pop();
        }

        public void Print()
        {
            if (_head == null)
            {
                Console.WriteLine("Stack is empty.");
                return;
            }

            var element = _head;

            while (element != null)
            {
                Console.Write(element.data + " ");
                element = element.next;
            }
        }
    }
}
