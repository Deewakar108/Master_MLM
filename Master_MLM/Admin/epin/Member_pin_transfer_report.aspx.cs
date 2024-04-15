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
using System.Collections.Generic;
using Master_MLM.App_Code;

namespace Master_MLM.Admin
{
    public partial class Member_pin_transfer_report : System.Web.UI.Page
    {
        My mycode = new My();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dtdatas = new DataTable();
                dtdatas.Columns.Add("Membercode");
                dtdatas.Columns.Add("Membername");
                dtdatas.Columns.Add("Transfer_to");
                dtdatas.Columns.Add("Transferto_name");
                dtdatas.Columns.Add("Total_pin");
                ViewState["dtdatas"] = dtdatas;
                fetch_year();
            }
        }

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
            ddl_year.DataSource = ar;
            ddl_year.DataBind();
            DateTime dt = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dt.ToString("dd/MM/yyyy");
            string day = date.Substring(0, 2);
            string month = date.Substring(3, 2);
            string year = date.Substring(6, 4);
            
            ddl_month.Text = month;
            ddl_year.Text = year;
        }

        #region page event
        protected void rb_month_CheckedChanged(object sender, EventArgs e)
        {

            ddl_month.Visible = true;
            ddl_year.Visible = true;

        }
        protected void rb_yearly_CheckedChanged(object sender, EventArgs e)
        {

            ddl_month.Visible = false;
            ddl_year.Visible = true;
        }
        #endregion page event
        #region find data
        protected void btn_find_Click(object sender, EventArgs e)
        {
            if (rb_month.Checked == false && rb_yearly.Checked == false)
            {
                pnl_view.Visible = false;
                lbl_message.Text = "Please select type.";
            }
            else
            {
                pnl_view.Visible = true;
                lbl_message.Text = "";
                fin_data();
            }
        }

        private void fin_data()
        {
            if (rb_month.Checked == true)
            {
                find_monthly();
            }
            else
            {

                find_yearly();
            }
        }

        private void find_monthly()
        {
            if (ViewState["dtdatas"] == null)
            {
                DataTable dtdatas = new DataTable();
                dtdatas.Columns.Add("Membercode");
                dtdatas.Columns.Add("Membername");
                dtdatas.Columns.Add("Transfer_to");
                dtdatas.Columns.Add("Transferto_name");
                dtdatas.Columns.Add("Total_pin");
                ViewState["dtdatas"] = dtdatas;

            }

            string month = ddl_month.Text + "/" + ddl_year.Text;
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select distinct Transfer_to,Transferto_name,Memberid,Member_name from Transfer_epin_member where Transfer_date like'%" + month + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Transfer_epin_member");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                pnl_view.Visible = false;
                lbl_message.Text = "Sorry! no data found";
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

                    drNewRow["Membercode"] = dt.Rows[j][2].ToString();
                    drNewRow["Membername"] = dt.Rows[j][3].ToString();
                    drNewRow["Transfer_to"] = dt.Rows[j][0].ToString();
                    drNewRow["Transferto_name"] = dt.Rows[j][1].ToString();
                    drNewRow["Total_pin"] = total_allocated_pin(dt.Rows[j][2].ToString(), dt.Rows[j][0].ToString());
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
                ViewState["dtdatas"] = null;
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
        private void find_yearly()
        {
            if (ViewState["dtdatas"] == null)
            {
                DataTable dtdatas = new DataTable();
                dtdatas.Columns.Add("Membercode");
                dtdatas.Columns.Add("Membername");
                dtdatas.Columns.Add("Transfer_to");
                dtdatas.Columns.Add("Transferto_name");
                dtdatas.Columns.Add("Total_pin");
                ViewState["dtdatas"] = dtdatas;

            }

            string year = ddl_year.Text;
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select distinct Transfer_to,Transferto_name,Memberid,Member_name from Transfer_epin_member where Transfer_date like'%" + year + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Transfer_epin_member");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                pnl_view.Visible = false;
                lbl_message.Text = "Sorry! no data found";
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

                    drNewRow["Membercode"] = dt.Rows[j][2].ToString();
                    drNewRow["Membername"] = dt.Rows[j][3].ToString();
                    drNewRow["Transfer_to"] = dt.Rows[j][0].ToString();
                    drNewRow["Transferto_name"] = dt.Rows[j][1].ToString();
                    drNewRow["Total_pin"] = total_allocated_pin(dt.Rows[j][2].ToString(), dt.Rows[j][0].ToString());
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
                ViewState["dtdatas"] = null;
            }
        }
        #endregion find data

        protected void img_expord_Click(object sender, ImageClickEventArgs e)
        {
            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dtm.ToString("dd/MM/yyyy");
            Session["today"] = date;
            string excelname = Session["today"] + "Memberpintransferreport.xls";
            export_to_excel(grd_epin, excelname);
        }

        #region export_gridview_in_excel
        private void export_to_excel(GridView grd_view, string excelname)
        {
            if (grd_view.HeaderRow.Cells.Count == 0) { return; }
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", excelname));
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            grd_view.AllowPaging = false;
            fin_data();
            //grd_view.HeaderRow.Style.Add("background-color", "#FFFFFF");
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
