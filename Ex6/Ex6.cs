using System;
using System.Reflection;

class Ex6
{
    static void Main()
    {
        string[]? arr = Console.ReadLine()?.Split(' '); // кількість сигналів
        int N = Convert.ToInt32(Console.ReadLine()); // кількість разів, які потрібно змінити на кожному сигналі світлофора

        TrafficLight[] TrafficLights = new TrafficLight[N]; // масив світлофорів
        Type type = typeof(TrafficLight); // получення інформації про TrafficLight


        if (arr != null) // якщо зчитано хочаб один сигнал
            for (int i = 0; i < N; i++) // по світлофорам
            {
                for (int j = 0; j < arr.Length; j++) // по зчитаним сигналам
                {
                    TrafficLights[i] = new(); // виділяється пам'ять (сигнал Red з конструктора)


                    // получення приватного поля signal
                    var signal = type.GetField("signal", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                    signal?.SetValue(TrafficLights[i], arr[j]); // обновлення сигналу (сигнал Red з конструктора)

                    var value = signal?.GetValue(TrafficLights[i]); // получення значення поля signal


                    if (value != null) // якщо значення поля signal не відсутнє
                    {
                        // так як value змінна типу Object то преобразується до string
                        if ((string)value == "red" || (string)value == "Red") // червоний -> зелений
                            signal?.SetValue(TrafficLights[i], "Green");
                        else if ((string)value == "green" || (string)value == "Green") // зелений -> жовтий
                            signal?.SetValue(TrafficLights[i], "Yellow");
                        else if ((string)value == "yellow" || (string)value == "Yellow") // жовтий -> червоний
                            signal?.SetValue(TrafficLights[i], "Red");
                    }

                    
                    value = signal?.GetValue(TrafficLights[i]); // перезаписується значення поля signal
                    arr[j] = (string?)value ?? arr[j]; // перезаписується сигнал який був зчитаний

                    Console.Write(value + " "); // виведення сигналу
                }
                Console.WriteLine();
            }


        Console.WriteLine();
    }
}