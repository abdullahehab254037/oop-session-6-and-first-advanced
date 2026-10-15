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
    public struct DeliveryAddress
    {
        public string city;
        public string street;
        public int BuildingNumber;
        public DeliveryAddress(string city, string street, int buildingNumber)
        {
            this.city = city;
            this.street = street;
            BuildingNumber = buildingNumber;
        }
        public string GetFullAddress()
        {
            return $"{BuildingNumber} {street}, {city}";
        }
    }
}
