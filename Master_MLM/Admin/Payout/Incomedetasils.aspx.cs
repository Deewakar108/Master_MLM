using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using Master_MLM.App_Code;
namespace Master_MLM.Admin46gt64
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

            find_binary_income(membrcode, startdate, enddate);

            find_royalty_income(membrcode, startdate, enddate);
            //find_cto_income(membrcode, startdate, enddate);

            find_referral_income(membrcode, startdate, enddate);

            //find_salaryincome(membrcode, startdate, enddate);

        }

        private void find_referral_income(string membercode, string startdate, string enddate)
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            string sql = "Select * from payout where ClosingType='Referral' and  Member_code='" + membercode + "' and  CONVERT(DATETIME, Start_date, 103) between  " +
                         "CONVERT(DATETIME,'" + startdate + "', 103) and  CONVERT(DATETIME,'" + enddate + "', 103)";
            SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "payout");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {

                grdReferral.DataSource = null;
                grdReferral.DataBind();
            }
            else
            {

                grdReferral.DataSource = ds;
                grdReferral.DataBind();

                double total = 0.0;
                int rowcount2 = grdReferral.Rows.Count;

                for (int k = 0; k < rowcount2; k++)
                {
                    Label lblStatus = (Label)grdReferral.Rows[k].FindControl("lblStatus");
                    if (lblStatus.Text != "AUTOPAID")
                    {
                        Label lblamount = (Label)grdReferral.Rows[k].FindControl("lbl_Grand_total");
                        if (lblamount.Text != "")
                        {
                            total = total + Convert.ToDouble(lblamount.Text);
                        }
                    }
                }
                lblReferral.Text = total.ToString();
            }
        }

        private void find_binary_income(string membercode, string startdate, string enddate)
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            string sql = "Select * from payout where ClosingType='Sponsor' and  Member_code='" + membercode + "' and CONVERT(DATETIME, Start_date, 103) between  CONVERT(DATETIME,'" + startdate +
                "', 103) and  CONVERT(DATETIME,'" + enddate + "', 103)";
            SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "payout");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {

                grd_payout_list.DataSource = null;
                grd_payout_list.DataBind();
            }
            else
            {

                grd_payout_list.DataSource = ds;
                grd_payout_list.DataBind();

                double total = 0.0;
                int rowcount2 = grd_payout_list.Rows.Count;

                for (int k = 0; k < rowcount2; k++)
                {
                    Label lblStatus = (Label)grd_payout_list.Rows[k].FindControl("lblStatus");
                    if (lblStatus.Text != "AUTOPAID")
                    {
                        Label lblamount = (Label)grd_payout_list.Rows[k].FindControl("lbl_Grand_total");
                        if (lblamount.Text != "")
                        {
                            total = total + Convert.ToDouble(lblamount.Text);
                        }
                    }
                }
                lbl_total_paout.Text = total.ToString();
            }
        }

        private void find_royalty_income(string membercode, string startdate, string enddate)
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            string sql = "Select * from payout where ClosingType='Royalty' and  Member_code='" + membercode + "' and CONVERT(DATETIME, Start_date, 103) between  CONVERT(DATETIME,'" + startdate +
             "', 103) and  CONVERT(DATETIME,'" + enddate + "', 103)";
            SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "payout");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {

                grdRoyalty.DataSource = null;
                grdRoyalty.DataBind();
            }
            else
            {

                grdRoyalty.DataSource = ds;
                grdRoyalty.DataBind();

                double total = 0.0;
                int rowcount2 = grdRoyalty.Rows.Count;

                for (int k = 0; k < rowcount2; k++)
                {
                    Label lblStatus = (Label)grdRoyalty.Rows[k].FindControl("lblStatus");
                    if (lblStatus.Text != "AUTOPAID")
                    {
                        Label lblamount = (Label)grdRoyalty.Rows[k].FindControl("lbl_Grand_total");
                        if (lblamount.Text != "")
                        {
                            total = total + Convert.ToDouble(lblamount.Text);
                        }
                    }
                }
                lblRoyalty.Text = total.ToString();
            }
        }

        private void find_cto_income(string membercode, string startdate, string enddate)
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            string sql = "Select * from payout where ClosingType='CTO' and  Member_code='" + membercode + "' and Start_date = '" + startdate + "' and End_date='" + enddate + "'";
            SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "payout");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {

                grdCTO.DataSource = null;
                grdCTO.DataBind();
            }
            else
            {

                grdCTO.DataSource = ds;
                grdCTO.DataBind();

                double total = 0.0;
                int rowcount2 = grdCTO.Rows.Count;

                for (int k = 0; k < rowcount2; k++)
                {
                    Label lblStatus = (Label)grdCTO.Rows[k].FindControl("lblStatus");
                    if (lblStatus.Text != "AUTOPAID")
                    {
                        Label lblamount = (Label)grdCTO.Rows[k].FindControl("lbl_Grand_total");
                        if (lblamount.Text != "")
                        {
                            total = total + Convert.ToDouble(lblamount.Text);
                        }
                    }
                }
                lblCTO.Text = total.ToString();
            }
        }

        private void find_salaryincome(string membercode, string startdate, string enddate)
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            //SqlDataAdapter ad = new SqlDataAdapter("Select * from daily_member_salary where Membercode='" + membercode + "' and Start_date = '" + startdate + "' and End_date='" + enddate + "'", conn);
            string sql = "Select * from payout where ClosingType='Spill' and   Member_code='" + membercode + "' and Start_date = '" + startdate + "' and End_date='" + enddate + "'";
            SqlDataAdapter ad = new SqlDataAdapter(sql, conn);

            DataSet ds = new DataSet();
            ad.Fill(ds, "Bank_payout_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {


                grd_spill.DataSource = null;
                grd_spill.DataBind();
            }
            else
            {


                grd_spill.DataSource = ds;
                grd_spill.DataBind();

                double total = 0.0;
                int rowcount2 = grd_spill.Rows.Count;

                for (int k = 0; k < rowcount2; k++)
                {

                    Label lblamount = (Label)grd_spill.Rows[k].FindControl("lbl_Grand_total");
                    if (lblamount.Text != "")
                    {
                        total = total + Convert.ToDouble(lblamount.Text);
                    }
                }
                lbl_salary.Text = total.ToString();
            }
        }
    }
}