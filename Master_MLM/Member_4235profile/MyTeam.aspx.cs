using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Master_MLM.App_Code;
using System.Collections;
using System.Data;

namespace Master_MLM.Member_4235profile
{
    public partial class MyTeam : System.Web.UI.Page
    {
        Important imp = new Important();
        DataTable dtTeamMember = new DataTable();
        string AdminCode = "";
        protected void Page_Load(object sender, EventArgs e)
        {
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

                if (!IsPostBack)
                {

                    BindGridView();

                }
            }
        }




        private void BindGridView()
        {
            if (Session["TeamMember"] == null)
            {
                FillGridView();
                Session["TeamMember"] = dtTeamMember;
            }
            else { dtTeamMember = (DataTable)Session["TeamMember"]; }
            pnl_view.Visible = true;
            grd_view.DataSource = dtTeamMember;
            grd_view.DataBind();
            Session["TeamMember"] = dtTeamMember;
        }

        private void FillGridView()
        {
            dtTeamMember = new DataTable();
            dtTeamMember.Columns.Add("ID", typeof(string));
            dtTeamMember.Columns.Add("MemberName", typeof(string));
            dtTeamMember.Columns.Add("MemberCode", typeof(string));
            dtTeamMember.Columns.Add("MobileNumber", typeof(string));
            dtTeamMember.Columns.Add("JoiningDate", typeof(string));
            dtTeamMember.Columns.Add("VerificationDate", typeof(string));
            dtTeamMember.Columns.Add("Status", typeof(string));
            dtTeamMember.Columns.Add("Level", typeof(string));

            DataTable dtAllMember = new DataTable();
            if (Session["AllMember"] == null)
            {
                string sql = "select  * from Member_registration order by id ASC";
                dtAllMember = imp.FillTable(sql);
                Session["AllMember"] = dtAllMember;
            }
            else { dtAllMember = (DataTable)Session["AllMember"]; }

            string MemberCode = Session["membercode"].ToString();
            int TotalTeamMember = GetMyTeamMember("'" + MemberCode + "'", dtAllMember);
            lblTotalMembers.Text = "Total Members : " + TotalTeamMember.ToString(); ;
            Session["TeamMember"] = null;
            Session["TeamMember"] = dtTeamMember;
            BindGridView();
        }


        public int GetMyTeamMember(string MemberCode, DataTable dtMyTeam, int TotalTeam = 0, int Level = 1)
        {
            DataRow[] drMyTeam = dtMyTeam.Select("Referal_code in (" + MemberCode + ")");
            if (drMyTeam.Length != 0)
            {
                int TotalReferral = drMyTeam.Length;
                while (TotalReferral != 0)
                {
                    TotalTeam = TotalTeam + TotalReferral;
                    MemberCode = "";
                    foreach (DataRow dr in drMyTeam)
                    {
                        int ID = dtTeamMember.Rows.Count + 1;
                        dtTeamMember.Rows.Add(ID, dr["Member_name"].ToString(), dr["Member_code"].ToString(), dr["Mobile_number"].ToString(),
                                                  dr["Date"].ToString(), dr["Verification_date"].ToString(), dr["joining_package"].ToString(), Level);

                        if (MemberCode == "") { MemberCode = "'" + dr["Member_code"].ToString() + "'"; }
                        else { MemberCode = MemberCode + ",'" + dr["Member_code"].ToString() + "'"; }
                    }

                    //drMyTeam = dtMyTeam.Select("Referal_code in (" + MemberCode + ")");
                    TotalReferral = 0;  // drMyTeam.Length;

                    Level = Level + 1;
                    //return GetMyTeamMember(MemberCode, dtMyTeam, TotalTeam, Level);
                }

            }
            return TotalTeam;
        }

        protected void grd_view_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_view.PageIndex = e.NewPageIndex;
            BindGridView();
        }

        protected void grd_view_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "IsTopUp")
            {
                string MemberCode = e.CommandArgument.ToString();
                string sql = "select  * from  Member_registration  where  Member_code = '" + MemberCode + "'";
                DataTable dt = imp.FillTable(sql);
                if (dt.Rows.Count != 0)
                {
                    lblMemberCode.Text = dt.Rows[0]["Member_code"].ToString();
                    lblMemberName.Text = dt.Rows[0]["Member_name"].ToString();

                    pnlMemberActivation.Visible = true;
                }

            }
        }

        protected void grd_view_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lbl = (Label)e.Row.FindControl("lbl_member_code");
                Button btnTopUp = (Button)e.Row.FindControl("btnTopUp");

                string MemberCode = lbl.Text;
                string sql = "select * from TopUpMemberList where MemberCode='" + MemberCode + "'";
                DataTable dt = imp.FillTable(sql);
                if (dt.Rows.Count != 0)
                {
                    btnTopUp.Visible = false;
                }
                else { btnTopUp.Visible = true; }
            }
        }

        protected void btnValidate_Click(object sender, EventArgs e)
        {
            string IsActivationPackage = "0, 2";
            string FixedPackageAmount = "6000";
            string sql = "select *, isnull((select top 1 Package_amount from Joining_package where Package_name=Package), 0) as package_amount, " +
                         "isnull((select top 1 RewardPoint from Joining_package where Package_name=Package), 0) as RewardPoint, isnull((select top 1 " +
                         "MatchingIncome from Joining_package where Package_name=Package), 0) as MatchingIncome from E_PIN_details where Status='GIVEN' " +
                         "and  Epin='" + txtEPin.Text + "'";

            sql = "select * from (select *, isnull((select top 1 IsActivationPackage from Joining_package where Package_name=Package), 0) as IsActivationPackage, " +
                  "isnull((select top 1 BV from Joining_package where Package_name=Package), 0) as BV," +
                  "isnull((select top 1 RepurchaseBV from Joining_package where Package_name=Package), 0) as RepurchaseBV," +
                "isnull((select top 1 Package_amount from Joining_package where Package_name=Package), 0) as package_amount, isnull((select top 1 RewardPoint from " +
                  "Joining_package where Package_name=Package), 0) as RewardPoint, isnull((select top 1 MatchingIncome from Joining_package where Package_name=Package), " +
                  "0) as MatchingIncome from E_PIN_details where Status='GIVEN' and  Epin='" + txtEPin.Text + "') T where  IsActivationPackage in (" +
                  IsActivationPackage + ") and package_amount='" + FixedPackageAmount + "'";

            DataTable dt = imp.FillTable(sql);
            if (dt.Rows.Count != 0)
            {
                lblPackageName.Text = dt.Rows[0]["Package"].ToString();
                hdfPackageAmount.Value = dt.Rows[0]["package_amount"].ToString();
                hdfPackageRewardPoint.Value = dt.Rows[0]["RewardPoint"].ToString();
                hdfMatchingIncome.Value = dt.Rows[0]["MatchingIncome"].ToString();
                hdfPackageID.Value = dt.Rows[0]["Package_id"].ToString();


                hdfRewardBV.Value = dt.Rows[0]["BV"].ToString();
                hdfRepurchaseBV.Value = dt.Rows[0]["RepurchaseBV"].ToString();

                divEPinDetail.Visible = true;
                //AlertMe("EPin verified successfully.");
                lblMessage.Text = "";
            }
            else
            {
                //AlertMe("Invalid EPin.");
                lblMessage.Text = "Invalid EPin.";
            }
        }

        protected void btnActivate_Click(object sender, EventArgs e)
        {
            string MemberCode = lblMemberCode.Text;

            string Joining_amount = hdfPackageAmount.Value;
            string joining_package = lblPackageName.Text;
            string Package_id = hdfPackageID.Value;
            string Pinno = txtEPin.Text;
            string MatchingIncome = hdfMatchingIncome.Value;
            string RewardPoint = hdfPackageRewardPoint.Value;

            string BV = hdfRewardBV.Value;
            string RepurchaseBV = hdfRepurchaseBV.Value;


            DateTime dtToday = DateTime.UtcNow.AddMinutes(30).AddHours(5);
            string Verification_date = dtToday.ToString("dd/MM/yyyy");
            string Verification_time = dtToday.ToString("hh:mm:ss tt");
            string Verification_idate = dtToday.ToString("yyyyMMdd");
            string PrevEPin = "--";// GetPreviousEPin(MemberCode);
            string NewEPin = Pinno;

            //For Member Activation
            //string sql = "update Member_registration set Status = 'Verified', Paidstatus = 'PAID', Joining_amount = '" + Joining_amount + "', joining_package = '" + joining_package + "', " +
            //             "Package_id = '" + Package_id + "', Pinno = '" + Pinno + "', Verification_date = '" + Verification_date + "', Verification_time = '" + Verification_time +
            //             "', Verification_idate = '" + Verification_idate + "', MatchingIncome = '" + MatchingIncome + "', RewardPoint = '" + RewardPoint + 
            //             "', RepurchaseBV = '" + RepurchaseBV + "', RewardBV = '" + BV +
            //             "' where Member_code='" + MemberCode + "'";
            //int i1 = imp.InsertUpdateDelete(sql);

            //TopUp
            string sql = "insert into TopUpMemberList(MemberCode,PrevEPin,NewEPin,ActivationDate,Activation_iDate) values ('" + MemberCode + "','','" + Pinno +
                         "','" + Verification_date + "','" + Verification_idate + "')";
            int i1 = imp.InsertUpdateDelete(sql);

            string SponsorCode = GetSponsorCode(MemberCode);
            sql = "update E_PIN_details  set used_by='" + SponsorCode + "', used_date='" + Verification_date + "', Used_to='" + MemberCode + "', Status='USED' where    Epin='" + Pinno + "'";
            int i2 = imp.InsertUpdateDelete(sql);
            if (i1 == 0 || i1 == 0)
            {
                //AlertMe("Try Again");
            }
            else
            {
                divEPinDetail.Visible = false;
                divEPinDetail.Visible = false;
                txtEPin.Text = "";
                //if (!tc.UpdateRewardPointOnly(MemberCode)) { AlertMe("Try Again"); }
                divEPinDetail.Visible = false;
                pnlMemberActivation.Visible = false;
                //InsertActivatedMemberDetails(MemberCode, PrevEPin, NewEPin);
                FillGridView();
                //AlertMe("Member successfully activated.");
            }
        }


        public string GetSponsorCode(string MemberCode)
        {
            string sql = "select * from Member_registration where Member_code='" + MemberCode + "'";
            DataTable dtTemp = imp.FillTable(sql);
            if (dtTemp.Rows.Count != 0)
            {
                return dtTemp.Rows[0]["Sponcer_code"].ToString();
            }
            return imp.AdminCode;
        }


    }
}