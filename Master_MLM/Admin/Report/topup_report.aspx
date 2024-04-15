<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="topup_report.aspx.cs" Inherits="Master_MLM.Admin_87554b.topup_report"
    Title="Topup Report" ValidateRequest="false" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Topup Report
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
                <a href="#" class="current">Member</a>
                <a href="#" class="current">Topup Report</a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <span class="icon-right"><i class="icon-print" onclick="$('#<%= print1.ClientID %>').click();"></i></span>
                        <span class="icon-right"><i class="icon-save" onclick="$('#<%= img_expord.ClientID %>').click();"></i></span>
                        <h5>Topup Report</h5>
                    </div>
                    <div class="widget-content">
                        <div style="display: none;">
                            <asp:LinkButton ID="print1" OnClientClick="printTable();" runat="server">
                                    <img src="../images/printer.png" height="25" width="25" border="0" alt=" " /></asp:LinkButton>
                            <asp:ImageButton ID="img_expord" runat="server" Height="32px" ImageUrl="~/images/Excelicons.png"
                                Style="margin-left: 0px; float: right;" OnClick="img_expord_Click" />
                        </div>
                        <div class="span12" style="text-align: center;">
                            Start Date : 
                                <asp:DropDownList ID="ddlStartDate" runat="server" CssClass="span1">
                                    <asp:ListItem Value="01" Text="01">01</asp:ListItem>
                                    <asp:ListItem Value="02" Text="02">02</asp:ListItem>
                                    <asp:ListItem Value="03" Text="03">03</asp:ListItem>
                                    <asp:ListItem Value="04" Text="04">04</asp:ListItem>
                                    <asp:ListItem Value="05" Text="05">05</asp:ListItem>
                                    <asp:ListItem Value="06" Text="06">06</asp:ListItem>
                                    <asp:ListItem Value="07" Text="07">07</asp:ListItem>
                                    <asp:ListItem Value="08" Text="08">08</asp:ListItem>
                                    <asp:ListItem Value="09" Text="09">09</asp:ListItem>
                                    <asp:ListItem Value="10" Text="10">10</asp:ListItem>
                                    <asp:ListItem Value="11" Text="11">11</asp:ListItem>
                                    <asp:ListItem Value="12" Text="12">12</asp:ListItem>
                                    <asp:ListItem Value="13" Text="13">13</asp:ListItem>
                                    <asp:ListItem Value="14" Text="14">14</asp:ListItem>
                                    <asp:ListItem Value="15" Text="15">15</asp:ListItem>
                                    <asp:ListItem Value="16" Text="16">16</asp:ListItem>
                                    <asp:ListItem Value="17" Text="17">17</asp:ListItem>
                                    <asp:ListItem Value="18" Text="18">18</asp:ListItem>
                                    <asp:ListItem Value="19" Text="19">19</asp:ListItem>
                                    <asp:ListItem Value="20" Text="20">20</asp:ListItem>
                                    <asp:ListItem Value="21" Text="21">21</asp:ListItem>
                                    <asp:ListItem Value="22" Text="22">22</asp:ListItem>
                                    <asp:ListItem Value="23" Text="23">23</asp:ListItem>
                                    <asp:ListItem Value="24" Text="24">24</asp:ListItem>
                                    <asp:ListItem Value="25" Text="25">25</asp:ListItem>
                                    <asp:ListItem Value="26" Text="26">26</asp:ListItem>
                                    <asp:ListItem Value="27" Text="27">27</asp:ListItem>
                                    <asp:ListItem Value="28" Text="28">28</asp:ListItem>
                                    <asp:ListItem Value="29" Text="29">29</asp:ListItem>
                                    <asp:ListItem Value="30" Text="30">30</asp:ListItem>
                                    <asp:ListItem Value="31" Text="31">31</asp:ListItem>
                                </asp:DropDownList>
                            <asp:DropDownList ID="ddlStartMonth" runat="server" CssClass="span1">
                                <asp:ListItem Value="01" Text="01">01</asp:ListItem>
                                <asp:ListItem Value="02" Text="02">02</asp:ListItem>
                                <asp:ListItem Value="03" Text="03">03</asp:ListItem>
                                <asp:ListItem Value="04" Text="04">04</asp:ListItem>
                                <asp:ListItem Value="05" Text="05">05</asp:ListItem>
                                <asp:ListItem Value="06" Text="06">06</asp:ListItem>
                                <asp:ListItem Value="07" Text="07">07</asp:ListItem>
                                <asp:ListItem Value="08" Text="08">08</asp:ListItem>
                                <asp:ListItem Value="09" Text="09">09</asp:ListItem>
                                <asp:ListItem Value="10" Text="10">10</asp:ListItem>
                                <asp:ListItem Value="11" Text="11">11</asp:ListItem>
                                <asp:ListItem Value="12" Text="12">12</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlStartYear" runat="server" CssClass="span2">
                                <asp:ListItem Value="2018" Text="2018">2018</asp:ListItem>
                                <asp:ListItem Value="2019" Text="2019">2019</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="span12" style="text-align: center;">
                            End Date : 
                                <asp:DropDownList ID="ddlEndDate" runat="server" CssClass="span1">
                                    <asp:ListItem Value="01" Text="01">01</asp:ListItem>
                                    <asp:ListItem Value="02" Text="02">02</asp:ListItem>
                                    <asp:ListItem Value="03" Text="03">03</asp:ListItem>
                                    <asp:ListItem Value="04" Text="04">04</asp:ListItem>
                                    <asp:ListItem Value="05" Text="05">05</asp:ListItem>
                                    <asp:ListItem Value="06" Text="06">06</asp:ListItem>
                                    <asp:ListItem Value="07" Text="07">07</asp:ListItem>
                                    <asp:ListItem Value="08" Text="08">08</asp:ListItem>
                                    <asp:ListItem Value="09" Text="09">09</asp:ListItem>
                                    <asp:ListItem Value="10" Text="10">10</asp:ListItem>
                                    <asp:ListItem Value="11" Text="11">11</asp:ListItem>
                                    <asp:ListItem Value="12" Text="12">12</asp:ListItem>
                                    <asp:ListItem Value="13" Text="13">13</asp:ListItem>
                                    <asp:ListItem Value="14" Text="14">14</asp:ListItem>
                                    <asp:ListItem Value="15" Text="15">15</asp:ListItem>
                                    <asp:ListItem Value="16" Text="16">16</asp:ListItem>
                                    <asp:ListItem Value="17" Text="17">17</asp:ListItem>
                                    <asp:ListItem Value="18" Text="18">18</asp:ListItem>
                                    <asp:ListItem Value="19" Text="19">19</asp:ListItem>
                                    <asp:ListItem Value="20" Text="20">20</asp:ListItem>
                                    <asp:ListItem Value="21" Text="21">21</asp:ListItem>
                                    <asp:ListItem Value="22" Text="22">22</asp:ListItem>
                                    <asp:ListItem Value="23" Text="23">23</asp:ListItem>
                                    <asp:ListItem Value="24" Text="24">24</asp:ListItem>
                                    <asp:ListItem Value="25" Text="25">25</asp:ListItem>
                                    <asp:ListItem Value="26" Text="26">26</asp:ListItem>
                                    <asp:ListItem Value="27" Text="27">27</asp:ListItem>
                                    <asp:ListItem Value="28" Text="28">28</asp:ListItem>
                                    <asp:ListItem Value="29" Text="29">29</asp:ListItem>
                                    <asp:ListItem Value="30" Text="30">30</asp:ListItem>
                                    <asp:ListItem Value="31" Text="31">31</asp:ListItem>
                                </asp:DropDownList>
                            <asp:DropDownList ID="ddlEndMonth" runat="server" CssClass="span1">
                                <asp:ListItem Value="01" Text="01">01</asp:ListItem>
                                <asp:ListItem Value="02" Text="02">02</asp:ListItem>
                                <asp:ListItem Value="03" Text="03">03</asp:ListItem>
                                <asp:ListItem Value="04" Text="04">04</asp:ListItem>
                                <asp:ListItem Value="05" Text="05">05</asp:ListItem>
                                <asp:ListItem Value="06" Text="06">06</asp:ListItem>
                                <asp:ListItem Value="07" Text="07">07</asp:ListItem>
                                <asp:ListItem Value="08" Text="08">08</asp:ListItem>
                                <asp:ListItem Value="09" Text="09">09</asp:ListItem>
                                <asp:ListItem Value="10" Text="10">10</asp:ListItem>
                                <asp:ListItem Value="11" Text="11">11</asp:ListItem>
                                <asp:ListItem Value="12" Text="12">12</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlEndYear" runat="server" CssClass="span2">
                                <asp:ListItem Value="2018" Text="2018">2018</asp:ListItem>
                                <asp:ListItem Value="2019" Text="2019">2019</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <%--<div class="span12" style="text-align: center;">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" Style="margin-bottom: 10px;" OnClientClick="return OnClick();" CssClass="btn btn-success"
                                OnClick="btnSubmit_Click" />
                            <br />
                            <br />
                            <asp:Label ID="lblMessage" runat="server" CssClass="label label-warning"></asp:Label>
                        </div>--%>
                        <div class="row-fluid">
                            <div class="span12" style="text-align: center;">
                                <asp:Button ID="btn_find" runat="server" Text="Show All Paid Members" CssClass="btn btn-success" OnClick="btn_Submit_Click" />
                            </div>
                            <div class="span12" style="text-align: center;">
                                <br /><br />
                                <asp:Label ID="lbl_message" runat="server" CssClass="label label-warning"></asp:Label>
                            </div>
                        </div>

                        <asp:Panel ID="pnl_view" Visible="false" runat="server">
                            <div class="row-fluid" id="tblPrintIQ">
                                <asp:GridView ID="grd_view" runat="server" CssClass="table table-bordered data-table dataTable" AutoGenerateColumns="false"
                                    AllowPaging="True" PageSize="50"
                                    OnPageIndexChanging="grd_view_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr No.">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_sl" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
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
                                        <asp:TemplateField HeaderText="Mobile No">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_mobile" runat="server" Text='<%#Bind("Mobile_number") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sponsor code">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_sponcer_code" runat="server" Text='<%# Bind("Sponcer_code") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Topup Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Joiningtime" runat="server" Text='<%# Bind("ActivationDate") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Package">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_joining_package" runat="server" Text='<%# Bind("Package") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField HeaderText="Verification Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Verification_date" runat="server" Text='<%# Bind("Verification_date") %>'></asp:Label>
                                                &nbsp;&nbsp;
                                              <asp:Label ID="lbl_Verification_time" runat="server" Text='<%# Bind("Verification_time") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_id" runat="server" Text='<%#Bind("Id") %>'></asp:Label>
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

</asp:Content>
