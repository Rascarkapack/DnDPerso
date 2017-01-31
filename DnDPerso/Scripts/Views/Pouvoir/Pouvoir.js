var pouvoirs = [];

$(document).ready(function () {
    setTimeout(function () {
        $("#searchPouvoirBtn").trigger('click');
    },
        10);

});
function searchPouvoir(classe, level) {
    var model =
    {
        Classe: classe,
        Niveau: level
    };

    common.customRequest('POST', "Pouvoir", "SendFilterToList", JSON.stringify(model), function (result) {
        $("#containerPouvoir").empty();
        $("#containerPouvoir").append(htmlDecode(result));

        $(".infobox-power-title").css('cursor', 'pointer');
        $(".infobox-power-title").on('click',
       function () {

           if ($.inArray(this.innerHTML, pouvoirs) === -1) {
               pouvoirs.push(this.innerHTML);
           }

           if ($(this).parent().parent().attr('class').indexOf('highLight') !== -1) {
               pouvoirs.splice($.inArray(this.innerHTML, pouvoirs), 1);
           }
           $(this).parent().parent().toggleClass('highLight');

       });
    });
}

function htmlDecode(value) {
    return $('<div/>').html(value.replace(/\?/g, "✦")).text();
}

function validatePouvoir() {
    common.customRequest('POST', "Pouvoir", "AddPouvoir", JSON.stringify({ pouvoirNames: pouvoirs }), function (idPersonnage) {
        window.location = '/Home/Index?IdPersonnage=' + idPersonnage;
    });
}

