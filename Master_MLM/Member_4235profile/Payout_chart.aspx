<%@ Page Language="C#" MasterPageFile="~/Member_4235profile/Member_main.Master" AutoEventWireup="true"
    CodeBehind="Payout_chart.aspx.cs" Inherits="Master_MLM.Member_4235profile.Payout_chart"
    Title="Payout Chart" EnableEventValidation="false" %>


<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="css/mygrid.css" rel="stylesheet" />
    <style type="text/css">
        .ddsmoothmenu ul li a.seventh {
            background-image: url( '../../images/bg2.png' );
            background-repeat: repeat-x;
            color: #333333;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="#">Home</a> <i class="fa fa-angle-right"></i><a href="#">Payment Status</a></li>
    </ol>



    <div class="grid-form">
        <div class="grid-form1">
            <h4 class="breadcrumb-item"><a>Payment Status</a></h4>
            <div class="panel-body panel-footer ovrflow-div">
                <div class="row" style="padding: 3px 0px 0px 0px;">
                    <div class="col-lg-12">
                        <asp:GridView ID="grd_payout_list" runat="server" AutoGenerateColumns="False" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                            HeaderStyle-CssClass="header" RowStyle-CssClass="rows" ShowHeaderWhenEmpty="true">
                            <EmptyDataTemplate>
                                <div style="text-align: center;">
                                    No Record Found.
                                </div>
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField HeaderText="Sr No.">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSRNO" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Start Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStartdate" runat="server" Font-Names="Arial" Text='<%#Bind("Startdate") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="End Date code">
                                    <ItemTemplate>
                                        <asp:Label ID="lblEnddate" runat="server" Font-Names="Arial" Text='<%#Bind("Enddate") %>'></asp:Label>
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
                                <asp:TemplateField HeaderText="Bank name" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_bank_name" runat="server" Font-Names="Arial" Text='<%#Bind("Bank_name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Branch name" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Branch_name" runat="server" Font-Names="Arial" Text='<%#Bind("Branch_name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Account no." Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Account_number" runat="server" Font-Names="Arial" Text='<%#Bind("Account_number") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ifsc code" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Ifsc_code" runat="server" Font-Names="Arial" Text='<%#Bind("Ifsc_code") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total Amount">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_totamount" runat="server" Font-Names="Arial" Text='<%#Bind("Totalamount") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tds">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Tds" runat="server" Font-Names="Arial" Text='<%#Bind("Tds") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cds">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Cds" runat="server" Font-Names="Arial" Text='<%#Bind("Cds") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Processing charge" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Processingcharge" runat="server" Font-Names="Arial" Text='<%#Bind("Processingcharge") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Net Amount">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Netmount" runat="server" Font-Names="Arial" Text='<%#Bind("Netmount") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Carryout" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Carryout" runat="server" Font-Names="Arial" Text='<%#Bind("Carryout") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pin Amount" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Pinamount" runat="server" Font-Names="Arial" Text='<%#Bind("Pinamount") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Spl Payout" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_SplPayout" runat="server" Font-Names="Arial" Text='<%#Bind("SpecialPayOut") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Grand Total">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Grand_total" runat="server" Font-Names="Arial" Text='<%#Bind("Grand_total") %>'></asp:Label>
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
                                        <a href="#" class="btn btn-info btn-sm" style="background-color: #1b93e1;" onclick="openWindow('<%#Eval("Membercode")+"&startdate="+Eval("Startdate")+"&enddate="+Eval("Enddate") %>');">View </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div style="margin: 0px auto 0px auto; padding: 30px 0px 30px 0px; height: auto; display: none;">
                        <div style="margin: 0px; padding: 0px; width: 100%; height: auto;">
                            <div style="margin: 0px 0px 10px 0px; padding: 0px; float: left; width: 100%; height: auto; background-color: white;">
                                <div style="margin: 0px; padding: 0px; width: 100%">
                                    <asp:Panel ID="pnl_view" Visible="false" runat="server">
                                        <table id="tblPrintIQ" cellspacing="0" cellpadding="0" border="0" style="margin: 25px auto 10px auto; border: 1px solid #666666; width: 1236px; height: auto;"
                                            class="round shadow">
                                            <tr>
                                                <td class="blue_bg" height="25" style="padding: 10px 0px 10px 30px; text-align: left; color: #FFFFFF; font-family: arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #CCCCCC;">
                                                    <h2 style="text-align: center; width: 88%; margin: 0px; float: left; text-align: left;">Payout Report
                                                    </h2>
                                                    <h2 style="text-align: center; width: 10%; margin: 0px; float: left; text-align: left;"
                                                        class="noPrint">
                                                        <asp:LinkButton ID="print1" OnClientClick="printTable();" runat="server">
                                    <img src="../images/printer.png" height="25" width="25" border="0" alt=" " /></asp:LinkButton>
                                                        <asp:ImageButton ID="img_expord" runat="server" Height="32px" ImageUrl="~/images/Excelicons.png"
                                                            Style="margin-left: 0px; float: right;" OnClick="img_expord_Click" />
                                                    </h2>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>

                                                    <script type="text/javascript">
                                                        function openWindow(code) {

                                                            window.open('../Admin/Payout/Incomedetasils.aspx?mcode=' + code, 'open_window', ' width=1000, height=480, left=150, top=100');
                                                        }
                                                    </script>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 0px 20px 0px 20px; text-align: right; margin: 0px;">Total Amount :-
                                <asp:Label ID="lbl_total_paout" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding: 0px 20px 0px 250px; text-align: right; margin: 0px;">&nbsp;
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

    <div class="row">
        <div class="block">
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
            <div class="block1">
            </div>
        </div>


    </div>
    <div id="notification">
        <div id="pan" class="notificationpan">
            <div style="float: left; width: auto; height: auto;">
                <asp:Label ID="lbl_message" runat="server" Style="padding: 10px 20px 0px 10px; font-size: 17px; color: #ffffff; font-weight: bold;"></asp:Label>
            </div>
            <%--<img src="../images/close.png" onclick="$(function () { $('.notificationpan').show().slideUp(1000);});"
                        class="closenotificationpan" />--%>
        </div>
    </div>
</asp:Content>
