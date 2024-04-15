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
using System.Collections.Generic;

namespace Master_MLM.Member_4235profile
{
    public partial class Request_pin : System.Web.UI.Page
    {

        My mycode = new My();
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
                #region pagbindin
                try
                {
                    //string mypage = Request.QueryString["mypage"];
                    //if (!String.IsNullOrEmpty(mypage))
                    //{
                    //    string page = mycode.Unzip(mypage);

                    //    if (page == mycode.Unzip(Session["verify"].ToString()))
                    //    {
                            if (!IsPostBack)
                            {

                                DateTime dt = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                                string date = dt.ToString("dd/MM/yyyy");

                                Session["today"] = date;

                                fetch_year();
                                find_package();
                            }
                        //}
                        //else
                        //{
                        //    Session.Abandon();
                        //    Session.Clear();
                        //    Response.Write("<script language=javascript>var wnd=window.open('','newWin','height=1,width=1,left=900,top=700,status=no,toolbar=no,menubar=no,scrollbars=no,maximize=false,resizable=1');</script>");
                        //    Response.Write("<script language=javascript>wnd.close();</script>");
                        //    Response.Write("<script language=javascript>window.open('../Default.aspx','_parent',replace=true);</script>");
                        //}
                    //}
                    //else
                    //{

                    //    Session.Abandon();
                    //    Session.Clear();
                    //    Response.Write("<script language=javascript>var wnd=window.open('','newWin','height=1,width=1,left=900,top=700,status=no,toolbar=no,menubar=no,scrollbars=no,maximize=false,resizable=1');</script>");
                    //    Response.Write("<script language=javascript>wnd.close();</script>");
                    //    Response.Write("<script language=javascript>window.open('../Default.aspx','_parent',replace=true);</script>");
                    //}

                }
                catch
                {
                    Session.Abandon();
                    Session.Clear();
                    Response.Write("<script language=javascript>var wnd=window.open('','newWin','height=1,width=1,left=900,top=700,status=no,toolbar=no,menubar=no,scrollbars=no,maximize=false,resizable=1');</script>");
                    Response.Write("<script language=javascript>wnd.close();</script>");
                    Response.Write("<script language=javascript>window.open('../Default.aspx','_parent',replace=true);</script>");
                }
                #endregion


            }


        }
        My code = new My();
        private void fetch_year()
        {
            Dictionary<string, object> dc1 = code.startyear_endyear();
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
            ddl_day.Text = day;
            ddl_month.Text = month;
            ddl_year.Text = year;
        }

        private void find_package()
        {
            code.bind_all_ddl_with_id(ddl_package, "Select Package_name,Package_id from Joining_package ORDER BY Package_name", "Package_name", "Package_id");
        }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            if (ddl_package.SelectedItem.Text == "Select")
            {

                lbl_msg.Text = "Please Select Package";
            }
            else
            {
                bool isValidNumeric = ValidateNumber(txt_pinqty.Text);
                bool isValidNumeric1 = ValidateNumber(txt_amount.Text);
                if (isValidNumeric == false)
                {
                    lbl_msg.Text = "Only digit allowed";
                }
                else if (isValidNumeric1 == false)
                {
                    lbl_msg.Text = "Only digit allowed";
                }
                else
                {
                    lbl_msg.Text = "";
                    send_request_for_pin();
                }
            }
        }
        private bool ValidateNumber(string number)
        {
            try
            {
                double _num = Convert.ToDouble(number.Trim());
            }
            catch
            {
                return false;
            }
            return true;
        }

        private void send_request_for_pin()
        {
            string membercode = Session["membercode"].ToString();
            Connection con = new Connection();
            string connectionstring = con.connect_method();
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Request_for_pin_details ", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Request_for_pin_details");
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.NewRow();
            dr[0] = membercode;
            dr[1] = txt_pinqty.Text;
            dr[2] = Session["today"].ToString();
            dr[3] = "";
            dr[4] = txt_amount.Text;
            dr[5] = txt_bank_name.Text;
            dr[6] = txt_transitionno.Text;
            dr[7] = ddl_day.Text + "/" + ddl_month.Text + "/" + ddl_year.Text;
            dr[8] = "";
            dr[9] = "Request";
            dr[11] = ddl_package.SelectedItem.Text;
            dr[12] = ddl_package.SelectedValue;
            dt.Rows.Add(dr);
            SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
            ad.Update(dt);
            lbl_msg.Text = "Request has been sent.";
            txt_pinqty.Text = "";
            txt_transitionno.Text = "";
            txt_bank_name.Text = "";
            txt_amount.Text = "";
        }
    }
}