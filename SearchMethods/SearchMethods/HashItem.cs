namespace SearchMethods
{
    public class HashItem
    {
        private string key;
        private object? value;

        public string Key => key;
        public object? Value => value;

        public HashItem(string key, object? value)
        {
            this.key = key;
            this.value = value;
        }
    }
}
