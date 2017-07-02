using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RentalHousingWebApp.PresentationLayer
{
    public partial class ManagerLandingPage : System.Web.UI.Page
    {
        string staffRole;
        string staffUsername;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["username"] as string) || string.IsNullOrEmpty(Session["role"] as string))
            {
                Response.Redirect("UserLoginPage.aspx");
            }
            else {
                staffRole = Session["role"].ToString();
                staffUsername = Session["username"].ToString();
                lbl_username.Text = staffUsername;
            }

            if (!staffRole.Equals("manager"))
            {
                Response.Redirect("ErrorPage.aspx");
            }
            
        }

        protected void btn_logout_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["role"] = "";
            Session["password"] = "";
            Response.Redirect("UserLoginPage.aspx");
        }
    }
}