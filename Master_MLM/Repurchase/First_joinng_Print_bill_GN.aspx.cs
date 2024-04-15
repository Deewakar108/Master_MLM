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
    public partial class First_joinng_Print_bill_GN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string bilno = Request.QueryString["billno"];
                if (!string.IsNullOrEmpty(bilno))
                {
                    hidebillno.Value = bilno;
                    hidememcode.Value = Request.QueryString["mem_code"].ToString();
                    find_data();
                    find_member_details();
                }
            }
        }

        private void find_member_details()
        {
            Connection con = new Connection();
            string connectinstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectinstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Re_Franchise_details where Stock_point_code ='" + hidememcode.Value + "' ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_Franchise_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
            }
            else
            {
                lbl_code.Text = hidememcode.Value;
                lbl_membername.Text = dt.Rows[0][2].ToString();
                lbl_mobileno.Text = dt.Rows[0][5].ToString();
                lbl_address.Text = dt.Rows[0][4].ToString();
            }
        }

        private void find_data()
        {
            string qry = "select * from Fisrt_Purchase_Pro_sell_member_product_wise DF join First_joining_product FD on DF.Product_id=FD.Product_code  where DF.Franchise_code='" + hidememcode.Value + "' and DF.Bill_no='" + hidebillno.Value + "' and  DF.Status='ADDED'";
            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Fisrt_Purchase_Pro_sell_member_product_wise");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
            }
            else
            {

                lbl_invoice_no.Text = hidebillno.Value;
                lbl_invoice_date.Text = dt.Rows[0][8].ToString();

                grdbill.DataSource = ds;
                grdbill.DataBind();

                int i;

                double totalamount = 0;
                int gridview_rowcount = grdbill.Rows.Count;
                for (i = 0; i < gridview_rowcount; i++)
                {
                    //Label lbl_BV = (Label)grdbill.Rows[i].FindControl("lbl_Tot_BV");
                    Label lbl_Sell_price = (Label)grdbill.Rows[i].FindControl("lbl_TotSell_price");
                    //if (lbl_BV.Text != "")
                    //{
                    //    totalbv = totalbv + Convert.ToInt32(lbl_BV.Text);
                    //}
                    if (lbl_Sell_price.Text != "")
                    {
                        totalamount = totalamount + Convert.ToDouble(lbl_Sell_price.Text);
                    }

                }
                lbl_grand_total.Text = totalamount.ToString();
                //lbl_totbv.Text = totalbv.ToString();
            }
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {

            Go_to_print();
        }
        private void Go_to_print()
        {

            Page.ClientScript.RegisterStartupScript(this.GetType(), "printit", "printit()", true);
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Sell-First-Purchase-Product-to-Member.aspx");
        }
    }
}