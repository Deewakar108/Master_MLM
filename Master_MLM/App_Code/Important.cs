using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web.UI;

using System.ComponentModel;
using System.Drawing;

using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Web.UI.WebControls;


namespace Master_MLM.App_Code
{
    public class Important
    {

        #region     Company Details

        public string Url = "http://oceanhealthpariwar.com/";
        public string CompanyName = "Ocean Health Pariwar";
        public string CopyRightDate = DateTime.UtcNow.AddMinutes(30).AddHours(5).Year.ToString();
        public string AdminCode = "12345678";
        public string EmailID = "info@oceanhealthpariwar.com";
        public string MobileNo = "+91-8797195789";
        public string Address = "xxxxx,  xxxx, xxxx - 101010";
        public string suffixTag = "OC";
        public double TDS = 5;
        public double AdminCharge = 10;

       

        public bool IsCarryForward = true;
        public double CarryForwardLimit = 500;

        public string[] strMonth = { "JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC" };

        public string ClosingType = "'Referral','Sponsor','CarryForward','Incentive','Royalty','Reward'";

        #endregion


        public string UploadFile(FileUpload fileName, string FolderPath)
        {
            string itime = DateTime.UtcNow.AddHours(5).AddMinutes(30).ToString("HHmmss");
            string ImagePath = "";
            string rename = "";
            Boolean FileOK = false;
            Boolean FileSaved = false;
            int k = 0;
            if (fileName.HasFile)
            {
                if (fileName.FileBytes.Length < 1000000)
                {
                    string FileExtension = Path.GetExtension(fileName.FileName.ToLower());
                    rename = itime + FileExtension;
                    string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };
                    for (int i = 0; i < allowedExtensions.Length; i++)
                    {
                        k++;
                        if (FileExtension == allowedExtensions[i])
                        {
                            FileOK = true;
                            break;
                        }
                        else
                        {
                        }
                    }
                }

                else
                {

                }

                if (FileOK)
                {
                    try
                    {
                        string ServerPath = HttpContext.Current.Server.MapPath("~/" + FolderPath);
                        fileName.SaveAs(ServerPath + rename);
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
                    ImagePath = FolderPath + Path.GetFileName(rename);
                }
            }
            return ImagePath;
        }

        public void InsertException(string Message, string Page)
        {
            DateTime dtToday = DateTime.UtcNow.AddHours(5).AddMinutes(30);

            string date = dtToday.ToString("dd/MM/yyyy");
            string time = dtToday.ToString("hh:mm:ss tt");
            Message = Message.Replace("'", "-");
            string sql = "insert into ExceptionDetails(exception_message,date,time,page) values ('" + Message + "','" + date + "','" + time + "','" + Page + "')";
            int i = InsertUpdateDelete(sql);
        }

        public string ConvertStringTo_iDate(string DateInString)                //Format :: dd/MM/yyyy
        {
            DateInString = DateInString.Substring(6, 4) + DateInString.Substring(3, 2) + DateInString.Substring(0, 2);
            return DateInString;
        }

        public string GenerateRandomNumber(int start, int end)
        {  //10000000  99999999
            Random random = new Random();
            int temp = random.Next(start, end);
            return temp.ToString();
        }

        public string UniqueUserID()  //(int start, int end)
        {
            //int start = 10000000; int end = 99999999;  // Upto 8 digit.
            int start = 100000; int end = 999999;  // Upto 6 digit.
            string id = GenerateRandomNumber(start, end);
            bool ExistStatus = true;
            while (ExistStatus)
            {
                if (IsUserIDExist(id)) { break; }
                id = GenerateRandomNumber(start, end);
            }

            return id.ToString();
        }

        public bool IsUserIDExist(string id)
        {
            bool status = false;
            DataTable dtTemp = FillTable("SELECT *  FROM Member_Login where User_id='" + id + "'");
            if (dtTemp.Rows.Count == 0) { status = true; }
            return status;
        }

        public DataTable FillTable(string sqlQuery)
        {
            DataTable dtTemp = new DataTable();
            Connection conn = new Connection();
            //string connstr = con.connect_method();
            SqlConnection con = new SqlConnection(conn.connect_method());
            if (con.State == ConnectionState.Closed) { con.Open(); }
            SqlDataAdapter ad = new SqlDataAdapter(sqlQuery, con);
            ad.Fill(dtTemp);
            if (con.State == ConnectionState.Open) { con.Close(); }
            return dtTemp;
        }

        public int InsertUpdateDelete(string sqlQuery)
        {
            int i = 0;

            Connection conn = new Connection();
            SqlConnection con = new SqlConnection(conn.connect_method());
            if (con.State == ConnectionState.Closed) { con.Open(); }
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            i = cmd.ExecuteNonQuery();
            if (con.State == ConnectionState.Open) { con.Close(); }

            if (i == 0) { InsertException(sqlQuery, "During Insert"); }


            return i;
        }

        public bool CheckPanNumber(string PanNumber, string Mobile_number)
        {
            DataTable dtTemp = new DataTable();
            //dtTemp = FillTable("select Pan_number, Mobile_number  from Member_registration   where Mobile_number = '" + Mobile_number + "' AND Pan_number = '" +
            //    PanNumber + "'");
            //if (dtTemp.Rows.Count != 0)
            //{
            //    return false;
            //}

            dtTemp = FillTable("select Pan_number, count(Pan_number) as Total  from Member_registration   where  Pan_number = '" + PanNumber +
                "'  group by Pan_number");
            if (dtTemp.Rows.Count != 0)
            {
                int total = int.Parse(dtTemp.Rows[0]["Total"].ToString());
                if (total >= 3) { return false; }
            }
            return true;
        }

        public bool IsValidPAN(string PanNumber)
        {
            Regex regex = new Regex("^[a-zA-Z]{5}[0-9]{4}[a-zA-Z]{1}$");
            Match match = regex.Match(PanNumber);
            if (match.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public NodeParent NodeParentAndReferral(string SponsorID, string Postion)  //Postion = Left or Right  Only.
        {
            bool left = false; bool right = false;
            NodeParent nodeParent = new NodeParent();
            if (SponsorID == AdminCode)
            {
                nodeParent.SponsorID = SponsorID;
                nodeParent.Referral = SponsorID;
                nodeParent.Postion = Postion;
            }

            DataTable dt = FillTable("Select * from binary_status  where member_code='" + SponsorID + "'  ");
            if (dt.Rows.Count != 0)
            {
                //string leftID = dt.Rows[0]["left_child"].ToString();
                //string rightID = dt.Rows[0]["right_child"].ToString();

                //if (leftID == "" && rightID == "") {
                //    nodeParent.SponsorID = SponsorID;
                //    nodeParent.Referral = SponsorID;
                //    nodeParent.Postion = Postion;
                //}
                //else if (leftID != "" && rightID == "")
                //{
                //    nodeParent.SponsorID = SponsorID;
                //    nodeParent.Referral = SponsorID;
                //    nodeParent.Postion = Postion;
                //}
                //if (dt.Rows[0]["left_child"].ToString() == "") { left = true; }
                //if (dt.Rows[0]["right_child"].ToString() == "") { right = true; }

                //if (left == true && right == true)
                //{
                //    nodeParent.SponsorID = SponsorID;
                //    nodeParent.Referral = SponsorID;
                //    nodeParent.Postion = Postion;
                //}
                //else if (left == false && right == true)
                //{
                //    SponsorID = dt.Rows[0]["left_child"].ToString();
                //    return NodeParentAndReferral(SponsorID, Postion);
                //}
                //else if (left == true && right == false)
                //{
                //    nodeParent.SponsorID = SponsorID;
                //    nodeParent.Referral = SponsorID;
                //    nodeParent.Postion = Postion;
                //}
                //else if (left == false && right == false)
                //{
                //    SponsorID = Postion == "Left" ? dt.Rows[0]["left_child"].ToString() : dt.Rows[0]["right_child"].ToString();
                //    return NodeParentAndReferral(SponsorID, Postion);
                //}
            }

            //if (Postion == "Left") { }
            //if (Postion == "Right") { }
            return nodeParent;
        }

        public MemberCount GetTotalMemberWithPosition(string MemberCode, int left = 0, int right = 0)
        {
            MemberCount members = new MemberCount();
            members.Left = left;
            members.Right = right;

            string sqlQuery = "Select member_code, left_child, right_child  from binary_status where member_code='" + MemberCode + "'";
            DataTable dt = FillTable(sqlQuery);
            if (dt.Rows.Count != 0)
            {
                if (dt.Rows[0]["left_child"].ToString() != "")
                {
                    members.Left = GetTotalNumber(dt.Rows[0]["left_child"].ToString()) + 1;
                }
                if (dt.Rows[0]["right_child"].ToString() != "")
                {
                    members.Right = GetTotalNumber(dt.Rows[0]["right_child"].ToString()) + 1;
                }
                return members;
            }
            return members;
        }

        public MemberCount GetMemberChild(string MemberCode)
        {
            MemberCount members = new MemberCount();
            members.Left = 0;
            members.Middle = 0;
            members.Right = 0;

            string sqlQuery = "Select *  from Member_registration where Member_code='" + MemberCode + "'";
            DataTable dt = FillTable(sqlQuery);
            if (dt.Rows.Count != 0)
            {
                members.Left = int.Parse(dt.Rows[0]["LeftChild"].ToString());
                members.Middle = int.Parse(dt.Rows[0]["MiddleChild"].ToString());
                members.Right = int.Parse(dt.Rows[0]["RightChild"].ToString());

                //if (dt.Rows[0]["left_child"].ToString() != "")
                //{
                //    members.Left = GetTotalNumber(dt.Rows[0]["left_child"].ToString()) + 1;
                //}
                //if (dt.Rows[0]["right_child"].ToString() != "")
                //{
                //    members.Right = GetTotalNumber(dt.Rows[0]["right_child"].ToString()) + 1;
                //}
                return members;
            }
            return members;
        }


        public MemberBV GetMember_BV(string MemberCode, double left = 0, double right = 0)
        {
            MemberBV members = new MemberBV();
            members.LeftBV = left;
            members.RightBV = right;

            string sqlQuery = "Select member_code, left_child, right_child, BV  from binary_status where member_code='" + MemberCode + "'";
            DataTable dt = FillTable(sqlQuery);
            if (dt.Rows.Count != 0)
            {
                double currentBV = 0;
                if (dt.Rows[0]["left_child"].ToString() != "")
                {
                    members.LeftBV = GetAllChildBV(dt.Rows[0]["left_child"].ToString()) + currentBV;
                }
                else if (dt.Rows[0]["right_child"].ToString() != "")
                {
                    members.RightBV = GetAllChildBV(dt.Rows[0]["right_child"].ToString()) + currentBV;
                }
                return members;
            }
            return members;
        }

        public double GetAllChildBV(string MemberCode, double BV = 0)
        {
            string sqlQuery = "Select * from binary_status where member_code='" + MemberCode + "'";
            DataTable dt = FillTable(sqlQuery);
            if (dt.Rows.Count != 0)
            {
                double currentBV = float.Parse(dt.Rows[0]["BV"].ToString());
                if (dt.Rows[0]["left_child"].ToString() != "") { BV = BV + currentBV; BV = GetAllChildBV(dt.Rows[0]["left_child"].ToString(), BV); }
                if (dt.Rows[0]["right_child"].ToString() != "") { BV = BV + currentBV; BV = GetAllChildBV(dt.Rows[0]["right_child"].ToString(), BV); }
                else { BV = BV + currentBV; }

                return BV;
            }
            return BV;
        }

        public int GetTotalNumber(string MemberCode, int member = 0)
        {
            string sqlQuery = "Select * from binary_status where member_code='" + MemberCode + "'";
            DataTable dt = FillTable(sqlQuery);
            if (dt.Rows.Count != 0)
            {
                if (dt.Rows[0]["left_child"].ToString() != "") { member = member + 1; member = GetTotalNumber(dt.Rows[0]["left_child"].ToString(), member); }
                if (dt.Rows[0]["right_child"].ToString() != "") { member = member + 1; member = GetTotalNumber(dt.Rows[0]["right_child"].ToString(), member); }
                return member;
            }
            return member;
        }

        public int GetCompletePairOnLevel(string MemberCode, int LevelNumber = 0)
        {
            string[] members = MemberCode.Split(',');
            MemberCode = "";
            int temp = 0;
            for (int i = 0; i < members.Length; i++)
            {
                string sqlQuery = "Select * from binary_status where member_code='" + members[i] + "'";
                DataTable dt = FillTable(sqlQuery);
                if (dt.Rows[0]["left_child"].ToString() != "" && dt.Rows[0]["right_child"].ToString() != "")
                {
                    temp = 1;
                    if (MemberCode == "") { MemberCode = MemberCode + dt.Rows[0]["left_child"].ToString() + "," + dt.Rows[0]["right_child"].ToString(); }
                    else { MemberCode = MemberCode + "," + dt.Rows[0]["left_child"].ToString() + "," + dt.Rows[0]["right_child"].ToString(); }

                }
                else { temp = 0; break; }
            }
            LevelNumber = LevelNumber + temp;
            if (MemberCode != "") { LevelNumber = GetCompletePairOnLevel(MemberCode, LevelNumber); }

            return LevelNumber;
        }

        public string GetPostName(string MemberCode, int PairLevel = 0)
        {
            string sqlQuery = "";
            if (PairLevel >= 3)
            {
                sqlQuery = "Select * from PostDetails  where MembersNo <= " + GetTotalNumber(MemberCode, 0) + " order by id desc";
            }
            else
            {
                sqlQuery = "Select * from PostDetails  where PairLevel <= " + PairLevel + " order by id desc";
            }
            DataTable dt = FillTable(sqlQuery);
            if (dt.Rows.Count != 0)
            {
                return dt.Rows[0]["PostName"].ToString();
            }
            return "N/A";
        }

        public string GetPostNameWithStatus(string MemberCode, string Status) // Check Here Status As FREE or PAID.
        {
            if (Status == "PAID") { return GetPostName(MemberCode, GetCompletePairOnLevel(MemberCode, 0)); }
            return "N/A";
        }

        public RewardPoints getRewardPoints(string memberCode)
        {
            RewardPoints r = new RewardPoints();
            string sql = "select * from RewardBinaryTable where MemberCode='" + memberCode + "'";
            DataTable dt = FillTable(sql);
            if (dt.Rows.Count != 0)
            {
                r.LeftRP = dt.Rows[0]["LeftRP"].ToString() == "" ? "0" : dt.Rows[0]["LeftRP"].ToString();
                r.RightRP = dt.Rows[0]["RightRP"].ToString() == "" ? "0" : dt.Rows[0]["RightRP"].ToString();
                return r;
            }

            r.LeftRP = "0";
            r.RightRP = "0";
            return r;
        }

        //public string GetPostName(int TotalNumber = 0)
        //{
        //    string sqlQuery = "";
        //    if (TotalNumber >= 3)
        //    {
        //        sqlQuery = "Select * from PostDetails  where MembersNo <= " + TotalNumber + " order by id desc";
        //    }
        //    else
        //    {
        //        sqlQuery = "Select * from PostDetails  where MembersNo <= " + TotalNumber + " order by id desc";
        //    }
        //    DataTable dt = FillTable(sqlQuery);
        //    if (dt.Rows.Count != 0)
        //    {
        //        return dt.Rows[0]["PostName"].ToString();
        //    }
        //    return "";
        //}

        public static void SendAlert(string Message)
        {
            Message = "alert('" + Message + "');";

            if (HttpContext.Current.CurrentHandler is Page)
            {
                Page page = (Page)HttpContext.Current.CurrentHandler;

                if (ScriptManager.GetCurrent(page) != null)
                {
                    ScriptManager.RegisterStartupScript(page, typeof(Page), "Message", Message, true);
                }
                else
                {
                    page.ClientScript.RegisterStartupScript(typeof(Page), "Message", Message, true);
                }
            }
        }

        public void Alert()
        {
            string Message = "AlertClick()";

            if (HttpContext.Current.CurrentHandler is Page)
            {
                Page page = (Page)HttpContext.Current.CurrentHandler;

                if (ScriptManager.GetCurrent(page) != null)
                {
                    ScriptManager.RegisterStartupScript(page, typeof(Page), "Message", Message, true);
                }
                else
                {
                    page.ClientScript.RegisterStartupScript(typeof(Page), "Message", Message, true);
                }
            }
        }


        public string GetTeamMemberList(string MemberCode, string MemberList = "")
        {
            string[] members = MemberCode.Split(',');
            MemberCode = "";
            for (int i = 0; i < members.Length; i++)
            {
                if (MemberList == "") { MemberList = members[i]; }
                else { MemberList = MemberList + "," + members[i]; }

                string sqlQuery = "Select * from binary_status where member_code='" + members[i] + "'";
                DataTable dt = FillTable(sqlQuery);
                if (dt.Rows[0]["left_child"].ToString() != "") { MemberList = GetTeamMemberList(dt.Rows[0]["left_child"].ToString(), MemberList); }
                if (dt.Rows[0]["right_child"].ToString() != "") { MemberList = GetTeamMemberList(dt.Rows[0]["right_child"].ToString(), MemberList); }
            }

            return MemberList;
        }

        public string GetTeamMember(string MemberCode)
        {
            string[] members = GetTeamMemberList(MemberCode).Split(',');
            MemberCode = "";
            for (int i = 0; i < members.Length; i++)
            {
                if (MemberCode == "") { MemberCode = "'" + members[i] + "'"; }
                else { MemberCode = MemberCode + "," + "'" + members[i] + "'"; }
            }

            return MemberCode;
        }


        public Package getPackageDetail(string Package_id)
        {
            Package p = new Package();
            string sql = " select Package_name, Package_id, BV, Package_amount, MonthlyYield, Duration from Joining_package where Package_id='" + Package_id + "'";
            DataTable dt = FillTable(sql);
            if (dt.Rows.Count != 0)
            {
                p.PackageName = dt.Rows[0]["Package_name"].ToString();
                p.ID = dt.Rows[0]["Package_id"].ToString();
                p.BV = dt.Rows[0]["BV"].ToString();
                p.PackageAmount = dt.Rows[0]["Package_amount"].ToString();
                p.MonthlyYield = dt.Rows[0]["MonthlyYield"].ToString();
                p.Duration = dt.Rows[0]["Duration"].ToString();
                return p;
            }
            p.PackageName = "";
            p.ID = "0";
            p.BV = "0";
            return p;
        }

        public bool IsValidEPin(string E_Pin)
        {
            bool status = false;
            string sql = "select * from E_PIN_details where Status='GIVEN' and  Epin='" + E_Pin + "'";
            DataTable dt = FillTable(sql);
            if (dt.Rows.Count != 0) { return true; }

            return status;
        }



        public string AlphaNumericKey(int KeyLength, bool IsAlphaNumeric)
        {
            string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "SSLIFE201890";

            string characters = numbers;
            if (IsAlphaNumeric)
            {
                characters += alphabets + small_alphabets + numbers;
            }
            int length = KeyLength;
            string key = string.Empty;
            for (int i = 0; i < length; i++)
            {
                string character = string.Empty;
                do
                {
                    int index = new Random().Next(0, characters.Length);
                    character = characters.ToCharArray()[index].ToString();
                } while (key.IndexOf(character) != -1);
                key += character;
            }
            return key;
        }


        public string GetNewID(string FieldName, string TableName)
        {
            string sql = "select isnull(MAX(" + FieldName + "), 1) as ID FROM " + TableName;
            return (int.Parse(FillTable(sql).Rows[0]["ID"].ToString()) + 1).ToString();
        }
    }

    public class LeftRightNode
    {
        public bool LeftNode { get; set; }
        public bool RightNode { get; set; }
        public string Referral { get; set; }
    }

    public class NodeParent
    {
        public string Postion { get; set; }
        public string SponsorID { get; set; }
        public string Referral { get; set; }
    }

    public class RewardPoints
    {
        public string LeftRP { get; set; }
        public string RightRP { get; set; }
    }

    public class Package
    {
        public string ID { get; set; }
        public string PackageName { get; set; }
        public string BV { get; set; }
        public string PackageAmount { get; set; }
        public string MonthlyYield { get; set; }
        public string Duration { get; set; }
    }

    public class MemberCount
    {
        public int Left { get; set; }
        public int Middle { get; set; }
        public int Right { get; set; }
    }

    public class MemberBV
    {
        public double LeftBV { get; set; }
        public double RightBV { get; set; }
    }


}