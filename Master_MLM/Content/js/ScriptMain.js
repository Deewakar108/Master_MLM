(function ($) {
    "use strict";
    

    var nav = $('.navbar');
    $(window).scroll(function () {
        if ($(this).scrollTop() > 80) {
            nav.addClass("fixed-header");
        } else {
            nav.removeClass("fixed-header");
        }
    });
    $(document).ready(function () {
        $('#nav-expander').on('click', function (e) {
            e.preventDefault();
            $('body').toggleClass('nav-expanded');
        });
        $('#nav-close').on('click', function (e) {
            e.preventDefault();
            $('body').removeClass('nav-expanded');
        });
    });
    $(document).ready(function () {
        var dropDown = $('li.dropdown');
        if ($('.navbar-expand-md .navbar-toggler').css('display') == 'none') {
            dropDown.on({
                mouseenter: function () {
                    dropDown.clearQueue();
                    $(this).find('.dropdown-menu').fadeIn(200);
                }, mouseleave: function () {
                    dropDown.find('.dropdown-menu').fadeOut(100);
                }
            });
        } else {
            dropDown.on('click', function () {
                $(this).find('.dropdown-menu').slideToggle();
            });
        }
    });
    $(document).ready(function () {
        $('.owl-cat-carousel').owlCarousel({
            loop: true,
            margin: 10,
            responsiveClass: true,
            responsive: {
                0: {
                    items: 2,
                    nav: true
                },
                600: {
                    items: 3,
                    nav: false
                },
                1000: {
                    items: 6,
                    nav: true,
                    dots: false,
                    loop: false,
                    margin: 25
                }
            }
        })
    });

})(window.jQuery);

