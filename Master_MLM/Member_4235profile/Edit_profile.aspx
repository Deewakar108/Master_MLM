<%@ Page Title="" Language="C#" MasterPageFile="~/Member_4235profile/Member_main.Master" AutoEventWireup="true"
    CodeBehind="Edit_profile.aspx.cs" Inherits="Master_MLM.Member_4235profile.Edit_profile" %>

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
        <li class="breadcrumb-item"><a href="index.html">Home</a> <i class="fa fa-angle-right"></i></li>
    </ol>
    <div class="grid-form">
        <div class="grid-form1">
            <h4 class="breadcrumb-item"><a>Edit Profile</a></h4>
            <div class="panel-body panel-footer">
                <div class="row" style="padding: 0px 0px 0px 0px;">
                    <div style="margin: 0px 0px 10px 0px; padding: 0px; float: left; width: 100%; height: auto;">
                        <p style="margin: 0px; padding: 0px; float: left; width: 100%; text-align: center">
                            <asp:Label ID="lbl_message" runat="server" Font-Bold="False" Font-Size="12pt" ForeColor="Red"></asp:Label>
                        </p>
                    </div>
                    <div style="margin: 0px 0px 10px 0px; padding: 0px; float: left; width: 100%; height: auto;">
                        <div class="middblock" style="background-color: White;">
                            <asp:Panel ID="Panel1" runat="server">


                                <div class="block" style="border: 1px solid lightgray; margin: 20px 0px 20px 0px;">


                                    <div class="row" style="margin: 0px;">
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="margin: 0px; padding: 0px;">
                                            <h2 style="font-size: 14px; color: #FFFFFF; text-decoration: none; font-weight: bold; padding: 10px 0px 10px 10px; margin: 0px; width: 216px; float: left; background-color: #F32C13;">Joining Information
                                            </h2>
                                        </div>
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 10px;">
                                            <asp:Panel ID="Panel2" runat="server" Visible="false">
                                                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin: 0px; padding: 5px 0px; font-size: 14px;">
                                                    Sponsor Code :
                                                </div>
                                                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="padding: 5px 0px; font-size: 14px;">
                                                    <asp:TextBox ID="txt_sponsorcode" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
                                                </div>
                                                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin: 0px; padding: 0px 0px; font-size: 14px;">
                                                    Sponsor Name :
                                                </div>
                                                <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="padding: 0px 0px; font-size: 14px;">
                                                    <asp:TextBox ID="txt_sponsorname" runat="server" ReadOnly="true" class="form-control"></asp:TextBox>
                                                </div>
                                            </asp:Panel>
                                        </div>
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin: 0px; padding: 5px 0px; font-size: 14px;">
                                                Member Code :
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="padding: 5px 0px; font-size: 14px;">
                                                <asp:Label ID="txt_member_code" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin: 0px; padding: 0px 0px; font-size: 14px;">
                                                Joining Package :
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="padding: 0px 0px; font-size: 14px;">
                                                <asp:Label ID="lbl_joining_package" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-bottom: 10px;">

                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin: 0px; padding: 5px 0px; font-size: 14px;">
                                                Joining Date :
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="padding: 5px 0px; font-size: 14px;">
                                                <asp:Label ID="lbl_joining_date" runat="server"></asp:Label>
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin: 0px; padding: 0px 0px; font-size: 14px;">
                                                Verification Date:
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="padding: 0px 0px; font-size: 14px;">
                                                <asp:Label ID="lbl_verificationdate" runat="server"></asp:Label>
                                            </div>
                                        </div>

                                    </div>

                                </div>


                                <div class="block" style="border: 1px solid lightgray; margin: 20px 0px 20px 0px;">


                                    <div class="row" style="margin: 0px;">
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="margin: 0px; padding: 0px;">
                                            <h2 style="font-size: 14px; color: #FFFFFF; text-decoration: none; font-weight: bold; padding: 10px 0px 10px 10px; margin: 0px; width: 216px; float: left; background-color: #F32C13;">Personal Details
                                            </h2>
                                        </div>
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding: 10px 0px 0px 0px; font-size: 14px;">
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin-bottom: 5px; padding-right: 0px;">
                                                Name :
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin-bottom: 5px; padding-left: 0px;">

                                                <asp:TextBox ID="txt_name" runat="server" class="textcolor" Style="width: 100%;"
                                                    ReadOnly="true" Enabled="False"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                                    Display="Dynamic" ControlToValidate="txt_name" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin-bottom: 5px; padding-right: 0px;">
                                                Father&#39;s Name :
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin-bottom: 5px; padding-left: 0px;">
                                                <asp:TextBox ID="txt_fathername" runat="server" class="form-control" Style="width: 100%;"></asp:TextBox>
                                            </div>

                                        </div>
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding: 10px 0px 0px 0px; font-size: 14px;">

                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin-bottom: 5px; padding-right: 0px;">
                                                Date of Birth :
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin-bottom: 5px; padding-left: 0px;">

                                                <asp:TextBox ID="txt_dob" CssClass="form-control" Width="100%" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin-bottom: 5px; padding-right: 0px;">
                                                Gender :
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin-bottom: 5px; padding-left: 0px;">

                                                <asp:DropDownList ID="ddl_gender" runat="server" CssClass="form-control" Style="color: Green; font-weight: bold; width: 100%;">
                                                    <asp:ListItem>Male</asp:ListItem>
                                                    <asp:ListItem>Female</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding: 10px 0px 0px 0px; font-size: 14px;">
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin-bottom: 5px; padding-right: 0px;">
                                                Address :
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin-bottom: 5px; padding-left: 0px;">

                                                <asp:TextBox ID="txt_address" runat="server" CssClass="form-control" Style="width: 100%; height: 50px" TextMode="MultiLine"></asp:TextBox>
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin-bottom: 5px; padding-right: 0px;">
                                                Pin Code:
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin-bottom: 5px; padding-left: 0px;">

                                                <asp:TextBox ID="txt_pincode" runat="server" CssClass="form-control" Width="100%" MaxLength="6"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding: 10px 0px 0px 0px; font-size: 14px;">
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin-bottom: 5px; padding-right: 0px;">
                                                State :
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin-bottom: 5px; padding-left: 0px;">

                                                <asp:DropDownList ID="ddl_state" runat="server" CssClass="form-control" Style="color: Green; font-weight: bold; width: 100%;"
                                                    AutoPostBack="True" OnSelectedIndexChanged="ddl_state_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin-bottom: 5px; padding-right: 0px;">
                                                District :
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin-bottom: 5px; padding-left: 0px;">

                                                <asp:DropDownList ID="ddl_district" runat="server" CssClass="form-control" Style="color: Green; font-weight: bold; width: 100%;">
                                                </asp:DropDownList>
                                            </div>

                                        </div>
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding: 10px 0px 0px 0px; font-size: 14px;">
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin-bottom: 5px; padding-right: 0px;">
                                                City :
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin-bottom: 5px; padding-left: 0px;">

                                                <asp:TextBox ID="txt_city" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin-bottom: 5px; padding-right: 0px;">
                                                Mobile No. :
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin-bottom: 5px; padding-left: 0px;">

                                                <asp:TextBox ID="txtmobileno" runat="server" CssClass="form-control" Width="100%" ReadOnly="true"></asp:TextBox>
                                            </div>

                                        </div>

                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding: 10px 0px 0px 0px; font-size: 14px;">
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin-bottom: 5px; padding-right: 0px;">
                                                Email Id :
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin-bottom: 5px; padding-left: 0px;">

                                                <asp:TextBox ID="txtemailid" runat="server" class="form-control" Width="100%"></asp:TextBox>
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin-bottom: 5px; padding-right: 0px;">
                                                PAN No. :
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin-bottom: 5px; padding-left: 0px;">

                                                <asp:TextBox ID="txtpannumber" runat="server" class="form-control" Width="100%"></asp:TextBox>
                                            </div>

                                        </div>

                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding: 10px 0px 0px 0px; font-size: 14px;">
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin-bottom: 5px; padding-right: 0px;">
                                                Nominee Name :
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin-bottom: 5px; padding-left: 0px;">

                                                <asp:TextBox ID="txt_nomineename" runat="server" class="form-control" Width="100%"></asp:TextBox>
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin-bottom: 5px; padding-right: 0px;">
                                                Nominee Relation :
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin-bottom: 5px; padding-left: 0px;">

                                                <asp:TextBox ID="txt_nomineerelation" runat="server" class="form-control" Width="100%"></asp:TextBox>
                                            </div>
                                        </div>

                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding: 10px 0px 10px 0px; font-size: 14px;">
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin-bottom: 5px; padding-right: 0px;">
                                                Nominee Age :
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin-bottom: 5px; padding-left: 0px;">

                                                <asp:TextBox ID="txt_nomineeage" runat="server" class="form-control" Width="100%"></asp:TextBox>
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin-bottom: 5px; padding-right: 0px;">
                                                Nominee Gender :
                                            </div>
                                            <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin-bottom: 5px; padding-left: 0px;">

                                                <asp:DropDownList ID="ddl_nomineegender" CssClass="form-control" runat="server" Style="color: Green; font-weight: bold; width: 100%;">
                                                    <asp:ListItem>Male</asp:ListItem>
                                                    <asp:ListItem>Female</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="block" style="border: 1px solid lightgray; margin: 20px 0px 20px 0px;">


                                    <div class="row" style="margin: 0px;">

                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 10px;">
                                            <asp:Button ID="btn_update" CssClass="btn btn-success " Text="Update" runat="server" Style="width: 100px; height: 35px;"
                                                OnClick="btn_update_Click" /><br />
                                        </div>



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
