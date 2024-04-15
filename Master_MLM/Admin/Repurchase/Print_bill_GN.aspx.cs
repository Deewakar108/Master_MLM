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
                    string fran_code = Request.QueryString["fran_code"].ToString();
                    find_data(fran_code);
                    find_franchise_details(fran_code);
                    
                }
            }
        }

        private void find_franchise_details(string fran_code)
        {
            Connection con = new Connection();
            string connectinstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectinstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Re_Franchise_details where Stock_point_code ='" + fran_code + "' ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_Franchise_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
            }
            else
            {
                lbl_code.Text = fran_code;
                lbl_membername.Text = dt.Rows[0][2].ToString();
                lbl_mobileno.Text = dt.Rows[0][5].ToString();
                lbl_address.Text = dt.Rows[0][4].ToString();
            }
        }


        private void find_data(string fran_code)
        {
              Connection con = new Connection();
            string Connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(Connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Re_Product_wise_sell_entery RP join Product_Details PD on RP.Product_id=PD.Product_id where RP.Stockpoint_code='" + fran_code + "' and RP.Distribution='" + hidebillno.Value + "' and RP.Status ='ADDED'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Re_Product_wise_sell_entery");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
            }
            else
            {

                lbl_invoice_no.Text = hidebillno.Value;
                lbl_invoice_date.Text = dt.Rows[0][7].ToString();

                grdbill.DataSource = ds;
                grdbill.DataBind();

                int i;
                int totalbv = 0;
                double totalamount = 0;
                int gridview_rowcount = grdbill.Rows.Count;
                for (i = 0; i < gridview_rowcount; i++)
                {
                    Label lbl_BV = (Label)grdbill.Rows[i].FindControl("lbl_totbv");
                    Label lbl_price = (Label)grdbill.Rows[i].FindControl("lbl_grand_total");
                    if (lbl_BV.Text != "")
                    {
                        totalbv = totalbv + Convert.ToInt32(lbl_BV.Text);
                    }
                    if (lbl_price.Text != "")
                    {
                        totalamount = totalamount + Convert.ToDouble(lbl_price.Text);
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
            Response.Redirect("Distribute-Stock.aspx");
        }
    }
}