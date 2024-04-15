<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Mission_Vision.aspx.cs" Inherits="Master_MLM.Mission_Vision" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
Mission Vision
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
                        <h2 class="other-page-head">Mission & Vision</h2>
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
                                <%--<p class="plan-inner-p">Welcome To Ocean Health Pariwar</p>--%>
                                <h2 class="plan-inner-h2">Mission & Vision</h2>
                            </div>
                        </div>
                    </div>
                </div>


                <div class="plan-bg">
                    <div class="row">
                        <div class="col-lg-5 col-md-5 col-sm-12 col-xs-12" style="float: right;">
                            <div class="plan-img">
                                <img src="images/mission.jpg" class="img-responsive" style="border: 2px solid #ec888f; border-radius: 20px;" />
                            </div>
                        </div>
                        
                        <div class="col-lg-7 col-md-7 col-sm-12 col-xs-12" style="float: left;">
                            <div class="ocien-text">
                                <p class="ocien-text-p">We, (Ocean Health Pariwar) are one of the best A Company in India. The Company is also engaged 
                                 We encourages Comprehensive approach to health, which Understands the individual as a complex Combition of elements Capable of being brought into harmony. We are committed to enhancing Positivity and well being in individuals, the environment and the global Community.

                                </p>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
</asp:Content>
