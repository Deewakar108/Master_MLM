<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="kyc_member.aspx.cs" Inherits="Master_MLM.Admin.Members.kyc_member"
    Title="Total Non-KYC Member" ValidateRequest="false" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Total Non-KYC Member
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .ddsmoothmenu ul li a.fifth {
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

        .table th, .table td {
            padding: 8px;
            line-height: 20px;
            text-align: center;
            vertical-align: middle;
            border-top: 1px solid #ddd;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">

        <div id="content-header">
            <div id="breadcrumb">
                <a href="/" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">Members</a>
                <a href="#" class="current">Non-KYC Member</a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Non-KYC Member</h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid">
                            <div class="span12" style="text-align: center;">
                                <asp:Button ID="btn_find" runat="server" Text="All Non-KYC Member" CssClass="btn btn-primary" OnClick="btn_Submit_Click" />
                            </div>
                            <div class="span12" style="text-align: left;">
                                <br />
                                <asp:Label ID="lbl_message" runat="server" CssClass="label label-warning"></asp:Label>
                            </div>
                        </div>
                        <asp:Panel ID="Panel1" runat="server">
                            <div class="row-fluid">
                                <asp:GridView ID="grd_view" runat="server" CssClass="table table-bordered data-table dataTable" ShowHeaderWhenEmpty="true"
                                    AutoGenerateColumns="false" AllowPaging="True" PageSize="500"
                                    OnPageIndexChanging="grd_view_PageIndexChanging" OnRowCommand="grd_view_RowCommand">
                                    <EmptyDataTemplate>
                                        <div style="text-align: center;">
                                            Member does not exist.
                                        </div>
                                    </EmptyDataTemplate>
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


                                        <asp:TemplateField HeaderText="SMS Send" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                            <ItemTemplate>
                                                <asp:Button ID="btnSendSMS" runat="server" CssClass="btn btn-success" Text="Send" CommandArgument='<%# Bind("Member_code") %>' CommandName="IsSend" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SMS Count" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSMSCount" runat="server" CssClass="label label-info" Text='<%# Bind("TotalSMSSend") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                    <HeaderStyle BackColor="#333333" ForeColor="White" Font-Size="13px" />
                                </asp:GridView>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row" style="padding: 30px 0px 20px 0px; display: none;">

        <div id="totaljoining" style="margin: 0px 0px 10px 0px; padding: 0px; float: left; width: 100%; height: auto;">

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

            <asp:Panel ID="pnl_view" Visible="false" runat="server">
                <table id="tblPrintIQ" style="width: 1170px; height: auto; margin: 10px auto; border-spacing: 0px; background-color: White;"
                    border="0" cellpadding="0" cellspacing="0" class="round shadow">
                    <tr>
                        <td style="border-bottom: 1px solid #CCCCCC; padding: 10px 0px 10px 20px; font-weight: bold;"
                            valign="top" class="blue_bg">
                            <h2 style="text-align: center; width: 88%; margin: 0px; float: left; text-align: left;">Total Non-KYC Member
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
                        <td style="text-align: center; padding: 5px 5px 5px 5px;"></td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
