<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="contact_us.aspx.cs" Inherits="Master_MLM.contact_us" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Contact Us
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <style>
        .menubar nav > ul > li > a.contact {
            color: #70c108;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <section>
        <div class="other-page-sec">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <h2 class="other-page-head">Contact Us</h2>
                    </div>
                </div>
            </div>
        </div>
    </section>
    
    

     <div class="business-plan-wrap">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="business-plan-sec">
                        <div class="plan-inner">
                            <h2 class="plan-inner-h2">Contact Us</h2>
                        </div>
                    </div>
                </div>
                 </div>

                    <div class="row">
                        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                            <div class="address-boxsec">
                                <div class="text-sec-contact">
                                    <i class="fa fa-map-marker text-sec-contact-i" aria-hidden="true"></i>
                                    <p class="text-sec-contact-p">Shop No. 10, Adarsh Colony, OPP Lauwala Gurdwara, Sanoli Road Panipat (Haryana)</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                            <div class="address-boxsec">
                                <div class="text-sec-contact">
                                    <i class="fa fa-phone text-sec-contact-i" aria-hidden="true"></i>
                                    <a href="tell:+91 00000000000" class="text-sec-contact-p" title="">+91 XXXXXXXXXX</a>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                            <div class="address-boxsec">
                                <div class="text-sec-contact">
                                    <i class="fa fa-envelope-o text-sec-contact-i" aria-hidden="true"></i>
                                    <a href="mailto:info@oceanhealthpariwar.com" class="text-sec-contact-p" title="">info@oceanhealthpariwar.com </a>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                            <div class="box-sec3">
                                <div class="map-sec-map">

                                    <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3476.5583879114133!2d77.01275671470026!3d29.383217082127622!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x390dd080c113212b%3A0xcd46e744a06b52e0!2sSanoli+Rd%2C+Sewah+Kheri%2C+Ujra+Keri+Village%2C+Panipat+Taraf+Afghan%2C+Haryana+132103!5e0!3m2!1sen!2sin!4v1528956969452" width="100%" height="300" frameborder="0" style="border:0" allowfullscreen></iframe>
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-8 col-md-8 col-sm-12 col-xs-12">
                            <div class="box-sec">
                                <div class="row">
                                    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                        <div class="name-sec">
                                            <asp:DropDownList ID="DropDownList1" runat="server" Class="form-control purpose-text" placeholder="Purpose">
                                                <asp:ListItem>Purpose</asp:ListItem>
                                                <asp:ListItem>Feedback</asp:ListItem>
                                                <asp:ListItem>Suggestion </asp:ListItem>
                                                <asp:ListItem>Complain </asp:ListItem>
                                                <asp:ListItem>Other </asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                        <div class="name-sec">

                                            <asp:TextBox ID="TextBox1" runat="server" Class="form-control purpose-tex" placeholder="Name *"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                        <div class="name-sec">
                                            <asp:TextBox ID="TextBox3" runat="server" Class="form-control purpose-tex" placeholder="E-mail Id *"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">
                                        <div class="name-sec">
                                            <asp:TextBox ID="TextBox2" runat="server" Class="form-control purpose-tex" MaxLength="10" placeholder="Mobile No *"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <div class="name-sec">
                                            <textarea name="message *" rows="2" cols="20" id="txt_message" class="form-control purpose-tex" placeholder="Message *" style="height: 100px;"></textarea>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <div class="name-sec">
                                            <div class="sub-buttons">
                                                <asp:Button ID="Button1" runat="server" Class="submit-button" Text="Submit" />
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
