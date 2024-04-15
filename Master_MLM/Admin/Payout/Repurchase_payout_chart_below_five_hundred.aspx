<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="Repurchase_payout_chart_below_five_hundred.aspx.cs" Inherits="Master_MLM.Admin_87554b.Repurchase_payout_chart_below_five_hundred"
    Title="Repurchase Payout Chart Below Five Hundred" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
  Repurchase Payout Chart Below Five Hundred
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
                <a href="#" class="current">Repurchase Payout Chart Below Five Hundred</a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <span class="icon-right"><i class="icon-print" onclick="$('#<%= print1.ClientID %>').click();"></i></span>
                        <span class="icon-right"><i class="icon-save" onclick="$('#<%= img_expord.ClientID %>').click();"></i></span>
                        <h5>Repurchase Payout Chart Below Five Hundred</h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid">
                            <div class="span12" style="text-align: center;">
                                Start Date :
                                <asp:DropDownList ID="ddl_s_date" runat="server" CssClass="span2" AutoPostBack="True" OnSelectedIndexChanged="ddl_s_date_SelectedIndexChanged">
                                </asp:DropDownList>
                                &nbsp;&nbsp;End Date :
                                <asp:DropDownList ID="ddl_e_date" runat="server" CssClass="span2"></asp:DropDownList>
                                &nbsp;&nbsp;<asp:Button ID="btn_find" Style="margin-bottom: 10px;" runat="server" OnClick="btn_find_Click" Text="Find" CssClass="btn btn-primary" />
                            </div>
                        </div>
                        <div style="display: none;">
                            <asp:LinkButton ID="print1" OnClientClick="printTable();" runat="server">
                                    <img src="../images/printer.png" height="25" width="25" border="0" alt="" /></asp:LinkButton>
                            <asp:ImageButton ID="img_expord" runat="server" Height="32px" ImageUrl="~/images/Excelicons.png"
                                Style="margin-left: 0px; float: right;" OnClick="img_expord_Click" />
                        </div>
                        <asp:Panel ID="pnl_view" Visible="false" runat="server">
                            <div class="row-fluid" id="tblPrintIQ">
                                <asp:GridView ID="grd_payout_list" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered data-table dataTable">
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
                                        <asp:TemplateField HeaderText="Mobile no.">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Mobileno" runat="server" Font-Names="Arial" Text='<%#Bind("Mobile_number") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Name" runat="server" Font-Names="Arial" Text='<%#Bind("Membername") %>'></asp:Label>
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

                                        <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPaidStatus" runat="server" Font-Names="Arial" Text='<%#Bind("Status") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       

                                      
                                    </Columns>
                                </asp:GridView>

                                <div class="span9">
                                    Total Amount :
                                    <asp:Label ID="lbl_total_paout" runat="server" Text="" CssClass="label label-warning"></asp:Label>
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
            <%--<img src="../images/close.png" onclick="$(function () { $('.notificationpan').show().slideUp(1000);});"
                        class="closenotificationpan" />--%>
        </div>
    </div>

</asp:Content>
