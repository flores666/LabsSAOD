namespace StackAndQueue
{
    public class StackByTwoQueue<Type>
    {
        private Queue<Type> _queue1 = new Queue<Type>();
        private Queue<Type> _queue2 = new Queue<Type>();
        private int _stackSize;

        public bool FirstEmpty => _queue1.Count == 0;
        public bool SecondEmpty => _queue2.Count == 0;
        public int Count => _stackSize;

        public StackByTwoQueue()
        {
            _stackSize = 0;
        }

        public void Push(Type value)
        {
            _stackSize++;
            _queue2.Enqueue(value);

            while (!FirstEmpty)
            {
                _queue2.Enqueue(_queue1.Dequeue());
            }

            var queue = _queue1;

            _queue1 = _queue2;
            _queue2 = queue;
        }

        public Type Pop()
        {
            if (FirstEmpty) return default(Type);
            _stackSize--;
            return _queue1.Dequeue();
        }

        public void Print()
        {
            foreach (var item in _queue1)
            {
                Console.Write(item + " ");
            }
        }
    }
}
