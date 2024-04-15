<%@ Page Title="Closing Pair Report" Language="C#" MasterPageFile="~/Member_4235profile/Member_main.Master" AutoEventWireup="true" CodeBehind="closing_pair_report.aspx.cs" Inherits="Master_MLM.Member_4235profile.closing_pair_report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/mygrid.css" rel="stylesheet" />
    <style type="text/css">
        .ddsmoothmenu ul li a.fourth {
            color: #ffffff;
            background: #0597D5;
            background: url( 'menu.png' ) repeat left top #007AC5;
        }

        @media only screen and (max-width: 480px) {
            .sks-display {
                display: none;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="#">Home</a> <i class="fa fa-angle-right"></i><a href="#">Binary Carry Forward Report</a></li>
    </ol>


    <div class="grid-form">
        <div class="grid-form1">
            <h4 class="breadcrumb-item"><a>Binary Carry Forward Report</a></h4>
            <div class="panel-body panel-footer">
                <div style="margin: 0px 0px 10px 0px; padding: 0px; float: left; width: 100%; height: auto;">
                    <div style="margin: 0px 0px 0px 0px; padding: 0px 0px 0px 0px; float: left; width: 100%; height: auto;">
                        <asp:Panel ID="pnl_view" runat="server" ScrollBars="Both" Style="margin: 0px auto; padding: 10px; height: auto; overflow: scroll;">

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
                                    <asp:GridView ID="grd_view" runat="server" Style="margin: 0px auto; font: normal 13px ebrima; height: auto; text-align: center; width: 100%;"
                                        AutoGenerateColumns="False" AllowSorting="True" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                                        HeaderStyle-CssClass="header" RowStyle-CssClass="rows" ShowHeaderWhenEmpty="true">
                                        <EmptyDataTemplate>
                                            <p>No Data Found.</p>
                                        </EmptyDataTemplate>
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSRNO" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--  <asp:TemplateField HeaderText="Member code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Member_code" runat="server" Font-Names="Arial" Text='<%#bind("Member_code") %>'
                                                        CssClass="sp_style"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Member Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Member_name" runat="server" Font-Names="Arial" Text='<%#bind("Member_name") %>'
                                                        CssClass="sp_style"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Closing No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Closing_no" runat="server" Font-Names="Arial" Text='<%#bind("Closing_no") %>'
                                                        CssClass="sp_style"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>




                                            <asp:TemplateField HeaderText="Previour Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_date" runat="server" Font-Names="Arial" Text='<%#bind("pre_left") %>'
                                                        CssClass="sp_style"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Previous Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_enddate" runat="server" Font-Names="Arial" Text='<%#bind("pre_right") %>'
                                                        CssClass="sp_style"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Carry Forward Left">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_closingdate" runat="server" Font-Names="Arial" Text='<%#bind("Current_left") %>'
                                                        CssClass="sp_style"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Carry Forward Right">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_joiningdate" runat="server" Font-Names="Arial" Text='<%#bind("Current_right") %>'
                                                        CssClass="sp_style"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Pair">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Pair" runat="server" Font-Names="Arial" Text='<%#bind("Pair") %>'
                                                        CssClass="sp_style"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Lapse Pair">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_lapsepair" runat="server" Font-Names="Arial" Text='<%#bind("Lapsepair") %>'
                                                        CssClass="sp_style"></asp:Label>
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
    </div>

</asp:Content>
