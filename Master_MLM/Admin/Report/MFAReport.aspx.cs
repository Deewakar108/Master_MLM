using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Master_MLM.App_Code;

namespace Master_MLM.Admin.Report
{
    public partial class MFAReport : System.Web.UI.Page
    {
        Important imp = new Important();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { BindGridView(); }
        }

        public void BindGridView()
        {
            string sql = "select * from Member_registration where IsMFA=1 order by id desc";
            DataTable dt = imp.FillTable(sql);

            grdAutoPlan.DataSource = dt;
            grdAutoPlan.DataBind();
            pnl_view.Visible = true;
        }

    }
}