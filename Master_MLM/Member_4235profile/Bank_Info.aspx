<%@ Page Title="" Language="C#" MasterPageFile="~/Member_4235profile/Member_main.Master" AutoEventWireup="true" CodeBehind="Bank_Info.aspx.cs" Inherits="Master_MLM.Member_4235profile.Bank_Info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .ddsmoothmenu ul li a.second {
            background-color: #F700A9;
            color: #fff;
        }

        table {
            width: 100%;
            margin: 0px;
            border-spacing: 0px;
            background-color: #EDF1F2;
        }

        .heading {
            background: url(images/h3-slogan-border.png) no-repeat 44px bottom;
            padding-bottom: 0px;
        }

        .bottomtd {
            padding: 5px 10px 10px 0px;
        }

        .lefttd {
            width: 170px;
            text-align: left;
            padding: 5px 0px 0px 40px;
            font-family: ebrima;
            font-size: 15px;
        }

        .righttd {
            padding: 5px 0px 0px 0px;
            text-align: left;
        }

        .trstyle {
            margin: 0px;
            padding: 7px;
            background-color: #F4F4F4;
            border-top: solid 1px #222;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="javascript:">Home</a> <i class="fa fa-angle-right"></i></li>
    </ol>

    <div class="grid-form">
        <div class="grid-form1">
            <h4 class="breadcrumb-item"><a>Edit Your Bank Info</a></h4>
            <div class="panel-body panel-footer">

                <div class="row" style="padding: 30px 0px 0px 0px;">
                    <div style="margin: 0px 0px 10px 0px; padding: 0px; float: left; width: 100%; height: auto;">
                        <p style="margin: 0px; padding: 0px; float: left; width: 100%; text-align: center">
                            <asp:Label ID="lbl_message" runat="server" Font-Bold="False" Font-Size="12pt" ForeColor="Red"></asp:Label>
                        </p>
                    </div>
                    <asp:Panel ID="Panel1" runat="server" Visible="False">

                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label for="txt_paename">Payee Name</label>
                                    <asp:TextBox ID="txt_paename" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label for="txt_bankname">Bank Name</label>
                                    <asp:TextBox ID="txt_bankname" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label for="txt_accno">Account No</label>
                                    <asp:TextBox ID="txt_accno" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label for="txt_ifsccode">IFSC Code</label>
                                    <asp:TextBox ID="txt_ifsccode" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label for="txt_bankbranch">Bank Branch</label>
                                    <asp:TextBox ID="txt_bankbranch" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label for="txtPANNumber">Pan No.</label>
                                    <asp:TextBox ID="txtPANNumber" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label for="txtAadharNo">Aadhar No.</label>
                                    <asp:TextBox ID="txtAadharNo" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-12 text-right">
                                <div class="form-group">
                                    <label for="btn_update">&nbsp;</label>
                                    <asp:Button ID="btn_update" CssClass="btn btn-success" Text="Update" runat="server" OnClick="btn_update_Click" />
                                </div>
                            </div>
                        </div>

                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
