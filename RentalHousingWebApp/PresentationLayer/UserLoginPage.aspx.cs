using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RentalHousingWebApp.DataAccessLayer;
using System.IO;

namespace RentalHousingWebApp.PresentationLayer
{
    public partial class UserLoginPage : System.Web.UI.Page
    {
        UserCredentials ucd = new UserCredentials();
        StaffCredentials scd = new StaffCredentials();

        protected void Page_Load(object sender, EventArgs e)
        {
            string path = HttpRuntime.AppDomainAppPath + "/DataAccessLayer/Database/"; 

            Session["username"] = "";
            Session["password"] = "";
            Session["role"] = "";
            if (!IsPostBack && Session["IsAlreadyLoad"] == null)
            {
                if (!File.Exists(path + @"\EndUsers.xml"))
                {
                    ucd.setupEndUserDB();
                }
                if (!File.Exists(path + @"\StaffMembers.xml"))
                {
                    scd.setupStaffDB();                
                }
                Session["IsAlreadyLoad"] = true;
            }
        
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            string result = "";
            if (txt_userName.Value != null && txt_userName.Value != "" && txt_password.Value !=null && txt_password.Value !="")
            {
                result = getUsers(txt_userName.Value.ToString(), txt_password.Value.ToString(), false);
            }
            if (!result.Any())
            {
                lbl_userLogin.Text = "Login Un-successful, try registering if new user";
            }
            else {
                lbl_userLogin.Text = "Login Successfull--" + result;
                string[] tokens = result.Split(';');
                Session["username"] = tokens[0];
                Session["password"] = tokens[1];
                Session["role"] = "endUser";
                Response.Redirect("UsersLandingPage.aspx");
            }
        }

        public string getUsers(string username, string password, bool isEncrypted) {         
                string output = "";
                List<string> result = ucd.readUser(username, password, false);
                foreach (string str in result)
                {
                    output += str;
                }
               return output;
        }

        protected void btn_register_Click(object sender, EventArgs e)
        {
            if (txt_registerUsername.Value != null && txt_registerUsername.Value != "" && txt_registerPassword.Value != null && txt_registerPassword.Value != "")
            {
                txt_staffUsername.Value = "";
                List<string> result = ucd.readUser(txt_registerUsername.Value.ToString(), txt_registerPassword.Value.ToString(), false);
                if (!result.Any())
                {
                   //If non exisitng user, add new user
                   string firstname = txt_firstname.Value.ToString();
                   string lastname = txt_lastname.Value.ToString();
                   string username = txt_registerUsername.Value.ToString();
                   string password = txt_registerPassword.Value.ToString();
                   bool isEncrypted = false;
                   bool done = ucd.addNewEndUser(firstname,lastname,username,password,isEncrypted);
                   if (done)
                   {
                       lbl_registerUser.Text = "Registration successful, Please use details to log in!";
                   }
                }
                else {
                  lbl_registerUser.Text = "Already a user? Please Login";
                }
                
            }
        }

        protected void btn_StaffLogin_Click(object sender, EventArgs e)
        {
            string result = "";
            if (txt_staffUsername.Value != null && txt_staffUsername.Value != "" && txt_staffPassword.Value != null && txt_staffPassword.Value != "")
            {
                List<string> temp = scd.readStaffMember(txt_staffUsername.Value.ToString(), txt_staffPassword.Value.ToString());
                foreach (string str in temp)
                {
                    result += str;
                }
            }
            if (!result.Any())
            {
                lbl_StaffLoginLabel.Text = "Login Un-successful, PLeae check credentials";
            }
            else
            {
                lbl_StaffLoginLabel.Text = "Login Success -- "+result;
                string[] tokens = result.Split(';');
                Session["username"] = tokens[1];
                Session["password"] = tokens[2];
                Session["role"] = tokens[0];
                string role = Session["role"].ToString();
                if (role.Equals("clerk"))
                {
                    Response.Redirect("StaffLandingPage.aspx");
                }
                else if (role.Equals("manager"))
                {
                    Response.Redirect("ManagerLandingPage.aspx");
                }
                else {
                    Response.Redirect("UserLoginPage.aspx");
                }

            }
        }
    }
}