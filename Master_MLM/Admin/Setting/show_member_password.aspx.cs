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
    public partial class show_member_password : System.Web.UI.Page
    {
        Important imp = new Important();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fill_gridview();
            }
        }

        private void fill_gridview()
        {
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select  p.Member_code, p.Member_name, p.Mobile_number,p.Nominee_name,ml.Pwd,ml.Transaction_Password from Member_registration p join Member_Login ml on p.Member_code =ml.User_id order by p.Id ASC", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "temp_payout");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                lbl_message.Text = "Sorry! no data found.";
                grd_view.DataSource = null;
                grd_view.DataBind();
                pnl_view.Visible = false;
            }
            else
            {
                lbl_message.Text = "";
                grd_view.DataSource = ds;
                grd_view.DataBind();
                pnl_view.Visible = true;
            }

        }

        protected void grd_view_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_view.PageIndex = e.NewPageIndex;
            grd_view.DataBind();
            fill_gridview();
        }
        My mycode = new My();
        protected void btn_find_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_memberid.Text == "")
                {
                    lbl_msg.Text = "Enter member code";
                }
                else if (txt_memberid.Text == imp.AdminCode)
                {
                    lbl_msg.Text = "Enter member code is wrong";
                }
                else
                {
                    string codenumber = txt_memberid.Text;
                    find_memberpwd(codenumber);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void find_memberpwd(string codenumber)
        {
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select  p.Member_code, p.Member_name, p.Mobile_number,p.Nominee_name,ml.Pwd,ml.Transaction_Password from Member_registration p join Member_Login ml on p.Member_code =ml.User_id where  p.Member_code='" + codenumber + "' order by p.Id ASC", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "temp_payout");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                lbl_msg.Text = "Sorry! no data found.";
                grd_view.DataSource = null;
                grd_view.DataBind();
            }
            else
            {
                lbl_message.Text = "";
                grd_view.DataSource = ds;
                grd_view.DataBind();
            }
        }

        protected void img_expord_Click(object sender, ImageClickEventArgs e)
        {
            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dtm.ToString("dd/MM/yyyy");
            Session["today"] = date;
            string excelname = Session["today"].ToString() + "Memberpassword.xls";
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
