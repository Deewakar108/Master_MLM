<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="show_member_password.aspx.cs" Inherits="Master_MLM.Admin.show_member_password"
    Title="Member Password list" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Member Password list
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .ddsmoothmenu ul li a.fifteen {
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
    <div id="content">

        <div id="content-header">
            <div id="breadcrumb">
                <a href="/" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">Setting</a>
                <a href="#" class="current">Member Password List</a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <span class="icon-right"><i class="icon-print" onclick="$('#<%= print1.ClientID %>').click()"></i></span>
                        <span class="icon-right"><i class="icon-save" onclick="$('#<%= img_expord.ClientID %>').click()"></i></span>
                        <h5>Member Password List</h5>
                    </div>
                    <div class="widget-content">
                        <div class="span12" style="text-align: center;">
                            <asp:Label ID="lbl_message" runat="server" CssClass="label label-warning"></asp:Label>
                            <div style="display: none;">
                                <asp:LinkButton ID="print1" OnClientClick="printTable();" runat="server">
                                    <img src="../images/printer.png" height="25" width="25" border="0" alt=" " /></asp:LinkButton>
                                <asp:ImageButton ID="img_expord" runat="server" Height="32px" ImageUrl="~/images/Excelicons.png"
                                    Style="margin-left: 0px; float: right;" OnClick="img_expord_Click" />
                            </div>
                        </div>
                        <div class="span12" style="text-align: center;">
                            <asp:TextBox ID="txt_memberid" runat="server" placeholder="Member Code" ></asp:TextBox>                            
                            <asp:Button ID="btn_find" runat="server" style="margin-bottom: 10px;" Text="Find" OnClick="btn_find_Click" CssClass="btn btn-primary" />
                        </div>
                        <asp:Panel ID="pnl_view" runat="server" Visible="False" Style="margin: 0px;">
                            <div class="row-fluid" id="tblPrintIQ">
                                <asp:GridView ID="grd_view" runat="server" CssClass="table table-bordered data-table dataTable"
                                    AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True"
                                    OnPageIndexChanging="grd_view_PageIndexChanging">

                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr No.">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSRNO" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Member Code">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_member_code" runat="server" Font-Names="Arial" Text='<%#bind("Member_code") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Member Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_name" runat="server" Font-Names="Arial" Text='<%#bind("Member_name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mobile">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_mobile" runat="server" Font-Names="Arial" Text='<%#bind("Mobile_number") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField HeaderText="Nominee name">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_nominee_name" runat="server" Font-Names="Arial" Text='<%#bind("Nominee_name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Password">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_pwd" runat="server" Font-Names="Arial" Text='<%#bind("Pwd") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Transaction Password">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Transaction_Password" runat="server" Font-Names="Arial" Text='<%#bind("Transaction_Password") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>

                                </asp:GridView>                                
                            </div>
                        </asp:Panel>
                        <div class="row-fluid">
                            <div style="text-align: center;" class="span12">
                                <asp:Label ID="lbl_msg" runat="server" CssClass="label label-warning"></asp:Label>
                            </div>
                        </div>
                        <div class="row-fluid">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
