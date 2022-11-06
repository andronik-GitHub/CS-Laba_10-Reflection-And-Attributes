using System;

class Gem
{
    string type = "None"; // тип камня
    string levelsOfClarity = "None"; // рівень рідкості

    public string Type { get => type; set => type = value; } // тип камня
    public string LevelsOfClarity { get => levelsOfClarity; set => levelsOfClarity = value; } // рівень рідкості

    /* --------------------------------------------------------------------------------------------------- */

    int strength; // сила
    int agility; // спритність
    int vitality; // живучість

    public int Strength { get => strength; set => strength = value; } // сила
    public int Agility { get => agility; set => agility = value; } // спритність
    public int Vitality { get => vitality; set => vitality = value; } // живучість

    /* --------------------------------------------------------------------------------------------------- */

    public Gem(string levelsOfClarity, string type) // конструктор
    {
        Type = type; // ініціалізація типу камня
        LevelsOfClarity = levelsOfClarity; // ініціалізація рівня рідкості


        int UpCharacteristic; // коефіцієнт збільшення характеристикd залежно від рівня рідкості
        if (LevelsOfClarity.ToLower() == "chipped")
            UpCharacteristic = 1;
        else if (LevelsOfClarity.ToLower() == "regular")
            UpCharacteristic = 2;
        else if (LevelsOfClarity.ToLower() == "perfect")
            UpCharacteristic = 5;
        else if (LevelsOfClarity.ToLower() == "flawless")
            UpCharacteristic = 10;
        else
            throw new Exception("Invalid type clarity!");


        if (Type.ToLower() == "ruby")
        {
            Strength = 7 + UpCharacteristic;
            Agility = 2 + UpCharacteristic;
            Vitality = 5 + UpCharacteristic;
        }
        else if (Type.ToLower() == "emerald")
        {
            Strength = 1 + UpCharacteristic;
            Agility = 4 + UpCharacteristic;
            Vitality = 9 + UpCharacteristic;
        }
        else if (Type.ToLower() == "amethyst")
        {
            Strength = 2 + UpCharacteristic;
            Agility = 8 + UpCharacteristic;
            Vitality = 4 + UpCharacteristic;
        }
        else
            throw new Exception("Invalid type gem!");
    }
}