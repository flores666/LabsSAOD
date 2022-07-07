namespace StackAndQueue
{
    public class ListQueue<Type>
    {
        private Node _front;
        private Node _peak;

        public bool Empty => _front == null;
        public Type Front => (Type)_front.data;

        public void Enqueue(Type data)
        {
            var element = new Node();
            element.data = data;

            if (_front == null)
            {
                _front = element;
                _peak = element;
            }
            else
            {
                _peak.next = element;
                _peak = element;
            }
        }

        public Type Dequeue()
        {
            if (_front == null && _peak == null)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            Node element = _front;

            if (_front == _peak)
            {
                _front = null;
                _peak = null;
                return (Type)element.data;
            }

            var temp = _front;
            _front = _front.next;

            return (Type)temp.data;
        }

        private int Compare(object? item1, object? item2)
        {
            var comparableItem = (IComparable)item1;
            return comparableItem.CompareTo(item2);
        }

        public bool Contains(Type element)
        {
            var node = _front;

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
            var node = _front;

            while (node != null)
            {
                Dequeue();
                node = node.next;
            }

        }

        public void Print()
        {
            if (_front == null)
            {
                Console.WriteLine("Queue is empty.");
                return;
            }

            var element = _front;

            while (element != null)
            {
                Console.Write(element.data + " ");
                element = element.next;
            }
        }
    }
}