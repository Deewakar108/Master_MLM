<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Add-Product.aspx.cs" Inherits="Master_MLM.Admin.Repurchase.Add_Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Add Product
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

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
    <div id="content">
        <div id="content-header">
            <div id="breadcrumb">
                <a href="/" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">Website</a>
                <a href="#" class="current">Add Product</a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Add Product</h5>
                    </div>
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
                                <div runat="server" visible="false">
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
                                </div>
                                <div class="control-group">
                                    <div class="controls">
                                        <asp:Button ID="btnupload" runat="server" ValidationGroup="D" Text="Upload Product" CssClass="btn btn-success" OnClick="btnupload_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="span12" style="text-align: center;">
                                <asp:Label ID="lblmessage" runat="server" CssClass="label label-warning"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
