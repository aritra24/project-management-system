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
            if (Session["username"] != null)
            {
                Response.Redirect("dashboard.aspx");
            }
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            var query = "Select * from Users where username = @username";
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
                        int access = (int)reader["accessLevel"];
                        HashAlgorithm sha = new SHA1CryptoServiceProvider();
                        string hashed = Convert.ToBase64String(sha.ComputeHash(Encoding.ASCII.GetBytes(Login_password.Text+salt)));
                        if (password == hashed)
                        {
                            Session["access"] = access;
                            Session["username"] = reader["username"];
                            Session["id"] = reader["id"];
                            if(access > 0)
                                Response.Redirect("./dashboard.aspx");
                            else if(access > 10)
                                Response.Redirect("./admin.aspx");
                        }
                        else
                        {
                            Label1.Text = "Login Failed";
                            Response.Redirect("./login.aspx");
                        }
                    }
                }
            }
            return;
        }
    }
}