using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Master_MLM.App_Code;
using System.Data;
using System.IO;
using System.Drawing;

namespace Master_MLM.Member_4235profile
{
    public partial class Upload_Bank_Payment_History_List : System.Web.UI.Page
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
                    string mypage = Request.QueryString["mypage"];
                    if (!String.IsNullOrEmpty(mypage))
                    {
                        string page = mycode.Unzip(mypage);

                        if (page == mycode.Unzip(Session["verify"].ToString()))
                        {
                            if (!IsPostBack)
                            {

                                DateTime dt = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                                string date = dt.ToString("dd/MM/yyyy");

                                Session["today"] = date;

                                fetch_list();

                            }
                        }
                        else
                        {
                            Session.Abandon();
                            Session.Clear();
                            Response.Write("<script language=javascript>var wnd=window.open('','newWin','height=1,width=1,left=900,top=700,status=no,toolbar=no,menubar=no,scrollbars=no,maximize=false,resizable=1');</script>");
                            Response.Write("<script language=javascript>wnd.close();</script>");
                            Response.Write("<script language=javascript>window.open('../Default.aspx','_parent',replace=true);</script>");
                        }
                    }
                    else
                    {

                        Session.Abandon();
                        Session.Clear();
                        Response.Write("<script language=javascript>var wnd=window.open('','newWin','height=1,width=1,left=900,top=700,status=no,toolbar=no,menubar=no,scrollbars=no,maximize=false,resizable=1');</script>");
                        Response.Write("<script language=javascript>wnd.close();</script>");
                        Response.Write("<script language=javascript>window.open('../Default.aspx','_parent',replace=true);</script>");
                    }

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

        private void fetch_list()
        {
            string membercode = Session["membercode"].ToString();
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from Update_bank_payment where  Member_code ='" + membercode + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Update_bank_payment");
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
                pnl_view.Visible = true;
                lbl_msg.Text = "";
                grd_epin.DataSource = ds;
                grd_epin.DataBind();
            }
        }
        protected void img_export_Click(object sender, ImageClickEventArgs e)
        {
            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dtm.ToString("dd/MM/yyyy");
            Session["today"] = date;
            string excelname = Session["today"] + "Upload_bank_payment_status_list.xls";
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
            fetch_list();
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