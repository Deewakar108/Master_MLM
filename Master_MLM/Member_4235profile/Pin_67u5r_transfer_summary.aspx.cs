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
using System.Drawing;
using System.IO;
using Master_MLM.App_Code;

namespace Master_MLM.Member_4235profile
{
    public partial class Pin_67u5r_transfer_summary : System.Web.UI.Page
    {
        My mycode = new My();
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


                #region pagbindin
                try
                {
                    //string mypage = Request.QueryString["mypage"];
                    //if (!String.IsNullOrEmpty(mypage))
                    //{
                    //    string page = mycode.Unzip(mypage);

                    //    if (page == mycode.Unzip(Session["verify"].ToString()))
                    //    {

                    if (!IsPostBack)
                    {
                        DataTable dtdatas = new DataTable();
                        dtdatas.Columns.Add("Transfer_to");
                        dtdatas.Columns.Add("Transferto_name");
                        dtdatas.Columns.Add("Total_pin");
                        ViewState["dtdatas"] = dtdatas;
                        find_transfer_pin_summary();
                    }

                    //    }
                    //    else
                    //    {
                    //        Session.Abandon();
                    //        Session.Clear();
                    //        Response.Write("<script language=javascript>var wnd=window.open('','newWin','height=1,width=1,left=900,top=700,status=no,toolbar=no,menubar=no,scrollbars=no,maximize=false,resizable=1');</script>");
                    //        Response.Write("<script language=javascript>wnd.close();</script>");
                    //        Response.Write("<script language=javascript>window.open('../Default.aspx','_parent',replace=true);</script>");
                    //    }
                    //}
                    //else
                    //{

                    //    Session.Abandon();
                    //    Session.Clear();
                    //    Response.Write("<script language=javascript>var wnd=window.open('','newWin','height=1,width=1,left=900,top=700,status=no,toolbar=no,menubar=no,scrollbars=no,maximize=false,resizable=1');</script>");
                    //    Response.Write("<script language=javascript>wnd.close();</script>");
                    //    Response.Write("<script language=javascript>window.open('../Default.aspx','_parent',replace=true);</script>");
                    //}

                }
                catch
                {
                    Session.Abandon();
                    Session.Clear();
                    Response.Write("<script language=javascript>var wnd=window.open('','newWin','height=1,width=1,left=900,top=700,status=no,toolbar=no,menubar=no,scrollbars=no,maximize=false,resizable=1');</script>");
                    Response.Write("<script language=javascript>wnd.close();</script>");
                    Response.Write("<script language=javascript>window.open('../Default.aspx','_parent',replace=true);</script>");
                }
                #endregion

            }
        }

        private void find_transfer_pin_summary()
        {
            string membercode = Session["membercode"].ToString();
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select distinct Transfer_to,Transferto_name from Transfer_epin_member where Memberid='" + membercode + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Transfer_epin_member");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                pnl_view.Visible = false;
                lbl_msg.Text = "Sorry! no data found";
                grd_epin.DataSource = null;
                grd_epin.DataBind();
            }
            else
            {
                int j = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    DataTable dtDatas = (DataTable)ViewState["dtdatas"];
                    DataRow drNewRow = dtDatas.NewRow();
                    drNewRow["Transfer_to"] = dt.Rows[j][0].ToString();
                    drNewRow["Transferto_name"] = dt.Rows[j][1].ToString();
                    drNewRow["Total_pin"] = total_allocated_pin(membercode, dt.Rows[j][0].ToString());
                    //add this new row to the Datatable and commit changes
                    dtDatas.Rows.Add(drNewRow);
                    dtDatas.AcceptChanges();
                    ViewState["dtdatas"] = dtDatas;
                    j = j + 1;
                }
                lbl_msg.Text = "";
                pnl_view.Visible = true;
                grd_epin.DataSource = ViewState["dtdatas"];
                grd_epin.DataBind();
            }
        }

        private object total_allocated_pin(string membercode, string transferto)
        {
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from Transfer_epin_member where Memberid ='" + membercode + "'and Transfer_to='" + transferto + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Transfer_epin_member");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                return rowcount;
            }
            else
            {

                return rowcount;
            }
        }

        protected void img_export_Click(object sender, ImageClickEventArgs e)
        {

            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dtm.ToString("dd/MM/yyyy");
            Session["today"] = date;
            string excelname = Session["today"] + "Transferpinsummary.xls";
            export_to_excel(grd_epin, excelname);
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
            find_transfer_pin_summary();
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