using Master_MLM.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;

namespace Master_MLM.AppCode
{
    public class Message_sending
    {

        public static void SendMsg(string membercode, string mobileno, string message)
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from message_config", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "message_config");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount > 0)
            {
                string uid = dt.Rows[0][1].ToString();
                string sender = dt.Rows[0][2].ToString();
                string route = dt.Rows[0][3].ToString();
                string domain = dt.Rows[0][4].ToString();
                string mobile = mobileno;

                string url = domain + "/rest/services/sendSMS/sendGroupSms?AUTH_KEY=" + uid + "&message=" + message + "&senderId=" + sender + "&routeId=" + route + "&mobileNos=" + mobile + "&smsContentType=Unicode";
                send_message_details_in_Message_send_details(mobileno, message, "NOTSEND", membercode, url);


            }
        }
        private static void send_message_details_in_Message_send_details(string mobileno, string message, string results, string membercode, string url)
        {

            DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dtm.ToString("dd/MM/yyyy");
            string time = dtm.ToString("hh:mm:ss tt");

            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn6 = new SqlConnection(connectionstring);
            SqlDataAdapter ad6 = new SqlDataAdapter("Select * from Message_send_details", conn6);
            DataSet ds6 = new DataSet();
            ad6.Fill(ds6, "Message_send_details");
            DataTable dt6 = ds6.Tables[0];
            DataRow dr6 = dt6.NewRow();
            dr6[1] = membercode;
            dr6[2] = mobileno;
            dr6[3] = date;
            dr6[4] = message;
            dr6[5] = results;
            dr6[6] = time;
            dr6[7] = url.ToString();
            dr6[8] = "";
            dt6.Rows.Add(dr6);
            SqlCommandBuilder cb = new SqlCommandBuilder(ad6);
            ad6.Update(dt6);
        }

        #region send_message

        public static void send_message()
        {

            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn6 = new SqlConnection(connectionstring);
            SqlDataAdapter ad6 = new SqlDataAdapter("Select * from Message_send_details where Status='NOTSEND'", conn6);
            DataSet ds6 = new DataSet();
            ad6.Fill(ds6, "Message_send_details");
            DataTable dt6 = ds6.Tables[0];
            int rowcount = dt6.Rows.Count;
            if (rowcount == 0)
            {
            }
            else
            {
                for (int i = 0; i < rowcount; i++)
                {

                    string msgurl = dt6.Rows[i][7].ToString();
                    string ID = dt6.Rows[i][0].ToString();

                    string query = "update Message_send_details set Status='SENDING' where ID='" + ID + "'";
                    update_messagesend(query);
                    HttpWebRequest httpreq = (HttpWebRequest)WebRequest.Create(msgurl);
                    try
                    {
                        HttpWebResponse httpres = (HttpWebResponse)httpreq.GetResponse();
                        StreamReader sr = new StreamReader(httpres.GetResponseStream());
                        sr.Close();
                        query = "update Message_send_details set Status='SEND',resulturl='" + sr.ToString() + "' where ID='" + ID + "'";
                        update_messagesend(query);
                        update_message_allocation_details();

                    }
                    catch (Exception ex)
                    {
                        query = "update Message_send_details set Status='NOTSEND' where ID='" + ID + "'";
                        update_messagesend(query);
                    }

                }
            }

        }

        private static void update_message_allocation_details()
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn6 = new SqlConnection(connectionstring);
            SqlDataAdapter ad6 = new SqlDataAdapter("Select * from Message_allocation_details", conn6);
            DataSet ds6 = new DataSet();
            ad6.Fill(ds6, "Message_allocation_details");
            DataTable dt6 = ds6.Tables[0];
            int rowcount = dt6.Rows.Count;
            if (rowcount == 0)
            {
            }
            else
            {
                int messagereminder = Convert.ToInt32(dt6.Rows[0][1].ToString());
                int used = Convert.ToInt32(dt6.Rows[0][2].ToString());
                foreach (DataRow dr in dt6.Rows)
                {
                    dr[1] = messagereminder - 1;
                    dr[2] = used + 1;
                    SqlCommandBuilder cb = new SqlCommandBuilder(ad6);
                    ad6.Update(dt6);
                }
            }
        }


        private static void update_messagesend(string query)
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn6 = new SqlConnection(connectionstring);
            SqlDataAdapter ad6 = new SqlDataAdapter(query, conn6);
            DataSet ds6 = new DataSet();
            ad6.Fill(ds6, "Message_send_details");

        }
        #endregion send_message


        public static void SendMsg1(string membercode, string mobileno, string message)
        {
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from message_config", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "message_config");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (rowcount > 0)
            {
                string uid = dt.Rows[0][1].ToString();
                string sender = dt.Rows[0][2].ToString();
                string route = dt.Rows[0][3].ToString();
                string domain = dt.Rows[0][4].ToString();
                string mobile = mobileno;
                string url = domain + "/rest/services/sendSMS/sendGroupSms?AUTH_KEY=" + uid + "&message=" + message + "&senderId=" + sender + "&routeId=" + route + "&mobileNos=" + mobile + "&smsContentType=Unicode";
                send_message_details_in_Message_send_details(mobileno, message, "NOTSEND", membercode, url);
                send_sms_final(url, membercode);
            }
        }

        private static void send_sms_final(string url, string membercode)
        {
            HttpWebRequest httpreq = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                HttpWebResponse httpres = (HttpWebResponse)httpreq.GetResponse();
                StreamReader sr = new StreamReader(httpres.GetResponseStream());
                string result = sr.ReadToEnd();
                sr.Close();
                string query = "update Message_send_details set Status='SEND',resulturl='" + result + "' where Membercode='" + membercode + "'";
                update_messagesend(query);
            }
            catch (Exception ex)
            {

            }
        }

    }
}