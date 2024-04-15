<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="View-Product.aspx.cs" Inherits="Master_MLM.Admin.Repurchase.View_Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    View/Edit Product
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .ddsmoothmenu ul li a.eleven {
            color: #446CB3;
            background: #fff;
            text-shadow: none;
            box-shadow: none;
            border-right: 1px solid #446CB3;
            cursor: pointer;
        }

        table {
            width: 100%;
        }

            table th {
                text-align: left;
                padding: 3px 5px;
            }

            table td {
                text-align: left;
                padding: 3px 5px;
            }
        .table-bordered {
            border: 1px solid #ddd!important;
        }
    </style>

    <script type="text/javascript">


        $(function () {

            $("#<%=ddl_gst_perc.ClientID %>").on('input', function () {
                calculate();
            });
            $("#<%=txt_mrp.ClientID %>").on('input', function () {
                calculate();
            });
            function calculate() {
                var mrp = parseFloat($("#<%=txt_mrp.ClientID %>").val());
                var gst_perc = parseFloat($("#<%=ddl_gst_perc.ClientID %>").val());
                var gst_amt = "";
                if (isNaN(gst_perc) || isNaN(mrp)) {
                    gst_amt = " ";
                }

                else {
                    gst_amt = ((mrp * gst_perc) / 100);
                }
                $("#<%=txt_gst_value.ClientID %>").val(gst_amt.toFixed(2));


                net_mrp = (mrp - gst_amt);
                $("#<%=txt_net_mrp.ClientID %>").val(net_mrp.toFixed(2));
            }
        });
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hd_id" runat="server" />
    <div id="content">
        <div id="content-header">
            <div id="breadcrumb">
                <a href="/" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">Repurchase</a>
                <a href="#" class="current">View/Edit Product</a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>View/Edit Product</h5>
                    </div>
                    <asp:Panel ID="pnl_edit_product" runat="server" Visible="false">
                        <div class="widget-content nopadding">
                            <div class="row-fluid">
                                <div class="form-horizontal" id="basic_validate">
                                    <div class="control-group">
                                        <label class="control-label">Product Name :<sup>*<span><asp:RequiredFieldValidator ControlToValidate="txt_Prduct_name" Display="Dynamic" ID="RequiredFieldValidator1" ValidationGroup="D" Text="**" ForeColor="Red" runat="server"></asp:RequiredFieldValidator></span></sup></label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_Prduct_name" runat="server" CssClass="span6"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">MRP :<sup>*<span><asp:RequiredFieldValidator ControlToValidate="txt_mrp" Display="Dynamic" ID="RequiredFieldValidator2" ValidationGroup="D" Text="**" ForeColor="Red" runat="server"></asp:RequiredFieldValidator></span></sup></label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_mrp" runat="server" Style="width: 100px" CssClass="span6"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">BV :<sup>*<span><asp:RequiredFieldValidator ControlToValidate="txt_bv" Display="Dynamic" ID="RequiredFieldValidator3" ValidationGroup="D" Text="**" ForeColor="Red" runat="server"></asp:RequiredFieldValidator></span></sup></label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_bv" runat="server" Style="width: 100px" CssClass="span6"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Unit :<sup>*</sup></label>
                                        <div class="controls">
                                            <asp:DropDownList ID="ddl_unit" runat="server" Style="width: 100px" CssClass="span6"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">GST% :</label>
                                        <div class="controls">
                                            <asp:DropDownList ID="ddl_gst_perc" runat="server" Style="width: 100px" CssClass="span6"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">GST Value :</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_gst_value" runat="server" Style="width: 100px; pointer-events: none;" CssClass="span6"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Net MRP :</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_net_mrp" runat="server" Style="width: 100px; pointer-events: none;" CssClass="span6"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <div class="controls">
                                            <asp:Button ID="btn_cancel" runat="server" ValidationGroup="D" Text="Cancel" CssClass="btn btn-success" OnClick="btn_cancel_Click" />
                                            <asp:Button ID="btn_update" runat="server" ValidationGroup="D" Text="Updated" OnClick="btn_update_Click" CssClass="btn btn-success" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnl_product_list" runat="server">
                        <div class="widget-content nopadding">
                            <div class="row-fluid">
                                <asp:Panel ID="pnl_manage_request" runat="server">
                                    <div style="padding: 0px 5px;">
                                        <asp:GridView ID="grd_product" runat="server" CssClass="table table-bordered data-table dataTable" AllowPaging="True" OnPageIndexChanging="grd_product_PageIndexChanging" AutoGenerateColumns="False" AutoGenerateSelectButton="true" OnSelectedIndexChanged="grd_product_SelectedIndexChanged" AutoGenerateDeleteButton="false" PageSize="20">
                                          
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sr No.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSRNO" runat="server" Text="<%#Container.DataItemIndex+1 %>"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Product Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Product_name" runat="server" Text='<%#Bind("Product_name") %>'>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Mrp">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Mrp" runat="server" Text='<%#Bind("Mrp") %>'>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="BV">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Bv" runat="server" Text='<%#Bind("Bv") %>'>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Unit">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Unit" runat="server" Text='<%#Bind("Unit") %>'>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_gst_perc" runat="server" Text='<%#Bind("Gst_perc") %>'>'></asp:Label>
                                                        <asp:Label ID="lbl_gst_amount" runat="server" Text='<%#Bind("Gst_amt") %>'>'></asp:Label>
                                                        <asp:Label ID="lbl_Net_Mrp" runat="server" Text='<%#Bind("Net_Mrp") %>'>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>


                                                <asp:TemplateField HeaderText=" ID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_id" runat="server" Text='<%#Bind("id") %>'>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="link_delete" runat="server" OnClick="link_delete_Click" OnClientClick='return confirm("Are you sure want to delete ?")' CausesValidation="False">Delete</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                           
                                        </asp:GridView>
                                    </div>
                                </asp:Panel>
                                <div class="span12" style="text-align: center;">
                                    <asp:Label ID="lbl_message" runat="server" CssClass="label label-warning"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
