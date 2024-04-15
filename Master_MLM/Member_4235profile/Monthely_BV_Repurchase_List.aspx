<%@ Page Title="Monthly Bv Repurchase List" Language="C#" MasterPageFile="~/Member_4235profile/Member_main.Master" AutoEventWireup="true" CodeBehind="Monthely_BV_Repurchase_List.aspx.cs" Inherits="Master_MLM.Member_4235profile.Monthely_BV_Repurchase_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .mydatagrid {
            width: 100%;
            border: solid 2px #1b93e1;
            min-width: 80%;
            margin: 15px 0px 0px 0px;
        }

            .mydatagrid th {
                padding: 5px;
            }

        .header {
            background-color: #1b93e1;
            font-family: 'Roboto', sans-serif;
            color: White;
            border: none 0px transparent;
            height: 30px;
            text-align: center;
            font-size: 16px;
        }

        td, th {
            padding: 5px 5px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hd_memberid" runat="server" />
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="index.html">Home</a> <i class="fa fa-angle-right"></i></li>
    </ol>

    <div class="grid-form">
        <div class="grid-form1">
            <h4 class="breadcrumb-item"><a>Monthly Bv Repurchase List</a></h4>

            <div class="panel-body panel-footer">
                <div class="row" style="padding: 0px 0px 0px 0px;">
                    <div style="margin: 0px auto; padding: 0px; width: 100%; height: auto;">
                        <div style="margin: 0px; padding: 0px; width: 100%; height: auto; float: left;">
                            <table border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #a7a43f; margin: 25px auto 0px auto; padding: 0px; width: 401px; height: 136px; background-color: White;">

                                <tr>
                                    <td style="text-align: right; padding: 5px 10px 0px 0px; font-family: ebrima; font-size: 15px;">Select Month :
                                    </td>
                                    <td style="padding: 5px 0px 0px 0px; text-align: left;">
                                        <asp:DropDownList ID="ddl_month" runat="server" CssClass="form-control" Style="float: left; color: Green; width: 75px; font-weight: bold;">
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
                                        &nbsp;
                            <asp:DropDownList ID="ddl_year" runat="server" CssClass="form-control" Style="color: Green; float: left; width: 100px; font-weight: bold;">
                                <asp:ListItem Selected="True">Select</asp:ListItem>
                                <asp:ListItem>2016</asp:ListItem>
                                <asp:ListItem>2017</asp:ListItem>
                                <asp:ListItem>2018</asp:ListItem>
                                <asp:ListItem>2019</asp:ListItem>
                                <asp:ListItem>2020</asp:ListItem>
                            </asp:DropDownList>
                                    </td>
                                </tr>

                                <tr>
                                    <td style="text-align: center; padding: 5px 0px 0px 0px;" colspan="2">
                                        <asp:Button ID="btn_Submit" CssClass="btn btn-success" runat="server" Text="Find" OnClick="btn_Submit_Click" Height="30px"
                                            Width="100px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: center; padding: 5px 0px 0px 0px;" colspan="2">
                                        <asp:Label ID="lbl_message" runat="server" Font-Bold="True" Font-Size="18px" ForeColor="Red"
                                            Font-Names="Bell MT"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <script type="text/javascript">
                            function PrintPanel() {
                                var panel = document.getElementById("<%=tblPrintIQ.ClientID %>");
                                var printWindow = window.open('', '', 'height=400,width=800');
                                printWindow.document.write('<html><head>');
                                printWindow.document.write('</head><body>');
                                printWindow.document.write('');
                                printWindow.document.write(panel.innerHTML);
                                printWindow.document.write('</body ></html>');
                                printWindow.document.close();
                                setTimeout(function () {
                                    printWindow.print();
                                }, 500);
                                return false;
                            }
                        </script>
                        <div id="tblPrintIQ" runat="server">
                            <asp:Panel ID="pnl_view" runat="server" Visible="false">
                                <div style="margin: 0px; padding: 0px; width: 100%; height: auto; float: left; position: relative">
                                    <asp:LinkButton ID="print1" OnClientClick="return PrintPanel()" runat="server" ToolTip="Print" CssClass="form-btn"><img src="images/printer.png" style="position:absolute; right: 30px; top: -15px;" height="25" width="25" border="0" /></asp:LinkButton>
                                    <asp:ImageButton ID="img_expord" runat="server" Height="25px" style="position:absolute; right: 1px; top: -15px;" ImageUrl="~/Member_4235profile/images/Excelicons.png"
                                     OnClick="img_expord_Click" />
                                    <div style="margin: 15px 0px 10px 0px; padding: 0px; float: left; width: 100%; height: auto;">
                                        <div style="margin: 0px 0px 0px 0px; padding: 0px 0px 0px 0px; float: left; width: 100%; height: auto;">
                                            <asp:GridView ID="grd_view" runat="server" Style="margin: 0px auto; width: 100%; font: normal 13px ebrima; height: auto;"
                                                CssClass="mydatagrid" PagerStyle-CssClass="pager"
                                                HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="true" OnPageIndexChanging="grd_view_PageIndexChanging" AutoGenerateColumns="False">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Sr No.">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_sl" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Self">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Self" runat="server" Text='<%# bind("Self") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Team">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl_Team" runat="server" Text='<%#bind("Team") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle BackColor="#00A4CC" />
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
</asp:Content>
