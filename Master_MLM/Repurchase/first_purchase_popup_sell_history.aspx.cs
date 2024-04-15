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
    public partial class first_purchase_popup_sell_history : System.Web.UI.Page
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
                            string Billno = Request.QueryString["Billno"].ToString();
                            string Membercode = Request.QueryString["Membercode"].ToString();
                            fill_gridview(Stockpoint_code, Billno, Membercode);
                        }
                        catch (Exception exc)
                        {
                        }
                    }
                }
            }
        }

        private void fill_gridview(string Stockpoint_code, string Billno, string Membercode)
        {
            string query = @"select * from Fisrt_Purchase_Pro_sell_member_product_wise RP join First_joining_product PD on RP.Product_id=PD.Product_code join CategoryDetails CD on PD.category_id=CD.category_id where RP.Stockpointcode='" + Stockpoint_code + "'  and RP.Membercode='" + Membercode + "' and RP.Bill_no='" + Billno + "' and RP.Status ='ADDED'";

            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "from Re_sell_member_product_wise");
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

                    Label lbl_Mrp = (Label)grd_view.Rows[i].FindControl("lbl_totalmrp");


                    if (lbl_Mrp.Text != "")
                    {
                        totalamount = totalamount + Convert.ToDouble(lbl_Mrp.Text);
                    }
                }
                lbl_totalamount.Text = totalamount.ToString();

            }
        }
    }
}