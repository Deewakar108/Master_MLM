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

namespace Master_MLM.Member_4235profile
{
    public partial class Allocated_pin_list : System.Web.UI.Page
    {
        string scrpt;
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
                        find_package();
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
        My mycode = new My();
        private void find_package()
        {
            mycode.bind_all_ddl_with_id(ddl_package, "Select Package_name,Package_id from Joining_package ORDER BY Package_name", "Package_name", "Package_id");
        }
        protected void ddl_package_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddl_package.SelectedItem.Text == "Select")
            {
                pnl_view.Visible = false;

                grd_epin.DataSource = null;
                grd_epin.DataBind();
                lbl_message1.Text = "Select package ";
                scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
            }
            else
            {
                fetch_epin_list();
            }
        }

        private void fetch_epin_list()
        {

            string membercode = Session["membercode"].ToString();
            string status = "GIVEN";
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from E_PIN_details where  distributed_to ='" + membercode + "' and Status='" + status + "' and  Package_id='" + ddl_package.SelectedValue + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "E_PIN_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                pnl_view.Visible = false;

                lbl_message1.Text = "Sorry! no pin found";
                scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
                grd_epin.DataSource = null;
                grd_epin.DataBind();
            }
            else
            {
                pnl_view.Visible = true;

                grd_epin.DataSource = ds;
                grd_epin.DataBind();
            }
        }



        private double find_epain_amount(string pin)
        {
            string query = @"Select JP.Package_amount from E_PIN_details  EPD join Joining_package JP on  EPD.Package_id=JP.Package_id where EPD.Epin='" + pin + "' and EPD.Status='GIVEN' ";
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter(query, coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "E_PIN_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                return 0.0;
            }
            else
            {
                return Convert.ToDouble(dt.Rows[0][0].ToString());
            }

        }



        protected void img_export_Click(object sender, ImageClickEventArgs e)
        {

            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dtm.ToString("dd/MM/yyyy");
            Session["today"] = date;
            string excelname = Session["today"] + "Allocatedpin.xls";
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
            fetch_epin_list();
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

        protected void lnk_btn_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lnk.Parent.Parent;
            int idx = row.RowIndex;
            Label lbl_epin = (Label)grd_epin.Rows[idx].FindControl("lbl_epin");
            Label lbl_packag_id = (Label)grd_epin.Rows[idx].FindControl("lbl_packag_id");

            Session["pin"] = lbl_epin.Text;
            double package_amount = find_package_amount(lbl_packag_id.Text);
            if (find_epain_amount(lbl_epin.Text) > 0.0)
            {

                Response.Redirect("Activate_your_id.aspx", false);

            }


        }
        protected void lnk_btn_upgrade_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lnk.Parent.Parent;
            int idx = row.RowIndex;
            Label lbl_epin = (Label)grd_epin.Rows[idx].FindControl("lbl_epin");
            Label lbl_packag_id = (Label)grd_epin.Rows[idx].FindControl("lbl_packag_id");

            Session["pin"] = lbl_epin.Text;
            double package_amount = find_package_amount(lbl_packag_id.Text);
            if (find_epain_amount(lbl_epin.Text) > 0.0)
            {
                if (package_amount < 15000)
                {
                    Response.Redirect("Upgrade_Member.aspx", false);
                }
                else if (package_amount == 15000)
                {
                    lbl_message1.Text = "Sorry! you have not authorized to upgrade this pin";
                    scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
                }
                else
                {
                    lbl_message1.Text = "Sorry! you have not authorized to active this pin";
                    scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
                }
            }
        }

        private double find_package_amount(string packag_id)
        {
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select  Package_amount from Joining_package where Package_id='" + packag_id + "'   ", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Joining_package");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                return 0;
            }
            else
            {
                return Convert.ToDouble(dt.Rows[0]["Package_amount"].ToString());
            }
        }

        protected void grd_epin_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EPIN")
            {
                string epin = e.CommandArgument.ToString();
                Session["epin"] = epin;
                Response.Redirect("add_member.aspx");
            }
        }
    }
}