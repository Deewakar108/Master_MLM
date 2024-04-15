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
    public partial class Distribute_E_Pin_history : System.Web.UI.Page
    {

        string status_d1 = "GIVEN";
        string status_d2 = "USED";
        string status_d3 = "DELETED";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dtdatas = new DataTable();
                dtdatas.Columns.Add("Membercode");
                dtdatas.Columns.Add("membername");
                dtdatas.Columns.Add("Totalallocatedpin");
                dtdatas.Columns.Add("use");
                dtdatas.Columns.Add("rest");
                dtdatas.Columns.Add("deleted");
                ViewState["dtdatas"] = dtdatas;



                DataTable dtdatas1 = new DataTable();
                dtdatas1.Columns.Add("Epin");
                dtdatas1.Columns.Add("Package");
                dtdatas1.Columns.Add("Membercode");
                dtdatas1.Columns.Add("membername");
                dtdatas1.Columns.Add("Totalallocatedpin");
                dtdatas1.Columns.Add("use");
                dtdatas1.Columns.Add("rest");
                dtdatas1.Columns.Add("deleted");
                ViewState["dtdatas1"] = dtdatas1;
                featch_distrubut_pin();         //total used pin
            }
        }

        private void featch_distrubut_pin()
        {
            string distributed_to = "";
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select distinct distributed_to from E_PIN_details where distributed_to !='" + distributed_to + "'", coon);
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

                    drNewRow["use"] = find_use_pin(dt.Rows[j][0].ToString());
                    drNewRow["rest"] = find_rest_pin(dt.Rows[j][0].ToString());
                    drNewRow["deleted"] = find_deleted_pin(dt.Rows[j][0].ToString());



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

        private object find_use_pin(string membercode)
        {
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from E_PIN_details where distributed_to='" + membercode + "' and Status='" + status_d2 + "'", coon);
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

        private object find_rest_pin(string membercode)
        {
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from E_PIN_details where distributed_to='" + membercode + "' and Status='" + status_d1 + "'", coon);
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

        private object find_deleted_pin(string membercode)
        {
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from E_PIN_details where distributed_to='" + membercode + "' and Status='" + status_d3 + "'", coon);
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

        private object find_total_allocated_pin(string membercode)
        {
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from E_PIN_details where distributed_to='" + membercode + "' ", coon);
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

        protected void grd_epin_used_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_epin_used.PageIndex = e.NewPageIndex;
            featch_distrubut_pin();//total used pin
            grd_epin_used.DataBind();
        }
        protected void grd_epin_used_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = grd_epin_used.SelectedRow;
            int idx = row.RowIndex;
            Label lblcode = (Label)grd_epin_used.Rows[idx].FindControl("lbl_membercode");
            Label lblname = (Label)grd_epin_used.Rows[idx].FindControl("lbl_membername");

            string code = lblcode.Text;
            string name = lblname.Text;

            find_packagewise_epin_details(code, name);
            pnl_view.Visible = true;

        }
       
        private void find_packagewise_epin_details(string code, string name)
        {
            if (ViewState["dtdatas1"] == null)
            {
                DataTable dtdatas1 = new DataTable();
                dtdatas1.Columns.Add("Package");
                dtdatas1.Columns.Add("Membercode");
                dtdatas1.Columns.Add("membername");
                dtdatas1.Columns.Add("Totalallocatedpin");
                dtdatas1.Columns.Add("use");
                dtdatas1.Columns.Add("rest");
                dtdatas1.Columns.Add("deleted");
                ViewState["dtdatas1"] = dtdatas1;
            }
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select Distinct Package from E_PIN_details where distributed_to='" + code + "' ", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "E_PIN_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {

            }
            else
            {
                for (int i = 0; i < rowcount; i++)
                {
                    string package = dt.Rows[i][0].ToString();

                    DataTable dtDatas1 = (DataTable)ViewState["dtdatas1"];
                    DataRow drNewRow1 = dtDatas1.NewRow();
                    drNewRow1["Package"] = package;
                    drNewRow1["Membercode"] = code;
                    drNewRow1["membername"] = name;
                    drNewRow1["Totalallocatedpin"] = find_total_allocated_pin_packagewise(code, package);
                    drNewRow1["use"] = find_use_pin_packagewise(code, package);
                    drNewRow1["rest"] = find_rest_pin_packagewise(code, package);
                    drNewRow1["deleted"] = find_deleted_pin_packagewise(code, package);
                    //add this new row to the Datatable and commit changes
                    dtDatas1.Rows.Add(drNewRow1);
                    dtDatas1.AcceptChanges();
                    ViewState["dtdatas1"] = dtDatas1;
                }
                grd_pin_details.DataSource = ViewState["dtdatas1"];
                grd_pin_details.DataBind();
                ViewState["dtdatas1"] = null;

            }
        }

        private object find_total_allocated_pin_packagewise(string code, string package)
        {
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from E_PIN_details where distributed_to='" + code + "'and Package='" + package + "' ", coon);
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

        private object find_use_pin_packagewise(string code, string package)
        {
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from E_PIN_details where distributed_to='" + code + "' and Package='" + package + "' and Status='" + status_d2 + "'", coon);
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

        private object find_deleted_pin_packagewise(string code, string package)
        {
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from E_PIN_details where distributed_to='" + code + "'and Package='" + package + "' and Status='" + status_d3 + "'", coon);
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

        private object find_rest_pin_packagewise(string code, string package)
        {
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from E_PIN_details where distributed_to='" + code + "'and Package='" + package + "' and Status='" + status_d1 + "'", coon);
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
        protected void btn_find_Click(object sender, EventArgs e)
        {

        }

        #region export_gridview_in_excel
        protected void img_exportgrd_Click(object sender, ImageClickEventArgs e)
        {

            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Distributedepinhistory.xls"));
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            grd_epin_used.AllowPaging = false;
            featch_distrubut_pin();
            grd_epin_used.HeaderRow.Style.Add("background-color", "#FFFFFF");
            for (int a = 0; a < grd_epin_used.HeaderRow.Cells.Count; a++)
            {
                grd_epin_used.HeaderRow.Cells[a].Style.Add("background-color", "#507CD1");
            }
            int j = 1;
            foreach (GridViewRow gvrow in grd_epin_used.Rows)
            {
                grd_epin_used.BackColor = Color.White;
                if (j <= grd_epin_used.Rows.Count)
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
            grd_epin_used.RenderControl(htw);
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
