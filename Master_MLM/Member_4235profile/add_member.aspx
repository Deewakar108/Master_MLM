<%@ Page Title="Add New Member" Language="C#" MasterPageFile="~/Member_4235profile/Member_main.Master" AutoEventWireup="true" CodeBehind="add_member.aspx.cs" Inherits="Master_MLM.Member_4235profile.add_member" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .panel {
            background: transparent !important;
        }

        .grid-form1 {
             padding: 0em !important; 
        }

         .col-xs-1, .col-sm-1, .col-md-1, .col-lg-1, .col-xs-2, .col-sm-2, .col-md-2, .col-lg-2, .col-xs-3, .col-sm-3, .col-md-3, .col-lg-3, 
            .col-xs-4, .col-sm-4, .col-md-4, .col-lg-4, .col-xs-5, .col-sm-5, .col-md-5, .col-lg-5, .col-xs-6, .col-sm-6, .col-md-6, .col-lg-6, 
            .col-xs-7, .col-sm-7, .col-md-7, .col-lg-7, .col-xs-8, .col-sm-8, .col-md-8, .col-lg-8, .col-xs-9, .col-sm-9, .col-md-9, .col-lg-9, 
            .col-xs-10, .col-sm-10, .col-md-10, .col-lg-10, .col-xs-11, .col-sm-11, .col-md-11, .col-lg-11, .col-xs-12, .col-sm-12, .col-md-12, 
            .col-lg-12 {
                padding-right: 2px !important;
                padding-left: 2px !important;
            }
    </style>

    <script>
        function IsChecked() {
            if ($("#<%=chkTermAndCondition.ClientID%>").prop('checked')) { return true; }
            else { alert('Please check box for term & condition.'); }
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:HiddenField ID="hdfRewardBV" runat="server" Value="0" />
    <asp:HiddenField ID="hdfRepurchaseBV" runat="server" Value="0" />

    <div class="grid-form">
        <div class="grid-form1">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
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
                            <div class="alert alert-danger" role="alert">
                                <asp:Label ID="lbl_msg" runat="server" Text=""></asp:Label>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="panel panel-success">
                    <div class="panel-heading">
                        <h4 class="breadcrumb-item"><a>Registration Form</a></h4>

                    </div>
                    <div class="panel-body">
                        <div class="panel panel-info">
                            <div class="panel-heading">
                                <h5 class="breadcrumb-item"><a>Spiller & Sponsor Information</a></h5>
                            </div>
                            <div class="panel-body">
                                <div class="form-horizontal">
                                    <div class="form-group">
                                        <label for="inputPassword3" class="col-lg-2 col-md-2 col-sm-2 col-xs-4  control-label">Position<sup>*</sup> </label>
                                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-8">
                                            <div class="radio-inline">
                                                <label>
                                                    <asp:RadioButton ID="rdbLeft" runat="server" GroupName="Position" />
                                                    Left</label>
                                            </div>
                                            <div class="radio-inline" style="display: none;">
                                                <label>
                                                    <asp:RadioButton ID="rdbMiddle" runat="server" GroupName="Position" />
                                                    Middle</label>
                                            </div>
                                            <div class="radio-inline">
                                                <label>
                                                    <asp:RadioButton ID="rdbRight" runat="server" GroupName="Position" />
                                                    Right</label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group" >
                                        <label for="inputEmail3" class="col-lg-2 col-md-2 col-sm-2 col-xs-12 control-label">Spiller ID<sup>*</sup></label>
                                        <div class="col-lg-8 col-md-8 col-sm-8 col-xs-9">
                                            <input type="text" class="form-control" id="txtReferralID" runat="server" style="height: auto; text-transform: uppercase;" placeholder="Spiller ID" />
                                        </div>
                                        <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">
                                            <asp:Button ID="btnFindReferral" runat="server" CssClass="btn btn-primary" OnClick="btnFindReferral_Click" Text="Find" />
                                        </div>
                                    </div>

                                    <div class="form-group" >
                                        <label for="inputPassword3" class="col-lg-2 col-md-2 col-sm-2 col-xs-12  control-label">Spiller Name<sup>*</sup></label>
                                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                            <input type="text" class="form-control" id="txtReferralName" style="height: auto;" disabled="disabled" runat="server" placeholder="Spiller Name" />
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label for="inputEmail3" class="col-lg-2 col-md-2 col-sm-2 col-xs-12 control-label">Sponsor ID<sup>*</sup></label>
                                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                            <input type="text" class="form-control" id="txtSponsorID" disabled="disabled" runat="server" style="height: auto; text-transform: uppercase;" placeholder="Sponsor ID" />
                                        </div>
                                        <%--<div class="col-lg-2 col-md-2 col-sm-2 col-xs-12">
                                            <asp:Button ID="btnFindSponsor" runat="server" CssClass="btn btn-primary" OnClick="btnFindSponsor_Click" Text="Find" />
                                        </div>--%>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputPassword3" class="col-lg-2 col-md-2 col-sm-2 col-xs-12  control-label">Sponsor Name<sup>*</sup></label>
                                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                            <input type="text" class="form-control" id="txtSponsorName" style="height: auto;" disabled="disabled" runat="server" placeholder="Sponsor Name" />
                                        </div>
                                    </div>
                                    <div class="form-group" style="display: none;">
                                        <label for="inputPassword3" class="col-lg-2 col-md-2 col-sm-2 col-xs-12  control-label">Package Name</label>
                                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                            <asp:DropDownList ID="ddlPackage" CssClass="form-control" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputPassword3" class="col-lg-2 col-md-2 col-sm-2 col-xs-12  control-label">E-Pin</label>
                                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                            <asp:TextBox ID="txtEPin" CssClass="form-control" Style="height: auto;" runat="server"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="form-group" style="display: none;">
                                        <label for="inputPassword3" class="col-lg-2 col-md-2 col-sm-2 col-xs-12  control-label">Bank Name</label>
                                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                            <asp:TextBox ID="txtReferralBankName" CssClass="form-control" Style="height: auto;" runat="server" Text="NO-NEED"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group" style="display: none;">
                                        <label for="inputPassword3" class="col-lg-2 col-md-2 col-sm-2 col-xs-12  control-label">DD No.</label>
                                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                            <asp:TextBox ID="txtDDNumber" CssClass="form-control" Style="height: auto;" runat="server" Text="NO-NEED"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel-body">
                        <div class="panel panel-info">
                            <div class="panel-heading">
                                <h5 class="breadcrumb-item"><a>Personal Information</a></h5>
                            </div>
                            <div class="panel-body">
                                <div class="form-horizontal">

                                    <div class="form-group">
                                        <label for="inputPassword3" class="col-lg-2 col-md-2 col-sm-2 col-xs-12 control-label">Full Name<sup>*</sup></label>
                                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                            <input type="text" class="form-control height-auto" id="txtFullName" runat="server" placeholder="Full Name" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputPassword3" class="col-lg-2 col-md-2 col-sm-2 col-xs-4 control-label">Gender<sup>*</sup></label>
                                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-8">
                                            <div class="radio-inline">
                                                <label>
                                                    <asp:RadioButton ID="rdbMale" runat="server" GroupName="Gender" />
                                                    Male</label>
                                            </div>
                                            <div class="radio-inline">
                                                <label>
                                                    <asp:RadioButton ID="rdbFemale" runat="server" GroupName="Gender" />
                                                    Female</label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputPassword3" class="col-lg-2 col-md-2 col-sm-2 col-xs-12 control-label">Date of Birth<sup>*</sup></label>
                                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                            <div class="row">
                                                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-3">
                                                    <asp:DropDownList ID="ddlDate" class="form-control height-auto" runat="server" Style="padding: 6px 3px;">
                                                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                                        <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                                        <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                        <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                                        <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                                        <asp:ListItem Text="13" Value="13"></asp:ListItem>
                                                        <asp:ListItem Text="14" Value="14"></asp:ListItem>
                                                        <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                                        <asp:ListItem Text="16" Value="16"></asp:ListItem>
                                                        <asp:ListItem Text="17" Value="17"></asp:ListItem>
                                                        <asp:ListItem Text="18" Value="18"></asp:ListItem>
                                                        <asp:ListItem Text="19" Value="19"></asp:ListItem>
                                                        <asp:ListItem Text="20" Value="20"></asp:ListItem>
                                                        <asp:ListItem Text="21" Value="21"></asp:ListItem>
                                                        <asp:ListItem Text="22" Value="22"></asp:ListItem>
                                                        <asp:ListItem Text="23" Value="23"></asp:ListItem>
                                                        <asp:ListItem Text="24" Value="24"></asp:ListItem>
                                                        <asp:ListItem Text="25" Value="25"></asp:ListItem>
                                                        <asp:ListItem Text="26" Value="26"></asp:ListItem>
                                                        <asp:ListItem Text="27" Value="27"></asp:ListItem>
                                                        <asp:ListItem Text="28" Value="28"></asp:ListItem>
                                                        <asp:ListItem Text="29" Value="29"></asp:ListItem>
                                                        <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                                        <asp:ListItem Text="31" Value="31"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>

                                                <div class="col-lg-2 col-md-2 col-sm-2 col-xs-3">
                                                    <asp:DropDownList ID="ddlMonth" class="form-control height-auto" runat="server" Style="padding: 6px 3px;">
                                                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                        <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                                        <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                                        <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                                        <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                                        <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                        <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                                        <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-6">
                                                    <asp:DropDownList ID="ddlYear" class="form-control height-auto" runat="server"></asp:DropDownList>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label for="inputPassword3" class="col-lg-2 col-md-2 col-sm-2 col-xs-12 control-label">Email ID</label>
                                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                            <input type="text" class="form-control height-auto" id="txtEmail" runat="server" placeholder="Email" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputPassword3" class="col-lg-2 col-md-2 col-sm-2 col-xs-12 control-label">Mobile No.<sup>*</sup></label>
                                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                            <input type="text" class="form-control height-auto" id="txtMobile" runat="server" placeholder="Mobile No." />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel-body">
                        <div class="panel panel-info">
                            <div class="panel-heading">
                                <h5 class="breadcrumb-item"><a>Postal Information</a></h5>
                            </div>
                            <div class="panel-body">
                                <div class="form-horizontal">
                                    <div class="form-group">
                                        <label for="inputEmail3" class="col-lg-2 col-md-2 col-sm-2 col-xs-12 control-label hor-form">Pin Code</label>
                                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                            <input type="text" class="form-control height-auto" id="txtPIN" runat="server" placeholder="Pin Code" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputEmail3" class="col-lg-2 col-md-2 col-sm-2 col-xs-12 control-label hor-form">Select State<sup>*</sup></label>
                                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">

                                            <asp:DropDownList AutoPostBack="true" ID="ddlState" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" CssClass="form-control height-auto" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputEmail3" class="col-lg-2 col-md-2 col-sm-2 col-xs-12 control-label hor-form">Select District<sup>*</sup></label>
                                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                            <asp:DropDownList ID="ddlDistrict" CssClass="form-control height-auto" runat="server"></asp:DropDownList>

                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputEmail3" class="col-lg-2 col-md-2 col-sm-2 col-xs-12 control-label hor-form">City</label>
                                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                            <input type="text" class="form-control height-auto" id="txtCity" runat="server" placeholder="City" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputEmail3" class="col-lg-2 col-md-2 col-sm-2 col-xs-12 control-label hor-form">Full Address</label>
                                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                            <%--<input type="text" class="form-control" id="Email7" placeholder="Email" />--%>
                                            <textarea class="form-control height-auto" id="txtAddress" style="resize: none;" rows="5" runat="server" placeholder="Address"></textarea>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="panel-body">
                        <div class="panel panel-info">
                            <div class="panel-heading">
                                <h5 class="breadcrumb-item"><a>Bank Information</a></h5>
                            </div>
                            <div class="panel-body">
                                <div class="form-horizontal">
                                    <div class="form-group">
                                        <label for="inputEmail3" class="col-lg-2 col-md-2 col-sm-2 col-xs-12 control-label hor-form">IFSC Code</label>
                                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                            <input type="text" class="form-control height-auto" id="txtIFSCCode" runat="server" placeholder="IFSC Code" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputEmail3" class="col-lg-2 col-md-2 col-sm-2 col-xs-12 control-label hor-form">Bank Name</label>
                                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                            <input type="text" class="form-control height-auto" id="txtBankName" runat="server" placeholder="Bank Name" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputEmail3" class="col-lg-2 col-md-2 col-sm-2 col-xs-12 control-label hor-form">Branch Name </label>
                                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                            <input type="text" class="form-control height-auto" id="txtBranchName" runat="server" placeholder="Branch Name " />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputEmail3" class="col-sm-2 control-label hor-form">Account No</label>
                                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                            <input type="text" class="form-control height-auto" id="txtAccounNo" runat="server" placeholder="Account No" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputEmail3" class="col-lg-2 col-md-2 col-sm-2 col-xs-12 control-label hor-form">Payee Name </label>
                                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                            <input type="text" class="form-control height-auto" id="txtPayeeName" runat="server" placeholder="Payee Name " />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputEmail3" class="col-lg-2 col-md-2 col-sm-2 col-xs-12 control-label hor-form">Pan No.</label>
                                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                            <input type="text" class="form-control height-auto" id="txtPAN" runat="server" placeholder="Pan No." />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputEmail3" class="col-lg-2 col-md-2 col-sm-2 col-xs-12 control-label hor-form">Aadhar No.</label>
                                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                            <input type="text" class="form-control height-auto" id="txtAadhar" runat="server" placeholder="Aadhar No." />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel-body">
                        <div class="panel panel-info">
                            <div class="panel-heading">
                                <h5 class="breadcrumb-item"><a>Nominee Information</a></h5>
                            </div>
                            <div class="panel-body">
                                <div class="form-horizontal">

                                    <div class="form-group">
                                        <label for="inputPassword3" class="col-lg-2 col-md-2 col-sm-2 col-xs-12 control-label">Nominee Name</label>
                                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                            <input type="text" class="form-control height-auto" id="txtNomineeName" runat="server" placeholder="Nominee Name" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputPassword3" class="col-lg-2 col-md-2 col-sm-2 col-xs-4 control-label">Gender</label>
                                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-8">
                                            <div class="radio-inline">
                                                <label>
                                                    <asp:RadioButton ID="rdbNomineeMale" runat="server" GroupName="NomineeGender" />
                                                    Male</label>
                                            </div>
                                            <div class="radio-inline">
                                                <label>
                                                    <asp:RadioButton ID="rdbNomineeFemale" runat="server" GroupName="NomineeGender" />
                                                    Female</label>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label for="inputPassword3" class="col-lg-2 col-md-2 col-sm-2 col-xs-12 control-label">Age</label>
                                        <div class="col-lg-2 col-md-2 col-sm-3 col-xs-6">
                                            <input type="text" class="form-control height-auto" id="txtNomineeAge" runat="server" placeholder="Age" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputPassword3" class="col-lg-2 col-md-2 col-sm-2 col-xs-12 control-label">Nominee Relation</label>
                                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                            <input type="text" class="form-control height-auto" id="txtNomineeRelation" runat="server" placeholder="Nominee Relation (Blood Relation Only)" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel-body">
                        <div class="panel panel-info">
                            <div class="panel-heading">
                                <h5 class="breadcrumb-item"><a>Security Information</a></h5>
                            </div>
                            <div class="panel-body">
                                <div class="form-horizontal">
                                    <div class="form-group" style="display: none;">
                                        <label for="inputEmail3" class="col-lg-2 col-md-2 col-sm-2 col-xs-12 control-label hor-form">User Name<sup>*</sup> </label>
                                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                            <input type="text" class="form-control height-auto" id="txtUserName" runat="server" placeholder="User Name"  />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="inputEmail3" class="col-lg-2 col-md-2 col-sm-2 col-xs-12 control-label hor-form">Login Password<sup>*</sup> </label>
                                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12">
                                            <input type="password" class="form-control height-auto" id="txtPassword" runat="server" placeholder="Password"  />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="panel-footer">
                        <div class="row">
                            <div class="col-lg-6" style="display:  none;">
                                <asp:CheckBox ID="chkTermAndCondition" runat="server" Checked="true" /> &nbsp; <a href="term_and_condition.aspx" target="_blank">Term & Condition</a>
                            </div>
                            <div class="col-lg-12 text-right">
                                <asp:Button ID="btnSubmit" OnClientClick="return IsChecked();" runat="server" Text="Submit" CssClass="btn btn-success" OnClick="btnSubmit_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                </div>
            </div>
            <%--<h4 class="breadcrumb-item"><a>Add New Member</a><span style="float: right;">
                <a href="javascript:printDiv('epin_generated')" style="display: none;">
                    <img src="../images/printer.png" height="20" width="20" border="0" alt=" " /></a>
                <asp:ImageButton ID="img_export" runat="server" Height="20px" Width="20px" ImageUrl="~/images/Excelicons.png"
                    Style="display: none; margin-left: 20px" OnClick="img_export_Click" /></span></h4>
            <div class="panel-body panel-footer">
                <div id="notification">
                    <div id="pan" class="notificationpan" style="background-color: red;">
                        <div style="float: left; width: auto; height: auto;">
                            <asp:Label ID="lbl_message1" runat="server" Style="padding: 10px 20px 0px 10px; background-position: left center; background-image: url(   '../images/warningicon.png' ); background-repeat: no-repeat; font-size: 15px; color: #ffffff; font-weight: bold; padding: 10px;"></asp:Label>
                        </div>

                    </div>
                </div>
                <div class="row" style="padding: 3px 0px 0px 0px;">
                    
                </div>
                <iframe name="print_frame" width="0" height="0" frameborder="0" src="about:blank"></iframe>
            </div>--%>
        </div>
    </div>

    <asp:HiddenField ID="hdfPackageName" runat="server" Value="0" />
    <asp:HiddenField ID="hdfPackageAmount" runat="server" Value="0" />
    <asp:HiddenField ID="hdfRewardPoint" runat="server" Value="0" />
    <asp:HiddenField ID="hdfMatchingIncome" runat="server" Value="0" />
    <asp:HiddenField ID="hdfPackageID" runat="server" Value="0" />
    <asp:HiddenField ID="hdfIsActivationPackage" runat="server" Value="0" />
</asp:Content>
