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
using System.Globalization;
using System.IO;
using System.Text;
using System.Drawing;
using Master_MLM.App_Code;

namespace Master_MLM.Member_4235profile
{
    public partial class Repurchase_carry_forward_ClosingReport : System.Web.UI.Page
    {
        string scrpt;
        string format = "dd/MM/yyyy";
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
                    try
                    {


                        fill_gridview();
                    }
                    catch
                    {
                    }

                }
            }
        }

        #region find_data
        Important imp = new Important();
        private void fill_gridview()
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
                dtdatas.Columns.Add("Lapsepair");
                ViewState["dtdatas"] = dtdatas;
            }

            string sql = " select  *,(select Member_name from Member_registration where Member_code=t1.Membercode) as Member_name from dbo.[Repurchase_Daily_child_table] t1 where Membercode='" + membercode + "' order by Deleteid";
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
                grd_view.DataSource = ViewState["dtdatas"];
                grd_view.DataBind();
                ViewState["dtdatas"] = null;
                pnl_view.Visible = true;

            }
            else
            {
                grd_view.DataSource = ViewState["dtdatas"];
                grd_view.DataBind();
                ViewState["dtdatas"] = null;
                pnl_view.Visible = true;

            }
        }

        private string find_previous_child(string Membercode, string Deleteid)
        {
            string sql = "Select top 1 Total_leftchild,Total_rightchild from dbo.[Repurchase_Daily_child_table] where Membercode='" + Membercode + "' and Deleteid<" + Deleteid + " order by id desc";
            DataTable dt = imp.FillTable(sql);
            int rowcount = dt.Rows.Count;
            if (rowcount > 0)
            {
                return dt.Rows[0][0].ToString() + "^" + dt.Rows[0][1].ToString();
            }
            else { return "0^0"; }
        }



        protected void grd_view_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_view.PageIndex = e.NewPageIndex;
            fill_gridview();

        }
        #endregion find_data

        #region export_gridview_in_excel
        protected void img_export_Click(object sender, ImageClickEventArgs e)
        {

            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dtm.ToString("dd/MM/yyyy");
            Session["today"] = date;
            string excelname = Session["today"] + "closingpairreport.xls";
            export_to_excel(grd_view, excelname);
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


    }
}