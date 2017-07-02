using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RentalHousingWebApp.RemoteServiceLayer;
using System.IO;

namespace RentalHousingWebApp.PresentationLayer
{
    public partial class ViewHouseListing : System.Web.UI.Page
    {
        HousingServiceAccess hsa = new HousingServiceAccess();
        String path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["username"] as string) || string.IsNullOrEmpty(Session["role"] as string))
            {
                Response.Redirect("UserLoginPage.aspx");
            }
            else {
                if (!IsPostBack && Session["IsHousesLoad"] == null)
                {
                    if (!File.Exists(path + @"\Houses.xml"))
                    {
                        hsa.setupHousingDb();
                    }
                    Session["IsHousesLoad"] = true;
                }         
            }
        }

        protected void btn_viewByZip_Click(object sender, EventArgs e)
        {
            if (txt_viewByZip.Text.Equals("") || txt_viewByZip.Text.Equals(null))
            {
                lbl_error_viewByZip.Text = "Please enter valid zip code";
            }
            else
            {
                txtArea_viewByZip.InnerText = "";
                int zip = Convert.ToInt32(txt_viewByZip.Text);
                List<string> list = new List<string>();
                list = hsa.readHouseByZip(zip).ToList();

                foreach (string str in list)
                {
                    txtArea_viewByZip.InnerText += str + "\n";
                }
            }
        }

        protected void btn_viewAll_Click(object sender, EventArgs e)
        {
            txtArea_viewAll.InnerText = "";
            List<string> list = new List<string>();
            list = hsa.readAllHouses().ToList();

            foreach (string str in list)
            {
                txtArea_viewAll.InnerText += str + "\n";
            }
        }

        protected void btn_BookNow_Click(object sender, EventArgs e)
        {
            if (txt_houseId.Text.Equals("") || txt_houseId.Text.Equals(null)
                || txt_houseName.Text.Equals("") || txt_houseName.Text.Equals(null)
                || txt_houseZip.Equals("") || txt_houseZip.Text.Equals(null)
                )
            {
                lbl_error_inputBoxes.Text = "Please provide valid input in all fields";
            }
            else
            {
                txt_HousesAfterBooking.InnerText = "";
                int id = Convert.ToInt32(txt_houseId.Text);
                int zip = Convert.ToInt32(txt_houseZip.Text);
                string name = txt_houseName.Text;

                if (hsa.removeHouse(id, name, zip))
                {
                    List<string> list = new List<string>();
                    list = hsa.readHouseByZip(zip).ToList();

                    foreach (string str in list)
                    {
                        txt_HousesAfterBooking.InnerText += str + "\n";
                    }
                    lbl_BookingSuccessMsg.Text = "Booking successful";
                }
                else
                {
                    lbl_BookingSuccessMsg.Text = "Booking failed, please check your inputs";
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