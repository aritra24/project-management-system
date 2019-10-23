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
        private String connection = "server=localhost;user id=root; password=root;persistsecurityinfo=True;database=project";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            var query = "Select password from users where username = @username";
            using (var conn = new SqlConnection(connection))
            {
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add("@username", SqlDbType.VarChar);
                    cmd.Parameters["@username"].Value = Convert.ToString(Login_username.Text);
                    try
                    {
                        conn.Open();
                    }
                    catch (SqlException ex)
                    {
                        Label1.Text+=$"Can not open connection ! ErrorCode: {ex.ErrorCode} Error: {ex.Message}";
                    }
                    catch (Exception ex)
                    {
                        Label1.Text+=$"Can not open connection ! Error: {ex.Message}";
                    }
                    SqlDataReader reader = cmd.ExecuteReader();
                    if(!reader.HasRows)
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
                            Response.Redirect("./dashboard.aspx");
                        }
                        else
                        {
                            Response.Redirect("./login.aspx");
                        }
                    }
                }
            }
            return;
        }
    }
}