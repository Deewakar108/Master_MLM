<%@ Page Title="Repurchase Product Date Wise" Language="C#" MasterPageFile="~/Member_4235profile/Member_main.Master" AutoEventWireup="true" CodeBehind="View-Repurchase-Product.aspx.cs" Inherits="Master_MLM.Member_4235profile.View_Repurchase_Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .mydatagrid {
            width: 100%;
            border: solid 2px #1b93e1;
            min-width: 80%;
            margin: 15px 0px 0px 0px;
        }

            .mydatagrid th {
                padding: 5px;
            }

        .header {
            background-color: #1b93e1;
            font-family: 'Roboto', sans-serif;
            color: White;
            border: none 0px transparent;
            height: 30px;
            text-align: center;
            font-size: 16px;
        }

        td, th {
            padding: 5px 5px;
        }
    </style>


    <script src="../js/jquery-1.10.2.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="index.html">Home</a> <i class="fa fa-angle-right"></i></li>
    </ol>

    <div class="grid-form">
        <div class="grid-form1">
            <h4 class="breadcrumb-item"><a>Repurchase Product Date Wise</a></h4>

            <div class="panel-body panel-footer">
                <div class="row" style="padding: 0px 0px 0px 0px;">
                    <div style="margin: 0px auto; padding: 0px; width: 100%; height: auto;">
                        <div style="margin: 0px; padding: 0px; width: 100%; height: auto; float: left;">
                            <table border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #a7a43f; margin: 25px auto 0px auto; padding: 0px; width: 401px; height: 136px; background-color: White;">

                                <tr>
                                    <td style="text-align: right; padding: 5px 10px 0px 0px; font-family: ebrima; font-size: 15px;">From :
                                    </td>
                                    <td style="padding: 5px 0px 0px 0px; text-align: left;">
                                        <asp:DropDownList ID="ddl_s_date" runat="server" CssClass="form-control" Style="color: Green; width: 75px; font-weight: bold; float: left;">
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
                                        &nbsp;
                            <asp:DropDownList ID="ddl_s_month" runat="server" CssClass="form-control" Style="float: left; color: Green; width: 75px; font-weight: bold;">
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
                                        &nbsp;
                            <asp:DropDownList ID="ddl_s_year" runat="server" CssClass="form-control" Style="color: Green; float: left; width: 100px; font-weight: bold;">
                            </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right; padding: 5px 10px 0px 0px; font-family: ebrima; font-size: 15px;">To :
                                    </td>
                                    <td style="padding: 5px 0px 0px 0px; text-align: left;">
                                        <asp:DropDownList ID="ddl_e_date" runat="server" CssClass="form-control" Style="color: Green; float: left; width: 75px; font-weight: bold;">
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
                                        &nbsp;
                            <asp:DropDownList ID="ddl_e_month" runat="server" CssClass="form-control" Style="color: Green; float: left; width: 75px; font-weight: bold;">
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
                                        &nbsp;
                            <asp:DropDownList ID="ddl_e_year" runat="server" CssClass="form-control" Style="color: Green; float: left; width: 100px; font-weight: bold;">
                            </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center; padding: 5px 0px 0px 0px;" colspan="2">
                                        <asp:Button ID="btn_find" CssClass="btn btn-success" runat="server" Text="Find" OnClick="btn_find_Click" Height="30px"
                                            Width="100px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center; padding: 5px 0px 0px 0px;" colspan="2">
                                        <asp:Label ID="lbl_message" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="Red"
                                            Font-Names="Bell MT"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <script type="text/javascript">
                            function PrintPanel() {
                                var panel = document.getElementById("<%=tblPrintIQ.ClientID %>");
                                var printWindow = window.open('', '', 'height=400,width=800');
                                printWindow.document.write('<html><head>');
                                printWindow.document.write('</head><body>');
                                printWindow.document.write('');
                                printWindow.document.write(panel.innerHTML);
                                printWindow.document.write('</body ></html>');
                                printWindow.document.close();
                                setTimeout(function () {
                                    printWindow.print();
                                }, 500);
                                return false;
                            }
                        </script>
                        <div id="tblPrintIQ" runat="server">
                            <asp:Panel ID="panel_view" runat="server" Visible="false">
                                <div style="margin: 0px; padding: 0px; width: 100%; height: auto; float: left; position: relative">
                                    <asp:LinkButton ID="print1" OnClientClick="return PrintPanel()" runat="server" ToolTip="Print" CssClass="form-btn"><img src="images/printer.png" style="position:absolute; right: 1px; top: -15px;" height="25" width="25" border="0" /></asp:LinkButton>
                                    <%--<asp:LinkButton ID="print1" OnClientClick="printTable();" runat="server"> 
                                    <img src="images/printer.png" style="position:absolute; right: 1px; top: -15px;" height="25" width="25" border="0" /></asp:LinkButton>--%>
                                    <div style="margin: 15px 0px 10px 0px; padding: 0px; float: left; width: 100%; height: auto;">
                                        <div style="margin: 0px 0px 0px 0px; padding: 0px 0px 0px 0px; float: left; width: 100%; height: auto;">
                                            <asp:GridView ID="gridview" runat="server" Style="margin: 0px auto; width: 100%; font: normal 13px ebrima; height: auto;"
                                                CssClass="mydatagrid" PagerStyle-CssClass="pager"
                                                HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AutoGenerateColumns="False">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <a href="#" onclick='openWindow("<%# DataBinder.Eval(Container.DataItem,"Stock_code")+"&Billno="+DataBinder.Eval(Container.DataItem,"Billno")+"&Membercode="+DataBinder.Eval(Container.DataItem,"Membercode")%>")'>
                                                                <asp:Label ID="lbl_Referalcode" class="btn btn-primary btn-sm" runat="server" Text="View Details"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <a href="#" onclick='open_Window("<%# DataBinder.Eval(Container.DataItem,"Billno")+"&mem_code="+DataBinder.Eval(Container.DataItem,"Membercode")%>")'>
                                                                <asp:Label ID="lblslip" class="btn btn-primary btn-sm" runat="server" Text="Print Slip"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Bill No">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Billno" runat="server" Text='<%#Bind("Billno") %>'></asp:Label>
                                                            <asp:Label ID="lbl_Stockpoint_code" runat="server" Text='<%#Bind("Stock_code") %>' Visible="false"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Total Price">

                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Total_price" runat="server" Text='<%#Bind("Total_mrp") %>'></asp:Label>
                                                        </ItemTemplate>

                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Total BV">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_BV" runat="server" Text='<%#Bind("TotalBV") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_date" runat="server" Text='<%#Bind("Date") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>



                                                </Columns>
                                                <HeaderStyle BackColor="#00A4CC" />
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function openWindow(code) {
            window.open('popup_buy_repurchase_history.aspx?Stockpoint_code=' + code, 'open_window', ' width=1100, height=480, left=0, top=0');
        }
        function open_Window(code) {
            window.open('Print_bill_GN.aspx?billno=' + code, 'open_window', ' width=1100, height=480, left=0, top=0');
        }
    </script>
</asp:Content>
