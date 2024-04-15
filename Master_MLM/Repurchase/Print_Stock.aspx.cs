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
    public partial class Print_Stock : System.Web.UI.Page
    {
        string query;
        #region PageloaD
        My mycod = new My();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    fetch_category_name();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void fetch_category_name()
        {
            mycod.bind_all_ddl_with_id_ltst_all(ddl_product_name, "Select Product_name,Product_id from  Product_Details order by Product_name");
        }
        #endregion pageload

        protected void btn_find_Click(object sender, EventArgs e)
        {
            try
            { 
                    fatch_data();
               
            }
            catch (Exception ex)
            {
            }
        }

        private void fatch_data()
        {

            if (ddl_product_name.Text == "All")
            {
                query = "Select * from Re_Franchise_stock_wise_entry RF join Product_Details PD on RF.Product_id=PD.Product_id  where RF.Stockpoint_code='" + Session["repurchase_user"].ToString() + "' order by PD.Product_name ASC";
                final_fatch_data(query);
            }
            else
            {
                query = "Select * from Re_Franchise_stock_wise_entry RF join Product_Details PD on RF.Product_id=PD.Product_id where RF.Stockpoint_code='" + Session["repurchase_user"].ToString() + "' and PD.Product_id='" + ddl_product_name.SelectedValue + "' order by PD.Product_name ASC";
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
                panel_view.Visible = true;
                gridview.DataSource = ds;
                gridview.DataBind();
                 
            }
        }
    }
}