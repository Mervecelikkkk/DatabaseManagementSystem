using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VeriTabaniYonetimSistemi
{
    public partial class index1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (Session["KullaniciAd"] != null )
            {
                //Label1.Text = Session["KullaniciAd"].ToString();
               
            }
            if (Session["Sifre"] != null)
            {
                //Label2.Text = Session["Sifre"].ToString();
            }
        
        }

        protected void chk1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}