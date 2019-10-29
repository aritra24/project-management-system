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
    public partial class edit : System.Web.UI.Page
    {
        private int slno;
        private String connection = @"Data Source=(localdb)\MSSQLlocalDB;Initial Catalog=project;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["access"] == null || (int)Session["access"] < 20)
            {
                Response.Redirect("login.aspx");
            }
            string s = Request.QueryString["id"];
            slno = Int32.Parse(s);
            if (!IsPostBack)
            {
                
                this.BindGrid();
            }
        }

        private void BindGrid()
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Projects.id as id, Projects.name as name, description, duration, Clients.name as client, createdby, reviseCount, postedOn FROM Projects, Clients WHERE Projects.id = @projectid AND Projects.client = Clients.id"))
                {
                    cmd.Parameters.AddWithValue("@projectid", slno);
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            view_project.DataSource = dt;
                            view_project.DataBind();
                        }
                    }
                }
            }
        }

        protected void view_project_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE Projects SET name=@name, description=@description, duration=@duration, reviseCount=@reviseCount WHERE id=@id"))
                {

                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@id", view_project.Rows[0].Cells[1].Text);
                    cmd.Parameters.AddWithValue("@name", e.NewValues["name"]);
                    cmd.Parameters.AddWithValue("@description", e.NewValues["description"]);
                    cmd.Parameters.AddWithValue("@duration", e.NewValues["duration"]);
                    cmd.Parameters.AddWithValue("@reviseCount", Convert.ToInt32(view_project.Rows[0].Cells[8].Text)+1);

                    cmd.ExecuteReader();
                }
                con.Close();
            }
            Response.Redirect("admin.aspx");
        }

        protected void view_project_RowEditing(object sender, GridViewEditEventArgs e)
        {
            view_project.EditIndex = 0;
        }
    }
}