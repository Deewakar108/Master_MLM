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
    public partial class View_request_pin_purchase : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["admin_usermlm"] == null)
            //{
            //    Session.Abandon();
            //    Session.Clear();
            //    Response.Write("<script language=javascript>var wnd=window.open('','newWin','height=1,width=1,left=900,top=700,status=no,toolbar=no,menubar=no,scrollbars=no,maximize=false,resizable=1');</script>");
            //    Response.Write("<script language=javascript>wnd.close();</script>");
            //    Response.Write("<script language=javascript>window.open('../Default.aspx','_parent',replace=true);</script>");
            //}
            //else
            //{
            if (!IsPostBack)
            {

                fill_gridview();
                DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                string date = dtm.ToString("dd/MM/yyyy");
                Session["today"] = date;
            }
            //}
        }

        private void fill_gridview()
        {
            string status = "Request";
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Request_for_pin_details where Status='" + status + "' order by ID ASC", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Request_for_pin_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                pnl_reward.Visible = false;
                lbl_message.Text = "Sorry! no data found.";
                grd_view.DataSource = null;
                grd_view.DataBind();
            }
            else
            {
                lbl_message.Text = "";
                pnl_reward.Visible = true;
                grd_view.DataSource = ds;
                grd_view.DataBind();
            }
        }
        #region page event
        protected void lnk_checkall_Click(object sender, EventArgs e)
        {
            int rowcount = grd_view.Rows.Count;
            for (int i = 0; i < rowcount; i++)
            {
                CheckBox chk = (CheckBox)grd_view.Rows[i].FindControl("CheckBox1");
                chk.Checked = true;
            }
        }
        protected void lnk_clearall_Click(object sender, EventArgs e)
        {
            int rowcount = grd_view.Rows.Count;
            for (int i = 0; i < rowcount; i++)
            {
                CheckBox chk = (CheckBox)grd_view.Rows[i].FindControl("CheckBox1");
                chk.Checked = false;
            }
        }
        #endregion page event

        #region allocate pin
        protected void btn_allocate_Click(object sender, EventArgs e)
        {
            int j = 0;
            int rowcount = grd_view.Rows.Count;
            for (int i = 0; i < rowcount; i++)
            {
                CheckBox chk = (CheckBox)grd_view.Rows[i].FindControl("CheckBox1");
                if (chk.Checked == true)
                {
                    Label lbl_id = (Label)grd_view.Rows[i].FindControl("lbl_id");
                    Label lbl_membercode = (Label)grd_view.Rows[i].FindControl("lbl_membercode");
                    Label lbl_pin_qty = (Label)grd_view.Rows[i].FindControl("lbl_pin_qty");
                    Label lbl_Package = (Label)grd_view.Rows[i].FindControl("lbl_Package");
                    Label lbl_Packageid = (Label)grd_view.Rows[i].FindControl("lbl_Packageid");
                    string id = lbl_id.Text;
                    string membercode = lbl_membercode.Text;
                    string Package = lbl_Package.Text;

                    int pinqty = Convert.ToInt32(lbl_pin_qty.Text);
                    int generatedpin = find_total_generatedpin(Package);


                    if (generatedpin >= pinqty)
                    {
                        allocated_epin(membercode, pinqty, Package, lbl_Packageid.Text);
                    }
                    else
                    {
                        Generate_epin(pinqty, Package);
                        allocated_epin(membercode, pinqty, Package, lbl_Packageid.Text);
                    }
                    update_status_of_requested_pin(id);
                }
                else
                {
                    j++;
                }
            }
            if (j == rowcount)
            {
                lbl_msg.Text = "Please check and then click allocate button.";
            }
            fill_gridview();
        }

        private int find_total_generatedpin(string Package)
        {

            string status = "GENERATED";
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from E_PIN_details where Status='" + status + "' and Package='" + Package + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "E_PIN_details");
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.NewRow();
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
        private void allocated_epin(string membercode, int pinqty, string Package, string Packageid)
        {
            string status = "GENERATED";
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from E_PIN_details where Status='" + status + "' and Package='" + Package + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "E_PIN_details");
            DataTable dt = ds.Tables[0];

            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
            }
            else
            {
                int i = 1;
                foreach (DataRow dr in dt.Rows)
                {
                    dr[2] = membercode;
                    dr[4] = Session["today"].ToString();
                    dr[6] = "GIVEN";
                    dr[10] = Packageid;
                    SqlCommandBuilder cb = new SqlCommandBuilder(ad);
                    ad.Update(dt);

                    if (i == pinqty)
                    {
                        break;
                    }
                    i++;
                }
            }
        }
        private void Generate_epin(int pinqty, string Package)
        {
            int[] generatedNum = new int[pinqty];
            bool duplicated;
            int tempo;
            Random random = new Random();
            // Create first number
            generatedNum[0] = random.Next(100000, 999999);

            for (int i = 1; i < pinqty; )
            {
                tempo = random.Next(100000, 999999);
                bool db_duplicate = check_dauplicate_pin(tempo);
                if (db_duplicate == true)
                {
                    generatedNum[i] = tempo;
                    i++;
                }
            }
            ArrayList ar = new ArrayList();
            foreach (int j in generatedNum)
            {
                string pin = "EP" + j.ToString();
                ar.Add(pin);
            }
            send_data_in_epin_table(ar, Package);
        }

        private bool check_dauplicate_pin(int tempo)
        {
            string tempo1 = "EP" + tempo.ToString();
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from E_PIN_details where Epin='" + tempo1 + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "E_PIN_details");
            DataTable dt = ds.Tables[0];

            if (dt.Rows.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void send_data_in_epin_table(ArrayList ar, string Package)
        {
            int rowcount = ar.Count;
            for (int i = 0; i < rowcount; i++)
            {
                string e_pin = ar[i].ToString();
                Connection con = new Connection();
                string connstr = con.connect_method();
                SqlConnection coon = new SqlConnection(connstr);
                SqlDataAdapter ad = new SqlDataAdapter("Select * from E_PIN_details", coon);
                DataSet ds = new DataSet();
                ad.Fill(ds, "E_PIN_details");
                DataTable dt = ds.Tables[0];
                DataRow dr = dt.NewRow();
                dr[0] = e_pin;
                dr[1] = Session["today"].ToString();
                dr[6] = "GENERATED";
                dr[9] = Package;
                dt.Rows.Add(dr);
                SqlCommandBuilder cb = new SqlCommandBuilder(ad);
                ad.Update(dt);
            }
        }

        private void update_status_of_requested_pin(string id)
        {
            string status = "Request";
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Request_for_pin_details where ID='" + id + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Request_for_pin_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {

            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dr[8] = Session["today"].ToString();
                    dr[9] = "ALLOCATED";
                    SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
                    ad.Update(dt);
                    lbl_msg.Text = "Request has been allocated.";
                }
            }

        }
        #endregion allocate pin

        protected void img_expord_Click(object sender, ImageClickEventArgs e)
        {
            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dtm.ToString("dd/MM/yyyy");
            Session["today"] = date;
            string excelname = Session["today"].ToString() + "Requestpinpurchase.xls";
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

