using Master_MLM.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Master_MLM.Admin
{
    public partial class Member_Notification_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    load_data_in_griedview();
                }
                catch
                {
                }
            }
        }
        private void load_data_in_griedview()
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            DataSet ds = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter("Select * from Member_news order by Id DESC", conn);
            ad.Fill(ds, "NewsTable");
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

                TextBox txtnews = (TextBox)row.FindControl("txt_news");
                TextBox txtdate = (TextBox)row.FindControl("txt_date");

                Connection con = new Connection();
                string connectionstring = con.connect_method();

                SqlConnection conn = new SqlConnection(connectionstring);
                SqlDataAdapter ad = new SqlDataAdapter("select * from Member_news where  id='" + lbl_id.Text + "'", conn);
                DataSet ds = new DataSet();
                ad.Fill(ds, "Member_news");
                DataTable dt = ds.Tables[0];
                int rowcount = dt.Rows.Count;
                if (rowcount == 0)
                {
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        dr["News"] = (txtnews.Text).Replace("'", "&#8217;");
                        dr["Headline"] = (txtnews.Text).Replace("'", "&#8217;"); 
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
            SqlDataAdapter ad = new SqlDataAdapter("select * from Member_news where  id='" + rowid + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_news");
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