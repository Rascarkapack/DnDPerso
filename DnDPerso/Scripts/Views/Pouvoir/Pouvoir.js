function searchPouvoir() {
    var model =
    {
        
            Classe: $("#listClasses").val(),
            Niveau: $("#Niveau").val()
        
    };

    common.customRequest('POST', "Pouvoir", "SendFilterToList", JSON.stringify(model), function (result) {
        $("#containerPouvoir").empty();
        $("#containerPouvoir").append(htmlDecode(result));
    });
}

function htmlDecode(value){
    return $('<div/>').html(value.replace(/\?/g, "✦")).text();
}