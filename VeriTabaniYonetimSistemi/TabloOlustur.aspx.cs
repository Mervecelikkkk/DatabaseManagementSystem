using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace VeriTabaniYonetimSistemi
{
    public partial class TabloOlustur : System.Web.UI.Page
    {

        //eklenilen verileri viewstateden kontrol et boş değilse gridview'de olusturulan textbox/listbox nesnelerinden verileri alıp tablo create et.
        protected void tblOlustur_Click(object sender, EventArgs e)
        {
  
            
            string StrQuery;
            if (Session["KullaniciAd"] != null)
            {
                string sessionKAd = Session["KullaniciAd"].ToString();
                try
                {
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ToString());
                    {

                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.Connection = conn;
                            conn.Open();
                            int rowIndex = 0;


                            if (ViewState["CurrentTable"] != null)
                            {
                                DataTable dt = (DataTable)ViewState["CurrentTable"];
                                if (dt.Rows.Count > 0)
                                {

                                    StrQuery = @"CREATE TABLE " +sessionKAd+"."+txtTblAd.Text + "(id int primary key identity(1,1), ";

                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        TextBox txtKolon = (TextBox)gvCreateTable.Rows[rowIndex].Cells[1].FindControl("txtKolonAdi");
                                        ListBox lstVeri = (ListBox)gvCreateTable.Rows[rowIndex].Cells[2].FindControl("lstVeriTipi");
                                        ListBox lstNull = (ListBox)gvCreateTable.Rows[rowIndex].Cells[3].FindControl("lstisNull");

                                        StrQuery += txtKolon.Text + " " + lstVeri.SelectedValue + " " + lstNull.SelectedValue;

                                        if (i != dt.Rows.Count - 1)
                                        {
                                            StrQuery += ",";
                                        }
                                        else
                                        {
                                            StrQuery += ");";
                                        }

                                        rowIndex++;
                                    }

                                    cmd.CommandText = StrQuery;
                                    cmd.ExecuteNonQuery();
                                   
                                   

                                }
                               
                            }


                        }
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Tablo Başarıyla Oluşturuldu.');", true);

                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Bir Hata Oluştu:" + ex.Message.ToString() + "');", true);
                    return;
                }
            }
        }
        //İlk defa postback oluyorsa ilk satırın kolonlarını oluştur. Kolon Adı, Veri Tipi, Null vs..
        private void SetInitialRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Column1", typeof(string)));
            dt.Columns.Add(new DataColumn("Column2", typeof(string)));
            dt.Columns.Add(new DataColumn("Column3", typeof(string)));
            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Column1"] = string.Empty;
            dr["Column2"] = string.Empty;
            dr["Column3"] = string.Empty;
            dt.Rows.Add(dr);

     
            ViewState["CurrentTable"] = dt;

            gvCreateTable.DataSource = dt;
            gvCreateTable.DataBind();
        }

        //Butona click ettiginde yeni bir satır daha ekle.
        //Viewstate'i kontrol et, anlık verileri ekledigin datatable'ı oluşturduğun viewstate'te koy.
        private void AddNewRowToGrid()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                      
                        TextBox txtKolon = (TextBox)gvCreateTable.Rows[rowIndex].Cells[1].FindControl("txtKolonAdi");
                        ListBox lstVeri = (ListBox)gvCreateTable.Rows[rowIndex].Cells[2].FindControl("lstVeriTipi");
                        ListBox lstNull = (ListBox)gvCreateTable.Rows[rowIndex].Cells[3].FindControl("lstisNull");

                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["RowNumber"] = i + 1;

                        dtCurrentTable.Rows[i - 1]["Column1"] = txtKolon.Text;
                        dtCurrentTable.Rows[i - 1]["Column2"] = lstVeri.Text;
                        dtCurrentTable.Rows[i - 1]["Column3"] = lstNull.Text;

                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    gvCreateTable.DataSource = dtCurrentTable;
                    gvCreateTable.DataBind();
                 
                }
              
            }
            else
            {
                Response.Write("ViewState is null");
            }
           
          
            SetPreviousData();
        }
        //Postback olduğunda önceki veriyi viewstate'den alıp textlere yazdır.
        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox txtKolon = (TextBox)gvCreateTable.Rows[rowIndex].Cells[1].FindControl("txtKolonAdi");
                        ListBox lstVeri = (ListBox)gvCreateTable.Rows[rowIndex].Cells[2].FindControl("lstVeriTipi");
                        ListBox lstNull = (ListBox)gvCreateTable.Rows[rowIndex].Cells[3].FindControl("lstisNull");

                        txtKolon.Text = dt.Rows[i]["Column1"].ToString();
                        lstVeri.Text = dt.Rows[i]["Column2"].ToString();
                        lstNull.Text = dt.Rows[i]["Column3"].ToString();

                        rowIndex++;
                    }
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //İlk defa postback oluyorsa ilk satırı oluştur.
            if (!Page.IsPostBack)
            {
                SetInitialRow();

            }
       
            
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid();
    

        }



    }
}