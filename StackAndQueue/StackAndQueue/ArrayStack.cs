namespace StackAndQueue
{
    public class ArrayStack<Type>
    {
        private List<Type> _stack = new List<Type>();
        private int _top;

        public bool Empty => _top == -1;
        public Type Peek { 
            get {
                if (_top < 0)
                {
                    throw new InvalidOperationException("Stack is empty");
                }

                return _stack[_top];
            }
        }

        public ArrayStack()
        {
            _top = -1;
        }

        public void Push(Type element)
        {
            _stack.Add(element);
            _top++;
        }

        public Type Pop()
        {
            if (_top < 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            var temp = _stack[_top];
            _stack.RemoveAt(_top);
            _top--;
            return temp;
        }

        public bool Contains(Type element)
        {
            return _stack.Contains(element);
        }

        public void Clear()
        {
            _stack.Clear();
            _top = -1;
        }

        public void Print()
        {
            if (_top < 0)
            {
                Console.WriteLine("Stack is empty");
            }

            foreach (var element in _stack)
            {
                Console.Write(element + " ");
            }
        }
    }
}