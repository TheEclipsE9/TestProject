$(document).ready(function () {
    console.log("js!");

    $('.link-options-open').click(function () {
        console.log("show!")
        $('.profile-options').show();
    });
    $('.link-options-close').click(function () {
        console.log("close!")
        $('.profile-options').hide();
    });
});