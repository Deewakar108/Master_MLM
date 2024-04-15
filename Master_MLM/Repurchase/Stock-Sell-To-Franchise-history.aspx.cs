using Master_MLM.App_Code;
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
    public partial class Stock_Sell_To_Franchise_history : System.Web.UI.Page
    {
        string query;
        DataTable dt_add;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["repurchase_user"] == null)
            {
                Session.Abandon();
                Session.Clear();
                Response.Write("<script language=javascript>var wnd=window.open('','newWin','height=1,width=1,left=900,top=700,status=no,toolbar=no,menubar=no,scrollbars=no,maximize=false,resizable=1');</script>");
                Response.Write("<script language=javascript>wnd.close();</script>");
                Response.Write("<script language=javascript>window.open('../Default.aspx','_parent',replace=true);</script>");

            }
            else
            {

                hd_franchis_code.Value = Session["repurchase_user"].ToString();
                if (!IsPostBack)
                {
                    fatch_stock_code_id();
                    dt_add = new DataTable();
                    dt_add.Columns.Add("Stockpoint_code");
                    dt_add.Columns.Add("Distribution");
                    dt_add.Columns.Add("Mrp");
                    dt_add.Columns.Add("BV");
                    dt_add.Columns.Add("Date");

                }
            }
        }

        private void fatch_stock_code_id()
        {
            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select distinct fd.Stock_point_code,fd.Member_name from Re_Franchise_details fd join Re_Product_wise_sell_entery pwse on  pwse.Stockpoint_code=fd.Stock_point_code where pwse.Re_distri_franchise_code='" + hd_franchis_code.Value + "' ", conn);
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
        #region page btn find
        protected void btn_find_Click(object sender, EventArgs e)
        {
            try
            { if (ddl_stockcode.Text == "")
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
            query = "Select distinct Distribution from Re_Product_wise_sell_entery where Stockpoint_code='" + ddl_stockcode.SelectedValue + "' and Re_distri_franchise_code='" + hd_franchis_code.Value + "' ";
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
                panel_view.Visible = false;
            }
            else
            {
                if (dt_add == null)
                {
                    dt_add = new DataTable();
                    dt_add.Columns.Add("Stockpoint_code");
                    dt_add.Columns.Add("Distribution");
                    dt_add.Columns.Add("Mrp");
                    dt_add.Columns.Add("BV");
                    dt_add.Columns.Add("Date");
                }

                int i;
                for (i = 0; i < rowcount; i++)
                {
                    string Distribution_no = dt.Rows[i][0].ToString();
                    string Stockpoint_code = ddl_stockcode.Text;

                    find_all_data(Distribution_no, Stockpoint_code);

                }
                panel_view.Visible = true;
                gridview.DataSource = dt_add;
                gridview.DataBind();
                bind_name();

            }
        }

        private void bind_name()
        {
            Connection con = new Connection();
            string connectinstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectinstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Re_Franchise_details where Stock_point_code ='" + ddl_stockcode.SelectedValue + "' ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_stock_point_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {

            }
            else
            {
                lbl_membername.Text = dt.Rows[0][2].ToString();
                lbl_city.Text = dt.Rows[0][3].ToString();
                lbl_mobileno.Text = dt.Rows[0][5].ToString();
            }
        }

        private void find_all_data(string Distribution_no, string Stockpoint_code)
        {
            double totalamount = 0;
            int totalbv = 0;
            double totaldp = 0;
            string Status = "ADDED";

            query = "Select * from Re_Product_wise_sell_entery  where Stockpoint_code='" + Stockpoint_code + "' and Distribution='" + Distribution_no + "'  and   Status='" + Status + "'  and Re_distri_franchise_code='" + hd_franchis_code.Value + "' ";
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_Product_wise_sell_entery");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
            }
            else
            {
                int i;
                for (i = 0; i < rowcount; i++)
                {

                    totalamount = totalamount + Convert.ToDouble(dt.Rows[i]["Tot_mrp"].ToString());
                    totalbv = totalbv + Convert.ToInt32(dt.Rows[i]["Tot_bv"].ToString());
                    
                }
                string date = dt.Rows[0][8].ToString();
                DataRow drNewRow = dt_add.NewRow();
                drNewRow["Stockpoint_code"] = Stockpoint_code;
                drNewRow["Distribution"] = Distribution_no;
                drNewRow["Mrp"] = totalamount.ToString("F");
                drNewRow["BV"] = totalbv.ToString();
                drNewRow["Date"] = date;
                dt_add.Rows.Add(drNewRow);
                dt_add.AcceptChanges();
            }
        }
        #endregion
    }
}