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
using System.Drawing;
using System.IO;
using Master_MLM.App_Code;

namespace Master_MLM.Admin_87554b
{
    public partial class my_team : System.Web.UI.Page
    {
        Important imp = new Important();
        DataTable dtTeamMember = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            fill_datain_gridview();

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

            string MemberCode = txtMemberCode.Text;
            int TotalTeamMember = GetMyTeamMember("'"+MemberCode + "'", dtAllMember);
            lblTotalMembers.Text = "Total Members : " + TotalTeamMember.ToString(); ;
            Session["TeamMember"] = null;
            Session["TeamMember"] = dtTeamMember;
            BindGridView();
        }

        private void fill_datain_gridview()
        {
            BindGridView();
            return;
           
            Connection con = new Connection();
            string connect = con.connect_method();
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter ad = new SqlDataAdapter(" Select * from Member_registration where Member_code!='" + imp.AdminCode + "' and Paidstatus='PAID'  order by Id ASC", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;

            if (rowcount == 0)
            {
                pnl_view.Visible = false;
                grd_view.DataSource = null;
                grd_view.DataBind();
                lbl_message.Text = "There is no member joining to Paid";
            }
            else
            {
                grd_view.Visible = true;
                lbl_message.Text = "Your Total Joining is =" + rowcount.ToString(); ;
                pnl_view.Visible = true;
                grd_view.DataSource = ds;
                grd_view.DataBind();



            }
        }

        protected void img_expord_Click(object sender, ImageClickEventArgs e)
        {
            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dtm.ToString("dd/MM/yyyy");
            Session["today"] = date;
            string excelname = Session["today"].ToString() + "Totalmemberjoining.xls";
            export_to_excel(grd_view, excelname);
        }

        #region export_gridview_in_excel
        private void export_to_excel(GridView grd_view, string excelname)
        {
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", excelname));
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            grd_view.AllowPaging = false;
            fill_datain_gridview();
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

        protected void grd_view_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_view.PageIndex = e.NewPageIndex;
            grd_view.DataBind();
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
                                                  dr["Date"].ToString(), dr["Verification_date"].ToString(), dr["Paidstatus"].ToString(), Level);

                        if (MemberCode == "") { MemberCode = "'" + dr["Member_code"].ToString() + "'"; }
                        else { MemberCode = MemberCode + ",'" + dr["Member_code"].ToString() + "'"; }
                    }

                    //drMyTeam = dtMyTeam.Select("Referal_code in (" + MemberCode + ")");
                    TotalReferral = 0;// drMyTeam.Length;

                    Level = Level + 1;
                    //return GetMyTeamMember(MemberCode, dtMyTeam, TotalTeam, Level);
                }
                
            }
            return TotalTeam;
        }

        public int GetMyTeamMember_2(string MemberCode, DataTable dtMyTeam, int TotalTeam = 0, int Level = 1)
        {
            DataRow[] drMyTeam = dtMyTeam.Select("Referal_code in (" + MemberCode + ")");
            if (drMyTeam.Length != 0)
            {
                TotalTeam = TotalTeam + drMyTeam.Length;
                MemberCode = "";
                foreach (DataRow dr in drMyTeam)
                {
                    //dtTeamMember.Rows.Add(ID, MemberName, MemberCode, MobileNumber, JoiningDate, VerificationDate, Status, Level);
                    int ID = dtTeamMember.Rows.Count + 1;
                    dtTeamMember.Rows.Add(ID, dr["Member_name"].ToString(), dr["Member_code"].ToString(), dr["Mobile_number"].ToString(), dr["Date"].ToString(), dr["Verification_date"].ToString(), dr["Paidstatus"].ToString(), Level);

                    if (MemberCode == "") { MemberCode = dr["Member_code"].ToString(); }
                    else { MemberCode = MemberCode + "," + dr["Member_code"].ToString(); }
                }

                Level = Level + 1;
                return GetMyTeamMember(MemberCode, dtMyTeam, TotalTeam, Level);
            }
            return TotalTeam;
        }

        protected void btnFind_Click(object sender, EventArgs e)
        {
            if (txtMemberCode.Text.Trim() == "") { lbl_message.Text = "Invalid Member Code."; return; }
            FillGridView();
        }


    }
}
