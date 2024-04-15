<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="Member_Bank_Payment_History_List.aspx.cs" Inherits="Master_MLM.Admin.Member_Bank_Payment_History_List" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Member Bank Payment Send History List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .ddsmoothmenu ul li a.fourth {
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <!--breadcrumbs-->
        <div id="content-header">
            <div id="breadcrumb">
                <a href="/" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">Member</a>
                <a href="#" class="current">Member Bank Payment History List</a>
            </div>
        </div>
        <!--End-breadcrumbs-->

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Member Bank Payment History List</h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid">
                            <div class="row" style="padding: 30px 0px 20px 0px;">
                                <div style="margin: 0px 0px 10px 0px; padding: 0px; float: left; width: 100%; height: auto;">
                                    <table  class="table sks-table">
                                        <tr>
                                            <td style="text-align: center;">
                                                <asp:RadioButton ID="rb_daily" runat="server" GroupName="g1" Text="" AutoPostBack="True"
                                                    OnCheckedChanged="rb_daily_CheckedChanged" Checked="True" /> Daily
                                            </td>
                                            <td style="text-align: center;">
                                                <asp:RadioButton ID="rb_monthly" runat="server" AutoPostBack="True" GroupName="g1"
                                                    OnCheckedChanged="rb_monthly_CheckedChanged" Text=""  /> Monthly
                                            </td>
                                            <td style="text-align: center;">
                                                <asp:RadioButton ID="rb_yearly" runat="server" AutoPostBack="True" GroupName="g1"
                                                    OnCheckedChanged="rb_yearly_CheckedChanged" Text=""  /> Yearly
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right;">Select Date :
                                            </td>
                                            <td style="text-align: left;" colspan="2">
                                                <asp:DropDownList ID="ddl_day" runat="server" CssClass="span4" >
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
                                                <asp:DropDownList ID="ddl_month" runat="server"  CssClass="span4">
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
                                                <asp:DropDownList ID="ddl_year" runat="server"  CssClass="span4">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 10px; text-align: center;" colspan="3">
                                                <asp:Button ID="btn_find" CssClass="btn btn-primary" runat="server" Text="Find" 
                                                    OnClick="btn_Submit_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 10px; text-align: center;" colspan="3">
                                                <asp:Label ID="lbl_message" runat="server" CssClass="label label-warning"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div id="totaljoining" style="margin: 0px 0px 10px 0px; padding: 0px; float: left; width: 100%; height: auto;">
                                    <asp:Panel ID="pnl_view" Visible="false" runat="server">

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

                                        <table id="tblPrintIQ" style="width: 1100px; height: auto; margin: 10px auto; border-spacing: 0px; background-color: White;"
                                            border="0" cellpadding="0" cellspacing="0" class="round shadow">
                                            <tr>
                                                <td style="border-bottom: 1px solid #CCCCCC; padding: 10px 0px 10px 20px; font-weight: bold;"
                                                    valign="top" class="blue_bg">
                                                    <h2 style="text-align: center; width: 88%; margin: 0px; float: left; text-align: left;">Member Bank Payment Send History List
                                                    </h2>
                                                    <h2 style="text-align: center; width: 10%; margin: 0px; float: left; text-align: left;"
                                                        class="noPrint">

                                                        <asp:ImageButton ID="img_expord" runat="server" Height="32px" ImageUrl="~/images/Excelicons.png"
                                                            Style="margin-left: 0px; float: right;" OnClick="img_expord_Click" />
                                                    </h2>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center; padding: 5px 5px 5px 5px;">
                                                    <asp:GridView ID="grd_view" runat="server" Style="margin: 0px auto; font: normal 13px ebrima; height: auto; width: 100%;"
                                                        AutoGenerateColumns="false">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Serial No.">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSRNO" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Member Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_name" runat="server" Text='<%# bind("Member_name") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Member Code">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_member_code" runat="server" Text='<%# bind("Member_code") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Bank Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Bankname" runat="server" Text='<%#bind("Bankname") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="IFSC Code">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_IFSCCode" runat="server" Text='<%#bind("IFSCCode") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Transaction Id">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Transaction" runat="server" Text='<%#bind("Transaction_id") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Amount">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Amount" runat="server" Text='<%#bind("Amount") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Date">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Date" runat="server" Text='<%#bind("Date") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Time">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_time" runat="server" Text='<%#bind("Time") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Slip">
                                                                <ItemTemplate>
                                                                    <a href='<%#Eval("Slippath") %>' target="_blank" style="padding: 25px 0px 0px 26px; background-image: url('../images/icon-download.png'); background-repeat: no-repeat; background-position: left top; font-family: ebrima; font-size: 14px; color: #0066CC; text-decoration: none;"></a>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                        </Columns>
                                                        <HeaderStyle BackColor="#333333" ForeColor="White" Font-Size="13px" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                        </div>
                        <div class="row-fluid">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>






</asp:Content>
