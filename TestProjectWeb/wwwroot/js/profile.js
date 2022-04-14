$(document).ready(function () {
    $('.options-open').click(function () {
        console.log("show!")
        $('.profile-options').show();
    });
    $('.options-close').click(function () {
        console.log("close!")
        $('.profile-options').hide();
    });

    $('.deleteAccount-open').click(function () {
        console.log("show!")
        $('.delete-account').show();
    });
    $('.deleteAccount-close').click(function () {
        console.log("close!")
        $('.delete-account').hide();
    });

    $('.search-link').click(function (evt) {
        evt.preventDefault();
        let searchWord = $('.search-word').val();
        let url = '';
        if (searchWord === "") {
            url = '/Profile/Profile';
        }
        else {
            url = `/Profile/Profile?seacrhWord=${searchWord}`
        }
                
        window.location.replace(url);
    })
});