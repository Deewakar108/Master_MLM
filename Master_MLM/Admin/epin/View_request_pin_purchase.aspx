<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="View_request_pin_purchase.aspx.cs" Inherits="Master_MLM.Admin.View_request_pin_purchase"
    Title="View Request Pin"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    View Request Pin Purchase
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="../css/custom.css" rel="stylesheet" />
    <style type="text/css">
        .ddsmoothmenu ul li a.second
        {
            color: #446CB3;
            background: #fff;
            text-shadow: none;
            box-shadow: none;
            border-right: 1px solid #446CB3;
            cursor: pointer;
        }
        .gridview a
        {
            padding: 5px;
            background-color: #cccccc;
            color: Black;
            margin-right: 3px;
        }
        .block
        {
            margin: 0px 0px 10px 0px;
            padding: 0px;
            float: left;
            width: 100%;
            height: auto;
        }
        .block1
        {
            margin: 0px auto;
            padding: 0px;
            width: 960px;
            height: auto;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div id="content">
        <div id="content-header">
            <div id="breadcrumb">
                <a href="/" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">E-Pin</a>
                <a href="#" class="current">Distribute E-Pin</a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Distribute E-Pin</h5>
                    </div>
                    <div class="widget-content">

                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row" style="padding: 30px 0px 0px 0px;">
        <div class="block">
            <div class="block1">
                <p style="margin: 0px auto; padding: 0px; width: 100%; height: 30px; text-align: center;">
                    <asp:Label ID="lbl_message" runat="server" ForeColor="#CC0000" Font-Bold="True"></asp:Label></p>
                <asp:Panel ID="pnl_reward" Visible="false" runat="server">
                    <table style="width: 950px; height: auto; margin: 10px auto; border-spacing: 0px;
                        background-color: White; background-color: White;" border="0" cellpadding="0"
                        cellspacing="0" class="round shadow">
                        <tr>
                            <td style="border-bottom: 1px solid #CCCCCC; padding: 5px 0px 5px 20px; font-weight: bold;"
                                valign="top" class="blue_bg">
                                Request pin purchase list
                                <asp:ImageButton ID="img_expord" runat="server" Height="32px" ImageUrl="~/images/Excelicons.png"
                                    Style="margin-left: 14px; float: right; margin-right: 12px;" OnClick="img_expord_Click" />
                                <span style="float: right; padding-top: 0px; padding-right: 10px;">
                                    <asp:LinkButton ID="lnk_clearall" runat="server" OnClick="lnk_clearall_Click" Style="color: #ffffff">Clear all</asp:LinkButton></span>
                                <span style="float: right; padding: 0px 10px 0px 0px;">
                                    <asp:LinkButton ID="lnk_checkall" runat="server" OnClick="lnk_checkall_Click" Style="color: #ffffff">Check all</asp:LinkButton></span>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center; padding: 5px 5px 5px 5px;">
                                <asp:GridView ID="grd_view" runat="server" CssClass="table table-bordered data-table dataTable" AutoGenerateColumns="False">
                                    <PagerStyle CssClass="pagination-sks" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Member code">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_membercode" runat="server" Text='<%#Bind("Membercode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Request date">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_request_date" runat="server" Text='<%#Bind("Requestdate") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Bank name">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_bank_name" runat="server" Text='<%#Bind("Bank_name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_amount" runat="server" Text='<%#Bind("Amount") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Transition no.">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_transition_not" runat="server" Text='<%#Bind("Transition_no") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Transition date">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_transition_date" runat="server" Text='<%#Bind("Transition_date") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Package">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Package" runat="server" Text='<%#Bind("Package") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Pin_qty">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_pin_qty" runat="server" Text='<%#Bind("Numberofpin") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_id" runat="server" Text='<%#Bind("ID") %>'></asp:Label>
                                                <asp:Label ID="lbl_Packageid" runat="server" Text='<%#Bind("Packageid") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#00A4CC" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; padding: 10px 25px 10px 5px;">
                                <asp:Label ID="lbl_msg" runat="server" Style="margin: 0px 10px 0px 0px;" ForeColor="Red"></asp:Label>
                                <asp:Button ID="btn_allocate" runat="server" Text="Allocate" OnClick="btn_allocate_Click"
                                    Width="100px" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
