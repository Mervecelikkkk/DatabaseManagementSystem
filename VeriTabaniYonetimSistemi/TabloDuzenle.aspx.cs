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
    public partial class TabloDuzenle : System.Web.UI.Page
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
        public void tableDataEdit()
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ToString());
                {


                    if (Session["KullaniciAd"] != null)
                    {
                        string sessionKAd = Session["KullaniciAd"].ToString();


                        //SqlCommand cmd = new SqlCommand(@" SELECT ORDINAL_POSITION, COLUMN_NAME, IS_NULLABLE, DATA_TYPE from INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='" + sessionKAd + "' " + "AND table_name = '" + ddlTables.SelectedItem.Text + "'", conn);
                        SqlCommand cmd = new SqlCommand(@" SELECT COLUMN_NAME, IS_NULLABLE, DATA_TYPE from INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA='" + sessionKAd + "' " + "AND table_name = '" + ddlTables.SelectedItem.Text + "'", conn);
                  
                        conn.Open();

                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        sda.Fill(ds);
                        gvEdit.DataSource = ds;
                        gvEdit.DataBind();

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
                tableDataEdit();
            }
            else
            {
                gvEdit.DataSource = null;
                gvEdit.DataBind();
            }
        }

        protected void gvEdit_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (Session["KullaniciAd"] != null)
            {
                string sessionKAd = Session["KullaniciAd"].ToString();
                try
                {
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ToString());
                    {
                        GridViewRow row = (GridViewRow)gvEdit.Rows[e.RowIndex];
                        Label lbldeleteid = (Label)row.FindControl("lblID");
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("alter table " + sessionKAd + "." + ddlTables.SelectedItem.Text+ " drop column " + Convert.ToString(gvEdit.DataKeys[e.RowIndex].Value.ToString()), conn);
                 
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        tableDataEdit();
                    }
        }
                catch
                {

                }
        }
          
        }
        protected void gvEdit_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvEdit.EditIndex = e.NewEditIndex;
            tableDataEdit();
        }
        protected void gvEdit_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (Session["KullaniciAd"] != null)
            {
                string sessionKAd = Session["KullaniciAd"].ToString();
                try
                {
                    string columnName = Convert.ToString(gvEdit.DataKeys[e.RowIndex].Value.ToString());
                    GridViewRow row = (GridViewRow)gvEdit.Rows[e.RowIndex];
                    Label lblID = (Label)row.FindControl("lblID");
                    TextBox colname = (TextBox)row.Cells[2].Controls[0];
                    TextBox dataType = (TextBox)row.Cells[3].Controls[0];
                    TextBox isNull = (TextBox)row.Cells[4].Controls[0];
                    gvEdit.EditIndex = -1;
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCS"].ToString());
                    {

                        conn.Open();
                        //SqlCommand cmd = new SqlCommand("update detail set name='" + colname.Text + "',address='" + dataType.Text + "',country='" + isNull.Text + "'where id='" + userid + "'", conn);
                        //cmd.ExecuteNonQuery();
                        conn.Close();
                        tableDataEdit();

                    }

                }
                catch { }
        }
        }
        protected void gvEdit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEdit.PageIndex = e.NewPageIndex;
            tableDataEdit();
        }
        protected void gvEdit_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvEdit.EditIndex = -1;
            tableDataEdit();
        }
    }
}