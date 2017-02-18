var talents = [];

$(document).ready(function () {
    $(".infobox-power-title").css('cursor', 'pointer');
    $(".infobox-power-title").on('click',
    function () {

        if ($.inArray(this.innerHTML, talents) === -1) {
            talents.push(this.innerHTML);
        }

        if ($(this).attr('class').indexOf('highLight') !== -1) {
            talents.splice($.inArray(this.innerHTML, talents), 1);
        }
        $(this).toggleClass('highLight');

    });

});


function validateTalent() {
    common.customRequest('POST', "Talent", "AddTalent", JSON.stringify({ talentNames: talents }), function (idPersonnage) {
        window.location = '/Home/Index?IdPersonnage=' + idPersonnage;
    });
}