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
    interface ITrackable
    {
        string GetTrackingStatus();
    }
    interface IInsurable
    {
        decimal CalculateInsurance();
    }
    static class DeliveryUtilities
    {
        public static void PrintSeparator()
        {
            Console.WriteLine("==========================================");
        }

        public static void PrintSystemTitle()
        {
            Console.WriteLine("Delivery Center");
        }
    }
    static class shipmentextensions
    {
        public static string GetSummary(this Shipment s)
        {
            return $"{s.code}||{s.weight}||{s.description}";
        }


    }
    public abstract partial class Shipment : ITrackable, IInsurable
    {
        private string TrackingCode;
        private string Description;
        private int Weight;
        private int DeliveryFee;
        public DeliveryAddress Destination;
        public static int TotalShipmentsCreated;

        public Shipment(string trackingCode, string description, int weight, int deliveryFee, DeliveryAddress destination)
        {
            TrackingCode = trackingCode;
            Description = description;
            Weight = weight;
            DeliveryFee = deliveryFee;
            Destination = destination;
            TotalShipmentsCreated++;

        }
        static Shipment()
        {
            TotalShipmentsCreated = 0;
            Console.WriteLine("Shipment System Initialized");
        }
        public static int GetTotalShipmentsCreated()
        {
            return TotalShipmentsCreated;
        }
        public string TrackingStatus { get; private set; }

        public void UpdateTrackingStatus(string newStatus)
        {
            TrackingStatus = newStatus;

            OnTrackingStatusChanged(newStatus);
        }

        partial void OnTrackingStatusChanged(string newStatus);



        public string code
        {
            get
            {
                return TrackingCode;
            }
            set { if (value != null) { TrackingCode = value; } }
        }



        public string description
        {
            get { return Description; }
            set
            {
                if (value != null) { Description = value; }
            }
        }
        public int weight
        {
            get { return Weight; }
            set { if (value > 0) { Weight = value; } }
        }
        public int deliveryFee
        {
            get { return DeliveryFee; }
            set { if (value > 0) { DeliveryFee = value; } }
        }
        public DeliveryAddress deliveryAddress { get; set; }
        public abstract int EstimatedCost
        {
            get;
        }
        public void UpdateDeliveryFee(int newFee)
        {
            if (newFee > 0)
            {
                DeliveryFee = newFee;
            }
        }
    }
    public abstract partial class Shipment : ITrackable, IInsurable
    {
        public virtual void PrintShipment()
        {
            Console.WriteLine($"tracking code:{TrackingCode},,,,description:{Description},,,,weight:{Weight},,,,delivery fee:{DeliveryFee}");
        }

        public abstract string GetTrackingStatus();

        public abstract decimal CalculateInsurance();


        public Shipment CopyShipment(Shipment copy)
        {
            return this;
        }
        public Shipment ShallowCopy()
        {
            return (Shipment)this.MemberwiseClone();
        }
        public Shipment DeepCopy(Shipment copy)
        {

            copy.deliveryFee = this.deliveryFee;
            copy.code = this.code;
            copy.description = this.description;
            copy.weight = this.weight;
            copy.Destination = new DeliveryAddress(this.Destination.city, this.Destination.street, this.Destination.BuildingNumber);
            return copy;
        }
        partial void OnTrackingStatusChanged(string newStatus)
        {
            Console.WriteLine($"Tracking status changed to: {newStatus}");
        }



        public Shipment(string trackingCode)
        {
            this.TrackingCode = trackingCode;
            Description = "Unknown";
            Weight = 1;
            DeliveryFee = 50;
            Destination = default;
        }

    }
    public class DeliveryCenter
    {
        private Shipment[] shipments;
        private int count;
        public int Capacity = 3;
        public DeliveryCenter()
        {
            shipments = new Shipment[Capacity];
            count = 0;
        }
        public Shipment this[int index]
        {
            get
            {
                if (index < 0 || index >= Capacity)
                    return null;
                return shipments[index];
            }
            set
            {
                if (index < 0 || index >= Capacity)
                    return;

                shipments[index] = value;
                count++;
            }
        }
        public void PrintShipmentITrackableshipment()
        {
            foreach (Shipment s in shipments)
            {
                Console.WriteLine(s.GetTrackingStatus);
            }
        }
        public void PrintInsuranceIInsurableshipment()
        {
            foreach (Shipment s in shipments)
            {
                Console.WriteLine(s.CalculateInsurance);
            }
        }
        public Shipment this[string trackingCode]
        {
            get
            {
                for (int i = 0; i < Capacity; i++)
                {
                    if (shipments[i].code == trackingCode)
                        return shipments[i];
                }
                return null;
            }
        }

        public bool AddShipment(Shipment shipment)
        {
            for (int i = 0; i < Capacity; i++)
            {

                if (shipments[i] == null)
                {
                    shipments[i] = shipment;
                    return true;
                }
            }
            return false;
        }
        public void printallshipments()
        {
            foreach (Shipment s in shipments)
            {
                s.PrintShipment();
            }
        }


    }
}
