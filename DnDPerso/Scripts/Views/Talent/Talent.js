var talents = [];

$(document).ready(function () {
    $(".infobox").css('cursor', 'pointer');
    $(".infobox").on('click',
    function () {

        if ($.inArray(this.innerHTML, talents) === -1) {
            talents.push(this.innerHTML);
        }

        if ($(this).parent().parent().attr('class').indexOf('highLight') !== -1) {
            talents.splice($.inArray(this.innerHTML, talents), 1);
        }
        $(this).parent().parent().toggleClass('highLight');

    });

});


function validateTalent() {
    common.customRequest('POST', "Talent", "AddTalent", JSON.stringify({ talentNames: talents }), function (idPersonnage) {
        window.location = '/Home/Index?IdPersonnage=' + idPersonnage;
    });
}