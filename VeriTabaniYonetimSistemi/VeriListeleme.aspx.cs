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
    public partial class VeriListeleme : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
                                                      where schema_name(t.schema_id) ='" + sessionKAd +
                                                          "' order by table_name;", conn);

                            conn.Open();
                            ddlTables.DataSource = cmd.ExecuteReader();
                            ddlTables.DataBind();
                            ListItem itemSelect = new ListItem("Tablo Seçimi Yapınız", "-1");
                            ddlTables.Items.Insert(0, itemSelect);
                        }
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Bir Hata Oluştu:" + ex.Message.ToString() + "');", true);
                        return;
                    }
                }
            }
        }

        public void tableDataList()
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ToString());
                {


                    if (Session["KullaniciAd"] != null)
                    {
                        string sessionKAd = Session["KullaniciAd"].ToString();


                        SqlCommand cmd = new SqlCommand(@"select * from " + sessionKAd + "." + ddlTables.SelectedItem.Text, conn);

                        conn.Open();

                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        gvList.DataSource = ds;
                        gvList.DataBind();

                        conn.Close();
                    }
                }
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Bir Hata Oluştu:" + ex.Message.ToString() + "');", true);
                return;
            }
        }

        protected void ddlTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTables.SelectedIndex > 0)
            {
                tableDataList();
            }
            else
            {
                gvList.DataSource = null;
                gvList.DataBind();
            }
        }

    }
}







