using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using System.Net;
using Master_MLM.App_Code;

namespace Master_MLM.Admin_87554b
{
    public partial class Repurchase_Make_payment : System.Web.UI.Page
    {
        string scrpt;
        Important imp = new Important();

        string ClosingType = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            ClosingType = "'SELF INCOME','MATCHING INCOME'";
            if (!IsPostBack)
            {
                DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                string date = dtm.ToString("dd/MM/yyyy");
                Session["today"] = date;
                find_startdate();
            }
        }

        private void find_startdate()
        {
            ArrayList ar1 = new ArrayList();
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select Satartdate from Repurchase_Bankpayout_made_details order by ID DESC ", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Repurchase_Bankpayout_made_details");
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count == 0)
            {
            }
            else
            {
                ar1.Add("Select");
                foreach (DataRow dr in dt.Rows)
                {
                    ar1.Add(dr[0].ToString());
                }
                ddl_s_date.DataSource = ar1;
                ddl_s_date.DataBind();

            }
        }

        protected void ddl_s_date_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArrayList ar1 = new ArrayList();
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select Enddate from Repurchase_Bankpayout_made_details where Satartdate='" + ddl_s_date.Text + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Repurchase_Bankpayout_made_details");
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count == 0)
            {
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ar1.Add(dr[0].ToString());
                }
                ddl_e_date.DataSource = ar1;
                ddl_e_date.DataBind();
            }
        }

        #region find data

        protected void btn_find_Click(object sender, EventArgs e)
        {
            if (ddl_s_date.Text == "Select")
            {
                lbl_message.Text = "Please select start Date";
                scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
            }
            else
            {
                fill_giidview();
            }
        }

        private void fill_giidview()
        {
            string status = "NOTPAID";
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select Bank_name, Branch_name, Ifsc_code, Account_number, * from Repurchase_Bank_payout_details bpd join Member_registration mr on bpd.Membercode=mr.Member_code   where bpd.Startdate='" + ddl_s_date.Text + "' and bpd.Enddate ='" + ddl_e_date.Text + "' and bpd.Status='" + status + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Repurchase_Bank_payout_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                pnl_view.Visible = false;
                lbl_message.Text = "Sorry! no data found.";
                scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
                grd_payout_list.DataSource = null;
                grd_payout_list.DataBind();
                grd_payout_list.Visible = true;
            }
            else
            {
                pnl_view.Visible = true;
                grd_payout_list.DataSource = ds;
                grd_payout_list.DataBind();
                grd_payout_list.Visible = true;

                double total = 0.0;
                int rowcount2 = grd_payout_list.Rows.Count;

                for (int k = 0; k < rowcount2; k++)
                {

                    Label lblamount = (Label)grd_payout_list.Rows[k].FindControl("lbl_Grand_total");
                    if (lblamount.Text != "")
                    {
                        total = total + Convert.ToDouble(lblamount.Text);
                    }
                }
                lbl_total_paout.Text = total.ToString();
            }

        }

        #endregion find data

        #region make payment

        protected void btn_pay_Click(object sender, EventArgs e)
        {
            int grdcount = grd_payout_list.Rows.Count;
            for (int i = 0; i < grdcount; i++)
            {
                Label lbl_Member_code = (Label)grd_payout_list.Rows[i].FindControl("lbl_Member_code");
                Label lbl_Mobileno = (Label)grd_payout_list.Rows[i].FindControl("lbl_Mobileno");
                Label lbl_Name = (Label)grd_payout_list.Rows[i].FindControl("lbl_Name");
                Label lbl_Netmount = (Label)grd_payout_list.Rows[i].FindControl("lbl_Grand_total");

                Label lbl_id = (Label)grd_payout_list.Rows[i].FindControl("lbl_id");
                CheckBox check = (CheckBox)grd_payout_list.Rows[i].FindControl("rowChkBox");
                string membercode = lbl_Member_code.Text;
                string id = lbl_id.Text;
                if (check.Checked == true)
                {
                    update_bank_payout_details_table(membercode, id, lbl_Netmount.Text);
                    update_payout_paid(membercode);// update payout status
                    string message = "Dear  " + lbl_Name.Text + ", Member ID:- " + membercode + ", Your Repurchase Payout Rs. " + lbl_Netmount.Text +
                              " has been transferred to your Account. Thanks. " + imp.Url;
                    sms_sender.send_message(lbl_Mobileno.Text, message, membercode);   // send sms
                }
            }

            lbl_message.Text = "Payment has been done.";
            scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
            fill_giidview();
        }

        private void update_bank_payout_details_table(string membercode, string id, string Amount)
        {

            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dtm.ToString("dd/MM/yyyy");
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from Repurchase_Bank_payout_details where Membercode='" + membercode + "' and Id ='" + id + "' ", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Repurchase_Bank_payout_details");
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dr["Status"] = "PAID";
                    dr["Paiddate"] = date;
                    SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
                    ad.Update(dt);
                }
            }
        }

        private void update_payout_paid(string membercode)
        {
            DateTime dtTempDate = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Update Repurchase_payout set Paid_date='" + dtTempDate.ToString("dd/MM/yyyy") + "', Status='PAID' where Member_code='" + membercode +
                "' and  Income_type in (" + ClosingType + ")  and Status='NOTPAID' and Start_date='" + ddl_s_date.Text + "' and End_date='" + ddl_e_date.Text + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "payout");
        }



        #endregion make payment

        #region export_gridview_in_excel
        protected void img_expord_Click(object sender, ImageClickEventArgs e)
        {
            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dtm.ToString("dd/MM/yyyy");
            Session["today"] = date;
            string excelname = Session["today"].ToString() + "datas.xls";
            export_to_excel(grd_payout_list, excelname);
        }

        private void export_to_excel(GridView grd_view, string excelname)
        {
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", excelname));
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            grd_view.AllowPaging = false;

            grd_view.HeaderRow.Style.Add("background-color", "#FFFFFF");
            for (int a = 0; a < grd_view.HeaderRow.Cells.Count; a++)
            {
                grd_view.HeaderRow.Cells[a].Style.Add("background-color", "#507CD1");
            }
            int j = 1;
            foreach (GridViewRow gvrow in grd_view.Rows)
            {
                grd_view.BackColor = Color.White;
                if (j <= grd_view.Rows.Count)
                {
                    if (j % 2 != 0)
                    {
                        for (int k = 0; k < gvrow.Cells.Count; k++)
                        {
                            gvrow.Cells[k].Style.Add("background-color", "#EFF3FB");
                        }
                    }
                }
                j++;
            }
            grd_view.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();


        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        #endregion export_gridview_in_excel
    }
}
