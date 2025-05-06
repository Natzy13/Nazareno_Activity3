using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace BogsySystem
{

    class DBAccess
    {
        private static SqlConnection connection = new SqlConnection(); //Empty connection object to the database
        private static SqlCommand command = new SqlCommand();          //For sql query command
        private static SqlDataAdapter adapter = new SqlDataAdapter();  //Use to store data in the data table from database bridge connection.

        //This is the connection to the sql server
        private static string strConnString = "Data Source=DESKTOP-ND2PEO8\\SQLEXPRESS;Initial Catalog=BogsyDb;Integrated Security=True;TrustServerCertificate=True";



        public void createConn()
        {
            try
            {
                if (connection.State != ConnectionState.Open)    // Check the connection if open
                {
                    connection.ConnectionString = strConnString; //Use the empty connection and use the sql server connection 
                    connection.Open();                           //Open the connection
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void closeConn() //Use to close the database connection 
        {
            connection.Close();
        }


        public void readDatathroughAdapter(string query, DataTable tblName) //Store data that comes from db to data table, for display
        {
            try
            {
                if (connection.State == ConnectionState.Closed) //Check if the connection is closed 
                {
                    createConn();                               //Open a connection
                }

                command.Connection = connection; // tells the command which database connection to use to execute the SQL
                command.CommandText = query;     // tells the command what sql query to run
                command.CommandType = CommandType.Text; //specify what type of command in this code it is plain SQL text

                adapter = new SqlDataAdapter(command); //Prepares the adapter to execute the command and pull data.
                adapter.Fill(tblName); //Fill the datatable that comes from sqldata adapter
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int executeQuery(SqlCommand dbCommand) //Use for INSERT, UPDATE with dbCommand parameter for query
        {
            try
            {
                if (connection.State == 0)
                {
                    createConn();
                }

                dbCommand.Connection = connection;
                dbCommand.CommandType = CommandType.Text;


                return dbCommand.ExecuteNonQuery(); //Return number of rows of how many is affected based on INSERT and UPDATE
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void readDatathroughAdapter(string query, DataTable tblName, int userID)
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    createConn();
                }

                command.Connection = connection;
                command.CommandText = query;
                command.CommandType = CommandType.Text;
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@userID", userID);

                adapter = new SqlDataAdapter(command);
                adapter.Fill(tblName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object executeScalar(SqlCommand command) //Use for counting rows in database
        {
            object result = null; //Store the return value of the SQL query

            if (connection.State == ConnectionState.Closed)
            {
                createConn();
            }

            command.Connection = connection;

            result = command.ExecuteScalar(); //Returns the single value in the first column of the first row of the query

            closeConn();
            return result;
        }
    }

}