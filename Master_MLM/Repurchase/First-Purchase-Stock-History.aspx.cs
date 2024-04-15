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
    public partial class First_Purchase_Stock_History : System.Web.UI.Page
    {
        string query;
        DataTable dt_add;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                fatch_data();
            }
        }

        private void fatch_data()
        {

            query = "select Stockpoint_code,Distribution,Date,sum(cast(Mrp as float)) as 'Mrp',sum(cast(Quantity as float)) as 'Quantity',sum(cast(Total_Mrp as float)) as 'Total_Mrp' from dbo.[Distribute_first_joining_stock]  where Stockpoint_code='" + Session["repurchase_user"].ToString() + "' and Status='ADDED'  group by Stockpoint_code,Distribution,Date";
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