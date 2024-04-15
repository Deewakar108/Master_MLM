using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace Master_MLM.App_Code
{
    public class sms_sender
    {

        public static void send_message(string mobile, string message, string membercode)
        {
            Important imp1 = new Important();
            string sql = "select * from Message_config";
            DataTable dt = imp1.FillTable(sql);
            if (dt.Rows.Count != 0)
            {
                if (dt.Rows[0]["Status"].ToString() == "STOP") { return; }

                string str1 = dt.Rows[0]["uid"].ToString();       // imp1.Key;                              //Key
                string str2 = dt.Rows[0]["sender"].ToString();       // imp1.SenderID;                         //Sender ID
                string str3 = "1";
                string text = mobile;
                string str4 = message;
                string url = "http://" + "mysms.msgclub.net" + "/rest/services/sendSMS/sendGroupSms?AUTH_KEY=" + str1 + "&message=" + str4 + "&senderId=" + str2 +
                    "&routeId=" + str3 + "&mobileNos=" + text + "&smsContentType=English";
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                try
                {
                    HttpWebResponse httpres = (HttpWebResponse)httpWebRequest.GetResponse();
                    StreamReader sr = new StreamReader(httpres.GetResponseStream());
                    string result = sr.ReadToEnd();
                    sr.Close();
                    send_message_details_in_Message_send_details(mobile, message, membercode, result, url);
                }
                catch (Exception ex)
                {
                }

            }
            else { return; }

            //if (!imp1.IsSend) { return; }

            
        }

        private static void send_message_details_in_Message_send_details(string mobile, string message, string membercode, string result, string url)
        {
            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string time = dtm.ToString("hh:mm:ss tt");

            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn6 = new SqlConnection(connectionstring);
            SqlDataAdapter ad6 = new SqlDataAdapter("Select * from Message_send_details", conn6);
            DataSet ds6 = new DataSet();
            ad6.Fill(ds6, "Message_send_details");
            DataTable dt6 = ds6.Tables[0];
            DataRow dr6 = dt6.NewRow();
            //dr6[0] = membercode;
            //dr6[1] = mobile;
            //dr6[2] = dtm.ToString("dd/MM/yyyy");
            //dr6[3] = message;
            //dr6[4] = result;
            //dr6[5] = time;
            dr6[1] = membercode;
            dr6[2] = mobile;
            dr6[3] = dtm.ToString("dd/MM/yyyy");
            dr6[4] = message;
            dr6[7] = url;
            dr6[8] = result;
            dr6[6] = time;
            dt6.Rows.Add(dr6);
            SqlCommandBuilder cb = new SqlCommandBuilder(ad6);
            ad6.Update(dt6);
        }

    }
}