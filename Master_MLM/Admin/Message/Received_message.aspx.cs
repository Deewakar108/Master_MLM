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
using System.IO;
using System.Drawing;
using Master_MLM.App_Code;

namespace Master_MLM.Admin
{
    public partial class Received_message : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
                if (!IsPostBack)
                {
                    fill_gridview();
                    DateTime dt = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                    string date = dt.ToString("dd/MM/yyyy");
                    string day = date.Substring(0, 2);
                    string month = date.Substring(3, 2);
                    string year = date.Substring(6, 4);
                    Session["today"] = date;
                }
            }
        }

        private void fill_gridview()
        {
            string receiverid = "Admin";
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from message_corner where Receiver_id='" + receiverid + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "message_corner");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;

            if (rowcount == 0)
            {
                lbl_message.Text = "There is no any message";
                pnl_reply.Visible = false;
                pnl_view_message.Visible = false;
                grd_view_received_message.DataSource = null;
                grd_view_received_message.DataBind();
            }
            else
            {
                lbl_message.Text = "";

                pnl_view_message.Visible = true;
                grd_view_received_message.DataSource = ds;
                grd_view_received_message.DataBind();
            }
        }
        #region Page Event
        protected void grd_view_received_message_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_view_received_message.PageIndex = e.NewPageIndex;
            grd_view_received_message.DataBind();
            fill_gridview();
        }

        #region reply
        protected void lnk_reply_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lnk.Parent.Parent;
            Label sender_id = (Label)row.FindControl("lbl_from");
            Label receiver_id = (Label)row.FindControl("lbl_receiver_id");
            Label receiver_name = (Label)row.FindControl("lbl_name");

            Session["senderid"] = sender_id.Text;
            Session["receiverid"] = receiver_id.Text;
            Session["name"] = receiver_name.Text;
            pnl_reply.Visible = true;
            lbl_to.Text = sender_id.Text;
        }
        protected void btn_send_Click(object sender, EventArgs e)
        {
            if (Session["receiverid"].ToString() == "Admin")
            {
                Connection con = new Connection();
                string Connectionstring = con.connect_method();
                SqlConnection conn = new SqlConnection(Connectionstring);
                SqlDataAdapter ad = new SqlDataAdapter("select * from message_corner", conn);
                DataSet ds = new DataSet();
                ad.Fill(ds, "message_corner");
                DataTable dt = ds.Tables[0];
                DataRow dr = dt.NewRow();
                dr[0] = Session["receiverid"].ToString();
                dr[1] = "";
                dr[2] = Session["senderid"].ToString();
                dr[3] = Session["name"].ToString();
                dr[4] = txt_subject.Text;
                dr[5] = txt_message.Text;
                dr[6] = Session["today"].ToString();
                dt.Rows.Add(dr);
                SqlCommandBuilder cb = new SqlCommandBuilder(ad);
                ad.Update(dt);
                lbl_reply_message.Text = "Your message has been sent.";
                txt_subject.Text = "";
                txt_message.Text = "";

            }
        }
        #endregion reply


        #endregion Page Event
        protected void img_expord_Click(object sender, ImageClickEventArgs e)
        {
            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dtm.ToString("dd/MM/yyyy");
            Session["today"] = date;
            string excelname = Session["today"].ToString() + "Receivedmsg.xls";
            export_to_excel(grd_view_received_message, excelname);
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
