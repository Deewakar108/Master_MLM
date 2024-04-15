using Master_MLM.App_Code;
using Master_MLM.AppCode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Master_MLM.Repurchase
{
    public partial class Member_Sell_History : System.Web.UI.Page
    {
        string query;
        ClassException ce = new ClassException();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                string date = dtm.ToString("dd/MM/yyyy");

                this.txt_fromdate.Text = date;
                this.txt_todate.Text = date;

            }
        }

        protected void btn_search_by_date_Click(object sender, EventArgs e)
        {
            try
            {
                BindGridview();
                ViewState["flag"] = "1";
            }
            catch (Exception ex)
            {
                ce.submit_exception(ex.ToString());

            }
        }

        private void BindGridview()
        {
            int startdate = Mycode.fetch_idate(txt_fromdate.Text);
            int enddate = Mycode.fetch_idate(txt_todate.Text);

            if (enddate >= startdate)
            {
                query = "Select * from Re_sell_member_bill_wise where Stock_code='" + Session["repurchase_user"].ToString() + "' and Idate>=" + startdate + " and Idate<=" + enddate + "";

                Connection con = new Connection();
                string connstr = con.connect_method();
                SqlConnection coon = new SqlConnection(connstr);
                SqlDataAdapter ad = new SqlDataAdapter(query, coon);
                DataSet ds = new DataSet();
                ad.Fill(ds, "Re_sell_member_bill_wise");
                DataTable dt = ds.Tables[0];
                int rowcount = dt.Rows.Count;
                if (rowcount == 0)
                {
                    lbl_message.Text = "Sorry! no data found.";
                    panel_view.Visible = false;
                    gridview.DataSource = null;
                    gridview.DataBind();
                    gridview.Visible = true;
                }
                else
                {
                    lbl_message.Text = "";
                    panel_view.Visible = true;
                    gridview.DataSource = ds;
                    gridview.DataBind();
                    gridview.Visible = true;
                }
            }
            else
            {
                lbl_message.Text = "To date can't be less than from date.";

            }
        }

        protected void btn_search_by_id_Click(object sender, EventArgs e)
        {
            try
            {
                BindGridview_by_membercode();
                ViewState["flag"] = "2";
            }
            catch (Exception ex)
            {
                ce.submit_exception(ex.ToString());

            }

        }

        private void BindGridview_by_membercode()
        {
            query = "Select * from Re_sell_member_bill_wise where Stock_code='" + Session["repurchase_user"].ToString() + "' and Membercode='" + txt_memberid.Text + "'";

            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter(query, coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_sell_member_bill_wise");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                lbl_message.Text = "Sorry! no data found.";
                panel_view.Visible = false;
                gridview.DataSource = null;
                gridview.DataBind();
                gridview.Visible = true;
            }
            else
            {
                lbl_message.Text = "";
                panel_view.Visible = true;
                gridview.DataSource = ds;
                gridview.DataBind();
                gridview.Visible = true;
            }
        }
    }
}