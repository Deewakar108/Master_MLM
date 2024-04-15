<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Total_Free_Joining.aspx.cs"
    Inherits="Master_MLM.Admin_87554b.Total_Free_Joining" ValidateRequest="false" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    All Member
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .ddsmoothmenu ul li a.fifth {
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
    <link href="../css/custom.css" rel="stylesheet" />
    <script>
        function AlertMe() { document.getElementById("sksButton").click(); }
    </script>

    <script type="text/javascript">
        function printTable() {
            var printContent = document.getElementById("tblPrintIQ");
            var windowUrl = 'abount:blank';
            var num;
            var uniqueName = new Date();
            var windowName = 'Print' + uniqueName.getTime();
            var printWindow = window.open(num, windowName, 'left=50000,top=50000,width=0,height=0');
            printWindow.document.write(printContent.innerHTML);
            printWindow.document.close();
            printWindow.focus();
            printWindow.print();
            printWindow.close();
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">

        <div id="content-header">
            <div id="breadcrumb">
                <a href="/" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">Report</a>
                <a href="#" class="current">All Member</a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            <asp:Panel ID="pnlActivateMember" runat="server" Visible="false">
                <div class="row-fluid">
                    <div class="widget-box">
                        <div class="widget-title bg_lg">
                            <span class="icon"><i class="icon-signal"></i></span>
                            <h5>Member Activation</h5>
                        </div>
                        <div class="widget-content nopadding">
                            <div class="row-fluid">
                                <div class="span6">
                                    <div class="form-horizontal">
                                    <div class="control-group">
                                        <label class="control-label">Member Name :</label>
                                        <div class="controls">
                                            <asp:Label ID="lblMemberName" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Member Code :</label>
                                        <div class="controls">
                                            <asp:Label ID="lblMemberCode" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">E-Pin :</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtEPin" runat="server" CssClass="span6"></asp:TextBox>
                                            <asp:Button ID="btnValidate" runat="server" Text="Validate" CssClass="btn btn-primary" OnClick="btnValidate_Click" />
                                        </div>
                                    </div>
                                    <div  id="divEPinDetail" runat="server" visible="false">
                                        <div class="control-group">
                                        <label class="control-label">Package  :</label>
                                        <div class="controls">
                                            <asp:Label ID="lblPackageName" runat="server" Text=""></asp:Label>
                                            <asp:HiddenField ID="hdfPackageAmount" runat="server" />
                                            <asp:HiddenField ID="hdfPackageRewardPoint" runat="server" />
                                            <asp:HiddenField ID="hdfMatchingIncome" runat="server" />
                                            <asp:HiddenField ID="hdfPackageID" runat="server" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <div class="controls">
                                            <asp:Button ID="btnActivate" runat="server" Text="Submit" CssClass="btn btn-success" OnClick="btnActivate_Click" />
                                        </div>
                                    </div>
                                    </div>
                                    
                                </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>


            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <span class="icon-right"><i class="icon-print" onclick="$('#<%= print1.ClientID %>').click();"></i></span>
                        <span class="icon-right"><i class="icon-save" onclick="$('#<%= img_expord.ClientID %>').click();"></i></span>
                        <h5>All Member</h5>
                    </div>
                    <div class="widget-content">
                        <div style="display: none;">
                            <asp:LinkButton ID="print1" OnClientClick="printTable();" runat="server">
                                    <img src="../images/printer.png" height="25" width="25" border="0" alt=" " /></asp:LinkButton>
                            <asp:ImageButton ID="img_expord" runat="server" Height="32px" ImageUrl="~/images/Excelicons.png"
                                Style="margin-left: 0px; float: right;" OnClick="img_expord_Click" />
                        </div>
                        <div class="row-fluid">
                            <div class="span12">
                                <asp:Button ID="btn_find" runat="server" Text="Show All Free Members" CssClass="btn btn-success" OnClick="btn_Submit_Click" />
                            </div>
                            <div class="span12" style="text-align: center;">
                                <asp:Label ID="lbl_message" runat="server" CssClass="label label-warning"></asp:Label>
                            </div>
                        </div>
                        <asp:Panel ID="pnl_view" Visible="false" runat="server">
                            <div class="row-fluid">
                                <asp:GridView ID="grd_view" runat="server" CssClass="table table-bordered data-table dataTable"
                                    AutoGenerateColumns="false" AllowPaging="True" PageSize="50" OnRowCommand="grd_view_RowCommand"
                                    OnPageIndexChanging="grd_view_PageIndexChanging">
                                    <PagerStyle CssClass="pagination-sks" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr No.">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_sl" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Member Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_name" runat="server" Text='<%# Bind("Member_name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Member Code">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_member_code" runat="server" Text='<%# Bind("Member_code") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sponsor code">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_sponcer_code" runat="server" Text='<%# Bind("Sponcer_code") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <%--<asp:TemplateField HeaderText="Referal Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_referalname" runat="server" Text='<%# Bind("Referal_name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Purchase Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_date" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mobile No">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_mobile" runat="server" Text='<%#Bind("Mobile_number") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Proof Identity" Visible="false">
                                            <ItemTemplate>

                                                <a href='<%#Eval("Proof_identy") %>' target="_blank" style="padding: 25px 0px 0px 26px; background-image: url('../images/icon-download.png'); background-repeat: no-repeat; background-position: left top; font-family: ebrima; font-size: 14px; color: #0066CC; text-decoration: none;"></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Proof Address" Visible="false">
                                            <ItemTemplate>

                                                <a href='<%#Eval("proof_address") %>' target="_blank" style="padding: 25px 0px 0px 26px; background-image: url('../images/icon-download.png'); background-repeat: no-repeat; background-position: left top; font-family: ebrima; font-size: 14px; color: #0066CC; text-decoration: none;"></a>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="ID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_id" runat="server" Text='<%#Bind("Id") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="btnActivation" CssClass="btn btn-info" CommandArgument='<%#Bind("Member_code") %>' CommandName="IsActivate" runat="server" Text="Top-Up" />
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="btn btn-success" style="display: none;" id="sksButton" onclick="$('#gritter-notice-wrapper1').show().fadeOut(8000);">
        SKS
    </div>
    <div id="gritter-notice-wrapper1" style="display: none;">
        <div id="gritter-item-1" class="gritter-item-wrapper  hover" style="">
            <div class="gritter-top"></div>
            <div class="gritter-item">
                <div class="gritter-close" style="display: block;" onclick="$('#gritter-notice-wrapper1').fadeOut(500);"></div>
                <img src="../img/demo/envelope.png" class="gritter-image" />
                <div class="gritter-with-image">
                    <span class="gritter-title">Message</span>
                    <p>
                        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                    </p>
                </div>
                <div style="clear: both"></div>
            </div>
            <div class="gritter-bottom"></div>
        </div>
    </div>
</asp:Content>
