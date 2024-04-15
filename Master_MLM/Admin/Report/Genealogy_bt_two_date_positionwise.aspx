<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="Genealogy_bt_two_date_positionwise.aspx.cs" Inherits="Master_MLM.Admin.Genealogy_bt_two_date_positionwise"
    Title="Genealogy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Genealogy
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

        .gridview a {
            display: inline-block;
            margin: 0px 3px 0px 0px;
            padding: 5px 5px 5px 5px;
            background: #336699;
            background: -webkit-gradient(linear, left bottom, left top, color-stop(0, #336699), color-stop(1, #ffffff));
            background: -ms-linear-gradient(bottom, #336699, #ffffff);
            background: -moz-linear-gradient(center bottom, #336699 0%, #ffffff 100%);
            background: -o-linear-gradient(#ffffff, #336699);
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr= '#ffffff', endColorstr= '#336699', GradientType=0);
            font-weight: bold;
            width: auto;
            text-decoration: none;
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
                <a href="#" class="current">Report</a>
                <a href="#" class="current">Member Genealogy Date Wise</a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <span class="icon-right"><i class="icon-print" onclick="$('#<%= print1.ClientID %>').click();"></i></span>
                        <span class="icon-right"><i class="icon-save" onclick="$('#<%= img_export.ClientID %>').click();"></i></span>
                        <h5>Member Genealogy Date Wise</h5>
                    </div>
                    <div class="widget-content">
                        <div style="display: none">
                            <asp:LinkButton ID="print1" OnClientClick="printTable();" runat="server" Style="margin-right: 20px; float: right">
                                    <img src="../images/printer.png" height="25" width="25" border="0" alt=" " /></asp:LinkButton>
                            <asp:ImageButton ID="img_export" runat="server" Height="32px" ImageUrl="~/images/Excelicons.png"
                                Style="margin-right: 15px; float: right" OnClick="img_export_Click" />
                        </div>
                        <div class="row-fluid">
                            <div class="span12" style="text-align: center;">
                                Member Code :
                                <asp:TextBox ID="txt_memberid" runat="server" placeholder="Member code" ></asp:TextBox>
                            </div>
                            <div class="span12" style="text-align: center;">
                                Position :
                                <asp:DropDownList ID="ddl_position" runat="server" CssClass="span2">
                                    <asp:ListItem>Left</asp:ListItem>
                                    <%--<asp:ListItem>Middle</asp:ListItem>--%>
                                    <asp:ListItem>Right</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="span12" style="text-align: center;">
                                From :
                                <asp:DropDownList ID="ddl_s_date" runat="server" CssClass="span1">
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
                                    <asp:ListItem>13</asp:ListItem>
                                    <asp:ListItem>14</asp:ListItem>
                                    <asp:ListItem>15</asp:ListItem>
                                    <asp:ListItem>16</asp:ListItem>
                                    <asp:ListItem>17</asp:ListItem>
                                    <asp:ListItem>18</asp:ListItem>
                                    <asp:ListItem>19</asp:ListItem>
                                    <asp:ListItem>20</asp:ListItem>
                                    <asp:ListItem>21</asp:ListItem>
                                    <asp:ListItem>22</asp:ListItem>
                                    <asp:ListItem>23</asp:ListItem>
                                    <asp:ListItem>24</asp:ListItem>
                                    <asp:ListItem>25</asp:ListItem>
                                    <asp:ListItem>26</asp:ListItem>
                                    <asp:ListItem>27</asp:ListItem>
                                    <asp:ListItem>28</asp:ListItem>
                                    <asp:ListItem>29</asp:ListItem>
                                    <asp:ListItem>30</asp:ListItem>
                                    <asp:ListItem>31</asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;
                            <asp:DropDownList ID="ddl_s_month" runat="server" CssClass="span1">
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
                            <asp:DropDownList ID="ddl_s_year" runat="server" CssClass="span2">
                            </asp:DropDownList>
                            </div>
                            <div class="span12" style="text-align: center;">
                                To :
                                <asp:DropDownList ID="ddl_e_date" runat="server" CssClass="span1">
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
                                    <asp:ListItem>13</asp:ListItem>
                                    <asp:ListItem>14</asp:ListItem>
                                    <asp:ListItem>15</asp:ListItem>
                                    <asp:ListItem>16</asp:ListItem>
                                    <asp:ListItem>17</asp:ListItem>
                                    <asp:ListItem>18</asp:ListItem>
                                    <asp:ListItem>19</asp:ListItem>
                                    <asp:ListItem>20</asp:ListItem>
                                    <asp:ListItem>21</asp:ListItem>
                                    <asp:ListItem>22</asp:ListItem>
                                    <asp:ListItem>23</asp:ListItem>
                                    <asp:ListItem>24</asp:ListItem>
                                    <asp:ListItem>25</asp:ListItem>
                                    <asp:ListItem>26</asp:ListItem>
                                    <asp:ListItem>27</asp:ListItem>
                                    <asp:ListItem>28</asp:ListItem>
                                    <asp:ListItem>29</asp:ListItem>
                                    <asp:ListItem>30</asp:ListItem>
                                    <asp:ListItem>31</asp:ListItem>
                                </asp:DropDownList>
                                &nbsp;
                            <asp:DropDownList ID="ddl_e_month" runat="server" CssClass="span1">
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
                            <asp:DropDownList ID="ddl_e_year" runat="server" CssClass="span2">
                            </asp:DropDownList>
                            </div>
                            <div class="span12" style="text-align: center;">
                                <asp:Button ID="btn_find" runat="server" Text="Find" OnClick="btn_find_Click" CssClass="btn btn-primary" />
                            </div>
                            <div class="span12" style="text-align: center;">
                                <asp:Label ID="lbl_msg" runat="server" CssClass="label label-warning"></asp:Label>
                            </div>
                        </div>

                        <asp:Panel ID="panel_view_left_right_join" runat="server" Visible="false">
                            <div class="row-fluid" id="tblPrintIQ">
                                <div class="span12">
                                    Member :
                                <asp:Label ID="lbl_name" runat="server" CssClass="label label-warning"></asp:Label>
                                </div>


                                <asp:GridView ID="grd_left" runat="server" CssClass="table table-bordered data-table dataTable"
                                    AutoGenerateColumns="False" AllowSorting="True"
                                    OnSorting="grd_left_Sorting">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr No.">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_sl" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ID">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMemberCode" runat="server" Text='<%#Bind("MemberCode") %>'></asp:Label>

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText=" Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMemberName" runat="server" Text='<%#Bind("MemberName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sponsor">
                                            <ItemTemplate>
                                                <asp:Label ID="lblsponsorCode" runat="server" Text='<%#Bind("Sponsorcode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sponsor Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblsponsorName" runat="server" Text='<%#Bind("Sponsorname") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText=" D.O.J" SortExpression="idate">
                                            <ItemTemplate>
                                                <asp:Label ID="lbljoiningdate" runat="server" Text='<%#Bind("DOJ") %>'></asp:Label>
                                                <asp:Label ID="lblddd" runat="server" Text='<%#Bind("idate") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>








                                        <asp:TemplateField HeaderText="Placement">
                                            <ItemTemplate>
                                                <asp:Label ID="lblplacement" runat="server" Text='<%#Bind("Placement") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Package">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPackage" runat="server" Text='<%#Bind("Package") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PV" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPoint" runat="server" Text='<%#Bind("Point") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAmount" runat="server" Text='<%#Bind("Amount") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <div class="row-fluid">
                                <div class="span12">
                                    <asp:Label ID="lbl_left" runat="server" CssClass="label label-warning"></asp:Label><br />
                                    <asp:Label ID="lbl_total_point" runat="server" Visible="false" CssClass="label label-warning"></asp:Label>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
