using System;
using System.Reflection;

class Ex2
{
    static void Main()
    {
        var BlackBox = new BlackBoxInt(); // об'єкт для якого будуть викликатись методи

        while (true)
        {
            string?[]? action = Console.ReadLine()?.Split('_'); // зчитування команди зі значенням, розбиваючи на підстроки

            if (action != null) // якщо зчитано не пусту строку
                if (action[0]?.ToLower() == "end") break; // якщо кінець вводу
                else if (action[0] != null && action[1] != null) // чи надано правильну кількість вхідних даних
                {
                    var method = typeof(BlackBoxInt).GetMethod // повертається метод в вигляді MethodInfo(var = MethodInfo?)
                        (
                            action[0]!, // назва метода (Add, Subtract...)
                            BindingFlags.Instance | // шукаються методи
                            BindingFlags.NonPublic | // шукаються не публічні члени класу
                            BindingFlags.Public // шукаються публічні члени класу
                        );

                    var result = method?.Invoke // виклакається метод і записується в result (var = Object?)
                        (
                            BlackBox, // об'єкт для якого викликається даний метод
                            parameters: new object[] { Convert.ToInt32(action[1]) } // передаються параметри для метода
                        );

                    Console.WriteLine(result); // вивід результата метода
                }
        }


        Console.WriteLine();
    }
}