$(document).ready(function(){
    $(".hamburger-icon").on('click', function() {
        $('.mobile-menu-wrapper').toggleClass("visible");
        $("body").toggleClass("no-scroll");
    });
});

