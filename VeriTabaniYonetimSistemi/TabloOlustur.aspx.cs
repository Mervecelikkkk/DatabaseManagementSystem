using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace VeriTabaniYonetimSistemi
{
    public partial class TabloOlustur : System.Web.UI.Page
    {


        protected void tblOlustur_Click(object sender, EventArgs e)
        {

            string StrQuery;
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ToString());
                {
                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        conn.Open();
                        int rowIndex = 0;
                        if (ViewState["CurrentTable"] != null)
                        {
                            DataTable dt = (DataTable)ViewState["CurrentTable"];
                            if (dt.Rows.Count > 0)
                            {
                                StrQuery = @"CREATE TABLE " + txtTblAd.Text + "(id int primary key identity(1,1), kullaniciid int, ";

                                for (int i = 0; i < dt.Rows.Count; i++)
                                {
                                    TextBox txt1 = (TextBox)Gridview1.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                                    ListBox lst1 = (ListBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("ListBox1");
                                    ListBox lst2 = (ListBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("ListBox2");

                                    StrQuery += txt1.Text + " " + lst1.SelectedValue + " " + lst2.SelectedValue;

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

                                comm.CommandText = StrQuery;
                                comm.ExecuteNonQuery();

                            }
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Message", "alert('Bir Hata Oluştu:" + ex.Message.ToString() + "');", true);
                return;
            }
         
        }

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

            Gridview1.DataSource = dt;
            Gridview1.DataBind();
        }

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
                      
                        TextBox txt1 = (TextBox)Gridview1.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                        ListBox lst1 = (ListBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("ListBox1");
                        ListBox lst2 = (ListBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("ListBox2");

                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["RowNumber"] = i + 1;

                        dtCurrentTable.Rows[i - 1]["Column1"] = txt1.Text;
                        dtCurrentTable.Rows[i - 1]["Column2"] = lst1.Text;
                        dtCurrentTable.Rows[i - 1]["Column3"] = lst2.Text;

                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    Gridview1.DataSource = dtCurrentTable;
                    Gridview1.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }

            //Set Previous Data on Postbacks
            SetPreviousData();
        }
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
                        TextBox txt1 = (TextBox)Gridview1.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                        ListBox lst1 = (ListBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("ListBox1");
                        ListBox lst2 = (ListBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("ListBox2");

                        txt1.Text = dt.Rows[i]["Column1"].ToString();
                        lst1.Text = dt.Rows[i]["Column2"].ToString();
                        lst2.Text = dt.Rows[i]["Column3"].ToString();

                        rowIndex++;
                    }
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
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