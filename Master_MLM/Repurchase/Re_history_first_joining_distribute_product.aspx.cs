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
    public partial class Re_history_first_joining_distribute_product : System.Web.UI.Page
    {
        string Status = "ADDED";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString.ToString().Contains("Stockpoint_code"))
                {
                    if (Request.QueryString["Stockpoint_code"].ToString() == null)
                    {

                    }
                    else
                    {
                        try
                        {
                            string Stockpoint_code = Request.QueryString["Stockpoint_code"].ToString();
                            string Distribution = Request.QueryString["Distribution"].ToString();

                            fill_gridview(Stockpoint_code, Distribution);
                        }
                        catch (Exception exc)
                        {
                        }
                    }
                }
            }
        }
        private void fill_gridview(string Stockpoint_code, string Distribution)
        {
            string query = "select * from Distribute_first_joining_stock DF join First_joining_product FP on DF.Product_id=FP.Product_code where DF.Stockpoint_code='" + Stockpoint_code + "' and DF.Distribution='" + Distribution + "'  and   DF.Status='" + Status + "' ";

            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "from Distribute_first_joining_stock");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                Panel1.Visible = false;
                grd_view.DataSource = null;
                grd_view.DataBind();


            }
            else
            {
                Panel1.Visible = true;
                grd_view.DataSource = ds;
                grd_view.DataBind();

                int i;
                double totalamount = 0;
                int gridview_rowcount = grd_view.Rows.Count;
                for (i = 0; i < gridview_rowcount; i++)
                {

                    Label lbl_totalmrp = (Label)grd_view.Rows[i].FindControl("lbl_totalmrp");

                    if (lbl_totalmrp.Text != "")
                    {
                        totalamount = totalamount + Convert.ToDouble(lbl_totalmrp.Text);
                    }

                }
                lbl_totalamount.Text = totalamount.ToString();

            }
        }
    }
}