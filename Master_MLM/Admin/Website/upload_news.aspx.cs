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

namespace Master_MLM.Admin
{
    public partial class upload_news : System.Web.UI.Page
    {
        #region pageload
        My mycode = new My();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fetch_year();

            }
        }
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
        #endregion
        #region pagesubmit
        protected void btnupload_Click(object sender, EventArgs e)
        {
            upload_news_data();
        }

        private void upload_news_data()
        {
            if (ddl_day.Text == "Select" || ddl_month.Text == "Select" || ddl_year.Text == "Select")
            {
                lblmessage.Text = "Please Select Date";
            }
            else
            {
                // string upload_data = upload_file();
                lblmessage.Text = "";
                Connection con = new Connection();
                string connectionstring = con.connect_method();
                SqlConnection conn = new SqlConnection(connectionstring);
                DataSet ds = new DataSet();
                SqlDataAdapter ad = new SqlDataAdapter("Select * from NewsTable", conn);
                ad.Fill(ds, "NewsTable");
                DataTable dt = ds.Tables[0];
                DataRow dr = dt.NewRow();
                dr[0] = txt_heading.Text;
                dr[1] = txt_description.Text;
                dr[2] = ddl_day.Text + "/" + ddl_month.Text + "/" + ddl_year.Text;
                //dr[4] = upload_data;

                dt.Rows.Add(dr);
                SqlCommandBuilder cb = new SqlCommandBuilder(ad);
                ad.Update(dt);
                lblmessage.Text = "News is successfully uploaded.";
                txt_heading.Text = "";
                txt_description.Text = "";

            }
        }
        #endregion
        #region uploadfilesection
        //private string upload_file()
        //{
        //    Boolean Fileok = false;
        //    Boolean Filesaved = false;
        //    string dbfilepath = "";
        //    int k = 0;
        //    if (fileupload.HasFile)
        //    {
        //        Session["fileupload"] = fileupload.FileName;
        //        string FileExtension = Path.GetExtension(Session["fileupload"].ToString()).ToLower();
        //        string[] allowedExtensions = { ".doc", ".docx", ".pdf", ".txt", ".ppt", ".pptx", ".png", ".jpeg", ".jpg", ".gif", ".htm" };
        //        for (int i = 0; i < allowedExtensions.Length; i++)
        //        {
        //            k++;
        //            if (FileExtension == allowedExtensions[i])
        //            {
        //                Fileok = true;
        //                break;

        //            }

        //        }

        //    }
        //    else
        //    {

        //    }

        //    if (Fileok)
        //    {
        //        try
        //        {
        //            string path = (Server.MapPath("news_data")).ToString();
        //            fileupload.SaveAs(path + "/" + Session["fileupload"]);
        //            Filesaved = true;

        //        }
        //        catch (Exception ex)
        //        {
        //            Filesaved = false;


        //        }


        //    }


        //    else
        //    {



        //    }
        //    if (Filesaved)
        //    {

        //        string filename = Path.GetFileName(Session["fileupload"].ToString());
        //        dbfilepath = @"../ace12345/news_data/" + filename;


        //    }


        //    return dbfilepath;

        //}
        #endregion
    }
}
