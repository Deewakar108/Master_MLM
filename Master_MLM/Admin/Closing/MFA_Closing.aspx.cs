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
using System.Collections.Generic;
using Master_MLM.App_Code;
using System.Globalization;

namespace Master_MLM.Admin.Closing
{
    public partial class MFA_Closing : System.Web.UI.Page
    {
        My mycode = new My();
        Important imp = new Important();
        DataTable dtAllMember;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fetch_year();
            }

        }
        private void fetch_year()
        {

            Dictionary<string, object> dc1 = mycode.startyear_endyear();
            string Startyear = (String)dc1["Startyear"];
            string End_year = (String)dc1["End_year"];
            ArrayList ar = new ArrayList();
            ar.Add("Select");
            for (int i = Convert.ToInt32(Startyear); i <= Convert.ToInt32(End_year); i++)
            {

                ar.Add(i);
            }
            ddl_year.DataSource = ar;
            ddl_year.DataBind();


        }
        protected void btn_find_Click(object sender, EventArgs e)
        {
            if (ddl_year.SelectedValue != "Select")
            {
                BindGridView();
            }
            else { lblMessage.Text = "Please select year"; }
        }

        public void GetAllMember()
        {
            string sql = "select *, (select Value from Joining_package where Package_name = joining_package) as PackageValue, " +
                         "isnull(convert(int, Verification_idate), 0) as V_iDate, isnull(convert(int, (substring(Date, 7, 4)+substring(Date, 4, 2) + " +
                         "substring(Date, 1, 2))), 0) as J_iDate, isnull(convert(int, (substring(MFA_AchievedDate, 7, 4)+substring(MFA_AchievedDate, 4, 2) + " +
                         "substring(MFA_AchievedDate, 1, 2))), 0) as MFA__iDate, convert(float, Joining_amount) as JoiningAmount from Member_registration order by id asc";
            dtAllMember = imp.FillTable(sql);
        }

        private void BindGridView()
        {
            DateTime dtStartDate = DateTime.UtcNow.AddMinutes(30).AddHours(5);
            int CurrentMonthValue = dtStartDate.Month;
            if (CurrentMonthValue != int.Parse(ddl_month.SelectedItem.Text))
            {
                string Start_iDate = ddl_year.SelectedItem.Text + ddl_month.SelectedItem.Text + "01";
                dtStartDate = DateTime.ParseExact(Start_iDate, "yyyyMMdd", CultureInfo.InvariantCulture).AddMonths(1).AddDays(-1);

                string End_iDate = dtStartDate.ToString("yyyyMMdd");

                GetAllMember();

                

                DataRow[] drMFAMember = dtAllMember.Select("MFA__iDate>0 and  MFA__iDate<=" + Start_iDate);
                if (drMFAMember.Length != 0)
                {
                    //Start_iDate = "20180301"; End_iDate = "20180331";
                    DataRow[] drAllMember = dtAllMember.Select("J_iDate>=" + Start_iDate + " and  J_iDate<=" + End_iDate);
                    if (drAllMember.Length != 0)
                    {
                        DataTable dtTemp = drAllMember.CopyToDataTable();
                        //double TurnOverAmount = double.Parse(dtTemp.Compute("SUM(JoiningAmount)", "").ToString());

                        double TurnOverAmount = 250 * drAllMember.Length;
                        string Amount = (TurnOverAmount / drMFAMember.Length).ToString();

                        string[] strMonth = { "JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC" };
                        foreach (DataRow dr in drMFAMember)
                        {
                            string MemberCode = dr["Member_code"].ToString();
                            
                            string MFA_AchievedDate = dr["MFA__iDate"].ToString();
                            dtStartDate = DateTime.ParseExact(MFA_AchievedDate, "yyyyMMdd", CultureInfo.InvariantCulture).AddMonths(1);

                            if (!IsExistInMFABonous(MemberCode))
                            {
                                for (int i = 0; i < 3; i++)
                                {
                                    string MonthValue = dtStartDate.ToString("MM");
                                    string MonthName = strMonth[int.Parse(MonthValue) - 1];
                                    string Year = dtStartDate.ToString("yyyy");

                                    string sql = "insert into MFABonous(MemberCode,Amount,MonthName,MonthValue,Year) values ('" + MemberCode + "','" + Amount +
                                                 "','" + MonthName + "','" + MonthValue + "','" + Year + "')";
                                    int i1 = imp.InsertUpdateDelete(sql);
                                    dtStartDate = dtStartDate.AddMonths(1);
                                }
                            }

                        }


                        lblMessage.Text = drMFAMember.Length + " Member got MFA Bonous in this month.";
                        return;
                        

                    }
                    else { lblMessage.Text = "0 Member joined in this month."; return; }
                }
                else { lblMessage.Text = "MFA Member does not exist."; return; }

                //Stage-1 Income

                //Stage-2 Income

                //Stage-3 Income

                //Stage-4 Income

                //Stage-5 Income

                //Stage-6 Income

                
            }
            else { lblMessage.Text = "Please select valid month."; return; }

            lblMessage.Text = "";
        }

        public bool IsExistInMFABonous(string MemberCode)
        {
            string sql = "select distinct MemberCode from MFABonous where MemberCode='" + MemberCode + "'";
            DataTable dtMFABonous = imp.FillTable(sql);
            if (dtMFABonous.Rows.Count != 0)
            {
                return true;
            }
            return false;
        }

        #region export_gridview_in_excel
        protected void img_export_Click(object sender, ImageClickEventArgs e)
        {
            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dtm.ToString("dd/MM/yyyy");
            Session["today"] = date;
            string excelname = Session["today"] + "tdsreport.xls";
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
            //find_tds_report();
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
