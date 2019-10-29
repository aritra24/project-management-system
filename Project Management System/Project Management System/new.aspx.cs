using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Management_System
{
    public partial class _new : System.Web.UI.Page
    {
        private String connection = @"Data Source=(localdb)\MSSQLlocalDB;Initial Catalog=project;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["access"] == null || (int)Session["access"] < 20)
            {
                Response.Redirect("login.aspx");
            }
            title.Attributes.Add("placeholder", "Title");
            description.Attributes.Add("placeholder", "Description");
            duration.Attributes.Add("placeholder", "Duration");

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Projects VALUES(@name, @description, @createdby, @postedOn, @duration, @client, @reviseCount)"))
                {

                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@name", title.Text);
                    cmd.Parameters.AddWithValue("@description", description.Text);
                    cmd.Parameters.AddWithValue("@createdby", (int)Session["id"]);
                    cmd.Parameters.AddWithValue("@postedOn", DateTime.Now);
                    cmd.Parameters.AddWithValue("@duration", duration.Text);
                    cmd.Parameters.AddWithValue("@client", client.SelectedValue);
                    cmd.Parameters.AddWithValue("@reviseCount", 0);

                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }
    }
}