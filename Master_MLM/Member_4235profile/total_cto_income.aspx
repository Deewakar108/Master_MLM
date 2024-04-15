<%@ Page Title="Total CTO Income" Language="C#" MasterPageFile="~/Member_4235profile/Member_main.Master" AutoEventWireup="true" 
    CodeBehind="total_cto_income.aspx.cs" Inherits="Master_MLM.Member_4235profile.total_cto_income" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/mygrid.css" rel="stylesheet" />
    <style type="text/css">
        .ddsmoothmenu ul li a.fourth {
            color: #ffffff;
            background: #0597D5;
            background: url( 'menu.png' ) repeat left top #007AC5;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="#">Home</a> <i class="fa fa-angle-right"></i><a href="#">Total CTO Income</a></li>
    </ol>


    <div class="grid-form">
        <div class="grid-form1">
            <h4 class="breadcrumb-item"><a>Total CTO Income</a></h4>
            <div class="panel-body panel-footer">
                <div style="margin: 0px 0px 10px 0px; padding: 0px; float: left; width: 100%; height: auto;">
                    <div style="margin: 0px 0px 0px 0px; padding: 0px 0px 0px 0px; float: left; width: 100%; height: auto;">
                        <asp:Panel ID="pnl_view" runat="server"  Style="margin: 0px auto; padding: 10px; height: auto;"
                            Width="1032px">

                            <div class="row">
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
                                <div id="tblPrintIQ" style="margin: 0px 0px 0px 0px; padding: 0px; float: left; width: 100%; height: auto; background-color: White;"
                                    class="round">
                                    <asp:GridView ID="grd_left" runat="server" Style="margin: 0px auto; font: normal 13px ebrima; height: auto; text-align: center; width: 100%;"
                                        AutoGenerateColumns="False" AllowSorting="True" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                                        HeaderStyle-CssClass="header" RowStyle-CssClass="rows" ShowHeaderWhenEmpty="true"
                                         OnRowDataBound="grd_left_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_sl" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Member Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMemberName" runat="server" Text='<%#Bind("MemberName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Member Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMember_code" runat="server" Text='<%#Bind("Member_code") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total">
                                                <ItemTemplate>
                                                    <i class="fa fa-inr">&nbsp;<asp:Label ID="lblTotalamount" runat="server" Text='<%#Bind("Totalamount", "{0:N2}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="TDS" SortExpression="idate">
                                                <ItemTemplate>
                                                    <i class="fa fa-inr">&nbsp;<asp:Label ID="lblTDS" runat="server" Text='<%#Bind("TDS", "{0:N2}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Admin Charge">
                                                <ItemTemplate>
                                                    <i class="fa fa-inr">&nbsp;<asp:Label ID="lblServicecharge" runat="server" Text='<%#Bind("Servicecharge", "{0:N2}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Gross">
                                                <ItemTemplate>
                                                    <i class="fa fa-inr">&nbsp;</i><asp:Label ID="lblFinal_amount" runat="server" Text='<%#Bind("Final_amount", "{0:N2}") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Paid Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPaid_date" runat="server" Text='<%#Bind("Paid_date") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Amount">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAmount" runat="server" Text='<%#Bind("Status") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnPay" Visible="false" CssClass="btn btn-primary btn-sm" runat="server" Text="Pay Now" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle BackColor="#333333" ForeColor="White" Font-Size="13px" />
                                    </asp:GridView>
                                </div>

                            </div>

                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>          <!--Left-->

</asp:Content>
