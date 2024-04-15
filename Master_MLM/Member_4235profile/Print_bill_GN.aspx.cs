using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using Master_MLM.App_Code;

namespace Master_MLM.Member_4235profile
{
    public partial class Print_bill_GN : System.Web.UI.Page
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
            SqlDataAdapter ad = new SqlDataAdapter("select * from Member_registration where Member_code ='" + hidememcode.Value + "' ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
            }
            else
            {
                lbl_code.Text = hidememcode.Value;
                lbl_membername.Text = dt.Rows[0][4].ToString();
                lbl_mobileno.Text = dt.Rows[0][7].ToString();
                lbl_address.Text = dt.Rows[0][14].ToString();
            }
        }

        private void find_data()
        {
            string query = @"select * from Re_sell_member_product_wise RP join Product_Details PD on RP.Product_id=PD.Product_id where RP.Membercode='" + hidememcode.Value + "' and RP.Bill_no='" + hidebillno.Value + "' and RP.Status ='ADDED'";

            Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_sell_member_product_wise");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
            }
            else
            {

                lbl_invoice_no.Text = hidebillno.Value;
                lbl_invoice_date.Text = dt.Rows[0][11].ToString();

                grdbill.DataSource = ds;
                grdbill.DataBind();

                int i;
                int totalbv = 0;
                double totalamount = 0;
                int gridview_rowcount = grdbill.Rows.Count;
                for (i = 0; i < gridview_rowcount; i++)
                {
                    Label lbl_BV = (Label)grdbill.Rows[i].FindControl("lbl_Tot_BV");
                    Label lbl_Sell_price = (Label)grdbill.Rows[i].FindControl("lbl_TotSell_price");
                    if (lbl_BV.Text != "")
                    {
                        totalbv = totalbv + Convert.ToInt32(lbl_BV.Text);
                    }
                    if (lbl_Sell_price.Text != "")
                    {
                        totalamount = totalamount + Convert.ToDouble(lbl_Sell_price.Text);
                    }

                }
                lbl_grand_total.Text = totalamount.ToString();
                lbl_totbv.Text = totalbv.ToString();
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
            Response.Redirect("Sell_Product_to_Member.aspx");
        }
    }
}
