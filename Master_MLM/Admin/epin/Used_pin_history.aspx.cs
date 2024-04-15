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
    public partial class Used_pin_history : System.Web.UI.Page
    {
        string status_d = "USED";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dtdatas = new DataTable();
                dtdatas.Columns.Add("Membercode");
                dtdatas.Columns.Add("membername");
                dtdatas.Columns.Add("Totalallocatedpin");
                ViewState["dtdatas"] = dtdatas;



                DataTable dtdatas1 = new DataTable();
                dtdatas1.Columns.Add("Epin");
                dtdatas1.Columns.Add("Package");
                dtdatas1.Columns.Add("membercode");
                dtdatas1.Columns.Add("usedby");
                dtdatas1.Columns.Add("usedbyname");
                dtdatas1.Columns.Add("usedto");
                dtdatas1.Columns.Add("usedtoname");
                dtdatas1.Columns.Add("status");
                ViewState["dtdatas1"] = dtdatas1;


                featch_used_pin();//total used pin

            }
        }
        #region featch total allocated pin
        private void featch_used_pin()
        {

            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select distinct distributed_to from E_PIN_details where Status='" + status_d + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "E_PIN_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                lbl_message_d.Text = "Sorry! no data found.";
                pnl_member.Visible = false;

                grd_epin_used.DataSource = null;
                grd_epin_used.DataBind();

            }
            else
            {
                int j = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    DataTable dtDatas = (DataTable)ViewState["dtdatas"];
                    DataRow drNewRow = dtDatas.NewRow();
                    drNewRow["Membercode"] = dt.Rows[j][0].ToString();
                    drNewRow["membername"] = find_name(dt.Rows[j][0].ToString());
                    drNewRow["Totalallocatedpin"] = find_total_allocated_pin(dt.Rows[j][0].ToString());
                    //add this new row to the Datatable and commit changes
                    dtDatas.Rows.Add(drNewRow);
                    dtDatas.AcceptChanges();
                    ViewState["dtdatas"] = dtDatas;
                    j = j + 1;
                }
                pnl_member.Visible = true;
                lbl_message_d.Text = "";
                grd_epin_used.DataSource = ViewState["dtdatas"];
                grd_epin_used.DataBind();

                int totalpin = 0;
                int rowcount2 = grd_epin_used.Rows.Count;
                for (int i = 0; i < rowcount2; i++)
                {
                    Label lblpin = (Label)grd_epin_used.Rows[i].FindControl("lbl_pin");
                    totalpin = totalpin + Convert.ToInt32(lblpin.Text);
                }
                lbl_total_pin.Text = totalpin.ToString();

            }

        }

        private object find_name(string membercode)
        {
            string name = "";
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from Member_registration where Member_code='" + membercode + "' ", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {

            }
            else
            {

                name = dt.Rows[0][4].ToString();
            }
            return name;
        }

        private object find_total_allocated_pin(string membercode)
        {

            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from E_PIN_details where distributed_to='" + membercode + "' and Status='" + status_d + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "E_PIN_details");
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
        #endregion featch total allocated pin
        #region page event
        protected void grd_epin_used_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_epin_used.PageIndex = e.NewPageIndex;
            featch_used_pin();//total used pin
            grd_epin_used.DataBind();

        }
        #endregion page event
        #region find
        protected void btn_find_Click(object sender, EventArgs e)
        {

            if (txt_member_code.Text == "")
            {
                lbl_message.Text = "Please enter member code.";
            }
            else
            {
                find_used_pindetails();// find pin member wise
            }
        }

        private void find_used_pindetails()
        {
            if (ViewState["dtdatas1"] == null)
            {
                DataTable dtdatas1 = new DataTable();
                dtdatas1.Columns.Add("Epin");
                dtdatas1.Columns.Add("Package");
                dtdatas1.Columns.Add("membercode");
                dtdatas1.Columns.Add("usedby");
                dtdatas1.Columns.Add("usedbyname");
                dtdatas1.Columns.Add("usedto");
                dtdatas1.Columns.Add("usedtoname");
                dtdatas1.Columns.Add("status");
                ViewState["dtdatas1"] = dtdatas1;
            }

            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from E_PIN_details where distributed_to='" + txt_member_code.Text + "' and Status='" + status_d + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "E_PIN_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                pnl_view.Visible = false;
                lbl_message.Text = "Sorry! data not found.";
                grd_pin_details.DataSource = null;
                grd_pin_details.DataBind();
            }
            else
            {
                for (int i = 0; i < rowcount; i++)
                {
                    DataTable dtDatas1 = (DataTable)ViewState["dtdatas1"];

                    DataRow drNewRow1 = dtDatas1.NewRow();
                    drNewRow1["Epin"] = dt.Rows[i][0].ToString();
                    drNewRow1["Package"] = dt.Rows[i][9].ToString();
                    drNewRow1["Membercode"] = txt_member_code.Text;
                    drNewRow1["usedby"] = dt.Rows[i][3].ToString();
                    drNewRow1["usedbyname"] = find_name(dt.Rows[i][3].ToString());
                    drNewRow1["usedto"] = dt.Rows[i][8].ToString();
                    drNewRow1["usedtoname"] = find_name(dt.Rows[i][8].ToString());
                    drNewRow1["status"] = dt.Rows[i][6].ToString();
                    //add this new row to the Datatable and commit changes
                    dtDatas1.Rows.Add(drNewRow1);
                    dtDatas1.AcceptChanges();
                    ViewState["dtdatas1"] = dtDatas1;

                }
                pnl_view.Visible = true;
                lbl_message.Text = "";
                grd_pin_details.DataSource = ViewState["dtdatas1"];
                grd_pin_details.DataBind();
                ViewState["dtdatas1"] = null;
            }
        }
        #endregion find

        protected void img_expord_Click(object sender, ImageClickEventArgs e)
        {
            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dtm.ToString("dd/MM/yyyy");
            Session["today"] = date;
            string excelname = Session["today"].ToString() + "Usedpinhistory.xls";
            export_to_excel(grd_epin_used, excelname);
        }
        protected void img_usedpindetails_Click(object sender, ImageClickEventArgs e)
        {
            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dtm.ToString("dd/MM/yyyy");
            Session["today"] = date;
            string excelname = Session["today"].ToString() + "Usedpindetails.xls";
            export_to_excel(grd_pin_details, excelname);
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
            featch_used_pin();//total used pin
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
