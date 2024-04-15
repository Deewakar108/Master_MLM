<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="Member_pin_transfer_report.aspx.cs" Inherits="Master_MLM.Admin.Member_pin_transfer_report"
    Title="Member Pin Transfer list" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Member Pin Transfer list
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="../css/custom.css" rel="stylesheet" />
    <style type="text/css">
        .ddsmoothmenu ul li a.second {
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

    <div id="content">
        <div id="content-header">
            <div id="breadcrumb">
                <a href="/" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">E-Pin</a>
                <a href="#" class="current">Member E-Pin Transfer List</a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Member E-Pin Transfer List</h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid" style="text-align: center;">
                            <div class="span12">
                                <span>
                                    <asp:RadioButton ID="rb_month" GroupName="g1" runat="server" AutoPostBack="True"
                                        OnCheckedChanged="rb_month_CheckedChanged" />&nbsp;Monthly</span>

                                <span style="padding: 0 10px 0 10px;">
                                    <asp:RadioButton ID="rb_yearly" GroupName="g1" runat="server" AutoPostBack="True"
                                        OnCheckedChanged="rb_yearly_CheckedChanged" />&nbsp;Yearly</span>
                            </div>
                        </div>
                        <div class="row-fluid" style="text-align: center;">
                            <div class="span12">
                                &nbsp;<asp:DropDownList ID="ddl_month" runat="server">
                                    <asp:ListItem>01</asp:ListItem>
                                    <asp:ListItem>02</asp:ListItem>
                                    <asp:ListItem>03</asp:ListItem>
                                    <asp:ListItem>04</asp:ListItem>
                                    <asp:ListItem>05</asp:ListItem>
                                    <asp:ListItem>06</asp:ListItem>
                                    <asp:ListItem>07</asp:ListItem>
                                    <asp:ListItem>08</asp:ListItem>
                                    <asp:ListItem>09</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                    <asp:ListItem>11</asp:ListItem>
                                    <asp:ListItem>12</asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;<asp:DropDownList ID="ddl_year" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="row-fluid" style="text-align: center;">
                            <asp:Button ID="Button1" runat="server" Text="Find" OnClick="btn_find_Click" CssClass="btn btn-primary" />
                            <br />
                            <br />
                            <asp:Label ID="lbl_message" runat="server" CssClass="label label-warning"></asp:Label>
                        </div>

                        <asp:Panel ID="pnl_view" runat="server" Visible="false">
                        <div class="row-fluid">
                            <div class="widget-box">
                                <div class="widget-title bg_lg">
                                    <span class="icon"><i class="icon-signal"></i></span>
                                    <span class="icon-right"><i class="icon-save" onclick="$('#<%=img_expord.ClientID %>').click();"></i></span>
                                    <h5>Member Pin Transfer Summary</h5>
                                </div>
                                <div class="widget-content">
                                    <div style="display: none;">
                                        <asp:ImageButton ID="img_expord" runat="server" Height="32px" ImageUrl="~/images/Excelicons.png"
                                        Style="margin-left: 0px; float: right; margin-right: 12px;" OnClick="img_expord_Click" />
                                    </div>
                                    <div class="row-fluid">
                                        <asp:GridView ID="grd_epin" runat="server" CssClass="table table-bordered data-table dataTable"
                                             AutoGenerateColumns="False">
                                        <PagerStyle CssClass="pagination-sks" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Serial No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSRNO" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Member Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_member_code" runat="server" Text='<%#Bind("Membercode") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Member Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Centre_name" runat="server" Text='<%#Bind("Membername") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Participate Id">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_used_to" runat="server" Text='<%#Bind("Transfer_to") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Participate Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_transferto_name" runat="server" Text='<%#Bind("Transferto_name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Transfer Pin Qty">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_total_transfer_pin" runat="server" Text='<%#Bind("Total_pin") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:TemplateField HeaderText="id" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_id" runat="server" Text='<%#Bind("ID") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                        </Columns>
                                    </asp:GridView>
                                    </div>
                                    <div class="row-fluid">
                                        <asp:Label ID="lbl_msg" runat="server" CssClass="label label-warning"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                            </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
