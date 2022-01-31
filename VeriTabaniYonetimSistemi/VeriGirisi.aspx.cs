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
    public partial class VeriGirisi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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
                    }
                }
                catch (Exception ex)
                {

                }
            }

            ListItem list = new ListItem("Tablo Seçimi Yapınız", "-1");
            ddlTables.Items.Insert(0, list);
            SetRows();


        }
        private void SetRows()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ToString());

            SqlCommand cmd = new SqlCommand(@"SELECT COUNT(*)
  FROM INFORMATION_SCHEMA.COLUMNS
 WHERE table_name = 'kullanicilar'", conn);
            conn.Open();
            Int32 count = (Int32)cmd.ExecuteScalar();

            ddlTables.DataValueField = count.ToString();

            cmd.ExecuteNonQuery();


            DataTable dt = new DataTable();
            int i = 1;
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
           
            
            dr = dt.NewRow();
            dr["RowNumber"] = 1;

            dt.Rows.Add(dr);
            for ( i = 1; i < count; i++)
            {

             
                dt.Columns.Add(new DataColumn("Column"+i, typeof(string)));
                dr["Column"+i] = string.Empty;

                gvDataInput.DataSource = dt;
                gvDataInput.DataBind();
            }


        }
    }
}
