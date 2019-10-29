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
    public partial class comments : System.Web.UI.Page
    {
        private String connection = @"Data Source=(localdb)\MSSQLlocalDB;Initial Catalog=project;Integrated Security=True";
        private String text = "";
        private int user;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindGrid();
            if(!IsPostBack)
                this.FillUsers();
        }

        private void BindGrid()
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT comment FROM Comments WHERE userID = @userID AND state=1 AND comment LIKE '%' + @comment + '%';"))
                {
                    cmd.Parameters.AddWithValue("@userID", user);
                    cmd.Parameters.AddWithValue("@comment",text);

                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            commentsFound.DataSource = dt;
                            commentsFound.DataBind();

                        }
                    }
                }
            }
        }


        private void FillUsers()
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT id, username FROM Users;"))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            userlist.Items.Add(Convert.ToString(sdr["id"])+"-"+Convert.ToString(sdr["username"]));
                        }
                    }
                    con.Close();
                }
            }
        }

        protected void searchterm_TextChanged(object sender, EventArgs e)
        {
            text = searchterm.Text;
            user = Convert.ToInt32(userlist.SelectedValue.Split('-')[0]);
            this.BindGrid();
        }

        protected void userlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            text = searchterm.Text;
            user = Convert.ToInt32(userlist.SelectedValue.Split('-')[0]);
            this.BindGrid();
        }
    }
}