using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Web.UI.WebControls;

namespace Project_Management_System
{
    public partial class login : System.Web.UI.Page
    {
        private String connection = @"Data Source=(localdb)\MSSQLlocalDB;Initial Catalog=project;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            var query = "Select password, salt from Users where username = @username";
            using (var conn = new SqlConnection(connection))
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@username", SqlDbType.VarChar);
                    cmd.Parameters["@username"].Value = Convert.ToString(Login_username.Text);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if(!reader.Read())
                    {
                        Response.Redirect("./login.aspx");
                    }
                    else
                    {
                        string password = (string)reader["password"];
                        string salt = (string)reader["salt"];
                        HashAlgorithm sha = new SHA1CryptoServiceProvider();
                        string hashed = Convert.ToBase64String(sha.ComputeHash(Encoding.ASCII.GetBytes(Login_password.Text)));
                        if (password == hashed)
                        {
                            Label1.Text += hashed + " " + password;
                            Response.Redirect("./dashboard.aspx");
                        }
                        else
                        {
                            Label1.Text += hashed + " " + password;
                            Response.Redirect("./login.aspx");
                        }
                    }
                }
            }
            return;
        }
    }
}