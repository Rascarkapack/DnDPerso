
$(document).ready(function () {
    $('#contentAuthBloc').keypress(function (e) {
        if (e.which === 13) {
            e.preventDefault();
            loginAuth();
        }
    });
});

function loginAuth() {
    var form = $('#loginAuthBloc');
    var loader = $('#fileGenerationSpinner');
    var authMessage = $('#authErrorMessage');
    var token = $('input[name="__RequestVerificationToken"]', form).val();

    loader.removeClass('HidePanel');
    $("html").css("cursor", "wait");

    common.customRequestSecured("POST", "Login", "Login", ({ Login: $("#authFormLogin").val(), Password: $("#authFormPassword").val() }), token, function (result) {
        $("html").css("cursor", "default");
        loader.addClass('HidePanel');

        if (result === "OK") {
            toastr.info("Connection réussie")
            authMessage.addClass('HidePanel');
            window.location.href = "/SelectionPersonnage/Index";
        } else {
            toastr.error("Erreur lors de l'authentification");
        }
    });
}