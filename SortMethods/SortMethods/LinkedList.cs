using System.Collections;

namespace SortMethods
{
    public class LinkedList<Type> : IEnumerable
    {
        private Node _head;
        private Node _tail;
        private Node _sorted = null;

        public Node Head => _head;

        private static int Compare<Type>(Type item1, Type item2)
        {
            var comparableItem = (IComparable)item1;
            return comparableItem.CompareTo(item2);
        }

        public void Push(Type data)
        {
            Node Node = new Node(data);
            if (_head == null)
            {
                _head = Node;
            }
            else
            {
                _tail.Next = Node;
            }
            _tail = Node;
        }

        private void SortedInsert(Node node)
        {
            if (_sorted == null || Compare(_sorted.Data, node.Data) >= 0)
            {
                node.Next = _sorted;
                _sorted = node;
            }
            else
            {
                Node current = _sorted;
                while (current.Next != null && Compare(current.Next.Data, node.Data) < 0)
                {
                    current = current.Next;
                }
                node.Next = current.Next;
                current.Next = node;
            }
        }

        public void InsertionSort()
        {
            Node current = _head;

            while (current != null)
            {
                Node Next = current.Next;
                SortedInsert(current);
                current = Next;
            }

            _head = _sorted;
        }

        private Node Split(Node head)
        {
            Node fast = head, slow = head;

            while (fast.Next != null && fast.Next.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;
            }
            Node temp = slow.Next;
            slow.Next = null;

            return temp;
        }

        public Node MergeSort(Node node)
        {
            if (node == null || node.Next == null)
            {
                return node;
            }

            Node second = Split(node);
            node = MergeSort(node);
            second = MergeSort(second);

            return Merge(node, second);
        }

        private Node Merge(Node first, Node second)
        {
            if (first == null)
            {
                _head = second;
                return second;
            }

            if (second == null)
            {
                _head = first;
                return first;
            }

            if (Compare(first.Data, second.Data) < 0)
            {
                first.Next = Merge(first.Next, second);
                _head = first;
                return first;
            }
            else
            {
                second.Next = Merge(first, second.Next);
                _head = second;
                return second;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            Node current = _head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}
