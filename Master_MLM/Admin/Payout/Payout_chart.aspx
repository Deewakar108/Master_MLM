<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="Payout_chart.aspx.cs" Inherits="Master_MLM.Admin_87554b.Payout_chart"
    Title="Payout Chart" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Payout Chart
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .ddsmoothmenu ul li a.seventh {
            background-image: url( '../../images/bg2.png' );
            background-repeat: repeat-x;
            color: #333333;
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
    <script type="text/javascript">
        function openWindow(code) {

            window.open('Incomedetasils.aspx?mcode=' + code, 'open_window', ' width=1000, height=480, left=150, top=100');
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="content">

        <div id="content-header">
            <div id="breadcrumb">
                <a href="/" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">Payout</a>
                <a href="#" class="current">Payout Chart</a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <span class="icon-right"><i class="icon-print" onclick="$('#<%= print1.ClientID %>').click();"></i></span>
                        <span class="icon-right"><i class="icon-save" onclick="$('#<%= img_expord.ClientID %>').click();"></i></span>
                        <h5>Payout Chart</h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid">
                            <div class="span12" style="text-align: center;">
                                Start Date :
                                <asp:DropDownList ID="ddl_s_date" runat="server" CssClass="span2" AutoPostBack="True" OnSelectedIndexChanged="ddl_s_date_SelectedIndexChanged">
                                </asp:DropDownList>
                                &nbsp;&nbsp;
                                End Date :
                                <asp:DropDownList ID="ddl_e_date" runat="server" CssClass="span2">
                                </asp:DropDownList>
                                &nbsp;&nbsp;
                                <asp:Button ID="btn_find" runat="server" style="margin-bottom: 10px;" OnClick="btn_find_Click" Text="Find" CssClass="btn btn-primary" />
                            </div>
                            <br />
                            <br />
                        </div>
                        <div style="display: none;">
                            <asp:LinkButton ID="print1" OnClientClick="printTable();" runat="server">
                                    <img src="../images/printer.png" height="25" width="25" border="0" alt=" " /></asp:LinkButton>
                            <asp:ImageButton ID="img_expord" runat="server" Height="32px" ImageUrl="~/images/Excelicons.png"
                                Style="margin-left: 0px; float: right;" OnClick="img_expord_Click" />
                        </div>
                        <asp:Panel ID="pnl_view" Visible="false" runat="server">
                            <div class="row-fluid" id="tblPrintIQ">
                                <asp:GridView ID="grd_payout_list" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered data-table dataTable">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr No.">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSRNO" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Member code">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Member_code" runat="server" Font-Names="Arial" Text='<%#Bind("Membercode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Name" runat="server" Font-Names="Arial" Text='<%#Bind("Membername") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Bank name">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_bank_name" runat="server" Font-Names="Arial" Text='<%#Bind("Bank_name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Branch name">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Branch_name" runat="server" Font-Names="Arial" Text='<%#Bind("Branch_name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Account no.">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Account_number" runat="server" Font-Names="Arial" Text='<%#Bind("Account_number") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ifsc code">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Ifsc_code" runat="server" Font-Names="Arial" Text='<%#Bind("Ifsc_code") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_totamount" runat="server" Font-Names="Arial" Text='<%#Bind("Totalamount", "{0:N2}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Tds">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Tds" runat="server" Font-Names="Arial" Text='<%#Bind("Tds", "{0:N2}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Cds">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Cds" runat="server" Font-Names="Arial" Text='<%#Bind("Cds", "{0:N2}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Processing charge" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Processingcharge" runat="server" Font-Names="Arial" Text='<%#Bind("Processingcharge", "{0:N2}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Net Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Netmount" runat="server" Font-Names="Arial" Text='<%#Bind("Netmount", "{0:N2}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Carryout" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Carryout" runat="server" Font-Names="Arial" Text='<%#Bind("Carryout", "{0:N2}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Pin Amount" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Pinamount" runat="server" Font-Names="Arial" Text='<%#Bind("Pinamount", "{0:N2}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Spl Payout" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_SplPayout" runat="server" Font-Names="Arial" Text='<%#Bind("SpecialPayOut", "{0:N2}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Grand Total">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Grand_total" runat="server" Font-Names="Arial" Text='<%#Bind("Grand_total", "{0:N2}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_date" runat="server" Font-Names="Arial" Text='<%#Bind("Date") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_status" runat="server" Font-Names="Arial" Text='<%#Bind("Status") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <a href="#" class="btn btn-info btn-xs" onclick="openWindow('<%#Eval("Membercode")+"&startdate="+Eval("Startdate")+"&enddate="+Eval("Enddate") %>');">View </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>

                                <div class="span12">
                                    Total Amount :
                                    <asp:Label ID="lbl_total_paout" runat="server" Text="" CssClass="label label-warning"></asp:Label>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>








    <div id="notification">
        <div id="pan" class="notificationpan">
            <div style="float: left; width: auto; height: auto;">
                <asp:Label ID="lbl_message" runat="server" Style="padding: 10px 20px 0px 10px; font-size: 17px; color: #ffffff; font-weight: bold;"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
