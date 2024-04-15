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
    public partial class Distribute_stock_via_stock_point_wise : System.Web.UI.Page
    {
        string query;
        #region PAGELOAD
        My mycod = new My();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind_franchise_code();
                fetch_product_name();
            }
        }



        private void Bind_franchise_code()
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
        private void fetch_product_name()
        {
            mycod.bind_all_ddl_with_id_ltst_all(ddl_product, "Select Product_name,Product_id from  Product_Details order by Product_name");

        }
        #endregion pageload

        #region page BTN FIND
        protected void btn_find_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddl_stockcode.Text == "")
                {
                    lbl_message.Text = "Please select stock code";
                }
                else if (ddl_product.Text == "Select")
                {
                    lbl_message.Text = "Please select product name";
                }
                else
                {
                    fatch_data();
                }

            }
            catch (Exception ex)
            {
            }
        }

        private void fatch_data()
        {

            if (ddl_product.Text == "All")
            {
                query = "Select * from Re_Franchise_stock_wise_entry RF join Product_Details PD on RF.Product_id=PD.Product_id  where RF.Stockpoint_code='" + ddl_stockcode.SelectedValue + "' order by PD.Product_name ASC";
                final_fatch_data(query);
            }
            else
            {
                query = "Select * from Re_Franchise_stock_wise_entry RF join Product_Details PD on RF.Product_id=PD.Product_id  where RF.Stockpoint_code='" + ddl_stockcode.SelectedValue + "' and RF.Product_id='" + ddl_product.SelectedValue + "' order by PD.Product_name ASC";
                final_fatch_data(query);
            }
        }

        private void final_fatch_data(string query)
        {
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
                panel_view.Visible = false;
                gridview.DataSource = null;
                gridview.DataBind();
                lbl_message.Text = "Stock not found......!";

            }
            else
            {
                lbl_message.Text = "";
                panel_view.Visible = true;
                gridview.DataSource = ds;
                gridview.DataBind();

                int i;
                double totalbv = 0;
                double totalamount = 0;
                int gridview_rowcount = gridview.Rows.Count;
                for (i = 0; i < gridview_rowcount; i++)
                {
                    Label lbl_BV = (Label)gridview.Rows[i].FindControl("lbl_totBV");
                    Label lbl_Quantity = (Label)gridview.Rows[i].FindControl("lbl_Quantity");
                    Label lbl_totMrp = (Label)gridview.Rows[i].FindControl("lbl_totMrp");

                    if (lbl_BV.Text != "")
                    {
                        totalbv = totalbv + Convert.ToDouble(lbl_BV.Text);
                    }
                    if (lbl_totMrp.Text != "")
                    {
                        totalamount = totalamount + Convert.ToDouble(lbl_totMrp.Text);
                    }

                }
                lbl_totalamount.Text = totalamount.ToString();
                lbl_totalbv.Text = totalbv.ToString();
                fatch_details();
            }
        }

        private void fatch_details()
        {
            query = "Select * from  Re_Franchise_details where Stock_point_code='" + ddl_stockcode.SelectedValue + "' ";
            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
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

        #endregion
    }
}