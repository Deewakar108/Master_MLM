<%@ Page Title="Repurchase Business
"
    Language="C#" MasterPageFile="~/Member_4235profile/Member_main.Master" AutoEventWireup="true" CodeBehind="repurchase_business_bv_point_left_right_self.aspx.cs" Inherits="Master_MLM.Member_4235profile.repurchase_business_bv_point_left_right_self" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="index.html">Home</a> <i class="fa fa-angle-right"></i></li>
    </ol>

    <div class="grid-form">
        <div class="grid-form1">
            <h4 class="breadcrumb-item"><a>Repurchase Business</a></h4>

            <div class="panel-body panel-footer">
                <div class="row" style="padding: 0px 0px 0px 0px;">
                    <div style="margin: 0px auto; padding: 0px; width: 100%; height: auto;">
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
                            <asp:Panel ID="panel_view" runat="server">
                                <div style="margin: 0px; padding: 0px; width: 100%; height: auto; float: left; position: relative">
                                    <asp:LinkButton ID="print1" OnClientClick="return PrintPanel()" runat="server" ToolTip="Print" CssClass="form-btn"><img src="images/printer.png" style="position:absolute; right: 1px; top: -15px;" height="25" width="25" border="0" /></asp:LinkButton>

                                    <div style="margin: 15px 0px 10px 0px; padding: 0px; float: left; width: 100%; height: auto;">

                                        <asp:GridView ID="gridview" runat="server" Style="margin: 0px auto; width: 100%; font: normal 13px ebrima; height: auto;"
                                            CssClass="mydatagrid" PagerStyle-CssClass="pager"
                                            HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AutoGenerateColumns="False">
                                            <Columns>
                                                  <asp:TemplateField HeaderText="Month">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Month" runat="server" Text='<%#Bind("Month") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Self BV">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_self" runat="server" Text='<%#Bind("Self_BV") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Left BV">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_leftbv" runat="server" Text='<%#Bind("Left_PV") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Right BV">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_rightbv" runat="server" Text='<%#Bind("Right_PV") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle BackColor="#00A4CC" />
                                        </asp:GridView>

                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
