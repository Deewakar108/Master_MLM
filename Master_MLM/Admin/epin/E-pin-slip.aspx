<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="E-pin-slip.aspx.cs" Inherits="Master_MLM.Admin.E_pin_slip" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>E-pin Slip</title>

    <style type="text/css">
        .lefttd {
            width: 155px;
            height: 30px;
            padding: 0px 0px 0px 35px;
            color: #333333;
        }

        .righttd {
            width: 340px;
            height: 30px;
        }

        .lefttd1 {
            width: 155px;
            height: 30px;
            padding: 0px 0px 0px 35px;
            color: #333333;
        }

        .righttd1 {
            width: 300px;
            height: 30px;
        }

        @media print {
            .noPrint {
                display: none;
            }
        }

        .heading {
            margin: 0px 0px 0px 0px;
            padding: 0px 0px 0px 8px;
            width: 97%;
            float: left;
            text-align: center;
        }

        .parastyle {
            margin: 8px 0px 0px 0px;
            padding: 0px;
            width: 100%;
            float: left;
            font-size: 15px;
            text-align: left;
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
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="Panel1" runat="server">
            <table style="border: 4px solid #000000; margin: 20px auto 0px auto; font-size: 17px; height: auto; width: 900px; border-spacing: 0px; font-family: ebrima;"
                border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="3" style="text-align: left;">
                        <asp:Button ID="btn_back" runat="server" Text="Back" Style="height: 25px; width: 100px; float: right;"
                            BackColor="#D83C03" BorderStyle="Outset" Font-Bold="True" ForeColor="White"
                            CssClass="noPrint" OnClick="btn_back_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="border-bottom-style: dashed; border-bottom-width: 2px; border-bottom-color: #003300; vertical-align: top; padding: 0px 0px 0px 10px;">
                        <h2 class="heading" style="font-size: 15px; text-align: left">
                            <asp:Label ID="lblCompanyName" runat="server" Text="Label"></asp:Label></h2>
                        <p class="parastyle">
                            <%--Office Address&nbsp;
                            <br />
                          Indraprastha Colony, Raipur --%>
                        </p>
                    </td>
                    <td style="text-align: center; font-weight: bold; font-size: 20px; border-bottom-style: dashed; border-bottom-width: 2px; border-bottom-color: #003300;">


                        <img src="../../Content/Images/logo/logo.png" style="margin: 3px 0px 0px 0px; padding: 0px; " />

                        <br />
                        <h2 class="heading">Allocated E-pin Details </h2>
                    </td>
                    <td style="border-bottom-style: dashed; border-bottom-width: 2px; border-bottom-color: #003300; vertical-align: top; padding: 0px 0px 0px 10px;">

                        <p class="parastyle">
                            Date : 
                            <asp:Label ID="lbl_date" runat="server"></asp:Label>
                        </p>
                        <p class="parastyle">
                            Tran. Id : 
                            <asp:Label ID="lbl_transactionid" runat="server"></asp:Label>
                        </p>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="border-bottom-style: dashed; border-bottom-width: 2px; border-bottom-color: #003300; color: #f00;">
                        <h2 class="heading" style="font-size: 17px; text-align: left; padding: 8px 0px 8px 10px">Personal Details</h2>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <table>
                            <tr>
                                <td class="lefttd">Code :
                                </td>
                                <td class="righttd" colspan="3">
                                    <asp:Label ID="lbl_code" runat="server" Text=""></asp:Label>
                                </td>

                            </tr>
                            <tr>
                                <td class="lefttd">Name :
                                </td>
                                <td class="righttd">
                                    <asp:Label ID="lbl_name" runat="server" Text=""></asp:Label>
                                </td>
                                <td class="lefttd">Address :
                                </td>
                                <td class="righttd">
                                    <asp:Label ID="lbl_address" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="lefttd">District :
                                </td>
                                <td class="righttd">
                                    <asp:Label ID="lbl_dist" runat="server" Text=""></asp:Label>
                                </td>
                                <td class="lefttd">State :
                                </td>
                                <td class="righttd">
                                    <asp:Label ID="lbl_state" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>



                    </td>


                </tr>

                <tr>
                    <td colspan="3" style="border-bottom-style: dashed; border-bottom-width: 2px; border-bottom-color: #003300; border-top-style: dashed; border-top-width: 2px; border-top-color: #003300; color: #f00;">
                        <h2 class="heading" style="font-size: 17px; text-align: left; padding: 8px 0px 8px 10px">Package & Payment Details</h2>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <table>
                            <tr>
                                <td class="lefttd">Package Name :
                                </td>
                                <td class="righttd" colspan="3">
                                    <asp:Label ID="lbl_package" runat="server" Text=""></asp:Label>
                                </td>

                            </tr>
                            <tr>
                                <td class="lefttd">No. Of Pin :
                                </td>
                                <td class="righttd">
                                    <asp:Label ID="lbl_pinno" runat="server" Text=""></asp:Label>
                                </td>
                                <td class="lefttd">Amount :
                                </td>
                                <td class="righttd">
                                    <asp:Label ID="lbl_amt" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>



                    </td>


                </tr>
                <tr>
                    <td colspan="3" style="border-bottom-style: dashed; border-bottom-width: 2px; border-bottom-color: #003300; border-top-style: dashed; border-top-width: 2px; border-top-color: #003300; color: #f00;">
                        <h2 class="heading" style="font-size: 17px; text-align: left; padding: 8px 0px 8px 10px">There are your pin no's </h2>

                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="padding: 10px;">
                        <asp:GridView ID="grdpins" runat="server" AutoGenerateColumns="False" ShowHeader="False" ForeColor="Black" Font-Bold="true">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSRNO" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Label ID="lblpins" runat="server" Text='<%#Bind("Epin") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 0px 20px 0px 20px; font-weight: bold; font-size: 14px; border-top-style: dashed; border-top-width: 2px; border-top-color: #000000; height: 40px;"
                        colspan="3">&nbsp;
                    <asp:Button ID="btn_print" runat="server" Text="Print" Style="height: 25px; width: 100px; float: right;"
                        BackColor="#D83C03" BorderStyle="Outset" Font-Bold="True" ForeColor="White"
                        OnClick="btn_print_Click" CssClass="noPrint" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center; height: 20px; font-weight: bold; font-size: 16px;"
                        colspan="3"></td>
                </tr>
            </table>
        </asp:Panel>
    </form>
</body>
</html>
