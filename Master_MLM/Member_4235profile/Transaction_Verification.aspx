<%@ Page Title="" Language="C#" MasterPageFile="~/Member_4235profile/Member_main.Master" AutoEventWireup="true" CodeBehind="Transaction_Verification.aspx.cs" Inherits="Master_MLM.Member_4235profile.Transaction_Verification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ol class="breadcrumb"><li class="breadcrumb-item"><a href="index.html">Home</a> <i class="fa fa-angle-right"></i>
        Transaction Verification</li></ol>

      <div class="grid-form">
        <div class="grid-form1">
            <h4 class="breadcrumb-item"><a>Transaction Password Verification</a></h4>
            <div class="panel-body panel-footer">
                 <asp:HiddenField ID="hd_url" runat="server" />
      <div class="row" style="padding: 30px 0px 0px 0px;">
        <div style="margin: 0px auto; height: auto; width: 411px;">
            <table style="border: 1px solid #cfc694; height: auto; margin: 0px 0px 20px 0px; background-color: White; border-spacing: 0px; width:100%;"
                border="0" class="round shadow">
                <tr>
                    <td style="text-align: left; padding: 10px 10px 10px 25px; font-family: arial, Helvetica, sans-serif;   font-weight: bold;"
                        class="blue_bg" colspan="5"><h4>Security Login</h4>
                    </td>
                </tr>
                
                <tr>
                    <td style="text-align: right; padding: 5px 10px 0px 10px; font-family: ebrima; font-size: 15px;"> Transaction Password :
                    </td>
                    <td style="padding: 5px 10px 0px 10px; text-align: left;" colspan="4">
                        <asp:TextBox ID="txt_new_password" runat="server" CssClass="form-control1" Style="width: 200px;"
                            TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
               
                <tr>
                    <td colspan="5" style="text-align: center;padding: 15px 10px 0px 10px;">
                        <asp:Button ID="btn_change_pwd" Text="Submit" runat="server" Style="width: 100px;"
                            Font-Bold="True" ForeColor="White" CssClass="btn btn-success" 
                            OnClick="btn_change_pwd_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5" style="text-align: center;padding: 10px 10px 10px 10px;">
                        <asp:Label ID="lbl_msg" runat="server" ForeColor="#FF6600" Font-Size="12pt"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>

    </div>
            </div>
        </div>
    </div>

    

</asp:Content>
