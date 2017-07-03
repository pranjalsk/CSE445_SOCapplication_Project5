using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RentalHousingWebApp.DataAccessLayer;
using RentalHousingWebApp.LocalComponentLayer;
using System.IO;

namespace RentalHousingWebApp.PresentationLayer
{
    public partial class UserLoginPage : System.Web.UI.Page
    {
        UserCredentials ucd = new UserCredentials();
        StaffCredentials scd = new StaffCredentials();
        
        string path;
   
        imgServiceRef.ServiceClient myimgref = new imgServiceRef.ServiceClient();
        String myStr;
       
        protected void Page_Load(object sender, EventArgs e)
        {
          //  string path = HttpRuntime.AppDomainAppPath + "/DataAccessLayer/Database/"; 
            path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            Session["username"] = "";
            Session["password"] = "";
            Session["role"] = "";
            img_captchImg.Visible = false;
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
                myStr = myimgref.GetVerifierString("5");
                Session["generatedString"] = myStr;
                img_captchImg.Visible = true;
                img_captchImg.ImageUrl = "http://neptune.fulton.ad.asu.edu/WSRepository/Services/ImageVerifier/Service.svc/GetImage/" + myStr;
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
                    string passDecrpt = new EncryptoDecrypto().decrypto(tokens[1]);
                    Session["password"] = passDecrpt;
                    Session["role"] = "endUser";
                    Response.Redirect("UsersLandingPage.aspx");             
            }
        }

        public string getUsers(string username, string password, bool isEncrypted) {         
                string output = "";
                string passEncrpt = new EncryptoDecrypto().encrypto(password);
                List<string> result = ucd.readUser(username, passEncrpt, true);
                foreach (string str in result)
                {
                    output += str;
                }
               return output;
        }

        public string getUsers1(string username)
        {
            string output = "";
            List<string> result = ucd.readUserByName(username);
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
                string result = "";
                bool flag = false;
                result = getUsers1(txt_registerUsername.Value.ToString());
               // List<string> result = ucd.readUser(txt_registerUsername.Value.ToString(), encpass, true);
                if (result.Equals("") || result.Equals(null) || !result.Any())
                {
                    flag = imageVerifer();
                    if (flag)
                    {   //If non exisitng user, add new user
                        string firstname = txt_firstname.Value.ToString();
                        string lastname = txt_lastname.Value.ToString();
                        string username = txt_registerUsername.Value.ToString();
                        string password = txt_registerPassword.Value.ToString();
                        string passEncrp = new EncryptoDecrypto().encrypto(password);
                        bool isEncrypted = true;
                        bool done = ucd.addNewEndUser(firstname, lastname, username, passEncrp, isEncrypted);
                        if (done)
                        {
                            Response.Write("<script language='javascript'>alert('Registration Successful, Please Login');</script>");

                            Server.Transfer("UserLoginPage.aspx", true);         
                        }    
                    }
                    else
                    {
                        lbl_registerUser.Text = "You got wrong captcha! Click on new image";
                        txt_imgText.Value = "";
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
                lbl_StaffLoginLabel.Text = "Login Un-successful, Pleae check credentials";
            }
            else
            {              
                    lbl_StaffLoginLabel.Text = "Login Success -- " + result;
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
                    else
                    {
                        Response.Redirect("UserLoginPage.aspx");
                    }
            }
        }

        public bool imageVerifer() {
            if (!string.IsNullOrEmpty(Session["generatedString"] as string) && Session["generatedString"].ToString().Equals(txt_imgText.Value.ToString()))
            {
                return true;   
            }
            else
            {
                return false;
            }
        }

       
        protected void btn_newImg_Click(object sender, EventArgs e)
        {
            myStr = myimgref.GetVerifierString("5");
            Session["generatedString"] = myStr;
            img_captchImg.Visible = true;
            img_captchImg.ImageUrl = "http://neptune.fulton.ad.asu.edu/WSRepository/Services/ImageVerifier/Service.svc/GetImage/" + myStr;
          
        }
    }
}