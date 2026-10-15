namespace ConsoleApp16
{
    internal class Program
    {
        static void Main(string[] args)
        {
           // DeliveryCenter deliveryCenter = new DeliveryCenter();
           // for (int i = 0; i < 3; i++)
           // {
           //     Console.WriteLine("enter city");
           //     string city = Console.ReadLine();
           //     Console.WriteLine("enter street");
           //     string street = Console.ReadLine();
           //     Console.WriteLine("enter building number");
           //     int buldingnum = Convert.ToInt32(Console.ReadLine());
           //     DeliveryAddress deliveryAddress = new DeliveryAddress(city, street, buldingnum);
           //     Console.WriteLine("enter code");
           //     string code = Console.ReadLine();
           //     Console.WriteLine("enter descr");
           //     string descr = Console.ReadLine();
           //     Console.WriteLine("enter weight");
           //     int weight = Convert.ToInt32(Console.ReadLine());
           //     Console.WriteLine("enter fee");
           //     int fee = Convert.ToInt32(Console.ReadLine());
           //     if (i == 0)
           //     {
           //         StandardShipment standard = new StandardShipment(code, descr, weight, fee, deliveryAddress);
           //         deliveryCenter[i] = standard;
           //     }
           //     if (i == 1)
           //     {
           //         Console.WriteLine("enter extra fee");
           //         int extrafee = Convert.ToInt32(Console.ReadLine());
           //         ExpressShipment express = new ExpressShipment(code, descr, weight, fee, deliveryAddress, extrafee);
           //         deliveryCenter[i] = express;
           //     }
           //     if (i == 2)
           //     {
           //         Console.WriteLine("enter custom fee");
           //         int customfee = Convert.ToInt32(Console.ReadLine());
           //         string dest = Console.ReadLine();
           //         InternationalShipment international = new InternationalShipment(code, descr, weight, fee, deliveryAddress, dest, customfee);
           //         deliveryCenter[i] = international;
           //
           //     }
           //
           //
           //     // deliveryCenter.AddShipment(shipment);
           // }
           // for (int i = 0; i < 3; i++)
           // {
           //     deliveryCenter[i].PrintShipment();
           // }
           // deliveryCenter.printallshipments();
           // deliveryCenter.PrintInsuranceIInsurableshipment();
           // deliveryCenter.PrintShipmentITrackableshipment();
           // decimal[] IInsurable = new decimal[deliveryCenter.Capacity];
           // string[] ITrackable = new string[deliveryCenter.Capacity];
           // for (int i = 0; i < deliveryCenter.Capacity; i++)
           // {
           //     IInsurable[i] = deliveryCenter[i].CalculateInsurance();
           // }
           // for (int i = 0; i < deliveryCenter.Capacity; i++)
           // {
           //     ITrackable[i] = deliveryCenter[i].GetTrackingStatus();
           // }
           // for (int i = 0; i < IInsurable.Length; i++)
           // {
           //     Console.WriteLine(IInsurable[i]);
           // }
           // for (int i = 0; i < ITrackable.Length; i++)
           // {
           //     Console.WriteLine(ITrackable[i]);
           // }
           // Shipment s1 = new StandardShipment("sh01", "good", 44, 50, new DeliveryAddress("giza", "street1", 10));
           // Shipment s2 = s1.ShallowCopy();
           // s2.Destination.city = "cairo";//value will be changed in the two shipment
           // Shipment s3 = new StandardShipment("sh03", "bad", 40, 55, new DeliveryAddress("alex", "street44", 70));
           // s3 = s1.DeepCopy(s3);
           // s3.Destination.city = "cairo";//value will be changed in the s3 only
           // Console.WriteLine(Shipment.GetTotalShipmentsCreated());
           // s3.GetSummary();
           // DeliveryUtilities.PrintSeparator();
           // DeliveryUtilities.PrintSystemTitle();
           // DeliveryUtilities.PrintSeparator();
            // generic class is class that can handle any refrence or value type
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
    public class StandardShipment : Shipment, IInsurable, ITrackable
    {
        public StandardShipment(string trackingCode, string description, int weight, int deliveryFee, DeliveryAddress destination) : base(trackingCode, description, weight, deliveryFee, destination)
        {

        }


        public override int EstimatedCost
        {
            get { return base.deliveryFee + (base.weight * 5); }
        }

        public override decimal CalculateInsurance()
        {
            return (this.EstimatedCost * (5 / 10));
        }

        public override string GetTrackingStatus()
        {
            return (this.code + "is ready");
        }

        public override void PrintShipment()
        {
            base.PrintShipment();
            Console.WriteLine($"estimated:{this.EstimatedCost}");
        }


    }
    public class ExpressShipment : Shipment, IInsurable, ITrackable
    {
        private int ExtraFee;
        public ExpressShipment(string trackingCode, string description, int weight, int deliveryFee, DeliveryAddress destination, int extrafee) : base(trackingCode, description, weight, deliveryFee, destination)
        {
            ExtraFee = extrafee;
        }
        public int extrafee
        {
            get { return ExtraFee; }
            set { if (extrafee > 0) { ExtraFee = value; } }
        }
        //public decimal EstimatedCost
        //{
        //    get { return this.EstimatedCost + ExtraFee; }
        //}
        public override int EstimatedCost
        {
            get { return base.deliveryFee + (base.weight * 5) + ExtraFee; }
        }
        public override decimal CalculateInsurance()
        {
            return (this.EstimatedCost * (8 / 10));
        }

        public override string GetTrackingStatus()
        {
            return (this.code + "out of delivery");
        }
        public override void PrintShipment()
        {
            base.PrintShipment();
            Console.WriteLine($"estimated:{this.EstimatedCost},,,,esxtrafee:{ExtraFee}");
        }
    }


    public class InternationalShipment : Shipment, IInsurable, ITrackable
    {
        private int CustomsFee;
        private string DestinationCountry;
        public InternationalShipment(string trackingCode, string description, int weight, int deliveryFee, DeliveryAddress destination, string destinationCountry,
            int customsFee) : base(trackingCode, description, weight, deliveryFee, destination)
        {
            DestinationCountry = destinationCountry;
            CustomsFee = customsFee;
        }
        public string destinationCountry
        {
            get { return DestinationCountry; }
            set
            {
                if (value != null) { DestinationCountry = value; }
            }
        }
        public override decimal CalculateInsurance()
        {
            return (this.EstimatedCost * (12 / 10));
        }

        public override string GetTrackingStatus()
        {
            return (this.code + "has been Delivered.");
        }
        public int customsFee
        {
            get { return CustomsFee; }
            set
            {
                if (value > 0)
                {
                    CustomsFee = value;
                }
            }
        }
        //public decimal EstimatedCost
        //{
        //    get { return this.EstimatedCost + CustomsFee; }
        //}
        public override int EstimatedCost
        {
            get { return base.deliveryFee + (base.weight * 5); }
        }
        public override void PrintShipment()
        {
            base.PrintShipment();
            Console.WriteLine($"estimated:{this.EstimatedCost},,,,customfee:{CustomsFee},,,,country:{DestinationCountry}");
        }
    }
}
