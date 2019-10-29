using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Management_System
{
    public partial class register : System.Web.UI.Page
    {
        private String connection = @"Data Source=(localdb)\MSSQLlocalDB;Initial Catalog=project;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                Response.Redirect("dashboard.aspx");
            }
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            string username, password, hashed="", salt="";
            username = Login_username.Text;
            var query = "Select * from Users where username = @username";
            using (var conn = new SqlConnection(connection))
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@username", SqlDbType.VarChar);
                    cmd.Parameters["@username"].Value = Convert.ToString(Login_username.Text);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (!reader.Read())
                    {
                        password = Login_password.Text;
                        salt = new Random().Next().ToString();
                        HashAlgorithm sha = new SHA1CryptoServiceProvider();
                        hashed = Convert.ToBase64String(sha.ComputeHash(Encoding.ASCII.GetBytes(password+salt)));
                    }
                    else
                    {
                        Response.Redirect("/register.aspx");
                        return;
                    }
                }
            }
            query = "INSERT INTO Users VALUES(@username, @hashed, @salt, @accessLevel);";
            using (var conn = new SqlConnection(connection))
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@hashed", hashed);
                    cmd.Parameters.AddWithValue("@salt", salt);
                    cmd.Parameters.AddWithValue("@accessLevel", 10);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    Response.Redirect("login.aspx");
                    return;
                }
            }
        }
    }
}