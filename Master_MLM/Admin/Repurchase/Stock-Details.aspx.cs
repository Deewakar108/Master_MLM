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
    public partial class Stock_Details : System.Web.UI.Page
    {
        #region PAGELOAD
        string query;
        My mycod = new My();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                query = "Select * from Re_admin_stock_wise_entry RAP join Product_Details PD on RAP.Product_id=PD.Product_id order by PD.Product_name ASC";
                final_fatch_data(query);
                fetch_product();
            }
        }

        private void fetch_product()
        {
            mycod.bind_all_ddl_with_id_ltst_all(ddl_product_name, "Select Product_name,Product_id from  Product_Details order by Product_name");
        }

        private void final_fatch_data(string query)
        {
            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Repurchase_stock_wise_entry");
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.NewRow();
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                panel_view.Visible = false;
                gridview.DataSource = null;
                gridview.DataBind();
                lblmessage.Text = "Sorry, Product does not exist.";
            }
            else
            {

                panel_view.Visible = true; ;
                lblmessage.Text = "";
                ad.Fill(ds);
                gridview.DataSource = ds;
                gridview.DataBind();


                lbl_totalamount.Text = totalamount.ToString();
                lbl_totalbv.Text = totalbv.ToString();
            }
        }
        int totalbv = 0;
        double totalamount = 0;
        protected void gridview_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl_BV = (Label)e.Row.FindControl("lbl_Bv");
                Label lbl_Mrp = (Label)e.Row.FindControl("lbl_Mrp");
                Label lbl_Quantity = (Label)e.Row.FindControl("lbl_Quantity");
                if (lbl_BV.Text != "")
                {
                    totalbv = totalbv + (Convert.ToInt32(lbl_BV.Text) * Convert.ToInt32(lbl_Quantity.Text));
                }
                if (lbl_Mrp.Text != "")
                {
                    totalamount = totalamount + (Convert.ToDouble(lbl_Mrp.Text) * Convert.ToDouble(lbl_Quantity.Text));
                }
            }


        }
        #endregion

        #region Delete
        protected void link_delete_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lnk.Parent.Parent;
            string id = ((Label)row.FindControl("lbl_id")).Text;
            string Product_id = ((Label)row.FindControl("lbl_Product_id")).Text;

            backup_stock(id, Product_id);
            delete_stock(id, Product_id);
            fatch_data();
            lblmessage.Text = "Data has been deleted successfully.";

        }

        Mycode my = new Mycode();
        private void backup_stock(string id, string Product_id)
        {
            string date = DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("dd/MM/yyyy");
            string query = @"insert into Re_admin_product_wise_deleted( [Entry_no],[Product_id],[Mrp] ,[Bv],[Unit],[Gst_perc],[Gst_amt],[Net_Mrp],[Quantity],[Date],[idate],[Status],[Total_mrp], [Total_gst_amt],[Total_net_mrp],[Total_bv],[Deleted_date] ) 
                             select [Entry_no],[Product_id],[Mrp] ,[Bv],[Unit],[Gst_perc],[Gst_amt],[Net_Mrp],[Quantity],[Date],[idate],[Status],[Total_mrp], [Total_gst_amt],[Total_net_mrp],[Total_bv],'" + date + "' from Re_admin_product_wise_enter where Product_id='" + Product_id + "';";

            string query1 = @"insert into Re_admin_stock_wise_deleted(  [Product_id],[Bv],[Quantity],[Mrp],[Delated_date] ) 
                             select [Product_id],[Bv],[Quantity],[Mrp],'" + date + "' from Re_admin_stock_wise_entry where Id='" + id + "'";
            string qry = query + query1;
            Mycode.execute(qry);
        }
        private void delete_stock(string id, string Product_id)
        {
            string query = @"delete from Re_admin_product_wise_enter where Product_id='" + Product_id + "';";
            string query1 = @"delete from Re_admin_stock_wise_entry where Id='" + id + "'";
            string qry = query + query1;
            Mycode.execute(qry);

        }
        #endregion

        #region FindbyproductnamE
        protected void btnfind_Click(object sender, EventArgs e)
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

                query = "Select * from Re_admin_stock_wise_entry RAP join Product_Details PD on RAP.Product_id=PD.Product_id order by PD.Product_name ASC"; 
                final_fatch_data(query);
            }
            else
            {
                query = "Select * from Re_admin_stock_wise_entry RAP join Product_Details PD on RAP.Product_id=PD.Product_id where RAP.Product_id='" + ddl_product_name.SelectedValue + "' order by PD.Product_name ASC"; 
                final_fatch_data(query);
            }
        }
        #endregion
    }
}