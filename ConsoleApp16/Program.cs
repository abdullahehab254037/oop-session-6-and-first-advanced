namespace ConsoleApp16
{
    internal class Program
    {
        static void Main(string[] args)
        {
          
        }
    }
    public class Container<T>
    {
        public T item;
        public void add(T value)
        {
            item = value;
        }
        public T get() { return item; }
    }
    public class Pair<TKey, TValue>
    {
        public TKey key;
        public TValue value;
        public Pair(TKey k, TValue v)
        {
            key = k;
            value = v;
        }


    }
}
