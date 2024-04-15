using Master_MLM.App_Code;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Master_MLM.Admin.Members
{
    public partial class Membertopup_report : System.Web.UI.Page
    {
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
            else
            {

                if (!IsPostBack)
                {
                    finddata();


                }
            }
        }

       

        
        protected void btn_find_Click(object sender, EventArgs e)
        {
            try
            {
                finddata();
            }
            catch (Exception ex)
            {
                My.submitException(ex);
            }
        }
        private void finddata()
        {
            //string MemberCode = Session["MemberCode"].ToString();

            string sql = "select  * from (select  t.*, m.Mobile_number, m.Member_code, m.Member_name, m.Sponcer_code, e.Package, (Convert(int, (Convert(varchar, Convert(datetime, t.ActivationDate, 103), 112)))) as Topup_Activation_iDate from TopUpMemberList t join Member_registration m on m.Member_code= t.MemberCode join E_PIN_details e on e.Epin=t.NewEPin) T ";

            bind_grid_view(sql);
        }

        private void bind_grid_view(string queiry)
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad_contactus = new SqlDataAdapter(queiry, conn);
            DataSet ds = new DataSet();
            ad_contactus.Fill(ds, "Member_registration");
            int rowcount = ds.Tables[0].Rows.Count;
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.NewRow();
            if (rowcount == 0)
            {

                pnl_view.Visible = false;
                lbl_message.Text = "Sorry Data Not Found";
                grd_view.DataSource = null;
                grd_view.DataBind();

            }
            else
            {
                pnl_view.Visible = true;
                lbl_message.Text = "";
                grd_view.DataSource = ds;
                grd_view.DataBind();


            }
        } 
      
    }
}