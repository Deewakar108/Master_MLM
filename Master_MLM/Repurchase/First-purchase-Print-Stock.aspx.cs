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
    public partial class First_purchase_Print_Stock : System.Web.UI.Page
    {
        string query;
        #region pageload
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
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
            query = "Select * from First_joining_Franchise_stock_wise_entry RF join First_joining_product PD on RF.Product_id=PD.Product_code where RF.Franchise_code='" + Session["repurchase_user"].ToString() + "' order by RF.Id ASC";


            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_stock_point_stock_wise_entry");
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
                lbl_message.Text = "";
                gridview.DataSource = ds;
                gridview.DataBind();
            }
        }
        #endregion pageload
    }
}