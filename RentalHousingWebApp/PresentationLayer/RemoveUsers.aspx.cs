using RentalHousingWebApp.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RentalHousingWebApp.PresentationLayer
{
    public partial class RemoveUsers : System.Web.UI.Page
    {
        UserCredentials ucd = new UserCredentials();
        StaffCredentials scd = new StaffCredentials();
        string path = HttpRuntime.AppDomainAppPath + "/DataAccessLayer/Database/";

        protected void Page_Load(object sender, EventArgs e)
        {      
            if (!IsPostBack && Session["IsAlreadyLoaded"] == null)
            {
                if (!File.Exists(path + @"\EndUsers.xml"))
                {
                    ucd.setupEndUserDB();
                }
                if (!File.Exists(path + @"\StaffMembers.xml"))
                {
                    scd.setupStaffDB();
                }
                Session["IsAlreadyLoaded"] = true;
            }
        }

        protected void btn_removeNow_Click(object sender, EventArgs e)
        {
            if (txt_userName.Text.Equals("") || txt_userName.Text.Equals(null))
            {
                lbl_error_inputBoxes.Text = "Please provide valid input in all fields";
            }
            else
            {
                txt_UsersAfterRemoval.InnerText = "";
                string name = txt_userName.Text;

                if (ucd.removeEndUserByName(name))
                {
                    List<string> list = new List<string>();
                    list = ucd.readAllEndUsers().ToList();

                    foreach (string str in list)
                    {
                        txt_UsersAfterRemoval.InnerText += str + "\n";
                    }
                    lbl_RemoveSuccessMsg.Text = "Removal successful";
                }
            }
        }

        protected void btn_logout_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["role"] = "";
            Session["password"] = "";
            Response.Redirect("UserLoginPage.aspx");
        }

        protected void btn_landingPage_Click(object sender, EventArgs e)
        {
            string role = Session["role"].ToString();
            if (role.Equals("clerk"))
            {
                Response.Redirect("StaffLandingPage.aspx");
            }
            else if (role.Equals("manager"))
            {
                Response.Redirect("ManagerLandingPage.aspx");
            }
            else if (role.Equals("endUser"))
            {
                Response.Redirect("UsersLandingPage.aspx");
            }
            else
            {
                Response.Redirect("UserLoginPage.aspx");
            }
        }
    }
}