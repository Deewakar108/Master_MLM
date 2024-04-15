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
using Master_MLM.App_Code;

namespace Master_MLM.Member_4235profile
{
    public partial class Member_home : System.Web.UI.Page
    {

        Important imp = new Important();
        //BinaryPlan binaryPlan = new BinaryPlan();



        protected void Page_Load(object sender, EventArgs e)
        {
            lblCompanyEmailID.Text = imp.EmailID;
            lblCompanyMobileNo.Text = imp.MobileNo;

            Page.Header.DataBind();

            if (Session["membercode"] == null)
            {
                Session.Abandon();
                Session.Clear();
                Response.Write("<script language=javascript>var wnd=window.open('','newWin','height=1,width=1,left=900,top=700,status=no,toolbar=no,menubar=no,scrollbars=no,maximize=false,resizable=1');</script>");
                Response.Write("<script language=javascript>wnd.close();</script>");
                Response.Write("<script language=javascript>window.open('../Default.aspx','_parent',replace=true);</script>");
            }
            else
            {
                try
                {
                    ShowAdd();
                    string memberid = Session["membercode"].ToString();
                    //lblCurrentLevel.Text = "";
                    //lblNextFilledPosition.Text = "";
                    //lblChildPosition.Text = "";
                    fetch_news(memberid);
                    fetch_member_info(memberid);
                    Bind_Training(memberid);

                    //find_totalpair(memberid);
                    //find_epin_commission(memberid);
                    //find_referal_commission(memberid);
                    //lbl_total_income.Text = (Convert.ToDouble(lbl_pairincome.Text) + Convert.ToDouble(lbl_pinincome.Text) + 
                    //    Convert.ToDouble(lbl_referal_income.Text)).ToString();


                    //RewardPoints r = imp.getRewardPoints(memberid);
                    //lbl_rp_points.Text = "Left-" + r.LeftRP + "  Right-" + r.RightRP;
                    //find_rppoints(memberid);
                    CalculateCommission(memberid);

                    featch_member_business(memberid);
                    find_repurchase_royalty_achiever(memberid);
                    find_carry_forward_list(memberid);
                    find_repurchse_carry_forward(memberid);

                }
                catch
                {
                }
            }
        }

        private void find_repurchse_carry_forward(string memberid)
        {
            string membercode = Session["membercode"].ToString();
            if (ViewState["dtdatas"] == null)
            {
                DataTable dtdatas = new DataTable();
                dtdatas.Columns.Add("Member_code");
                dtdatas.Columns.Add("Member_name");
                dtdatas.Columns.Add("Closing_no");
                dtdatas.Columns.Add("pre_left");
                dtdatas.Columns.Add("pre_right");
                dtdatas.Columns.Add("Current_left");
                dtdatas.Columns.Add("Current_right");
                dtdatas.Columns.Add("Pair");
                dtdatas.Columns.Add("Pairno");
                dtdatas.Columns.Add("colising_date");
                dtdatas.Columns.Add("Lapsepair");
                ViewState["dtdatas"] = dtdatas;
            }
            string sql = "  select top 1 *,(select Member_name from Member_registration where Member_code=t1.Membercode) as Member_name from dbo.[Repurchase_Daily_child_table] t1 where Membercode='" + membercode + "' order by Deleteid desc";
            DataTable dt = imp.FillTable(sql);
            int rowcount = dt.Rows.Count;
            if (rowcount > 0)
            {
                for (int i = 0; i < rowcount; i++)
                {
                    string Membercode = dt.Rows[i]["Membercode"].ToString();
                    string Member_name = dt.Rows[i]["Member_name"].ToString();
                    string Total_leftchild = dt.Rows[i]["Total_leftchild"].ToString();
                    string Total_rightchild = dt.Rows[i]["Total_rightchild"].ToString();
                    string Pair = dt.Rows[i]["Pair"].ToString();
                    string Deleteid = dt.Rows[i]["Deleteid"].ToString();
                    string Closing_no = dt.Rows[i]["Closingno"].ToString();
                    string Closing_date = dt.Rows[i]["Date"].ToString();
                    string Lapsepair = "0";
                    if (double.Parse(Pair) > 5)
                    {
                        Lapsepair = (double.Parse(Pair) - 5).ToString();
                    }

                    string pre_child = find_previous_child(Membercode, Deleteid);
                    string[] child = pre_child.Split('^');

                    DataTable dtDatas = (DataTable)ViewState["dtdatas"];
                    DataRow drNewRow = dtDatas.NewRow();
                    drNewRow["Member_code"] = Membercode;
                    drNewRow["Member_name"] = Member_name;
                    drNewRow["Closing_no"] = Closing_no;
                    drNewRow["colising_date"] = Closing_date;
                    drNewRow["pre_left"] = child[0].ToString();
                    drNewRow["pre_right"] = child[1].ToString();
                    drNewRow["Current_left"] = Total_leftchild;
                    drNewRow["Current_right"] = Total_rightchild;
                    drNewRow["Pair"] = Pair;
                    drNewRow["Lapsepair"] = Lapsepair;                  
                    dtDatas.Rows.Add(drNewRow);
                    dtDatas.AcceptChanges();
                    ViewState["dtdatas"] = dtDatas;
                }
                gridviewrepurchse.DataSource = ViewState["dtdatas"];
                gridviewrepurchse.DataBind();
                ViewState["dtdatas"] = null;


            }
            else
            {
                gridviewrepurchse.DataSource = ViewState["dtdatas"];
                gridviewrepurchse.DataBind();
                ViewState["dtdatas"] = null;


            }
        }
        
        private void find_carry_forward_list(string memberid)
        {
            string membercode = Session["membercode"].ToString();
            if (ViewState["dtdatas"] == null)
            {
                DataTable dtdatas = new DataTable();
                dtdatas.Columns.Add("Member_code");
                dtdatas.Columns.Add("Member_name");
                dtdatas.Columns.Add("Closing_no");
                dtdatas.Columns.Add("pre_left");
                dtdatas.Columns.Add("pre_right");
                dtdatas.Columns.Add("Current_left");
                dtdatas.Columns.Add("Current_right");
                dtdatas.Columns.Add("Pair");
                dtdatas.Columns.Add("Pairno");
                dtdatas.Columns.Add("colisingdate");
                dtdatas.Columns.Add("Lapsepair");
                ViewState["dtdatas"] = dtdatas;
            }
            string sql = "  select top 1 *,(select Member_name from Member_registration where Member_code=t1.Membercode) as Member_name from dbo.[Daily_child_table] t1 where Membercode='" + membercode + "' order by Deleteid desc";
            DataTable dt = imp.FillTable(sql);
            int rowcount = dt.Rows.Count;
            if (rowcount > 0)
            {
                for (int i = 0; i < rowcount; i++)
                {


                    string Membercode = dt.Rows[i]["Membercode"].ToString();
                    string Member_name = dt.Rows[i]["Member_name"].ToString();
                    string Total_leftchild = dt.Rows[i]["Total_leftchild"].ToString();
                    string Total_rightchild = dt.Rows[i]["Total_rightchild"].ToString();
                    string Pair = dt.Rows[i]["Pair"].ToString();
                    string Deleteid = dt.Rows[i]["Deleteid"].ToString();
                    string Closing_no = dt.Rows[i]["Closingno"].ToString();
                    string Closing_date = dt.Rows[i]["Date"].ToString();
                    string Lapsepair = "0";
                    if (double.Parse(Pair) > 5)
                    {
                        Lapsepair = (double.Parse(Pair) - 5).ToString();
                    }

                    string pre_child = find_previous_child(Membercode, Deleteid);
                    string[] child = pre_child.Split('^');

                    DataTable dtDatas = (DataTable)ViewState["dtdatas"];
                    DataRow drNewRow = dtDatas.NewRow();
                    drNewRow["Member_code"] = Membercode;
                    drNewRow["Member_name"] = Member_name;
                    drNewRow["Closing_no"] = Closing_no;
                    drNewRow["colisingdate"] = Closing_date;
                    drNewRow["pre_left"] = child[0].ToString();
                    drNewRow["pre_right"] = child[1].ToString();
                    drNewRow["Current_left"] = Total_leftchild;
                    drNewRow["Current_right"] = Total_rightchild;
                    drNewRow["Pair"] = Pair;
                    drNewRow["Lapsepair"] = Lapsepair;
                    //add this new row to the Datatable and commit changes
                    dtDatas.Rows.Add(drNewRow);
                    dtDatas.AcceptChanges();
                    ViewState["dtdatas"] = dtDatas;
                }
                gridviewcarry.DataSource = ViewState["dtdatas"];
                gridviewcarry.DataBind();
                ViewState["dtdatas"] = null;
               

            }
            else
            {
                gridviewcarry.DataSource = ViewState["dtdatas"];
                gridviewcarry.DataBind();
                ViewState["dtdatas"] = null;
               

            }
        }

        private string find_previous_child(string Membercode, string Deleteid)
        {
            string sql = "Select top 1 Total_leftchild,Total_rightchild from dbo.[Daily_child_table] where Membercode='" + Membercode + "' and Deleteid<" + Deleteid + " order by id desc";
            DataTable dt = imp.FillTable(sql);
            int rowcount = dt.Rows.Count;
            if (rowcount > 0)
            {
                return dt.Rows[0][0].ToString() + "^" + dt.Rows[0][1].ToString();
            }
            else { return "0^0"; }
        }

        private void featch_member_business(string memberid)
        {
            string month = DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("MM/yyyy");
            string qry = @"Select Month,isnull(Sum(cast(Self as float)),0) as Self_BV, 
(Select (isnull(Sum(cast(Self as float)),0)+isnull(Sum(cast(Team as float)),0)) as total from Re_purchase_member_bv_point_details_monthly where Member_code in(Select left_child from binary_status where member_code ='" + memberid + @"'
 ) and Month=t1.Month) as Left_PV,  (Select (isnull(Sum(cast(Self as float)),0)+isnull(Sum(cast(Team as float)),0)) as total from Re_purchase_member_bv_point_details_monthly where Member_code in(Select right_child from binary_status where member_code ='" + memberid + @"'
 ) and Month=t1.Month) as Right_PV from Re_purchase_member_bv_point_details_monthly t1 where Member_code ='" + memberid + "' and t1.Month='" + month + "' group by Month";

            Connection con = new Connection();
            string connect = con.connect_method();
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter ad = new SqlDataAdapter(qry, conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "binary_status");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {

            }
            else
            {

                gridview.DataSource = dt;
                gridview.DataBind();
            }
        }

        private void find_repurchase_royalty_achiever(string memberid)
        {
            string qry = @" Select * from Repurchase_Royalty_Member where MemberCode='" + memberid + "' ";
            DataTable dt = imp.FillTable(qry);
            int rowcount = dt.Rows.Count;
            if (rowcount > 0)
            {
                lblRewardName.Text = "Diamond";
            }

        }


        My use = new My();

        public void ShowAdd()
        {
            string imagePath = "https://www.w3schools.com/howto/img_fjords.jpg";

            string sql = "select * from PopupImage where IsActive=0";
            DataTable dt = imp.FillTable(sql);
            if (dt.Rows.Count != 0)
            {
                if (Session["Popup"] == null)
                {
                    Session["Popup"] = "OK";
                    imagePath = dt.Rows[0]["ImagePath"].ToString();
                    imagePath = imagePath.Replace("~/", "../");
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), "script", "<script type='text/javascript'>ClickMe('" + imagePath + "');</script>", false);
                }
            }
        }

        public void CalculateCommission(string MemberCode)
        {
            string sql = "select  Member_code, Status, ClosingType, sum(convert(float, Totalamount)) as Totalamount, sum(convert(float, Tds)) as TDS, " +
                         "sum(convert(float, Servicecharge)) as Servicecharge, sum(convert(float, carryAmount)) as carryAmount, " +
                         "sum(convert(float, Final_amount)) as Final_amount from payout where Member_code='" +
                         MemberCode + "' group by Member_code, Status, ClosingType";
            DataTable dtTemp = imp.FillTable(sql);

            if (dtTemp.Rows.Count != 0)
            {
                //Sponsor Income
                DataRow[] dr = dtTemp.Select("ClosingType='Sponsor' and Status='NOTPAID'");
                if (dr.Length != 0)
                {
                    DataTable dtTempX = dr.CopyToDataTable();
                    double Total = double.Parse(dtTempX.Compute("SUM(Totalamount)", "").ToString());
                    lblSponsorIncome.Text = Total.ToString("0.00");
                }

                //CTO Income
                //dr = dtTemp.Select("ClosingType='CTO' and Status='NOTPAID'");
                //if (dr.Length != 0)
                //{
                //    DataTable dtTempX = dr.CopyToDataTable();
                //    double Total = double.Parse(dtTempX.Compute("SUM(Totalamount)", "").ToString());
                //    lblCTO.Text = Total.ToString("0.00");
                //}


                //Royalty Income
                //dr = dtTemp.Select("ClosingType='Royalty' and Status='NOTPAID'");
                //if (dr.Length != 0)
                //{
                //    DataTable dtTempX = dr.CopyToDataTable();
                //    double Total = double.Parse(dtTempX.Compute("SUM(Totalamount)", "").ToString());
                //    lblRoyalty.Text = Total.ToString("0.00");
                //}

                //Referral Income
                dr = dtTemp.Select("ClosingType='Royalty' and Status='NOTPAID'");
                if (dr.Length != 0)
                {
                    DataTable dtTempX = dr.CopyToDataTable();
                    double Total = double.Parse(dtTempX.Compute("SUM(Totalamount)", "").ToString());
                    lblReferral.Text = Total.ToString("0.00");
                }
            }



            //Repurchase Incomes
            sql = @"select  Member_code, Status, Income_type, sum(convert(float, Totalamount)) as Totalamount, sum(convert(float, Tds)) as TDS, 
                                sum(convert(float, Servicecharge)) as Servicecharge,   sum(convert(float, Final_amount)) as Final_amount from Repurchase_payout 
                                where Member_code='" + MemberCode + "' group by Member_code, Status, Income_type";
            dtTemp = imp.FillTable(sql);

            if (dtTemp.Rows.Count != 0)
            {
                //Repurchase Income
                DataRow[] dr = dtTemp.Select("Income_type in('MATCHING INCOME','SELF INCOME') and Status='NOTPAID'");
                if (dr.Length != 0)
                {
                    DataTable dtTempX = dr.CopyToDataTable();
                    double Total = double.Parse(dtTempX.Compute("SUM(Final_amount)", "").ToString());
                    lblRepurchase.Text = Total.ToString("0.00");
                }

                //Repurchase Royalty Income
                dr = dtTemp.Select("Income_type='ROYALTY INCOME' and Status='NOTPAID'");
                if (dr.Length != 0)
                {
                    DataTable dtTempX = dr.CopyToDataTable();
                    double Total = double.Parse(dtTempX.Compute("SUM(Final_amount)", "").ToString());
                    lblRepurchase.Text = Total.ToString("0.00");
                }
            }



            ////Reward Name
            //sql = "select  * from AchievedTable where MemberCode='" + MemberCode + "' order by id desc";
            //DataTable dt = imp.FillTable(sql);
            //if (dt.Rows.Count != 0)
            //{
            //    lblRewardName.Text = dt.Rows[0]["RewardName"].ToString();
            //}
            //else { lblRewardName.Text = "No Reward Achieved."; }

            ////KYC Status
            //if (IsKYCUpdate(MemberCode)) { lblKYC.Text = "Updated."; }
        }

        public bool IsKYCUpdate(string MemberCode)
        {
            bool status = false;
            string sql = "select * from Member_registration where (Account_number='' or  Bank_name='' or Branch_name='' or Ifsc_code=''  or Pan_number='')  " +
                         "and  Member_code='" + MemberCode + "'";
            DataTable dtTemp = imp.FillTable(sql);
            if (dtTemp.Rows.Count == 0) { status = true; }

            return status;
        }

        private void find_rppoints(string memberid)
        {

            ArrayList al = new ArrayList();
            ArrayList al2 = new ArrayList();
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select left_child,right_child from binary_status  where member_code='" + memberid + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "binary_status");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount != 0)
            {

                string left_child = dt.Rows[0][0].ToString();
                string right_child = dt.Rows[0][1].ToString();
                double leftrp = 0.0;
                double rightrp = 0.0;

                if (left_child != "")
                {
                    al.Add(left_child);
                }
                if (right_child != "")
                {
                    al2.Add(right_child);
                }
                leftrp = My.find_member_point(al);
                rightrp = My.find_member_point(al2);
                //lbl_rp_points.Text = "Left-" + leftrp + ", Right-" + rightrp;
            }

        }

        private void find_referal_commission(string memberid)
        {
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select Sum(cast(Credit as float)) from E_Wallet   where Member_code='" +
                memberid + "' and Description like '%Direct Referral Income from%'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "payout");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {


            }
            else
            {
                if (dt.Rows[0][0].ToString() != "")
                {
                    //lbl_referal_income.Text = dt.Rows[0][0].ToString();
                }

            }
        }

        private void find_epin_commission(string memberid)// only for epin using
        {

            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            string sql = "Select Sum(cast(Commission as float)) from Member_epin_commission mec " +
                " join Re_Franchise_details rfd on mec.Franchise_code= rfd.Stock_point_code where rfd.Member_code='" +
                memberid + "'";
            SqlDataAdapter ad = new SqlDataAdapter(sql, coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "payout");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {


            }
            else
            {
                if (dt.Rows[0][0].ToString() != "")
                {
                    //lbl_pinincome.Text = dt.Rows[0][0].ToString();
                }
                else
                {
                    find_epin_commission_for_add_franchise(memberid);
                }
            }
        }

        private void find_epin_commission_for_add_franchise(string memberid)
        {
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select Sum(cast(Commission as float)) from Member_epin_commission where Franchise_code='" + memberid + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "payout");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                //lbl_pinincome.Text = "0000";

            }
            else
            {
                if (dt.Rows[0][0].ToString() != "")
                {
                    //lbl_pinincome.Text = dt.Rows[0][0].ToString();
                }
                else
                {
                    //lbl_pinincome.Text = "0000";
                }
            }
        }

        private void find_totalpair(string membercode)
        {
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select  sum(cast(Totalamount as float))  from payout where Member_code='" +
                membercode + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "payout");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
            }
            else
            {
                if (dt.Rows[0][0].ToString() != "")
                {
                    //lbl_pairincome.Text = dt.Rows[0][0].ToString();
                }
            }
        }

        private void Bind_Training(string memberid)
        {
            Connection con = new Connection();
            string connect = con.connect_method();
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter ad = new SqlDataAdapter("Select top 4 * from Training_schedule where Membercode in ('" +
                memberid + "','All') Order by Id DESC", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Training_schedule");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                Grd_training.DataSource = null;
                Grd_training.DataBind();
            }
            else
            {
                Grd_training.DataSource = ds;
                Grd_training.DataBind();
            }
        }

        private void fetch_member_info(string memberid)
        {
            Connection con = new Connection();
            string connect = con.connect_method();
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter ad = new SqlDataAdapter("Select Member_code,Sponcer_name,Date,Status,Verification_date,joining_package from Member_registration where Member_code ='" +
                                memberid + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;

            if (rowcount == 0)
            {
            }
            else
            {
                lbl_yourid.Text = memberid;
                lbl_joining_date.Text = dt.Rows[0]["Date"].ToString();
                lbl_verification.Text = dt.Rows[0]["Verification_date"].ToString();
                lbl_package.Text = dt.Rows[0]["joining_package"].ToString();
                //find_upgrade_package(memberid);
                string status = dt.Rows[0]["Status"].ToString();
                if (status == "Pending")
                {
                    lbl_status.Text = "Pending";
                }
                else
                {
                    lbl_status.Text = "Active";
                }

                lbl_sponsor.Text = dt.Rows[0]["Sponcer_name"].ToString();


            }
        }

        private void find_upgrade_package(string memberid)
        {
            Connection con = new Connection();
            string connect = con.connect_method();
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter ad = new SqlDataAdapter("Select top 1 Upgrade_Packageid  from Member_Upgrade_History where Member_code ='"
                + memberid + "'  order by id DESC  ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_Upgrade_History");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;

            if (rowcount == 0)
            {
                lbl_upgradepackage.Text = "Your account is not upgraded.";
            }
            else
            {
                lbl_upgradepackage.Text = find_package_name1(dt.Rows[0][0].ToString());
            }
        }

        private string find_package_name1(string Package_id)
        {
            Connection con = new Connection();
            string connect = con.connect_method();
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter ad = new SqlDataAdapter("Select  Package_name  from Joining_package where Package_id ='" +
                Package_id + "'     ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_Upgrade_History");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;

            if (rowcount == 0)
            {
                return "";
            }
            else
            {
                return dt.Rows[0][0].ToString();
            }
        }

        private void fetch_news(string memberid)
        {
            //Connection con = new Connection();
            //string connect = con.connect_method();
            //SqlConnection conn = new SqlConnection(connect);
            //SqlDataAdapter ad = new SqlDataAdapter("Select top 5 Heading, News, Date from NewsTable order by id desc", conn);
            //DataSet ds = new DataSet();
            //ad.Fill(ds, "Member_news");
            //DataTable dt = ds.Tables[0];
            //int rowcount = dt.Rows.Count;
            //if (rowcount == 0)
            //{
            //    dtlst_news.DataSource = null;
            //    dtlst_news.DataBind();

            //}
            //else
            //{
            //    dtlst_news.DataSource = ds;
            //    dtlst_news.DataBind();
            //}
        }

        protected void Grd_training_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                Grd_training.PageIndex = e.NewPageIndex;
                Grd_training.DataBind();
                string memberid = Session["membercode"].ToString();
                Bind_Training(memberid);
            }
            catch
            {
            }
        }



    }
}