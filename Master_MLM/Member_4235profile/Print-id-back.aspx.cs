using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Master_MLM.Member_4235profile
{
    public partial class Print_id_back : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Print_Member_Id_Card.aspx", false);
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "printit", "printit()", true);
        }
    }
}