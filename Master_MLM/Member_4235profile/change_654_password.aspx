<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/Member_4235profile/Member_main.Master" AutoEventWireup="true"
    CodeBehind="change_654_password.aspx.cs" Inherits="Master_MLM.Member_4235profile.change_654_password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <!--ALERT-->
        <input onclick="return AlertMessage()" type="button" value="Show" id="btnAlert" style="display: none;" />
        <input type="hidden" id="hdfAlertMessage" />
        <div class="wthree-typo" style="padding: 10px;" id="divAlert" runat="server" visible="false">

            <script>
                function AlertClick(message) { $("#btnAlert").click(); }
                function AlertMessage() {

                    $("#divAlert").show().fadeOut(5000);
                    return false;
                }
            </script>
            <div class="grid_3 grid_5 w3ls" style="padding: 2px; margin: 0;">
                <%--<div class="alert alert-success" role="alert" style="margin: 0;">
					<strong>Well done!</strong>
                    <asp:Label ID="lbl_msg" runat="server" Text=""></asp:Label>
				</div>
				<div class="alert alert-info" role="alert">
					<strong>Heads up!</strong> This alert needs your attention, but it's not super important.
				</div>
				<div class="alert alert-warning" role="alert">
					<strong>Warning!</strong> Best check yo self, you're not looking too good.
				</div>--%>
                <div class="alert alert-danger" role="alert">
                    <asp:Label ID="lbl_msg" runat="server" Text=""></asp:Label>
                </div>
            </div>

        </div>
    </div>

    <div class="grid-form">
        <div class="grid-form1">
            <h4 class="breadcrumb-item"><a>Change Password</a></h4>
            <div class="panel-body panel-footer">
                <div role="form" class="form-horizontal">
                    <div class="form-group">
                        <label class="col-md-2 control-label">Old Password</label>
                        <div class="col-md-8">
                            <div class="input-group">
                                <span class="input-group-addon">
                                    <i class="fa fa-key"></i>
                                </span>
                                <%--<input type="password" class="form-control1" id="exampleInputPassword1" placeholder="Password">--%>
                                <asp:TextBox ID="txt_old_password" runat="server" class="form-control1" placeholder="Password" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-2 control-label">New Password</label>
                        <div class="col-md-8">
                            <div class="input-group">
                                <span class="input-group-addon">
                                    <i class="fa fa-key"></i>
                                </span>
                                <%--<input type="password" class="form-control1" id="Password1" placeholder="Password">--%>
                                <asp:TextBox ID="txt_new_password" runat="server" class="form-control1" placeholder="Password" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-md-2 control-label">Retype Password</label>
                        <div class="col-md-8">
                            <div class="input-group">
                                <span class="input-group-addon">
                                    <i class="fa fa-key"></i>
                                </span>
                                <%--<input type="password" class="form-control1" id="Password2" placeholder="Password">--%>
                                <asp:TextBox ID="txt_confirm_password" runat="server" class="form-control1" placeholder="Password" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <div class="panel-footer">
                <div class="row">
                    <div class="col-sm-4 col-sm-offset-4">

                        <asp:Button ID="btn_change_pwd" class="btn-primary btn" runat="server" Text="Submit" OnClick="btn_change_pwd_Click" />
                    </div>
                </div>
            </div>

        </div>
    </div>




</asp:Content>
