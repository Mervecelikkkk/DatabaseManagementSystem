using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VeriTabaniYonetimSistemi
{
    public partial class Register : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ToString());

        protected void btnRegister_Click(object sender, EventArgs e)
        {


            string activationUrl = string.Empty;
            string emailid = string.Empty;

            try
            {
              
                
                SqlCommand cmd = new SqlCommand("insert into Kullanicilar (ad, soyad, kullaniciAd, email, sifre) values (@ad, @soyad, @kullaniciAd, @email, @sifre) ", conn);
                SqlCommand cmdSchema = new SqlCommand("Create Schema "+txtKullaniciAd.Text, conn);

                cmd.Parameters.AddWithValue("@ad", txtAd.Text);
                cmd.Parameters.AddWithValue("@soyad", txtSoyad.Text);
                cmd.Parameters.AddWithValue("@kullaniciAd", txtKullaniciAd.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@sifre", txtSifre.Text);
                //cmd.Parameters.AddWithValue("@aktifMi", false);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                cmd.ExecuteNonQuery();
                cmdSchema.ExecuteNonQuery();
              
                MailAddress to = new MailAddress(txtEmail.Text);

                MailAddress from = new MailAddress("clkmerve3@gmail.com");

                MailMessage mail = new MailMessage(from, to);

                emailid = txtEmail.Text;
                mail.Subject = "Hesap Doğrulama";
                activationUrl = Server.HtmlEncode("https://localhost:44395/HesapAktif.aspx?UserID=" + FetchUserId(emailid) + "&EmailId=" + emailid);

                mail.Body = "Merhaba " + txtAd.Text.Trim() + "!\n" +
                  "Lütfen <a href='" + activationUrl + "'>hesabınızı etkinleştirmek ve hizmetlerimizden faydalanabilmek için linke tıklayın. \n Teşekkürler!";


                //                mail.Body = @"<div style='text-align:center;'>
                //                      <h1> VTYS'ye hoş geldiniz </h1>

                //                         <h3> Email Adresinizi Doğrulamak için Butona Tıklayın </ h3 >

                //                          <form method='post' action='{0} style='display:inline;'>

                //                           <button type ='submit' style ='display:block;    
                //                                                          text-align:center;
                //                                                          font-weight:bold;
                //                                                          background-color:#008CBA;
                //                                                          font-size:16px;
                //                                                          border-radius: 10px;
                //                                                          color:#ffffff;
                //                                                          cursor: pointer;
                //                                                          width:100%;
                //                                                          padding:10px;'>

                //                                                          confirm mail

                //</button>

                //</form>

                //</div> ";
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                emailid = txtEmail.Text;

                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                emailid = txtEmail.Text;
                smtp.Credentials = new NetworkCredential(
                    "clkmerve3@gmail.com", "M1475963C9874123");
                smtp.EnableSsl = true;
                smtp.Send(mail);

                clearControls();
              

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Lütfen Hesabınızı Aktif Etmek için Email Adresinize Gönderilen Linke Tıklayınız.');", true);



            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Bir Hata Oluştu:" + ex.Message.ToString() + "');", true);
                return;
            }

            finally
            {
                activationUrl = string.Empty;
                emailid = string.Empty;
                conn.Close();
            }



        }

        private string FetchUserId(string emailid)
        {
            SqlCommand cmd = new SqlCommand("Select id from Kullanicilar Where email=@email", conn);
            cmd.Parameters.AddWithValue("@email", emailid);
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            string UserID = Convert.ToString(cmd.ExecuteScalar());
            conn.Close();
            return UserID;
        }
        private void clearControls()
        {
            txtAd.Text = string.Empty;
            txtSoyad.Text = string.Empty;
            txtKullaniciAd.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtSifre.Text = string.Empty;
            txtAd.Focus();
        }

    }
}