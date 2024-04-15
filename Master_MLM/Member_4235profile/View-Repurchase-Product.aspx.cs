using Master_MLM.App_Code;
using Master_MLM.AppCode;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Master_MLM.Member_4235profile
{
    public partial class View_Repurchase_Product : System.Web.UI.Page
    {
        string query;
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
                Page.Server.ScriptTimeout = 36000;
                if (!IsPostBack)
                {
                    fetch_year();
                    //// Create a new table. for sorting
                    DataTable taskTable = new DataTable("TaskList");
                }
            }

        }
        My mycode = new My();
        private void fetch_year()
        {
            Dictionary<string, object> dc1 = mycode.startyear_endyear();
            string Startyear = (String)dc1["Startyear"];
            string End_year = (String)dc1["End_year"];
            ArrayList ar = new ArrayList();
            ar.Add("Select");
            for (int i = Convert.ToInt32(Startyear); i <= Convert.ToInt32(End_year); i++)
            {

                ar.Add(i);
            }
            ddl_s_year.DataSource = ar;
            ddl_s_year.DataBind();

            ddl_e_year.DataSource = ar;
            ddl_e_year.DataBind();


            DateTime dt = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            string date = dt.ToString("dd/MM/yyyy");
            string day = date.Substring(0, 2);
            string month = date.Substring(3, 2);
            string year = date.Substring(6, 4);
            ddl_s_date.Text = day;
            ddl_s_month.Text = month;
            ddl_s_year.Text = year;
            ddl_e_date.Text = day;
            ddl_e_month.Text = month;
            ddl_e_year.Text = year;
        }


        ClassException ce = new ClassException();
        protected void btn_find_Click(object sender, EventArgs e)
        {
            try
            {
                BindGridview();
                ViewState["flag"] = "1";
            }
            catch (Exception ex)
            {
                ce.submit_exception(ex.ToString());

            }
        }

        private void BindGridview()
        {
            string Sdate = ddl_s_year.Text + ddl_s_month.Text + ddl_s_date.Text;
            string Edate = ddl_e_year.Text + ddl_e_month.Text + ddl_e_date.Text;

            int startdate = Convert.ToInt32(Sdate);
            int enddate = Convert.ToInt32(Edate);

            if (enddate >= startdate)
            {
                query = "Select * from Re_sell_member_bill_wise where Membercode='" + Session["membercode"].ToString() + "' and Idate>=" + startdate + " and Idate<=" + enddate + "";

                Connection con = new Connection();
                string connstr = con.connect_method();
                SqlConnection coon = new SqlConnection(connstr);
                SqlDataAdapter ad = new SqlDataAdapter(query, coon);
                DataSet ds = new DataSet();
                ad.Fill(ds, "Re_sell_member_bill_wise");
                DataTable dt = ds.Tables[0];
                int rowcount = dt.Rows.Count;
                if (rowcount == 0)
                {
                    lbl_message.Text = "Sorry! no data found.";
                    panel_view.Visible = false;
                    gridview.DataSource = null;
                    gridview.DataBind();
                    gridview.Visible = true;
                }
                else
                {
                    lbl_message.Text = "";
                    panel_view.Visible = true;
                    gridview.DataSource = ds;
                    gridview.DataBind();
                    gridview.Visible = true;
                }
            }
            else
            {
                lbl_message.Text = "To date can't be less than from date.";

            }
        }
    }
}