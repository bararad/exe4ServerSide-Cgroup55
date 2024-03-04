namespace TarHome1.BL
{
    public class User
    {
        string firstName;
        string familyName;
        string email;
        string password;
        int isAdmin;
        int isActive;

        public User() { }

    
        public User(string firstName, string familyName, string email, string password, int isAdmin, int isActive)
        {
            FirstName = firstName;
            FamilyName = familyName;
            Email = email;
            Password = password;
            IsAdmin = isAdmin;
            IsActive = isActive;
        }

        public string FirstName { get => firstName; set => firstName = value; }
        public string FamilyName { get => familyName; set => familyName = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public int IsAdmin { get => isAdmin; set => isAdmin = value; }
        public int IsActive { get => isActive; set => isActive = value; }


        //Registration
        public int Register()
        {
            DBservices dbs = new DBservices();
            List<User> users = dbs.GetUsers();

            foreach (User u in users)
            {
                if (u.Email==this.Email)
                {
                    return 0;
                }
            }
            return dbs.InsertUser(this);
        }

        //Update
        public int UpdateDetails(string email)
        {
            DBservices dbs = new DBservices();
            return dbs.InsertUpdatedUser(this,email);
        }
        public int AdminUpdateDetails(string email)
        {
            DBservices dbs = new DBservices();
            return dbs.AdminInsertUpdatedUser(this, email);
        }

        //Login
        public User Login()
        {
            DBservices dbs = new DBservices();
            return dbs.GetUserByDetails(this);
        }

        public Object GetReport(int month)
        {
            DBservices dbs = new DBservices();
            return dbs.GetAverageReport(month);
        }

        public List<User> Read()
        {
            DBservices dbs = new DBservices();
            return dbs.GetUsers();
        }

        public int DeleteUser(User user)
        {
            DBservices dbs = new DBservices();
            if (user.Email=="admin@gmail.com")
            {
                return 0;
            }
            return dbs.DeleteUser(user);           
        }


    }
}

