$(function() {
    var myColor;
    var $content = $("#content");
    var $navbar = $("#Navbar");

    if ($content.hasClass("light"))
        myColor = "light";
    else
        myColor = "dark";

    $("#YesButton").click(function(event) {
        if (myColor == "dark") {
            event.preventDefault();
            alert("LOL. There is no way out! PS. Your HR department has been contacted");
        }
    });

    $("#NoButton").click(function() {
        $(".footer").addClass("hidden");
    });

});