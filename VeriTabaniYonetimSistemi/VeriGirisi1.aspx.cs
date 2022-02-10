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
    public partial class VeriGirisi1 : System.Web.UI.Page
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
        private void SetRows()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ToString());
            if (Session["KullaniciAd"] != null)
            {
                string sessionKAd = Session["KullaniciAd"].ToString();


               
                SqlCommand cmd = new SqlCommand(@"SELECT COLUMN_NAME,ORDINAL_POSITION,IS_NULLABLE,DATA_TYPE
                                                FROM INFORMATION_SCHEMA.COLUMNS
                                                WHERE TABLE_SCHEMA='"+ sessionKAd +"' "+ "AND table_name = '"+ ddlTables.SelectedItem.Text+"'", conn);
            conn.Open();
            DataTable dsColumnList = new DataTable();

            dsColumnList.Load(cmd.ExecuteReader());
            string _columnName, _ordinalPosition, _isNullable, _dataType = " ";
            int i = 1;
           DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            DataRow dr = null;
            //BoundField field = new BoundField();
            //field.HeaderText = "Kolon";
            foreach (DataRow item in dsColumnList.Rows)
            {
                _columnName = item["COLUMN_NAME"].ToString();
                _ordinalPosition = item["ORDINAL_POSITION"].ToString();
                _isNullable = item["IS_NULLABLE"].ToString();
                _dataType = item["DATA_TYPE"].ToString();

                    //field.DataField = _columnName;
                    //gvDataInput.Columns.Add(field);
                    //dt.Columns.Add(new DataColumn(_columnName, typeof(string)));

                    string txtKolon = Request.Form["txt_columnName"];             
                    string txtNull = Request.Form["txt_isNullable"];
                    string txtVeriTipi = Request.Form["txt_dataType"];

                   

                    dr = dt.NewRow();

             
                dt.Rows.Add(dr);
                if (_dataType.Contains("varchar")) { TextBox txtBox1 = new TextBox(); }
                else if (_dataType.Contains("int")) { TextBox txtBox2 = new TextBox(); }
                else if (_dataType.Contains("date")) { DateTime txtBox3 = new DateTime(); }

                //gvDataInput.DataSource = ds;
                //gvDataInput.DataBind();

          
           
               //gvDataInput.DataSource = dt;
               //gvDataInput.DataBind();




                    int rowIndex = 0;

                    if (ViewState["CurrentTable"] != null)
                    {
                        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                        DataRow drCurrentRow = null;
                        if (dtCurrentTable.Rows.Count > 0)
                        {
                            for (i = 1; i <= dtCurrentTable.Rows.Count; i++)
                            {

                            

                                TextBox txtKol = (TextBox)gvDataInput.Rows[rowIndex].Cells[1].FindControl("txt_columnName");
                                TextBox txtN = (TextBox)gvDataInput.Rows[rowIndex].Cells[2].FindControl("txt_isNullable");
                                TextBox txtV = (TextBox)gvDataInput.Rows[rowIndex].Cells[3].FindControl("txt_dataType");

                                drCurrentRow = dtCurrentTable.NewRow();
                                //drCurrentRow["RowNumber"] = i + 1;

                                dtCurrentTable.Rows[i - 1]["Column1"] = txtKol.Text;
                                dtCurrentTable.Rows[i - 1]["Column2"] = txtN.Text;
                                dtCurrentTable.Rows[i - 1]["Column3"] = txtV.Text;
                      

                                rowIndex++;
                            }
                         
                            dtCurrentTable.Rows.Add(drCurrentRow);
                            ViewState["CurrentTable"] = dtCurrentTable;

                            gvDataInput.DataSource = dtCurrentTable;
                            gvDataInput.DataBind();
                        }
                    }
                    else
                    {
                        Response.Write("ViewState is null");
                    }
                }
            }






        }


        protected void gvDataInput_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void ddlTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTables.SelectedIndex > 0)
            {

                //set first row
                DataTable dt = new DataTable();
                DataRow dr = null;
                //dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
                dt.Columns.Add(new DataColumn("Column1", typeof(string)));
                dt.Columns.Add(new DataColumn("Column2", typeof(string)));
                dt.Columns.Add(new DataColumn("Column3", typeof(string)));
       
                dr = dt.NewRow();
                //dr["RowNumber"] = 1;
                dr["Column1"] = string.Empty;
                dr["Column2"] = string.Empty;
                dr["Column3"] = string.Empty;
      
                dt.Rows.Add(dr);


                ViewState["CurrentTable"] = dt;

                gvDataInput.DataSource = dt;
                gvDataInput.DataBind();
                SetRows();
            }
            else
            {
                gvDataInput.DataSource = null;
                gvDataInput.DataBind();
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
