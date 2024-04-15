<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Packagewise_Epin_History.aspx.cs" Inherits="Master_MLM.Admin.Packagewise_Epin_History" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Package Wise E-pin History
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="../css/custom.css" rel="stylesheet" />
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
                        <div class="row-fluid">
                            <div class="span12" style="text-align: center;">
                                Member Code :
                                <asp:TextBox ID="txt_membercode" runat="server"></asp:TextBox>
                            </div>
                            <div class="span12" style="text-align: center;">
                                Package :
                                <asp:DropDownList ID="ddl_package" runat="server" AutoPostBack="True"></asp:DropDownList>
                            </div>
                            <div class="span12" style="text-align: center;">
                                <asp:Button ID="btn_find" runat="server" Text="Find" CssClass="btn btn-primary" OnClick="btn_Submit_Click" />
                                <br />
                                <asp:Label ID="lbl_msg" runat="server" CssClass="label label-warning"></asp:Label>
                            </div>
                            <asp:Panel ID="pnl_view" Visible="false" runat="server">
                                <div class="row-fluid">
                                    <div class="widget-box">
                                        <div class="widget-title bg_lg">
                                            <span class="icon"><i class="icon-signal"></i></span>
                                            <span class="icon-right"><i class="icon-print" onclick="printDiv('epin_distributed');"></i></span>
                                            <span class="icon-right"><i class="icon-save" onclick="$('#<%=img_distributed.ClientID %>').click();"></i></span>
                                            <h5>Distributed E-Pin</h5>
                                        </div>
                                        <div class="widget-content">
                                            <div style="display: none;">
                                                <a href="javascript:printDiv('epin_distributed')" id="aExcel">
                                                    <img src="../images/printer.png" height="25" width="25" border="0" alt=" " /></a>
                                                <asp:ImageButton ID="img_distributed" runat="server" Height="32px" ImageUrl="~/images/Excelicons.png"
                                                    Style="margin-left: 20px" OnClick="img_distributed_Click" />
                                            </div>
                                            <div class="row-fluid" id="epin_distributed">
                                                <asp:GridView ID="grd_epin_distributed" runat="server" CssClass="table table-bordered data-table dataTable" ShowHeaderWhenEmpty="true"
                                                    AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="grd_epin_distributed_PageIndexChanging">
                                                    <PagerStyle CssClass="pagination-sks" />
                                                    <EmptyDataTemplate>
                                                    <div style="text-align: center;">
                                                        No Record Found.
                                                    </div>
                                                </EmptyDataTemplate>
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
                                                        <asp:TemplateField HeaderText="Generation Date" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_Date" runat="server" Font-Names="Arial" Text='<%#Bind("Date") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Member Code">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_member_code" runat="server" Font-Names="Arial" Text='<%#Bind("distributed_to") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <%-- <asp:TemplateField HeaderText="Member Name">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_member_name" runat="server" Font-Names="Arial" Text='<%#bind("used_by") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                                                        <asp:TemplateField HeaderText="Status">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_Status" runat="server" Font-Names="Arial" Text='<%#Bind("Status") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Id" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_id" runat="server" Font-Names="Arial" Text='<%#Bind("ID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>

                                            <div class="row-fluid">
                                                <div class="span12">
                                                    <asp:Label ID="lbl_message_d" runat="server" CssClass="label label-warning"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="widget-box">
                                        <div class="widget-title bg_lg">
                                            <span class="icon"><i class="icon-signal"></i></span>
                                            <span class="icon-right"><i class="icon-print" onclick="printDiv('epin_used');"></i></span>
                                            <span class="icon-right"><i class="icon-save" onclick="$('#<%=img_used.ClientID %>').click();"></i></span>
                                            <h5>Used E-Pin</h5>
                                        </div>
                                        <div class="widget-content">
                                            <div style="display: none;">
                                                <asp:ImageButton ID="img_used" runat="server" Height="32px" ImageUrl="~/images/Excelicons.png"
                                                    Style="margin-left: 20px" OnClick="img_used_Click" />
                                            </div>
                                            <div class="row-fluid" id="epin_used">
                                                <asp:GridView ID="grd_epin_used" runat="server" CssClass="table table-bordered data-table dataTable" ShowHeaderWhenEmpty="true"
                                                    AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="grd_epin_used_PageIndexChanging">
                                                    <PagerStyle CssClass="pagination-sks" />
                                                    <EmptyDataTemplate>
                                                    <div style="text-align: center;">
                                                        No Record Found.
                                                    </div>
                                                </EmptyDataTemplate>
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
                                                        <asp:TemplateField HeaderText="Generation Date" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_Date" runat="server" Font-Names="Arial" Text='<%#Bind("Date") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Package">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_Package" runat="server" Font-Names="Arial" Text='<%#Bind("Package") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Distributed To">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_member_code" runat="server" Font-Names="Arial" Text='<%#Bind("distributed_to") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Used By">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_used_by" runat="server" Font-Names="Arial" Text='<%#Bind("used_by") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Used To">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_Used_to" runat="server" Font-Names="Arial" Text='<%#Bind("Used_to") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Status">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_Status" runat="server" Font-Names="Arial" Text='<%#Bind("Status") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Id" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_id" runat="server" Font-Names="Arial" Text='<%#Bind("ID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>

                                            <div class="row-fluid">
                                                <div class="span12">
                                                    <asp:Label ID="lbl_message_u" runat="server" CssClass="label label-warning"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="widget-box">
                                        <div class="widget-title bg_lg">
                                            <span class="icon"><i class="icon-signal"></i></span>
                                            <span class="icon-right"><i class="icon-print" onclick="printDiv('epin_used');"></i></span>
                                            <span class="icon-right"><i class="icon-save" onclick="$('#<%=img_used.ClientID %>').click();"></i></span>
                                            <h5>Deleted E-Pin</h5>
                                        </div>
                                        <div class="widget-content">
                                            <div style="display: none;">
                                                <asp:ImageButton ID="ImageButton1" runat="server" Height="32px" ImageUrl="~/images/Excelicons.png"
                                                    Style="margin-left: 20px" OnClick="img_used_Click" />
                                            </div>
                                            <div class="row-fluid" id="Div1">
                                                <asp:GridView ID="grdDeleted" runat="server" CssClass="table table-bordered data-table dataTable" ShowHeaderWhenEmpty="true"
                                                    AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="grd_epin_used_PageIndexChanging">
                                                    <PagerStyle CssClass="pagination-sks" />
                                                    <EmptyDataTemplate>
                                                    <div style="text-align: center;">
                                                        No Record Found.
                                                    </div>
                                                </EmptyDataTemplate>
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
                                                        <asp:TemplateField HeaderText="Generation Date" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_Date" runat="server" Font-Names="Arial" Text='<%#Bind("Date") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Package">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_Package" runat="server" Font-Names="Arial" Text='<%#Bind("Package") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Distributed To">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_member_code" runat="server" Font-Names="Arial" Text='<%#Bind("distributed_to") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Used By">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_used_by" runat="server" Font-Names="Arial" Text='<%#Bind("used_by") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Used To">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_Used_to" runat="server" Font-Names="Arial" Text='<%#Bind("Used_to") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Status">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_Status" runat="server" Font-Names="Arial" Text='<%#Bind("Status") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Id" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_id" runat="server" Font-Names="Arial" Text='<%#Bind("ID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>

                                            <div class="row-fluid">
                                                <div class="span12">
                                                    <asp:Label ID="lbl_message_del" runat="server" CssClass="label label-warning"></asp:Label>
                                                </div>
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
    </div>


    <iframe name="print_frame" width="0" height="0" frameborder="0" src="about:blank"></iframe>
</asp:Content>
