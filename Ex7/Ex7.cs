using System;
using System.Collections.Generic;
using System.Reflection;

class Ex7
{
    static void Main()
    {
        List<Weapon> weapons = new(); // колекція яка зберігає всю зброю

        try
        {
            while (true) // ввід даних до команди "END"
            {
                string[]? action = Console.ReadLine()?.Split(';'); // розбивається зчитувана строка і записується

                if (action != null)
                {
                    if (action[0]?.ToLower().Trim() == "end") break; // якщо команда "END" то ввід завершено

                    if (action[0]?.ToLower() == "create") // якщо команда "Сreate"(створення зброї)
                    {
                        string[] temp = action[1].Split(' '); // action[1] складається з типу і рівня рідкості розділеними пробілом


                        // Додавання зброї в колекцію
                        var method = typeof(List<Weapon>).GetMethod // получення метода через рефлексію
                                                (
                                                    "Add", // назва метода
                                                    BindingFlags.Instance | // шукаються методи
                                                    BindingFlags.NonPublic | // шукаються не публічні члени класу
                                                    BindingFlags.Public // шукаються публічні члени класу
                                                );

                        method?.Invoke // виклик метода
                        (
                            weapons, // об'єкт для якого викликається даний метод
                            parameters: new object[] // параметри для метода
                            {
                                new Weapon // створюється нова зброя через конструктор
                                (
                                    temp[0], // рівень рідкості зброї
                                    temp[1], // тип зброї
                                    action[2] // назва зброї
                                )
                            }
                        );
                    }
                    else if (action[0]?.ToLower() == "add") // якщо команда "Аdd"(додавання камня до зброї)
                    {
                        if (SearchStringToCollection(action[1], weapons) < 0) // шукає строку в колекції
                                                                              // в данній ситуації пошук зброї за її назвою
                                                                              // якщо  < 0 то зброї не знайдено
                        {
                            Console.WriteLine("Weapon not found!");
                            break;
                        }

                        int index = SearchStringToCollection(action[1], weapons); // індекс зброї в колекції

                        string[] temp = action[3].Split(' '); // action[3] складається з рівня рідкості і типу камня розділеними пробілом


                        var method = typeof(Weapon).GetMethod // получення метода через рефлексію
                                                (
                                                    "AddGem", // назва метода
                                                    BindingFlags.Instance | // шукаються методи
                                                    BindingFlags.NonPublic | // шукаються не публічні члени класу
                                                    BindingFlags.Public // шукаються публічні члени класу
                                                );

                        method?.Invoke // виклик метода
                        (
                            weapons[index], // об'єкт для якого викликається даний метод
                            parameters: new object[] // параметри для метода
                            {
                                Convert.ToInt32(action[2]), // індекс гнізда
                                new Gem(temp[0], temp[1]) // дорогоцінний камень
                            }
                        );
                    }
                    else if (action[0]?.ToLower() == "remove") // якщо команда "Аdd"(видалення камня до зброї)
                    {
                        if (SearchStringToCollection(action[1], weapons) < 0) // шукає строку в колекції
                                                                              // в данній ситуації пошук зброї за її назвою
                                                                              // якщо  < 0 то зброї не знайдено

                        {
                            Console.WriteLine("Weapon not found!");
                            break;
                        }

                        int index = SearchStringToCollection(action[1], weapons); // індекс зброї в колекції

                        var method = typeof(Weapon).GetMethod // получення метода через рефлексію
                                                (
                                                    "RemoveGem", // назва метода
                                                    BindingFlags.Instance | // шукаються методи
                                                    BindingFlags.NonPublic | // шукаються не публічні члени класу
                                                    BindingFlags.Public // шукаються публічні члени класу
                                                );

                        method?.Invoke // виклик метода
                        (
                            weapons[index], // об'єкт для якого викликається даний метод
                            parameters: new object[] { Convert.ToInt32(action[2]) } // параметри для метода
                        );
                    }
                    else if (action[0]?.ToLower() == "print") // якщо команда "Аdd"(друк зброї за іменем)
                    {
                        if (SearchStringToCollection(action[1], weapons) < 0) // шукає строку в колекції
                                                                              // в данній ситуації пошук зброї за її назвою
                                                                              // якщо  < 0 то зброї не знайдено

                        {
                            Console.WriteLine("Weapon not found!");
                            break;
                        }


                        int index = SearchStringToCollection(action[1], weapons); // індекс зброї в колекції

                        Console.WriteLine(weapons[index]);
                    }
                }
            }
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }


        Console.ReadKey();
    }

    static int SearchStringToCollection // пошук строки в колекції
        (
            string str, // шукана строка
            List<Weapon> collection // колекція в якій реалізовувати пошук
        )
    {
        for (int i = 0; i < collection.Count; i++)
            if (collection[i].Name == str) return i; // якщо знайдено співпадіння то повертається індекс

        return -1; // повертаючий індекс = -1 якщо співпадіннь немає
    }
}