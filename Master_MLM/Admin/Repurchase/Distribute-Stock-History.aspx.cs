using Master_MLM.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Master_MLM.Admin.Repurchase
{
    public partial class Distribute_Stock_History : System.Web.UI.Page
    {
        string query;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fatch_stock_code_id();
            }
        }

        private void fatch_stock_code_id()
        {
            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select Stock_point_code,Member_name from Re_Franchise_details ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_Franchise_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                ddl_stockcode.Items.Insert(0, new ListItem("Select", "Select"));
            }
            else
            {
                ddl_stockcode.DataTextField = ds.Tables[0].Columns["Stock_point_code"].ToString();
                ddl_stockcode.DataValueField = ds.Tables[0].Columns["Stock_point_code"].ToString();

            }
            ddl_stockcode.DataSource = ds.Tables[0];
            ddl_stockcode.DataBind();
            ddl_stockcode.Items.Insert(0, new ListItem("Select", "Select"));
        }
        #region BTN find
        protected void btn_find_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddl_stockcode.Text == "")
                {
                    lbl_message.Text = "Please select stock code";
                }
                else
                {
                    lbl_message.Text = "";
                    fatch_data();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void fatch_data()
        {
            lbl_message.Text = "";

            query = @"select Date,Stockpoint_code,Distribution,sum(cast(Tot_mrp as float)) as Tot_mrp,sum(cast(Tot_bv as float)) as Tot_bv from dbo.[Re_Product_wise_sell_entery] where Stockpoint_code='" + ddl_stockcode.SelectedValue + "' and   Status='ADDED' and Re_distri_franchise_code is null  group by Date,Stockpoint_code,Distribution";
            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_Product_wise_sell_entery");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                lbl_message.Text = "Stock not found......!";
                pnl_franchise_detail.Visible = false;
                panel_view.Visible = false;
            }
            else
            {
                pnl_franchise_detail.Visible = true;
                panel_view.Visible = true;
                gridview.DataSource = dt;
                gridview.DataBind();
                bind_name();

            }
        }

        private void bind_name()
        {
            Connection con = new Connection();
            string connectinstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectinstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Re_Franchise_details where Stock_point_code ='" + ddl_stockcode.SelectedValue + "' and Re_distri_franchise_code is null ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_stock_point_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {

            }
            else
            {
                lbl_membername.Text = dt.Rows[0]["Member_name"].ToString();
                lbl_city.Text = dt.Rows[0]["City"].ToString();
                lbl_mobileno.Text = dt.Rows[0]["Mobileno"].ToString();
            }
        }

        #endregion
    }
}