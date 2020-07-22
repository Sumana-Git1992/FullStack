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
                
    }
}