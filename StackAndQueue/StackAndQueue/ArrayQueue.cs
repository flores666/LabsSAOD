namespace StackAndQueue
{
    public class ArrayQueue<Type>
    {
        private List<Type> _queue = new List<Type>();
        private int _top;
        private int _front;

        public bool Empty => _top == -1;
        public Type Peek
        {
            get
            {
                if (_top < 0)
                {
                    throw new InvalidOperationException("Queue is empty");
                }

                return _queue[_front];
            }
        }

        public ArrayQueue()
        {
            _top = -1;
            _front = 0;
        }

        public void Enqueue(Type element)
        {
            _queue.Add(element);
            _top++;
        }

        public Type Dequeue()
        {
            if (_top < 0)
            {
                throw new IndexOutOfRangeException("Queue is empty");
            }

            var temp = _queue[_front];
            _queue.RemoveAt(_front);
            _top--;
            return temp;
        }

        public bool Contains(Type element)
        {
            return _queue.Contains(element);
        }

        public void Clear()
        {
            _queue.Clear();
            _top = -1;
        }

        public void Print()
        {
            if (_top < 0)
            {
                Console.WriteLine("Queue is empty");
            }

            foreach (var element in _queue)
            {
                Console.Write(element + " ");
            }
        }
    }
}