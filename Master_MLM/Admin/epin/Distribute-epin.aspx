<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="Distribute-epin.aspx.cs" Inherits="Master_MLM.Admin.Distribute_epin"
    Title="Distribute E-pin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Distribute E-pin
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="notification" style="display: none;">
        <div id="pan" class="notificationpan">
            <div style="float: left; width: auto; height: auto;">
                <asp:Label ID="lbl_message1" runat="server" Style="padding: 10px 20px 0px 10px; background-position: left center; background-image: url(   '../images/warningicon.png' ); background-repeat: no-repeat; font-size: 15px; color: #ffffff; font-weight: bold;"></asp:Label>
            </div>

        </div>
    </div>

    <div id="content">
        <!--breadcrumbs-->
        <div id="content-header">
            <div id="breadcrumb">
                <a href="/" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">E-Pin</a>
                <a href="#" class="current">Distribute E-Pin</a>
            </div>
        </div>
        <!--End-breadcrumbs-->

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Distribute E-Pin</h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid">
                            <div class="span1">
                                Package
                            </div>
                            <div class="span2">
                                <asp:DropDownList ID="ddl_package" runat="server"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddl_package_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <asp:GridView ID="grd_epin_distribute" runat="server" CssClass="table table-bordered data-table dataTable"
                                AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="grd_epin_distribute_PageIndexChanging"
                                AllowSorting="True">
                                <PagerStyle  CssClass="pagination-sks" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr No.">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSRNO" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="E-PIN">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_epin" runat="server" Font-Names="Arial" Text='<%#Bind("Epin") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Generation Date" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Date" runat="server" Font-Names="Arial" Text='<%#Bind("Date") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Package">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Package" runat="server" Font-Names="Arial" Text='<%#Bind("Package") %>'></asp:Label>
                                            <asp:Label ID="lbl_Package_id" runat="server" Font-Names="Arial" Text='<%#Bind("Package_id") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_Status" runat="server" Font-Names="Arial" Text='<%#Bind("Status") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Id" Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_id" runat="server" Font-Names="Arial" Text='<%#Bind("ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chk_check_pin" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <asp:Panel ID="Panel1" runat="server" Style="margin-top: 9px" Visible="false">
                        
                        <div class="row-fluid">
                            <div class="span1">
                                Member :
                            </div>
                            <div class="span3">
                                <asp:TextBox ID="txt_member_code" placeholder="Member Code" runat="server"   CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_member_code"
                                    ErrorMessage="**" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                            </div>
                            <div class="span2">
                                <asp:Button ID="btn_find" runat="server" CssClass="btn btn-primary" OnClick="btn_find_Click"
                                    UseSubmitBehavior="false" OnClientClick="this.disabled = true;" Text="Find" />
                            </div>
                            <div class="span2">
                                <asp:Label ID="txt_member_name" runat="server" Font-Bold="True" ForeColor="#CC0000"></asp:Label>
                            </div>
                            <div class="span2">
                                <asp:Button ID="btn_distribute" runat="server" OnClick="btn_distribute_Click"
                                    Text="Distribute E-PIN" CssClass="btn btn-success" />
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span12" style="text-align: center;">
                                <br />
                                <asp:Label ID="lbl_message" runat="server" CssClass="label label-warning" ></asp:Label>
                                &nbsp;<asp:HiddenField ID="hd_franchisecode" runat="server" />
                                <asp:HiddenField ID="hd_franchisestatus" runat="server" />
                            </div>
                        </div>
                    </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
