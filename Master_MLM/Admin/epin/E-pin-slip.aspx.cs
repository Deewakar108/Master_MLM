using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using Master_MLM.App_Code;


namespace Master_MLM.Admin
{
    public partial class E_pin_slip : System.Web.UI.Page
    {
        Important imp = new Important();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    lblCompanyName.Text = imp.CompanyName;

                    string membercode = Request.QueryString["code"];
                    if (!string.IsNullOrEmpty(membercode))
                    {

                        string transid = Request.QueryString["transid"];
                        lbl_transactionid.Text = transid;

                        find_data(membercode, transid);
                        find_member_details(membercode);
                    }
                }
                catch
                {
                }
            }
        }
        private void find_data(string membercode, string transid)
        {

            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from Allocated_E_PIN_details where Member_code='" + membercode + "' and Transaction_id='" + transid + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Bank_payout_details");
            DataTable dt = ds.Tables[0];
            int rowcount = dt.Rows.Count;
            if (dt.Rows.Count > 0)
            {
                grdpins.DataSource = ds;
                grdpins.DataBind();

                lbl_pinno.Text = rowcount.ToString();
                lbl_date.Text = dt.Rows[0][5].ToString();
                find_package_amount(dt.Rows[0][3].ToString(), rowcount);
            }
            else
            {
            }
        }

        private void find_package_amount(string packageid, int rowcount)
        {
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select Package_name,Package_amount from Joining_package where Package_id='" + packageid + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Joining_package");
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                lbl_package.Text = dt.Rows[0][0].ToString();
                lbl_amt.Text = (Convert.ToDouble(dt.Rows[0][1].ToString()) * rowcount).ToString();
            }
        }
        private void find_member_details(string membercode)
        {
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select Member_name,District,Address,State from Member_registration where Member_code='" + membercode + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "Member_registration");
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                lbl_code.Text = membercode;
                lbl_name.Text = dt.Rows[0][0].ToString();
                lbl_dist.Text = dt.Rows[0][1].ToString();
                lbl_address.Text = dt.Rows[0][2].ToString();
                lbl_state.Text = dt.Rows[0][3].ToString();

            }
        }
        protected void btn_print_Click(object sender, EventArgs e)
        {
            Go_to_print();
        }
        private void Go_to_print()
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "printit", "printit()", true);
        }
        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Distribute-epin.aspx");
        }
    }
}
