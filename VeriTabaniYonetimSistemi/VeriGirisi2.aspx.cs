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
    public partial class VeriGirisi2 : System.Web.UI.Page
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
                            int rowIndex = 0;


                          
                            }
             
                    }
                    catch (Exception ex)
                    {

                    }

                }

                ListItem list = new ListItem("Tablo Seçimi Yapınız", "-1");
                ddlTables.Items.Insert(0, list);



            }
        }
        //static DataTable dt = new DataTable("Shashank");
        static DataSet set = new DataSet("office");
        private void SetRows()
        {


            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ToString());
            if (Session["KullaniciAd"] != null)
            {
                string sessionKAd = Session["KullaniciAd"].ToString();

                SqlCommand cmd = new SqlCommand(@"SELECT COLUMN_NAME,ORDINAL_POSITION,IS_NULLABLE,DATA_TYPE
                                                FROM INFORMATION_SCHEMA.COLUMNS
                                                WHERE TABLE_SCHEMA='" + sessionKAd + "' " + "AND table_name = '" + ddlTables.SelectedItem.Text + "'", conn);
                conn.Open();
                DataTable dsColumnList = new DataTable();

                dsColumnList.Load(cmd.ExecuteReader());
                string _columnName, _ordinalPosition, _isNullable, _dataType = " ";
        
                DataTable dt = new DataTable();
                DataRow dr = null;

                int rowIndex = 0;
                dr = dt.NewRow();
                dt.Rows.Add(dr);
                foreach (DataRow item in dsColumnList.Rows)
                {
                    _columnName = item["COLUMN_NAME"].ToString();
                    _ordinalPosition = item["ORDINAL_POSITION"].ToString();
                    _isNullable = item["IS_NULLABLE"].ToString();
                    _dataType = item["DATA_TYPE"].ToString();
                    TextBox txtKolon = (TextBox)gvDataInput.FindControl("txt_columnName");  
                    dr = dt.NewRow();
                    dt.Rows.Add(dr);
                    for(int i = 0; i <dt.Rows.Count;i++) { 
                      dt.Columns.Add(new DataColumn(_columnName, typeof(string)));
                        gvDataInput.Rows[i].Cells[0].Text= _columnName;
                  }
                    if (_dataType.Contains("varchar")) { TextBox txtBox1 = new TextBox(); }
                    else if (_dataType.Contains("int")) { TextBox txtBox2 = new TextBox(); }
                    else if (_dataType.Contains("date")) { DateTime txtBox3 = new DateTime(); }

                    string txtSira = Request.Form["txt_columnName"];
                    //string txtNull = Request.Form["txt_isNullable"];
                    //string txtVeriTipi = Request.Form["txt_dataType"];


                   
                      
                     
            
                 gvDataInput.DataSource = dt;
                 gvDataInput.DataBind();



             
                }
            









            }

            //gvDataInput.Columns.Clear();

  }

        
        
        
        
        



        protected void ddlTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTables.SelectedIndex > 0)
            {
                SetRows();


            }
        }
       

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            //    if (Session["KullaniciAd"] != null)
            //    {
            //        string sessionKAd = Session["KullaniciAd"].ToString();
            //        try
            //        {
            //            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ToString());
            //            {
            //                SqlCommand cmd = new SqlCommand("INSERT INTO" + sessionKAd + "." + ddlTables.SelectedItem.Text + "( name )VALUES(" + txtKolon + ") ; ", conn);
            //                conn.Open();
            //            cmd.ExecuteNonQuery();

            //       }
            //       }
            //            catch { }
            //}
        }
        }
}


        
        
        
        
 
