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
using System.Globalization;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using Master_MLM.App_Code;
using System.Collections.Generic;

namespace Master_MLM.Member_4235profile
{
    public partial class Genealogy_bt_two_date_positionwise : System.Web.UI.Page
    {
        Important imp = new Important();
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
                Page.Server.ScriptTimeout = 36000;
                if (!IsPostBack)
                {
                    fetch_year();
                    //// Create a new table. for sorting
                    DataTable taskTable = new DataTable("TaskList");

                    txt_memberid.Text = Session["membercode"].ToString();

                }
            }

        }

        My mycode = new My();
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
            ddl_s_year.DataSource = ar;
            ddl_s_year.DataBind();

            ddl_e_year.DataSource = ar;
            ddl_e_year.DataBind();


            DateTime dt = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dt.ToString("dd/MM/yyyy");
            string day = date.Substring(0, 2);
            string month = date.Substring(3, 2);
            string year = date.Substring(6, 4);
            ddl_s_date.Text = day;
            ddl_s_month.Text = month;
            ddl_s_year.Text = year;
            ddl_e_date.Text = day;
            ddl_e_month.Text = month;
            ddl_e_year.Text = year;





        }
        protected void btn_find_Click(object sender, EventArgs e)
        {
            fill_gridview();
        }

        private void fill_gridview()
        {

            if (txt_memberid.Text == "")
            {
                lbl_msg.Text = "Enetr member code";

            }
            else if (txt_memberid.Text == imp.AdminCode)
            {
                lbl_msg.Text = "Enetr wrong member code";
            }
            else
            {
                string startdate = ddl_s_date.Text + "/" + ddl_s_month.Text + "/" + ddl_s_year.Text;
                string enddate = ddl_e_date.Text + "/" + ddl_e_month.Text + "/" + ddl_e_year.Text;
                string format2 = "dd/MM/yyyy";
                DateTime startdate1 = DateTime.ParseExact(startdate, format2, CultureInfo.InvariantCulture);
                DateTime enddate1 = DateTime.ParseExact(enddate, format2, CultureInfo.InvariantCulture);
                int result2 = DateTime.Compare(enddate1, startdate1);
                if (result2 >= 0)
                {
                    lbl_msg.Text = "";
                    string membercode = txt_memberid.Text;
                    fill_members(membercode, startdate, enddate);
                }
                else
                {
                    lbl_msg.Text = "End Date Cannot be less than start date";
                }
            }
        }

        private void fill_members(string membercode, string startdate, string enddate)
        {
            ViewState["dtDatas"] = null;

            if (ViewState["dtDatas"] == null)
            {
                DataTable dtDatas = new DataTable();
                dtDatas.Columns.Add("MemberCode");
                dtDatas.Columns.Add("MemberName");
                dtDatas.Columns.Add("Sponsorcode");
                dtDatas.Columns.Add("Sponsorname");
                dtDatas.Columns.Add("DOJ");
                dtDatas.Columns.Add("Placement");
                dtDatas.Columns.Add("Package");
                dtDatas.Columns.Add("Point");
                dtDatas.Columns.Add("Amount");
                dtDatas.Columns.Add("idate", typeof(int));
                dtDatas.Columns.Add("AmountType");
                dtDatas.Columns.Add("Verification_date");
                dtDatas.Columns.Add("Verification_time");
                //store the state of the datatable into a ViewState object
                ViewState["dtDatas"] = dtDatas;
            }

            ArrayList al = new ArrayList();
            Connection con = new Connection();
            string connect = con.connect_method();
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from binary_status where member_code ='" + membercode + "' ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "binary_status");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
                lbl_msg.Text = "Enetr wrong member code";
                panel_view_left_right_join.Visible = false;
            }
            else
            {
                lbl_name.Text = dt.Rows[0][0].ToString();
                lbl_msg.Text = " ";
                panel_view_left_right_join.Visible = true;

                string left_child = dt.Rows[0][3].ToString();
                string right_child = dt.Rows[0][4].ToString();
                string middle_child = dt.Rows[0][11].ToString();

                if (ddl_position.Text == "Left")
                {
                    if (left_child != "")
                    {
                        al.Add(left_child);
                    }
                    bind_gridview(al);
                }

                if (ddl_position.Text == "Middle")
                {
                    if (middle_child != "")
                    {
                        al.Add(middle_child);
                    }
                    bind_gridview(al);
                }

                if (ddl_position.Text == "Right")
                {
                    if (right_child != "")
                    {
                        al.Add(right_child);
                    }
                    bind_gridview(al);
                }
            }
        }

        private void bind_gridview(ArrayList al)
        {
            string format2 = "dd/MM/yyyy";

            string startdate = ddl_s_date.Text + "/" + ddl_s_month.Text + "/" + ddl_s_year.Text;
            string enddate = ddl_e_date.Text + "/" + ddl_e_month.Text + "/" + ddl_e_year.Text;
            DateTime d1 = DateTime.ParseExact(startdate, format2, CultureInfo.InvariantCulture);
            DateTime d2 = DateTime.ParseExact(enddate, format2, CultureInfo.InvariantCulture);

            string membercode = "";
            for (int i = 0; i < al.Count; i++)
            {
                membercode = al[i].ToString();
                string left_child1 = find_the_left_child(membercode);
                string right_child1 = find_the_right_child(membercode);
                string middle_child1 = find_the_middle_child(membercode);

                if (left_child1 != "")
                {
                    al.Add(left_child1);
                }

                if (middle_child1 != "")
                {
                    al.Add(middle_child1);

                }

                if (right_child1 != "")
                {
                    al.Add(right_child1);
                }
                Connection con = new Connection();
                string connect = con.connect_method();
                SqlConnection conn = new SqlConnection(connect);
                SqlDataAdapter ad1 = new SqlDataAdapter("Select * from Member_registration where Member_code ='" + al[i].ToString() + "'", conn);
                DataSet ds1 = new DataSet();
                ad1.Fill(ds1, "Member_registration");
                DataTable dt1 = ds1.Tables[0];
                int rowcount1 = ds1.Tables[0].Rows.Count;
                if (rowcount1 == 0)
                {
                }
                else
                {
                    string joiningdate = dt1.Rows[0][5].ToString();
                    DateTime runningdate = DateTime.ParseExact(joiningdate, format2, CultureInfo.InvariantCulture);

                    int result2 = DateTime.Compare(runningdate, d1);

                    if (result2 >= 0)//runningdate date is greater and equal than d1
                    {
                        int result3 = DateTime.Compare(d2, runningdate);//laste date greater than and equal
                        if (result3 >= 0)
                        {

                            DataTable dtDatas = (DataTable)ViewState["dtDatas"];
                            DataRow drNewRow = dtDatas.NewRow();
                            drNewRow["MemberCode"] = membercode;
                            drNewRow["MemberName"] = dt1.Rows[0][4].ToString();
                            drNewRow["Sponsorcode"] = dt1.Rows[0][1].ToString();
                            drNewRow["Sponsorname"] = dt1.Rows[0][2].ToString();
                            drNewRow["DOJ"] = dt1.Rows[0][5].ToString();
                            drNewRow["Placement"] = dt1.Rows[0][33].ToString();
                            drNewRow["Package"] = dt1.Rows[0][32].ToString();
                            drNewRow["Point"] = dt1.Rows[0][54].ToString();
                            drNewRow["Amount"] = dt1.Rows[0][30].ToString();
                            drNewRow["AmountType"] = dt1.Rows[0][41].ToString();
                            drNewRow["Verification_date"] = dt1.Rows[0][42].ToString();
                            drNewRow["Verification_time"] = dt1.Rows[0][43].ToString();

                            string DOJ = dt1.Rows[0][5].ToString();
                            string date = DOJ.Substring(0, 2);
                            string month = DOJ.Substring(3, 2);
                            string year = DOJ.Substring(6, 4);
                            drNewRow["idate"] = Convert.ToInt32(year + month + date);
                            //add this new row to the Datatable and commit changes
                            dtDatas.Rows.Add(drNewRow);
                            dtDatas.AcceptChanges();
                            ViewState["dtDatas"] = dtDatas;
                        }
                    }
                }

            }
            if (al.Count == 0)
            {
                grd_left.DataSource = null;
                grd_left.DataBind();
            }
            else
            {

                grd_left.DataSource = ViewState["dtDatas"];
                grd_left.DataBind();


                int j = grd_left.Rows.Count;
                lbl_left.Text = "Total Child:- " + j.ToString();

                double points = 0.0;
                for (int k = 0; k < j; k++)
                {
                    //string bvpoint = grd_left.Rows[k].Cells[6].Text;
                    Label lblpoint = (Label)grd_left.Rows[k].FindControl("lblPoint");
                    if (lblpoint.Text != "")
                    {
                        points = points + Convert.ToDouble(lblpoint.Text);
                    }
                }
                lbl_total_point.Text = "Total PV:- " + points.ToString();

            }
        }
        private string find_the_left_child(string membercode)
        {
            String toreturn = "";
            Connection con = new Connection();
            string connect = con.connect_method();
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from binary_status where member_code ='" + membercode + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "binary_status");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {

            }
            else
            {
                toreturn = dt.Rows[0][3].ToString();
            }

            return toreturn;
        }
        private string find_the_middle_child(string membercode)
        {
            String toreturn = "";
            Connection con = new Connection();
            string connect = con.connect_method();
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from binary_status where member_code ='" + membercode + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "binary_status");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {

            }
            else
            {
                toreturn = dt.Rows[0][11].ToString();
            }

            return toreturn;
        }
        private string find_the_right_child(string membercode)
        {
            String toreturn = "";
            Connection con = new Connection();
            string connect = con.connect_method();
            SqlConnection conn = new SqlConnection(connect);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from binary_status where member_code ='" + membercode + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "binary_status");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {

            }
            else
            {
                toreturn = dt.Rows[0][4].ToString();
            }

            return toreturn;
        }

        #region export_gridview_in_excel
        protected void img_export_Click(object sender, ImageClickEventArgs e)
        {

            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dtm.ToString("dd/MM/yyyy");
            Session["today"] = date;
            string excelname = Session["today"] + ddl_position.Text + "genealogy.xls";
            export_to_excel(grd_left, excelname);
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
            grd_view.AllowSorting = false;
            fill_gridview();
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
        #region gridview_sorting
        protected void grd_left_Sorting(object sender, GridViewSortEventArgs e)
        {
            //Retrieve the table from the session object.
            DataTable dt = (DataTable)ViewState["dtDatas"];
            // DataTable dt = ViewState["dtDatas"] as DataTable;

            if (dt != null)
            {

                //Sort the data.
                dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                grd_left.DataSource = ViewState["dtDatas"];
                grd_left.DataBind();
            }
        }

        private string GetSortDirection(string column)
        {
            // By default, set the sort direction to ascending.
            string sortDirection = "ASC";

            // Retrieve the last column that was sorted.
            string sortExpression = ViewState["SortExpression"] as string;

            if (sortExpression != null)
            {
                // Check if the same column is being sorted.
                // Otherwise, the default value can be returned.
                if (sortExpression == column)
                {
                    string lastDirection = ViewState["SortDirection"] as string;
                    if ((lastDirection != null) && (lastDirection == "ASC"))
                    {
                        sortDirection = "DESC";
                    }
                }
            }

            // Save new values in ViewState.
            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = column;

            return sortDirection;
        }
        #endregion gridview_sorting
        protected string hide_string(string str)
        {

            string val = "";
            if (str != "")
            {
                if (str.Length >= 10)
                {
                    val = str.Substring(0, 2) + "xxxxxxxx" + str.Substring((str.Length) - 2, 2);
                }
            }
            return val;
        }
    }
}