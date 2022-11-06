using System;

class Weapon
{
    string name = "None"; // назва зброї
    string type = "None"; // тип зброї
    string levelOfRarity = "None"; // рівень рідкості

    public string Name { get => name; set => name = value; } // назва зброї
    public string Type { get => type; set => type = value; } // тип зброї
    public string LevelOfRarity { get => levelOfRarity; set => levelOfRarity = value; } // рівень рідкості

    /* --------------------------------------------------------------------------------------------------- */

    int minDamage; // мінімальний урон
    int maxDamage; // максимальний урон
    int numberSocket; // кількість роз'ємів для камнів

    public int MinDamage { get => minDamage; set => minDamage = value; } // мінімальний урон
    public int MaxDamage { get => maxDamage;  set => maxDamage = value; } // максимальний урон
    public int NumberSocket { get => numberSocket; set => numberSocket = value; } // кількість роз'ємів для камнів

    /* --------------------------------------------------------------------------------------------------- */

    int strength; // сила
    int agility; // спритність
    int vitality; // живучість

    public int Strength { get => strength; set => strength = value; } // сила
    public int Agility { get => agility; set => agility = value; } // спритність
    public int Vitality { get => vitality; set => vitality = value; } // живучість

    /* --------------------------------------------------------------------------------------------------- */

    Gem?[] gems; // дорогоцінні камні

    /* --------------------------------------------------------------------------------------------------- */

    public Weapon(string levelOfRarity, string type, string name) // конструктор
    {
        Type = type; // ініціалізація типу зброї
        LevelOfRarity = levelOfRarity; // ініціалізація рівня рідкості
        Name = name; // ініціалізація імені зброї

        Strength = 0; // ініціалізація сили
        Agility = 0; // ініціалізація спритності
        Vitality = 0; // ініціалізація живучості



        int UpDamage; // коефіцієнт збільшення урону залежно від рівня рідкості
        if (LevelOfRarity.ToLower() == "common")
            UpDamage = 1;
        else if (LevelOfRarity.ToLower() == "uncommon")
            UpDamage = 2;
        else if (LevelOfRarity.ToLower() == "rare")
            UpDamage = 2;
        else if (LevelOfRarity.ToLower() == "epic")
            UpDamage = 5;
        else
            throw new Exception("Invalid rarity weapon!");



        if (Type.ToLower() == "axe") // ініціалізація топора
        {
            MinDamage = 5 * UpDamage;
            MaxDamage = 10 * UpDamage;
            NumberSocket = 4;
        }
        else if (Type.ToLower() == "sword") // ініціалізація меча
        {
            MinDamage = 4 * UpDamage;
            MaxDamage = 6 * UpDamage;
            NumberSocket = 3;
        }
        else if (Type.ToLower() == "knife") // ініціалізація ножа
        {
            MinDamage = 3 * UpDamage;
            MaxDamage = 4 * UpDamage;
            NumberSocket = 2;
        }
        else
            throw new Exception("Invalid type weapon!");

        gems = new Gem[NumberSocket]; // виділення пам'яті під максимальну кількість дорогоцінних каменів
    }

    // Переоприділення методу ToString під вивід у форматі "{назва зброї}: {мін. шкоди}-{макс. шкоди} шкоди, +{балів} сили, +{балів} спритності, +{балів} живучості"
    public override string ToString() => $"{Name}: {MinDamage}-{MaxDamage} Damage, +{Strength} Strength, +{Agility} Agility, +{Vitality} Vitality";

    /* =================================================================================================== */

    public void AddGem(int index, Gem gem) // додавання камня
    {
        if (!(index > gems.Length - 1 || index < 0)) // якщо індекс не за діапазоном
        {
            gems[index] = gem;

            MinDamage += gem.Strength * 2;
            MaxDamage += gem.Strength * 3;

            MinDamage += gem.Agility * 1;
            MaxDamage += gem.Agility * 4;

            Strength += gem.Strength;
            Agility += gem.Agility;
            Vitality += gem.Vitality;
        }
        else
            throw new Exception("Invalid operation!");
    }

    public void RemoveGem(int index) // видалення камня
    {
        if (gems[index] != null && !(index > gems.Length - 1 || index < 0)) // якщо індекс не за діапазоном і виділеня пам'ять (якщо виріз занятий якимось камнем)
        {
            MinDamage -= gems[index]!.Strength * 2;
            MaxDamage -= gems[index]!.Strength * 3;

            MinDamage -= gems[index]!.Agility * 1;
            MaxDamage -= gems[index]!.Agility * 4;

            Strength -= gems[index]!.Strength;
            Agility -= gems[index]!.Agility;
            Vitality -= gems[index]!.Vitality;


            gems[index] = null;
        }
        else
            throw new Exception("Invalid operation!");
    }
}