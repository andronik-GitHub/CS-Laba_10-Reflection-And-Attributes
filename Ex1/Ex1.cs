using System;
using System.Reflection;
using System.Collections;

class Ex1
{
    static void Main()
    {
        Type type = typeof(RichSoilLand); // получення інформації про RichSoilLand
        List<string> AccessCommand = new (); // для збереження команд


        while (true)
        {
            string? action = Console.ReadLine(); // зчитування команди

            if (action?.ToLower() == "harvest") { Console.WriteLine(); break; } // якщо ввід завершено
            if (action != null) AccessCommand.Add(action); // збереження команди
        }


        foreach (string s in AccessCommand) // прохід по збереженим командам
            foreach (
                FieldInfo field // для зберігання інформації про поле(змінну)
                in
                type.GetFields // повертає всі поля данного типу в виді масива об'єктів FieldInfo
                    (
                        BindingFlags.DeclaredOnly | // враховуються лише члени(методи), оголошені на рівні ієрархії наданого типу
                        BindingFlags.Instance | // методи включаються до пошуку
                        BindingFlags.NonPublic | // приватні члени включаються у пошук
                        BindingFlags.Public | // публічні члени включаються у пошук
                        BindingFlags.Static // статичні члени включаються у пошук
                    )
                )
                if (s.ToLower() == "private") // якщо потрібно вивести всі поля з мод.доступу private
                {
                    if (field.IsPrivate) // якщо поле private
                    {
                        string modificator = "private "; // для відображення модифікатора доступу
                        if (field.IsStatic) modificator += "static "; // оновлення мод.доступу якщо поле статичне


                        //              модифікатор доступу     тип данних        ім'я поля
                        Console.WriteLine($"{modificator}{field.FieldType.Name} {field.Name}");
                    }
                }
                else if (s.ToLower() == "protected") // якщо потрібно вивести всі поля з мод.доступу protected
                {
                    if (field.IsFamily) // якщо поле protected
                    {
                        string modificator = "protected "; // для відображення модифікатора доступу
                        if (field.IsStatic) modificator += "static "; // оновлення мод.доступу якщо поле статичне


                        //              модифікатор доступу     тип данних        ім'я поля
                        Console.WriteLine($"{modificator}{field.FieldType.Name} {field.Name}");
                    }
                }
                else if (s.ToLower() == "public") // якщо потрібно вивести всі поля з мод.доступу public
                {
                    if (field.IsPublic) // якщо поле public
                    {
                        string modificator = "public "; // для відображення модифікатора доступу
                        if (field.IsStatic) modificator += "static "; // оновлення мод.доступу якщо поле статичне


                        //              модифікатор доступу     тип данних        ім'я поля
                        Console.WriteLine($"{modificator}{field.FieldType.Name} {field.Name}");
                    }
                }
                else if (s.ToLower() == "all") // якщо потрібно вивести всі поля
                {
                    string modificator = ""; // для відображення модифікатора доступу

                    if (field.IsPublic)
                        modificator = "public ";
                    else if (field.IsPrivate)
                        modificator = "private ";
                    else if (field.IsFamily)
                        modificator = "protected ";

                    if (field.IsStatic) modificator += "static "; // оновлення мод.доступу якщо поле статичне


                    //              модифікатор доступу     тип данних        ім'я поля
                    Console.WriteLine($"{modificator}{field.FieldType.Name} {field.Name}");
                }
        


        Console.ReadKey();
    }
}