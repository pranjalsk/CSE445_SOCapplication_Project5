using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryItPagesApplication
{
    public partial class TryItPart1 : System.Web.UI.Page
    {
        ServiceCrimeData.ServiceCrimeDataClient proxy;
        int[] crimeData = new int[10];

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Crime data service calling and data display
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_crimeData_Click(object sender, EventArgs e)
        {
            if (txt_zipCode.Value == null || txt_zipCode.Value == "" || txt_zipCode.Value.Length < 5)
            {
                lbl_errormsg_crime.Visible = true;
                lbl_errormsg_crime.Text = "Zip code should contain 5 digits";
            }
            else
            {
                lbl_errormsg_crime.Visible = false;
                //Zip, ViolentCrime,MurderAndManslaughter,ForcibleRape,Robbery,AggravatedAssault,PropertyCrime,Burglary,LarcenyTheft,MotorVehicleTheft  
                proxy = new ServiceCrimeData.ServiceCrimeDataClient();

                int[] crimeData = new int[10];
                crimeData = proxy.getCrimeData(Convert.ToInt32(txt_zipCode.Value));

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

        /// <summary>
        /// Near By stores service calling and display result
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_getStoresNearBy_Click(object sender, EventArgs e)
        {
            if (txt_zip.Text == "" || txt_zip.Text == null || txt_zip.Text.Length < 5)
            {
                lbl_errorMsg.Visible = true;
                lbl_errorMsg.Text = "Zip code should contain 5 digits";
            }
            else
            {
                NearByStoresService.ServiceNearByStoresClient proxyNearByStores = new NearByStoresService.ServiceNearByStoresClient();
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
    }
}