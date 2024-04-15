<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="Distribute_E-Pin_history.aspx.cs" Inherits="Master_MLM.Admin.Distribute_E_Pin_history"
    Title="Distribute E-Pin History" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Distribute E-Pin History
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
        }

        .minimum-height {
            min-height: 517px;
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
                <a href="#" class="current">Distributed E-Pin History</a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Distributed E-Pin History</h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid">
                            <div class="span12" style="text-align: center;">
                                <asp:Label ID="lbl_message_d" runat="server" CssClass="label label-warning"></asp:Label>
                            </div>
                        </div>
                        <asp:GridView ID="grd_epin_used" runat="server" BackColor="White" CssClass="table table-bordered data-table dataTable"
                            AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="grd_epin_used_PageIndexChanging"
                            PageSize="20" AutoGenerateSelectButton="True" OnSelectedIndexChanged="grd_epin_used_SelectedIndexChanged">
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
                                <asp:TemplateField HeaderText="Total Distribute Pin">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_pin" runat="server" Font-Names="Arial" Text='<%#Bind("Totalallocatedpin") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total Use Pin">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_pin2" runat="server" Font-Names="Arial" Text='<%#Bind("use") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total Available Pin">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_pin1" runat="server" Font-Names="Arial" Text='<%#Bind("rest") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total Deleted Pin">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_deleted" runat="server" Font-Names="Arial" Text='<%#Bind("deleted") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <div class="row-fluid">
                            <div class="span12" style="text-align: left;">
                                Total Pin :
                                <asp:Label ID="lbl_total_pin" runat="server" CssClass="label label-warning"></asp:Label>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <asp:Panel ID="pnl_view" runat="server" Visible="false">
                                <div class="widget-box">
                                    <div class="widget-title bg_lg">
                                        <span class="icon"><i class="icon-signal"></i></span>
                                        <h5>E-PIN Details</h5>
                                    </div>
                                    <div class="widget-content">
                                        <div class="row-fluid">
                                            <div class="span12" style="text-align: center;">
                                                <asp:Label ID="lbl_message_u" runat="server" CssClass="label label-warming"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row-fluid">
                                            <asp:GridView ID="grd_pin_details" runat="server" CssClass="table table-bordered data-table dataTable"
                                                AutoGenerateColumns="False" PageSize="30">
                                                <PagerStyle CssClass="pagination-sks" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Sr No.">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSRNO" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Package">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Package" runat="server" Font-Names="Arial" Text='<%#Bind("Package") %>'></asp:Label>
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
                                                    <asp:TemplateField HeaderText="Total Distribute Pin">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_pin" runat="server" Font-Names="Arial" Text='<%#Bind("Totalallocatedpin") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Total Use Pin">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_pin2" runat="server" Font-Names="Arial" Text='<%#Bind("use") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Total Available Pin">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_pin1" runat="server" Font-Names="Arial" Text='<%#Bind("rest") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Total Deleted Pin">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_deleted" runat="server" Font-Names="Arial" Text='<%#Bind("deleted") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
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




    <div class="row" style="padding: 30px 0px 30px 0px; display: none;">
        <div class="block">
            <table border="0" cellpadding="0" cellspacing="0" style="width: 745px; margin: 0px auto;"
                class="round shadow">
                <tr>
                    <td>
                        <div id="epin_distributed">
                            <table cellspacing="0" cellpadding="0" border="0" style="width: 100%; float: left">
                                <tr>
                                    <td colspan="2" style="padding: 5px 0px 5px 30px; text-align: left; color: #FFFFFF; font-family: arial, Helvetica, sans-serif; font-size: 16px; font-weight: bold; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #CCCCCC;"
                                        class="blue_bg">
                                        <h2 style="text-align: left; width: 85%; margin: 0px; float: left;">Distribute E-PIN History
                                        </h2>
                                        <h2 style="text-align: center; width: 14%; margin: 0px; float: left;" class="noPrint">
                                            <a href="javascript:printDiv('epin_distributed')">
                                                <img src="../images/printer.png" height="25" width="25" border="0" alt=" " /></a>
                                            <asp:ImageButton ID="img_exportgrd" runat="server" Height="32px" ImageUrl="~/images/Excelicons.png"
                                                OnClick="img_exportgrd_Click" Style="margin-left: 20px" />
                                        </h2>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="padding: 5px; text-align: center;" valign="top"></td>
                                </tr>
                                <tr>
                                    <td style="padding: 0px 20px 10px 0px; text-align: right">Total Pin :
                                        
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div class="block">
            <asp:Panel ID="pnl_member" runat="server" Visible="false">
                <%--  <table border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #CCCCCC;
                    padding: 0px; margin: 0px auto; width: 423px; font-family: arial, Helvetica, sans-serif;
                    font-size: 15px; font-weight: bold; background-color: #FFFFFF; height: auto;"
                    class="round  shadow">
                    <tr>
                        <td style="text-align: right; padding: 10px 10px 0px 0px;">
                            Enter member code :-
                        </td>
                        <td style="text-align: left; padding: 10px 0px 0px 0px;">
                            <asp:TextBox ID="txt_member_code" runat="server" Height="25px" TaBindex="1" Width="180px"
                                placeholder="Enter member code"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center; padding: 10px 0px 0px 0px;">
                        </td>
                        <td style="text-align: left; padding: 10px 0px 0px 0px;">
                            <asp:Button ID="btn_find" runat="server" Text="Find" Style="margin: 0px;" Width="100px"
                                OnClick="btn_find_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center; padding: 10px 0px 10px 0px;" colspan="2">
                            <asp:Label ID="lbl_message" runat="server" Font-Bold="False" ForeColor="Red" Font-Italic="False"></asp:Label>
                        </td>
                    </tr>
                </table>--%>
            </asp:Panel>
        </div>
        <div class="block">
            <%--<asp:Panel ID="pnl_view-X" runat="server" Visible="false">--%>
            <table border="0" cellpadding="0" cellspacing="0" style="width: 1000px; margin: 0px auto; background-color: white;"
                class="round shadow">
                <tr>
                    <td>
                        <div id="epin_used" style="background-color: White;">
                            <table cellspacing="0" cellpadding="0" border="0" style="width: 100%; float: left; background-color: #FFFFFF;">
                                <tr>
                                    <td colspan="2" height="30" style="padding: 5px 0px 5px 30px; text-align: left; color: #FFFFFF; font-family: arial, Helvetica, sans-serif; font-size: 16px; font-weight: bold;"
                                        class="blue_bg">
                                        <h2 style="text-align: left; width: 88%; margin: 0px; float: left;">E-PIN Details
                                        </h2>
                                        <h2 style="text-align: center; width: 11%; margin: 0px; float: left;" class="noPrint">
                                            <a href="javascript:printDiv('epin_used')">
                                                <img src="../images/printer.png" height="25" width="25" border="0" alt=" " /></a>
                                        </h2>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="padding: 5px; text-align: center; background-color: White;"
                                        valign="top">


                                        <%--<asp:GridView ID="grd_pin_details" runat="server" BackColor="White" BorderColor="#DEDFDE"
                                                BorderStyle="Solid" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical"
                                                Style="text-align: center; font-family: arial, Helvetica, sans-serif; font-size: 12px;
                                                height: auto; margin-top: 4px; margin-bottom: 16px; margin-right: 0px; margin-left: 0px;"
                                                AutoGenerateColumns="False" PageSize="30" Width="980px">
                                                
                                                <RowStyle BackColor="#F7F7DE" Font-Size="10pt" ForeColor="#333333" />
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
                                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_id" runat="server" Font-Names="Arial" Text='<%#Bind("ID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#CCCC99" BorderStyle="Solid" />
                                                <PagerStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="noPrint" />
                                                <SelectedRowStyle BackColor="#EFEFEF" Font-Bold="True" ForeColor="#CC0000" />
                                                <HeaderStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Bold="False"
                                                    ForeColor="White" Height="40px" BackColor="#9d25a7" Font-Size="12pt" />
                                                <AlternatingRowStyle BackColor="White" />
                                            </asp:GridView>--%>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
            <%--</asp:Panel>--%>
        </div>
    </div>
    <iframe name="print_frame" width="0" height="0" frameborder="0" src="about:blank"></iframe>
</asp:Content>
