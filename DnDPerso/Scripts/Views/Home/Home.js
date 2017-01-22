﻿function SaveCharacterSheet() {
    var model =
    {
        Nom : $("#input_characterName").val(),
        Niveau : $("input_characterLevel").val(),
        IdClasse : $("listClasses").val(),
        Experience : $("input_characterExperience").val(), 
        IdRace : $("listRaces").val(),  
        CategorieTaille : $("input_characterHeightCategorie").val(), 
        Age : $("input_characterAge").val(), 
        Sexe : $("input_characterSexe").val(), 
        Taille : $("input_characterHeight").val(), 
        Poids : $("input_characterWeight").val(), 
        IdAlignement : $("listAlignements").val(), 
        IdDivinite : $("listDivinites").val(), 
        IdGroupeAventurier : $("input_characterGroup").val(), 
        PointAction : $("input_characterPAValue").val(), 
        PVMax : $("input_PVMax").val(),  
        Personnalite : $("input_characterPersonnalite").val(),
        InitiativeDivers : $("input_characterINITDivers").val(),
        CaracteristiqueForce : $("input_ForceValue").val(),
		CaracteristiqueConstitution : $("input_ConsValue").val(),
		CaracteristiqueDexterite : $("input_DexValue").val(),
		CaracteristiqueIntelligence : $("input_IntValue").val(),
		CaracteristiqueSagesse : $("input_SagValue").val(),
		CaracteristiqueCharisme : $("input_ChaValue").val(),
		DefenseCADemiNiveau : $("input_CADemiNiveau").val(),
		DefenseCACaracteristique : $("input_CACarac").val(),
		DefenseCAClasse : $("input_CAClasse").val(),
		DefenseCATalent : $("input_CATalent").val(),
		DefenseCADivers : $("input_CADivers").val(),
		DefenseVIGDemiNiveau: $("input_VIGDemiNiveau").val(),
		DefenseVIGCaracteristique: $("input_VIGCarac").val(),
		DefenseVIGClasse: $("input_VIGClasse").val(),
		DefenseVIGTalent: $("input_VIGTalent").val(),
		DefenseVIGDivers: $("input_VIGDivers").val(),
		DefenseREFDemiNiveau: $("input_REFDemiNiveau").val(),
		DefenseREFCaracteristique: $("input_REFCarac").val(),
		DefenseREFClasse: $("input_REFClasse").val(),
		DefenseREFTalent: $("input_REFTalent").val(),
		DefenseREFDivers: $("input_REFDivers").val(),
		DefenseVOLDemiNiveau: $("input_VOLDemiNiveau").val(),
		DefenseVOLCaracteristique: $("input_VOLCarac").val(),
		DefenseVOLClasse: $("input_VOLClasse").val(),
		DefenseVOLTalent: $("input_VOLTalent").val(),
		DefenseVOLDivers: $("input_VOLDivers").val()
    };

    common.customRequest('POST', "Home", "SaveCharacterData", JSON.stringify(model), function (result) {
        //todo function maj level...
    });
}