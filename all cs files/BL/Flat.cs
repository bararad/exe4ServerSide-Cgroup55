namespace TarHome1.BL
{
    public class Flat
    {

        string id;
        string city;
        string address;
        double price;
        int numofRooms;
     

        public Flat(string id, string city, string address, double price, int numofRooms)
        {
            Id = id;
            City = city;
            Address = address;
            NumofRooms = numofRooms;
            Price = price;
            
        }
        public Flat() { }

        public string Id { get => id; set => id = value; }
        public string City { get => city; set => city = value; }
        public string Address { get => address; set => address = value; }
        public int NumofRooms { get => numofRooms; set => numofRooms = value; }
        public double Price { get => price; set { price=Discount(value, NumofRooms); } }
        
      

        public int Insert()
        {
            DBservices dbs= new DBservices();
            return dbs.InsertFlat(this);
        }
        public static List<Flat> Read()
        {
            DBservices dbs = new DBservices();
            return dbs.GetFlat();
        }

        public double Discount(double price,int noOfrooms)
        {
            if (price>100 && noOfrooms> 1)
            {
                return price * 0.9;
            }
            return price;
        }
        

    }
}
