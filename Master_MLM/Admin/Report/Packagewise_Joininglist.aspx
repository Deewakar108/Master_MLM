<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Packagewise_Joininglist.aspx.cs"
    Inherits="Master_MLM.Admin.Packagewise_Joininglist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Package Wise Joining list
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
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
                <a href="#" class="current">Package Wise Total Joining</a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <span class="icon-right"><i class="icon-print" onclick="$('#<%= print1.ClientID %>').click();"></i></span>
                        <span class="icon-right"><i class="icon-save" onclick="$('#<%= print1.ClientID %>').click();"></i></span>
                        <h5>Package Wise Total Joining</h5>
                    </div>
                    <div class="widget-content">
                        <div style="display: none;">
                            <asp:LinkButton ID="print1" OnClientClick="printTable();" runat="server">
                                    <img src="../images/printer.png" height="25" width="25" border="0" alt=" " /></asp:LinkButton>
                            <asp:ImageButton ID="img_expord" runat="server" Height="32px" ImageUrl="~/images/Excelicons.png"
                                Style="margin-left: 0px; float: right;" OnClick="img_expord_Click" />
                        </div>
                        <div class="row-fluid">
                            <div class="span12" style="text-align: center;">
                                Package :
                                <asp:DropDownList ID="ddl_package" runat="server" CssClass="span2"></asp:DropDownList>
                                <asp:Button ID="btn_find" style="margin-bottom: 10px;" runat="server" Text="Find" CssClass="btn btn-primary" OnClick="btn_Submit_Click" />
                            </div>
                            <div class="span12" style="text-align: center;">
                                <asp:Label ID="lbl_message" runat="server" CssClass="label label-warning"></asp:Label>
                            </div>
                        </div>
                        <asp:Panel ID="pnl_view" Visible="false" runat="server">
                            <div class="row-fluid" id="tblPrintIQ">
                                <asp:GridView ID="grd_view" runat="server" CssClass="table table-bordered data-table dataTable"
                                    AutoGenerateColumns="false" AllowPaging="True" PageSize="50"
                                    OnPageIndexChanging="grd_view_PageIndexChanging">
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
                                        <asp:TemplateField HeaderText="Purchase Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_date" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                                                &nbsp;&nbsp;
                                            <asp:Label ID="lbl_Joiningtime" runat="server" Text='<%# Bind("Joiningtime") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Package">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_joining_package" runat="server" Text='<%# Bind("joining_package") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Verification Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Verification_date" runat="server" Text='<%# Bind("Verification_date") %>'></asp:Label>
                                                &nbsp;&nbsp;
                                              <asp:Label ID="lbl_Verification_time" runat="server" Text='<%# Bind("Verification_time") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_id" runat="server" Text='<%#Bind("Id") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
