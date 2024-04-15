<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Add-Franchise.aspx.cs" Inherits="Master_MLM.Admin.Repurchase.Add_Franchise" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Add Franchise
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-horizontal .control-group {
            width: 50%;
            float: left;
        }

        .table th {
            font-size: 12px;
            text-align: left;
        }

        @media only screen and (max-width:800px) {
            .form-horizontal .control-group {
                width: 100%;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">
        <div id="content-header">
            <div id="breadcrumb">
                <a href="../home.aspx" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">Franchise</a>
                <a href="#" class="current">Add Franchise</a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Add Franchise</h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid">
                            <div class="form-horizontal width-forty" id="basic_validate">
                                <div class="control-group" style="width: 100%">
                                    <label class="control-label">Enter Member Code :</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txt_member_code" runat="server"></asp:TextBox>
                                        <asp:Button ID="btn_find" runat="server" Text="Find" CssClass="btn btn-success" OnClick="btn_find_Click" />
                                    </div>
                                </div>
                                <div class="control-group" style="width: 100%">
                                    <label class="control-label">Member Name :</label>
                                    <div class="controls">
                                        <asp:Label ID="lbl_membername" runat="server" Style="color: #CC0000; font-weight: bold; font-size: 14px; margin: 5px 0px 0px 0px; float: left;"></asp:Label>
                                    </div>

                                </div>
                                <div class="span12" style="text-align: center;">
                                    <asp:Label ID="lblmessage" runat="server" CssClass="label label-warning"></asp:Label>
                                </div>
                            </div>
                        </div>

                        <div class="row-fluid">
                            <div class="form-horizontal">
                                <asp:Panel ID="panel_add_data" runat="server" Visible="true">
                                    <div class="control-group" style="width: 100%">
                                        <label class="control-label">
                                            Franchise Code :<sup>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_stockpointcode" Display="Dynamic" ErrorMessage="*" Font-Bold="False" ForeColor="#CC0000" ValidationGroup="a"></asp:RequiredFieldValidator></sup></label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_stockpointcode" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Franchise Name :<sup><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_franchisename" Display="Dynamic" ErrorMessage="*" Font-Bold="False" ForeColor="#CC0000" ValidationGroup="a"></asp:RequiredFieldValidator></sup></label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_franchisename" runat="server" Style="width: 98%;"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">City :<sup><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_city" Display="Dynamic" ErrorMessage="*" Font-Bold="False" ForeColor="#CC0000" ValidationGroup="a"></asp:RequiredFieldValidator></sup></label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_city" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Address :<sup><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_address" Display="Dynamic" ErrorMessage="*" Font-Bold="False" ForeColor="#CC0000" ValidationGroup="a"></asp:RequiredFieldValidator></sup></label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_address" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Mobile No :<sup><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_mobileno" Display="Dynamic" ErrorMessage="*" Font-Bold="False" ForeColor="#CC0000" ValidationGroup="a"></asp:RequiredFieldValidator></sup></label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_mobileno" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Password :<sup><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_pwd" Display="Dynamic" ErrorMessage="*" Font-Bold="False" ForeColor="#CC0000" ValidationGroup="a"></asp:RequiredFieldValidator></sup></label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_pwd" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <div class="controls">
                                            <asp:Button ID="btn_add" runat="server" Text="Add" ValidationGroup="a" OnClick="btn_add_Click" CssClass="btn btn-success" />
                                        </div>
                                    </div>
                                </asp:Panel>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <asp:Panel ID="panel_view" runat="server" Visible="false">
                                <div class="form-horizontal">
                                    <div class="grd-wprr" style="margin: 20px 0px 0px 0px;">
                                        <asp:GridView ID="gridview" runat="server" CssClass="table table-bordered data-table dataTable"
                                            AutoGenerateColumns="False" AutoGenerateSelectButton="false" AutoGenerateEditButton="True" OnRowCancelingEdit="gridview_RowCancelingEdit" OnRowEditing="gridview_RowEditing" OnRowUpdating="gridview_RowUpdating">
                                            <Columns>
                                                <asp:TemplateField HeaderText="SL. No.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_sl" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Member Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Member_name" runat="server" Text='<%#Bind("Member_name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Member Code">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Mmember_code" runat="server" Text='<%#Bind("Member_code") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Address" Visible="false">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txt_Address" runat="server" TextMode="MultiLine" Text='<%#Bind("Address") %>'
                                                            Style="height: 50px; width: 250px;"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Address" runat="server" Text='<%#Bind("Address") %>'></asp:Label>
                                                    </ItemTemplate>

                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="City">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txt_City" runat="server" Text='<%#Bind("City") %>'
                                                            Style="height: 25px; width: 180px;"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_City" runat="server" Text='<%#Bind("City") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Mobile No">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txt_Mobileno" runat="server" Text='<%#Bind("Mobileno") %>'
                                                            Style="height: 25px; width: 100px;"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Mobileno" runat="server" Text='<%#Bind("Mobileno") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Franchise Name">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txt_Franchise_name" runat="server" Text='<%#Bind("Franchise_name") %>'
                                                            Style="height: 25px; width: 100px;"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Franchise_name" runat="server" Text='<%#Bind("Franchise_name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="SP Code/User Id">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Stock_point_code" runat="server" Text='<%#Bind("Stock_point_code") %>'>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Password ">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txt_Pwd" runat="server" Text='<%#Bind("Pwd") %>'
                                                            Style="height: 25px; width: 100px;"></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_Pwd" runat="server" Text='<%#Bind("Pwd") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_date" runat="server" Text='<%#Bind("Date") %>'>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl_id" runat="server" Text='<%#Bind("Id")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="link_delete" runat="server" OnClick="link_delete_Click" OnClientClick='return confirm("Are you sure want to delete ?")' CausesValidation="False"><i class="grid-icon icon-trash"</asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
