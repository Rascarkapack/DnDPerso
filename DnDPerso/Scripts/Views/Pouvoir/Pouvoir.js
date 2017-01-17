function searchPouvoir() {
    var model =
    {
        
            Classe: $("#listClasses").val(),
            Niveau: $("#Niveau").val()
        
    };

    common.customRequest('POST', "Pouvoir", "SendFilterToList", JSON.stringify(model), function (result) {
        $(".containerPouvoir").append(result);
    });
}