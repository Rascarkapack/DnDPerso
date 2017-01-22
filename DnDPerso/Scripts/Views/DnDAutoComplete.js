function CalculCaracMod(CaracValue) {
    if(CaracValue == 1)
        return -1;
    else if(CaracValue == 2 || CaracValue == 3)
        return -4;
    else if (CaracValue == 4 || CaracValue == 5)
        return -3;
    else if (CaracValue == 6 || CaracValue == 7)
        return -2;
    else if (CaracValue == 8 || CaracValue == 9)
        return -1;
    else if (CaracValue == 10 || CaracValue == 11)
        return -0;
    else if (CaracValue == 12 || CaracValue == 13)
        return 1;
    else if (CaracValue == 14 || CaracValue == 15)
        return 2;
    else if (CaracValue == 16 || CaracValue == 17)
        return 3;
    else if (CaracValue == 18 || CaracValue == 19)
        return 4;
    else if (CaracValue == 20 || CaracValue == 21)
        return 5;
    else if (CaracValue == 22 || CaracValue == 23)
        return 6;
    else if (CaracValue == 24 || CaracValue == 25)
        return 7;
    else if (CaracValue == 26 || CaracValue == 27)
        return 8;
    else if (CaracValue == 28 || CaracValue == 29)
        return 9;
    else if (CaracValue == 30 || CaracValue == 31)
        return 10;
}

function SetCharacterLevel() {
    var xp = $("input_characterExperience").val();

    if (xp < 1000)
        return 1;
    else if (xp < 2250)
        return 2;
    else if (xp < 3750)
        return 3;
    else if (xp < 5500)
        return 4;
    else if (xp < 7500)
        return 5;
    else if (xp < 10000)
        return 6;
    else if (xp < 13000)
        return 7;
    else if (xp < 16500)
        return 8;
    else if (xp < 20500)
        return 9;
    else if (xp < 26000)
        return 10;
    else if (xp < 32000)
        return 11;
    else if (xp < 39000)
        return 12;
    else if (xp < 47000)
        return 13;
    else if (xp < 57000)
        return 14;
    else if (xp < 69000)
        return 15;
    else if (xp < 83000)
        return 16;
}