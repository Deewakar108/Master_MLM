<%@ Page Title="Member Payment Report" Language="C#" MasterPageFile="~/Member_4235profile/Member_main.Master" AutoEventWireup="true" CodeBehind="Member_payment_report.aspx.cs" Inherits="Master_MLM.Member_4235profile.Member_payment_report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .ddsmoothmenu ul li a.seventh {
            color: rgb(255, 255, 255);
            background: #5723A2;
            text-shadow: none;
            box-shadow: none;
            border-right: 1px solid #446CB3;
            cursor: pointer;
        }
    </style>
    <style type="text/css">
        @media print {
            .noPrint
            {
                display: none;
            }

        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ol class="breadcrumb"><li class="breadcrumb-item"><a href="index.html">Home</a> <i class="fa fa-angle-right"></i></li></ol>
      <div class="grid-form">
        <div class="grid-form1">
            <h4 class="breadcrumb-item"><a>Payment Status</a><span style="float:right;"><asp:LinkButton ID="print1" OnClientClick="printTable();" runat="server">
                                    <img src="../images/printer.png" height="25" width="25" border="0"  /></asp:LinkButton>
                                    <asp:ImageButton ID="img_export" runat="server" Height="32px" ImageUrl="~/images/Excelicons.png"
                                        Style="margin-left: 20px" OnClick="img_export_Click" /></span></h4>
            <div class="panel-body panel-footer">
                       <div class="row" style="padding: 20px 0px 20px 0px;">
        <div class="block">
            <div class="block1">

               

                <asp:Panel ID="pnl_view" Visible="false" runat="server">
                    <table id="tblPrintIQ" cellspacing="0" cellpadding="0" border="0" style="margin: 25px auto 0px auto; border: 1px solid #666666; width: 1236px; height: auto;"
                        class="round shadow">
                        
                        <tr>
                            <td>
                                <asp:GridView ID="grd_payout_list" runat="server" AutoGenerateColumns="False" BackColor="White"
                                    BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" Style="text-align: center; font-family: arial, Helvetica, sans-serif; font-size: 10px; height: auto; width: 100%; margin-top: 4px; margin-bottom: 16px; margin-right: 0px;">
                                    <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
                                    <RowStyle BackColor="White" Font-Size="10pt" ForeColor="#330099" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr No.">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSRNO" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Member code" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Member_code" runat="server" Font-Names="Arial" Text='<%#bind("Membercode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Name" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Name" runat="server" Font-Names="Arial" Text='<%#bind("Membername") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Bank name">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_bank_name" runat="server" Font-Names="Arial" Text='<%#bind("Bankname") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Branch name">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Branch_name" runat="server" Font-Names="Arial" Text='<%#bind("Branchname") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Account no.">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Account_number" runat="server" Font-Names="Arial" Text='<%#bind("Accountno") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ifsc code">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Ifsc_code" runat="server" Font-Names="Arial" Text='<%#bind("Ifsccode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_payout" runat="server" Font-Names="Arial" Text='<%#bind("Amount") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_date" runat="server" Font-Names="Arial" Text='<%#bind("date") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_status" runat="server" Font-Names="Arial" Text='<%#bind("status") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#FFFFCC" BorderStyle="Solid" ForeColor="#330099" />
                                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
                                    <HeaderStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True"
                                        Font-Size="8pt" ForeColor="#FFFFCC" Height="40px" CssClass="blue_bg" BackColor="#990000" />

                                </asp:GridView>
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
    <div id="notification">
        <div id="pan" class="notificationpan">
            <div style="float: left; width: auto; height: auto;">
                <asp:Label ID="lbl_message" runat="server" Style="padding: 10px 20px 0px 10px; font-size: 17px; color: #ffffff; font-weight: bold;"></asp:Label>
            </div>
        </div>
    </div>
            </div>
        </div>
    </div>
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
