namespace StackAndQueue
{
    public class TwoStacksInArray<Type>
    {
        private List<Type> _array = new List<Type>();
        private int _firstTop;
        private int _secondTop;

        private readonly int _firstCapacity;
        private readonly int _secondCapacity;
        private readonly int _capacity;

        public int FirstTop => _firstTop;
        public int SecondTop => _secondTop;

        public TwoStacksInArray(int firstCapacity, int secondCapacity)
        {
            var capacity = firstCapacity + secondCapacity;
            _array = new List<Type>(capacity);

            InitializeStackDefault(capacity);

            _capacity = capacity;
            _firstCapacity = firstCapacity;
            _secondCapacity = secondCapacity;
            _firstTop = -1;
            _secondTop = capacity;
        }

        public TwoStacksInArray(int capacity)
        {
            _array = new List<Type>(capacity);

            InitializeStackDefault(capacity);

            _capacity = capacity;
            _firstCapacity = capacity / 2;
            _secondCapacity = capacity - _firstCapacity;
            _firstTop = -1;
            _secondTop = capacity;
        }

        private void InitializeStackDefault(int capacity)
        {
            for (var i = 0; i < capacity; i++)
            {
                _array.Add(default(Type));
            }
        }

        public void FirstPush(Type element)
        {
            if (_firstTop > _secondCapacity + 1)
            {
                throw new StackOverflowException("First stack is full");
            }

            _array[++_firstTop] = element;
        }

        public void SecondPush(Type element)
        {
            if (_secondTop < _firstCapacity)
            {
                throw new StackOverflowException("Second stack is full");
            }

            _array[--_secondTop] = element;
        }

        public Type FirstPop()
        {
            if (_firstTop < 0)
            {
                throw new InvalidOperationException("First stack is empty");
            }
            var temp = _array[_firstTop];
            _array[_firstTop--] = default(Type);
            return temp;
        }

        public Type SecondPop()
        {
            if (_secondTop >= _capacity)
            {
                throw new InvalidOperationException("First stack is empty");
            }

            var temp = _array[_secondTop];
            _array[_secondTop++] = default(Type);
            return temp;
        }

        public void Print()
        {
            var iterator = 0;
            foreach (var element in _array)
            {
                if (iterator++ == _firstCapacity)
                {
                    Console.Write("| ");
                }
                Console.Write(element + " ");
            }
        }
    }
}