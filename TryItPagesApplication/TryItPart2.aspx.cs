using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryItPagesApplication
{
    public partial class TryItPart2 : System.Web.UI.Page
    {
        ServiceReferenceDataAccess.ServiceDataAccessClient proxy = new ServiceReferenceDataAccess.ServiceDataAccessClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            proxy.createDB();
        }

        protected void btn_viewAll_Click(object sender, EventArgs e)
        {
            txtArea_viewAll.InnerText = "";
            List<string> list = new List<string>();
            list = proxy.readAll().ToList();

            foreach (string str in list)
            {
                txtArea_viewAll.InnerText += str + "\n";
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
                list = proxy.read(zip).ToList();

                foreach (string str in list)
                {
                    txtArea_viewByZip.InnerText += str + "\n";
                }
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

                if (proxy.remove(id, name, zip))
                {
                    List<string> list = new List<string>();
                    list = proxy.read(zip).ToList();

                    foreach (string str in list)
                    {
                        txt_HousesAfterBooking.InnerText += str + "\n";
                    }
                }
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var mail = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        protected void btn_emailVerify_Click(object sender, EventArgs e)
        {
            if (!IsValidEmail(txt_emailAddress.Text))
            {
                Response.Write("<script>alert('invalid Email format');</script>");
            }
            else
            {
                var url = "http://webstrar36.fulton.asu.edu/page1/ServiceValidation.svc/checkEmail?email=" + txt_emailAddress.Text;
                var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

                using (var response = webrequest.GetResponse())
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    var result = reader.ReadToEnd();
                    lbl_emailVerify.Text = Convert.ToString(result);
                }
            }
        }

        protected void btn_verifyCredit_Click(object sender, EventArgs e)
        {
            var url = "http://webstrar36.fulton.asu.edu/page1/ServiceValidation.svc/isCreditCardValid?number=" + txt_creditCard.Text;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                lbl_creditVerify.Text = Convert.ToString(result);
            }
        }

    }
}