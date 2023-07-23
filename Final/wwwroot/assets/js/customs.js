$(document).ready(function () {

    //addBasket
    $(document).on("click", ".addtocart", function (e) {
        e.preventDefault();
        let url = $(this).attr("href");
        fetch(url).then(response => response.text()).then(data => {
            $(".forbasket").html(data);

            fetch("/Product/Count/").then(res => {
                return res.text()
            }).then(data => {
                $(".notification").html(data)

            })

        })

    })
    //basketcount
    $(document).on("click", ".basketUpdate", function (e) {
        e.preventDefault();
        let url = $(this).attr("href");
        let count = parseInt($(this).parent().find(".countInp").text());
        let id = 0;

        if ($(this).hasClass("subCount")) {
            if (count != 1) {
                count--;
            }
            id = $(this).next().attr("data-id");


            $(this).next().text(count);
        }
        else if ($(this).hasClass("addCount")) {
            count++;
            id = $(this).prev().attr("data-id");
            $(this).prev().text(count);
        }

        url = "Basket/Update" + "?id=" + id + "&count=" + count;


        fetch(url).then(response => {
            fetch("Basket/GetBasket").then(response => response.text()).then(data => $(".forbasket").html(data))
            return response.text()

        }).then(data => $(".maincart").html(data))

    })
    //deleteproductformcard
    $(document).on("click", ".deletecard", function (e) {
        e.preventDefault();

        let url = $(this).attr("href");

        fetch(url).then(response => {
            fetch("Basket/GetBasket").then(response => response.text()).then(data => $(".forbasket").html(data))

            return response.text()
        }).then(data => $(".maincart").html(data))

    })
    //deleteproductfrombasket
    $(document).on ("click", ".deletebasket", function (e) {
        e.preventDefault();

        let url = $(this).attr("href");

        fetch(url).then(response => {
            fetch("Basket/GetCard").then(response => response.text()).then(data => $(".maincart").html(data))

            fetch("/Product/Count").then(res => {
                return res.text()
            }).then(data => {
                $(".notification").html(data)
            })
            return response.text()
        }).then(data => $(".forbasket").html(data))
    })
    //search
    $(document).on("keyup", "#searchBtn", function (e) {
        e.preventDefault()
        console.log($(this).val())
        let url = $("#searchForm").attr("action");
        fetch(url + "?key=" + $(this).val()).then(res => {
            return res.text()
        }).then(data => {
            $("#productList").html(data)
        })
    })
    //tablereserve
    $(document).ready(function () {
        $(document).on('click', '.tableimage', function (e) {

            e.preventDefault();
            var teable = document.getElementById("teable");
            teable.style.display = "block";
           
            var num = $(this).attr("data-num");
           var reserveId = $(this).attr("data-id");
            var name = $(this).attr("data-name");
            document.getElementById("teable").value = name + num;
       
            document.getElementById("reserve-id-input").value = reserveId;
            
        
        })
        // tablecategory
        $(".tablecategory").click(function (e) { 
            e.preventDefault();
            console.log(93)
            var id = $(this).attr("data-id");
            var num = $(this).attr("data-num");
            var name = $(this).attr("data-name");
            var tablecategory = document.querySelector(".tablecategory");
             fetch("../Table/ReserveFilter" + "?id=" + id).then(res => {
                return res.text()
            }).then(data => {
                $(".tab-content").html(data);
              
            })
          
        })
    })
    

})

