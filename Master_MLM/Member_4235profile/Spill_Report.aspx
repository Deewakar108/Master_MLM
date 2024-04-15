<%@ Page Title="Spill Report" Language="C#" MasterPageFile="~/Member_4235profile/Member_main.Master" AutoEventWireup="true" CodeBehind="Spill_Report.aspx.cs" Inherits="Master_MLM.Member_4235profile.Spill_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/mygrid.css" rel="stylesheet" />
    <style type="text/css">
        .ddsmoothmenu ul li a.tenth {
            background-color: #F700A9;
            color: #fff;
        }

        @media print {
            .noPrint {
                display: none;
            }
        }

        @media (max-width:408px) {
            .sks-hidden {
                display: none;
            }
        }
    </style>

    <script type="text/javascript">
        printDivCSS = new String('<link href="itemprint.css" rel="stylesheet" type="text/css">')
        function printDiv(divId) {
            window.frames["print_frame"].document.body.innerHTML = printDivCSS + document.getElementById(divId).innerHTML
            window.frames["print_frame"].window.focus()
            window.frames["print_frame"].window.print()
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="index.html">Home</a> <i class="fa fa-angle-right"></i></li>
    </ol>
    <div class="grid-form">
        <div class="grid-form1">
            <h4 class="breadcrumb-item"><a>Spill Report  Date wise</a></h4>
            <div class="panel-body panel-footer">
                <div class="row" style="padding: 3px 0px 0px 0px;">
                    <div style="margin: 0px auto 0px auto; padding: 30px 0px 30px 0px; height: auto;">
                        <div style="margin: 0px; padding: 0px; width: 100%; height: auto;">
                            <table border="0" style="margin: 25px auto 25px auto; background-color: White; border: 1px solid #eee287;  height: 85px;"
                                class="round shadow">

                                <tr>
                                    <td colspan="4" style="padding: 10px 0px 10px 0px; text-align: center;">
                                        <asp:RadioButton ID="rb_daily" runat="server" GroupName="g1" Text="Daily" AutoPostBack="True"
                                            OnCheckedChanged="rb_daily_CheckedChanged" Style="margin: 0px 0px 0px 25px;" />
                                        <asp:RadioButton ID="rb_monthly" runat="server" AutoPostBack="True" GroupName="g1"
                                            OnCheckedChanged="rb_monthly_CheckedChanged" Text="Monthly" Style="margin: 0px 0px 0px 25px;" />
                                        <asp:RadioButton ID="rb_yearly" runat="server" AutoPostBack="True" GroupName="g1"
                                            OnCheckedChanged="rb_yearly_CheckedChanged" Text="Yearly" Style="margin: 0px 0px 0px 25px;" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; padding: 5px 5px 5px 0px;">Select Date
                                    </td>
                                    <td style="text-align: left; padding: 5px 5px 5px 0px;" colspan="3">
                                        <asp:DropDownList ID="ddl_day" runat="server" CssClass="form-control" Style="margin-right: 7px; float: left; width: 90px;">
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
                                        <asp:DropDownList ID="ddl_month" runat="server" CssClass="form-control" Style="float: left; margin-right: 7px; width: 90px;">
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
                                        <asp:DropDownList ID="ddl_year" runat="server" CssClass="form-control" Style="width: 90px; float: left;">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 10px 0px 10px 0px; text-align: center;" colspan="4">
                                        <asp:Button ID="btn_find" runat="server" CssClass="btn btn-success" Text="Find" Style="padding: 3px 0px 3px 0px; height: 30px; width: 100px;"
                                            OnClick="btn_Submit_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 0px 0px 10px 0px; text-align: center;" colspan="4">
                                        <asp:Label ID="lbl_message" runat="server" Font-Bold="False" Font-Size="12px" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                            </table>

                            <div style="margin: 0px 0px 10px 0px; padding: 0px; float: left; width: 100%; height: auto; background-color: white;">
                                <div style="margin: 0px; padding: 0px; width: 100%">
                                    <asp:Panel ID="pnl_view" Visible="false" runat="server">
                                        <table style="height: auto; margin: 2px auto; border-spacing: 0px; width: 100%;"
                                            border="0" class="round shadow">
                                            <tr>
                                                <td style="border-bottom: 1px solid #CCCCCC; padding: 10px 0px 10px 20px; font-weight: bold;"
                                                    valign="top" class="blue_bg">Spill Report 
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center; padding: 5px 5px 5px 5px;">
                                                    <asp:GridView ID="grd_view" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                                        HeaderStyle-CssClass="header" RowStyle-CssClass="rows" runat="server" Style="margin: 0px auto; font: normal 13px ebrima; height: auto;"
                                                        AutoGenerateColumns="False" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sr No.">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_sl" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Member Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_member_name" runat="server" Text='<%# Bind("Member_name") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Member Code" ItemStyle-CssClass="sks-hidden" ControlStyle-CssClass="sks-hidden" HeaderStyle-CssClass="sks-hidden">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblMemberCode" runat="server" Text='<%# Bind("Member_code") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Package" ItemStyle-CssClass="sks-hidden" ControlStyle-CssClass="sks-hidden" HeaderStyle-CssClass="sks-hidden">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_joining_package" runat="server" Text='<%# Bind("joining_package") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Amount" ItemStyle-CssClass="sks-hidden" ControlStyle-CssClass="sks-hidden" HeaderStyle-CssClass="sks-hidden">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_amount" runat="server" Text='<%# Bind("Joining_amount") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Joining Date" ItemStyle-CssClass="sks-hidden" ControlStyle-CssClass="sks-hidden" HeaderStyle-CssClass="sks-hidden">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_date" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="ID" Visible="false" ItemStyle-CssClass="sks-hidden" ControlStyle-CssClass="sks-hidden" HeaderStyle-CssClass="sks-hidden">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_id" runat="server" Text='<%#Bind("Id") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Activation date" ItemStyle-CssClass="sks-hidden" ControlStyle-CssClass="sks-hidden" HeaderStyle-CssClass="sks-hidden">
                                                                <ItemTemplate>


                                                                    <asp:Label ID="lbl_activationdate" runat="server" Text='<%#Bind("Verification_date") %>'></asp:Label>
                                                                    &nbsp;&nbsp;
                                                                                                       <asp:Label ID="lbltime" runat="server" Text='<%#Bind("Verification_time") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <HeaderStyle BackColor="#00A4CC" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
