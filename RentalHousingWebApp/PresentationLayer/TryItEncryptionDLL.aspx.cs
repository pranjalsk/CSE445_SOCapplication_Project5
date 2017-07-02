using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RentalHousingWebApp.PresentationLayer
{
    public partial class TryItEncryptionDLL : System.Web.UI.Page
    {
        EncryptoLibrary.CryptoClass proxy = new EncryptoLibrary.CryptoClass();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_encypt_Click(object sender, EventArgs e)
        {
            if (!txt_encryptiontext.Text.Equals(null) && !txt_encryptiontext.Text.Equals(""))
            {
                string enc = proxy.encrypto(txt_encryptiontext.Text);
                lbl_encryptedtext.Text = enc;
                string dec = proxy.decrypto(enc);
                lbl_decryptedtext.Text = dec;
            }
        }
    }
}