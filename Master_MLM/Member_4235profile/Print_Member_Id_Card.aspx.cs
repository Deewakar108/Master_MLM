using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Master_MLM.App_Code;
using System.Data;

namespace Master_MLM.Member_4235profile
{
    public partial class Print_Member_Id_Card : System.Web.UI.Page
    {
        string scrpt;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        My mycode = new My();
        protected void btn_find_Click(object sender, EventArgs e)
        {
            try
            {
                if (radio_print_front.Checked == true)
                {
                    string path = "Print_id.aspx";
                    Response.Redirect(path);
                }
                else if (radio_print_back.Checked == true)
                {
                    string path = "Print-id-back.aspx";
                    Response.Redirect(path);
                }
            }
            catch (Exception ex)
            {
            }

        }


    }
}