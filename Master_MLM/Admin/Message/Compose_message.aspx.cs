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
using Master_MLM.App_Code;

namespace Master_MLM.Admin
{
    public partial class Compose_message : System.Web.UI.Page
    {
        #region page load
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
                    find_member_id();
                    DateTime dt = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                    string date = dt.ToString("dd/MM/yyyy");
                    string day = date.Substring(0, 2);
                    string month = date.Substring(3, 2);
                    string year = date.Substring(6, 4);
                    Session["today"] = date;
                }
            }
        }

        private void find_member_id()
        {
            string membercode = imp.AdminCode;
            ArrayList ar = new ArrayList();
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select Member_code,Your_Name from Member_registration where Member_code !='" + membercode + "'", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;

            if (rowcount == 0)
            {
                lbl_message.Text = "No any member exist...!";
            }
            else
            {
                lbl_message.Text = "";
                ar.Add("Select");

                foreach (DataRow dr in dt.Rows)
                {
                    string member = dr[0].ToString() + "," + dr[1].ToString();
                    ar.Add(member);
                }
                ddl_to.DataSource = ar;
                ddl_to.DataBind();
            }
        }
        #endregion page load
        #region send
        protected void btn_send_Click(object sender, EventArgs e)
        {
            if (ddl_to.Text == "Select")
            {
                lbl_message.Text = "Please select receiver id";
            }
            else
            {
                lbl_message.Text = "";
                Send_message();
            }
        }
        private void Send_message()
        {
            string membercode = ddl_to.Text;
            string sub_code = "";
            string sub_name = "";
            int pos = membercode.LastIndexOf(Convert.ToChar(@","));
            if ((pos >= 0))
            {
                sub_code = membercode.Substring(0, (pos));
                sub_name = membercode.Substring((pos + 1));
            }
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from message_corner ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "message_corner");
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.NewRow();
            dr[0] = "Admin";
            dr[1] = "";
            dr[2] = sub_code;
            dr[3] = sub_name;
            dr[4] = txt_subject.Text;
            dr[5] = txt_message.Text;
            dr[6] = Session["today"];
            dt.Rows.Add(dr);
            SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
            ad.Update(dt);
            lbl_message.Text = "Your message has been sent.";
            txt_message.Text = "";
            txt_subject.Text = "";
        }
        #endregion send
    }
}
