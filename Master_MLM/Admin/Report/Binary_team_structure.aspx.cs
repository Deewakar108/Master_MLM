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
using System.Collections.Generic;
using System.Data.SqlClient;
using Master_MLM.App_Code;

namespace Master_MLM.Admin
{
    public partial class Binary_team_structure : System.Web.UI.Page
    {
        string gender = "";
        int countMemberForMakingID = 0;
        Important imp = new Important();
        string queryString = "";
        string topMemberImage = "images/gr.jpg";

        string divID = "";
        string LeftRightBV = "Left PV : 0  &nbsp;&nbsp;&nbsp; Right PV : 0";
        string PurchaseDate = "";
        string Package = "";
        string SponsorName = "";
        string ReferralName = "";
        string AdminCode = "BMHP1234";

        protected void Page_Load(object sender, EventArgs e)
        {
            AdminCode = imp.AdminCode;
            if (Session["admin_usermlm"] == null)
            {
                Session.Abandon();
                Session.Clear();
                Response.Write("<script language=javascript>var wnd=window.open('','newWin','height=1,width=1,left=900,top=700,status=no,toolbar=no,menubar=no,scrollbars=no,maximize=false,resizable=1');</script>");
                Response.Write("<script language=javascript>wnd.close();</script>");
                Response.Write("<script language=javascript>window.open('../Default.aspx','_parent',replace=true);</script>");
            }
            else
            {
                if (Request.QueryString["q"] != null)
                {
                    queryString = Request.QueryString["q"].ToString();
                    if (IsMemberCodeExist(queryString)) { ShowAdminBinaryTree(queryString); panel_view_tree.Visible = true; lbl_msg.Text = ""; }
                    else { lbl_msg.Text = "Enter valid member code"; panel_view_tree.Visible = false; }
                    return;
                }
                if (!IsPostBack)
                {
                    DataTable dtdatas = new DataTable();
                    dtdatas.Columns.Add("Membercode", typeof(string));
                    dtdatas.Columns.Add("id", typeof(Int32));
                    ViewState["dtdatas"] = dtdatas;

                }
            }
        }
        protected void btn_find_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_memberid.Text == "")
                {
                    lbl_msg.Text = "Enter valid member code";

                    panel_view_tree.Visible = false;
                }
                else
                {
                    string codenumber = txt_memberid.Text;
                    if (IsMemberCodeExist(codenumber)) { Session["prevMemberCode"] = codenumber; ShowAdminBinaryTree(codenumber); panel_view_tree.Visible = true; lbl_msg.Text = ""; }
                    else { lbl_msg.Text = "Enter valid member code"; panel_view_tree.Visible = false; }

                }
            }
            catch (Exception ex)
            {
                My.submitException(ex);
            }
        }


        public void ShowCompanyInfoAsTopMember()
        {
            string sql = "select top 1 member_imagepath, Referal_name, Referal_code, Date, Member_name, Member_code,Sponcer_name,Sponcer_code from Member_registration order by id asc";
            DataTable dt = imp.FillTable(sql);

            string row = "";
            if (dt.Rows.Count != 0)
            {
                row = "<div style='width: 19%; padding: 15px; margin: 5px auto; background-color: #f5f7c7; border-radius: 5px;min-height: 120px;'>" +
                    "<img src='" + dt.Rows[0]["member_imagepath"].ToString() + "' style='height: 115px; width: 110px;' alt='USER' /><br /><div style='font-size: 14px;'>" +
                    dt.Rows[0]["Member_name"].ToString() + "</div> <div style='font-size: 10px;'>" + dt.Rows[0]["Member_code"].ToString() +
                    "</div><div class='row' style='font-size: 11px; margin-top: 5px; text-align: left;'>" +
                    "<div class='col-lg-12'>Referrer : " + dt.Rows[0]["Referal_name"].ToString() + "</div><div class='col-lg-12'>Sponsor : " +
                    dt.Rows[0]["Sponcer_name"].ToString() + "</div> <div class='col-lg-12'>Joining Date : " + dt.Rows[0]["Date"].ToString() + "</div></div></div>";
            }

            //divTopMember.InnerHtml = row;
        }

        My mycode = new My();

        private void ShowAdminBinaryTree(string MemberCode)
        {
            //MemberCode = "BMHP1234";
            string left = "0";
            string right = "0";
            divID = "div" + countMemberForMakingID;
            
            string mouseHover = "<div id='" + divID + "' style='position: fixed;display:none; z-index: 1; background-color: green;" +
                " border-radius: 5px; padding: 10px; color: white; font-size: 12px;'>Purchase Date: " + PurchaseDate +
                " <br />Package: " + Package + "<br />Referral : " + ReferralName + "<br />" + "</div>";
            MemberDetail m = getMemberDetail(MemberCode);
            MemberCount memberCount = imp.GetTotalMemberWithPosition(MemberCode);
            ReferralName = m.ReferralName;
            string SponsorName = m.SponsorName;
            Package = m.PackageName;
            PurchaseDate = m.VerificationDate;
            string ShowMember = "Left : " + memberCount.Left + " Right : " + memberCount.Right;
            string ShowBV = "Left BV: " + m.LeftBV + " Right BV: " + m.RightBV;

            string RedImage = "images/r.jpg";
            if (m.Paidstatus == "FREE") { topMemberImage = RedImage; }

            countMemberForMakingID = countMemberForMakingID + 1;
            divID = "div" + countMemberForMakingID;
            mouseHover = "<div id='" + divID + "' style='position: fixed; text-align: left; display:none; z-index: 1; background-color: green;" +
                 " border-radius: 5px; padding: 10px; color: white; font-size: 11px;'>Purchase Date: " + PurchaseDate +
                 " <br />Package: " + Package + "<br />Referral : " + ReferralName + "<br />Sponsor : " + SponsorName + "<br />" + ShowMember + "</div>";

            string tr = "<tr><td style='font-size: 11px;'>Left: " + left + "</td><td style='font-size: 12px;'>" + m.Name + "<br />ID: " + m.Code +
                "<br /><img onmouseover=\"hoverdiv(event,'" + divID + "')\" onmouseout=\"hoverdiv(event,'" + divID + "')\" src='" + topMemberImage +
                "'  /></td><td style='font-size: 11px;'>Right: " + right + "  " + mouseHover + "</td></tr>";
            topMemberAdmin.InnerHtml = tr;

            countMemberForMakingID = countMemberForMakingID + 1;
            divID = "div" + countMemberForMakingID;
            //mouseHover = "<div id='" + divID + "' style='position: fixed; text-align: left; display:none; z-index: 1; background-color: green;" +
            //     " border-radius: 5px; padding: 10px; color: white; font-size: 11px;'>Purchase Date: " + PurchaseDate +
            //     " <br />Package: " + Package + "<br />Referral : " + ReferralName + "<br />Sponsor : " + SponsorName + "<br />" + ShowMember + "</div>";
            
            mouseHover = "<div id='" + divID + "' style='position: fixed; text-align: left; display:none; z-index: 1; background-color: green;" +
                 " border-radius: 5px; padding: 10px; color: white; font-size: 11px;'>Purchase Date: " + PurchaseDate +
                 " <br />Package: " + Package + "<br />Sponsor : " + SponsorName + "<br />" + ShowMember + "</div>";


            spTopAdminName.InnerHtml = m.Name + "<br />ID: " + m.Code + "<br /><img onmouseover=\"hoverdiv(event,'" + divID + "')\" onmouseout=\"hoverdiv(event,'" + divID +
                "')\" src='" + topMemberImage + "'  /><br/> " + mouseHover;


            HtmlGenericControl[] spanLevel1 = { spAdmin1, spAdmin2 };
            HtmlGenericControl[] spanLevel2 = { spAdmin5 , spAdmin6, spAdmin7 , spAdmin8};


            #region  Left

            MemberDetail m2 = getBinaryMember(MemberCode);
            string m2Left = m2.LeftMember;
            ChildLevel(m2Left, spanLevel1[0]);

            MemberDetail m3 = getBinaryMember(m2Left);
            #region  Left

            string m3Left = m3.LeftMember;
            ChildLevel(m3Left, spanLevel2[0]);

            #endregion

            #region  Right

            string m3Right = m3.RightMember;
            ChildLevel(m3Right, spanLevel2[1]);

            #endregion

            #endregion
            
            #region  Right

            string m2Right = m2.RightMember;
            ChildLevel(m2Right, spanLevel1[1]);

            MemberDetail m4 = getBinaryMember(m2Right);
            #region  Left

            string m4Left = m4.LeftMember;
            ChildLevel(m4Left, spanLevel2[2]);

            #endregion
            
            #region  Right

            string m4Right = m4.RightMember;
            ChildLevel(m4Right, spanLevel2[3]);

            #endregion

            #endregion

        }

        private void ChildLevel(string MemberCode, HtmlGenericControl span, string LeftCount = "0", string RightCount = "0")
        {
			topMemberImage = "images/gr.jpg";
            countMemberForMakingID = countMemberForMakingID + 1;
            string tr = "";
            string url = "#";
            if (MemberCode != "0")
            {
                url = "Binary_team_structure.aspx?q=" + MemberCode;
                MemberDetail m = getMemberDetail(MemberCode);
                MemberCount memberCount = imp.GetTotalMemberWithPosition(MemberCode);

                divID = "div" + countMemberForMakingID;
                LeftRightBV = "Left BV : " + m.LeftBV + "  &nbsp;&nbsp;&nbsp; Right BV : " + m.RightBV;
                PurchaseDate = m.VerificationDate;
                Package = m.PackageName;
                SponsorName = m.SponsorName;
                ReferralName = m.ReferralName;
                string ShowMember = "Left : " + memberCount.Left + " Right : " + memberCount.Right;
                string ShowBV = "Left BV: " + m.LeftBV + " Right BV: " + m.RightBV;

                //string mouseHover = "<div id='" + divID + "' style='position: fixed; text-align: left; display:none; z-index: 1; background-color: green;" +
                //    " border-radius: 5px; padding: 10px; color: white; font-size: 12px;'>Purchase Date: " + PurchaseDate +
                //    " <br />Package: " + Package + "<br />Referral : " + ReferralName + "<br />SponsorName : " + SponsorName + "<br />" + ShowMember + "</div>";
                string mouseHover = "<div id='" + divID + "' style='position: fixed; text-align: left; display:none; z-index: 1; background-color: green;" +
                                    " border-radius: 5px; padding: 10px; color: white; font-size: 12px;'>Purchase Date: " + PurchaseDate +
                                    " <br />Package: " + Package + "SponsorName : " + SponsorName + "<br />" + ShowMember + "</div>";

                string RedImage = "images/r.jpg";
				if (m.Paidstatus == "FREE") { topMemberImage = RedImage; }
			
                tr = m.Name + "<br />(ID: " + m.Code + ") <br /><a   href='" + url + "'  > " +
                " <img  onmouseover=\"hoverdiv(event,'" + divID + "')\"  onmouseout=\"hoverdiv(event,'" + divID + "')\" src='" + topMemberImage + "'   /> " + mouseHover + "</a>";
                span.InnerHtml = tr;
            }
            else
            {
                url = "#";
                tr = "N/A" + "<br />(ID: " + "N/A" + ") <br /><a   href='" + url + "'  > " +
                    " <img src='images/grey.jpg'   /> </a>";
                span.InnerHtml = tr;
            }
        }

        private MemberDetail getBinaryMember(string MemberCode)
        {
            MemberDetail m = new MemberDetail();
            string sql = " select  * from binary_status  where member_code='" + MemberCode + "'";
            DataTable dt = imp.FillTable(sql);
            if (dt.Rows.Count != 0)
            {
                m.LeftMember = dt.Rows[0]["left_child"].ToString() == "" ? "0" : dt.Rows[0]["left_child"].ToString();
                m.RightMember = dt.Rows[0]["right_child"].ToString() == "" ? "0" : dt.Rows[0]["right_child"].ToString();

                if (MemberCode != AdminCode) { m.LeftCount = imp.GetTotalNumber(m.LeftMember).ToString(); }
                else { m.LeftCount = "0"; }

                if (MemberCode != AdminCode) { m.RightCount = imp.GetTotalNumber(m.RightMember).ToString(); }
                else { m.RightCount = "0"; }

                return m;
            }

            m.LeftMember = "0";
            m.RightMember = "0";

            return m;
        }

        private bool IsMemberCodeExist(string MemberCode)
        {
            string sql = " select  * from binary_status  where member_code='" + MemberCode + "'";
            DataTable dt = imp.FillTable(sql);
            if (dt.Rows.Count != 0) { return true; }
            return false;
        }

        private DataTable getAdminBinaryMember(string MemberCode)
        {
            MemberDetail m = new MemberDetail();
            string sql = " select top 4 * from binary_status  where introducer_code='" + MemberCode + "' and member_code!='" + AdminCode + "'";
            DataTable dt = imp.FillTable(sql);
            if (dt.Rows.Count < 4)
            {
                int count = (4 - dt.Rows.Count);
                for (int i = 0; i < count; i++)
                { dt.Rows.Add("0", "0", "0", "0", "0", "0", "0", "0", "0", "0"); }

            }

            return dt;
        }

        public MemberDetail getMemberDetail(string MemberCode)
        {
            MemberDetail m = new MemberDetail();
            string sql = " select Member_code, Member_name, Status, member_imagepath, Id, Position, Paidstatus, " +
                " Sponcer_name, Sponcer_code, joining_package, Verification_date, Verification_time, BV, Referal_name, " + 
                "Referal_code from Member_registration " +
                " where Member_code='" + MemberCode + "'";
            DataTable dt = imp.FillTable(sql);
            if (dt.Rows.Count != 0)
            {
                m.Name = dt.Rows[0]["Member_name"].ToString();
                m.Code = dt.Rows[0]["Member_code"].ToString();
                m.ImageUrl = dt.Rows[0]["member_imagepath"].ToString();
                m.VerifiedStatus = dt.Rows[0]["Status"].ToString();
                m.Position = dt.Rows[0]["Position"].ToString();
                m.Paidstatus = dt.Rows[0]["Paidstatus"].ToString();
                m.ID = dt.Rows[0]["Id"].ToString();

                m.SponsorName = dt.Rows[0]["Sponcer_name"].ToString();
                m.SponsorCode = dt.Rows[0]["Sponcer_code"].ToString();
                m.ReferralName = dt.Rows[0]["Referal_name"].ToString();
                m.ReferralCode = dt.Rows[0]["Referal_code"].ToString();

                #region Find BV 

                m.LeftBV = "0";
                m.RightBV = "0";
                sql = "select top 1 (convert(float, Total_leftchild) + (select sum(convert(float, Pair)) from Daily_child_table p where p.Membercode=d.Membercode)) as " +
                          "Total_leftchild, (convert(float, Total_rightchild) + (select sum(convert(float, Pair)) from Daily_child_table p where p.Membercode=d.Membercode)) " +
                          "as Total_rightchild from Daily_child_table d where Membercode='" + MemberCode + "' order by id desc";
                DataTable dtBinary = imp.FillTable(sql);
                if (dtBinary.Rows.Count != 0)
                {
                    m.LeftBV = dtBinary.Rows[0]["Total_leftchild"].ToString();
                    m.RightBV = dtBinary.Rows[0]["Total_rightchild"].ToString();
                }

                #endregion

                m.PackageName = dt.Rows[0]["joining_package"].ToString();
                m.VerificationDate = dt.Rows[0]["Verification_date"].ToString();
                m.VerificationTime = dt.Rows[0]["Verification_time"].ToString();
                m.BV = dt.Rows[0]["BV"].ToString();

                m.LeftMember = "0";
                m.RightMember = "0";
                return m;
            }
            m.LeftMember = "0";
            m.RightMember = "0";
            return m;
        }

        public void Alert(string Message)
        {
            lbl_msg.Text = Message;
            imp.Alert();
        }

        private bool IsTeamMember(string MemberCode, bool Status = false)
        {
            string TeamLeader = Session["membercode"].ToString();
            string sql = " select  * from binary_status  where member_code='" + MemberCode + "'";
            DataTable dt = imp.FillTable(sql);
            if (dt.Rows.Count != 0)
            {
                string SponsorCode = dt.Rows[0]["introducer_code"].ToString();
                if (SponsorCode == AdminCode) { return false; }
                if (SponsorCode == TeamLeader) { return true; }
                else { return IsTeamMember(SponsorCode); }
            }
            return Status;
        }

        protected void btnPreviusPage_Click(object sender, EventArgs e)
        {
            if (Session["prevMemberCode"] != null) 
            {
                string memberCode = Session["prevMemberCode"].ToString();
                Response.Redirect("Binary_team_structure.aspx?q=" + memberCode);
            }
        }

    }

    public class MemberDetail
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string LeftMember { get; set; }
        public string RightMember { get; set; }
        public string ImageUrl { get; set; }
        public string Gender { get; set; }
        public string Position { get; set; }
        public string VerifiedStatus { get; set; }
        public string Paidstatus { get; set; }

        public string LeftCount { get; set; }
        public string RightCount { get; set; }

        public string SponsorName { get; set; }
        public string SponsorCode { get; set; }
        public string ReferralName { get; set; }
        public string ReferralCode { get; set; }

        public string VerificationDate { get; set; }
        public string VerificationTime { get; set; }
        public string PackageName { get; set; }
        public string BV { get; set; }

        public string LeftBV { get; set; }
        public string RightBV { get; set; }


        public string BinarySponsorCode { get; set; }
        public string BinarySponsorName { get; set; }
    }
}

