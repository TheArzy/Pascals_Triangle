using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _1_4_2_Pascals_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {

            byte stringNumber; // Кол-во строк 
            byte exit = 0; // Нужно для повтора программы

            while (true)
            {

               Write("Введите требуемое кол-во строк треугольника Паскаля: ");

                while (true) // Ввод числа и его проверка
                {
                    // Проверка введенного значения на его соответствие текущим требованиям
                    // (Кароч чтобы число не вылезло за пределы возможностей переменной и нужных нам условий)
                    if (byte.TryParse(ReadLine(), out stringNumber) && stringNumber <= 50 && stringNumber > 0) break;
                    else Write("Кол-во строк должно быть целым числом от 1 до 50, попробуйте еще раз: ");
                }
                WriteLine();

                #region Создание треугольника Паскаля

                int[,] triangle = new int[stringNumber, stringNumber]; // Инициализация 2D массива для треугольника

                // Создание треугольника
                for (byte ind = 0; ind < stringNumber; ind++)
                {

                    triangle[ind, 0] = 1; // Выставление крайних единиц

                    for (byte ind_2 = 1; ind_2 <= ind; ind_2++)
                    {
                        if (ind >= 2)
                        {
                            triangle[ind, ind_2] = triangle[ind - 1, ind_2 - 1] + triangle[ind - 1, ind_2]; // Построение внутренней части
                        }
                        if (ind_2 == ind)
                        {
                            triangle[ind, ind_2] = 1; // Выставление крайних единиц
                        } 
                    }

                }

                #endregion

                #region Вывод

                WriteLine("-------------------------------------------------------------------------------------------------");

                // Вывод треугольника в консоль
                for (byte ind = 0; ind <= stringNumber - 1; ind++)
                {
                    // Специальный отступ, чтоб больше было похоже на треугольник
                    for (byte corr = (byte)(stringNumber - ind); corr > 0; corr--)
                    {
                        Write("    ");
                    }
                    // Вывод самого треугольника
                    for (byte ind_2 = 0; ind_2 <= stringNumber - 1; ind_2++)
                    {
                        Write($"{triangle[ind, ind_2], 8}");
                        if (ind_2 == ind) break;
                    }
                    WriteLine();
                }

                WriteLine("-------------------------------------------------------------------------------------------------");

                #endregion

                #region Повтор или выход

                WriteLine("Запустить заново? 1 - Повтор | 0 - Выход");
                while (true) // Ввод числа и его проверка
                {
                    // Проверка введенного значения на его соответствие текущим требованиям
                    // (Кароч чтобы число не вылезло за пределы возможностей переменной и нужных нам условий)
                    if (byte.TryParse(ReadLine(), out exit) && exit <= 1 && exit >= 0) break;
                    else Write("Число должно быть целым в диапазоне от 0 до 1, попробуйте еще раз: ");
                }
                WriteLine();
                if (exit == 0) break; // Завершение программы

                #endregion
            }
        }
    }
}
