<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="Generate-epin.aspx.cs" Inherits="Master_MLM.Admin.Generate_epin"
    Title="E-pin Generation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    E-pin Generation
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="../css/custom.css" rel="stylesheet" />
    <style type="text/css">
        .ddsmoothmenu ul li a.second {
            color: #446CB3;
            background: #fff;
            text-shadow: none;
            box-shadow: none;
            border-right: 1px solid #446CB3;
            cursor: pointer;
        }
    </style>
    <%--<script type="text/javascript">
        function HideLabel() {
            document.getElementById('<%= lbl_message.ClientID %>').style.display = "none";
        }
        setTimeout("HideLabel();", 5000);
    </script>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="content">
        <!--breadcrumbs-->
        <div id="content-header">
            <div id="breadcrumb">
                <a href="/" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">E-Pin</a>
                <a href="#" class="current">Generate E-Pin</a>
            </div>
        </div>
        <!--End-breadcrumbs-->

        <div class="container-fluid">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Generate E-Pin</h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid">
                            <div class="span6">
                                <asp:Button ID="btn_generate_pin" runat="server" Text="Generate E- Pin"
                                    OnClick="btn_generate_pin_Click" CssClass="btn btn-primary btn-large" />
                            </div>
                            <div class="span6 alert alert-block" style="text-align: center;">
                                <asp:Label ID="lbl_total_pin" runat="server" Style="color: Red; font-size: 15px;"></asp:Label>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span4">
                                <asp:GridView ID="grd_epin" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered data-table dataTable"
                                    EnableModelValidation="True">
                                    <PagerStyle CssClass="pagination-sks" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr No.">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="E-pin">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lbl_epin" Text='<%#bind("Epin") %>'>  </asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>

                                </asp:GridView>
                            </div>
                        </div>

                        <div class="row-fluid">
                            <div class="span1">
                                <asp:Label ID="lbl_package" runat="server" Font-Bold="True" Text="Package :-"
                                    Visible="False"></asp:Label>
                            </div>
                            <div class="span2">
                                <asp:DropDownList ID="ddl_package" runat="server" Style="width: 150px; height: 25px;"
                                    Visible="False">
                                </asp:DropDownList>
                            </div>
                            <div class="span2">
                                <asp:Button ID="btn_submit" runat="server" Text="SUBMIT" CssClass="btn btn-success"
                                    OnClick="btn_submit_Click" Visible="False" UseSubmitBehavior="false"
                                    OnClientClick="this.disabled = true;" />
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span12" style="text-align: center;">
                                <asp:Label ID="lbl_dis" runat="server" CssClass="label label-success" Font-Bold="True" ForeColor="White"></asp:Label>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>

    </div>

    <div id="notification" style="display: none;">
        <div id="pan" class="notificationpan">
            <div style="float: left; width: auto; height: auto;">
                <asp:Label ID="lbl_message1" runat="server" Style="padding: 10px 20px 0px 10px; background-position: left center; background-image: url(   '../images/warningicon.png' ); background-repeat: no-repeat; font-size: 15px; color: #ffffff; font-weight: bold;"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
