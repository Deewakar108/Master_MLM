<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="Total_left_right_joining.aspx.cs" Inherits="Master_MLM.Admin_87554b.Total_left_right_joining"
    Title="Total Left Right Joining " %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Total Left Right Joining
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

        function printTable2() {
            var printContent = document.getElementById("divPrint2");
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
                <a href="#" class="current">Total Left Right Joining</a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Total Left Right Joining</h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid">
                            <div class="span12" style="text-align: center;">
                                <asp:TextBox ID="txt_memberid" runat="server" placeholder="Member Code"  CssClass="span2"></asp:TextBox>
                                <asp:Button ID="btn_find" runat="server" Text="Find" OnClick="btn_find_Click" CssClass="btn btn-primary" Style="margin-bottom: 10px;" />
                            </div>
                            <div class="span12" style="text-align: center;">
                                <asp:Label ID="lbl_msg" runat="server" CssClass="label label-warning"></asp:Label>
                            </div>
                        </div>
                        <asp:Panel ID="panel_view_left_right_join" runat="server" Visible="false">
                            <asp:Panel ID="pnl_view" runat="server" Visible="false">
                                <div class="row-fluid">
                                    <div class="span12" style="text-align: center;">
                                        <asp:Image ID="Img_member" runat="server" Height="128px" Width="130px" Style="border: solid 3px #F88201;" />
                                        <br />
                                        <asp:Label ID="lbl_name" runat="server" CssClass="label label-default"></asp:Label>
                                    </div>
                                </div>
                                <div class="row-fluid">
                                    <div class="widget-box">
                                        <div class="widget-title bg_lg">
                                            <span class="icon"><i class="icon-signal"></i></span>
                                            <span class="icon-right"><i class="icon-print" onclick="$('#<%= print1.ClientID %>').click();"></i></span>
                                            <span class="icon-right"><i class="icon-save" onclick="$('#<%= img_export.ClientID %>').click();"></i></span>
                                            <h5>Left Genealogy</h5>
                                        </div>
                                        <div class="widget-content">
                                            <div style="display: none;">
                                                <asp:LinkButton ID="print1" OnClientClick="printTable();" runat="server">
                                    <img src="../images/printer.png" height="25" width="25" border="0" alt=" " /></asp:LinkButton>
                                                <asp:ImageButton ID="img_export" runat="server" Height="32px" ImageUrl="~/images/Excelicons.png"
                                                    Style="margin-left: 20px" OnClick="img_export_Click" />
                                            </div>
                                            <div class="row-fluid" id="tblPrintIQ">
                                                <div class="span12" style="text-align: center;">
                                                    Total Left Member :
                                                    <asp:Label ID="lbl_left" runat="server" CssClass="label label-warning"></asp:Label>
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
                                                                <%-- <asp:Label ID="lblMemberCode" runat="server" Text='<%#Bind("MemberCode") %>'></asp:Label>--%>
                                                                <asp:Label ID="lblMemberCode" runat="server" Text='<%#hide_string(Eval("MemberCode").ToString()) %>'></asp:Label>

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
                                                        <asp:TemplateField HeaderText="S. Name">
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
                                                        <asp:TemplateField HeaderText="verified Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblverified_Date" runat="server" Text='<%#Bind("verified_Date") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Placement">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblplacement" runat="server" Text='<%#Bind("Placement") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Package" Visible="false">
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
                                        </div>
                                    </div>
                                </div>
                                <div class="row-fluid">
                                    <div class="widget-box">
                                        <div class="widget-title bg_lg">
                                            <span class="icon"><i class="icon-signal"></i></span>
                                            <span class="icon-right"><i class="icon-print" onclick="$('#<%= print.ClientID %>').click();"></i></span>
                                            <span class="icon-right"><i class="icon-save" onclick="$('#<%= ImageButton1.ClientID %>').click();"></i></span>
                                            <h5>Right Genealogy</h5>
                                        </div>
                                        <div class="widget-content">
                                            <div style="display: none;">
                                                <asp:LinkButton ID="print" OnClientClick="printTable1();" runat="server">
                                    <img src="../images/printer.png" height="25" width="25" border="0" alt=" " /></asp:LinkButton>
                                                <asp:ImageButton ID="ImageButton1" runat="server" Height="32px" ImageUrl="~/images/Excelicons.png"
                                                    Style="margin-left: 20px" OnClick="ImageButton1_Click" />
                                            </div>
                                            <div class="row-fluid" id="tblPrintIQ1">
                                                <div class="span12" style="text-align: center;">
                                                    Total Right Member :
                                                    <asp:Label ID="lbl_right" runat="server" CssClass="label label-warning"></asp:Label>
                                                </div>
                                                <asp:GridView ID="grd_right" runat="server" CssClass="table table-bordered data-table dataTable"
                                                    AutoGenerateColumns="False" AllowSorting="True"
                                                    OnSorting="grd_right_Sorting">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Sr No.">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_sl" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ID">
                                                            <ItemTemplate>
                                                                <%-- <asp:Label ID="lblMemberCode" runat="server" Text='<%#Bind("MemberCode") %>'></asp:Label>--%>
                                                                <asp:Label ID="lblMemberCode" runat="server" Text='<%#hide_string(Eval("MemberCode").ToString()) %>'></asp:Label>

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
                                                        <asp:TemplateField HeaderText="S. Name">
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
                                                        <asp:TemplateField HeaderText="verified Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblverified_Date" runat="server" Text='<%#Bind("verified_Date") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Placement">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblplacement" runat="server" Text='<%#Bind("Placement") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Package" Visible="false">
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
                                        </div>
                                    </div>
                                </div>

                                <div class="row-fluid" style="display: none;">
                                    <div class="widget-box">
                                        <div class="widget-title bg_lg">
                                            <span class="icon"><i class="icon-signal"></i></span>
                                            <span class="icon-right"><i class="icon-print" onclick="$('#<%= LinkButton1.ClientID %>').click();"></i></span>
                                            <span class="icon-right"><i class="icon-save" onclick="$('#<%= ImageButton2.ClientID %>').click();"></i></span>
                                            <h5>Middle Genealogy</h5>
                                        </div>
                                        <div class="widget-content">
                                            <div style="display: none;">
                                                <asp:LinkButton ID="LinkButton1" OnClientClick="printTable2();" runat="server">
                                    <img src="../images/printer.png" height="25" width="25" border="0" alt=" " /></asp:LinkButton>
                                                <asp:ImageButton ID="ImageButton2" runat="server" Height="32px" ImageUrl="~/images/Excelicons.png"
                                                    Style="margin-left: 20px" OnClick="ImageButton1_Click" />
                                            </div>
                                            <div class="row-fluid" id="divPrint2">
                                                <div class="span12" style="text-align: center;">
                                                    Total Middle Member :
                                                    <asp:Label ID="lblMiddleMember" runat="server" CssClass="label label-warning"></asp:Label>
                                                </div>
                                                <asp:GridView ID="grdMiddleMember" runat="server" CssClass="table table-bordered data-table dataTable"
                                                    AutoGenerateColumns="False" AllowSorting="True"
                                                    >
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Sr No.">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbl_sl" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ID">
                                                            <ItemTemplate>
                                                                <%-- <asp:Label ID="lblMemberCode" runat="server" Text='<%#Bind("MemberCode") %>'></asp:Label>--%>
                                                                <asp:Label ID="lblMemberCode" runat="server" Text='<%#hide_string(Eval("MemberCode").ToString()) %>'></asp:Label>

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
                                                        <asp:TemplateField HeaderText="S. Name">
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
                                                        <asp:TemplateField HeaderText="verified Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblverified_Date" runat="server" Text='<%#Bind("verified_Date") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Placement">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblplacement" runat="server" Text='<%#Bind("Placement") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Package" Visible="false">
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
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>

                        </asp:Panel>
                        <%-- <div class="row-fluid">
                            <div class="row" style="padding: 0px 0px 0px 0px;">
        <div style="margin: 0px; padding: 0px; width: 100%; height: auto; float: left;">
            
            
                <div style="margin: 0px; padding: 0px; width: 100%; height: auto; float: left;">
                    <div style="margin: 0px 0px 0px 0px; padding: 30px 0px 0px 0px; float: left; width: 100%; height: auto;">
                        <table style="margin: 0px auto; width: 950px" cellpadding="0" cellspacing="0" border="0">
                            <tbody>
                                <tr>
                                    <td valign="bottom">&nbsp;
                                    </td>
                                    <td valign="top" width="250" style="text-align: center">
                                        <table border="0" cellpadding="0" cellspacing="0" style="margin: 0px; width: 100%; height: 117px;">
                                            <tr>
                                                <td>
                                                    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-top: 5px">
                                                    
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td valign="bottom">&nbsp;
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div style="margin: 0px 0px 10px 0px; padding: 0px; float: left; width: 100%; height: auto;">
                        <div style="margin: 0px 0px 0px 0px; padding: 0px 0px 0px 0px; float: left; width: 100%; height: auto;">
                            
                                <div style="margin: 0px 0px 0px 0px; padding: 10px; float: left; width: 1000px; height: auto;">
                                    <div style="background-image: url('../images/icons/Arrow_blue.png'); background-repeat: no-repeat; background-position: center bottom; 
                                        margin: 0px; padding: 0px 0px 90px 0px; width: 280px; height: auto">
                                        <table class="leftdown">
                                            <tbody>
                                                <tr>
                                                    <td align="left" style="padding: 5px 0px 0px 20px; width: 170px; vertical-align: central">Total Left Member :-
                                                    </td>
                                                    <td align="left" style="padding: 5px 0px 0px 0px; vertical-align: central">
                                                        
                                                    </td>
                                                </tr>

                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                                <div class="row">

                                    

                                    <table style="width: 1032px; height: auto; margin: 0px; border-spacing: 0px; float: left; background-color: #fff"
                                        border="0" cellpadding="0" cellspacing="0" class="round">
                                        <tr>
                                            <td style="border-bottom: 1px solid #CCCCCC; padding: 10px 0px 10px 20px; font-weight: bold;"
                                                valign="top" class=" login_bg">
                                                <h2 style="text-align: left; width: 85%; margin: 0px; float: left;">Left Genealogy
                                                </h2>
                                                <h2 style="text-align: center; width: 15%; margin: 0px; float: left;" class="noPrint">
                                                    
                                                </h2>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div class="scrollbar" style="margin: 0px 0px 10px 0px; padding: 10px; float: left; width: 1000px;  background-color: #FFFFFF;">
                                                    <div style="margin: 0px 0px 0px 0px; padding: 0px; float: left; width: 100%; height: auto; background-color: White;"
                                                        class="round">
                                                        
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div style="margin: 0px 0px 0px 0px; padding: 10px; float: left; width: 1000px; height: auto;">
                                    <div style="background-image: url('../images/icons/Arrow_blue.png'); background-repeat: no-repeat; background-position: center bottom; margin: 0px; padding: 0px 0px 90px 0px; width: 296px; height: auto; float: left">
                                        <table class="rightdown" align="right">
                                            <tbody>
                                                <tr>
                                                    <td style="text-align:left; padding: 5px 0px 0px 20px; width: 170px;vertical-align:central"" >-
                                                    </td>
                                                    <td style="text-align: left; padding-top: 5px;vertical-align:central"  >
                                                       
                                                    </td>
                                                    <td style="text-align: center">&nbsp;
                                                    </td>
                                                </tr>
                                                
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                                <div class="row">

                                    

                                    <table style="width: 1032px; height: auto; margin: 0px; border-spacing: 0px; float: left; background-color: #fff;"
                                        border="0" cellpadding="0" cellspacing="0" class="round">
                                        <tr>
                                            <td style="border-bottom: 1px solid #CCCCCC; padding: 10px 0px 10px 20px; font-weight: bold;"
                                                valign="top" class=" login_bg">
                                                <h2 style="text-align: left; width: 85%; margin: 0px; float: left;">Right Genealogy
                                                </h2>
                                                <h2 style="text-align: center; width: 15%; margin: 0px; float: left;" class="noPrint">
                                                    
                                                </h2>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div class="scrollbar" style="margin: 0px 0px 10px 9px; padding: 10px; float: left; width: 1000px;  background-color: #FFFFFF;">
                                                    <div style="margin: 0px 0px 0px 0px; padding: 0px; float: left; width: 100%; height: auto; background-color: White;"
                                                        class="round">
                                                        
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            
                        </div>
                    </div>
                </div>
            
        </div>
    </div>
                        </div>
                        <div class="row-fluid">

                        </div>
                        <div class="row-fluid">

                        </div>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
