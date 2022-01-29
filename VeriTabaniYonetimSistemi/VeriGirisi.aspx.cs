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
    public partial class VeriGirisi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string StrQuery;
            if (Session["KullaniciAd"] != null)
            {
                string sessionKAd = Session["KullaniciAd"].ToString();
                try
                {
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ToString());
                    {
                        SqlCommand cmd = new SqlCommand(@"select schema_name(t.schema_id) as schema_name,
                                                      t.name as table_name,
                                                      t.create_date,
                                                      t.modify_date
                                                      from sys.tables t
                                                      where schema_name(t.schema_id) ='" +sessionKAd+
                                                         "' order by table_name;", conn);

                        conn.Open();
                        DropDownList1.DataSource = cmd.ExecuteReader();
                        DropDownList1.DataBind();
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
