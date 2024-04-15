<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="E-pin-history.aspx.cs" Inherits="Master_MLM.Admin.E_pin_history"
    Title="E-Pin-History" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    E-Pin-History
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
                <a href="#" class="current">E-Pin History</a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>E-Pin History</h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid">
                            <div class="widget-box">
                                <div class="widget-title bg_lg">
                                    <span class="icon"><i class="icon-signal"></i></span>
                                    <h5>Generated E-PIN</h5>
                                </div>
                                <div class="widget-content">
                                    <asp:GridView ID="grd_epin_generated" runat="server" CssClass="table table-bordered data-table dataTable" ShowHeaderWhenEmpty="true"
                                        AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="grd_epin_generated_PageIndexChanging">
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
                                    <div class="row-fluid">
                                        <div class="span12" style="text-align: center;">
                                            <asp:Label ID="lbl_message_g" runat="server" CssClass="label label-warning"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row-fluid">
                            <div class="widget-box">
                                <div class="widget-title bg_lg">
                                    <span class="icon"><i class="icon-signal"></i></span>
                                    <h5>Distributed E-PIN</h5>
                                </div>
                                <div class="widget-content">
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
                                            <asp:TemplateField HeaderText="Member Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_distributed_to_name1" runat="server" Font-Names="Arial" Text='<%#Bind("distributed_to_name1") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <%-- <asp:TemplateField HeaderText="Member Name">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_member_name" runat="server" Font-Names="Arial" Text='<%#Bind("used_by") %>'></asp:Label>
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
                                    <div class="row-fluid">
                                        <div class="span12" style="text-align: center;">
                                            <asp:Label ID="lbl_message_d" runat="server" CssClass="label label-warning"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row-fluid">
                            <div class="widget-box">
                                <div class="widget-title bg_lg">
                                    <span class="icon"><i class="icon-signal"></i></span>
                                    <h5>Used E-PIN</h5>
                                </div>
                                <div class="widget-content">
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

                                            <asp:TemplateField HeaderText="Distributed To Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_distributed_to_name" runat="server" Font-Names="Arial" Text='<%#Bind("distributed_to_name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Used By">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_used_by" runat="server" Font-Names="Arial" Text='<%#Bind("used_by") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Used By Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_used_by_name" runat="server" Font-Names="Arial" Text='<%#Bind("used_by_name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Used To">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Used_to" runat="server" Font-Names="Arial" Text='<%#Bind("Used_to") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Used To Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Used_to_name" runat="server" Font-Names="Arial" Text='<%#Bind("Used_to_name") %>'></asp:Label>
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
                                    <div class="row-fluid">
                                        <div class="span12" style="text-align: center;">
                                            <asp:Label ID="lbl_message_u" runat="server" CssClass="label label-warning"></asp:Label>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>

                        <div class="row-fluid">
                            <div class="widget-box">
                                <div class="widget-title bg_lg">
                                    <span class="icon"><i class="icon-signal"></i></span>
                                    <h5>Deleted E-PIN</h5>
                                </div>
                                <div class="widget-content">
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

                                            <asp:TemplateField HeaderText="Distributed To Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_distributed_to_name" runat="server" Font-Names="Arial" Text='<%#Bind("distributed_to_name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Used By">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_used_by" runat="server" Font-Names="Arial" Text='<%#Bind("used_by") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Used By Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_used_by_name" runat="server" Font-Names="Arial" Text='<%#Bind("used_by_name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Used To">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Used_to" runat="server" Font-Names="Arial" Text='<%#Bind("Used_to") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Used To Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_Used_to_name" runat="server" Font-Names="Arial" Text='<%#Bind("Used_to_name") %>'></asp:Label>
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
                                    <div class="row-fluid">
                                        <div class="span12" style="text-align: center;">
                                            <asp:Label ID="lbl_message_del" runat="server" CssClass="label label-warning"></asp:Label>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>




    <div style="margin: 0px auto; padding: 0px; width: 100%; text-align: center; display: none;">
        <table border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #CCCCCC; padding: 0px; margin: 20px auto 20px auto; width: 1100px; font-family: arial, Helvetica, sans-serif; font-size: 15px; font-weight: bold; background-color: #FFFFFF; height: auto;"
            class="round shadow">
            <tr>
                <td colspan="2" height="30" style="padding: 0px 0px 10px 0px; text-align: left; color: #FFFFFF; font-family: arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold;">
                    <div id="epin_generated">
                        <table cellspacing="0" cellpadding="0" border="0" style="width: 100%; float: left;">
                            <tr>
                                <td colspan="2" height="30" style="padding: 5px 0px 5px 30px; text-align: left; font-family: arial, Helvetica, sans-serif; font-size: 16px; font-weight: bold;"
                                    class=" blue_bg">
                                    <h2 style="text-align: left; width: 85%; margin: 0px; float: left;">Generated E-PIN
                                    </h2>
                                    <h2 style="text-align: center; width: 15%; margin: 0px; float: left;" class="noPrint">
                                        <a href="javascript:printDiv('epin_generated')">
                                            <img src="../images/printer.png" height="25" width="25" border="0" alt=" " /></a>
                                        <asp:ImageButton ID="img_generated" runat="server" Height="32px" ImageUrl="~/images/Excelicons.png"
                                            Style="margin-left: 20px" OnClick="img_generated_Click" />
                                    </h2>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="padding: 5px; text-align: center;" valign="top"></td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2" height="30" style="padding: 10px 0px 10px 0px; text-align: left; color: #FFFFFF; font-family: arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold;">
                    <div id="epin_distributed">
                        <table cellspacing="0" cellpadding="0" border="0" style="width: 100%; float: left">
                            <tr>
                                <td colspan="2" height="30" style="padding: 5px 0px 5px 30px; text-align: left; color: #FFFFFF; font-family: arial, Helvetica, sans-serif; font-size: 16px; font-weight: bold; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #CCCCCC;"
                                    class="blue_bg">
                                    <h2 style="text-align: left; width: 85%; margin: 0px; float: left;">Distributed E-PIN
                                    </h2>
                                    <h2 style="text-align: center; width: 15%; margin: 0px; float: left;" class="noPrint">
                                        <a href="javascript:printDiv('epin_distributed')">
                                            <img src="../images/printer.png" height="25" width="25" border="0" alt=" " /></a>
                                        <asp:ImageButton ID="img_distributed" runat="server" Height="32px" ImageUrl="~/images/Excelicons.png"
                                            Style="margin-left: 20px" OnClick="img_distributed_Click" />
                                    </h2>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="padding: 5px; text-align: center;" valign="top"></td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2" height="30" style="padding: 10px 0px 10px 0px; text-align: left; color: #FFFFFF; font-family: arial, Helvetica, sans-serif; font-size: 18px; font-weight: bold;">
                    <div id="epin_used">
                        <table cellspacing="0" cellpadding="0" border="0" style="width: 100%; float: left">
                            <tr>
                                <td colspan="2" height="30" style="padding: 5px 0px 5px 30px; text-align: left; color: #FFFFFF; font-family: arial, Helvetica, sans-serif; font-size: 16px; font-weight: bold;"
                                    class="blue_bg">
                                    <h2 style="text-align: left; width: 85%; margin: 0px; float: left;">Used E-PIN
                                    </h2>
                                    <h2 style="text-align: center; width: 15%; margin: 0px; float: left;" class="noPrint">
                                        <a href="javascript:printDiv('epin_used')">
                                            <img src="../images/printer.png" height="25" width="25" border="0" alt=" " /></a>
                                        <asp:ImageButton ID="img_used" runat="server" Height="32px" ImageUrl="~/images/Excelicons.png"
                                            Style="margin-left: 20px" OnClick="img_used_Click" />
                                    </h2>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="padding: 5px; text-align: center;" valign="top"></td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <iframe name="print_frame" width="0" height="0" frameborder="0" src="about:blank"></iframe>
</asp:Content>
