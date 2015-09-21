$(document).ready(function () {

    //Check to see if the window is top if not then display button
    $('#body').scroll(function () {
        if ($(this).scrollTop() > 100) {
            $('.scrollToTop').fadeIn();
        } else {
            $('.scrollToTop').fadeOut();
        }
    });

    //Click event to scroll to top
    $('.scrollToTop').click(function () {
        $('#body').animate({ scrollTop: 0 }, 800);
        return false;
    });
});