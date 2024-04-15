<%@ Page Title="Spill Report" Language="C#" MasterPageFile="~/Member_4235profile/Member_main.Master" AutoEventWireup="true" CodeBehind="Reward_Report.aspx.cs" Inherits="Master_MLM.Member_4235profile.Reward_Report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/mygrid.css" rel="stylesheet" />
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

        @media (max-width:408px) {
            .sks-hidden {
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="index.html">Home</a> <i class="fa fa-angle-right"></i></li>
    </ol>
    <div class="grid-form">
        <div class="grid-form1">
            <h4 class="breadcrumb-item"><a>Reward Report</a></h4>
            <div class="panel-body panel-footer">
                <div class="row" style="padding: 3px 0px 0px 0px;">
                    <div style="margin: 0px auto 0px auto; padding: 30px 0px 30px 0px; height: auto;">
                        <div style="margin: 0px; padding: 0px; width: 100%; height: auto;">

                            <div style="margin: 0px 0px 10px 0px; padding: 0px; float: left; width: 100%; height: auto; background-color: white;">
                                <div style="margin: 0px; padding: 0px; width: 100%">
                                    <asp:Panel ID="pnl_view" runat="server">
                                        <table style="height: auto; margin: 2px auto; border-spacing: 0px; width: 100%;"
                                            border="0" class="round shadow">
                                            
                                            <tr>
                                                <td style="text-align: center; padding: 5px 5px 5px 5px;">
                                                    <asp:GridView ID="grd_view" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                                        HeaderStyle-CssClass="header" RowStyle-CssClass="rows" runat="server" Style="margin: 0px auto; font: normal 13px ebrima; width: 100%; height: auto;"
                                                        AutoGenerateColumns="False"  ShowHeaderWhenEmpty="true">

                                                        <EmptyDataTemplate>
                                                            <div style="text-align: center;">
                                                                Reward Not Achieved.
                                                            </div>
                                                        </EmptyDataTemplate>
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sr No.">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_sl" runat="server" Text='<%# Container.DataItemIndex+1 %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Achieved Date">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_Mobile_number" runat="server" Text='<%# Bind("DateOfAchievement") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Status">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_TDS" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Reward Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_TDS" runat="server" Text='<%# Bind("RewardName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Paid Date">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPaidDate" runat="server" Text='<%# Bind("PaidDate") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <HeaderStyle BackColor="#00A4CC" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
