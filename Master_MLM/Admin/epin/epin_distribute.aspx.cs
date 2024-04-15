﻿using System;
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
using Master_MLM.App_Code;


namespace Master_MLM.Admin
{
    public partial class epin_distribute : System.Web.UI.Page
    {
        Important imp = new Important();
        //#region pageload
        My mycode = new My();
        string scrpt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["CheckReferesh"] = Server.UrlDecode(System.DateTime.Now.ToString());
                DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                string date = dtm.ToString("dd/MM/yyyy");
                Session["today"] = date;
                find_package();
            }
            
            if (ViewState["DistributedTable"] == null) { CreateViewStateTable(); }
        }

        public void CreateViewStateTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("PackageName", typeof(string));
            dt.Columns.Add("Amount", typeof(string));
            dt.Columns.Add("Quantity", typeof(string));
            dt.Columns.Add("TotalAmount", typeof(string));
            dt.Columns.Add("ID", typeof(string));

            ViewState["DistributedTable"] = dt;

            BindGridView(dt);
        }

        public void BindGridView(DataTable dt)
        {
            grdDistributedPin.DataSource = dt;
            grdDistributedPin.EmptyDataText = "No Record Found.";
            grdDistributedPin.DataBind();

            //Calculate Amount
            double amt = 0;
            foreach (DataRow dr in dt.Rows)
            {
                amt = amt + double.Parse(dr["TotalAmount"].ToString());
            }
            lblTotal.Text = amt.ToString("0.00");

            BindSlip(dt);
        }

        public void BindSlip(DataTable dt)
        {
            grdSlip.DataSource = dt;
            grdSlip.EmptyDataText = "No Record Found.";
            grdSlip.DataBind();

            //Calculate Amount
            double amt = 0;
            foreach (DataRow dr in dt.Rows)
            {
                amt = amt + double.Parse(dr["TotalAmount"].ToString());
            }
            lblTotalAmountSlip.Text = amt.ToString("0.00");
        }

        private void find_package()
        {
            mycode.bind_all_ddl_with_id(ddl_package, "Select Package_name,Package_id from Joining_package ORDER BY Package_name", "Package_name", "Package_id");
        }

        public bool CheckQuantity(int Quantity, string Package)
        {
            string sql = "select * from E_PIN_details where Package='" + Package + "' and Status='GENERATED'";
            DataTable dt = imp.FillTable(sql);
            if (dt.Rows.Count < Quantity) { return true; }
            return false;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (ddl_package.SelectedValue == "Select") { AlertMe("Please select Package."); return; }
            if (txtAmount.Text.Trim() == "") { AlertMe("Invalid Amount."); return; }
            if (txtQuantity.Text.Trim() == "" || txtQuantity.Text.Trim() == "0") { AlertMe("Invalid Quantity."); return; }
            if (int.Parse(txtQuantity.Text.Trim()) <= 0) { AlertMe("Invalid Quantity."); return; }

            DataTable dtTemp = (DataTable)ViewState["DistributedTable"];

            DataRow[] dr = dtTemp.Select("PackageName='" + ddl_package.SelectedItem.Text + "'");
            if (dr.Length == 0) 
            {
                if (CheckQuantity(int.Parse(txtQuantity.Text), ddl_package.SelectedItem.Text)) { AlertMe("Pin Quantity does not exist."); return; }
                double total = int.Parse(txtAmount.Text) * int.Parse(txtQuantity.Text);
                string ID = DateTime.Now.ToString("yyyyMMddhhmmss");
                dtTemp.Rows.Add(ddl_package.SelectedItem.Text, txtAmount.Text, txtQuantity.Text, (total).ToString(), ID);
                ClearAll();
                BindGridView(dtTemp);
            }
            else 
            {
                AlertMe("Package Already Exist.");
            }
        }

        public void ClearAll() 
        {
            ddl_package.SelectedValue = "Select";
            txtAmount.Text = "";
            txtQuantity.Text = "";
            txtAvailableQuantity.Text = "";
        }

        public void AlertMe(string Message)
        {
            lblMessage.Text = Message;
            scrpt = "<script>$(document).ready( function () { $('#gritter-notice-wrapper1').show().fadeOut(5000); });</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "AlertMe();", true);
        }

        protected void ddl_package_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select Package_amount, (select count(*) as Quantity from E_PIN_details where Status='GENERATED' and Package=Package_name) as Quantity  from Joining_package where Package_name='" + ddl_package.SelectedItem.Text + "'";
            DataTable dt = imp.FillTable(sql);
            if (dt.Rows.Count != 0) { txtAmount.Text = dt.Rows[0]["Package_amount"].ToString(); txtAvailableQuantity.Text = dt.Rows[0]["Quantity"].ToString(); }
            else { txtAmount.Text = ""; AlertMe("Package Not Exist."); }
        }

        protected void grdDistributedPin_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "IsDelete") 
            {
                string ID = e.CommandArgument.ToString();

                DataTable dtTemp = (DataTable)ViewState["DistributedTable"];
                DataRow[] dr = dtTemp.Select("ID='" + ID + "'");
                if (dr.Length != 0) { dtTemp.Rows.Remove(dr[0]); BindGridView(dtTemp); }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string TransactionID = "REL" + DateTime.Now.ToString("yyyyMMddhhmmss");

            DataTable dtTemp = (DataTable)ViewState["DistributedTable"];
            if (dtTemp.Rows.Count == 0) { AlertMe("Empty package submitted."); return; }
            if (txtMemberCode.Text == "") { AlertMe("Invalid Member Code."); return; }
            if (lblMemberName.Text == "") { AlertMe("Invalid Member Code."); return; }

            foreach (DataRow dr in dtTemp.Rows)
            {
                string Package = dr["PackageName"].ToString();
                string Quantity = dr["Quantity"].ToString();
                string date = DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("dd/MM/yyyy");
                string sql = "update E_PIN_details set distributed_to='" + txtMemberCode.Text + "', distribution_date='" + date +
                             "', Status='GIVEN', TransactionID='" + TransactionID + "' where Epin in (select top " + Quantity + " Epin from E_PIN_details where Status='GENERATED' and Package='" + Package + "')";
                int i = imp.InsertUpdateDelete(sql);
            }

            lblMemberName.Text = lblMemberName.Text;
            lbl_code.Text = txtMemberCode.Text;
            lblTransactionID.Text = TransactionID;
            lblDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            BindSlip(dtTemp);
            Panel1.Visible = false;
            Panel2.Visible = true;
            
            AlertMe("E-Pin successfully distributed.");
        }

        protected void btnMemberFind_Click(object sender, EventArgs e)
        {
            string sql = "select * from Member_registration where Member_code='" + txtMemberCode.Text + "'";
            DataTable dt = imp.FillTable(sql);
            if (dt.Rows.Count != 0) { txtMemberCode.Enabled = false; lblMemberName.Text = dt.Rows[0]["Member_name"].ToString(); }
            else { AlertMe("Invalid Member Code."); }
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "printit", "printit()", true);
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            ViewState["DistributedTable"] = null;
            CreateViewStateTable();
            lblMemberName.Text = "";
            txtMemberCode.Text = "";
            txtMemberCode.Enabled = true;
            Response.Redirect(Request.Url.PathAndQuery);
        }

        //private void fetch_epin_list()
        //{
        //    string status1 = "GENERATED";
        //    Connection con = new Connection();
        //    string connstr = con.connect_method();
        //    SqlConnection coon = new SqlConnection(connstr);
        //    SqlDataAdapter ad = new SqlDataAdapter("Select * from E_PIN_details where Status='" + status1 + "' and  Package_id='" + ddl_package.SelectedValue + "'", coon);
        //    DataSet ds = new DataSet();
        //    ad.Fill(ds, "E_PIN_details");
        //    DataTable dt = ds.Tables[0];
        //    int rowcount = dt.Rows.Count;
        //    if (rowcount == 0)
        //    {
        //        lbl_message.Text = "All pins are distributed or Pin is not generated. Please Gnerate E-pin";
        //        Panel1.Visible = false;

        //        grd_epin_distribute.DataSource = null;
        //        grd_epin_distribute.DataBind();
        //    }
        //    else
        //    {
        //        lbl_message.Text = "";
        //        Panel1.Visible = true;
        //        grd_epin_distribute.DataSource = ds;
        //        grd_epin_distribute.DataBind();
        //    }
        //}
        //#endregion
        //protected void Page_Prerender(object sender, EventArgs e)
        //{
        //    if (Session["CheckReferesh"] != null)
        //    {
        //        ViewState["CheckReferesh"] = Session["CheckReferesh"].ToString();
        //    }
        //}
        //#region pageevent
        //protected void grd_epin_distribute_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    grd_epin_distribute.PageIndex = e.NewPageIndex;
        //    grd_epin_distribute.DataBind();
        //    fetch_epin_list();
        //}
        ////protected void chk_check_pin_CheckedChanged(object sender, EventArgs e)
        ////{
        ////    CheckBox chk = (CheckBox)sender;

        ////    if (chk.Checked == true)
        ////    {
        ////        Panel1.Visible = true;
        ////        btn_distribute.Enabled = true;

        ////    }
        ////    else
        ////    {
        ////        Panel1.Visible = false;
        ////        btn_distribute.Enabled = false;
        ////    }
        ////}
        //#endregion

        //#region pagesubmit
        //protected void btn_distribute_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        if (txt_member_name.Text == "")
        //        {
        //            lbl_message.Text = "Please fill member code and click find button.";
        //        }
        //        else
        //        {
        //            bool validcode = check_membercode(txt_member_code.Text);
        //            if (validcode == true)
        //            {
        //                find_franchise_code();


        //                lbl_message.Text = "";
        //                string tranid = mycode.featch_tranid();
        //                int grdcount = grd_epin_distribute.Rows.Count;
        //                int j = 0;
        //                for (int i = 0; i < grdcount; i++)
        //                {
        //                    Label lbl_epin = (Label)grd_epin_distribute.Rows[i].FindControl("lbl_epin");
        //                    Label lbl_Package = (Label)grd_epin_distribute.Rows[i].FindControl("lbl_Package_id");
        //                    Label id = (Label)grd_epin_distribute.Rows[i].FindControl("lbl_id");
        //                    CheckBox check = (CheckBox)grd_epin_distribute.Rows[i].FindControl("chk_check_pin");
        //                    string ID = id.Text;
        //                    if (check.Checked == true)
        //                    {
        //                        submit_dataInEpinTable(ID);
        //                        send_data_into_allocated_pin_list(lbl_epin.Text, lbl_Package.Text, tranid);
        //                    }
        //                    else
        //                    {
        //                        j++;

        //                    }
        //                }
        //                if (j == grdcount)
        //                {
        //                    lbl_message.Text = "Please check any one checkbox of pin list";
        //                }
        //                else
        //                {
        //                    hd_franchisecode.Value = "0";
        //                    hd_franchisestatus.Value = "NO";
        //                    string path = "E-pin-slip.aspx?code=" + txt_member_code.Text + "&transid=" + tranid;
        //                    Response.Redirect(path);
        //                }

        //            }
        //            else
        //            {
        //                lbl_message.Text = "Please enter valid member code";
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        My.submitException1(ex.ToString());
        //    }
        //}

        //private void find_franchise_code()
        //{
        //    Connection con = new Connection();
        //    string connstr = con.connect_method();
        //    SqlConnection coon = new SqlConnection(connstr);
        //    SqlDataAdapter ad = new SqlDataAdapter("Select * from Re_Franchise_details where Member_code='" + txt_member_code.Text + "'", coon);
        //    DataSet ds = new DataSet();
        //    ad.Fill(ds, "Re_Franchise_details");
        //    DataTable dt = ds.Tables[0];
        //    int rowcount = dt.Rows.Count;
        //    if (rowcount == 0)
        //    {
        //        hd_franchisecode.Value = "0";
        //        hd_franchisestatus.Value = "NO";
        //    }
        //    else
        //    {
        //        hd_franchisecode.Value = dt.Rows[0][6].ToString();
        //        hd_franchisestatus.Value = "YES";
        //    }
        //}

        //private void send_data_into_allocated_pin_list(string epin, string Package, string tranid)
        //{

        //    DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
        //    string date = dtm.ToString("dd/MM/yyyy");
        //    string idate = mycode.idate();

        //    Connection con = new Connection();
        //    string connstr = con.connect_method();
        //    SqlConnection coon = new SqlConnection(connstr);
        //    SqlDataAdapter ad = new SqlDataAdapter("Select * from Allocated_E_PIN_details", coon);
        //    DataSet ds = new DataSet();
        //    ad.Fill(ds, "Allocated_E_PIN_details");
        //    DataTable dt = ds.Tables[0];
        //    DataRow dr = dt.NewRow();
        //    dr[1] = txt_member_code.Text;
        //    dr[2] = epin;
        //    dr[3] = Package;
        //    dr[4] = tranid;
        //    dr[5] = dtm.ToString("dd/MM/yyyy hh:ss tt");
        //    dr[6] = idate;
        //    dr[7] = hd_franchisecode.Value;
        //    dt.Rows.Add(dr);
        //    SqlCommandBuilder cb = new SqlCommandBuilder(ad);
        //    ad.Update(dt);

        //}

        //private bool check_membercode(string membercode)
        //{
        //    Connection con = new Connection();
        //    string connstr = con.connect_method();
        //    SqlConnection coon = new SqlConnection(connstr);
        //    SqlDataAdapter ad = new SqlDataAdapter("Select * from Member_registration where Member_code='" + membercode + "'", coon);
        //    DataSet ds = new DataSet();
        //    ad.Fill(ds, "Member_registration");
        //    DataTable dt = ds.Tables[0];
        //    int rowcount = dt.Rows.Count;
        //    if (rowcount == 0)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        //private void submit_dataInEpinTable(string ID)
        //{

        //    Connection con = new Connection();
        //    string connstr = con.connect_method();
        //    SqlConnection coon = new SqlConnection(connstr);
        //    SqlDataAdapter ad = new SqlDataAdapter("Select * from E_PIN_details where id='" + ID + "'", coon);
        //    DataSet ds = new DataSet();
        //    ad.Fill(ds, "E_PIN_details");
        //    DataTable dt = ds.Tables[0];
        //    int rowcount = dt.Rows.Count;
        //    if (rowcount == 0)
        //    {
        //        //do nothing
        //    }
        //    else
        //    {
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            dr[2] = txt_member_code.Text;
        //            dr[4] = Session["today"].ToString();
        //            dr[6] = "GIVEN";
        //            dr[11] = hd_franchisestatus.Value;
        //            dr[12] = hd_franchisecode.Value;
        //        }
        //        SqlCommandBuilder cb = new SqlCommandBuilder(ad);
        //        ad.Update(dt);
        //        lbl_message.Text = "E-PIN is successfully distributed.";


        //    }
        //}
        //#endregion

        //protected void btn_find_Click(object sender, EventArgs e)
        //{
        //    txt_member_name.Text = "";
        //    lbl_message.Text = "";
        //    if (txt_member_code.Text == "")
        //    {
        //        lbl_message.Text = "Please enter valid member code";
        //    }
        //    else
        //    {

        //        bool chkvalidmembercode = mycode.valid_number(txt_member_code.Text);
        //        if (chkvalidmembercode == false)
        //        {
        //            lbl_message.Text = "Please enter valid member code";
        //        }
        //        else
        //        {

        //            string membercode = txt_member_code.Text;
        //            Connection con = new Connection();
        //            string connstr = con.connect_method();
        //            SqlConnection coon = new SqlConnection(connstr);
        //            SqlDataAdapter ad = new SqlDataAdapter("Select * from Member_registration where Member_code='" + membercode + "'", coon);
        //            DataSet ds = new DataSet();
        //            ad.Fill(ds, "Member_registration");
        //            DataTable dt = ds.Tables[0];
        //            int rowcount = dt.Rows.Count;
        //            if (rowcount == 0)
        //            {
        //                lbl_message.Text = "Please enter valid member code";
        //                txt_member_code.Text = "";
        //                txt_member_name.Text = "";
        //                btn_distribute.Enabled = false;
        //            }
        //            else
        //            {
        //                lbl_message.Text = "";
        //                btn_distribute.Enabled = true;
        //                txt_member_name.Text = dt.Rows[0][4].ToString();

        //            }
        //        }
        //    }
        //    ViewState["CheckReferesh"] = Session["CheckReferesh"].ToString();

        //}

        //protected void ddl_package_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    lbl_message.Text = "";
        //    if (ddl_package.SelectedItem.Text == "Select")
        //    {
        //        Panel1.Visible = false;

        //        grd_epin_distribute.DataSource = null;
        //        grd_epin_distribute.DataBind();
        //        lbl_message1.Text = "Select package ";
        //        scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
        //        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
        //    }
        //    else
        //    {
        //        fetch_epin_list();
        //    }
        //}




    }
}
