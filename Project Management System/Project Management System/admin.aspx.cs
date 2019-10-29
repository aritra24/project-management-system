using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Management_System
{
    public partial class admin : System.Web.UI.Page
    {
        private String connection = @"Data Source=(localdb)\MSSQLlocalDB;Initial Catalog=project;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindGrid();
            }
        }


        private void BindGrid()
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Projects.id as id, Projects.name as name, duration, Clients.name as client, reviseCount, postedOn FROM Projects, Clients WHERE Projects.client = Clients.id"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            AllProjects.DataSource = dt;
                            AllProjects.DataBind();
                        }
                    }
                }
            }
            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Comments.id as id, username, comment FROM Comments, Users WHERE state = 0 AND Comments.userID = Users.Id;"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            Notifications.DataSource = dt;
                            Notifications.DataKeyNames = new string[] { "id" };
                            Notifications.DataBind();
                        }
                    }
                }
            }
        }

        protected void AllProjects_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string id = AllProjects.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
            if (e.CommandName == "view")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("edit.aspx?id=" + id);
            }
            if (e.CommandName == "remove")
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Projects WHERE id=@id"))
                    {
                        
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@id", Int32.Parse(id));
                        cmd.ExecuteNonQuery();
                        this.BindGrid();
                    }
                    con.Close();
                }
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Response.Redirect("new.aspx");
        }

        protected void Notifications_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            int cstate = 0;
            if (e.CommandName == "Approve")
            {
                cstate = 1;
            }
            else if(e.CommandName == "Reject")
            {
                cstate=2;
            }
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE Comments SET state=@state WHERE id=@id"))
                {

                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@id", Notifications.Rows[Convert.ToInt32(e.CommandArgument)].Cells[2].Text);
                    cmd.Parameters.AddWithValue("@state", cstate);
                    cmd.ExecuteReader();
                    this.BindGrid();
                }
                con.Close();
            }

        }
    }
}