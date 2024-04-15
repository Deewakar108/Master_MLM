<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Member_4235profile/Member_main.Master" AutoEventWireup="true" CodeBehind="Member_1541_profile.aspx.cs" Inherits="Master_MLM.Member_4235profile.Member_1541_profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .ddsmoothmenu ul li a.second {
            background-color: #F700A9;
            color: #fff;
        }

        .middblock {
            width: 960px;
            margin: 0px auto;
            height: 906px;
            padding: 10px 0px 0px 0px;
        }

        .leftblock {
            width: 200px;
            margin: 0px 30px 0px 0px;
            height: 200px;
            padding: 0px 0px 0px 0px;
            float: left;
        }

        .rightblock {
            width: 729px;
            margin: 0px 0px 0px 0px;
            height: 200px;
            padding: 0px 0px 0px 0px;
            float: left;
        }

            .rightblock table {
                width: 729px;
                margin: 0px 0px 0px 0px;
                padding: 0px 0px 0px 0px;
                float: left;
                height: 194px;
            }

        .tdleft {
            width: 120px;
            padding: 0px 0px 0px 0px;
        }

        .rightblock h1 {
            width: 363px;
            margin: 0px 0px 0px 0px;
            padding: 0px 0px 0px 0px;
            float: left;
        }

        .lefttd {
            width: 150px;
            text-align: left;
            padding: 5px 0px 0px 40px;
            color: #6C6C6C;
        }

        .righttd {
            padding: 5px 0px 0px 0px;
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="index.html">Home</a> <i class="fa fa-angle-right"></i></li>
    </ol>

    <div class="grid-form">
        <div class="grid-form1">
            <h4 class="breadcrumb-item"><a>Member Profile</a></h4>
            <div class="panel-body panel-footer">
                <div id="notification">
                    <div id="pan" class="notificationpan">
                        <div style="float: left; width: auto; height: auto;">
                            <asp:Label ID="lbl_message" runat="server" Style="padding: 10px 20px 0px 10px; font-size: 15px; font-weight: bold;"></asp:Label>
                        </div>
                        <img src="../images/close.png" onclick="$(function () { $('.notificationpan').show().slideUp(1000);});"
                            class="closenotificationpan" alt="" />
                    </div>
                </div>
                <div class="row" style="padding: 0px 0px 0px 0px;">
                    <div class="block row1">
                        <div class="middblock" style="background-color: White;">
                            <div class="block" style="border: 1px solid lightgray; margin: 20px 0px 0px 0px;">
                                <div class="row">
                                    <div class="col-lg-6 text-center" style="padding-top: 10px;">
                                        <asp:Image ID="Img_member" CssClass="" runat="server" Height="169px" Width="170px" ImageUrl="~/Images/user.png" /><br />
                                        <h1>
                                            <asp:Label ID="lblname" runat="server" Font-Size="17pt" ForeColor="Black"></asp:Label>
                                        </h1>
                                    </div>
                                    <div class="col-lg-6">
                                        <table border="0" cellpadding="0" cellspacing="0" style="background-color: White;">
                                            <tr>
                                                <td colspan="2">

                                                    <h1>
                                                        <asp:FileUpload ID="FileUpload1" runat="server" Width="170px" CssClass="form-control" Style="float: left" />
                                                        <asp:ImageButton ID="imgbtn_upload" runat="server" Height="30px" ImageUrl="~/images/upload_button.jpg"
                                                            OnClick="imgbtn_upload_Click" Style="margin: 0px 10px 0px 12px; float: left;"
                                                            Width="102px" />


                                                    </h1>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdleft">Member code :
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_membercode" runat="server"></asp:Label>
                                                </td>
                                            </tr>


                                            <tr>
                                                <td class="tdleft">Mobile no. :
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_mobileno" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="tdleft">E-mail :
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_email" runat="server"></asp:Label>
                                                </td>
                                            </tr>


                                            <tr>
                                                <td>Date of Birth :
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_date_of_birth" runat="server" Font-Bold="False" Style="text-align: justify;"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Gender :
                                                </td>
                                                <td>
                                                    <asp:Label ID="lbl_gender" runat="server" Font-Bold="False" Style="text-align: justify;"></asp:Label>
                                                    <asp:Label ID="lbl_password" runat="server" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Status :
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblStatus" runat="server" Font-Bold="False" Style="text-align: justify;"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>

                            </div>

                            <div class="block" style="border: 1px solid lightgray; margin: 20px 0px 0px 0px;">

                                <div class="row" style="margin: 0px;">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="margin: 0px; padding: 0px;">
                                        <h2 style="font-size: 14px; color: #FFFFFF; text-decoration: none; font-weight: bold; padding: 10px 0px 10px 10px; margin: 0px; width: 216px; float: left; background-color: #F32C13;">Plan and Senior Details 
                                        </h2>
                                    </div>
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 10px;">
                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin: 0px; padding: 5px 0px; font-size: 14px;">
                                            Account Type :
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="padding: 5px 0px; font-size: 14px;">
                                            <asp:Label ID="lbl_acount_type" runat="server" Style="text-align: justify;"></asp:Label>
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin: 0px; padding: 0px 0px; font-size: 14px;">
                                            Package Name:
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="padding: 0px 0px; font-size: 14px;">
                                            <asp:Label ID="lbl_package" runat="server" Style="text-align: justify;"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin: 0px; padding: 5px 0px; font-size: 14px;">
                                            Purchase Date :
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="padding: 5px 0px; font-size: 14px;">
                                            <asp:Label ID="lbl_date" runat="server" Style="text-align: justify;"></asp:Label>
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin: 0px; padding: 0px 0px; font-size: 14px;">
                                            Package Amount :
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="padding: 0px 0px; font-size: 14px;">
                                            <i class="fa fa-rupee"></i>
                                            <asp:Label ID="lbl_joining_amount" runat="server" Style="text-align: justify;"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin: 0px; padding: 5px 0px; font-size: 14px;">
                                            Verification Date :
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="padding: 5px 0px; font-size: 14px;">
                                            <asp:Label ID="lbl_verificationdate" runat="server" Style="text-align: justify;"></asp:Label>
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin: 0px; padding: 0px 0px; font-size: 14px;">
                                            Sponsor Code :
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="padding: 0px 0px; font-size: 14px;">
                                            <asp:Label ID="lbl_sponser_code" runat="server" Style="text-align: justify;"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-bottom: 10px;">
                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin: 0px; padding: 5px 0px; font-size: 14px;">
                                            Sponsor Name :
                                        </div>
                                        <div class="col-lg-9 col-md-9 col-sm-6 col-xs-6" style="padding: 5px 0px; font-size: 14px;">
                                            <asp:Label ID="lbl_sponcer_name" runat="server" Style="text-align: justify;"></asp:Label>
                                            <asp:Label ID="Label1" runat="server" Style="text-align: justify;" Visible="false" Text="****************"></asp:Label>
                                        </div>
                                    </div>
                                </div>


                            </div>
                            <div class="block" style="border: 1px solid lightgray; margin: 20px 0px 0px 0px;">


                                <div class="row" style="margin: 0px;">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="margin: 0px; padding: 0px;">
                                        <h2 style="font-size: 14px; color: #FFFFFF; text-decoration: none; font-weight: bold; padding: 10px 0px 10px 10px; margin: 0px; width: 216px; float: left; background-color: #F32C13;">Personal Details
                                        </h2>
                                    </div>
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 10px;">
                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin: 0px; padding: 5px 0px; font-size: 14px;">
                                            Father&#39;s Name :
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="padding: 5px 0px; font-size: 14px;">
                                            <asp:Label ID="lbl_fathername" runat="server" Style="text-align: justify;"></asp:Label>
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin: 0px; padding: 0px 0px; font-size: 14px;">
                                            Full Address :
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="padding: 0px 0px; font-size: 14px;">
                                            <asp:Label ID="lbl_address" runat="server" Style="text-align: justify;"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin: 0px; padding: 5px 0px; font-size: 14px;">
                                            District :
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="padding: 5px 0px; font-size: 14px;">
                                            <asp:Label ID="lbl_district" runat="server" Style="text-align: justify;"></asp:Label>
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin: 0px; padding: 0px 0px; font-size: 14px;">
                                            State :
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="padding: 0px 0px; font-size: 14px;">
                                            <asp:Label ID="lbl_state" runat="server" Style="text-align: justify;"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-bottom: 10px;">
                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin: 0px; padding: 5px 0px; font-size: 14px;">
                                            City :
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="padding: 5px 0px; font-size: 14px;">
                                            <asp:Label ID="lbl_city" runat="server" Style="text-align: justify;"></asp:Label>
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin: 0px; padding: 0px 0px; font-size: 14px;">
                                            Pin Code :
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="padding: 0px 0px; font-size: 14px;">
                                            <asp:Label ID="lbl_pincode" runat="server" Style="text-align: justify;"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="block" style="border: 1px solid lightgray; margin: 20px 0px 0px 0px;">

                                <div class="row" style="margin: 0px;">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="margin: 0px; padding: 0px;">
                                        <h2 style="font-size: 14px; color: #FFFFFF; text-decoration: none; font-weight: bold; padding: 10px 0px 10px 10px; margin: 0px; width: 216px; float: left; background-color: #F32C13;">Nominee Details
                                        </h2>
                                    </div>
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 10px;">
                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin: 0px; padding: 5px 0px; font-size: 14px;">
                                            Name :
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="padding: 5px 0px; font-size: 14px;">
                                            <asp:Label ID="lbl_nominee_name" runat="server" Style="text-align: justify;"></asp:Label>
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin: 0px; padding: 0px 0px; font-size: 14px;">
                                            Relation :
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="padding: 0px 0px; font-size: 14px;">
                                            <asp:Label ID="lbl_nominee_relation" runat="server" Style="text-align: justify;"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-bottom: 10px;">

                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin: 0px; padding: 5px 0px; font-size: 14px;">
                                            Age :
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="padding: 5px 0px; font-size: 14px;">
                                            <asp:Label ID="lbl_nominee_age" runat="server" Style="text-align: justify;"></asp:Label>
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin: 0px; padding: 0px 0px; font-size: 14px;">
                                            Gender :
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="padding: 0px 0px; font-size: 14px;">
                                            <asp:Label ID="lbl_nominee_gender" runat="server"
                                                Style="text-align: justify;"></asp:Label>
                                        </div>
                                    </div>


                                </div>

                            </div>
                            <div class="block" style="border: 1px solid lightgray; margin: 20px 0px 20px 0px;">


                                <div class="row" style="margin: 0px;">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="margin: 0px; padding: 0px;">
                                        <h2 style="font-size: 14px; color: #FFFFFF; text-decoration: none; font-weight: bold; padding: 10px 0px 10px 10px; margin: 0px; width: 216px; float: left; background-color: #F32C13;">Bank Account Details
                                        </h2>
                                    </div>
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-top: 10px;">
                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin: 0px; padding: 5px 0px; font-size: 14px;">
                                            Bank Name :
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="padding: 5px 0px; font-size: 14px;">
                                            <asp:Label ID="lbl_bank_name" runat="server" Style="text-align: justify;"></asp:Label>
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin: 0px; padding: 0px 0px; font-size: 14px;">
                                            Branch :
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="padding: 0px 0px; font-size: 14px;">
                                            <asp:Label ID="lbl_bank_branch" runat="server" Style="text-align: justify;"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin: 0px; padding: 5px 0px; font-size: 14px;">
                                            Account No. :
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="padding: 5px 0px; font-size: 14px;">
                                            <asp:Label ID="lbl_account_no" runat="server" Style="text-align: justify;"></asp:Label>
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin: 0px; padding: 0px 0px; font-size: 14px;">
                                            IFSC Code :
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="padding: 0px 0px; font-size: 14px;">
                                            <asp:Label ID="lbl_ifsc_code" runat="server" Style="text-align: justify;"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" style="padding-bottom: 10px;">

                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin: 0px; padding: 5px 0px; font-size: 14px;">
                                            Payee Name :
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="padding: 5px 0px; font-size: 14px;">
                                            <asp:Label ID="lbl_payee_name" runat="server" Style="text-align: justify;"></asp:Label>
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="margin: 0px; padding: 0px 0px; font-size: 14px;">
                                            PAN No.:
                                        </div>
                                        <div class="col-lg-3 col-md-3 col-sm-6 col-xs-6" style="padding: 0px 0px; font-size: 14px;">
                                            <asp:Label ID="lbl_panno" runat="server" Style="text-align: justify;"></asp:Label>
                                        </div>
                                    </div>

                                </div>

                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>




</asp:Content>
