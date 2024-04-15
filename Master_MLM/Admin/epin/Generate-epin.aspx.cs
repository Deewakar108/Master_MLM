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
    public partial class Generate_epin : System.Web.UI.Page
    {
        int min = 10000000;
        int max = 99999999;
        int k = 0;

        string scrpt;
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                DateTime dtm = DateTime.UtcNow.AddHours(5).AddMinutes(30);
                string date = dtm.ToString("dd/MM/yyyy");
                Session["today"] = date;

                DataTable dtdatas = new DataTable();
                dtdatas.Columns.Add("Epin");
                ViewState["dtdatas"] = dtdatas;

                find_total_pin();

                find_package();
                Session["CheckReferesh"] = Server.UrlDecode(System.DateTime.Now.ToString());
            }
        }

        protected void Page_Prerender(object sender, EventArgs e)
        {
            if (Session["CheckReferesh"] != null)
            {
                ViewState["CheckReferesh"] = Session["CheckReferesh"].ToString();
            }
        }

        private void find_total_pin()
        {
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from E_PIN_details", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "E_PIN_details");
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.NewRow();
            int rowcount = dt.Rows.Count;
            lbl_total_pin.Text = "Total Generated Pin : " + rowcount.ToString();
        }
        My mycode = new My();
        private void find_package()
        {
            mycode.bind_all_ddl_with_id(ddl_package, "Select Package_name,Package_id from Joining_package ORDER BY Package_name", "Package_name", "Package_id"); 
        }
        protected void btn_generate_pin_Click(object sender, EventArgs e)
        {
            btn_submit.Visible = true;
            ddl_package.Visible = true;
            lbl_package.Visible = true;
            unique_num();//create random unique number.
            ViewState["CheckReferesh"] = Session["CheckReferesh"].ToString();
        }

        private void unique_num()
        {
            if (ViewState["dtdatas"] == null)
            {
                DataTable dtdatas = new DataTable();
                dtdatas.Columns.Add("Epin");
                ViewState["dtdatas"] = dtdatas;

            }
            int[] generatedNum = new int[10];
            bool duplicated;
            int tempo;
            Random random = new Random();
            // Create first number
            generatedNum[0] = random.Next(100000, 999999);

            for (int i = 1; i < 10; )
            {
                tempo = random.Next(100000, 999999);
                bool db_duplicate = check_dauplicate_pin(tempo);
                if (db_duplicate == true)
                {
                    generatedNum[i] = tempo;
                    i++;
                }
            }
            ArrayList ar = new ArrayList();
            foreach (int j in generatedNum)
            {
                DataTable dtDatas = (DataTable)ViewState["dtdatas"];
                DataRow drNewRow = dtDatas.NewRow();
                drNewRow["Epin"] = "EP" + j.ToString();
                //add this new row to the Datatable and commit changes
                dtDatas.Rows.Add(drNewRow);
                dtDatas.AcceptChanges();
                ViewState["dtdatas"] = dtDatas;
            }
            grd_epin.DataSource = ViewState["dtdatas"];
            grd_epin.DataBind();
            ViewState["dtdatas"] = null;
            generatedNum = null;
        }

        private bool check_dauplicate_pin(int tempo)
        {
            string tempo1 = "EP" + tempo.ToString();
            Connection con = new Connection();
            string connstr = con.connect_method();
            SqlConnection coon = new SqlConnection(connstr);
            SqlDataAdapter ad = new SqlDataAdapter("Select * from E_PIN_details where Epin='" + tempo1 + "'", coon);
            DataSet ds = new DataSet();
            ad.Fill(ds, "E_PIN_details");
            DataTable dt = ds.Tables[0];

            if (dt.Rows.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        protected void btn_submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddl_package.SelectedItem.Text == "")
                {
                    lbl_dis.Text = "Please create package.";
                }
                else if (ddl_package.SelectedItem.Text == "Select")
                {
                    lbl_dis.Text = "Please select package.";

                }
                else
                {
                    send_data_in_epin_table();
                    btn_submit.Visible = false;
                    ddl_package.Visible = false;
                    lbl_package.Visible = false;
                    grd_epin.DataSource = null;
                    grd_epin.DataBind();
                    find_total_pin();
                }
            }
            catch
            {
            }
        }


        private void send_data_in_epin_table()
        {
            int grdrowcount = grd_epin.Rows.Count;
            for (int i = 0; i < grdrowcount; i++)
            {
                Label lblpin = (Label)grd_epin.Rows[i].FindControl("lbl_epin");

                Connection con = new Connection();
                string connstr = con.connect_method();
                SqlConnection coon = new SqlConnection(connstr);
                SqlDataAdapter ad = new SqlDataAdapter("Select * from E_PIN_details where Epin='" + lblpin.Text + "'", coon);
                DataSet ds = new DataSet();
                ad.Fill(ds, "E_PIN_details");
                DataTable dt = ds.Tables[0];
                int rowcount = dt.Rows.Count;
                if (rowcount == 0)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = lblpin.Text;
                    dr[1] = Session["today"].ToString();
                    dr[6] = "GENERATED";
                    dr[9] = ddl_package.SelectedItem.Text;
                    dr[10]=ddl_package.SelectedValue;
                    dt.Rows.Add(dr);
                    SqlCommandBuilder cb = new SqlCommandBuilder(ad);
                    ad.Update(dt);
                    lbl_dis.Text = "E-Pin is successfully generated.";
                }
            }

        }

    }
}
