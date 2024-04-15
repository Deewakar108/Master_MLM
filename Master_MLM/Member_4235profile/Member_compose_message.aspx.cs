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

namespace Master_MLM.Member_4235profile
{
    public partial class Member_compose_message : System.Web.UI.Page
    {
        Important imp = new Important();
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
                if (!IsPostBack)
                {

                    DateTime dt = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                    string date = dt.ToString("dd/MM/yyyy");
                    string day = date.Substring(0, 2);
                    string month = date.Substring(3, 2);
                    string year = date.Substring(6, 4);
                    Session["today"] = date;
                }
            }
        }
        #region Send Message
        protected void btn_send_Click(object sender, EventArgs e)
        {
            if (ddl_to.Text == "Select")
            {
                //lbl_message.Text = "Please select receiver id";
                Alert("Please select receiver id.");
                return;
            }
            else if (txt_subject.Text == "") { Alert("Invalid Subject."); return; }
            else if (txt_message.Text == "") { Alert("Invalid message."); return; }
            else
            {
                Send_message();
            }

        }

        private void Send_message()
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from message_corner ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "message_corner");
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.NewRow();
            dr[0] = Session["membercode"].ToString();
            dr[1] = Session["membername"].ToString();
            dr[2] = ddl_to.Text;
            dr[3] = ddl_to.Text;
            dr[4] = txt_subject.Text;
            dr[5] = txt_message.Text;
            dr[6] = DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("dd/MM/yyyy");
            dt.Rows.Add(dr);
            SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
            ad.Update(dt);
            //lbl_msg.Text = "Your message has been sent.";
            Alert("Your message has been sent.");
            txt_message.Text = "";
            txt_subject.Text = "";
            txt_subject.Focus();
        }
        #endregion Send Message
        
        public void Alert(string Message)
        {
            lbl_msg.Text = Message;
            imp.Alert();
        }

    }
}