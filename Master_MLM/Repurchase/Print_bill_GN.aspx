<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Print_bill_GN.aspx.cs" Inherits="Master_MLM.Repurchase.Print_bill_GN" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Print Bill GN</title>
    <style type="text/css">
        @media print {
            .noPrint {
                display: none;
            }
        }
    </style>
    <style type="text/css">
        .block1 {
            width: 100px;
            height: 23px;
            margin: 5px auto 0px auto;
            padding: 0px 0px 4px 5px;
            float: left;
            text-align: center;
        }

        .block2 {
            margin: 5px auto 0px auto;
            padding: 5px 0px 0px 5px;
            width: 127px;
            height: 22px;
            float: left;
            text-align: left;
        }

        .style1 {
            width: 132px;
            height: 22px;
        }

        .style2 {
            width: 99px;
            height: 22px;
        }
    </style>

    <script type="text/javascript">
        function printit() {
            if (window.print) {
                window.print();
            }
        }
    </script>
</head>
<body style="margin: 0px; padding: 0px;">
    <form id="form1" runat="server" style="margin: 0px; padding: 0px;">
        <div id="content" style="height: auto; text-align: justify; float: left; width: 100%; margin: 0px; padding: 0px;">
            <asp:HiddenField ID="hidebillno" runat="server" />
            <asp:HiddenField ID="hidememcode" runat="server" />
            <div style="margin: 0px auto 0px auto; height: auto; width: 730px;">
                <div style="padding: 0px 0px 0px 0px; margin: 0px; height: 29px; width: 730px; float: left;">
                    <asp:Button ID="btn_back" runat="server" Text="Back" class="noPrint" OnClick="btn_back_Click"
                        Style="float: left;" />
                    <asp:Button ID="btn_print" runat="server" Text="Printit" class="noPrint" OnClick="btn_print_Click"
                        Style="float: right;" />
                </div>
                <div style="margin: 0px 0px 18px 0px; height: auto; width: 730px; float: left;">
                    <div style="border-left: 1px solid #000; border-right: 1px solid #000; border-top: 1px solid #000; margin: 0px; padding: 0px; width: 730px; height: auto; float: left;">
                        <div style="margin: 0px auto 0px auto; padding: 0px; width: 730px; height: auto; float: left;">
                            <div style="width: 242px; float: left; margin: 0px; padding: 0px;">
                                <h2 style="padding: 0px 0px 0px 15px; margin: 0px 0px 5px 0px; float: left; width: 94%; font-family: arial, Helvetica, sans-serif; font-size: 16px; font-weight: bold; color: #003366; text-align: left; line-height: 20px;">
                                    <asp:Label ID="label12" runat="server" Font-Bold="True" Font-Names="Ebrima" Font-Size="10pt"
                                        ForeColor="Maroon" Text="Invoice No. :-"></asp:Label>
                                    <asp:Label ID="lbl_invoice_no" runat="server" Font-Bold="True" Font-Names="Ebrima"
                                        Font-Size="10pt" ForeColor="#004488"></asp:Label>
                                </h2>
                                <h2 style="padding: 0px 0px 0px 15px; margin: 0px 0px 5px 0px; float: left; width: 94%; font-family: arial, Helvetica, sans-serif; font-size: 16px; font-weight: bold; color: #003366; text-align: left; line-height: 20px;">
                                    <asp:Label ID="label8" runat="server" Font-Bold="True" Font-Names="Ebrima" Font-Size="10pt"
                                        ForeColor="Maroon" Text="Date :-" Style="margin: 0px; padding: 0px 0px 5px 0px; text-align: justify;"></asp:Label>
                                    <asp:Label ID="lbl_invoice_date" runat="server" Font-Bold="True" Font-Names="Ebrima"
                                        Font-Size="10pt" ForeColor="#004488"></asp:Label>
                                </h2>
                                <h2 style="padding: 0px 0px 0px 15px; margin: 0px 0px 5px 0px; float: left; width: 94%; font-family: arial, Helvetica, sans-serif; font-size: 16px; font-weight: bold; color: #003366; text-align: left; line-height: 20px;">
                                    <asp:Label ID="label5" runat="server" Font-Bold="True" Font-Names="Ebrima" Font-Size="10pt"
                                        ForeColor="Maroon" Text="Franchise :-" Style="margin: 0px; padding: 0px 0px 5px 0px; text-align: justify;"></asp:Label>
                                    <asp:Label ID="lbl_franchisename" runat="server" Font-Bold="True" Font-Names="Ebrima"
                                        Font-Size="10pt" ForeColor="#004488"></asp:Label>
                                </h2>
                                <h2 style="padding: 0px 0px 0px 15px; margin: 0px 0px 5px 0px; float: left; width: 94%; font-family: arial, Helvetica, sans-serif; font-size: 16px; font-weight: bold; color: #003366; text-align: left; line-height: 20px;">
                                    <asp:Label ID="label6" runat="server" Font-Bold="True" Font-Names="Ebrima" Font-Size="10pt"
                                        ForeColor="Maroon" Text="Address  :-" Style="margin: 0px; padding: 0px 0px 5px 0px; text-align: justify;"></asp:Label>
                                    <asp:Label ID="lbl_franchiseaddress" runat="server" Font-Bold="True" Font-Names="Ebrima"
                                        Font-Size="10pt" ForeColor="#004488"></asp:Label>
                                </h2>
                            </div>
                            <div style="width: 242px; float: left; margin: 0px; padding: 0px 0px 15px 0px;">
                                <h2 style="padding: 0px; margin: 0px 0px 5px 0px; float: left; width: 100%; font-family: arial, Helvetica, sans-serif; font-size: 12px; font-weight: bold; color: #003366; text-align: center; line-height: 20px;">
                                    <img src="../images/logo.png" style="margin: 3px 0px 2px 0px; width: 200px;" />
                                    <br />
                                </h2>

                                <h2 style="padding: 0px; margin: 0px; float: left; width: 100%; font-family: arial, Helvetica, sans-serif; font-size: 12px; color: #333333; text-align: center; line-height: 20px; text-decoration: underline;">Franchise Distributed Product Invoice </h2>
                            </div>
                            <div style="width: 242px; float: left; margin: 0px; padding: 0px;">
                                <h2 style="padding: 0px 0px 0px 15px; margin: 0px 0px 5px 0px; float: left; width: 94%; font-family: arial, Helvetica, sans-serif; font-size: 16px; font-weight: bold; color: #003366; text-align: left; line-height: 20px;">
                                    <asp:Label ID="label2" runat="server" Font-Bold="True" Font-Names="Ebrima" Font-Size="10pt"
                                        ForeColor="Maroon" Text="Code :- " Style="margin: 0px; padding: 0px 0px 5px 0px; text-align: justify;"></asp:Label>
                                    <asp:Label ID="lbl_code" runat="server" Font-Bold="True" Font-Names="Ebrima"
                                        Font-Size="10pt" ForeColor="#004488"></asp:Label>
                                </h2>
                                <h2 style="padding: 0px 0px 0px 15px; margin: 0px 0px 5px 0px; float: left; width: 94%; font-family: arial, Helvetica, sans-serif; font-size: 16px; font-weight: bold; color: #003366; text-align: left; line-height: 20px;">
                                    <asp:Label ID="label1" runat="server" Font-Bold="True" Font-Names="Ebrima" Font-Size="10pt"
                                        ForeColor="Maroon" Text="Name :- " Style="margin: 0px; padding: 0px 0px 5px 0px; text-align: justify;"></asp:Label>
                                    <asp:Label ID="lbl_membername" runat="server" Font-Bold="True" Font-Names="Ebrima"
                                        Font-Size="10pt" ForeColor="#004488"></asp:Label>
                                </h2>
                                <h2 style="padding: 0px 0px 0px 15px; margin: 0px 0px 5px 0px; float: left; width: 94%; font-family: arial, Helvetica, sans-serif; font-size: 16px; font-weight: bold; color: #003366; text-align: left; line-height: 20px;">
                                    <asp:Label ID="label3" runat="server" Font-Bold="True" Font-Names="Ebrima" Font-Size="10pt"
                                        ForeColor="Maroon" Text="Mob. :- " Style="margin: 0px; padding: 0px 0px 5px 0px; text-align: justify;"></asp:Label>
                                    <asp:Label ID="lbl_mobileno" runat="server" Font-Bold="True" Font-Names="Ebrima"
                                        Font-Size="10pt" ForeColor="#004488"></asp:Label>
                                </h2>
                                <h2 style="padding: 0px 0px 0px 15px; margin: 0px 0px 5px 0px; float: left; width: 94%; font-family: arial, Helvetica, sans-serif; font-size: 16px; font-weight: bold; color: #003366; text-align: left; line-height: 20px;">
                                    <asp:Label ID="label4" runat="server" Font-Bold="True" Font-Names="Ebrima" Font-Size="10pt"
                                        ForeColor="Maroon" Text="Address :- " Style="margin: 0px; padding: 0px 0px 5px 0px; text-align: justify;"></asp:Label>
                                    <asp:Label ID="lbl_address" runat="server" Font-Bold="True" Font-Names="Ebrima"
                                        Font-Size="10pt" ForeColor="#004488"></asp:Label>
                                </h2>
                            </div>
                        </div>
                    </div>
                    <div style="margin: 0px; padding: 0px; width: 730px; height: auto; float: left; text-align: center;">
                        <asp:GridView ID="grdbill" runat="server" AutoGenerateColumns="False"
                            Width="732px" BorderColor="#000" BorderStyle="Solid" BorderWidth="1px">
                            <Columns>
                                <asp:TemplateField HeaderText="Sl No." ControlStyle-Width="51px">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_sl" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                    </ItemTemplate>
                                    <ControlStyle Width="51px"></ControlStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Product Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Product_name" runat="server" Font-Names="Ebrima" Font-Size="12px"
                                            ForeColor="Maroon" Text='<%#Bind("Product_name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="BV/Pcs" ControlStyle-Width="50px">
                                    <ControlStyle Width="50px"></ControlStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_BV" runat="server" Font-Names="Ebrima" Font-Size="12px" ForeColor="Maroon"
                                            Width="50px" Text='<%#Bind("BV") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Mrp/Pcs" ControlStyle-Width="50px">
                                    <ControlStyle Width="50px"></ControlStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_MRP" runat="server" Font-Names="Ebrima" Font-Size="12px" ForeColor="Maroon"
                                            Width="50px" Text='<%#Bind("Mrp") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="Qty." ControlStyle-Width="51px">
                                    <ControlStyle Width="51px"></ControlStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Quantity" runat="server" Font-Names="Ebrima" Font-Size="12px" ForeColor="Maroon"
                                            Width="50px" Text='<%#Bind("Quantity") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tot BV" ControlStyle-Width="48px">
                                    <ControlStyle Width="48px"></ControlStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_totbv" runat="server" Font-Names="Ebrima" Font-Size="12px" ForeColor="Maroon"
                                            Width="50px" Text='<%#Bind("Tot_BV") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tot Mrp" ControlStyle-Width="48px">
                                    <ControlStyle Width="48px"></ControlStyle>
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_grand_total" runat="server" Font-Names="Ebrima" Font-Size="12px" ForeColor="Maroon"
                                            Width="50px" Text='<%#Bind("Tot_mrp") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <HeaderStyle Font-Names="Ebrima" ForeColor="Maroon" Font-Size="12px" />
                            <RowStyle Font-Size="12px" />
                        </asp:GridView>
                    </div>
                    <div style="border-left: 1px solid #000; border-right: 1px solid #000; border-bottom: 1px solid #000; margin: 0px auto; height: auto; width: 730px; float: left;">

                        <div style="margin: 0px auto; height: auto; width: 730px; float: left;">
                            <div style="margin: 0px auto 0px auto; padding: 0px 0px 0px 5px; width: 487px; height: 53px; float: left; text-align: justify;">
                            </div>
                            <div style="border-left: 1px solid #000; margin: 0px auto; padding: 0px; width: 237px; height: 53px; float: left; text-align: center;">
                                <div style="margin: 0px auto 0px auto; padding: 0px; width: 100%; height: 25px; float: left; text-align: center;">
                                    <div
                                        style="border-bottom: 1px solid #000; margin: 0px auto; padding: 5px 0px 0px 5px; float: left; text-align: left; border-right: 1px solid #000;"
                                        class="style2">
                                        <asp:Label ID="Label114" runat="server" Font-Bold="True" Font-Names="Ebrima" Font-Size="10pt"
                                            ForeColor="Maroon" Text="Total BV"></asp:Label>
                                    </div>
                                    <div style="border-bottom: 1px solid #000; margin: 0px auto; padding: 5px 0px 0px 0px; float: left; text-align: center; color: #004488; font-family: ebrima; font-weight: bold; font-size: 10px;"
                                        class="style1">
                                        <asp:Label ID="lbl_totbv" runat="server" Font-Bold="True" Font-Names="Ebrima"
                                            Font-Size="10pt" ForeColor="#004488"></asp:Label>
                                    </div>
                                </div>
                                <div style="margin: 0px auto 0px auto; padding: 0px; width: 100%; height: 21px; float: left; text-align: center;">
                                    <div style="border-bottom: 1px solid #000; margin: 0px auto; padding: 5px 0px 0px 5px; float: left; text-align: left; border-right: 1px solid #000;"
                                        class="style2">
                                        <asp:Label ID="Label117" runat="server" Font-Bold="True" Font-Names="Ebrima" Font-Size="10pt"
                                            ForeColor="Maroon" Text="Grand Total"></asp:Label>
                                    </div>
                                    <div style="border-bottom: 1px solid #000; margin: 0px auto; padding: 5px 0px 0px 0px; float: left; text-align: center; color: #004488; font-family: ebrima; font-weight: bold; font-size: 0px;"
                                        class="style1">
                                        <asp:Label ID="lbl_grand_total" runat="server" Font-Bold="True" Font-Names="Ebrima"
                                            Font-Size="10pt" ForeColor="#004488"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div style="margin: 0px; padding: 50px 20px 20px 0px; height: auto; width: 710px; float: left; text-align: right; font-family: arial, Helvetica, sans-serif; font-size: 16px;">
                            <asp:Label ID="Label119" runat="server" Text="Authorised Signature"></asp:Label>
                        </div>
                    </div>
                    <div style="margin: 15px auto 0px auto; padding: 10px 10px 0px 0px; width: 719px; height: 26px; float: left; text-align: right; font-family: arial, Helvetica, sans-serif; font-size: 16px;">
                    </div>
                </div>
            </div>
            <div style="margin: 0px; height: 35px; width: 730px; float: left;">
                <table style="width: 350px; float: left; margin-top: 3px;">
                    <tr>
                        <td>&nbsp;
                        </td>
                        <td>
                            <asp:Label ID="lbl_session" runat="server" Text="" Visible="false"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
