using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Master_MLM.App_Code;
namespace Master_MLM.Member_4235profile
{
    public partial class Incomedetasils : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    string membrcode = Request.QueryString["mcode"].ToString();
                    string startdate = Request.QueryString["startdate"].ToString();
                    string enddate = Request.QueryString["enddate"].ToString();
                    find_data(membrcode, startdate, enddate);
                    pnl_view.Visible = true;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void find_data(string membrcode, string startdate, string enddate)
        {

            find_repurchase_income(membrcode, startdate, enddate);

        }
        Important imp = new Important();
        private void find_repurchase_income(string membercode, string startdate, string enddate)
        {
            string sql = @" select * from dbo.[Repurchase_payout] where   Member_code='" + membercode + "' and Start_date='" + startdate + "' and End_date='" + enddate + "'";
            DataTable dtTemp = imp.FillTable(sql);
            grd_payout_list.DataSource = dtTemp;
            grd_payout_list.DataBind();
            double total = 0.0;
            int rowcount2 = grd_payout_list.Rows.Count;
            for (int k = 0; k < rowcount2; k++)
            {
                Label lblStatus = (Label)grd_payout_list.Rows[k].FindControl("lblStatus");
                if (lblStatus.Text != "AUTOPAID")
                {
                    Label lblamount = (Label)grd_payout_list.Rows[k].FindControl("lblFinal_amount");
                    if (lblamount.Text != "")
                    {
                        total = total + Convert.ToDouble(lblamount.Text);
                    }
                }
            }
            lbl_total_paout.Text = total.ToString();

        }

     
    }
}