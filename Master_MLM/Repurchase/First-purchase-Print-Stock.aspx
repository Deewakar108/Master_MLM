<%@ Page Title="" Language="C#" MasterPageFile="~/Repurchase/main.Master" AutoEventWireup="true" CodeBehind="First-purchase-Print-Stock.aspx.cs" Inherits="Master_MLM.Repurchase.First_purchase_Print_Stock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Print Product List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        td, th {
            padding: 5px 10px;
            text-align: left;
        }

            td span {
                padding: 0px 0px;
            }

        .panel-body {
            overflow: auto;
            padding: 15px 0px;
        }

        .btn {
            vertical-align: top;
        }

        option {
            color: #222 !important;
        }
    </style>
    <script type="text/javascript">
        function printTable() {
            document.getElementById('myid').style.display = "none";
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
    <div class="grid-form">
        <div class="grid-form1">
            <asp:Label ID="lbl_message" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#CC0000"></asp:Label>
            <div class="panel-body panel-footer">
                <div role="form" class="form-horizontal">
                    <div class="grd-over-flow">
                        <asp:Panel ID="panel_view" runat="server" Visible="false">
                            <div id="tblPrintIQ" border="0" cellpadding="0" cellspacing="0" style="border: 1px solid #CCCCCC; padding: 5px; margin: 0px; float: left; width: 1028px;">
                                <h4 class="breadcrumb-item" style="width: 85%; float: left"><a>Print Product List</a></h4>
                                <h2 id="myid" style="text-align: right; width: 15%; margin: 0px; float: left;" class="noPrint">
                                    <asp:LinkButton ID="print1" OnClientClick="printTable();" runat="server">
                                    <img src="images/printer.png" height="25" width="25" border="0" /></asp:LinkButton>
                                </h2>
                                <asp:GridView ID="gridview" runat="server" Width="1015px" Style="margin: 10px 0px 0px 0px; float: left; padding: 0px; text-align: center; font-weight: normal;"
                                    AutoGenerateColumns="False"
                                    BorderColor="#186B80" BorderStyle="Solid" BorderWidth="1px" CellPadding="4" Font-Names="Ebrima"
                                    Font-Size="12px" ForeColor="#333333">
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr No.">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_sl" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Product">
                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Description" runat="server" Text='<%#Bind("Product_name") %>'></asp:Label>
                                                <asp:Label ID="lbl_Productnameid" runat="server" Text='<%#Bind("Product_code") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="MRP/Pcs">

                                            <ItemTemplate>
                                                <asp:Label ID="lbl_Mrp" runat="server" Text='<%#Bind("price") %>'></asp:Label>
                                            </ItemTemplate>

                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#CCCC99" />
                                    <PagerStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <SelectedRowStyle BackColor="#EFEFEF" Font-Bold="True" ForeColor="#CC0000" />
                                    <HeaderStyle BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True"
                                        ForeColor="White" Height="40px" BackColor="#00A4CC" />
                                    <AlternatingRowStyle BackColor="White" />
                                </asp:GridView>
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
