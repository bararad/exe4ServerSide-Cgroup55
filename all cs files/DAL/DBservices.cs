using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using TarHome1.BL;
//using RuppinProj.Models;

/// <summary>
/// DBServices is a class created by me to provides some DataBase Services
/// </summary>
public class DBservices
{

    public DBservices()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //--------------------------------------------------------------------------------------------------
    // This method creates a connection to the database according to the connectionString name in the web.config 
    //--------------------------------------------------------------------------------------------------
    public SqlConnection connect(String conString)
    {

        // read the connection string from the configuration file
        IConfigurationRoot configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json").Build();
        string cStr = configuration.GetConnectionString("myProjDB");
        SqlConnection con = new SqlConnection(cStr);
        con.Open();
        return con;
    }

    //--------------------------------------------------------------------------------------------------
    // This method Inserts a flat to the flat table 
    //--------------------------------------------------------------------------------------------------
    public int InsertFlat(Flat flat)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateFlatInsertCommandWithStoredProcedure("SPInsertFlat", con, flat);        // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //--------------------------------------------------------------------------------------------------
    // This method Inserts a vacation to the vacation table 
    //--------------------------------------------------------------------------------------------------
    public int InsertVacation(Vacation vacation)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateVacationInsertCommandWithStoredProcedure("SPInsertVacation", con, vacation);        // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //--------------------------------------------------------------------------------------------------
    // This method Inserts a user to the user table 
    //--------------------------------------------------------------------------------------------------
    public int InsertUser(User user)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateUserInsertCommandWithStoredProcedure("SPInsertUser", con, user);        // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //--------------------------------------------------------------------------------------------------
    // This method Updates a user to the user table (by user)
    //--------------------------------------------------------------------------------------------------
    public int InsertUpdatedUser(User user, String useremail)
    {
        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = UpdateUserInsertCommandWithStoredProcedure("SPUpdateUser", con, user, useremail);        // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }


    //--------------------------------------------------------------------------------------------------
    // This method Updates a user to the user table (by Admin)
    //--------------------------------------------------------------------------------------------------
    public int AdminInsertUpdatedUser(User user, String useremail)
    {
        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = AdminUpdateUserInsertCommandWithStoredProcedure("SPAdminUpdateUser", con, user, useremail);        // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }
    //--------------------------------------------------------------------------------------------------
    // This method reads flats from the database 
    //--------------------------------------------------------------------------------------------------
    public List<Flat> GetFlat()
    {

        SqlConnection con;
        SqlCommand cmd;
        List<Flat> flatsList = new List<Flat>();

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithSPWithoutParameters("spGetFlat", con);// create the command

        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                Flat f = new Flat();
                f.Id = dataReader["id"].ToString();
                f.City = dataReader["city"].ToString();
                f.Address = dataReader["address"].ToString();
                f.Price = Convert.ToDouble(dataReader["price"]);
                f.NumofRooms = Convert.ToInt32(dataReader["numOfRooms"]);

                flatsList.Add(f);
            }
            return flatsList;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //--------------------------------------------------------------------------------------------------
    // This method reads vacations from the database 
    //--------------------------------------------------------------------------------------------------
    public List<Vacation> GetVacation()
    {

        SqlConnection con;
        SqlCommand cmd;
        List<Vacation> vacationsList = new List<Vacation>();

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithSPWithoutParameters("spGetVacation", con);             // create the command

        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                Vacation v = new Vacation();
                v.Id = (dataReader["vacaId"]).ToString();
                v.Userid = (dataReader["userEmail"]).ToString();
                v.Flatid = (dataReader["flatId"]).ToString();
                v.Startdate = DateTime.Parse(dataReader["startdate"].ToString());
                v.Enddate = DateTime.Parse(dataReader["enddate"].ToString());
                vacationsList.Add(v);
            }
            return vacationsList;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }


    //--------------------------------------------------------------------------------------------------
    // This method reads vacations of specific user from the database (read with parameters)
    //--------------------------------------------------------------------------------------------------
    public List<Vacation> GetVacationByEmail(string email)
    {

        SqlConnection con;
        SqlCommand cmd;
        List<Vacation> vacationsList = new List<Vacation>();

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithSPWithParametersVaca("spGetVacaByEamil", con, email);  // create the command


        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                Vacation v = new Vacation();
                v.Id = (dataReader["vacaId"]).ToString();
                v.Userid = (dataReader["userEmail"]).ToString();
                v.Flatid = (dataReader["flatId"]).ToString();
                v.Startdate = DateTime.Parse(dataReader["startdate"].ToString());
                v.Enddate = DateTime.Parse(dataReader["enddate"].ToString());
                vacationsList.Add(v);
            }
            return vacationsList;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }


    }

    //--------------------------------------------------------------------------------------------------
    // This method gets vacations report from the database (read with parameters)
    //--------------------------------------------------------------------------------------------------

    public List<object> GetAverageReport(int month)
    {

        SqlConnection con;
        SqlCommand cmd;
        List<object> listObjs = new List<object>();

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithSPWithParametersReport("spGetVacaReport", con, month);  // create the command


        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                string city = dataReader["City"].ToString();
                double averagePricePerNight = Convert.ToDouble(dataReader["AveragePricePerNight"]);
                // Create an object or data structure to hold the result
                var result = new { City = city, AveragePricePerNight = averagePricePerNight };

                // Add the result to the list
                listObjs.Add(result);
            }
            return listObjs;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }


    //--------------------------------------------------------------------------------------------------
    // This method reads users from the database 
    //--------------------------------------------------------------------------------------------------
    public List<User> GetUsers()
    {

        SqlConnection con;
        SqlCommand cmd;
        List<User> usersList = new List<User>();

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithSPWithoutParameters("spGetUsers", con);             // create the command

        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dataReader.Read())
            {
                User u = new User();
                u.FirstName = (dataReader["firstName"]).ToString();
                u.FamilyName = (dataReader["familyName"]).ToString();
                u.Email = (dataReader["email"].ToString());
                u.Password = (dataReader["password"].ToString());
                u.IsAdmin = Convert.ToInt32(dataReader["isAdmin"]);
                u.IsActive = Convert.ToInt32(dataReader["isActive"]);
                usersList.Add(u);
            }
            return usersList;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //---------------------------------------------------------------------------------
    // Get User SqlCommand using a stored procedure
    //---------------------------------------------------------------------------------

    public User GetUserByDetails(User user)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = CreateCommandWithSPWithParameters("spGetUserByDetails", con, user);  // create the command


        try
        {
            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            User u = new User();
            while (dataReader.Read())
            {
                u.FirstName = (dataReader["firstName"]).ToString();
                u.FamilyName = (dataReader["familyName"]).ToString();
                u.Email = (dataReader["email"].ToString());
                u.Password = (dataReader["password"].ToString());
                u.IsAdmin = Convert.ToInt32(dataReader["isAdmin"]);
                u.IsActive = Convert.ToInt32(dataReader["isActive"]);
            }
            return u;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //---------------------------------------------------------------------------------
    // Delete User with SqlCommand using a stored procedure
    //---------------------------------------------------------------------------------
    public int DeleteUser(User user)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("myProjDB"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        cmd = DeleteUserInsertCommandWithStoredProcedure("SPDeleteUser", con, user);        // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //---------------------------------------------------------------------------------
    // Create Flat SqlCommand using a stored procedure
    //---------------------------------------------------------------------------------

    private SqlCommand CreateFlatInsertCommandWithStoredProcedure(String spName, SqlConnection con, Flat flat)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        cmd.Parameters.AddWithValue("@city", flat.City);

        cmd.Parameters.AddWithValue("@address", flat.Address);

        cmd.Parameters.AddWithValue("@price", flat.Price);

        cmd.Parameters.AddWithValue("@numofRooms", flat.NumofRooms);

        return cmd;
    }

    //---------------------------------------------------------------------------------
    // Create Vacation SqlCommand using a stored procedure
    //---------------------------------------------------------------------------------
    private SqlCommand CreateVacationInsertCommandWithStoredProcedure(String spName, SqlConnection con, Vacation vacation)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        cmd.Parameters.AddWithValue("@startdate", vacation.Startdate);

        cmd.Parameters.AddWithValue("@enddate", vacation.Enddate);

        cmd.Parameters.AddWithValue("@flatId", vacation.Flatid);

        cmd.Parameters.AddWithValue("@userEmail", vacation.Userid);

        return cmd;
    }

    //---------------------------------------------------------------------------------
    // Create User SqlCommand using a stored procedure
    //---------------------------------------------------------------------------------
    private SqlCommand CreateUserInsertCommandWithStoredProcedure(String spName, SqlConnection con, User user)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        cmd.Parameters.AddWithValue("@email", user.Email);

        cmd.Parameters.AddWithValue("@firstName", user.FirstName);

        cmd.Parameters.AddWithValue("@familyName", user.FamilyName);

        cmd.Parameters.AddWithValue("@password", user.Password);

        cmd.Parameters.AddWithValue("@isAdmin", user.IsAdmin);

        cmd.Parameters.AddWithValue("@isActive", user.IsActive);

        return cmd;
    }

    //---------------------------------------------------------------------------------
    // Delete User SqlCommand using a stored procedure
    //---------------------------------------------------------------------------------
    private SqlCommand DeleteUserInsertCommandWithStoredProcedure(String spName, SqlConnection con, User user)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        cmd.Parameters.AddWithValue("@email", user.Email);

        return cmd;
    }

    //---------------------------------------------------------------------------------
    // Create the SqlCommand using a stored procedure
    //---------------------------------------------------------------------------------

    private SqlCommand UpdateUserInsertCommandWithStoredProcedure(String spName, SqlConnection con, User user, String useremail)
    {
        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        cmd.Parameters.AddWithValue("@email", useremail);

        cmd.Parameters.AddWithValue("@firstName", user.FirstName);

        cmd.Parameters.AddWithValue("@familyName", user.FamilyName);

        cmd.Parameters.AddWithValue("@password", user.Password);


        return cmd;
    }

    private SqlCommand AdminUpdateUserInsertCommandWithStoredProcedure(String spName, SqlConnection con, User user, String useremail)
    {
        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        cmd.Parameters.AddWithValue("@email", useremail);

        cmd.Parameters.AddWithValue("@firstName", user.FirstName);

        cmd.Parameters.AddWithValue("@familyName", user.FamilyName);

        cmd.Parameters.AddWithValue("@password", user.Password);

        cmd.Parameters.AddWithValue("@isAdmin", user.IsAdmin);

        cmd.Parameters.AddWithValue("@isActive", user.IsActive);

        return cmd;
    }
    private SqlCommand CreateCommandWithSPWithoutParameters(String spName, SqlConnection con)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        return cmd;
    }

    private SqlCommand CreateCommandWithSPWithParameters(String spName, SqlConnection con, User user)
    {
        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        cmd.Parameters.AddWithValue("@email", user.Email);

        cmd.Parameters.AddWithValue("@password", user.Password);

        return cmd;
    }

    private SqlCommand CreateCommandWithSPWithParametersVaca(String spName, SqlConnection con, string email)
    {
        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        cmd.Parameters.AddWithValue("@email", email);

        return cmd;
    }

    //Create Command for Report

    private SqlCommand CreateCommandWithSPWithParametersReport(String spName, SqlConnection con, int month)
    {
        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = spName;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.StoredProcedure; // the type of the command, can also be text

        cmd.Parameters.AddWithValue("@month", month);

        return cmd;
    }


}
