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

namespace Master_MLM.Member_4235profile
{
    public partial class Total_left_right_joining : System.Web.UI.Page
    {
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
                    DataTable taskTable = new DataTable("TaskList");

                    string membercode = Session["membercode"].ToString();
                    find_image(membercode);
                    lbl_name.Text = Session["membername"].ToString() + "</br>" + "(" + Session["membercode"].ToString() + ")";
                    fill_members(membercode);
                }
            }
        }

        private void find_image(string membercode)
        {
            Connection con = new Connection();
            string connect = con.connect_method();
            SqlConnection conn = new SqlConnection(connect);

            SqlDataAdapter ad = new SqlDataAdapter("Select * from Member_registration where Member_code ='" + membercode + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            DataTable dt = ds.Tables[0];
            int rowcount = ds.Tables[0].Rows.Count;
            if (rowcount == 0)
            {
            }
            else
            {
                Session["membername"] = dt.Rows[0][4].ToString();
                Img_member.ImageUrl = dt.Rows[0][29].ToString();
            }
        }

        private void fill_members(string membercode)
        {
            ViewState["dtDatas"] = null;
            ViewState["dtDatas1"] = null;
            ViewState["dtDatas2"] = null;
            if (ViewState["dtDatas1"] == null)
            {
                DataTable dtDatas1 = new DataTable();
                dtDatas1.Columns.Add("MemberCode");
                dtDatas1.Columns.Add("MemberName");
                dtDatas1.Columns.Add("Sponsorcode");
                dtDatas1.Columns.Add("Sponsorname");
                dtDatas1.Columns.Add("DOJ");
                dtDatas1.Columns.Add("Placement");
                dtDatas1.Columns.Add("Package");
                dtDatas1.Columns.Add("Point");
                dtDatas1.Columns.Add("Amount");
                dtDatas1.Columns.Add("idate", typeof(int));
                dtDatas1.Columns.Add("Verification_date");
                dtDatas1.Columns.Add("Verification_time");
                //store the state of the datatable into a ViewState object
                ViewState["dtDatas1"] = dtDatas1;
            }
            if (ViewState["dtDatas2"] == null)
            {
                DataTable dtDatas2 = new DataTable();
                dtDatas2.Columns.Add("MemberCode");
                dtDatas2.Columns.Add("MemberName");
                dtDatas2.Columns.Add("Sponsorcode");
                dtDatas2.Columns.Add("Sponsorname");
                dtDatas2.Columns.Add("DOJ");
                dtDatas2.Columns.Add("Placement");
                dtDatas2.Columns.Add("Package");
                dtDatas2.Columns.Add("Point");
                dtDatas2.Columns.Add("Amount");
                dtDatas2.Columns.Add("idate", typeof(int));
                dtDatas2.Columns.Add("Verification_date");
                dtDatas2.Columns.Add("Verification_time");
                //store the state of the datatable into a ViewState object
                ViewState["dtDatas2"] = dtDatas2;
            }

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
                dtDatas.Columns.Add("Verification_date");
                dtDatas.Columns.Add("Verification_time");
                //store the state of the datatable into a ViewState object
                ViewState["dtDatas"] = dtDatas;
            }

            ArrayList al = new ArrayList();
            ArrayList a2 = new ArrayList();
            ArrayList a3 = new ArrayList();

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

                pnl_view.Visible = false;
                pnlRight.Visible = false;
                pnlMiddle.Visible = false;

            }
            else
            {


                pnl_view.Visible = true;
                pnlRight.Visible = true;
                pnlMiddle.Visible = true;

                string left_child = dt.Rows[0][3].ToString();
                string right_child = dt.Rows[0][4].ToString();
                string middle_child = dt.Rows[0][11].ToString();

                if (left_child != "")
                {
                    al.Add(left_child);
                }
                if (middle_child != "")
                {
                    a3.Add(middle_child);
                }
                if (right_child != "")
                {
                    a2.Add(right_child);
                }

                bind_left_child(al);
                bind_right_child(a2);
                bind_middle_child(a3);
            }


        }



        #region Left Child
        private void bind_left_child(ArrayList al)
        {
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
            if (al.Count == 0)
            {
                grd_left.DataSource = null;
                grd_left.DataBind();
            }
            else
            {

                grd_left.DataSource = ViewState["dtDatas"];
                grd_left.DataBind();
                lbl_left.Text = al.Count.ToString();

                int j = grd_left.Rows.Count;
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
                //  lbl_left_bv.Text = points.ToString();

            }
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

        #endregion Left Child

        #region Right Child
        private void bind_right_child(ArrayList a2)
        {
            string membercode = "";
            for (int i = 0; i < a2.Count; i++)
            {
                membercode = a2[i].ToString();
                string left_child1 = find_the_left_child(membercode);
                string right_child1 = find_the_right_child(membercode);
                string middle_child1 = find_the_middle_child(membercode);

                if (left_child1 != "")
                {
                    a2.Add(left_child1);
                }

                if (middle_child1 != "")
                {
                    a2.Add(middle_child1);
                }

                if (right_child1 != "")
                {
                    a2.Add(right_child1);
                }
                Connection con = new Connection();
                string connect = con.connect_method();
                SqlConnection conn = new SqlConnection(connect);
                SqlDataAdapter ad1 = new SqlDataAdapter("Select * from Member_registration where Member_code ='" + a2[i].ToString() + "'", conn);
                DataSet ds1 = new DataSet();
                ad1.Fill(ds1, "Member_registration");
                DataTable dt1 = ds1.Tables[0];
                int rowcount1 = ds1.Tables[0].Rows.Count;
                if (rowcount1 == 0)
                {
                }
                else
                {
                    DataTable dtDatas1 = (DataTable)ViewState["dtDatas1"];
                    DataRow drNewRow2 = dtDatas1.NewRow();
                    drNewRow2["MemberCode"] = membercode;
                    drNewRow2["MemberName"] = dt1.Rows[0][4].ToString();
                    drNewRow2["Sponsorcode"] = dt1.Rows[0][1].ToString();
                    drNewRow2["Sponsorname"] = dt1.Rows[0][2].ToString();
                    drNewRow2["DOJ"] = dt1.Rows[0][5].ToString();
                    drNewRow2["Placement"] = dt1.Rows[0][33].ToString();
                    drNewRow2["Package"] = dt1.Rows[0][32].ToString();
                    drNewRow2["Point"] = dt1.Rows[0][54].ToString();
                    drNewRow2["Amount"] = dt1.Rows[0][30].ToString();

                    drNewRow2["Verification_date"] = dt1.Rows[0][42].ToString();

                    drNewRow2["Verification_time"] = dt1.Rows[0][43].ToString();

                    string DOJ = dt1.Rows[0][5].ToString();
                    string date = DOJ.Substring(0, 2);
                    string month = DOJ.Substring(3, 2);
                    string year = DOJ.Substring(6, 4);

                    drNewRow2["idate"] = Convert.ToInt32(year + month + date);
                    //add this new row to the Datatable and commit changes
                    dtDatas1.Rows.Add(drNewRow2);
                    dtDatas1.AcceptChanges();
                    ViewState["dtDatas1"] = dtDatas1;

                }

            }
            if (a2.Count == 0)
            {
                grd_right.DataSource = null;
                grd_right.DataBind();
            }
            else
            {

                grd_right.DataSource = ViewState["dtDatas1"];
                grd_right.DataBind();
                lbl_right.Text = a2.Count.ToString();

                int j = grd_right.Rows.Count;
                double points = 0.0;
                for (int k = 0; k < j; k++)
                {
                    //string bvpoint = grd_left.Rows[k].Cells[6].Text;
                    Label lblpoint = (Label)grd_right.Rows[k].FindControl("lblPoint");
                    if (lblpoint.Text != "")
                    {
                        points = points + Convert.ToDouble(lblpoint.Text);
                    }
                }

                // lbl_right_bv.Text = points.ToString();

                ViewState["dtDatas1"] = null;
            }
        }
        #endregion Right Child

        #region Middle Child
        private void bind_middle_child(ArrayList a3)
        {
            string membercode = "";
            for (int i = 0; i < a3.Count; i++)
            {
                membercode = a3[i].ToString();
                string left_child1 = find_the_left_child(membercode);
                string right_child1 = find_the_right_child(membercode);
                string middle_child1 = find_the_middle_child(membercode);

                if (left_child1 != "")
                {
                    a3.Add(left_child1);
                }
                if (middle_child1 != "")
                {
                    a3.Add(middle_child1);
                }
                if (right_child1 != "")
                {
                    a3.Add(right_child1);
                }
                Connection con = new Connection();
                string connect = con.connect_method();
                SqlConnection conn = new SqlConnection(connect);
                SqlDataAdapter ad1 = new SqlDataAdapter("Select * from Member_registration where Member_code ='" + a3[i].ToString() + "'", conn);
                DataSet ds1 = new DataSet();
                ad1.Fill(ds1, "Member_registration");
                DataTable dt1 = ds1.Tables[0];
                int rowcount1 = ds1.Tables[0].Rows.Count;
                if (rowcount1 == 0)
                {
                }
                else
                {
                    DataTable dtDatas2 = (DataTable)ViewState["dtDatas2"];
                    DataRow drNewRow2 = dtDatas2.NewRow();
                    drNewRow2["MemberCode"] = membercode;
                    drNewRow2["MemberName"] = dt1.Rows[0][4].ToString();
                    drNewRow2["Sponsorcode"] = dt1.Rows[0][1].ToString();
                    drNewRow2["Sponsorname"] = dt1.Rows[0][2].ToString();
                    drNewRow2["DOJ"] = dt1.Rows[0][5].ToString();
                    drNewRow2["Placement"] = dt1.Rows[0][33].ToString();
                    drNewRow2["Package"] = dt1.Rows[0][32].ToString();
                    drNewRow2["Point"] = dt1.Rows[0][54].ToString();
                    drNewRow2["Amount"] = dt1.Rows[0][30].ToString();

                    drNewRow2["Verification_date"] = dt1.Rows[0][42].ToString();

                    drNewRow2["Verification_time"] = dt1.Rows[0][43].ToString();

                    string DOJ = dt1.Rows[0][5].ToString();
                    string date = DOJ.Substring(0, 2);
                    string month = DOJ.Substring(3, 2);
                    string year = DOJ.Substring(6, 4);

                    drNewRow2["idate"] = Convert.ToInt32(year + month + date);
                    //add this new row to the Datatable and commit changes
                    dtDatas2.Rows.Add(drNewRow2);
                    dtDatas2.AcceptChanges();
                    ViewState["dtDatas2"] = dtDatas2;

                }

            }
            if (a3.Count == 0)
            {
                grdMiddle.DataSource = null;
                grdMiddle.DataBind();
            }
            else
            {

                grdMiddle.DataSource = ViewState["dtDatas2"];
                grdMiddle.DataBind();
                lblMiddleMember.Text = a3.Count.ToString();

                int j = grdMiddle.Rows.Count;
                double points = 0.0;
                for (int k = 0; k < j; k++)
                {
                    //string bvpoint = grd_left.Rows[k].Cells[6].Text;
                    Label lblpoint = (Label)grdMiddle.Rows[k].FindControl("lblPoint");
                    if (lblpoint.Text != "")
                    {
                        points = points + Convert.ToDouble(lblpoint.Text);
                    }
                }

                // lbl_right_bv.Text = points.ToString();

                ViewState["dtDatas2"] = null;
            }
        }
        #endregion Middle Child

        #region export_gridview_in_excel

        protected void img_export_Click(object sender, ImageClickEventArgs e)
        {
            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dtm.ToString("dd/MM/yyyy");
            Session["today"] = date;
            string excelname = Session["today"] + "leftgenealogy.xls";
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
            // fillgridview();
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
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dtm.ToString("dd/MM/yyyy");
            Session["today"] = date;
            string excelname = Session["today"] + "rightgenealogy.xls";
            export_to_excel(grd_right, excelname);
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

        protected void grd_right_Sorting(object sender, GridViewSortEventArgs e)
        {//Retrieve the table from the session object.
            DataTable dt1 = (DataTable)ViewState["dtDatas1"];
            // DataTable dt = ViewState["dtDatas"] as DataTable;

            if (dt1 != null)
            {

                //Sort the data.
                dt1.DefaultView.Sort = e.SortExpression + " " + GetSortDirection1(e.SortExpression);
                grd_left.DataSource = ViewState["dtDatas1"];
                grd_left.DataBind();
            }

        }

        private string GetSortDirection1(string column)
        {
            // By default, set the sort direction to ascending.
            string sortDirection = "ASC";

            // Retrieve the last column that was sorted.
            string sortExpression = ViewState["SortExpression1"] as string;

            if (sortExpression != null)
            {
                // Check if the same column is being sorted.
                // Otherwise, the default value can be returned.
                if (sortExpression == column)
                {
                    string lastDirection = ViewState["SortDirection1"] as string;
                    if ((lastDirection != null) && (lastDirection == "ASC"))
                    {
                        sortDirection = "DESC";
                    }
                }
            }

            // Save new values in ViewState.
            ViewState["SortDirection1"] = sortDirection;
            ViewState["SortExpression1"] = column;

            return sortDirection;
        }
        #endregion gridview_sorting

        My mycode = new My();

        double tot_left_pv = 0;
        protected void grd_left_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblPoint = (Label)e.Row.FindControl("lblPoint");
                    if (!string.IsNullOrEmpty(lblPoint.Text))
                    {
                        tot_left_pv = tot_left_pv + Convert.ToDouble(lblPoint.Text);
                    }
                }
                //  lbl_left_bv.Text = tot_left_pv.ToString();

            }
            catch (Exception ex)
            {
                My.submitException(ex);
            }
        }
        double tot_right_pv = 0;
        protected void grd_right_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Label lblPoint = (Label)e.Row.FindControl("lblPoint");
                    if (!string.IsNullOrEmpty(lblPoint.Text))
                    {
                        tot_right_pv = tot_right_pv + Convert.ToDouble(lblPoint.Text);
                    }
                }
                //lbl_right_bv.Text = tot_left_pv.ToString();
            }
            catch (Exception ex)
            {
                My.submitException(ex);
            }
        }
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

        protected void grdMiddle_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void grdMiddle_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}