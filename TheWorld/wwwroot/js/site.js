// site.js

(function () {

//    var ele = $("#username");
//    ele.text("Shawn Wildermuth");
//
//    var main = $("#main");
//    main.on("mouseenter", function() {
//        main.style = "background: #888";
//    });
//
//    main.on("mouseleave", function() {
//        main.style = "";
//    });
//
//    var manuItems = $("ul.menu li a");
//    manuItems.on("click", function () {
//        var me = $(this);
//        alert(me.text());"
//      });

    var $sidebarAndWrapper = $("#sidebar, #wrapper");

    $("#sidebarToggle").on("click",
        function() {
            $sidebarAndWrapper.toggleClass("hide-sidebar");
            if ($sidebarAndWrapper.hasClass("hide-sidebar")) {
                $(this).text("Show Sidebar");
            } else {
                $(this).text("Hide Sidebar");
            }
        });


})();