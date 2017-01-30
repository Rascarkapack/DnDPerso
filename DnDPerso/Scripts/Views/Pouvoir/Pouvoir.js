$(document).ready(function () {
    setTimeout(function() {
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
           common.customRequest('POST', "Pouvoir", "AddPouvoir", JSON.stringify({ pouvoirName: this.innerHTML }), function (idPersonnage) {
               window.location = '/Home/Index?IdPersonnage=' + idPersonnage;
           });
           
       });
    });
}

function htmlDecode(value){
    return $('<div/>').html(value.replace(/\?/g, "✦")).text();
}