
$(document).ready(function () {
    $("#input_characterLevel").val(SetCharacterLevel($("#input_characterExperience").val()));
    SetModifierValue();
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
		DefenseVOLDivers: $("#input_VOLDivers").val()
    };

    common.customRequest('POST', "Home", "SaveCharacterData", JSON.stringify(model), null);
}

function SetModifierValue() {
    var level = $("#input_characterLevel").val();
    var bonusLevel = (level - (level % 2)) / 2;

    //caracteristiques
    $("#input_ForceMod").val(CalculCaracMod($("#input_ForceValue").val()) + bonusLevel);
    $("#input_ConsMod").val(CalculCaracMod($("#input_ConsValue").val()) + bonusLevel);
    $("#input_DexMod").val(CalculCaracMod($("#input_DexValue").val()) + bonusLevel);
    $("#input_IntMod").val(CalculCaracMod($("#input_IntValue").val()) + bonusLevel);
    $("#input_SagMod").val(CalculCaracMod($("#input_SagValue").val()) + bonusLevel);
    $("#input_ChaMod").val(CalculCaracMod($("#input_ChaValue").val()) + bonusLevel);

    //defenses
    $("#input_CADemiNiveau").val(bonusLevel);
    $("#input_VIGDemiNiveau").val( bonusLevel);
    $("#input_REFDemiNiveau").val( bonusLevel);
    $("#input_VOLDemiNiveau").val( bonusLevel);

    $("#input_CADemiTotal").val($("#input_CADemiNiveau").val() + $("#input_CACarac").val() + $("#input_CAClasse").val() + $("#input_CATalent").val() + $("#input_CADivers").val());
    $("#input_VIGDemiTotal").val($("#input_VIGDemiNiveau").val() + $("#input_VIGCarac").val() + $("#input_VIGClasse").val() + $("#input_VIGTalent").val() + $("#input_VIGDivers").val());
    $("#input_REFDemiTotal").val($("#input_REFDemiNiveau").val() + $("#input_REFCarac").val() + $("#input_REFClasse").val() + $("#input_REFTalent").val() + $("#input_REFDivers").val());
    $("#input_VOLDemiTotal").val($("#input_VOLDemiNiveau").val() + $("#input_VOLCarac").val() + $("#input_VOLClasse").val() + $("#input_VOLTalent").val() + $("#input_VOLDivers").val());

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