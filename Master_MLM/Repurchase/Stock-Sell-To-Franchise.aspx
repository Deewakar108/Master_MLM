<%@ Page Title="" Language="C#" MasterPageFile="~/Repurchase/main.Master" AutoEventWireup="true" CodeBehind="Stock-Sell-To-Franchise.aspx.cs" Inherits="Master_MLM.Repurchase.Stock_Sell_To_Franchise" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Distribute Stock
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

        .textbx-box {
            margin: 0px;
            padding: 0px;
            width: 50%;
            height: auto;
            float: left;
            border-top: 1px solid #eeeeee;
            border-bottom: 1px solid #eeeeee;
        }

        .textbx-lbl-name {
            padding-top: 15px;
            width: 180px;
            float: left;
            text-align: right;
            font-size: 14px;
            font-weight: normal;
            line-height: 20px;
            display: block;
            margin-bottom: 5px;
        }

        .textbx-wpr {
            margin-left: 200px;
            padding: 10px 0;
        }

        .btn {
            padding: 4px 15px;
        }

        .fnl-submit-tbl-styl {
            border: 1px solid #CCCCCC;
            padding: 0px;
            margin: 10px;
            width: 605px;
            font-family: arial, Helvetica, sans-serif;
            font-size: 14px;
            font-weight: bold;
            background-color: #FFFFFF;
            float: right;
        }

        @media only screen and (max-width:800px) {
            .textbx-box {
                width: 100%;
            }

            .textbx-lbl-name {
                width: 100%;
                text-align: left;
            }

            .textbx-wpr {
                margin-left: 0px;
                padding: 10px 0;
            }

            .fnl-submit-tbl-styl {
                margin: 10px 0px;
                width: 100%;
            }
        }
    </style>

    <style>
        .form-horizontal .control-group {
            width: 50%;
            float: left;
        }

        .table th {
            font-size: 12px;
            text-align: left;
        }

        .tbl-styl {
            border: 1px solid #CCCCCC;
            padding: 0px;
            margin: 10px;
            width: 605px;
            font-family: arial, Helvetica, sans-serif;
            font-size: 14px;
            font-weight: bold;
            background-color: #FFFFFF;
            float: right;
        }

        @media only screen and (max-width:800px) {
            .form-horizontal .control-group {
                width: 100%;
            }

            .tbl-styl {
                float: left;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hd_franchis_code" runat="server" />
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <div class="grid-form">
        <div class="grid-form1">
            <h4 class="breadcrumb-item"><a>Sell Stock</a></h4>
            <asp:Label ID="lbl_message" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#CC0000"></asp:Label>

            <div class="panel-body panel-footer">
                <div role="form" class="form-horizontal">
                    <div class="grd-over-flow">
                        <div class="grd-over-flow" style="margin: 0px 0px 0px 0px">
                            <div class="textbx-box" style="width: 100%;">
                                <p class="textbx-lbl-name">Franchise Code  :</p>
                                <div class="textbx-wpr">
                                    <asp:TextBox ID="txt_stock_point_code" runat="server"></asp:TextBox>
                                    <asp:Button ID="btn_find" runat="server" class="btn btn-success" Text="Find" OnClick="btn_find_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="grd-over-flow">
                        <div class="textbx-box">
                            <p class="textbx-lbl-name">Name  :</p>
                            <div class="textbx-wpr">
                                <asp:Label ID="lbl_membername" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="textbx-box">
                            <p class="textbx-lbl-name">Mobile  :</p>
                            <div class="textbx-wpr">
                                <asp:Label ID="lbl_mobileno" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                        <div class="textbx-box" style="width: 100%;">
                            <p class="textbx-lbl-name">City  :</p>
                            <div class="textbx-wpr">
                                <asp:Label ID="lbl_city" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                    <asp:Panel ID="panel_member_details" runat="server" Visible="false">
                        <div class="grd-over-flow" style="margin: 40px 0px 0px 0px">
                            <div class="textbx-box">
                                <p class="textbx-lbl-name">Date :</p>
                                <div class="textbx-wpr">
                                    <asp:TextBox ID="txt_date" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="textbx-box">
                                <p class="textbx-lbl-name">Distribution No&nbsp; :</p>
                                <div class="textbx-wpr">
                                    <asp:TextBox ID="txt_distributionno" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="textbx-box">
                                <p class="textbx-lbl-name">Product  :</p>
                                <div class="textbx-wpr">
                                    <asp:DropDownList ID="ddl_product_name" runat="server" Style="height: 28px; width: 186px; padding: 0px;" AutoPostBack="true" OnSelectedIndexChanged="ddl_product_name_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="textbx-box">
                                <p class="textbx-lbl-name">BV  :</p>
                                <div class="textbx-wpr">
                                    <asp:TextBox ID="txt_bv" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="textbx-box">
                                <p class="textbx-lbl-name">MRP  :</p>
                                <div class="textbx-wpr">
                                    <asp:TextBox ID="txt_mrp" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                            <div class="textbx-box">
                                <p class="textbx-lbl-name">Available Quantity  :</p>
                                <div class="textbx-wpr">
                                    <asp:TextBox ID="txt_quantity" runat="server" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                            <div class="textbx-box">
                                <p class="textbx-lbl-name">
                                    Sell Quantity  :<span><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_sell_quantity" Display="Dynamic" ErrorMessage="**" Font-Bold="False" ForeColor="#CC0000" ValidationGroup="a"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="valEmailID0" runat="server" ControlToValidate="txt_sell_quantity"
                                            ErrorMessage="only digit allowed in quantity" ValidationExpression="^\d+$" Font-Size="13px"
                                            Display="Dynamic" ForeColor="Red" ValidationGroup="a"></asp:RegularExpressionValidator>
                                    </span>
                                </p>
                                <div class="textbx-wpr">
                                    <asp:TextBox ID="txt_sell_quantity" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="textbx-box">
                                <p class="textbx-lbl-name"></p>
                                <div class="textbx-wpr">
                                    <asp:Button ID="btn_add" runat="server" ValidationGroup="a" class="btn btn-success" Text="Add" OnClick="btn_add_Click" />
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="panel_view" runat="server" Visible="false">
                        <div class="grd-over-flow" style="margin: 40px 0px 0px 0px">
                            <asp:GridView ID="gridview" runat="server" Style="width: 100%; margin: 10px 0px 0px 0px; float: left; padding: 0px; text-align: center; font-weight: normal;"
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
                                    <asp:TemplateField HeaderText="Entery No" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_product_id" runat="server" Text='<%#Bind("Product_id") %>'></asp:Label>
                                            <asp:Label ID="lbl_Stockpoint_code" runat="server" Text='<%#Bind("Stockpoint_code") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Product Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Product_name" runat="server" Text='<%#Bind("Product_name") %>'></asp:Label>
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
                                    <asp:TemplateField HeaderText="Tot Mrp.">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_totmrp" runat="server" Text='<%#Bind("Tot_mrp") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tot Bv">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Tot_bv" runat="server" Text='<%#Bind("Tot_bv") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_id" runat="server" Text='<%#Bind("Id")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgbtn_delete" runat="server" Height="25px" ImageUrl="~/images/delete-icon.png"
                                                Width="25px" OnClientClick="return confirm('Are you sure want to delete it ?')"
                                                OnClick="imgbtn_delete_Click" CausesValidation="false" />
                                            <%--<asp:LinkButton ID="link_delete" runat="server" OnClick="link_delete_Click" OnClientClick='return confirm("Are you sure want to delete ?")' CausesValidation="False"><i class="grid-icon icon-trash"</asp:LinkButton>--%>
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
                        <div class="grd-wprr">
                            <table border="0" cellpadding="0" cellspacing="0" class="tbl-styl">
                                <tr>
                                    <td style="text-align: right; padding: 0px 18px 0px 0px">Total Price -
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
                                    <td colspan="4" style="padding: 5px 0px 5px 0px; text-align: center;">
                                        <asp:Button ID="btn_final_submit" runat="server" Text="Submit" Style="background-color: #ff6666; font-weight: bold; height: 30px; width: 145px; color: #fff;"
                                            ValidationGroup="a" OnClick="btn_final_submit_Click" CausesValidation="false" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:Panel>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
