<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="About_Company.aspx.cs" Inherits="Master_MLM.About_Company" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
About Company
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
 <style>
        .menubar nav > ul > li > a.about {
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
                        <h2 class="other-page-head">About Company</h2>
                    </div>
                </div>
            </div>
        </div>
    </section>


<section>

    <%--<section>
        <div class="img-sec">
           <img src="images/about-bgimages.jpg" class="img-responsive" title="" />
        </div>
    </section>--%>

         <div class="business-plan-wrap">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <div class="business-plan-sec">
                            <div class="plan-inner">
                                <%--<p class="plan-inner-p">Welcome To Ocean Health Pariwar</p>--%>
                                <h2 class="plan-inner-h2">About Company</h2>
                            </div>
                        </div>
                    </div>
                </div>


                <div class="plan-bg">
                    <div class="row">
                        <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12" style="float: right;">
                            <div class="plan-img">
                                <img src="images/about_us.jpg" class="img-responsive" style="border: 2px solid #ec888f; border-radius: 20px;" />
                            </div>
                        </div>
                        
                        <div class="col-lg-7 col-md-7 col-sm-12 col-xs-12" style="float: left;">
                            <div class="ocien-text">
                                <p class="ocien-text-p">We, (Ocean Health Pariwar) are one of the best A Company in India. The Company is also engaged 
                                  in creating awareness about the ayurveda around the globe. Ayueveda is 5000 years old science which 
                                    has gifted a Precious treasure of Natural remedies and healing process which is truly a boon to
                                     us in this present time44. Adopting Ayurveda is not only safe for human body but it also
                                     provides a lifetime cure for any disease. </p>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
