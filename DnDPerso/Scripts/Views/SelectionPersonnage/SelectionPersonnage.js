function LoadPersonnage(idPersonnage) {
    window.location = '/Home/Index?IdPersonnage=' + idPersonnage;
}

function LoadPersonnage(idPersonnage) {
    common.customRequest("POST", "SelectionPersonnage", "DeletePersonnage", JSON.stringify({ IdPersonnage: idPersonnage }), null);
}