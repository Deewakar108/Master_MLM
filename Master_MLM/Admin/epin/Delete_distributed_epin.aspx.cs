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
using System.Text;
using Master_MLM.App_Code;

namespace Master_MLM.Admin
{
    public partial class Delete_distributed_epin : System.Web.UI.Page
    {
        string status_d = "GIVEN";
        DateTime dtToday = DateTime.UtcNow.AddHours(5).AddMinutes(30);
        public void GridBinding()
        {
            grd_epin_distributed.AllowPaging = false;
            grd_epin_distributed.DataBind();

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            if (!IsPostBack)
            {

                //    DataTable dtdatas = new DataTable();
                //    dtdatas.Columns.Add("Membercode");
                //    dtdatas.Columns.Add("membername");
                //    dtdatas.Columns.Add("Totalallocatedpin");
                //    ViewState["dtdatas"] = dtdatas;
                featch_allocated_pin();//total allocated pin
            }
        }

        private void featch_allocated_pin()
        {
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select epd.distributed_to,epd.Epin,epd.ID,epd.Package,mr.Member_name from E_PIN_details epd join Member_registration mr on epd.distributed_to=mr.Member_code  where epd.Status='" + status_d + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "temp");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                lbl_message_d.Text = "Sorry! no data found.";
                pnl_view.Visible = false;
                grd_epin_distributed.DataSource = null;
                grd_epin_distributed.DataBind();
            }
            else
            {
                lbl_message_d.Text = "";
                pnl_view.Visible = true;
                grd_epin_distributed.DataSource = ds;
                grd_epin_distributed.DataBind();
            }
        }
        protected void btn_checkall_Click(object sender, EventArgs e)
        {
            //Button btn = (Button)sender;
            if (btn_checkall.Text == "Check All")
            {
                checkall();
                btn_checkall.Text = "Clear All";
            }
            else
            {
                clearall();
                btn_checkall.Text = "Check All";
            }
        }
        private void checkall()
        {
            int growcount = grd_epin_distributed.Rows.Count;
            for (int i = 0; i < growcount; i++)
            {
                CheckBox chk = (CheckBox)grd_epin_distributed.Rows[i].FindControl("CheckBox1");
                chk.Checked = true;
            }

        }
        private void clearall()
        {
            int growcount = grd_epin_distributed.Rows.Count;
            for (int i = 0; i < growcount; i++)
            {
                CheckBox chk = (CheckBox)grd_epin_distributed.Rows[i].FindControl("CheckBox1");
                chk.Checked = false;
            }

        }

        protected void grd_epin_distributed_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_epin_distributed.PageIndex = e.NewPageIndex;
            featch_allocated_pin();//total allocated pin
            grd_epin_distributed.DataBind();
        }
        protected void btn_delete_Click(object sender, EventArgs e)
        {
            lbl_msg.Text = "";
            lbl_message_d.Text = "";
            int j = 0;
            int growcount = grd_epin_distributed.Rows.Count;
            for (int i = 0; i < growcount; i++)
            {
                CheckBox chk = (CheckBox)grd_epin_distributed.Rows[i].FindControl("CheckBox1");
                if (chk.Checked == true)
                {
                    Label lblid = (Label)grd_epin_distributed.Rows[i].FindControl("lbl_id");
                    delete_data(lblid.Text);
                }
                else
                {
                    j++;
                }
            }
            if (j == growcount)
            {
                lbl_message_d.Text = "Please check checkbox then click delete button.";
            }
            featch_allocated_pin();//total allocated pin
        }
        private void delete_data(string id)
        {
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from E_PIN_details where ID='" + id + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "E_PIN_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            { }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dr[5] = dtToday.ToString("dd/MM/yyyy");
                    dr[6] = "DELETED";
                    //dr.Delete();
                    SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
                    ad.Update(dt);
                    lbl_msg.Text = "Data has been deleted.";
                    break;
                }

            }
        }

        #region export_gridview_in_excel
        protected void img_exportgrd_Click(object sender, ImageClickEventArgs e)
        {

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Distributedepin.xls"));
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            grd_epin_distributed.AllowPaging = false;
            featch_allocated_pin();
            grd_epin_distributed.HeaderRow.Style.Add("background-color", "#FFFFFF");
            for (int a = 0; a < grd_epin_distributed.HeaderRow.Cells.Count; a++)
            {
                grd_epin_distributed.HeaderRow.Cells[a].Style.Add("background-color", "#507CD1");
            }
            int j = 1;
            foreach (GridViewRow gvrow in grd_epin_distributed.Rows)
            {
                grd_epin_distributed.BackColor = Color.White;
                if (j <= grd_epin_distributed.Rows.Count)
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
            grd_epin_distributed.RenderControl(htw);
            Response.Write(sw.ToString());
            Response.End();


        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        #endregion export_gridview_in_excel

        //#region print all page
        //protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        //{
        //    PrintAllPages();
        //}

        //private void PrintAllPages()
        //{
        //    grd_epin_distributed.AllowPaging = false;
        //    featch_allocated_pin();
        //    grd_epin_distributed.DataBind();

        //    StringWriter sw = new StringWriter();

        //    HtmlTextWriter hw = new HtmlTextWriter(sw);

        //    grd_epin_distributed.RenderControl(hw);

        //    string gridHTML = sw.ToString().Replace("\"", "'")

        //        .Replace(System.Environment.NewLine, "");

        //    StringBuilder sb = new StringBuilder();

        //    sb.Append("<script type = 'text/javascript'>");

        //    sb.Append("window.onload = new function(){");

        //    sb.Append("var printWin = window.open('', '', 'left=0");

        //    sb.Append(",top=0,width=1000,height=600,status=0');");

        //    sb.Append("printWin.document.write(\"");

        //    sb.Append(gridHTML);

        //    sb.Append("\");");

        //    sb.Append("printWin.document.close();");

        //    sb.Append("printWin.focus();");

        //    sb.Append("printWin.print();");

        //    sb.Append("printWin.close();};");

        //    sb.Append("</script>");

        //    ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());
        //    Page page = HttpContext.Current.CurrentHandler as Page;
        //    page.ClientScript.RegisterStartupScript(typeof(Page), "Test", "GridPrint");


        //    grd_epin_distributed.AllowPaging = true;
        //    featch_allocated_pin();
        //    grd_epin_distributed.DataBind();
        //}
        //#endregion print all page


    }
}
