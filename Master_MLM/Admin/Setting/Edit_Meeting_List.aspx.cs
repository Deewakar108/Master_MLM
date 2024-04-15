using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using Master_MLM.App_Code;

namespace Master_MLM.Admin
{
    public partial class Edit_Meeting_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                load_data_in_griedview();
            }
        }

        private void load_data_in_griedview()
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter("Select * from Training_schedule order by id DESC", conn);
            ad.Fill(ds, "Meetings_seminars_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                lblMessage.Text = "Sorry! Data does not exist.";
                grd_edit_news.Visible = false;
            }
            else
            {
                lblMessage.Text = "";
                grd_edit_news.Visible = true;
                grd_edit_news.DataSource = ds;
                grd_edit_news.DataBind();
            }
        }
        #region pageevent
        protected void grd_edit_news_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grd_edit_news.EditIndex = e.NewEditIndex;
            load_data_in_griedview();
            grd_edit_news.DataBind();
        }

        protected void grd_edit_news_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = (GridViewRow)grd_edit_news.Rows[e.RowIndex];
                Label lbl_id = (Label)row.FindControl("lbl_id");
                TextBox txtheading = (TextBox)row.FindControl("txt_heading");
                TextBox txtnews = (TextBox)row.FindControl("txt_news");
                TextBox txtdate = (TextBox)row.FindControl("txt_date");
                TextBox txt_Location = (TextBox)row.FindControl("txt_Location");
                string format2 = "dd/MM/yyyy";
                string d3 = "";
                try
                {
                    lblMessage.Text = "";
                    DateTime d1 = DateTime.ParseExact(txtdate.Text, format2, CultureInfo.InvariantCulture);
                    d3 = d1.ToString("yyyyMMdd");
                    Connection con = new Connection();
                    string connectionstring = con.connect_method();

                    SqlConnection conn = new SqlConnection(connectionstring);
                    SqlDataAdapter ad = new SqlDataAdapter("select * from Training_schedule where  ID='" + lbl_id.Text + "'", conn);
                    DataSet ds = new DataSet();
                    ad.Fill(ds, "Training_schedule");
                    DataTable dt = ds.Tables[0];
                    int rowcount = dt.Rows.Count;
                    if (rowcount == 0)
                    {
                    }
                    else
                    {
                        foreach (DataRow dr in dt.Rows)
                        {

                            dr["Heading"] = txtheading.Text;
                            dr["Training_Details"] = txtnews.Text;
                            dr["Location"] = txt_Location.Text;
                            dr["Date"] = txtdate.Text;
                            SqlCommandBuilder cb = new SqlCommandBuilder(ad);
                            ad.Update(dt);
                            break;
                        }
                        grd_edit_news.EditIndex = -1;
                        load_data_in_griedview();

                    }
                }
                catch
                {
                    lblMessage.Text = "Please enter date is wrong";
                }



            }
            catch
            {

            }
        }

        protected void grd_edit_news_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grd_edit_news.EditIndex = -1;
            load_data_in_griedview();
            grd_edit_news.DataBind();
        }

        protected void grd_edit_news_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_edit_news.PageIndex = e.NewPageIndex;
            load_data_in_griedview();
            grd_edit_news.DataBind();
        }

        protected void imgbtn_delete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)btn.Parent.Parent;
            Label lbl_id = (Label)row.FindControl("lbl_id");
            string rowid = lbl_id.Text;
            delete_news(rowid);
            load_data_in_griedview();
        }

        private void delete_news(string rowid)
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();

            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Training_schedule where  ID='" + rowid + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Meetings_seminars_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dr.Delete();
                    break;
                }
                SqlCommandBuilder cb = new SqlCommandBuilder(ad);
                ad.Update(dt);
            }
        }
        #endregion
    }
}