using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VeriTabaniYonetimSistemi
{
    public partial class HesapAktif : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ToString());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HesapAktifEt();
            }
        }
        private void HesapAktifEt()
        {
            try
            {

                if ((!string.IsNullOrEmpty(Request.QueryString["UserID"])) & (!string.IsNullOrEmpty(Request.QueryString["EmailId"])))
                {
                    SqlCommand cmd = new SqlCommand("Update Kullanicilar Set aktifMi=1 Where id=@id and email=@email", conn);
                    cmd.Parameters.AddWithValue("@id", Request.QueryString["UserID"]);
                    cmd.Parameters.AddWithValue("@email", Request.QueryString["EmailId"]);
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                    } //?
                    cmd.ExecuteNonQuery();
                    Response.Write("Hesabın Aktif edildi. Artık <a href='https://localhost:44395/login.aspx'> Login </a> ile giriş yapabilirsin.");
                }
           
               
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Bir Hata Oluştu:" + ex.Message.ToString() + "');", true);
                return;
            }
            finally 
            { 
            conn.Close();
            }
        }
        
    }
}