function searchPouvoir() {
    var model =
    {
        FilterPouvoir:
        {
            Classe: $("#listClasses").val(),
            Niveau: $("#Niveau").val()
        }
    };

    common.customRequest('POST', "Pouvoir", "SendFilterToList", model, function (result) {
        $(".containerPouvoir").append(result);
    });
}