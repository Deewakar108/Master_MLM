using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Master_MLM.App_Code;
using System.Collections;
using System.IO;
using System.Data;

namespace Master_MLM.Member_4235profile
{
    public partial class Update_Bank_Payment : System.Web.UI.Page
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
                    string mypage = Request.QueryString["mypage"];
                    if (!String.IsNullOrEmpty(mypage))
                    {
                        string page = mycode.Unzip(mypage);

                        if (page == mycode.Unzip(Session["verify"].ToString()))
                        {
                            if (!IsPostBack)
                            {

                                DateTime dt = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                                string date = dt.ToString("dd/MM/yyyy");

                                Session["today"] = date;

                                fetch_year();

                            }
                        }
                        else
                        {
                            Session.Abandon();
                            Session.Clear();
                            Response.Write("<script language=javascript>var wnd=window.open('','newWin','height=1,width=1,left=900,top=700,status=no,toolbar=no,menubar=no,scrollbars=no,maximize=false,resizable=1');</script>");
                            Response.Write("<script language=javascript>wnd.close();</script>");
                            Response.Write("<script language=javascript>window.open('../Default.aspx','_parent',replace=true);</script>");
                        }
                    }
                    else
                    {

                        Session.Abandon();
                        Session.Clear();
                        Response.Write("<script language=javascript>var wnd=window.open('','newWin','height=1,width=1,left=900,top=700,status=no,toolbar=no,menubar=no,scrollbars=no,maximize=false,resizable=1');</script>");
                        Response.Write("<script language=javascript>wnd.close();</script>");
                        Response.Write("<script language=javascript>window.open('../Default.aspx','_parent',replace=true);</script>");
                    }

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

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            if (ddl_day.Text == "Select" || ddl_month.Text == "Select" || ddl_year.Text == "Select")
            {
                lbl_msg.Text = "Plesae select date";
            }
            else
            {
                //if (FileUpload1.HasFile)
                //{
                bool isValidNumeric = ValidateNumber(txt_amount.Text);
                if (isValidNumeric == false)
                {
                    lbl_msg.Text = "Please enter valid amount";
                }
                else
                {
                    send_data();
                }

                //}
                //else
                //{
                //    lbl_msg.Text = "Please choose slip";  
                //}
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

        private void send_data()
        {
            string slip = upload_slip();
            if (slip == "Max Size")
            {
                lbl_msg.Text = "Please Upload image Max(200kb)";
            }
            else
            {

                string membercode = Session["membercode"].ToString();
                Connection con = new Connection();
                string connectionstring = con.connect_method();
                SqlConnection conn = new SqlConnection(connectionstring);
                SqlDataAdapter ad = new SqlDataAdapter("select * from Update_bank_payment ", conn);
                DataSet ds = new DataSet();
                ad.Fill(ds, "Update_bank_payment");
                DataTable dt = ds.Tables[0];
                DataRow dr = dt.NewRow();
                dr["Member_code"] = membercode;
                dr["Bankname"] = txt_bank_name.Text;
                dr["Transaction_id"] = txt_transitionno.Text;
                dr["Amount"] = txt_amount.Text;
                dr["Slippath"] = slip;
                dr["Date"] = ddl_day.Text + "/" + ddl_month.Text + "/" + ddl_year.Text;
                dr["Idate"] = ddl_year.Text + ddl_month.Text + ddl_day.Text;
                dr["Time"] = txt_time.Text;
                dr["IFSCCode"] = txt_ifsccode.Text;
                dt.Rows.Add(dr);
                SqlCommandBuilder cmd = new SqlCommandBuilder(ad);
                ad.Update(dt);
                lbl_msg.Text = "Bank payment has been update.";
                txt_bank_name.Text = "";
                txt_transitionno.Text = "";
                txt_amount.Text = "";
            }

        }

        private string upload_slip()
        {
            DateTime dt = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dt.ToString("dd_MM_yyyy");
            string time = dt.ToString("hh_mm_ss_tt");
            string name = time + date;

            string dbfilePath = "";
            Boolean FileOK = false;
            Boolean FileSaved = false;
            int k = 0;
            if (FileUpload1.HasFile)
            {
                if (FileUpload1.FileBytes.Length < 200000)
                {
                    Session["file1"] = FileUpload1.FileName;
                    String FileExtension = Path.GetExtension(Session["file1"].ToString()).ToLower();
                    Session["file2"] = (Guid.NewGuid() + FileExtension);
                    string[] allowedExtensions = { ".doc", ".docx", ".pdf", ".png", ".jpeg", ".jpg" };
                    for (int i = 0; i < allowedExtensions.Length; i++)
                    {
                        k++;
                        if (FileExtension == allowedExtensions[i])
                        {
                            FileOK = true;
                            break;
                        }
                    }
                }
                else
                {

                    dbfilePath = "Max Size";
                }
            }
            else
            {

            }
            if (FileOK)
            {
                try
                {
                    string path = (Server.MapPath("../Master_image/bank_slip")).ToString();
                    FileUpload1.SaveAs(path + "/" + Session["file2"]);
                    FileSaved = true;
                }
                catch (Exception ex)
                {

                    FileSaved = false;
                }
            }
            else
            {

            }
            if (FileSaved)
            {

                string fileName = Path.GetFileName(Session["file2"].ToString());
                dbfilePath = @"/Master_image/bank_slip/" + fileName;
            }
            return dbfilePath;

        }
    }
}