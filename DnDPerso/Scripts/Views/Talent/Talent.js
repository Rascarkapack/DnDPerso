var talents = [];

$(document).ready(function () {
    $(".infobox-power").css('cursor', 'pointer');
    $(".infobox-power").on('click',
    function () {

        if ($.inArray(this.innerHTML, talents) === -1) {
            talents.push($(this).find('.infobox-power-title')[0].innerHTML);
        }

        if ($(this).attr('class').indexOf('highLight') !== -1) {
            talents.splice($.inArray($(this).find('.infobox-power-title')[0].innerHTML, talents), 1);
        }
        $(this).toggleClass('highLight');

    });

});


function validateTalent() {
    common.customRequest('POST', "Talent", "AddTalent", JSON.stringify({ talentNames: talents }), function (idPersonnage) {
        window.location = '/Home/Index?IdPersonnage=' + idPersonnage;
    });
}