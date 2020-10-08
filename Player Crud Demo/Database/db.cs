using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Player_Crud_Demo.Models;


namespace Player_Crud_Demo.Database
{
    public class db
    {
        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        public void AddPlayer(PlayerClass pl)
        {
            SqlCommand com = new SqlCommand("PlayerAdd",con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FirstName", pl.FirstName);
            com.Parameters.AddWithValue("@LastName", pl.LastName);
            com.Parameters.AddWithValue("@Email", pl.Email);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        public void UpdatePlayer(PlayerClass pl)
        {
            SqlCommand com = new SqlCommand("PlayerUpdate", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FirstName", pl.FirstName);
            com.Parameters.AddWithValue("@LastName", pl.LastName);
            com.Parameters.AddWithValue("@Email", pl.Email);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        public DataSet ShowPlayerByID(int id)
        {
            SqlCommand com = new SqlCommand("GetPlayerByID", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@PlayerID", id);
            SqlDataAdapter sd = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            sd.Fill(ds);
            return ds;
        }

        public DataSet ShowPlyerList()
        {
            SqlCommand com = new SqlCommand("PlayerAll", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sd = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            sd.Fill(ds);
            return ds;
        }

        public void DeletePlayer(int id)
        {
            SqlCommand com = new SqlCommand("PlayerDelete", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@PlayerID", id);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
    }
}