using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using WebAPIDemo.Models;

namespace WebAPIDemo.ServiceLayer
{
    public class DataLayer
    {
        public static MySqlConnection conn()
        {
            string conn_string = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(conn_string);
            return conn;
        }
        public static MySqlConnection con = conn();
        public static IEnumerable<ToDoModel> GetWorkList()
        {
            List<ToDoModel> workItems = new List<ToDoModel>();
            try
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Select * From WorkList", con);
                cmd.CommandType = CommandType.Text;

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                workItems = ds.Tables[0].AsEnumerable().Select(dataRow => new ToDoModel (dataRow.Field<int>("ID"), dataRow.Field<string>("WorkName"))).ToList();
            }
            finally
            {
                con.Close();
            }
            return workItems;
        }

        public static int InsertWorkItem(ToDoModel workItem)
        {
            int WorkItemID = 0;
            try
            {
                string query = "Insert into WorkList (WorkName) " + "Values(@WorkName); SELECT @@IDENTITY";
                // create connection and command
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.Add("@WorkName", MySqlDbType.VarChar, 50).Value = workItem.WorkName;
                    con.Open();
                    WorkItemID = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }

            }
            finally
            {
                con.Close();
            }
            return WorkItemID;
        }

        public static IEnumerable<ToDoModel> UpdateWorkItem(int ID, ToDoModel workItem)
        {
            int updatedRows = 0;
            List<ToDoModel> workItems = new List<ToDoModel>();
            try
            {
                string query = "Update WorkList Set WorkName = @WorkName Where ID = @ID";
                // create connection and command
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.Add("@WorkName", MySqlDbType.VarChar, 50).Value = workItem.WorkName;
                    cmd.Parameters.Add("@ID", MySqlDbType.VarChar, 50).Value = ID;
                    con.Open();
                    updatedRows = Convert.ToInt32(cmd.ExecuteNonQuery());
                    con.Close();
                }

                if (updatedRows > 0)
                {
                    workItems = GetWorkList().ToList();
                }
                else
                {
                    throw new Exception("ID Not found");
                }

            }
            finally
            {
                con.Close();
            }
            return workItems;
        }

        public static IEnumerable<ToDoModel> DeleteWorkItem(int ID)
        {
            int deletedRows = 0;
            List<ToDoModel> workItems = new List<ToDoModel>();
            try
            {
                string query = "Delete From WorkList Where ID = @ID";
                // create connection and command
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.Add("@ID", MySqlDbType.VarChar, 50).Value = ID;
                    con.Open();
                    deletedRows = Convert.ToInt32(cmd.ExecuteNonQuery());
                    con.Close();
                }

                if (deletedRows > 0)
                {
                    workItems = GetWorkList().ToList();
                }
                else
                {
                    throw new Exception("ID Not found");
                }

            }
            finally
            {
                con.Close();
            }
            return workItems;
        }

    }
}