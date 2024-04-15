<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="Used_pin_history.aspx.cs" Inherits="Master_MLM.Admin.Used_pin_history"
    Title="Used Pin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Used Pin
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

        .block {
            margin: 0px;
            padding: 0px 0px 30px 0px;
            width: 100%;
            text-align: center;
            float: left;
        }

        @media print {
            .noPrint {
                display: none;
            }
    </style>

    <script type="text/javascript">
        printDivCSS = new String('<link href="itemprint.css" rel="stylesheet" type="text/css">')
        function printDiv(divId) {
            window.frames["print_frame"].document.body.innerHTML = printDivCSS + document.getElementById(divId).innerHTML
            window.frames["print_frame"].window.focus()
            window.frames["print_frame"].window.print()
        }

    </script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <!--breadcrumbs-->
        <div id="content-header">
            <div id="breadcrumb">
                <a href="/" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">E-Pin</a>
                <a href="#" class="current">Used E-Pin</a>
            </div>
        </div>
        <!--End-breadcrumbs-->

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <span class="icon-right"><i class="icon-print" onclick="printDiv('epin_distributed');"></i></span>
                        <span class="icon-right"><i class="icon-save" onclick="$('#<%=img_expord.ClientID %>').click();"></i></span>
                        <h5>Used E-PIN</h5>
                    </div>
                    <div class="widget-content">

                        <div style="display: none;">
                            <asp:ImageButton ID="img_expord" runat="server" Height="32px" ImageUrl="~/images/Excelicons.png"
                                Style="margin-left: 20px" OnClick="img_expord_Click" />
                        </div>

                        <div class="span12">
                            <asp:Label ID="lbl_message_d" runat="server" CssClass="label label-warning"></asp:Label>
                        </div>
                        <div class="row-fluid" id="epin_distributed">
                            <asp:GridView ID="grd_epin_used" runat="server" CssClass="table table-bordered data-table dataTable"
                                AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="grd_epin_used_PageIndexChanging"
                                PageSize="20">
                                <PagerStyle CssClass="pagination-sks" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr No.">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSRNO" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Member Code">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_membercode" runat="server" Font-Names="Arial" Text='<%#Bind("Membercode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Member Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_membername" runat="server" Font-Names="Arial" Text='<%#Bind("membername") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total Used Pin">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_pin" runat="server" Font-Names="Arial" Text='<%#Bind("Totalallocatedpin") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                        </div>
                        <div class="span12">
                            Total Pin :
                                <asp:Label ID="lbl_total_pin" runat="server" CssClass="label label-warning"></asp:Label>
                        </div>
                        <br />
                        <asp:Panel ID="pnl_member" runat="server" Visible="false">
                            <div class="row-fluid">
                                <div class="span12">
                                    Member Code :
                                    <asp:TextBox ID="txt_member_code" runat="server" placeholder="Member Code"></asp:TextBox>
                                    <asp:Button ID="btn_find" runat="server" Text="Find" CssClass="btn btn-primary" OnClick="btn_find_Click" />
                                </div>
                                <div class="span12" style="text-align: center;">
                                    <asp:Label ID="lbl_message" runat="server" CssClass="label label-warning"></asp:Label>
                                </div>
                            </div>
                        </asp:Panel>

                        <asp:Panel ID="pnl_view" runat="server" Visible="false">
                            <div style="display: none;">
                                <asp:ImageButton ID="img_usedpindetails" runat="server" Height="32px" ImageUrl="~/images/Excelicons.png"
                                    Style="margin-left: 20px" OnClick="img_usedpindetails_Click" />
                            </div>
                            <div class="row-fluid">
                                <div class="widget-box">
                                    <div class="widget-title bg_lg">
                                        <span class="icon"><i class="icon-signal"></i></span>
                                        <span class="icon-right"><i class="icon-print" onclick="printDiv('epin_used');"></i></span>
                                        <span class="icon-right"><i class="icon-save" onclick="$('#<%=img_usedpindetails.ClientID %>').click();"></i></span>
                                        <h5>E-PIN Details</h5>
                                    </div>
                                    <div class="widget-content">
                                        <div class="row-fluid" id="epin_used">
                                            <asp:GridView ID="grd_pin_details" runat="server" CssClass="table table-bordered data-table dataTable"
                                                AutoGenerateColumns="False" PageSize="30">
                                                <PagerStyle CssClass="pagination-sks" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Sr No.">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSRNO" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="E-PIN">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_epin" runat="server" Font-Names="Arial" Text='<%#Bind("Epin") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Package">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Package" runat="server" Font-Names="Arial" Text='<%#Bind("Package") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Distributed To">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_member_code" runat="server" Font-Names="Arial" Text='<%#Bind("membercode") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="User Member Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_used_by" runat="server" Font-Names="Arial" Text='<%#Bind("usedby") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="User Member Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_usedbyname" runat="server" Font-Names="Arial" Text='<%#Bind("usedbyname") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Used For">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Used_to" runat="server" Font-Names="Arial" Text='<%#Bind("usedto") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Used For Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_usedtoname" runat="server" Font-Names="Arial" Text='<%#Bind("usedtoname") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Status">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Status" runat="server" Font-Names="Arial" Text='<%#Bind("Status") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--<asp:TemplateField HeaderText="Id" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_id" runat="server" Font-Names="Arial" Text='<%#Bind("ID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <div class="span12">
                                            <asp:Label ID="lbl_message_u" runat="server" CssClass="label label-warning"></asp:Label>
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


    <iframe name="print_frame" width="0" height="0" frameborder="0" src="about:blank"></iframe>
</asp:Content>
