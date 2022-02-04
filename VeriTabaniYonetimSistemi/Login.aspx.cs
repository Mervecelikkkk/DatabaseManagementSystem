using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VeriTabaniYonetimSistemi
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["KullaniciBilgi"];

            if (cookie != null)
            {
                txtKullaniciAd.Text = cookie["KullaniciAd"].ToString();
                //lblMsj.Text = Session["KullaniciAd"].ToString();

            }


        }
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ToString());
        //Kullanici giris bilgilerini db'den al checkk et index sayfasina yonlendir eslesmiyorsa hata mesaji yazdir.

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select kullaniciAd,sifre from Kullanicilar Where kullaniciAd=@kullaniciAd and sifre=@sifre", conn);
                cmd.Parameters.AddWithValue("@kullaniciAd", txtKullaniciAd.Text);
                cmd.Parameters.AddWithValue("@sifre", txtSifre.Text);

                SqlDataReader dr = cmd.ExecuteReader();


                if (dr.Read())
                {
                    lblMsj.ForeColor = System.Drawing.Color.Green;
                    lblMsj.Text = "Login Başarılı";
                    //Kullanici Rememeber Me checkbox'ini isaretlediyse kullanici adini cookie'de tur login ekrani cagirildiginde bilgiyi ilgili textbox'a yazdir.
                    //Login basarili ise kullanici bilgilerini session'da tut.
                    if (chkRemember.Checked == true)
                    {
                        HttpCookie cookie = new HttpCookie("KullaniciBilgi");
                        cookie["KullaniciAd"] = txtKullaniciAd.Text;

                        //cookie.Expires = DateTime.Now.AddDays(30);
                        Response.Cookies.Add(cookie);

                        Session["KullaniciAd"] = txtKullaniciAd.Text;
                        Session["Sifre"] = txtSifre.Text;


                    }
                    Response.Redirect("index.aspx");
                }
                else
                {
                    lblMsj.ForeColor = System.Drawing.Color.Red;
                    lblMsj.Text = "Kullanıcı Adı veya Şifre Yanlış. Lütfen Tekrar Deneyiniz.";

                }

                conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }




        }
    }
}