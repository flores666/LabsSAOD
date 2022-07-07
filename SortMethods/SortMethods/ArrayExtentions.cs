namespace SortMethods
{
    public static class ArrayExtentions
    {

        private static int Compare(object? item1, object? item2)
        {
            var comparableItem = (IComparable)item1;
            return comparableItem.CompareTo(item2);
        }

        public static void Print(this Array array)
        {
            Console.Write("Array: ");

            foreach (var item in array)
            {
                Console.Write(item.ToString() + " ");
            }
        }

        private static void Swap(this Array array, int index1, int index2)
        {
            var temporary = array.GetValue(index1);

            array.SetValue(array.GetValue(index2), index1);
            array.SetValue(temporary, index2);
        }

        public static void ShellSort(this Array array)
        {
            var step = array.Length / 2;

            while (step > 0)
            {
                for (int i = step; i < array.Length; i++)
                {
                    var value = array.GetValue(i);
                    int j;

                    for (j = i - step; (j >= 0) && (Compare(array.GetValue(j), value) > 0); j -= step)
                    {
                        array.SetValue(array.GetValue(j), j + step);
                    }

                    array.SetValue(value, j + step);
                }

                step /= 2;
            }
        }

        public static void RadixSort(this int[] array)
        {
            var arraySize = array.Length;
            var tempArray = new int[arraySize];

            var numOfBits = 4;
            var numOfBitsOfInt = 32;

            var countArr = new int[1 << numOfBits];
            var prefix = new int[1 << numOfBits];

            var numOfGroups = (int)Math.Ceiling((double)numOfBitsOfInt / (double)numOfBits);
            var mask = (1 << numOfBits) - 1;

            for (int c = 0, shift = 0; c < numOfGroups; c++, shift += numOfBits)
            {
                for (int j = 0; j < countArr.Length; j++)
                {
                    countArr[j] = 0;
                }

                for (int i = 0; i < arraySize; i++)
                {
                    countArr[(array[i] >> shift) & mask]++;
                }

                prefix[0] = 0;
                for (int i = 1; i < countArr.Length; i++)
                {
                    prefix[i] = prefix[i - 1] + countArr[i - 1];
                }

                for (int i = 0; i < arraySize; i++)
                {
                    tempArray[prefix[(array[i] >> shift) & mask]++] = array[i];
                }

                tempArray.CopyTo(array, 0);
            }
        }

        public static void QuickSort(this Array array, int startIndex = 0, int endIndex = -1)
        {
            if (endIndex < 0)
            {
                endIndex = array.Length - 1;
            }

            if (startIndex >= endIndex)
            {
                return;
            }

            var middleIndex = (endIndex - startIndex) / 2 + startIndex;
            var currentIndex = startIndex;

            array.Swap(startIndex, middleIndex);

            for (int i = startIndex + 1; i <= endIndex; ++i)
            {
                if (Compare(array.GetValue(i), array.GetValue(startIndex)) <= 0)
                {
                    array.Swap(++currentIndex, i);
                }
            }

            array.Swap(startIndex, currentIndex);

            QuickSort(array, startIndex, currentIndex - 1);
            QuickSort(array, currentIndex + 1, endIndex);
        }

        public static void HeapSort(this Array array)
        {
            for (int i = array.Length / 2 - 1; i >= 0; i--)
            {
                array.Heapify(array.Length, i);
            }
            for (int i = array.Length - 1; i >= 0; i--)
            {
                array.Swap(0, i);

                array.Heapify(i, 0);
            }
        }

        private static void Heapify(this Array array, int heapSize, int root)
        {
            int largest = root;

            int left = 2 * root + 1;
            int right = 2 * root + 2;

            if (left < heapSize && Compare(array.GetValue(left), array.GetValue(largest)) > 0)
            {
                largest = left;
            }

            if (right < heapSize && Compare(array.GetValue(right), array.GetValue(largest)) > 0)
            {
                largest = right;
            }

            if (largest != root)
            {
                array.Swap(root, largest);
                array.Heapify(heapSize, largest);
            }
        }

        public static void CountSort(this int[] array)
        {
            var max = array.Max();
            var min = array.Min();

            int[] countArr = new int[max - min + 1];

            for (int i = 0; i < countArr.Length; i++)
            {
                countArr[i] = 0;
            }

            for (int i = 0; i < array.Length; i++)
            {
                countArr[array[i] - min]++;
            }

            var index = 0;
            for (int i = min; i <= max; i++)
            {
                while (countArr[i - min]-- > 0)
                {
                    array[index] = i;
                    array.SetValue(i, index);
                    index++;
                }
            }
        }

        private static void Merge(this Array array, int left, int mid, int right)
        {
            var temp = Array.CreateInstance(array.GetType().GetElementType(), array.Length);

            int leftEnd = (mid - 1);
            int tmpPosition = left;
            int numOfElements = (right - left + 1);

            while ((left <= leftEnd) && (mid <= right))
            {
                if (Compare(array.GetValue(left), array.GetValue(mid)) <= 0)
                {
                    temp.SetValue(array.GetValue(left++), tmpPosition++);
                }
                else
                {
                    temp.SetValue(array.GetValue(mid++), tmpPosition++);

                }
            }

            while (left <= leftEnd)
            {
                temp.SetValue(array.GetValue(left++), tmpPosition++);
            }

            while (mid <= right)
            {
                temp.SetValue(array.GetValue(mid++), tmpPosition++);
            }

            for (int i = 0; i < numOfElements; i++)
            {
                array.SetValue(temp.GetValue(right), right);
                right--;
            }
        }

        public static void MergeSort(this Array array, int left = 0, int right = -1)
        {
            if (right < 0)
            {
                right = array.Length - 1;
            }

            if (right > left)
            {
                int mid = (right + left) / 2;
                array. MergeSort(left, mid);
                array.MergeSort(mid + 1, right);

                array.Merge(left, mid + 1, right);
            }
        }
    }
}