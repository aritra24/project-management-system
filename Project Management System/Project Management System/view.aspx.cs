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
    public partial class view : System.Web.UI.Page
    {
        private int slno;
        private String connection = @"Data Source=(localdb)\MSSQLlocalDB;Initial Catalog=project;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["access"] == null || (int)Session["access"] < 10)
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
                            title1.Text = dt.Rows[0].ItemArray[1].ToString();
                            Description.Text = dt.Rows[0].ItemArray[2].ToString();
                            Duration.Text = dt.Rows[0].ItemArray[3].ToString();
                            Client.Text = dt.Rows[0].ItemArray[4].ToString();
                            PostedOn.Text = dt.Rows[0].ItemArray[5].ToString();
                            ReviseCount.Text = dt.Rows[0].ItemArray[6].ToString();

                        }
                    }
                }
            }
            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT username, comment FROM Comments, Users WHERE project=@id AND Users.Id=Comments.userID AND state=1"))
                {
                    cmd.Parameters.AddWithValue("@id", slno);
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            commentsTable.DataSource = dt;
                            commentsTable.DataBind();

                        }
                    }
                }
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Comments VALUES(@user, @comment, @state, @project);"))
                {

                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@user", Session["id"]);
                    cmd.Parameters.AddWithValue("@comment", Comment.Text);
                    cmd.Parameters.AddWithValue("@state", 0);
                    cmd.Parameters.AddWithValue("@project", slno);
                    cmd.ExecuteReader();
                }
                con.Close();
            }
        }
    }
}