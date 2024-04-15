<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Master_MLM.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Welcome To Ocean Health Pariwar
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/angularjs/1.4.8/angular.min.js"></script>

    <style>
        .menubar nav > ul > li > a.home {
            color: #70c108;
        }
    </style>

    <link href="fancybox/jquery.fancybox.css" rel="stylesheet" />
    <script src="fancybox/jquery.fancybox.js"></script>
    <link href="ProductSlider/style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <%-- -------------------POPUP---------------------------%>
    <%--<script type="text/javascript">
        jQuery(document).ready(function ($) {
            $.fancybox({
                href: "images/popup.png",
                width: "800",
                top: "200"

            });
        }); // ready
    </script>--%>

    <div class="slider-iner">
        <section class="rev_slider_wrapper">
            <div id="slider1" class="rev_slider" data-version="5.0">
                <ul>

                    <li data-transition="fade">
                        <img src="images/slider/s4.png" alt="" width="1920" height="500" data-bgposition="top center" data-bgfit="cover" data-bgrepeat="no-repeat" data-bgparallax="1" title="Ocean Health Pariwar" />

                        <div class="tp-caption tp-resizeme"
                            data-x="center" data-hoffset=""
                            data-y="center" data-voffset="-70"
                            data-transform_idle="o:1;"
                            data-transform_in="x:[-175%];y:0px;z:0;rX:0;rY:0;rZ:0;sX:1;sY:1;skX:0;skY:0;opacity:0.01;s:3000;e:Power3.easeOut;"
                            data-transform_out="s:1000;e:Power3.easeInOut;s:1000;e:Power3.easeInOut;"
                            data-mask_in="x:[100%];y:0;s:inherit;e:inherit;"
                            data-splitin="none"
                            data-splitout="none"
                            data-responsive_offset="on"
                            data-start="500">
                            <div class="slide-content-box center">
                                <h4>Welcome To Ocean Health Pariwar</h4>
                                <h1>The Best Company of<br />
                                    <span>Ocean Health Pariwar</span> </h1>
                                <%--  <p>
                                        Sed ut perspiciatis, unde omnis iste natus error sit voluptatem accusantium doloremque la<br>
                                        udantium, totam rem aperiam eaque ipsa, quae ab illo inventore
                                    </p>--%>
                            </div>
                        </div>
                        <div class="tp-caption tp-resizeme"
                            data-x="center" data-hoffset="0"
                            data-y="center" data-voffset="80"
                            data-transform_idle="o:1;"
                            data-transform_in="y:[100%];z:0;rX:0deg;rY:0;rZ:0;sX:1;sY:1;skX:0;skY:0;opacity:0;s:2000;e:Power4.easeInOut;"
                            data-transform_out="s:1000;e:Power3.easeInOut;s:1000;e:Power3.easeInOut;"
                            data-splitin="none"
                            data-splitout="none"
                            data-responsive_offset="on"
                            data-start="1500">
                            <div class="slide-content-box">
                                <div class="button">
                                    <a class="thm-btn" href="RegistrationForm.aspx#Regis">JOIN NOW</a>
                                </div>
                            </div>
                        </div>
                    </li>


                    <li data-transition="fade">
                        <img src="images/slider/s3.jpg" alt="" width="1920" height="500" data-bgposition="top center" data-bgfit="cover" data-bgrepeat="no-repeat" data-bgparallax="1" title="Ocean Health Pariwar" />

                        <div class="tp-caption tp-resizeme"
                            data-x="center" data-hoffset=""
                            data-y="center" data-voffset="-70"
                            data-transform_idle="o:1;"
                            data-transform_in="x:[-175%];y:0px;z:0;rX:0;rY:0;rZ:0;sX:1;sY:1;skX:0;skY:0;opacity:0.01;s:3000;e:Power3.easeOut;"
                            data-transform_out="s:1000;e:Power3.easeInOut;s:1000;e:Power3.easeInOut;"
                            data-mask_in="x:[100%];y:0;s:inherit;e:inherit;"
                            data-splitin="none"
                            data-splitout="none"
                            data-responsive_offset="on"
                            data-start="500">
                            <div class="slide-content-box center">
                                <h4>Welcome To Ocean Health Pariwar</h4>
                                <h1>The Best Company of<br />
                                    <span>Ocean Health Pariwar</span> </h1>
                                <%--  <p>
                                        Sed ut perspiciatis, unde omnis iste natus error sit voluptatem accusantium doloremque la<br>
                                        udantium, totam rem aperiam eaque ipsa, quae ab illo inventore
                                    </p>--%>
                            </div>
                        </div>
                        <div class="tp-caption tp-resizeme"
                            data-x="center" data-hoffset="0"
                            data-y="center" data-voffset="80"
                            data-transform_idle="o:1;"
                            data-transform_in="y:[100%];z:0;rX:0deg;rY:0;rZ:0;sX:1;sY:1;skX:0;skY:0;opacity:0;s:2000;e:Power4.easeInOut;"
                            data-transform_out="s:1000;e:Power3.easeInOut;s:1000;e:Power3.easeInOut;"
                            data-splitin="none"
                            data-splitout="none"
                            data-responsive_offset="on"
                            data-start="1500">
                            <div class="slide-content-box">
                                <div class="button">
                                    <a class="thm-btn" href="RegistrationForm.aspx#Regis">JOIN NOW</a>
                                </div>
                            </div>
                        </div>
                    </li>

                    <li data-transition="fade">
                        <img src="images/slider/s2.jpg" alt="" width="1920" height="500" data-bgposition="top center" data-bgfit="cover" data-bgrepeat="no-repeat" data-bgparallax="1" title="Ocean Health Pariwar" />


                        <div class="tp-caption tp-resizeme"
                            data-x="center" data-hoffset=""
                            data-y="center" data-voffset="-70"
                            data-transform_idle="o:1;"
                            data-transform_in="x:[-175%];y:0px;z:0;rX:0;rY:0;rZ:0;sX:1;sY:1;skX:0;skY:0;opacity:0.01;s:3000;e:Power3.easeOut;"
                            data-transform_out="s:1000;e:Power3.easeInOut;s:1000;e:Power3.easeInOut;"
                            data-mask_in="x:[100%];y:0;s:inherit;e:inherit;"
                            data-splitin="none"
                            data-splitout="none"
                            data-responsive_offset="on"
                            data-start="500">
                            <div class="slide-content-box center">
                                <h4>Welcome To Ocean Health Pariwar</h4>
                                <h1>The Best Company of<br />
                                    <span>Ocean Health Pariwar</span> </h1>
                                <%--<p>
                                        Sed ut perspiciatis, unde omnis iste natus error sit voluptatem accusantium doloremque la<br>
                                        udantium, totam rem aperiam eaque ipsa, quae ab illo inventore
                                    </p>--%>
                            </div>
                        </div>
                        <div class="tp-caption tp-resizeme"
                            data-x="center" data-hoffset="0"
                            data-y="center" data-voffset="80"
                            data-transform_idle="o:1;"
                            data-transform_in="y:[100%];z:0;rX:0deg;rY:0;rZ:0;sX:1;sY:1;skX:0;skY:0;opacity:0;s:2000;e:Power4.easeInOut;"
                            data-transform_out="s:1000;e:Power3.easeInOut;s:1000;e:Power3.easeInOut;"
                            data-splitin="none"
                            data-splitout="none"
                            data-responsive_offset="on"
                            data-start="1500">
                            <div class="slide-content-box">
                                <div class="button">
                                    <a class="thm-btn" href="RegistrationForm.aspx#Regis">JOIN NOW</a>
                                </div>
                            </div>
                        </div>
                    </li>

                </ul>
            </div>
        </section>

    </div>
    <section>
        <div class="welcome-section">
            <div class="col-lg-8 col-md-8 col-sm-12 col-xs-12 welcome-space">
                <div class="welcome-sec-main">
                </div>
                <div class="welcom-pa">
                    <h2 class="welcome-sec-main-h2">Welcome to Ocean Health Pariwar </h2>
                    <p class="welcom-pa-p">
                        We, (Ocean Health Pariwar) are one of the best A Company in India. The Company is also engaged in creating awareness about the ayurveda around the globe. Ayueveda is 5000 years old science which has gifted a Precious treasure of Natural remedies and healing process which is truly a boon to us in this present time44. Adopting Ayurveda is not only safe for human body but it also provides a lifetime cure for any disease.

                    </p>
                    <div class="welcome-btn">
                        <a class="welcome-btn-a" href="About_Company.aspx#health" title="Ocean Health Pariwar ">learn now</a>
                    </div>
                </div>
            </div>
            <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 welcome-space">
                <div class="welcome-img-sec">
                    <img src="images/about.png" class="img-responsive" title="Ocean Health Pariwar " />
                </div>
            </div>
        </div>
    </section>
    <section>
        <div class="mission-sec">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <div class="our-miss">
                            <p class="our-miss-p">Welcome To Ocean Health Pariwar</p>
                            <h2 class="our-miss-h2">OUR MISSION & VISION</h2>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="ourservice-sec">
                        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                            <div class="our-section">
                                <div class="ser-image">
                                    <img src="images/service.png" class="img-responsive ser-image2" title="Ocean Health Pariwar" />
                                    <h2 class="ser-image-h2">Our Service</h2>
                                    <p class="ser-image-p">
                                        Dummy text Welcome to Company  Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in
                                    a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock
                                    </p>
                                    <div class="ser-button">
                                        <a class="ser-button-a" href="javascript:" title="">Read More &nbsp;<i class="fa fa-angle-double-right" aria-hidden="true"></i></a>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                            <div class="our-section">
                                <div class="ser-image">
                                    <img src="images/mission.png" class="img-responsive ser-image2" title="Ocean Health Pariwar" />
                                    <h2 class="ser-image-h2">Missio & Visionn</h2>
                                    <p class="ser-image-p">
                                        We, (Ocean Health Pariwar) are one of the best A Company in India. The Company is also engaged We encourages
                                       Comprehensive approach to health, which Understands the individual as a complex Combition of elements Capable
                                    </p>
                                    <div class="ser-button">
                                        <a class="ser-button-a" href="Mission_Vision.aspx#health" title="">Read More &nbsp;<i class="fa fa-angle-double-right" aria-hidden="true"></i></a>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                            <div class="our-section">
                                <div class="ser-image">
                                    <img src="images/vision.png" class="img-responsive ser-image2" title="Ocean Health Pariwar" />
                                    <h2 class="ser-image-h2">Our Aim</h2>
                                    <p class="ser-image-p">
                                        Dummy text Welcome to Company Contrary to popular belief, Lorem Ipsum is not simply random text. It has roots in
                                    a piece of classical Latin literature from 45 BC, making it over 2000 years old. Richard McClintock
                                    </p>
                                    <div class="ser-button">
                                        <a class="ser-button-a" href="javascript:" title="">Read More &nbsp;<i class="fa fa-angle-double-right" aria-hidden="true"></i></a>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </section>
    <%-- ...........product********************** --%>
    <section>
        <div class="welcome-text" data-ng-app="productsApp">
            <div class="background-bg" data-ng-controller="myProductsCtrl">
                <div class="container">
                    <div class="welcome-text-iner">
                        <div class="leading-text">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <h2 class="our-product-h2">Product - </h2>
                                <div style="margin: 0px; padding: 0px; width: 100%; float: left;">
                                    <ul id="flexiselDemo2">
                                        <li class="nbs-flexisel-item" data-ng-repeat="x in products">
                                            <div class="image-box">
                                                <figure>
                                                    <a href="product.aspx">
                                                        <img src="{{x.Image_path}}" alt="Ocean Health Pariwar" style="height:260px; width:100%" /></a>
                                                    <div class="bike-sec">
                                                        <p class="figure-p">{{x.Product_name}}</p>
                                                    </div>
                                                </figure>
                                            </div>
                                        </li>
                                    </ul>

                                </div>




                                <%--<section class="about-section">
                                    <div class="owl-sec">
                                        <div class="three-column-carousel">



                                            <div class="item-holder">
                                                <div class="image-box">
                                                    <figure>
                                                        <a href="#">
                                                            <img src="images/product_syrup/2.jpg" alt="Ocean Health Pariwar" /></a>
                                                        <div class="bike-sec">
                                                            <p class="figure-p">GRITMUKT SYRUP</p>
                                                        </div>
                                                    </figure>
                                                </div>
                                            </div>
                                            <div class="item-holder">
                                                <div class="image-box">
                                                    <figure>
                                                        <a href="#">
                                                            <img src="images/product_syrup/3.jpg" alt="Ocean Health Pariwar" /></a>
                                                        <div class="bike-sec">
                                                            <p class="figure-p">OCEDIAB SYRUP</p>
                                                        </div>
                                                    </figure>
                                                </div>
                                            </div>
                                            <div class="item-holder">
                                                <div class="image-box">
                                                    <figure>
                                                        <a href="#">
                                                            <img src="images/product_syrup/4.jpg" alt="Ocean Health Pariwar" /></a>
                                                        <div class="bike-sec">
                                                            <p class="figure-p">OCITUS COUGH SYRUP</p>
                                                        </div>
                                                    </figure>
                                                </div>
                                            </div>
                                            <div class="item-holder">
                                                <div class="image-box">
                                                    <figure>
                                                        <a href="#">
                                                            <img src="images/product_syrup/5.jpg" alt="Ocean Health Pariwar" /></a>
                                                        <div class="bike-sec">
                                                            <p class="figure-p">LIVKRIT - DS SYRUP</p>
                                                        </div>
                                                    </figure>
                                                </div>
                                            </div>
                                            <div class="item-holder">
                                                <div class="image-box">
                                                    <figure>
                                                        <a href="#">
                                                            <img src="images/product_syrup/6.jpg" alt="Ocean Health Pariwar" /></a>
                                                        <div class="bike-sec">
                                                            <p class="figure-p">OCIRON SYRUP</p>
                                                        </div>
                                                    </figure>
                                                </div>
                                            </div>
                                            <div class="item-holder">
                                                <div class="image-box">
                                                    <figure>
                                                        <a href="#">
                                                            <img src="images/product_syrup/7.jpg" alt="Ocean Health Pariwar" /></a>
                                                        <div class="bike-sec">
                                                            <p class="figure-p">KRITZYME SYRUP</p>
                                                        </div>
                                                    </figure>
                                                </div>
                                            </div>
                                            <div class="item-holder">
                                                <div class="image-box">
                                                    <figure>
                                                        <a href="#">
                                                            <img src="images/product_syrup/8.jpg" alt="Ocean Health Pariwar" /></a>
                                                        <div class="bike-sec">
                                                            <p class="figure-p">OCIVIT SYRUP</p>
                                                        </div>
                                                    </figure>
                                                </div>
                                            </div>
                                            <div class="item-holder">
                                                <div class="image-box">
                                                    <figure>
                                                        <a href="#">
                                                            <img src="images/product_syrup/9.jpg" alt="Ocean Health Pariwar" /></a>
                                                        <div class="bike-sec">
                                                            <p class="figure-p">LIVKRIT SYRUP</p>
                                                        </div>
                                                    </figure>
                                                </div>
                                            </div>
                                            <div class="item-holder">
                                                <div class="image-box">
                                                    <figure>
                                                        <a href="#">
                                                            <img src="images/product_syrup/10.jpg" alt="Ocean Health Pariwar" /></a>
                                                        <div class="bike-sec">
                                                            <p class="figure-p">OCERAKT SYRUP</p>
                                                        </div>
                                                    </figure>
                                                </div>
                                            </div>
                                            <div class="item-holder">
                                                <div class="image-box">
                                                    <figure>
                                                        <a href="#">
                                                            <img src="images/product_syrup/11.jpg" alt="Ocean Health Pariwar" /></a>
                                                        <div class="bike-sec">
                                                            <p class="figure-p">COUGH SYRUP</p>
                                                        </div>
                                                    </figure>
                                                </div>
                                            </div>
                                            <div class="item-holder">
                                                <div class="image-box">
                                                    <figure>
                                                        <a href="#">
                                                            <img src="images/product_syrup/12.jpg" alt="Ocean Health Pariwar" /></a>
                                                        <div class="bike-sec">
                                                            <p class="figure-p">OCECID SYRUP</p>
                                                        </div>
                                                    </figure>
                                                </div>
                                            </div>
                                            <div class="item-holder">
                                                <div class="image-box">
                                                    <figure>
                                                        <a href="#">
                                                            <img src="images/product_syrup/13.jpg" alt="Ocean Health Pariwar" /></a>
                                                        <div class="bike-sec">
                                                            <p class="figure-p">CEREBRO SYRUP</p>
                                                        </div>
                                                    </figure>
                                                </div>
                                            </div>
                                            <div class="item-holder">
                                                <div class="image-box">
                                                    <figure>
                                                        <a href="#">
                                                            <img src="images/product_syrup/14.jpg" alt="Ocean Health Pariwar" /></a>
                                                        <div class="bike-sec">
                                                            <p class="figure-p">OCEFEM SYRUP</p>
                                                        </div>
                                                    </figure>
                                                </div>
                                            </div>
                                            <div class="item-holder">
                                                <div class="image-box">
                                                    <figure>
                                                        <a href="#">
                                                            <img src="images/product_syrup/15.jpg" alt="Ocean Health Pariwar" /></a>
                                                        <div class="bike-sec">
                                                            <p class="figure-p">ACTIVATOR SYRUP</p>
                                                        </div>
                                                    </figure>
                                                </div>
                                            </div>

                                            <div class="item-holder">
                                                <div class="image-box">
                                                    <figure>
                                                        <a href="#">
                                                            <img src="images/product_syrup/16.jpg" alt="Ocean Health Pariwar" /></a>
                                                        <div class="bike-sec">
                                                            <p class="figure-p">PYNACE PAIN OIL</p>
                                                        </div>
                                                    </figure>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </section>--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section>
        <div class="rewards">
            <div class="container">
                <div class="row">
                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 welcome-rewards">
                        <div class="rewards-border-red">
                            <div class="rewards-slide">
                                <h2>Rewards Achievers</h2>
                                <div class="rewards-box-images1">
                                    <img src="images/topachiever.png" class="img-responsive rewards-box-images2" title="" />
                                </div>
                                <marquee onmouseover="stop();" onmouseout="start ();" scrollamount="3" scrolldelay="1" direction="up">
                            <table class="table">
                              <tr>
                                  <td rowspan="2">
                                      <img src="images/marquee images.png" alt="" />
                                  </td>
                                  <td>Achievers Name</td>
                              </tr>
                              <tr>
                                  <td>Achievers</td>
                              </tr>                   
                                 <tr>
                                  <td rowspan="2">
                                      <img src="images/marquee images.png" alt="" />
                                  </td>
                                  <td>Achievers Name</td>
                              </tr>
                              <tr>
                                  <td>Achievers</td>
                              </tr>
                               <tr>
                                  <td rowspan="2">
                                      <img src="images/marquee images.png" alt="" />
                                  </td>
                                  <td>Achievers Name</td>
                              </tr>
                              <tr>
                                  <td>Achievers</td>
                              </tr>
                                    <tr>
                                  <td rowspan="2">
                                      <img src="images/marquee images.png" alt="" />
                                  </td>
                                  <td>Achievers Name</td>
                              </tr>
                              <tr>
                                  <td>Achievers</td>
                              </tr>
                          </table>
                      </marquee>
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 welcome-rewards">
                        <div class="welcome-reward2">
                            <div class="rewards-slide" style="background-color: #fff;">
                                <h2 style="background-color: #09bbf1;">Top Rewards</h2>
                                <div class="rewards-box-images3">
                                    <img src="images/rewards1.png" class="img-responsive rewards-box-images4" title="" />
                                </div>
                                <marquee onmouseover="stop();" onmouseout="start ();" scrollamount="3" scrolldelay="1" direction="up">
                                 <table class="table">
                                  
                                      <tr>
                                  <td rowspan="1">
                                      <img src="images/rewards.png" alt=""/>
                                  </td>
                                         <td style="padding-top:25px">Reward Name </td>
                                    </tr>                                   
                                  <tr>
                                  <td rowspan="1">
                                      <img src="images/rewards.png" alt=""/>
                                  </td>
                                        <td style="padding-top:25px">Reward Name </td>
                                    </tr>
                                   <tr>
                                  <td rowspan="1">
                                      <img src="images/rewards.png" alt=""/>
                                  </td>
                                         <td style="padding-top:25px">Reward Name </td>
                                    </tr>
                                   <tr>
                                  <td rowspan="1">
                                       <img src="images/rewards.png" alt=""/>
                                   </td>
                                          <td style="padding-top:25px">Reward Name </td>
                                    </tr>
                                 </table>
                            </marquee>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 welcome-rewards">
                        <div class="rewards-border-green">
                            <div class="rewards-slide">
                                <h2>Latest News</h2>
                                <div class="rewards-box-images5">
                                    <img src="images/news1.png" class="img-responsive rewards-box-images6" title="" />
                                </div>
                                <marquee onmouseover="stop();" onmouseout="start ();" scrollamount="3" scrolldelay="1" direction="up">
                                <div class="latest-news">
                                    <ul>
                                        <li><a href="javascript:" title="">Welcome to Ocean Health Pariwar</a> </li>
                                       <li><a href="javascript:" title="">Welcome to Ocean Health Pariwar</a> </li>
                                       <li><a href="javascript:" title="">Welcome to Ocean Health Pariwar</a> </li>
                                       <li><a href="javascript:" title="">Welcome to Ocean Health Pariwar</a> </li>
                                       <li><a href="javascript:" title="">Welcome to Ocean Health Pariwar</a> </li>
                                      <li><a href="javascript:" title="">Welcome to Ocean Health Pariwar</a> </li>
                                       <li><a href="javascript:" title="">Welcome to Ocean Health Pariwar</a> </li>
                                       <li><a href="javascript:" title="">Welcome to Ocean Health Pariwar</a> </li>
                                    </ul>
                                </div>
                            </marquee>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <%-- ............footer.............. --%>

    <script type="text/javascript">
        var app = angular.module('productsApp', []);
        app.controller('myProductsCtrl', function ($scope, $http) {
            $http.get("WebService1.asmx/fetch_product_details").then(function (response) {
                $scope.products = response.data;
                if ($scope.products == "") {
                    alert("Sorry no data found");
                }
            })
        });
    </script>
 
    <!-- //banner slider -->
    <script type="text/javascript">
        $(window).load(function () {
            $("#flexiselDemo2").flexisel({
                visibleItems: 4,
                animationSpeed: 1000,
                autoPlay: true,
                autoPlaySpeed: 3000,
                pauseOnHover: true,
                enableResponsiveBreakpoints: true,
                responsiveBreakpoints: {
                    portrait: {
                        changePoint: 480,
                        visibleItems: 1
                    },
                    landscape: {
                        changePoint: 640,
                        visibleItems: 1
                    },
                    tablet: {
                        changePoint: 768,
                        visibleItems: 1
                    }
                }
            });

        });
    </script>
    <script src="ProductSlider/jquery.flexisel.js"></script>


    <%-- <script src="js/owl.carousel.min.js"></script>
    <script src="js/script.js"></script>--%>
</asp:Content>
