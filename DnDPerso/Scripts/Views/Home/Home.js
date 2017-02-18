
$(document).ready(function () {
    $("#input_characterLevel").val(SetCharacterLevel($("#input_characterExperience").val()));
    SetModifierValue();
    $("input[id^='modifDiversCompe']").change(function () {
        SetModifierValue();
    });

    $("#ModArmeDegat").on('propertychange input', function(s, e) {
        SetModifierValue();
    });

    $("#SelectedArme").change(function() {
        $("#ModArmeDegat").val($(this).val().substring($("#SelectedArme").val().indexOf("D") + 1, $(this).val().length));
        SetModifierValue();
    });

    $("#ModArmeDegat").val($("#SelectedArme").val().substring($("#SelectedArme").val().indexOf("D") +1, $("#SelectedArme").val().length));

    $("input[id^='quant']").on('blur', function (s,e) {
        var lenghtString = 'quant'.length;
        var idTarget = s.currentTarget.attributes["id"].value;
        var id = idTarget.substring(lenghtString, idTarget.lenght);
        var value = s.currentTarget.value;
        
        if (value === "0") {
            common.customRequest('POST', "Home", "DeleteEquipement", JSON.stringify({ idEquip: id }), function () {
                var idPerso = $("#input_characterId").val();
                //$("#innerEncartEquipement").load("/Home/EncartEquipementPartialView?idPersonnage=" + idPerso);
                window.location = '/Home/Index?IdPersonnage=' + idPerso;

            });
        } else {
            common.customRequest('POST', "Home", "UpdateEquipement", JSON.stringify({ idEquip: id, quantite : value }), function () {
                //var idPerso = $("#input_characterId").val();
                //$("#innerEncartEquipement").load("/Home/EncartEquipementPartialView?idPersonnage=" + idPerso);

            });
        }
       
    });

    $("input[id^='checkBox_Former']").change(function (s, e) {
        var lenghtString = 'checkBox_Former'.length;
        var idTarget = s.currentTarget.attributes["id"].value;
        var compeLib = idTarget.substring(lenghtString, idTarget.lenght);
        var hiddenId = $("#hiddenId" + compeLib).val();
        common.customRequest('POST', "Home", "UpdateCompetence", JSON.stringify({ idCompePerso: hiddenId }), function (idPersonnage) {
            //window.location = '/Home/Index?IdPersonnage=' + idPersonnage;
            SetModifierValue();
        });
    });
    $(".hanging").addClass('cache');
    $(".infobox-flavor").addClass('cache');
    
    $(".infobox-power-origin").on('click', function () {
        
        if ($(this).parent().parent().parent().find('.cache').length > 0) {
            $(this).parent().parent().parent().find('.cache').removeClass('cache');
        } else {
            $(this).parent().parent().parent().find('.hanging').addClass('cache');
            $(this).parent().parent().parent().find('.infobox-flavor').addClass('cache');
        }
        
    });
});

function SaveCharacterSheet() {
    //calcul new level from xp
    $("#input_characterLevel").val(SetCharacterLevel($("#input_characterExperience").val()));
    SetModifierValue();

    var model =
    {
        Id: $("#input_characterId").val(),
        Nom : $("#input_characterName").val(),
        Niveau : $("#input_characterLevel").val(),
        IdClasse : $("#IdClasse").val(),
        Experience : $("#input_characterExperience").val(), 
        IdRace : $("#IdRace").val(),  
        CategorieTaille : $("#input_characterHeightCategorie").val(), 
        Age : $("#input_characterAge").val(), 
        Sexe : $("#input_characterSexe").val(), 
        Taille : $("#input_characterHeight").val(), 
        Poids : $("#input_characterWeight").val(), 
        IdAlignement : $("#IdAlignement").val(), 
        IdDivinite : $("#IdDivinite").val(), 
        IdGroupeAventurier : $("#input_characterGroup").val(), 
        PointAction : $("#input_characterPAValue").val(), 
        PVMax : $("#input_PVMax").val(),  
        Personnalite : $("#input_characterPersonnalite").val(),
        InitiativeDivers : $("#input_INITDivers").val(),
        CaracteristiqueForce : $("#input_ForceValue").val(),
		CaracteristiqueConstitution : $("#input_ConsValue").val(),
		CaracteristiqueDexterite : $("#input_DexValue").val(),
		CaracteristiqueIntelligence : $("#input_IntValue").val(),
		CaracteristiqueSagesse : $("#input_SagValue").val(),
		CaracteristiqueCharisme : $("#input_ChaValue").val(),
		DefenseCADemiNiveau : $("#input_CADemiNiveau").val(),
		DefenseCACaracteristique : $("#input_CACarac").val(),
		DefenseCAClasse : $("#input_CAClasse").val(),
		DefenseCATalent : $("#input_CATalent").val(),
		DefenseCADivers : $("#input_CADivers").val(),
		DefenseVIGDemiNiveau: $("#input_VIGDemiNiveau").val(),
		DefenseVIGCaracteristique: $("#input_VIGCarac").val(),
		DefenseVIGClasse: $("#input_VIGClasse").val(),
		DefenseVIGTalent: $("#input_VIGTalent").val(),
		DefenseVIGDivers: $("#input_VIGDivers").val(),
		DefenseREFDemiNiveau: $("#input_REFDemiNiveau").val(),
		DefenseREFCaracteristique: $("#input_REFCarac").val(),
		DefenseREFClasse: $("#input_REFClasse").val(),
		DefenseREFTalent: $("#input_REFTalent").val(),
		DefenseREFDivers: $("#input_REFDivers").val(),
		DefenseVOLDemiNiveau: $("#input_VOLDemiNiveau").val(),
		DefenseVOLCaracteristique: $("#input_VOLCarac").val(),
		DefenseVOLClasse: $("#input_VOLClasse").val(),
		DefenseVOLTalent: $("#input_VOLTalent").val(),
		DefenseVOLDivers: $("#input_VOLDivers").val(),
		ModCaracAttaque: $("#ModCaracAttaque").val(),
		ModManiAttaque: $("#ModManiAttaque").val(),
		ModTalentAttaque: $("#ModTalentAttaque").val(),
		ModClasseAttaque: $("#ModClasseAttaque").val(),
		ModCaracDegat: $("#ModCaracDegat").val(),
		ModTalentDegat: $("#ModTalentDegat").val()
    };

    common.customRequest('POST', "Home", "SaveCharacterData", JSON.stringify(model), function(result) {
        if (result === "OK") {
 
            toastr.info("enregistrement effectué");
        } else {
            toastr.error("erreur ors de l'enregistrement");
        }
    });
}

function SetModifierValue() {
    var level = $("#input_characterLevel").val();
    var bonusLevel = (level - (level % 2)) / 2;

    //TotalAttaque
    $('#TotalAttaque').val(parseInt(bonusLevel) + parseInt($('#ModCaracAttaque').val()) + parseInt($('#ModClasseAttaque').val()) + parseInt($('#ModManiAttaque').val()) + parseInt($('#ModTalentAttaque').val()));

    //TotalDegat
    $('#TotalDegat').val(parseInt($('#ModArmeDegat').val()) + parseInt($('#ModCaracDegat').val()) + parseInt($('#ModTalentDegat').val()));

    //caracteristiques
    $("#input_ForceMod").val(CalculCaracMod($("#input_ForceValue").val()) + bonusLevel);
    $("#input_ConsMod").val(CalculCaracMod($("#input_ConsValue").val()) + bonusLevel);
    $("#input_DexMod").val(CalculCaracMod($("#input_DexValue").val()) + bonusLevel);
    $("#input_IntMod").val(CalculCaracMod($("#input_IntValue").val()) + bonusLevel);
    $("#input_SagMod").val(CalculCaracMod($("#input_SagValue").val()) + bonusLevel);
    $("#input_ChaMod").val(CalculCaracMod($("#input_ChaValue").val()) + bonusLevel);

    var compeId = $("input[id^='totalValueCompe']");

    $.each(compeId, function (key, value) {

        var checked = 0;
        var modCarac;

        var lenghtString = 'totalValueCompe'.length;
        var idTarget = value.attributes["id"].value;
        var compeLib = idTarget.substring(lenghtString, idTarget.lenght);
        switch (compeLib) {
            case "Acrobaties":
                modCarac = CalculCaracMod($("#input_DexValue").val()) + bonusLevel;
                break;
            case "Arcanes":
                modCarac = CalculCaracMod($("#input_IntValue").val()) + bonusLevel;
                break;
            case "Athl_tisme":
                modCarac = CalculCaracMod($("#input_ForceValue").val()) + bonusLevel;
                break;
            case "Bluff":
                modCarac = CalculCaracMod($("#input_ChaValue").val()) + bonusLevel;
                break;
            case "Connaissance_de_la_rue":
                modCarac = CalculCaracMod($("#input_ChaValue").val()) + bonusLevel;
                break;
            case "Diplomatie":
                modCarac = CalculCaracMod($("#input_ChaValue").val()) + bonusLevel;
                break;
            case "Discr_tion":
                modCarac = CalculCaracMod($("#input_DexValue").val()) + bonusLevel;
                break;
            case "Endurance":
                modCarac = CalculCaracMod($("#input_ConsValue").val()) + bonusLevel;
                break;
            case "Exploration":
                modCarac = CalculCaracMod($("#input_SagValue").val()) + bonusLevel;
                break;
            case "Histoire":
                modCarac = CalculCaracMod($("#input_IntValue").val()) + bonusLevel;
                break;
            case "Intimidation":
                modCarac = CalculCaracMod($("#input_ChaValue").val()) + bonusLevel;
                break;
            case "Intuition":
                modCarac = CalculCaracMod($("#input_SagValue").val()) + bonusLevel;
                break;
            case "Larcin":
                modCarac = CalculCaracMod($("#input_DexValue").val()) + bonusLevel;
                break;
            case "Nature":
                modCarac = CalculCaracMod($("#input_SagValue").val()) + bonusLevel;
                break;
            case "Perception":
                modCarac = CalculCaracMod($("#input_SagValue").val()) + bonusLevel;
                break;
            case "Religion":
                modCarac = CalculCaracMod($("#input_IntValue").val()) + bonusLevel;
                break;
            case "Soins":
                modCarac = CalculCaracMod($("#input_SagValue").val()) + bonusLevel;
                break;

        }
        if ($("#checkBox_Former" + compeLib).prop('checked')) {
            checked = 5;
        }

        var modDiv = 0;
        if ($("#modifDiversCompe" + compeLib).val() !== undefined && $("#modifDiversCompe" + compeLib).val() !== "") {
            modDiv=parseInt($("#modifDiversCompe" + compeLib).val());
        }
        

       

        $("#totalValueCompe" + compeLib).val(bonusLevel + checked + modCarac + modDiv);

    });

    //defenses
    $("#input_CADemiNiveau").val(10+  parseInt(bonusLevel));
    $("#input_VIGDemiNiveau").val(10+ parseInt(bonusLevel));
    $("#input_REFDemiNiveau").val(10+ parseInt(bonusLevel));
    $("#input_VOLDemiNiveau").val(10+ parseInt(bonusLevel));

    $("#input_CATotal").val(parseInt($("#input_CADemiNiveau").val()) + parseInt($("#input_CACarac").val()) + parseInt($("#input_CAClasse").val()) + parseInt($("#input_CATalent").val()) + parseInt($("#input_CADivers").val()));
    $("#input_VIGTotal").val(parseInt($("#input_VIGDemiNiveau").val()) + parseInt($("#input_VIGCarac").val()) + parseInt($("#input_VIGClasse").val()) + parseInt($("#input_VIGTalent").val()) + parseInt($("#input_VIGDivers").val()));
    $("#input_REFTotal").val(parseInt($("#input_REFDemiNiveau").val()) + parseInt($("#input_REFCarac").val()) + parseInt($("#input_REFClasse").val()) + parseInt($("#input_REFTalent").val()) + parseInt($("#input_REFDivers").val()));
    $("#input_VOLTotal").val(parseInt($("#input_VOLDemiNiveau").val()) + parseInt($("#input_VOLCarac").val()) + parseInt($("#input_VOLClasse").val()) + parseInt($("#input_VOLTalent").val()) + parseInt($("#input_VOLDivers").val()));

    //initiative
    var INITDivers;
    if (typeof $("#input_INITDivers").val() == "undefined" || $("#input_INITDivers").val() == "") {
        INITDivers = 0;
        $("#input_INITDivers").val(INITDivers);
    }
    else
        INITDivers = $("#input_INITDivers").val();

    $("#input_INITTotal").val(CalculCaracMod($("#input_DexValue").val()) + bonusLevel + parseInt(INITDivers));
}

function AfficheHtml(html) {
   
}

function OpenPopUpPouvoir(classe, level) {
    window.location = '/Pouvoir/Index?classe=' + classe + '&level=' + level;
}

function deletePouvoir(idPouvoirPersonnage) {
    common.customRequest('POST', "Pouvoir", "DeletePouvoir", JSON.stringify({ idPouvoirPersonnage: idPouvoirPersonnage }), function (idPersonnage) {
        window.location = '/Home/Index?IdPersonnage=' + idPersonnage;
    });
}

function setCombat() {
    $("#tabCombat").addClass("active");
    $("#tabAutres").removeClass("active");
    $("#tabNote").removeClass("active");
    $("#bloc_combat").removeClass("cache");
    $("#bloc_autres").addClass("cache");
    $("#bloc_note").addClass("cache");
}
function setAutres() {
    $("#tabAutres").addClass("active");
    $("#tabCombat").removeClass("active");
    $("#tabNote").removeClass("active");
    $("#bloc_combat").addClass("cache");
    $("#bloc_autres").removeClass("cache");
    $("#bloc_note").addClass("cache");
}
function setNote() {
    $("#tabNote").addClass("active");
    $("#tabAutres").removeClass("active");
    $("#tabCombat").removeClass("active");
    $("#bloc_combat").addClass("cache");
    $("#bloc_autres").addClass("cache");
    $("#bloc_note").removeClass("cache");
}

function AddEquipement() {
    var model;
    model = {
        typeEquipement: $("#input_TypeEquipement").val(),
        categorieEquipement: $("#input_CategorieEquipement").val(),
        quantite: $("#input_QuantiteEquipement").val(),
        rareteEquipement: $("#input_RareteEquipement").val()
    };

    common.customRequest("POST", "Home", "AddEquipement", JSON.stringify(model), function(result) {
        if (result === "undifined" || result === "KO") {
            toastr.error("Erreur");
           
        } else {
            toastr.info("Equipement ajouté");
            var idPerso = $("#input_characterId").val();
            $("#innerEncartEquipement").load("/Home/EncartEquipementPartialView?idPersonnage=" + idPerso);

            $("#SelectedArme").append('<option value="' + result.type + '">'+result.type+ '</>');
        }
    });
}