using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Master_MLM.App_Code;
using System.Data;

namespace Master_MLM.Admin
{
    public partial class Package_list : System.Web.UI.Page
    {
        string scrpt;
        string query = "";
        My mycode = new My();
        Important imp = new Important();

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

            if (!IsPostBack)
            {
                try
                {
                    fetch_add_package();
                }
                catch
                {
                }
            }
        }

        private void fetch_add_package()
        {
            query = "Select * from Joining_package   ";
            mycode.bind_gridview(gridview, query);
            if (gridview.Rows.Count == 0)
            {

            }
            else
            {

            }
        }

        protected void img_delete_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton img = (ImageButton)sender;
                GridViewRow row = (GridViewRow)img.Parent.Parent;
                int idx = row.RowIndex;
                Label lbl_id = (Label)gridview.Rows[idx].FindControl("lbl_id");

                deletedata(lbl_id.Text);
                fetch_add_package();
                lbl_message.Text = "Package has been delete successfully.";

                scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
            }
            catch
            {

            }
        }

        private void deletedata(string id)
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("delete from Joining_package where id='" + id + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Product_Info");
        }

        #region gride view edit 
        protected void gridview_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridview.EditIndex = -1;
            fetch_add_package();
            gridview.DataBind();
        }

        protected void gridview_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridview.EditIndex = e.NewEditIndex;
            fetch_add_package();
            gridview.DataBind();
        }

        protected void gridview_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = (GridViewRow)gridview.Rows[e.RowIndex];
            Label lbl_id = (Label)row.FindControl("lbl_id");
            TextBox txt_amount = (TextBox)row.FindControl("txt_amount");
            TextBox txt_PV = (TextBox)row.FindControl("txt_PV");
            TextBox txt_Capping = (TextBox)row.FindControl("txt_Capping");

            bool chkaamt = mycode.valid_amount(txt_amount.Text);
            bool chkpv = mycode.valid_amount(txt_PV.Text);
            bool Capping = mycode.valid_amount(txt_Capping.Text);

            if (chkaamt == false)
            {
                lbl_message.Text = "Please Enter Valid Purchase Package";
                scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
            }
            else if (chkpv == false)
            {
                lbl_message.Text = "Please Enter Valid PV";
                scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
            }
            else if (Capping == false)
            {
                lbl_message.Text = "Please Enter Valid Capping";
                scrpt = "<script>$( function () { $('.notificationpan').hide().slideDown(1000);  $('.notificationpan').delay(10000).show().slideUp(1000);});</script>";
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "tmp", scrpt, false);
            }
            else
            {
                update_data(txt_amount.Text, txt_PV.Text, lbl_id.Text, txt_Capping.Text);
                gridview.EditIndex = -1;
                fetch_add_package();
            }

        }

        private void update_data(string amt, string pv, string id, string Capping)
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Joining_package where ID='" + id + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Joining_package");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {

            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    dr["Package_amount"] = amt;
                    dr["BV"] = pv;
                    dr["Capping"] = Capping;
                    SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
                    ad.Update(dt);
                }
            }
        }
        #endregion

        protected void gridview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "IsDelete")
            {
                string PackageID = e.CommandArgument.ToString();
                string sql = "delete from  Package_details where Packageid='" + PackageID + "'";
                int i1 = imp.InsertUpdateDelete(sql);
                sql = "delete from  Joining_package where Package_id='" + PackageID + "'";
                int i2 = imp.InsertUpdateDelete(sql);
                //if (i1 == 0 || i2 == 0) { AlertMe("Try again."); return; }
                AlertMe("Package is successfully deleted.");
                fetch_add_package();
            }
        }

        public void AlertMe(string Message)
        {
            lblMessage.Text = Message;
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "AlertMe();", true);
        }

    }
}