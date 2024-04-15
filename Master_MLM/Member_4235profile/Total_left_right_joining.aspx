<%@ Page Title="Total Left Right Joining" Language="C#" MasterPageFile="~/Member_4235profile/Member_main.Master" AutoEventWireup="true"
    CodeBehind="Total_left_right_joining.aspx.cs" Inherits="Master_MLM.Member_4235profile.Total_left_right_joining" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/mygrid.css" rel="stylesheet" />
    <style type="text/css">
        .ddsmoothmenu ul li a.fourth {
            color: #ffffff;
            background: #0597D5;
            background: url( 'menu.png' ) repeat left top #007AC5;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="index.html">Home</a> <i class="fa fa-angle-right"></i></li>
    </ol>

    <div class="grid-form">
        <div class="grid-form1">
            <h4 class="breadcrumb-item"><a>Total Left-Right Joining</a></h4>
            <div class="panel-body panel-footer">
                <div style="margin: 0px 0px 0px 0px; padding: 30px 0px 0px 0px; float: left; width: 100%; height: auto;">
                    <table border="0" cellpadding="0" cellspacing="0" style="margin: 0px; width: 100%;">
                        <tr>
                            <td style="text-align: center;">
                                <asp:Image ID="Img_member" runat="server" Height="128px" Width="130px" Style="border: solid 1px #44B6AE; padding: 10px;" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center; padding-top: 5px">
                                <asp:Label ID="lbl_name" runat="server" Font-Bold="True" Font-Size="14pt" ForeColor="#44B6AE"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>



    <div class="grid-form">
        <div class="grid-form1">
            <h4 class="breadcrumb-item"><a>Left Genealogy &nbsp; &nbsp;(
                <span style="font-size: 10px;">Total Left Member :- &nbsp; 
                    <asp:Label ID="lbl_left" runat="server" Text="0" Style="color: #100e0e;"></asp:Label></span>) 
            </a></h4>
            <div class="panel-body panel-footer" style="overflow-y: auto;">
                <div style="margin: 0px 0px 10px 0px; padding: 0px; float: left; width: 100%; height: auto;">
                    <div style="margin: 0px 0px 0px 0px; padding: 0px 0px 0px 0px; float: left; width: 100%; height: auto;">
                        <asp:Panel ID="pnl_view" runat="server" Visible="false" Style="margin: 0px auto; padding: 10px; height: auto;"
                            Width="100%">

                            <div class="row">

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
                                <div id="tblPrintIQ" style="margin: 0px 0px 0px 0px; padding: 0px; float: left; width: 100%; height: auto; background-color: White;"
                                    class="round">
                                    <asp:GridView ID="grd_left" runat="server" Style="margin: 0px auto; font: normal 13px ebrima; height: auto; text-align: center; width: 100%;"
                                        AutoGenerateColumns="False" AllowSorting="True" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                                        HeaderStyle-CssClass="header" RowStyle-CssClass="rows"
                                        OnSorting="grd_left_Sorting" OnRowDataBound="grd_left_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_sl" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ID">
                                                <ItemTemplate>
                                                    <%-- Text='<%# getCompliance(Eval("Field1"),Eval("Field2")) %>'Text='<%#Bind("MemberCode") %>'--%>
                                                    <%--<asp:Label ID="lblMemberCode" runat="server" Text='<%#hide_string(Eval("MemberCode").ToString()) %>'></asp:Label>--%>
                                                    <asp:Label ID="lblMemberCode" runat="server" Text='<%# Bind("MemberCode") %>'></asp:Label>
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
                                            <asp:TemplateField HeaderText="S. Name" Visible="false">
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
                                            <asp:TemplateField HeaderText="Activation date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_activationdate" runat="server" Text='<%#Bind("Verification_date") %>'></asp:Label>
                                                    &nbsp;&nbsp;
                                                                                                    <asp:Label ID="lbltime" runat="server" Text='<%#Bind("Verification_time") %>'></asp:Label>


                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle BackColor="#333333" ForeColor="White" Font-Size="13px" />
                                        <PagerStyle CssClass="pager" />
                                        <RowStyle CssClass="rows" />
                                    </asp:GridView>
                                </div>

                            </div>

                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--Left-->


    <div class="grid-form">
        <div class="grid-form1">
            <h4 class="breadcrumb-item"><a>Right Genealogy &nbsp; &nbsp;(
                <span style="font-size: 10px;">Total Right Member :- &nbsp;
                    <asp:Label ID="lbl_right" runat="server" Text="0" Style="color: #100e0e;"></asp:Label></span>) 
            </a></h4>
            <div class="panel-body panel-footer" style="overflow-y: auto;">
                <div style="margin: 0px 0px 10px 0px; padding: 0px; float: left; width: 100%; height: auto;">
                    <div style="margin: 0px 0px 0px 0px; padding: 0px 0px 0px 0px; float: left; width: 100%; height: auto;">
                        <asp:Panel ID="pnlRight" runat="server" Visible="false" Style="margin: 0px auto; padding: 10px; height: auto;" Width="100%">

                            <div class="row">

                                <script type="text/javascript">
                                    function printTable1() {
                                        var printContent = document.getElementById("tblPrintIQ1");
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
                                <div id="tblPrintIQ1" style="margin: 0px 0px 0px 0px; padding: 0px; float: left; width: 100%; height: auto; background-color: White;"
                                    class="round">
                                    <asp:GridView ID="grd_right" runat="server" Style="margin: 0px auto; font: normal 13px ebrima; height: auto; text-align: center; width: 100%;"
                                        AutoGenerateColumns="False" AllowSorting="True" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                                        HeaderStyle-CssClass="header" RowStyle-CssClass="rows"
                                        OnSorting="grd_right_Sorting" OnRowDataBound="grd_right_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_sl" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ID">
                                                <ItemTemplate>
                                                    <%-- <asp:Label ID="lblMemberCode" runat="server" Text='<%#Bind("MemberCode") %>'></asp:Label>--%>
                                                    <%--<asp:Label ID="lblMemberCode" runat="server" Text='<%#hide_string(Eval("MemberCode").ToString()) %>'></asp:Label>--%>
                                                    <asp:Label ID="lblMemberCode" runat="server" Text='<%# Bind("MemberCode") %>'></asp:Label>
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
                                            <asp:TemplateField HeaderText="S. Name" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSponsorName" runat="server" Text='<%#Bind("Sponsorname") %>'></asp:Label>
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
                                                    <asp:Label ID="lblAmount" runat="server" Text='<%#Bind("Amount") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Activation date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_activationdate" runat="server" Text='<%#Bind("Verification_date") %>'></asp:Label>
                                                    &nbsp;&nbsp;
                                                                                                    <asp:Label ID="lbltime" runat="server" Text='<%#Bind("Verification_time") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle BackColor="#333333" ForeColor="White" Font-Size="13px" />
                                    </asp:GridView>
                                </div>

                            </div>

                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--Right-->


    <div class="grid-form" style="display: none;">
        <div class="grid-form1">
            <h4 class="breadcrumb-item"><a>Middle Genealogy &nbsp; &nbsp;(
                <span style="font-size: 10px;">Total Middle Member :- &nbsp;
                    <asp:Label ID="lblMiddleMember" runat="server" Text="0" Style="color: #100e0e;"></asp:Label></span>) 
            </a></h4>
            <div class="panel-body panel-footer" style="overflow-y: auto;">
                <div style="margin: 0px 0px 10px 0px; padding: 0px; float: left; width: 100%; height: auto;">
                    <div style="margin: 0px 0px 0px 0px; padding: 0px 0px 0px 0px; float: left; width: 100%; height: auto;">
                        <asp:Panel ID="pnlMiddle" runat="server" Visible="false" Style="margin: 0px auto; padding: 10px; height: auto;" Width="100%">

                            <div class="row">

                                <script type="text/javascript">
                                    function printTable1() {
                                        var printContent = document.getElementById("tblPrintIQ2");
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
                                <div id="tblPrintIQ2" style="margin: 0px 0px 0px 0px; padding: 0px; float: left; width: 100%; height: auto; background-color: White;"
                                    class="round">
                                    <asp:GridView ID="grdMiddle" runat="server" Style="margin: 0px auto; font: normal 13px ebrima; height: auto; text-align: center; width: 100%;"
                                        AutoGenerateColumns="False" AllowSorting="True" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                                        HeaderStyle-CssClass="header" RowStyle-CssClass="rows"
                                        OnSorting="grdMiddle_Sorting" OnRowDataBound="grdMiddle_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sr No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_sl" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ID">
                                                <ItemTemplate>
                                                    <%-- <asp:Label ID="lblMemberCode" runat="server" Text='<%#Bind("MemberCode") %>'></asp:Label>--%>
                                                    <%--<asp:Label ID="lblMemberCode" runat="server" Text='<%#hide_string(Eval("MemberCode").ToString()) %>'></asp:Label>--%>
                                                    <asp:Label ID="lblMemberCode" runat="server" Text='<%# Bind("MemberCode") %>'></asp:Label>
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
                                            <asp:TemplateField HeaderText="S. Name" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSponsorName" runat="server" Text='<%#Bind("Sponsorname") %>'></asp:Label>
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
                                            <asp:TemplateField HeaderText="PV">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPoint" runat="server" Text='<%#Bind("Point") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Amount">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAmount" runat="server" Text='<%#Bind("Amount") %>' Visible="false"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Activation date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_activationdate" runat="server" Text='<%#Bind("Verification_date") %>'></asp:Label>
                                                    &nbsp;&nbsp;
                                                                                                    <asp:Label ID="lbltime" runat="server" Text='<%#Bind("Verification_time") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle BackColor="#333333" ForeColor="White" Font-Size="13px" />
                                    </asp:GridView>
                                </div>

                            </div>

                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--Middle-->
</asp:Content>
