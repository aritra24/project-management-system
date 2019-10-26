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
            if (!this.IsPostBack)
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
        }
    }
}