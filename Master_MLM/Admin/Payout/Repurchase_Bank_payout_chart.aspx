<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="Repurchase_Bank_payout_chart.aspx.cs" Inherits="Master_MLM.Admin.Repurchase_Bank_payout_chart"
    Title="Repurchase Make Bank Payout" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Repurchase Make Bank Payout
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .ddsmoothmenu ul li a.seventh {
            color: #ffffff;
            background: #0597D5;
            background: url( 'menu.png' ) repeat left top #007AC5;
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
                <a href="#" class="current">Payout</a>
                <a href="#" class="current">Repurchase Make Bank Payout</a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <span class="icon-right"><i class="icon-print" onclick="$('#<%= print1.ClientID %>').click();"></i></span>
                        <span class="icon-right"><i class="icon-save" onclick="$('#<%= img_expord.ClientID %>').click();"></i></span>
                        <h5>Repurchase Make Bank Payout</h5>
                    </div>
                    <div class="widget-content">
                        <div style="display: none;">
                            <asp:LinkButton ID="print1" OnClientClick="printTable();" runat="server">
                                    <img src="../images/printer.png" height="25" width="25" border="0" /></asp:LinkButton>
                            <asp:ImageButton ID="img_expord" runat="server" Height="32px" ImageUrl="~/images/Excelicons.png"
                                Style="margin-left: 0px; float: right;" OnClick="img_expord_Click" />
                        </div>
                        <div class="row-fluid">
                            <div class="sapn12" style="text-align: center;">
                                <asp:Label ID="lbl_previous_date" runat="server" CssClass="label label-warning"></asp:Label>
                                <br />
                                <br />
                            </div>
                            <div class="sapn12" style="text-align: center;">
                                Select Month Date : 
                                 
                                &nbsp;
                            <asp:DropDownList ID="ddl_s_month" runat="server" CssClass="span1">
                                <asp:ListItem Value="01" Text="JAN">JAN</asp:ListItem>
                                <asp:ListItem Value="02" Text="FEB">FEB</asp:ListItem>
                                <asp:ListItem Value="03" Text="MAR">MAR</asp:ListItem>
                                <asp:ListItem Value="04" Text="APR">APR</asp:ListItem>
                                <asp:ListItem Value="05" Text="MAY">MAY</asp:ListItem>
                                <asp:ListItem Value="06" Text="JUN">JUN</asp:ListItem>
                                <asp:ListItem Value="07" Text="JUL">JUL</asp:ListItem>
                                <asp:ListItem Value="08" Text="AUG">AUG</asp:ListItem>
                                <asp:ListItem Value="09" Text="SEP">SEP</asp:ListItem>
                                <asp:ListItem Value="10" Text="OCT">OCT</asp:ListItem>
                                <asp:ListItem Value="11" Text="NOV">NOV</asp:ListItem>
                                <asp:ListItem Value="12" Text="DEC">DEC</asp:ListItem>
                            </asp:DropDownList>
                                &nbsp;
                            <asp:DropDownList ID="ddl_s_year" runat="server" CssClass="span2">
                            </asp:DropDownList>
                            </div>

                            <div class="sapn12" style="text-align: center;">
                                <asp:Button ID="btn_find" runat="server" OnClick="btn_find_Click" Text="Find" CssClass="btn btn-primary" />
                            </div>
                            <br />
                            <br />
                        </div>

                        <asp:Panel ID="pnl_view" Visible="false" runat="server">
                            <div class="row-fluid" id="tblPrintIQ">

                                <asp:GridView ID="grd_payout_list" runat="server" AutoGenerateColumns="False"
                                    CssClass="table table-bordered data-table dataTable">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr No.">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSRNO" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Member code">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Member_code" runat="server" Font-Names="Arial" Text='<%#Bind("Membercode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Name" runat="server" Font-Names="Arial" Text='<%#Bind("Membername") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Bank name">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_bank_name" runat="server" Font-Names="Arial" Text='<%#Bind("Bankname") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Branch name">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Branch_name" runat="server" Font-Names="Arial" Text='<%#Bind("Branchname") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Account no.">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Account_number" runat="server" Font-Names="Arial" Text='<%#Bind("Accountno") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ifsc code">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Ifsc_code" runat="server" Font-Names="Arial" Text='<%#Bind("Ifsccode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       
                                        <asp:TemplateField HeaderText="Total Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_totamount" runat="server" Font-Names="Arial" Text='<%#Bind("Totalamount") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Tds">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Tds" runat="server" Font-Names="Arial" Text='<%#Bind("Tds") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Cds">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Cds" runat="server" Font-Names="Arial" Text='<%#Bind("Cds") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       
                                        <asp:TemplateField HeaderText="Net Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Netmount" runat="server" Font-Names="Arial" Text='<%#Bind("Netmount") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Carryout">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Carryout" runat="server" Font-Names="Arial" Text='<%#Bind("Carryout") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       
                                        <asp:TemplateField HeaderText="Grand Total">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Grand_total" runat="server" Font-Names="Arial" Text='<%#Bind("Grand_total") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_date" runat="server" Font-Names="Arial" Text='<%#Bind("Date") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_status" runat="server" Font-Names="Arial" Text='<%#Bind("Status") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                       
                                    </Columns>
                                </asp:GridView>

                                <div class="span12">
                                    Total Amount :
                                    <asp:Label ID="lbl_total_paout" runat="server" Text="" CssClass="label label-warning"></asp:Label>
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="panel_show" Visible="false" runat="server">
                            <div class="row-fluid">
                                <div class="span12">
                                    <asp:Label ID="lbl_dis" runat="server" CssClass="label label-warning"></asp:Label>
                                </div>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div id="notification">
        <div id="pan" class="notificationpan">
            <div style="float: left; width: auto; height: auto;">
                <asp:Label ID="lbl_message" runat="server" Style="padding: 10px 20px 0px 10px; font-size: 17px; color: #ffffff; font-weight: bold;"></asp:Label>
            </div>
        </div>
    </div>
    <br />
    <br />
    <br />
    <br />
</asp:Content>
