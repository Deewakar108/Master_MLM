using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Master_MLM.App_Code;

namespace Master_MLM.Admin_87554b
{
    public partial class ClosingReport : System.Web.UI.Page
    {
        Important imp = new Important();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { BindClosingDate(); }
        }

        public void BindClosingDate()
        {
            string sql = "select *, (End_date + ' - ' + Interval) as TextValue from closing order by Id desc";
            DataTable dtTemp = imp.FillTable(sql);
            if (dtTemp.Rows.Count != 0)
            {
                ddlClosingDate.DataSource = dtTemp;
                ddlClosingDate.DataTextField = "TextValue";
                ddlClosingDate.DataValueField = "Closingno";
                ddlClosingDate.DataBind();

                ddlClosingDate.Items.Insert(0, new ListItem { Text = "Select", Value = "0", Selected = true });
            }
        }

        protected void btn_find_Click(object sender, EventArgs e)
        {


            if (ddlClosingDate.SelectedValue != "0")
            {
                BindGridView();
            }
            else
            {
                lbl_message.Text = "Invalid Date.";
                pnl_view.Visible = false;
            }
        }

        public void BindGridView()
        {
            if (ViewState["dtdatas"] == null)
            {
                DataTable dtdatas = new DataTable();
                dtdatas.Columns.Add("Member_code");
                dtdatas.Columns.Add("Member_name");
                dtdatas.Columns.Add("pre_left");
                dtdatas.Columns.Add("pre_right");
                dtdatas.Columns.Add("Current_left");
                dtdatas.Columns.Add("Current_right");
                dtdatas.Columns.Add("Pair");
                dtdatas.Columns.Add("Pairno");
                dtdatas.Columns.Add("Lapsepair");
                ViewState["dtdatas"] = dtdatas;
            }

            string ClosingNumber = ddlClosingDate.SelectedValue;
            string sql = " select  *,(select Member_name from Member_registration where Member_code=t1.Membercode) as Member_name from dbo.[Daily_child_table] t1 where Closingno='" + ClosingNumber + "'";
            DataTable dt = imp.FillTable(sql);
            int rowcount = dt.Rows.Count;
            if (rowcount > 0)
            {
                //string Membercode = "";
                //string Member_name = "";
                //string Total_leftchild = "";
                //string Total_rightchild = "";
                //string Pair = "";
                //string Lapsepair = "0";
                //string Deleteid = "0";
                for (int i = 0; i < rowcount; i++)
                {


                    string Membercode = dt.Rows[i]["Membercode"].ToString();
                    string Member_name = dt.Rows[i]["Member_name"].ToString();
                    string Total_leftchild = dt.Rows[i]["Total_leftchild"].ToString();
                    string Total_rightchild = dt.Rows[i]["Total_rightchild"].ToString();
                    string Pair = dt.Rows[i]["Pair"].ToString();
                    string Deleteid = dt.Rows[i]["Deleteid"].ToString();
                    string Lapsepair = "0";
                    if (double.Parse(Pair) > 5)
                    {
                        Lapsepair = (double.Parse(Pair) - 5).ToString();
                    }

                    string pre_child = find_previous_child(Membercode, Deleteid);
                    string[] child = pre_child.Split('^');

                    DataTable dtDatas = (DataTable)ViewState["dtdatas"];
                    DataRow drNewRow = dtDatas.NewRow();
                    drNewRow["Member_code"] = Membercode;
                    drNewRow["Member_name"] = Member_name;
                    drNewRow["pre_left"] = child[0].ToString();
                    drNewRow["pre_right"] = child[1].ToString();
                    drNewRow["Current_left"] = Total_leftchild;
                    drNewRow["Current_right"] = Total_rightchild;
                    drNewRow["Pair"] = Pair;
                    drNewRow["Lapsepair"] = Lapsepair;
                    //add this new row to the Datatable and commit changes
                    dtDatas.Rows.Add(drNewRow);
                    dtDatas.AcceptChanges();
                    ViewState["dtdatas"] = dtDatas;
                }
                grd_view.DataSource = ViewState["dtdatas"];
                grd_view.DataBind();
                ViewState["dtdatas"] = null;
                pnl_view.Visible = true;
                lbl_message.Text = "";
            }
            else
            {
                grd_view.DataSource = ViewState["dtdatas"];
                grd_view.DataBind();
                ViewState["dtdatas"] = null;
                pnl_view.Visible = true;
                lbl_message.Text = "";
            }

        }

        private string find_previous_child(string Membercode, string Deleteid)
        {
            string sql = "Select top 1 Total_leftchild,Total_rightchild from dbo.[Daily_child_table] where Membercode='" + Membercode + "' and Deleteid<" + Deleteid + " order by id desc";
            DataTable dt = imp.FillTable(sql);
            int rowcount = dt.Rows.Count;
            if (rowcount > 0)
            {
                return dt.Rows[0][0].ToString() + "^" + dt.Rows[0][1].ToString();
            }
            else { return "0^0"; }
        }



        protected void grd_view_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd_view.PageIndex = e.NewPageIndex;
            BindGridView();

        }
    }
}