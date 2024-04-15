<%@ Page Title="Pin Transfer" Language="C#" MasterPageFile="~/Member_4235profile/Member_main.Master" AutoEventWireup="true" CodeBehind="Transfer_3546cv4_pin.aspx.cs" Inherits="Master_MLM.Member_4235profile.Transfer_3546cv4_pin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .ddsmoothmenu ul li a.tenth {
            background-color: #F700A9;
            color: #fff;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="javascript:">Home</a> <i class="fa fa-angle-right"></i></li>
    </ol>

    <div class="grid-form">
        <div class="grid-form1">
            <h4 class="breadcrumb-item"><a>Pin Transfer</a></h4>


            <div class="row" style="padding: 30px 0px 0px 0px; margin: 0px;">
                <div style="margin: 0px 0px 10px 0px; padding: 0px; float: left; width: 100%; height: auto;">
                    <p style="margin: 0px; padding: 0px; float: left; width: 100%; text-align: center">
                        <asp:Label ID="lbl_message" runat="server" Font-Bold="False" Font-Size="12pt" ForeColor="Red"></asp:Label>
                    </p>
                </div>
                <div class="col-lg-3">
                </div>
                <div class="col-lg-6" style="padding: 10px 0px; border: 1px solid #5cb85c;">
                    <div class="col-lg-6">
                        <div class="form-group">
                            <label for="txt_paename">Select Package</label>
                            <asp:DropDownList ID="ddl_package" runat="server" CssClass="form-control" Style="width: 100%;">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="form-group">
                            <label for="txt_bankname" style="width: 100%;">
                                &nbsp; 
                                        <asp:Label ID="lbl_findmsg" runat="server" ForeColor="Red"></asp:Label></label>
                            <asp:Button ID="btn_find" runat="server" Text="Find" Width="80px" CssClass="btn btn-success" OnClick="btn_find_Click" />
                            &nbsp;
                        </div>
                    </div>
                    <div class="col-lg-12">
                        <div class="form-group">
                            <asp:GridView ID="grd_epin" runat="server" Style="margin: 0px auto; font: normal 13px ebrima; height: auto;"
                                Width="100%" AutoGenerateColumns="False" Visible="false">
                                <Columns>
                                    <asp:TemplateField HeaderText="Serial No.">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSRNO" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="E-Pin">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_epin" runat="server" Text='<%#bind("Epin") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Allocation Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_distributed_date" runat="server" Text='<%#bind("distribution_date") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_status" runat="server" Text='<%#bind("Status") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="id" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_id" runat="server" Text='<%#bind("ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                            </asp:GridView>
                        </div>
                    </div>
                    <asp:Panel ID="pnl_view" runat="server" Visible="false">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label for="txt_ifsccode" style="width: 100%;">Total Available Pin</label>
                                <asp:Label ID="lbl_avilable_pin" runat="server" ForeColor="Black" Font-Bold="True" CssClass="form-control" Style="width: 100%;"></asp:Label>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label for="txt_bankbranch" style="width: 100%;">Enter Pin Qty</label>
                                <asp:TextBox ID="txt_pin_qty" runat="server" placeholder="Enter pin quantity" CssClass="form-control" Style="width: 100%;"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-lg-6">
                            <div class="form-group">
                                <label for="txt_ifsccode" style="width: 100%;">Enter member id </label>
                                <asp:TextBox ID="txt_member_id" runat="server" placeholder="Enter member id" AutoPostBack="True"
                                    OnTextChanged="txt_member_id_TextChanged" CssClass="form-control" Style="width: 100%;"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label for="txt_bankbranch" style="width: 100%;">Member Name</label>
                                <asp:Label ID="lbl_name" runat="server" CssClass="form-control" Style="width: 100%;"></asp:Label>
                            </div>
                        </div>

                        <div class="col-lg-12 text-right">
                            <div class="form-group">
                                <label for="btn_update">&nbsp;</label>

                                <asp:Button ID="btn_submit" runat="server" Text="Submit"
                                    OnClick="btn_submit_Click" class="btn btn-success" />
                                <br />
                                &nbsp;
                                <asp:Label ID="lbl_submit_msg" runat="server" ForeColor="Red"></asp:Label>
                            </div>
                        </div>

                    </asp:Panel>
                </div>
                <div class="col-lg-3">
                </div>

            </div>

        </div>
    </div>

</asp:Content>
