<%@ Page Title="" Language="C#" MasterPageFile="~/Member_4235profile/Member_main.Master" AutoEventWireup="true" CodeBehind="Activate_your_id.aspx.cs" Inherits="Master_MLM.Member_4235profile.Activate_your_id" %>


<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .ddsmoothmenu ul li a.tenth {
            color: #ffffff;
            background: #0597D5;
            background: url( 'menu.png' ) repeat left top #007AC5;
        }

        .box h3 {
            text-align: center;
            position: relative;
        }

        .box {
            width: 70%;
            /*height: 100px;*/
            background: #FFF;
            margin: 40px auto;
        }

        .effect1 {
            -webkit-box-shadow: 0 10px 6px -6px #777;
            -moz-box-shadow: 0 10px 6px -6px #777;
            box-shadow: 0 10px 6px -6px #777;
        }

        p {
            margin: 5px !important;
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="index.html">Home</a> <i class="fa fa-angle-right"></i></li>
    </ol>

    <div class="grid-form">
        <div class="grid-form1">
            <h4 class="breadcrumb-item"><a>Member Activation</a></h4>
            <div class="panel-body panel-footer">
                <div class="row" style="padding: 0px 0px 0px 0px;">
                    <div style="margin: 0px auto; padding: 0px; width: 100%; height: auto;">
                        <div style="margin: 0px; padding: 0px; width: 100%; height: auto; float: left;">

                            <div class="col-lg-4">
                            </div>
                            <div class="col-lg-4" style="padding: 10px 0px; border: 1px solid #5cb85c;">
                                <div class="col-lg-12" style="display: none;">
                                    <div class="form-group">
                                        <label for="txt_paename">Enter Epin</label>
                                        <asp:TextBox ID="txt_epin" CssClass="form-control" runat="server" Enabled="false" ReadOnly="True"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                            Display="Dynamic" ControlToValidate="txt_epin" ValidationGroup="gg1" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <label>Epin Details</label>
                                        <asp:Label ID="lblEpinDetails" runat="server" Text="" CssClass="form-control"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-lg-12" style="padding-bottom: 10px;">
                                    <div class="form-group">
                                        <label style="float: left; width: 22%;">Member Code</label>
                                        <asp:TextBox ID="txtMemberCode" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                                            Display="Dynamic" ControlToValidate="txtMemberCode" ValidationGroup="gg1" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                                        <br />
                                        <asp:Button ID="btn_member" runat="server" CssClass="btn btn-success" Text="Find" OnClick="btn_member_Click" />
                                    </div>
                                </div>
                                <div class="col-lg-12" style="padding-bottom: 10px;">
                                    <div class="form-group">
                                        <label style="float: left; width: 22%;">Member Name</label>
                                        <asp:TextBox ID="txt_membername" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-lg-12">
                                    <div class="form-group">

                                        <asp:Button ID="btn_activate" runat="server" CssClass="btn btn-success" Text="Activate" OnClick="btn_activate_Click" Visible="false" ValidationGroup="gg1" />
                                        <br />
                                        <br />
                                        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                                        <asp:HiddenField ID="hdfPackage" runat="server"></asp:HiddenField>
                                        <asp:HiddenField ID="hdfPackageAmount" runat="server" />
                                        <asp:HiddenField ID="hdfPackageRewardPoint" runat="server" />
                                        <asp:HiddenField ID="hdfMatchingIncome" runat="server" />
                                        <asp:HiddenField ID="hdfPackageID" runat="server" />

                                        <asp:HiddenField ID="hdfRewardBV" runat="server" />
                                        <asp:HiddenField ID="hdfRepurchaseBV" runat="server" />

                                        &nbsp;
                                    </div>
                                </div>


                            </div>

                            <div class="col-lg-4">
                            </div>

                             


                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>




    <div id="notification">
        <div id="pan" class="notificationpan">
            <div style="float: left; width: 300px; height: auto;">
                <asp:Label ID="lbl_msg" runat="server" Style="padding: 10px 20px 0px 20px; font-size: 17px; color: #ffffff; font-weight: bold;"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
