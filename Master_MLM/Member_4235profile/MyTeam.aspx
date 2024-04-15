<%@ Page Title="My Team Report" Language="C#" MasterPageFile="~/Member_4235profile/Member_main.Master" AutoEventWireup="true" CodeBehind="MyTeam.aspx.cs" Inherits="Master_MLM.Member_4235profile.MyTeam" %>

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
    <asp:Panel ID="pnlMemberActivation" runat="server" Visible="false">

        <div class="grid-form">
            <div class="grid-form1">
                <h4 class="breadcrumb-item"><a>Member Top Up</a></h4>
                <div class="panel-body panel-footer">
                    <div class="row">

                        <div class="col-lg-6">
                            <div class="form-group">
                                <label for="txtMemberName">Member Name</label>
                                <asp:Label ID="lblMemberName" runat="server" CssClass="form-control" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label for="txtMemberCode">Member Code</label>
                                <asp:Label ID="lblMemberCode" runat="server" CssClass="form-control" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="txtEPin">EPin</label>
                                <asp:TextBox ID="txtEPin" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label for="txtEPin"></label>
                                <asp:Button ID="btnValidate" runat="server" CssClass="btn btn-info" Style="margin-top: 25px" Text="Validate" OnClick="btnValidate_Click" />
                            </div>
                        </div>
                    </div>

                    <div class="row" id="divEPinDetail" runat="server" visible="false">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label class="form-label">Package  :</label>
                                <asp:Label ID="lblPackageName" CssClass="form-control" runat="server" Text=""></asp:Label>
                                <asp:HiddenField ID="hdfPackageAmount" runat="server" />
                                <asp:HiddenField ID="hdfPackageRewardPoint" runat="server" />
                                <asp:HiddenField ID="hdfMatchingIncome" runat="server" />
                                <asp:HiddenField ID="hdfPackageID" runat="server" />

                                <asp:HiddenField ID="hdfRewardBV" runat="server" />
                                <asp:HiddenField ID="hdfRepurchaseBV" runat="server" />
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <div class="controls">
                                    <asp:Button ID="btnActivate" runat="server" Style="margin-top: 25px" Text="Submit" CssClass="btn btn-success" OnClick="btnActivate_Click" />
                                </div>
                            </div>
                        </div>
                    </div>


                    <br />
                    <br />
                    <asp:Label ID="lblMessage" runat="server" CssClass="label label-danger" Text=""></asp:Label>

                </div>
            </div>
        </div>

    </asp:Panel>


    <div class="grid-form">
        <div class="grid-form1">
            <h4 class="breadcrumb-item"><a>My Team</a></h4>
            <div class="panel-body panel-footer">
                <div class="row" style="padding: 3px 0px 0px 0px;">
                    <div style="margin: 0px auto 0px auto; padding: 30px 0px 30px 0px; height: auto;">
                        <div style="margin: 0px; padding: 0px; width: 100%; height: auto;">


                            <div style="margin: 0px 0px 10px 0px; padding: 0px; float: left; width: 100%; height: auto; background-color: white;">
                                <asp:Label ID="lblTotalMembers" runat="server" Text="" CssClass="label label-info"></asp:Label>
                                <div class="ovrflow-div" style="margin: 0px; padding: 0px; width: 100%">
                                    <asp:Panel ID="pnl_view" Visible="false" runat="server">
                                        <table style="height: auto; margin: 2px auto; border-spacing: 0px; width: 100%;"
                                            border="0">

                                            <tr>
                                                <td style="text-align: center; padding: 5px 5px 5px 5px;">
                                                    <asp:GridView ID="grd_view" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                                                        HeaderStyle-CssClass="header" RowStyle-CssClass="rows" runat="server"
                                                        Style="margin: 0px auto; font: normal 13px ebrima; height: auto;" PageSize="50" AllowPaging="true"
                                                        OnPageIndexChanging="grd_view_PageIndexChanging" OnRowCommand="grd_view_RowCommand"
                                                        AutoGenerateColumns="False" OnRowDataBound="grd_view_RowDataBound">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sr No.">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_sl" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Member Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_name" runat="server" Text='<%# Bind("MemberName") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Member Code">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_member_code" runat="server" Text='<%# Bind("MemberCode") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Mobile No">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbl_mobile" runat="server" Text='<%#Bind("MobileNumber") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Package">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblPaidstatus" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Level" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblLevel" runat="server" Text='<%# Bind("Level") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Top Up">
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btnTopUp" runat="server" CommandArgument='<%# Bind("MemberCode") %>' CommandName="IsTopUp" CssClass="btn btn-primary btn-sm" Text="TopUp" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
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
