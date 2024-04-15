using Master_MLM.App_Code;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Master_MLM.Admin
{
    public partial class sms_quantity : System.Web.UI.Page
    {
        Important imp = new Important();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fatch_avl_sms();
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            fatch_avl_sms();
        }

        private void fatch_avl_sms()
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn6 = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from message_config", conn6);
            DataSet ds = new DataSet();
            ad.Fill(ds, "message_config");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount == 0)
            {
                lbl_msg.Text = "0";
                lbl_avl.Text = "Your total SMS balance is : 0";
            }
            else
            {
                grdSMS.DataSource = dt;
                grdSMS.DataBind();


                string uid = dt.Rows[0]["uid"].ToString();
                string client_id = get_client_id(uid);

                String user_balance_url = "http://mysms.msgclub.net/rest/services/sendSMS/getClientRouteBalance?AUTH_KEY=" + uid + "&clientId=" + client_id;
                HttpWebRequest httpreq = (HttpWebRequest)WebRequest.Create(user_balance_url);
                HttpWebResponse httpres = (HttpWebResponse)httpreq.GetResponse();
                StreamReader sr = new StreamReader(httpres.GetResponseStream());
                string json = sr.ReadToEnd();
                JArray jar = (JArray)JsonConvert.DeserializeObject(json);
                JObject jo = (JObject)jar[0];
                String balance = jo["routeBalance"].ToString();
                lbl_avl.Text = "Your total SMS balance is : " + balance;
                lbl_msg.Text = balance;
                sr.Close();
            }
        }

        private string get_client_id(string uid)
        {
            string url = "http://mysms.msgclub.net/rest/services/transaction/transactionLog?AUTH_KEY=" + uid;
            HttpWebRequest httpreq = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpres = (HttpWebResponse)httpreq.GetResponse();
            StreamReader sr = new StreamReader(httpres.GetResponseStream());
            string json = sr.ReadToEnd();
            sr.Close();

            JArray jar = (JArray)JsonConvert.DeserializeObject(json);
            JObject jo = (JObject)jar[0];
            return jo["userIdT0"].ToString();

        }

        protected void grd_epin_distribute_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SMS") 
            {
                string Status=e.CommandArgument.ToString();
                if (Status == "STOP") { Status = "SEND"; } else { Status = "STOP"; }

                string sql = "update message_config set Status='" + Status + "'";
                int i1 = imp.InsertUpdateDelete(sql);

                fatch_avl_sms();
            }
        }

        protected void grd_epin_distribute_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow) 
            {
                Label lbl_Status = (Label)e.Row.FindControl("lbl_Status");
                Button btn = (Button)e.Row.FindControl("btnUpdate");

                if (lbl_Status.Text.Trim() == "STOP") { btn.Text = "SEND"; btn.CssClass = "btn btn-primary"; }
                else { btn.Text = "STOP"; btn.CssClass = "btn btn-danger"; }
            }
        }
    }
}
