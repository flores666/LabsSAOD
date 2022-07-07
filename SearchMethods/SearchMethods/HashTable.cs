namespace SearchMethods
{
    public class HashTable
    {
        private Dictionary<int, List<HashItem>> _items = null;

        public HashTable()
        {
            _items = new Dictionary<int, List<HashItem>>();
        }

        private int GetHash(string value)
        {
            return value.Length;
        }

        public void Insert<Type>(string key, Type value)
        {
            var item = new HashItem(key, value);
            var hash = GetHash(item.Key);

            List<HashItem> hashTableItem = null;

            if (_items.ContainsKey(hash))
            {
                hashTableItem = _items[hash];

                var elementWithKey = hashTableItem.SingleOrDefault(i => i.Key == item.Key);

                if (elementWithKey != null)
                {
                    throw new ArgumentException("Item with this key is already exists. Key must be uniqe");
                }

                _items[hash].Add(item);
            } 
            else
            {
                hashTableItem = new List<HashItem> { item };
                _items.Add(hash, hashTableItem);
            }
        }

        public string Search(string key)
        {
            var hash = GetHash(key);

            if (!_items.ContainsKey(hash))
            {
                return null;
            }
            var hashTableItem = _items[hash];

            if (hashTableItem != null)
            {
                var item = hashTableItem.SingleOrDefault(i => i.Key == key);

                if (item != null)
                {
                    return item.Value.ToString();
                }
            }

            return null;
        }

        public void PrintTable()
        {
            foreach (var item in _items)
            {
                Console.WriteLine($"Hash: {item.Key}");

                foreach (var value in item.Value)
                {
                    Console.WriteLine($"\t{value.Key} - {value.Value}");
                }
            }
            Console.WriteLine();
        }
    }
}