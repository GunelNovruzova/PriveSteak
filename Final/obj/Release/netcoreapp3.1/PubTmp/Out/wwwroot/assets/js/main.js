$(document).ready(function () {
    $('.images2').slick({
        slidesToShow: 5,
        slidesToScroll: 1,
        arrows: false,
        autoplay: true,
        autoplaySpeed: 1000,
        responsive: [
            {
                breakpoint: 576,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 1,
                    infinite: true,
                    dots: false,
                }
            }
        ]
    });
    $('.videosslide').slick({
        slidesToShow: 4,
        slidesToScroll: 1,
        arrows: false,
        autoplay: true,
        autoplaySpeed: 1000,
        responsive: [
            {
                breakpoint: 576,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    infinite: true,
                    dots: false,
                }
            }
        ]
    });
    $('.imageslide').slick({
        slidesToShow: 4,
        slidesToScroll: 1,
        arrows: false,
        autoplay: true,
        autoplaySpeed: 1000,
        responsive: [
            {
                breakpoint: 576,
                settings: {
                    slidesToShow: 3,
                    slidesToScroll: 1,
                    infinite: true,
                    dots: false,
                }
            }
        ]

    });
    $('.aboutimage').slick({
        slidesToShow: 3,
        slidesToScroll: 1,
        infinite: true,
        autoplay: true,
        autoplaySpeed: 2000,
        responsive: [
            {
                breakpoint: 576,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    infinite: true,
                    dots: false,
                }
            }
        ]
    })
    $(".slick-slider .slick-next").html(`<i class="fa-solid fa-arrow-right"></i>`)
    $(".slick-slider .slick-prev").html(`<i class="fa-solid fa-arrow-left"></i>`)
    $('input[name="paymentmethod"]').on('click', function () {
        var $value = $(this).attr('value');
        $('.payment-method-details').slideUp();
        $('[data-method="' + $value + '"]').slideDown();
    });
    $("#create_pwd").on("change", function () {
        $(".account-create").slideToggle("100");
    });
    $("#ship_to_different").on("change", function () {
        $(".ship-to-different").slideToggle("100");
    });


});

//var shopcategories = $('.allrigght');
//let offsetTop = shopcategories.offset().top;
//let offsetLeft = shopcategories.offset().left;
//let footer = document.getElementsByTagName('footer')[0];
//function isInViewport(node) {
//    var rect = node.getBoundingClientRect();
//    return (
//        (rect.height > 0 || rect.width > 0) &&
//        rect.bottom >= 0 &&
//        rect.right >= 0 &&
//        rect.top <= (window.innerHeight || document.documentElement.clientHeight) &&
//        rect.left <= (window.innerWidth || document.documentElement.clientWidth)
//    )
//}
//if (!window.matchMedia('(max-width: 1040px)').matches) {
    
//    $(window).scroll(function () {
//        ScrollToTop();

//        var scroll = $(window).scrollTop();
//        if (isInViewport(footer)) {
//            console.log(1)
//            $('.allrigght').css({
//                'height': '100%',
//                'display': 'flex',
//                'flex-direction': 'column',
//                'justify-content': 'flex-end',
//                'position': 'static',
//                'width': 'auto'
//            });
//            return;
//        }
//        if (scroll >= offsetTop) {
//            shopcategories.css({
//                'position': 'fixed',
//                'top': `115px`,
//                'left': `${offsetLeft}px`,
//                'z-index': '99999',
//                'width': '30%',
//                'height': 'auto',
//                'display': 'block'
//            });
//        }

//        else {
//            shopcategories.css({
//                'position': 'static',
//                'width': 'auto'
//            });
//        }
//    });
//}
//$(window).scroll(function () {
//    ScrollToTop();
//    var header = $('.header'),
//        scroll = $(window).scrollTop();

//    if (scroll >= 150) {
//        header.css({
//            'position': 'fixed',
//            'top': '0',
//            'left': '0',
//            'right': '0',
//            'z-index': '99999'
//        });
//    } else {
//        header.css({
//            'position': 'absolute'

//        });
//    }
//});
//ScrollToTop();

$(document).on("click", ".fa-minus", function (e) {
    e.preventDefault();
    var basketfor = document.querySelector(".allprod");
    basketfor.style.visibility = "visible";
    basketfor.style.right = "1%";
    basketfor.style.opacity = "1";
})

document.querySelector(".arrowup").addEventListener("click", function () {
    window.scrollTo({
        top: 0,
        behavior: 'smooth'
    });

})
function ScrollToTop() {
    let topbutton = document.querySelector(".buttontop");
    if (window.scrollY > 250) {
        topbutton.style.opacity = "1"
        topbutton.style.visibility = "visible"
    }
    else {
        topbutton.style.opacity = "0"
        topbutton.style.visibility = "hidden"
    }
}
ScrollToTop();




//






