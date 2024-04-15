<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Legal.aspx.cs" Inherits="Master_MLM.Legal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Title" runat="server">
    Legal
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <section>
        <div class="other-page-sec">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <h2 class="other-page-head">Legal</h2>
                    </div>
                </div>
            </div>
        </div>
    </section>


    <section>
        <div class="business-plan-wrap">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <div class="plan-inner">
                            <h2 class="plan-innerlegal-h2">Legal</h2>
                        </div>
                    </div>
                </div>
                <div class="plan-bg-legal">
                    <div class="row">
                        <%-- <div class="secter-img">
                            <h3 class="raddy-header">Certificate of Incorporation</h3>
                            <img src="images/doc2.jpg" class="legal-imgone" />
                            </div>
                           <h3 class="raddy-header">Certificate of G M P</h3>
                            <img src="images/doc1.jpg" class="legal-imgone" />
                            <h3 class="raddy-header">PAN CARD</h3>
                            <img src="images/doc3.jpg" class="legal-imgone" />--%>
                        <div class="hom-img-glry-sec">
                            <div class="agileinfo-gallery-row">
                               <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                    <h3 class="raddy-header">Certificate of Incorporation</h3>
                                        <a href="images/doc2.jpg" class="hovereffect">
                                            <img src="images/doc2.jpg" alt="Integer Foundation" />
                                        </a>
                                </div>
                                <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                     <h3 class="raddy-header">Certificate of G M P</h3>
                                        <a href="images/doc1.jpg" class="hovereffect">
                                            <img src="images/doc1.jpg" alt="Integer Foundation" />
                                        </a>
                                </div>
                                <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12">
                                    <h3 class="raddy-header">PAN CARD</h3>
                                        <a href="images/doc3.jpg" class="hovereffect">
                                            <img src="images/doc3.jpg" alt="Integer Foundation" />
                                        </a>
                                </div>
                                <div class="clearfix"></div>
                                <script src="Gallery/simple-lightbox.min.js"></script>
                                <script>
                                    $(function () {
                                        var gallery = $('.agileinfo-gallery-row a').simpleLightbox({ navText: ['&lsaquo;', '&rsaquo;'] });
                                    });
                                </script>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
