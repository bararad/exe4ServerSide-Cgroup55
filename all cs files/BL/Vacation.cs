namespace TarHome1.BL
{
    public class Vacation
    {
        string id;
        string userid;
        string flatid;
        DateTime startdate;
        DateTime enddate;
              

        public Vacation(string id, string userid, string flatid, DateTime startdate, DateTime enddate)
        {
            Id = id;
            Userid = userid;
            Flatid = flatid;
            Startdate = startdate;
            Enddate = enddate;
        }
        public Vacation() { }

        public string Id { get => id; set => id = value; }
        public string Userid { get => userid; set => userid = value; }
        public string Flatid
        {
            get => flatid;
            set => flatid= value;
        }
        public DateTime Startdate { get => startdate; set => startdate = value; }
        public DateTime Enddate
        {
            get => enddate; 
            set
            {
                if (Startdate<value)
                {
                    enddate = value;
                }
                else
                {
                    enddate = DateTime.MinValue;
                }
            } 
        }

        public int Insert()
        {
            DBservices dbs = new DBservices();
            List <Vacation> vacationList = Read();

            foreach (var v in vacationList)
            {
                if (this.flatid == v.Flatid)
                {
                    if (this.startdate > v.enddate || this.enddate < v.startdate)
                    {
                        continue;
                    }
                    return 0;
                }
            }

            return dbs.InsertVacation(this);

        }

        public static List<Vacation> Read()
        {
            DBservices dbs = new DBservices();
            return dbs.GetVacation();
        }

        public List <Vacation> ReadByUserEmail(string email)
        {
            DBservices dbs = new DBservices();
            return dbs.GetVacationByEmail(email);
        }

    }
}
