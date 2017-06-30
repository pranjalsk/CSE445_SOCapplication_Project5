using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RentalHousingWebApp.DataAccessLayer;

namespace RentalHousingWebApp.PresentationLayer
{
    public partial class UserLoginPage : System.Web.UI.Page
    {
        UserCredentials ucd = new UserCredentials();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            ucd.setupEndUserDB();
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            string result = "";
            if (txt_userName.Value != null && txt_userName.Value != "" && txt_password.Value !=null && txt_password.Value !="")
            {
                result = getUsers(txt_userName.Value.ToString(), txt_password.Value.ToString(), false);
            }
            txt_staffUsername.Value = result;
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
                bool alreadyExists = false;
                string output = "";
                List<string> result = ucd.readUser(txt_registerUsername.Value.ToString(), txt_registerPassword.Value.ToString(), false);
                foreach (string str in result)
                {
                    output += str;
                }

                txt_staffUsername.Value = output;
                

                if (!alreadyExists)
                {
                    bool done = ucd.addNewEndUser(txt_registerUsername.Value.ToString(), txt_registerPassword.Value.ToString(), false);
                    //txt_staffUsername.Value = done.ToString();
                }
                else {
                   // txt_staffUsername.Value = "Already a user";
                }
                
            }
        }
    }
}