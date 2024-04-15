<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Spill_Report.aspx.cs"
    Inherits="Master_MLM.Admin_87554b.Spill_Report" EnableEventValidation="false" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Spill Report
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .ddsmoothmenu ul li a.fifth {
            color: #446CB3;
            background: #fff;
            text-shadow: none;
            box-shadow: none;
            border-right: 1px solid #446CB3;
            cursor: pointer;
        }

        .gridview a {
            display: inline-block;
            margin: 0px 3px 0px 0px;
            padding: 5px 5px 5px 5px;
            background: #336699;
            background: -webkit-gradient(linear, left bottom, left top, color-stop(0, #336699), color-stop(1, #ffffff));
            background: -ms-linear-gradient(bottom, #336699, #ffffff);
            background: -moz-linear-gradient(center bottom, #336699 0%, #ffffff 100%);
            background: -o-linear-gradient(#ffffff, #336699);
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr= '#ffffff', endColorstr= '#336699', GradientType=0);
            font-weight: bold;
            width: auto;
            text-decoration: none;
            cursor: pointer;
        }

        @media print {
            .noPrint {
                display: none;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">

        <div id="content-header">
            <div id="breadcrumb">
                <a href="/" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">Report</a>
                <a href="#" class="current">Spill Report  Date wise</a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Spill Report  Date wise</h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid">
                            <div class="span12" style="text-align: center;">
                                <asp:RadioButton ID="rb_daily" runat="server" GroupName="g1" Text="" AutoPostBack="True"
                                    OnCheckedChanged="rb_daily_CheckedChanged" Style="margin: 0px 0px 0px 25px;" />
                                &nbsp;Daily
                                                    <asp:RadioButton ID="rb_monthly" runat="server" AutoPostBack="True" GroupName="g1"
                                                        OnCheckedChanged="rb_monthly_CheckedChanged" Text="" />
                                &nbsp;Monthly
                                                    <asp:RadioButton ID="rb_yearly" runat="server" AutoPostBack="True" GroupName="g1"
                                                        OnCheckedChanged="rb_yearly_CheckedChanged" Text="" />
                                &nbsp;Yearly
                            </div>
                            <div class="span12" style="text-align: center;">
                                Member Code :
                                <asp:TextBox ID="txt_memberid" runat="server" placeholder="Member Code" ></asp:TextBox>
                            </div>
                            <div class="span12" style="text-align: center;">
                                Date : 
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
                                </asp:DropDownList>
                            </div>
                            <div class="span12" style="text-align: center;">
                                Position :
                                <asp:DropDownList ID="ddl_position" runat="server" CssClass="span2">
                                    <asp:ListItem Selected="True">Select</asp:ListItem>
                                    <asp:ListItem>Left</asp:ListItem>
                                    <asp:ListItem>Middle</asp:ListItem>
                                    <asp:ListItem>Right</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="span12" style="text-align: center;">
                                <asp:Button ID="btn_find" runat="server" Text="Find" CssClass="btn btn-primary" OnClick="btn_Submit_Click" />
                                <br />
                                <br />
                                <asp:Label ID="lbl_message" runat="server" CssClass="label label-warning"></asp:Label>
                            </div>
                        </div>
                        <asp:Panel ID="pnl_view" Visible="false" runat="server">
                            <div class="row-fluid">
                                <asp:GridView ID="grd_view" runat="server" CssClass="table table-bordered data-table dataTable"
                                    AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr No.">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_sl" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Member Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_member_name" runat="server" Text='<%# bind("Member_name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Member Code">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMemberCode" runat="server" Text='<%#hide_string(Eval("Member_code").ToString()) %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Package">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_joining_package" runat="server" Text='<%# bind("joining_package") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_amount" runat="server" Text='<%# bind("Joining_amount") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Joining Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_date" runat="server" Text='<%# bind("Date") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_id" runat="server" Text='<%#bind("Id") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Activation date">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_activationdate" runat="server" Text='<%#bind("Verification_date") %>'></asp:Label>
                                                &nbsp;&nbsp;
                                                                                                       <asp:Label ID="lbltime" runat="server" Text='<%#bind("Verification_time") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
