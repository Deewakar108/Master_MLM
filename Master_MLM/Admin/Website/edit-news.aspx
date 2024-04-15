<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="edit-news.aspx.cs" Inherits="Master_MLM.Admin.edit_news"
    Title="Edit News" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Edit News
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
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">

        <div id="content-header">
            <div id="breadcrumb">
                <a href="/" title="Go to Home" class="tip-bottom"><i class="icon-home"></i>Home</a>
                <a href="#" class="current">Website</a>
                <a href="#" class="current">Edit News</a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Edit News</h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid">
                            <div class="span12" style="text-align: center;">
                                <asp:Label ID="lblMessage" runat="server" CssClass="label label-warning"></asp:Label>
                            </div>

                            <asp:GridView ID="grd_edit_news" runat="server"  CssClass="table table-bordered data-table dataTable"
                                AutoGenerateColumns="False" AutoGenerateEditButton="True" OnRowCancelingEdit="grd_edit_news_RowCancelingEdit"
                                OnRowEditing="grd_edit_news_RowEditing" OnRowUpdating="grd_edit_news_RowUpdating"
                                AllowPaging="True" OnPageIndexChanging="grd_edit_news_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderText="Heading">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txt_heading" runat="server" TextMode="MultiLine" Text='<%#Bind("Heading") %>'
                                                Style="height: 50px; width: 250px;"></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_heading" runat="server" Text='<%#Bind("Heading") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="News Description">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txt_news" runat="server" TextMode="MultiLine" Text='<%#Bind("News") %>'
                                                ></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_news" runat="server" Text='<%#Bind("News") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txt_date" runat="server"  Text='<%#Bind("Date") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_date" runat="server" Text='<%#Bind("Date") %>'>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_id" runat="server" Text='<%#Bind("id")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <i class="icon-trash grid-icon"  onclick="$('#ContentPlaceHolder1_grd_edit_news_imgbtn_delete_<%# Container.DataItemIndex %>').click();"></i>
                                            <asp:ImageButton ID="imgbtn_delete" style="display: none;" runat="server" Height="29px" ImageUrl="~/images/delete-icon.png"
                                                Width="30px" OnClientClick="return confirm('Are you sure want to delete it ?')"
                                                OnClick="imgbtn_delete_Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                           
                        </div>
                        <div class="row-fluid">
                        </div>
                        <div class="row-fluid">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
