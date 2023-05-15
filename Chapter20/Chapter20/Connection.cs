using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;

namespace Chapter20
{
    public class Inventory
    {
        private readonly string _connectionString;
        public Inventory() : this(
        @"Data Source=localhost\sqlexpress; Initial Catalog=AdvProg; Integrated Security =True; Trust Server Certificate=True;")
        {
        }
        public Inventory(string connectionString)
        => _connectionString = connectionString;

        private SqlConnection _sqlConnection = null;
        private void OpenConnection()
        {
            _sqlConnection = new SqlConnection
            {
                ConnectionString = _connectionString
            };
            _sqlConnection.Open();
        }
        private void CloseConnection()
        {
            if (_sqlConnection?.State != ConnectionState.Closed)
            {
                _sqlConnection?.Close();
            }
        }
        public List<CarViewModel> GetAllInventory()
        {
            OpenConnection();
            // This will hold the records.
            List<CarViewModel> inventory = new List<CarViewModel>();
            // Prep command object.
            string sql =
            @"SELECT i.Id, i.Color, i.PetName,m.Name as Make
                FROM Inventory i
            INNER JOIN Makes m on m.Id = i.MakeId";
            using SqlCommand command =
            new SqlCommand(sql, _sqlConnection)
            {
                CommandType = CommandType.Text
            };
            command.CommandType = CommandType.Text;
            SqlDataReader dataReader =
            command.ExecuteReader(CommandBehavior.CloseConnection);
            while (dataReader.Read())
            {
                inventory.Add(new CarViewModel
                {
                    Id = (int)dataReader["Id"],
                    Color = (string)dataReader["Color"],
                    Make = (string)dataReader["Make"],
                    PetName = (string)dataReader["PetName"]
                });
            }
            dataReader.Close();
            return inventory;
        }

        public CarViewModel GetCar(int id)
        {
            OpenConnection();
            CarViewModel car = null;
            //This should use parameters for security reasons
            string sql =
            $@"SELECT i.Id, i.Color, i.PetName,m.Name as Make
                FROM Inventory i
                INNER JOIN Makes m on m.Id = i.MakeId
                WHERE i.Id = {id}";
            using SqlCommand command =
            new SqlCommand(sql, _sqlConnection)
            {
                CommandType = CommandType.Text
            };
            SqlDataReader dataReader =
            command.ExecuteReader(CommandBehavior.CloseConnection);
            while (dataReader.Read())
            {
                car = new CarViewModel
                {
                    Id = (int)dataReader["Id"],
                    Color = (string)dataReader["Color"],
                    Make = (string)dataReader["Make"],
                    PetName = (string)dataReader["PetName"]
                };
            }
            dataReader.Close();
            return car;
        }

        public void InsertAuto(string color, int makeId, string petName)
        {
            OpenConnection();
            // Format and execute SQL statement.
            string sql = $"Insert Into Inventory (MakeId, Color, PetName) Values ('{makeId}', '{color}', '{petName}')";
            // Execute using our connection.
            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }
            CloseConnection();
        }
        public void InsertAuto(Car car)
        {
            OpenConnection();
            // Format and execute SQL statement.
            string sql = "Insert Into Inventory (MakeId, Color, PetName) Values " +
            $"('{car.MakeId}', '{car.Color}', '{car.PetName}')";
            // Execute using our connection.
            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.CommandType = CommandType.Text;
                command.ExecuteNonQuery();
            }
            CloseConnection();
        }
        public void DeleteCar(int id)
        {
            OpenConnection();
            // Get ID of car to delete, then do so.
            string sql = $"Delete from Inventory where Id = '{id}'";
            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                try
                {
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception("Sorry! That car is on order!", ex);
                    throw error;
                }
            }
            CloseConnection();
        }

        public void UpdateCarPetName(int id, string newPetName)
        {
            OpenConnection();
            // Get ID of car to modify the pet name.
            string sql = $"Update Inventory Set PetName = '{newPetName}' Where Id = '{id}'";
            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.ExecuteNonQuery();
            }
            CloseConnection();
        }

        public string LookUpInventory(int Id)
        {
            OpenConnection();
            string carPetName;
            // Establish name of stored proc.
            using (SqlCommand command = new SqlCommand("GetPetName", _sqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter
                {
                    // Input param.
                    ParameterName = "@carId",
                    SqlDbType = SqlDbType.Int,
                    Value = Id,
                    Direction = ParameterDirection.Input
                };

                command.Parameters.Add(parameter);
                // Output param.
                parameter = new SqlParameter
                {
                    ParameterName = "@petName",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50,
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(parameter);
                // Execute the stored proc.
                command.ExecuteNonQuery();
                // Return output param.
                carPetName = (string)command.Parameters["@petName"].Value;
                CloseConnection();
            }
            return carPetName;
        }
    }
}