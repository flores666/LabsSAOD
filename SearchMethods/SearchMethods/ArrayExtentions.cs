namespace SearchMethods
{
    public static class ArrayExtentions
    {
        public static void BubbleSort(this Array array)
        {
            for (var i = array.Length - 1; i > 0; i--)
            {
                for (var j  = 1; j <= i; j++)
                {
                    var element2 = array.GetValue(j - 1);

                    if (Compare(array.GetValue(j), element2) < 0)
                    {
                        array.Swap(j - 1, j);
                    }
                }
            }
        }

        private static void Swap(this Array array, int a, int b)
        {
            var temporary = array.GetValue(a);

            array.SetValue(array.GetValue(b), a);
            array.SetValue(temporary, b);
        }

        private static bool isSameTypeAsArrayElement<Type>(this Array array, Type key)
        {
            return ReferenceEquals(key?.GetType(), array.GetType().GetElementType());
        }

        /// <summary>
        ///     Less than zero – This instance precedes obj in the sort order.
        ///     Zero – This instance occurs in the same position in the sort order as obj.
        ///     Greater than zero – This instance follows obj in the sort order.
        /// </summary>
        private static int Compare(object? item1, object? item2)
        {
            var comparableItem = (IComparable)item1;
            return comparableItem.CompareTo(item2);
        }

        public static void Print(this Array array)
        {
            Console.Write("Array: ");

            if (array.Length == 0)
            {
                Console.Write("null");
                return;
            }

            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
        }

        public static int SequentalSearch<Type>(this Array array, Type key)
        {
            if (!array.isSameTypeAsArrayElement(key))
            {
                throw new ArgumentException("Wrong types");
            }

            var index = 0;

            foreach (var item in array)
            {
                if (Compare(item, key) == 0)
                {
                    return index;
                }

                index++;
            }

            return -1;
        }

        public static int BinarySearch<Type>(this Array array, Type key)
        {
            if (!array.isSameTypeAsArrayElement(key))
            {
                throw new ArgumentException("Wrong types");
            }

            int middleIndex,
                leftIndex = 0,
                rightIndex = array.Length - 1;

            while (leftIndex <= rightIndex)
            {
                middleIndex = (leftIndex + rightIndex) / 2;

                if (Compare(array.GetValue(middleIndex), key) == 0)
                {
                    return middleIndex;
                }

                if (Compare(array.GetValue(middleIndex), key) > 0)
                {
                    rightIndex = middleIndex - 1;
                }
                else
                {
                    leftIndex = middleIndex + 1;
                }
            }

            return -1;
        }

        public static int FibonachiSearch<Type>(this Array array, Type key)
        {
            if (!array.isSameTypeAsArrayElement(key))
            {
                throw new ArgumentException("Wrong types");
            }

            int fibNum1 = 1, fibNum2 = 0;
            var fibSum = fibNum1 + fibNum2;
            
            while (fibSum < array.Length)
            {
                fibNum2 = fibNum1;
                fibNum1 = fibSum;
                fibSum = fibNum1 + fibNum2;
            }
            
            var offset = -1;
            
            while (fibSum > 1)
            {
                var index = Math.Min(offset + fibNum2, array.Length - 1);
                
                if (Compare(array.GetValue(index), key) < 0)
                {
                    fibSum = fibNum1;
                    fibNum1 = fibNum2;
                    fibNum2 = fibSum - fibNum1;
                    offset = index;
                }
                
                else if (Compare(array.GetValue(index), key) > 0)
                {
                    fibSum = fibNum2;
                    fibNum1 = fibNum1 - fibNum2;
                    fibNum2 = fibSum - fibNum1;
                }
                else
                {
                    return index;
                }
            }

            return -1;
        }

    }
}