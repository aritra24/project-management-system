using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Management_System
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["theme"];
            if (cookie["theme"].ToString() == "dark")
            {
                cb1.Checked = false;
            }
            else
            {
                cb1.Checked = true;
            }
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["theme"];
            if (cookie["theme"].ToString() == "light")
            {
                Page.Theme = "light";
            }
            else
            {
                Page.Theme = "dark";
            }
        }

        protected void Unnamed_CheckedChanged(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["theme"];
            if(cookie == null)
            {
                cookie = new HttpCookie("theme");
            }
            if (((CheckBox)sender).Checked==true)
            {
                cookie["theme"] = "dark";
            }
            else
            {
                cookie["theme"] = "light";
            }
            Response.AppendCookie(cookie);
        }
    }
}