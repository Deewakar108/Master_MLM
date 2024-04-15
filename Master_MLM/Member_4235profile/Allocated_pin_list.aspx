<%@ Page Title="Avilable Pin" Language="C#" MasterPageFile="~/Member_4235profile/Member_main.Master" AutoEventWireup="true" CodeBehind="Allocated_pin_list.aspx.cs" Inherits="Master_MLM.Member_4235profile.Allocated_pin_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .ddsmoothmenu ul li a.tenth {
            background-color: #F700A9;
            color: #fff;
        }

        @media print {
            .noPrint {
                display: none;
            }
        }

        @media (max-width: 480px) {
            .display-480 {
                display: none;
            }
        }



        .auto-style1 {
            height: 28px;
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
    <link href="css/mygrid.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="grid-form">
        <div class="grid-form1">
            <h4 class="breadcrumb-item"><a>Available Pin</a><span style="float: right;">
                <a href="javascript:printDiv('epin_generated')" style="display: none;">
                    <img src="../images/printer.png" height="20" width="20" border="0" alt=" " /></a>
                <asp:ImageButton ID="img_export" runat="server" Height="20px" Width="20px" ImageUrl="~/images/Excelicons.png"
                    Style="display: none; margin-left: 20px" OnClick="img_export_Click" /></span></h4>
            <div class="panel-body panel-footer">
                <div id="notification">
                    <div id="pan" class="notificationpan" style="background-color: red;">
                        <div style="float: left; width: auto; height: auto;">
                            <asp:Label ID="lbl_message1" runat="server" Style="padding: 10px 20px 0px 10px; background-position: left center; background-image: url(   '../images/warningicon.png' ); background-repeat: no-repeat; font-size: 15px; color: #ffffff; font-weight: bold; padding: 10px;"></asp:Label>
                        </div>

                    </div>
                </div>
                <div class="row row1" style="padding: 3px 0px 0px 0px;">
                    <div id="epin_generated" style="margin: 0 auto; padding: 10px 0px 30px 0px; height: auto;">
                        <table style="width: 100%; height: auto; margin: 0 auto; border-spacing: 0px; float: none; background-color: white;"
                            border="0" class="shadow round">

                            <tr>
                                <td style="padding: 5px; text-align: left; vertical-align: middle;">Select Package

                                    <asp:DropDownList ID="ddl_package" runat="server" Style="color: black; width: auto;"
                                        AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="ddl_package_SelectedIndexChanged">
                                    </asp:DropDownList>

                                </td>
                                <td style="padding: 5px; text-align: left;">&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Panel ID="pnl_view" runat="server" Visible="false">
                                        <div class="round">
                                            <asp:GridView ID="grd_epin" runat="server" Style="margin: 0px auto; width: 100%; font: normal 13px ebrima; height: auto;"
                                                CssClass="mydatagrid" PagerStyle-CssClass="pager"
                                                HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AutoGenerateColumns="False" OnRowCommand="grd_epin_RowCommand">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Sl. No.">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSRNO" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="E-Pin">
                                                        <ItemTemplate>

                                                            <asp:Label ID="lbl_epin" runat="server" Text='<%# Bind("Epin") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Package" HeaderStyle-CssClass="display-480" ItemStyle-CssClass="display-480">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Package" runat="server" Font-Names="Arial" Text='<%#Bind("Package") %>'></asp:Label>
                                                            <asp:Label ID="lbl_packag_id" runat="server" Font-Names="Arial" Text='<%#Bind("Package_id") %>' Visible="false"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Allocation Date" HeaderStyle-CssClass="display-480" ItemStyle-CssClass="display-480">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_distributed_date" runat="server" Text='<%#Bind("distribution_date") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Status" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_status" runat="server" Text='<%#Bind("Status") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="id" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_id" runat="server" Text='<%#Bind("ID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                   
                                                    <asp:TemplateField HeaderText="Active">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnk_btn" runat="server" CssClass="btn btn-primary btn-sm" Text="Active" OnClick="lnk_btn_Click"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Member">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnEpinForNewUser" runat="server" CssClass="btn btn-primary btn-sm" Text="Add" CommandName="EPIN" CommandArgument='<%# Bind("Epin") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                </Columns>
                                                <HeaderStyle BackColor="#00A4CC" />
                                            </asp:GridView>
                                        </div>
                                    </asp:Panel>

                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <iframe name="print_frame" width="0" height="0" frameborder="0" src="about:blank"></iframe>
            </div>
        </div>
    </div>

</asp:Content>
