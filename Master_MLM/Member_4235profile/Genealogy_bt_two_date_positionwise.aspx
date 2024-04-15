<%@ Page Title="Genealogy" Language="C#" MasterPageFile="~/Member_4235profile/Member_main.Master" AutoEventWireup="true" CodeBehind="Genealogy_bt_two_date_positionwise.aspx.cs" Inherits="Master_MLM.Member_4235profile.Genealogy_bt_two_date_positionwise" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/mygrid.css" rel="stylesheet" />
    <style type="text/css">
        .ddsmoothmenu ul li a.fifth {
            background-color: #F700A9;
            color: #fff;
        }

        @media print {
            .noPrint {
                display: none;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="index.html">Home</a> <i class="fa fa-angle-right"></i></li>
    </ol>

    <div class="grid-form">
        <div class="grid-form1">
            <h4 class="breadcrumb-item"><a>Member Genealogy</a></h4>
            <div class="panel-body panel-footer">
                <div class="row" style="padding: 0px 0px 0px 0px;">
                    <div style="margin: 0px auto; padding: 0px; width: 100%; height: auto;">
                        <div style="margin: 0px; padding: 0px; width: 100%; height: auto; float: left;">

                            <div class="col-lg-4">
                            </div>
                            <div class="col-lg-4" style="padding: 10px 0px; border: 1px solid #5cb85c;">
                                <div class="col-lg-12" style="display: none;">
                                    <div class="form-group">
                                        <label for="txt_paename">Enter Member Code</label>
                                        <asp:TextBox ID="txt_memberid" CssClass="form-control" runat="server" placeholder="Enter member code" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <label>Select Position</label>
                                        <asp:DropDownList ID="ddl_position" runat="server" CssClass="form-control" Style="width: 100%;">
                                            <asp:ListItem>Left</asp:ListItem>
                                            <%--<asp:ListItem>Middle</asp:ListItem>--%>
                                            <asp:ListItem>Right</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-lg-12" style="padding-bottom: 10px;">
                                    <div class="form-group">
                                        <label style="float: left; width: 22%;">From</label>
                                        <asp:DropDownList ID="ddl_s_date" runat="server" CssClass="form-control" Style="color: Green; width: 60px; font-weight: bold; float: left;">
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
                            <asp:DropDownList ID="ddl_s_month" runat="server" CssClass="form-control" Style="float: left; color: Green; width: 60px; font-weight: bold;">
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
                            <asp:DropDownList ID="ddl_s_year" runat="server" CssClass="form-control" Style="color: Green; float: left; width: 70px; font-weight: bold;">
                            </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-lg-12" style="padding-bottom: 10px;">
                                    <div class="form-group">
                                        <label style="float: left; width: 22%;">To</label>
                                        <asp:DropDownList ID="ddl_e_date" runat="server" CssClass="form-control" Style="color: Green; float: left; width: 60px; font-weight: bold;">
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
                            <asp:DropDownList ID="ddl_e_month" runat="server" CssClass="form-control" Style="color: Green; float: left; width: 60px; font-weight: bold;">
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
                            <asp:DropDownList ID="ddl_e_year" runat="server" CssClass="form-control" Style="color: Green; float: left; width: 70px; font-weight: bold;">
                            </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <label>
                                            &nbsp; 
                                        <asp:Label ID="lbl_msg" runat="server" ForeColor="Red"></asp:Label></label>
                                        <asp:Button ID="btn_find" CssClass="btn btn-success" runat="server" Text="Find" OnClick="btn_find_Click"
                                            Width="100px" />
                                        &nbsp;
                                    </div>
                                </div>


                            </div>

                            <div class="col-lg-4">
                            </div>

                            <div class="col-lg-12" style="padding: 0px;">
                                <asp:Panel ID="panel_view_left_right_join" runat="server" Visible="false">
                                    <div style="margin: 0px; padding: 0px; width: 100%; height: auto; float: left; overflow-y: auto">
                                        <div style="margin: 0px 0px 0px 0px; padding: 30px 0px 0px 0px; float: left; width: 100%; height: auto;">
                                            <table style="margin: 0px auto; width: 100%; height: 15px;" cellpadding="0" cellspacing="0"
                                                border="0">
                                                <tbody>
                                                    <tr>
                                                        <td valign="top" style="text-align: center">
                                                            <asp:Label ID="lbl_name" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="#FF9900"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top" style="text-align: left">
                                                            <asp:Label ID="lbl_left" runat="server"></asp:Label>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="lbl_total_point" runat="server" Visible="false"></asp:Label>
                                                            <asp:ImageButton ID="img_export" runat="server" Height="32px" ImageUrl="~/images/Excelicons.png"
                                                                Style="margin-right: 20px; float: right" OnClick="img_export_Click" />
                                                            <asp:LinkButton ID="print1" OnClientClick="printTable();" runat="server" Style="margin-right: 10px; float: right;">
                                    <img src="../images/printer.png" height="25" width="25" border="0" alt=" " /></asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                        <div style="margin: 0px 0px 10px 0px; padding: 0px; float: left; width: 100%; height: auto;">

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

                                            <div id="tblPrintIQ" style="margin: 0px auto; padding: 0px; height: auto;">
                                                <asp:GridView ID="grd_left" runat="server" Style="margin: 0px auto; font: normal 13px ebrima; height: auto; text-align: center; width: 100%"
                                                    AutoGenerateColumns="False" AllowSorting="True" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                                                    HeaderStyle-CssClass="header" RowStyle-CssClass="rows"
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
                                                                <%--<asp:Label ID="lblMemberCode" runat="server" Text='<%#hide_string(Eval("MemberCode").ToString()) %>'></asp:Label>--%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText=" Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblMemberName" runat="server" Text='<%#Bind("MemberName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Sponsor" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblsponsorCode" runat="server" Text='<%#Bind("Sponsorcode") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Sponsor Name" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblsponsorName" runat="server" Text='<%#Bind("Sponsorname") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText=" D.O.J" SortExpression="idate" HeaderStyle-ForeColor="Blue">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbljoiningdate" runat="server" Text='<%#Bind("DOJ") %>'></asp:Label>
                                                                <asp:Label ID="lblddd" runat="server" Text='<%#Bind("idate") %>' Visible="false"></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle ForeColor="Blue" />
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
                                                                <asp:Label ID="lblPoint" runat="server" Text='<%#bind("Point") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Amount" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAmount" runat="server" Text='<%#Bind("Amount") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Amount Type" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAmountType" runat="server" Text='<%#Bind("AmountType") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Activation date">
                                                            <ItemTemplate>


                                                                <asp:Label ID="lbl_activationdate" runat="server" Text='<%#bind("Verification_date") %>'></asp:Label>
                                                                &nbsp;&nbsp;
                                                                                                       <asp:Label ID="lbltime" runat="server" Text='<%#bind("Verification_time") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>




                                                    </Columns>
                                                    <HeaderStyle BackColor="#333333" ForeColor="White" Font-Size="13px" />
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
    </div>


</asp:Content>
