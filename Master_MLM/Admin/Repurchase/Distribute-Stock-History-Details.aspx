<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Distribute-Stock-History-Details.aspx.cs" Inherits="Master_MLM.Admin.Repurchase.Distribute_Stock_History_Details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Distribute Stock History </title>
    <style type="text/css">
        .body, #form1 {
            margin: 0px;
            padding: 0px;
            height: auto;
            width: 100%;
        }

        .main {
            margin: 0px;
            padding: 0px;
            float: left;
            height: auto;
            width: 100%;
        }

        .blue_bg {
            background: #356aa0;
            background: -moz-linear-gradient(top, #356aa0 0%, #356aa0 100%);
            background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,#356aa0), color-stop(100%,#356aa0));
            background: -webkit-linear-gradient(top, #356aa0 0%,#356aa0 100%);
            background: -o-linear-gradient(top, #356aa0 0%,#356aa0 100%);
            background: -ms-linear-gradient(top, #356aa0 0%,#356aa0 100%);
            background: linear-gradient(to bottom, #0E4379 0%,#356aa0 100%);
            filter: progid:DXImageTransform.Microsoft.gradient( startColorstr= '#356aa0', endColorstr= '#356aa0',GradientType=0 );
            color: #FFFFFF;
        }


        .myButton {
            -moz-box-shadow: inset 0px 1px 0px 0px #54a3f7;
            -webkit-box-shadow: inset 0px 1px 0px 0px #54a3f7;
            box-shadow: inset 0px 1px 0px 0px #54a3f7;
            background: -webkit-gradient(linear, left top, left bottom, color-stop(0.05, #007dc1), color-stop(1, #0061a7));
            background: -moz-linear-gradient(top, #007dc1 5%, #0061a7 100%);
            background: -webkit-linear-gradient(top, #007dc1 5%, #0061a7 100%);
            background: -o-linear-gradient(top, #007dc1 5%, #0061a7 100%);
            background: -ms-linear-gradient(top, #007dc1 5%, #0061a7 100%);
            background: linear-gradient(to bottom, #007dc1 5%, #0061a7 100%);
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr= '#007dc1', endColorstr= '#0061a7',GradientType=0);
            background-color: #007dc1;
            -moz-border-radius: 3px;
            -webkit-border-radius: 3px;
            border-radius: 3px;
            border: 1px solid #124d77;
            display: inline-block;
            cursor: pointer;
            color: #ffffff;
            font-family: arial;
            font-size: 13px;
            padding: 6px 24px;
            text-decoration: none;
            text-shadow: 0px 1px 0px #154682;
        }

            .myButton:hover {
                background: -webkit-gradient(linear, left top, left bottom, color-stop(0.05, #0061a7), color-stop(1, #007dc1));
                background: -moz-linear-gradient(top, #0061a7 5%, #007dc1 100%);
                background: -webkit-linear-gradient(top, #0061a7 5%, #007dc1 100%);
                background: -o-linear-gradient(top, #0061a7 5%, #007dc1 100%);
                background: -ms-linear-gradient(top, #0061a7 5%, #007dc1 100%);
                background: linear-gradient(to bottom, #0061a7 5%, #007dc1 100%);
                filter: progid:DXImageTransform.Microsoft.gradient(startColorstr= '#0061a7', endColorstr= '#007dc1',GradientType=0);
                background-color: #0061a7;
            }

            .myButton:active {
                position: relative;
                top: 1px;
            }

        .user {
            background-position: left center;
            padding: 3px 5px 3px 20px;
            background-image: url( '../Users.png' );
            background-repeat: no-repeat;
            width: 160px;
        }

        .password {
            background-position: left center;
            padding: 3px 5px 3px 20px;
            background-image: url( '../icons/pwd.png' );
            background-repeat: no-repeat;
            width: 160px;
        }

        .input, .input {
            color: #3C3C3C;
            margin: 5px 0px 0px 5px;
            border: 1px solid #c7d0d2;
            border-radius: 2px;
            box-shadow: inset 0 1.5px 3px rgba(190, 190, 190, .4), 0 0 0 2px #f5f7f8;
            -webkit-transition: all .4s ease;
            -moz-transition: all .4s ease;
            transition: all .4s ease;
        }

            .input:hover, .input:hover {
                border: 1px solid #b6bfc0;
                box-shadow: inset 0 1.5px 3px rgba(190, 190, 190, .7), 0 0 0 2px #f5f7f8;
            }
            .round {
    border: 1px solid #CCCCCC;
    -webkit-border-radius: 5px 5px 5px 5px;
    -moz-border-radius: 5px 5px 5px 5px;
    border-radius: 5px 5px 5px 5px;
    overflow: hidden;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="main">
            <asp:Panel ID="Panel1" runat="server" Visible="false">
                <table style="width: 1006px; height: auto; margin: 0px; float: left; border-spacing: 0px;"
                    border="0" class="round shadow">
                    <tr>
                        <td style="padding: 10px 0px 10px 20px; height: 25px; border-bottom-style: solid;  border-bottom-width: 1px; border-bottom-color: #CCCCCC; font-size: 16px; color: white; font-weight: bold; font-family: 'Roboto';"
                            class="blue_bg">Distribute Stock History
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center; padding: 0px;">
                            <asp:GridView ID="grd_view" runat="server" Style="margin: 0px; float: left; font-size: 15px; font-weight: bold; font-family: 'Roboto'; height: auto;"
                                Width="1000px" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr No.">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_sl" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Distribution No">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Distribution" runat="server" Text='<%#Bind("Distribution") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                    <asp:TemplateField HeaderText="Product">

                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Description" runat="server" Text='<%#Bind("Product_name") %>'></asp:Label>
                                            <asp:Label ID="lbl_Productnameid" runat="server" Text='<%#Bind("Product_id") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>

                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Mrp/Pcs">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Mrp" runat="server" Text='<%#Bind("Mrp") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="BV/Pcs">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_BV" runat="server" Text='<%#Bind("BV") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantity">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Quantity" runat="server" Text='<%#Bind("Quantity") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tot Mrp">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_totMrp" runat="server" Text='<%#Bind("Tot_mrp") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="tot BV">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_totBV" runat="server" Text='<%#Bind("Tot_bv") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_id" runat="server" Text='<%#Bind("Id")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>

                                <HeaderStyle BackColor="#454D58" ForeColor="White" />
                            </asp:GridView>



                        </td>
                    </tr>
                    <tr>

                        <td>


                            <table border="0" style="border: 1px solid #CCCCCC; padding: 0px; margin: 10px; width: 605px; font-family: arial, Helvetica, sans-serif; font-size: 14px; font-weight: bold; background-color: #FFFFFF; float: right;">
                                <tr>
                                    <td style="text-align: right; padding: 0px 18px 0px 0px">Total Mrp -
                                    </td>
                                    <td style="text-align: justify;">
                                        <asp:Label ID="lbl_totalamount" runat="server" ForeColor="#CC0000"></asp:Label>

                                    </td>
                                    <td style="text-align: right; padding: 10px 18px 10px 0px;">Total BV -
                                    </td>
                                    <td style="text-align: justify; padding: 10px 18px 10px 0px;">
                                        <asp:Label ID="lbl_totalbv" runat="server" Font-Bold="True" ForeColor="#CC0000"></asp:Label>
                                    </td>
                                </tr>
                                <tr>

                                    <td colspan="4" style="padding: 5px 0px 5px 0px;">&nbsp;</td>

                                </tr>
                            </table>

                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
