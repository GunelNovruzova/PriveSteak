
/*var closebasket = document.querySelector(".closebasket");*/
$(document).on("click", ".basket", function(e) {
    e.preventDefault();
    var basketfor = document.querySelector(".forbasket");
    basketfor.style.opacity = "1";
    basketfor.style.visibility = "visible";
    basketfor.style.right = "1%"
})
$(document).on("click", ".closebasket", function(e) {
    e.preventDefault(); 
    var basketfor= document.querySelector(".forbasket");
    basketfor.style.visibility="hidden";
    basketfor.style.right="-100%";
    basketfor.style.opacity="0";
})



$(".productModal").click(function (e) {
    e.preventDefault();

    let url = $(this).attr("href");

    fetch(url).then(response => response.text())
        .then(data => {
            $(".modal-content").html(data)

            $('.product-large-slider').slick({
                slidesToShow: 1,
                slidesToScroll: 1,
                arrows: false,
                dots: false,
                fade: true,
                asNavFor: '.quick-view-thumb',
                speed: 400,
            });

            $('.pro-nav').slick({
                slidesToShow: 4,
                slidesToScroll: 1,
                asNavFor: '.quick-view-image',
                dots: false,
                arrows: false,
                focusOnSelect: true,
                speed: 400,
            });

            $("#productQuickModal").modal("show")
        })
})




//$(document).on("click", ".close", function (e) {
//    e.preventDefault();
//    var modalbody = document.querySelector("#productQuickModal");
//    modalbody.style.visibility = "hidden";
//    modalbody.style.display = "none";
//})

