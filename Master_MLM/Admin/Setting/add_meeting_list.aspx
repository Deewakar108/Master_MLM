<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="add_meeting_list.aspx.cs"
    Inherits="Master_MLM.Admin.add_meeting_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Add Training Schedule
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">


        function CheckLimit() {
            var textField =
                document.getElementById("<%=txt_heading.ClientID %>");
            var labelCount =
                document.getElementById("<%=lblCountLimit.ClientID %>");

            if (textField.value.length > 40) {
                textField.value = textField.value.substring(0, 40);
            } else {
                labelCount.innerHTML = 40 - textField.value.length;
            }
        }

        function CheckLimitformessage() {
            var textField1 =
                document.getElementById("<%=txt_description.ClientID %>");
            var labelCount1 =
                document.getElementById("<%=lblCountLimit1.ClientID %>");

            if (textField1.value.length > 400) {
                textField1.value = textField1.value.substring(0, 400);
            } else {
                labelCount1.innerHTML = 400 - textField1.value.length;
            }
        }

    </script>
    <style type="text/css">
        .ddsmoothmenu ul li a.fifteen {
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
                <a href="#" class="current">Setting</a>
                <a href="#" class="current">Add Training Schedule </a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Add Training Schedule </h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid">
                            <div class="form-horizontal">
                                <div class="control-group">
                                    <label class="control-label">Date :</label>
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
                                        <asp:DropDownList ID="ddl_year" runat="server" CssClass="span2">
                                            <asp:ListItem Selected="True">Select</asp:ListItem>
                                            <asp:ListItem>2018</asp:ListItem>
                                            <asp:ListItem>2019</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">Location :</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txt_location" runat="server" CssClass="span6"></asp:TextBox>
                                        <span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_heading"
                                                Display="Dynamic" ErrorMessage="*" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                                        </span>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">Headline :</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txt_heading" runat="server" onKeyUp="CheckLimit();" CssClass="span6"></asp:TextBox>
                                        <span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_heading"
                                                Display="Dynamic" ErrorMessage="*" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                                            You have&nbsp;<asp:Label ID="lblCountLimit" runat="server"></asp:Label>
                                            characters left </span>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">Description :</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txt_description" Rows="5" runat="server" onKeyUp="CheckLimitformessage();"
                                            TextMode="MultiLine" CssClass="span6"></asp:TextBox>
                                        <span>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_description"
                                                Display="Dynamic" ErrorMessage="*" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                                            You have&nbsp;<asp:Label ID="lblCountLimit1" runat="server"></asp:Label>
                                            characters left. </span>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <div class="controls">
                                        <asp:Button ID="btnupload" runat="server" OnClick="btnupload_Click" Text="Upload" CssClass="btn btn-success" />
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row-fluid">
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
