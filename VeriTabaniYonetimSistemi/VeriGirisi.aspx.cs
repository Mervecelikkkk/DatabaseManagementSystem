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
                
                for (int i = 1; i < 5; i++)
                {
                    TextBox txtBox = new TextBox();
                    txtBox.ID = "txt" + "Column" + i;
                    txtBox.Text = "";
                    txtBox.Width = 90;
                    txtBox.Height = 12;
                    txtBox.CssClass = "normal_fields";
                }
          
            }
        }
        private void SetRows()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ToString());

            SqlCommand cmd = new SqlCommand(@"SELECT COLUMN_NAME,ORDINAL_POSITION,IS_NULLABLE,DATA_TYPE
                                                FROM INFORMATION_SCHEMA.COLUMNS
                                                WHERE table_name = 'kullanicilar'", conn);
            conn.Open();
            DataTable dsColumnList = new DataTable();

            dsColumnList.Load(cmd.ExecuteReader());
            string _columnName, _ordinalPosition, _isNullable, _dataType = " ";
            int i = 1;
        DataTable dt = new DataTable();
            DataRow dr = null;
            foreach (DataRow item in dsColumnList.Rows)
            {
                _columnName = item["COLUMN_NAME"].ToString();
                _ordinalPosition = item["ORDINAL_POSITION"].ToString();
                _isNullable = item["IS_NULLABLE"].ToString();
                _dataType = item["DATA_TYPE"].ToString();

                //dt.Columns.Add(new DataColumn(_columnName, typeof(string)));
 
              
                //dr = dt.NewRow();
                if (_dataType.Contains("varchar")) { TextBox txtBox1 = new TextBox(); }
                else if (_dataType.Contains("int")) { TextBox txtBox2 = new TextBox(); }
                else if (_dataType.Contains("date")) { DateTime txtBox3 = new DateTime(); }
                  //dt.Rows.Add(dr);

                //gvDataInput.DataSource = dt;
                //gvDataInput.DataBind();

                //

                int rowIndex = 0;

                if (ViewState["CurrentTable"] != null)
                {
                    DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                    DataRow drCurrentRow = null;
                    if (dtCurrentTable.Rows.Count > 0)
                    {
                        for ( i = 1; i <= dtCurrentTable.Rows.Count; i++)
                        {

                            TextBox txtKolon = (TextBox)gvDataInput.Rows[rowIndex].Cells[1].FindControl("txt_columnName");
                            TextBox txtSira = (TextBox)gvDataInput.Rows[rowIndex].Cells[2].FindControl("txt_ordinalPosition");
                            TextBox txtNull = (TextBox)gvDataInput.Rows[rowIndex].Cells[3].FindControl("txt_isNullable");
                            TextBox txtVeriTipi = (TextBox)gvDataInput.Rows[rowIndex].Cells[4].FindControl("txt_dataType");

                            drCurrentRow = dtCurrentTable.NewRow();
                            //drCurrentRow["RowNumber"] = i + 1;

                            dtCurrentTable.Rows[i - 1]["Column1"] = txtKolon.Text;
                            dtCurrentTable.Rows[i - 1]["Column2"] = txtSira.Text;
                            dtCurrentTable.Rows[i - 1]["Column3"] = txtNull.Text;
                            dtCurrentTable.Rows[i - 1]["Column4"] = txtVeriTipi.Text;

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
      

            lt1.Text = "<table><tr><td>başlık 1</td><td>başlık 2</td><td>başlık 3</td></tr><tr><td>xxx</td><td>yyy</td><td>zzz</td></tr></table>";


            //ddlTables.DataValueField = count.ToString();

            //cmd.ExecuteNonQuery();


            //DataTable dt = new DataTable();
            //int i = 1;
            //DataRow dr = null;
            //dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));


            //dr = dt.NewRow();
            //dr["RowNumber"] = 1;

            //dt.Rows.Add(dr);
            //for (i = 1; i <= count; i++)
            //{


            //    dt.Columns.Add(new DataColumn("Column" + i, typeof(string)));
            //    TextBox txtBox = new TextBox();
            //    txtBox.ID = "txt" + "Column" + i;
            //    txtBox.Text = "";
            //    txtBox.Width = 90;
            //    txtBox.Height = 12;
            //    txtBox.CssClass = "normal_fields";
            //    //container.Controls.Add(txtBox);
            //    //dr["Column"+i] = string.Empty;
            //    //TextBox txt = (TextBox)gvDataInput.Rows[0].Cells[i].FindControl(txtBox.ID);

            //    //dt.Rows[0]["Column+i"] = txt.Text;
            //    gvDataInput.DataSource = dt;
            //    gvDataInput.DataBind();
            //}


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
                dt.Columns.Add(new DataColumn("Column4", typeof(string)));
                dr = dt.NewRow();
                //dr["RowNumber"] = 1;
                dr["Column1"] = string.Empty;
                dr["Column2"] = string.Empty;
                dr["Column3"] = string.Empty;
                dr["Column4"] = string.Empty;
                dt.Rows.Add(dr);


                ViewState["CurrentTable"] = dt;

                gvDataInput.DataSource = dt;
                gvDataInput.DataBind();
                SetRows();
            }
            else
            {
              //gvDataInput.DataSource = null;
              // gvDataInput.DataBind();
            }
        }
    }
}
