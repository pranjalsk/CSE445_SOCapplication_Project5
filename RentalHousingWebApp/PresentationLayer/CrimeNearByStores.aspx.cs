using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RentalHousingWebApp.RemoteServiceLayer;

namespace RentalHousingWebApp.PresentationLayer
{
    public partial class CrimeNearByStores : System.Web.UI.Page
    {
        CrimeDataServiceAccess crimeDataProxy;    
        int[] crimeData = new int[10];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["username"] as string) || string.IsNullOrEmpty(Session["role"] as string))
            {
                Response.Redirect("UserLoginPage.aspx");
            }
        }

        protected void btn_crimeData_Click(object sender, EventArgs e)
        {
            //Check for valid zip number entry
            if (txt_zipCode.Value == null || txt_zipCode.Value == "" || txt_zipCode.Value.Length < 5)
            {
                lbl_errormsg_crime.Visible = true;
                lbl_errormsg_crime.Text = "Zip code should contain 5 digits";
            }
            else
            {
                lbl_errormsg_crime.Visible = false;
                //Zip, ViolentCrime,MurderAndManslaughter,ForcibleRape,Robbery,AggravatedAssault,PropertyCrime,Burglary,LarcenyTheft,MotorVehicleTheft  
                crimeDataProxy = new CrimeDataServiceAccess();

                int[] crimeData = new int[10];
                crimeData = crimeDataProxy.getCrimeData(Convert.ToInt32(txt_zipCode.Value));

                td_ZIP.Text = Convert.ToString(crimeData[0]);
                td_ViolentCrime.Text = Convert.ToString(crimeData[1]);
                td_MurderAndManslaughter.Text = Convert.ToString(crimeData[2]);
                td_ForcibleRape.Text = Convert.ToString(crimeData[3]);
                td_Robbery.Text = Convert.ToString(crimeData[4]);
                td_AggravatedAssault.Text = Convert.ToString(crimeData[5]);
                td_PropertyCrime.Text = Convert.ToString(crimeData[6]);
                td_Burglary.Text = Convert.ToString(crimeData[7]);
                td_LarcenyTheft.Text = Convert.ToString(crimeData[8]);
                td_MotorVehicleTheft.Text = Convert.ToString(crimeData[9]);
            }  
        }

        protected void btn_getStoresNearBy_Click(object sender, EventArgs e)
        {
            //Check for valid zip nmber enrty
            if (txt_zip.Text == "" || txt_zip.Text == null || txt_zip.Text.Length < 5)
            {
                lbl_errorMsg.Visible = true;
                lbl_errorMsg.Text = "Zip code should contain 5 digits";
            }
            else
            {
                NearByStoresAccess proxyNearByStores = new NearByStoresAccess();
                lbl_errorMsg.Visible = false;
                string zip = Convert.ToString(txt_zip.Text);
                string[] latlng = proxyNearByStores.getLatLong(txt_zip.Text).Split(',');
                lbl_latitude.Visible = true;
                lbl_longitude.Visible = true;
                lbl_latitude.Text = latlng[0];
                lbl_longitude.Text = latlng[1];
                string typeSelected = dpdown_storeType.SelectedValue;
                txtArea_NearByStores.InnerText = proxyNearByStores.findNearestStore(zip, typeSelected);
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