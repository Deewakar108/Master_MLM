<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Membertopup_report.aspx.cs" Inherits="Master_MLM.Admin.Members.Membertopup_report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Topup Report 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="../../Member_4235profile/css/mygrid.css" rel="stylesheet" />
    <style type="text/css">
        .ddsmoothmenu ul li a.fifth {
            color: #446CB3;
            background: #fff;
            text-shadow: none;
            box-shadow: none;
            border-right: 1px solid #446CB3;
            cursor: pointer;
        }

        @media print {
            .noPrint {
                display: none;
            }
        }
    </style>
    <script type="text/javascript">
        function printTable() {
            var printContent = document.getElementById("tblPrintIQ");
            var windowUrl = 'abount:blank';
            var num;
            var uniqueName = new Date();
            var windowName = 'Print' + uniqueName.getTime();
            var printWindow = window.open(num, windowName, 'left=50000,top=50000,width=0,height=0');
            printWindow.document.write(printContent.innerHTML);
            printWindow.document.close();
            printWindow.focus();
            printWindow.print();
            printWindow.close();
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">

        <div id="content-header">
            <div id="breadcrumb">
                <a href="/" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">Report</a>
                <a href="#" class="current">Topup Member List</a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                       <%-- <span class="icon-right"><i class="icon-print" onclick="$('#<%= print1.ClientID %>').click();"></i></span>
                        <span class="icon-right"><i class="icon-save" onclick="$('#<%= img_expord.ClientID %>').click();"></i></span>--%>
                        <h5>Topup Member List</h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid">
                            <%--<div class="span12" style="text-align: center;">
                                <asp:RadioButton ID="rb_daily" runat="server" GroupName="g1" Text="" AutoPostBack="True" OnCheckedChanged="rb_daily_CheckedChanged" />&nbsp;Daily
                                <asp:RadioButton ID="rb_monthly" runat="server" AutoPostBack="True" GroupName="g1" OnCheckedChanged="rb_monthly_CheckedChanged" Text="" Style="padding: 0 0 0 15px;" />&nbsp;Monthly
                                <asp:RadioButton ID="rb_yearly" runat="server" AutoPostBack="True" GroupName="g1" OnCheckedChanged="rb_yearly_CheckedChanged" Text="" Style="padding: 0 0 0 15px;" />&nbsp;Yearly
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
                                <asp:DropDownList ID="ddl_year" runat="server" CssClass="span1" Style="padding-left: 2px;">
                                </asp:DropDownList>
                            </div>--%>
                            <div class="span12" style="text-align: center; display:none;">
                                <asp:Button ID="btn_find" runat="server" Text="Find Topup list" CssClass="btn btn-primary" OnClick="btn_find_Click" />
                            </div>
                            <div class="span12" style="text-align: center;">
                                <br />
                                <asp:Label ID="lbl_message" runat="server" CssClass="label label-warning"></asp:Label>
                            </div>

                            <div style="margin: 0px 0px 10px 0px; padding: 0px; float: left; width: 100%; height: auto; background-color: white;">
                                <div style="margin: 0px; padding: 0px; width: 100%">
                                    <asp:Panel ID="pnl_view" Visible="false" runat="server">
                                        <table style="height: auto; margin: 2px auto; border-spacing: 0px; width: 100%;"
                                            border="0" class="round shadow">

                                            <tr>
                                                <td style="text-align: center; padding: 5px 5px 5px 5px;">
                                                    <asp:GridView ID="grd_view" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                                                        HeaderStyle-CssClass="header" RowStyle-CssClass="rows" runat="server" AutoGenerateColumns="False">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sr No.">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_sl" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Member Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_name" runat="server" Text='<%# Bind("Member_name") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Member Code">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_member_code" runat="server" Text='<%# Bind("Member_code") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Mobile No">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_mobile" runat="server" Text='<%#Bind("Mobile_number") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Sponsor code">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_sponcer_code" runat="server" Text='<%# Bind("Sponcer_code") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Topup Date">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Joiningtime" runat="server" Text='<%# Bind("ActivationDate") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Package">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_joining_package" runat="server" Text='<%# Bind("Package") %>'></asp:Label>
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
