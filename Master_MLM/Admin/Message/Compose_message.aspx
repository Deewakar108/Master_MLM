<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="Compose_message.aspx.cs" Inherits="Master_MLM.Admin.Compose_message"
    Title="Message Sent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
    Message Sent
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .ddsmoothmenu ul li a.ninth {
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
                <a href="#" class="current">Message</a>
                <a href="#" class="current">Send Message</a>
            </div>
        </div>

        <div class="container-fluid minimum-height">
            <div class="row-fluid">
                <div class="widget-box">
                    <div class="widget-title bg_lg">
                        <span class="icon"><i class="icon-signal"></i></span>
                        <h5>Send Message</h5>
                    </div>
                    <div class="widget-content">
                        <div class="row-fluid">
                            <div class="form-horizontal">
                                <div class="control-group">
                                    <label class="control-label">To : </label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddl_to" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">Subject : </label>
                                    <div class="controls">
                                        <asp:TextBox ID="txt_subject" runat="server" CssClass="span6"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_subject"
                                            Display="Dynamic" ErrorMessage="**"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">Message : </label>
                                    <div class="controls">
                                        <asp:TextBox ID="txt_message" runat="server" Rows="5" TextMode="MultiLine" CssClass="span6"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_message"
                                            Display="Dynamic" ErrorMessage="**"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <div class="controls">
                                        <asp:Button ID="btn_send" runat="server" Text="Send" CssClass="btn btn-success" OnClick="btn_send_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="span12" style="text-align: center;">
                                <asp:Label ID="lbl_message" runat="server" CssClass="label label-warning"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
