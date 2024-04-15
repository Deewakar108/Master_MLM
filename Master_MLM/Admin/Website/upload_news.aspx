<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="upload_news.aspx.cs" Inherits="Master_MLM.Admin.upload_news"
    Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Upload News
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">


        function CheckLimit() {
            var textField =
                document.getElementById("<%=txt_heading.ClientID %>");
            var labelCount =
                document.getElementById("<%=lblCountLimit.ClientID %>");

            if (textField.value.length > 30) {
                textField.value = textField.value.substring(0, 30);
            } else {
                labelCount.innerHTML = 30 - textField.value.length;
            }
        }

        function CheckLimitformessage() {
            var textField1 =
                document.getElementById("<%=txt_description.ClientID %>");
            var labelCount1 =
                document.getElementById("<%=lblCountLimit1.ClientID %>");

            if (textField1.value.length > 300) {
                textField1.value = textField1.value.substring(0, 300);
            } else {
                labelCount1.innerHTML = 300 - textField1.value.length;
            }
        }

    </script>

    <style type="text/css">
        .ddsmoothmenu ul li a.eleven {
            color: #446CB3;
            background: #fff;
            text-shadow: none;
            box-shadow: none;
            border-right: 1px solid #446CB3;
            cursor: pointer;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="content">

        <div id="content-header">
            <div id="breadcrumb">
                <a href="/" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">Website</a>
                <a href="#" class="current">Upload News</a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Upload News</h5>
                    </div>
                    <div class="widget-content nopadding">
                        <div class="row-fluid">
                            <div class="form-horizontal"  id="basic_validate">
                                <div class="control-group">
                                    <label class="control-label"> Date :</label>
                                    <div class="controls">
                                         <asp:DropDownList ID="ddl_day" runat="server" CssClass="span1">
                                    <asp:ListItem Selected="True">Select</asp:ListItem>
                                    <asp:ListItem>01</asp:ListItem>
                                    <asp:ListItem>02</asp:ListItem>
                                    <asp:ListItem>03</asp:ListItem>
                                    <asp:ListItem>04</asp:ListItem>
                                    <asp:ListItem>05</asp:ListItem>
                                    <asp:ListItem>06</asp:ListItem>
                                    <asp:ListItem>07</asp:ListItem>
                                    <asp:ListItem>08</asp:ListItem>
                                    <asp:ListItem>09</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>11</asp:ListItem>
                                    <asp:ListItem>12</asp:ListItem>
                                    <asp:ListItem>13</asp:ListItem>
                                    <asp:ListItem>14</asp:ListItem>
                                    <asp:ListItem>15</asp:ListItem>
                                    <asp:ListItem>16</asp:ListItem>
                                    <asp:ListItem>17</asp:ListItem>
                                    <asp:ListItem>18</asp:ListItem>
                                    <asp:ListItem>19</asp:ListItem>
                                    <asp:ListItem>20</asp:ListItem>
                                    <asp:ListItem>21</asp:ListItem>
                                    <asp:ListItem>22</asp:ListItem>
                                    <asp:ListItem>23</asp:ListItem>
                                    <asp:ListItem>24</asp:ListItem>
                                    <asp:ListItem>25</asp:ListItem>
                                    <asp:ListItem>26</asp:ListItem>
                                    <asp:ListItem>27</asp:ListItem>
                                    <asp:ListItem>28</asp:ListItem>
                                    <asp:ListItem>29</asp:ListItem>
                                    <asp:ListItem>30</asp:ListItem>
                                    <asp:ListItem>31</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddl_month" runat="server" CssClass="span1">
                                    <asp:ListItem Selected="True">Select</asp:ListItem>
                                    <asp:ListItem>01</asp:ListItem>
                                    <asp:ListItem>02</asp:ListItem>
                                    <asp:ListItem>03</asp:ListItem>
                                    <asp:ListItem>04</asp:ListItem>
                                    <asp:ListItem>05</asp:ListItem>
                                    <asp:ListItem>06</asp:ListItem>
                                    <asp:ListItem>07</asp:ListItem>
                                    <asp:ListItem>08</asp:ListItem>
                                    <asp:ListItem>09</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>11</asp:ListItem>
                                    <asp:ListItem>12</asp:ListItem>
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddl_year" runat="server" CssClass="span2" >
                                </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label"> Headline :</label>
                                    <div class="controls">
                                       <asp:TextBox ID="txt_heading" runat="server" onKeyUp="CheckLimit();" CssClass="span6"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_heading"
                                        Display="Dynamic" ErrorMessage="*">
                                    </asp:RequiredFieldValidator>
                                    You have&nbsp;<asp:Label ID="lblCountLimit" runat="server" ForeColor="Black" Text="30"></asp:Label>
                                    characters left </span>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label"> Description :</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txt_description" runat="server" onKeyUp="CheckLimitformessage();" CssClass="span6"
                                    TextMode="MultiLine" Rows="5"></asp:TextBox>
                                <span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_description"
                                        Display="Dynamic" ErrorMessage="*">
                                    </asp:RequiredFieldValidator>
                                    You have&nbsp;<asp:Label ID="lblCountLimit1" runat="server" ForeColor="Black" Text="300"></asp:Label>
                                    characters left </span>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <div class="controls">
                                        <asp:Button ID="btnupload" runat="server" OnClick="btnupload_Click" Text="Upload News" CssClass="btn btn-success" />
                                    </div>
                                </div>
                            </div>
                            <div class="span12" style="text-align: center;">
                                <asp:Label ID="lblmessage" runat="server" CssClass="label label-warning"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
