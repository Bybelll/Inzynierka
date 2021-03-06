using MySqlConnector;
using System;
using System.Text;
using System.Collections.Generic;
using Inzynierka.Component;
using System.Security.Cryptography;

namespace Inzynierka
{
    class DBConnect
    {
        private MySqlConnection connection;

        //Constructor
        public DBConnect()
        {
            Initialize();
        }

       
        private void Initialize()
        {

            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
            {
                Server = "db4free.net",
                UserID = "bybell",
                Password = "ZAQ!2wsx",
                Database = "inzynierka",
            };

            try
            {
                connection = new MySqlConnection(builder.ConnectionString);                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        private string GetHash(string input)
        {
            SHA256 sha256Hash = SHA256.Create();
            byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            var sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        public bool InsertUsers(string name,string surname,int age,byte status,string login,string password)
        {
            string passwordHashed = GetHash(password);
            string query = "INSERT INTO Users (ID,Name,Surname,Age,Status,Login,Password) VALUES" +
                "(NULL,'"+name+"','"+surname+"','"+age+"','"+status+"','"+login+"','"+passwordHashed+"')";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
                return true;
            }
            else { return false; }
        }

        public void InsertVehicles(string type,double cost,byte availability,byte damage,double latitude, double longitude)
        {
            string query = "INSERT INTO Vehicles (ID,Type, Cost, Availability, Damage, Latitude, Longitude ) VALUES" +
                "(NULL,'"+type+"','" + cost + "','" +availability + "','" +damage + "','" +latitude + "','" +longitude+"')";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }
        
        public void InsertRental(int usersID, int vehiclesID, string rentalTime,string returnTime, double startPointLatitude,double startPointLonditude, double finishPointLatitude, double finishPointLongitude, double totalCost )
        {
            //for RentalTime and Return time use function DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            
            string query = "INSERT INTO Rental (ID, UsersID, VehiclesID, RentalTime, ReturnTime, StartingPointLatitute, StartingPointLongitute, FinishPointLatitute, FinishPointLongitute, TotalCost ) VALUES" +
              "(NULL,'" + usersID + "','" + vehiclesID + "','" + rentalTime + "','" + returnTime + "','" + startPointLatitude + "','" + startPointLonditude + "','" + finishPointLatitude + "','" + finishPointLongitude + "','" + totalCost+"')";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Update statement
        public void Update()
        {
            //string query = "UPDATE tableinfo SET name='Joe', age='22' WHERE name='John Smith'";

            ////Open connection
            //if (this.OpenConnection() == true)
            //{
            //    //create mysql command
            //    MySqlCommand cmd = new MySqlCommand();
            //    //Assign the query using CommandText
            //    cmd.CommandText = query;
            //    //Assign the connection using Connection
            //    cmd.Connection = connection;

            //    //Execute query
            //    cmd.ExecuteNonQuery();

            //    //close connection
            //    this.CloseConnection();
            //}
        }

        //Delete statement
        public void DeleteUsers(string login)
        {
            string query = "DELETE FROM Users WHERE Login =" + login;

            //if (this.OpenConnection() == true)
            //{
            //    MySqlCommand cmd = new MySqlCommand(query, connection);
            //    cmd.ExecuteNonQuery();
            //    this.CloseConnection();
            //}
        }

        //Select statement
        public List<Vehicle> Select()
        {
            string query = "SELECT * FROM Vehicles";

            //Create a list to store the result
            List<Vehicle> list = new List<Vehicle>();


            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                   Vehicle vehicle = new Vehicle(dataReader.GetInt32("ID"), dataReader.GetString("Type"),dataReader.GetDouble("Cost"), dataReader.GetByte("Availability"), dataReader.GetByte("Damage"),dataReader.GetDouble("Latitude"), dataReader.GetDouble("Longitude"));
                    list.Add(vehicle);

                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }
    }

}