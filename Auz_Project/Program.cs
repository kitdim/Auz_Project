using System;
using System.IO;
using System.Linq;
using DimaLibrary;


namespace Auz_Project
{
    class Program
    {
        #region Задание, функционал, выбор кейса, прощание
        /// <summary>
        /// Задание
        /// </summary>
        static void Task() 
        {
            Console.Write(File.ReadAllText(@"c:\Users\kitdim\Desktop\Project\task.txt")+
                                            "\n\nНажмите на любую на клавишу для продолжения...");
            Console.ReadKey();
        }

        /// <summary>
        ///  Функционал программы
        /// </summary>
        static void Choice()
        {
            Console.WriteLine(File.ReadAllText(@"c:\Users\kitdim\Desktop\Project\Choice.txt"));
        }

        /// <summary>
        /// Отправка числа на кейсы для выбора 
        /// </summary>
        /// <returns></returns>
        static string YourСhoice()
        {           
            Console.Write("\nВыберите нужный вариант для продолжения: ");
            string number = Console.ReadLine();
            Console.Clear();
            return number;
        }

        /// <summary>
        /// Прощание с пользователем
        /// </summary>
        static void Goodbye()
        {
            Random rnd = new Random();
            int value = rnd.Next(1, 4); 
            switch (value)
            {
                case 1:
                    Console.WriteLine("До свидание!");
                    break;
                case 2:
                    Console.WriteLine("Пока!");
                    break;
                case 3:
                    Console.WriteLine("Всего доброго!");
                    break;
            }
            Console.ReadKey();

        }
        #endregion

        #region Заполнение данных от пользователя
        /// <summary>
        /// Заполнение массива с клавиатуры
        /// </summary>
        /// <param name="ar"></param>
        /// <returns>Заполненный массив</returns>
        static double [] FillArray(double [] ar)
        {
            for (int i = 0; i < ar.Length; i++)
            {
                Console.Write("E = ");
                ar[i] = double.Parse(Console.ReadLine());
                Console.Clear();
            }
            return ar;
        }

        /// <summary>
        /// Вывод массива
        /// </summary>
        /// <param значения проекта="ar"></param>
        static void OutputArray(double [] ar1, double[] ar2, double[] ar3)
        {
            Console.Write("E1 ={");
            for (int i = 0; i < ar1.Length; i++)
            {
                Console.Write($" {ar1[i]} ");
            }
            Console.Write("}");
            Console.WriteLine();
            Console.Write("E2 ={");
            for (int i = 0; i < ar2.Length; i++)
            {
                Console.Write($" {ar2[i]} ");
            }
            Console.Write("}");
            Console.WriteLine();
            Console.Write("E3 ={");
            for (int i = 0; i < ar3.Length; i++)
            {
                Console.Write($" {ar3[i]} ");
            }
            Console.Write("}");
            Console.WriteLine("\nНажмите на любую клавишу для расчета...");
            Console.ReadKey();
        }

        /// <summary>
        /// Копируем массив для сохранения
        /// </summary>
        /// <param массив до изменений="ar1"></param>
        /// <returns>Копию</returns>
        static double [] CopyArray(double[] ar1)
        {
            double[] ArrayCopy = ar1;
            return ArrayCopy;
        }

        /// <summary>
        /// Заполнение с клавиатуры известной вероятности состояния
        /// </summary>
        /// <returns>известная вероятность состояния</returns>
        static double InputQJ()
        {
            Console.Write("qj = ");
            double qj = double.Parse(Console.ReadLine());
            return qj;
        }
        #endregion

        #region Критерий Гермейера

        /// <summary>
        /// Шаг 0. Находим максимальное число в трёх матрицах 
        /// и отмимаем его от каждого элемента в матрицах
        /// </summary>
        /// <param name="arE1"></param>
        /// <param name="arE2"></param>
        /// <param name="arE3"></param>
        static void Zero(double[] arE1, double[] arE2, double[] arE3)
        {
            double maxE1 = arE1.Max();
            double maxE2 = arE2.Max();
            double maxE3 = arE3.Max();
            double max;

            if (maxE1 > maxE2 && maxE1 > maxE3) max = maxE1 + 1;
            else if (maxE2 > maxE1 && maxE2 > maxE3) max = maxE2 + 1;
            else max = maxE3 + 1;

            for (int i = 0; i < arE1.Length; i++)
            {
                arE1[i] -= max;
            }

            for (int i = 0; i < arE2.Length; i++)
            {
                arE2[i] -= max;
            }

            for (int i = 0; i < arE3.Length; i++)
            {
                arE3[i] -= max;
            }
        }

        /// <summary>
        /// Шаг 1.
        /// Умножение каждого элемента в матрице
        /// на известную вероятность состояния
        /// </summary>
        /// <param ar="double[]"></param>
        static void One(double[] arE1, double[] arE2, double[] arE3, double qj)
        {
            Console.WriteLine("Шаг 1. Умножение каждого элемента в матрице на известную вероятность состояния");
            Console.Write("\nE1 = ");
            for (int i = 0; i < arE1.Length; i++)
            {
                arE1[i] = arE1[i] * qj;
                Console.Write($"{Math.Round(arE1[i], 2)}\t");        // вывод значений с двумя знаками после запятой
            }
            Console.WriteLine();
            Console.Write("E2 = ");
            for (int i = 0; i < arE2.Length; i++)
            {
                arE2[i] = arE2[i] * qj;
                Console.Write($"{Math.Round(arE2[i], 2)}\t");
            }
            Console.WriteLine();
            Console.Write("E3 = ");
            for (int i = 0; i < arE3.Length; i++)
            {
                arE3[i] = arE3[i] * qj;
                Console.Write($"{Math.Round(arE3[i], 2)}\t");
            }
            Console.WriteLine();
            Console.WriteLine("\nНажмите на любую клавишу для продолжения...");
            Console.ReadKey();

        }
        
        /// <summary>
        /// Тот же шаг 1, только на двухмерном массиве
        /// </summary>
        /// <param двухмерный массив="E"></param>
        /// <param известная вероятность="qj"></param>
        static void One(double [,] E, double qj)
        {
            uint b = 1;                         // cчетчик для отображения какой именно проект выводится
            for (int i = 0; i < E.Length; i++)
            {
                Console.Write("E{0} = ", b);
                for (int j = 0; j < E.Length; j++)
                {
                    E[i,j] *= qj;                               // на этой строке ошибка перевыполнения
                    Console.Write($"{Math.Round(E[i,j], 2)}\t");
                }
                b ++;
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        /// <summary>
        /// Шаг 2. Найти минимальное значение
        /// </summary>
        /// <param ar="double[]"></param>
        static double[] Two(double[] arE1, double[] arE2, double[] arE3)
        {
            
            double minG1 = Math.Round(arE1.Min(), 2);              // ищем минимальный элемент в массиве
            double minG2 = Math.Round(arE2.Min(), 2);
            double minG3 = Math.Round(arE3.Min(), 2);
            double[] minAr = { minG1,minG2,minG3 };
            return minAr;
        }
        static void Two(double[] ar)
        {
            Console.WriteLine("\nШаг 2. Находим минимальное значение\n" +
                                "\nG1 = {0}\n" +
                                "G2 = {1}\n" +
                                "G3 = {2}", ar[0], ar[1], ar[2]);
            Console.WriteLine("\nНажмите на любую клавишу для продолжения...");
            Console.ReadKey();

        }

        /// <summary>
        /// Шаг 3. Найти максимальное значение среди минимальных
        /// </summary>
        /// <param ar="double[]"></param>
        static double Three(double [] ar)
        {
            double Gmax = ar.Max();                 // ищем минимальное значение
            return Gmax; 
        }
        static void Three(double Gmax)
        {
            Console.WriteLine("\nШаг 3. Находим максимальное значение среди минимальных значений\n" +
                              "\nGmax = {0}", Gmax);
            Console.ReadKey();
        }

        /// <summary>
        /// Определение выгодного проекта
        /// </summary>
        /// <param Gmax=double></param>
        static string SelectProject(double Gmax, double qj)
        {
                /* Ошибка 
                 2.1.   
                    Ишет нужное значение Gmax без ранее 
                    выполнннего шага ZERO(вычитание из каждого элемента матрицы 
                    самое максмальное значение из все проектов
                    
                    !!! ИСПРАВЛЕНО !!! Добавил данные из метода ZERO
                */

            double[] arE1 = { 94, 50, 18 };                        
            double[] arE2 = { 51, 27, 11 };           
            double[] arE3 = { 19, 11, 7 };
            double maxE1 = arE1.Max();
            double maxE2 = arE2.Max();
            double maxE3 = arE3.Max();
            double max;
            string E1 = "E1 эффективнее";
            string E2 = "E2 эффективнее";
            string E3 = "E3 эффективнее";
            string error = "ошибка";

            if (maxE1 > maxE2 && maxE1 > maxE3) max = maxE1 + 1;
            else if (maxE2 > maxE1 && maxE2 > maxE3) max = maxE2 + 1;
            else max = maxE3 + 1;
 
            for (int i = 0; i < arE1.Length; i++)
            {
                arE1[i] -= max;
                arE1[i] = arE1[i] * qj;
                Math.Round(arE1[i], 2);
                if (arE1[i] == Gmax)
                return E1;
            }
            for (int i = 0; i < arE2.Length; i++)
            {
                arE2[i] -= max;
                arE2[i] = arE2[i] * qj;
                Math.Round(arE2[i], 2);
                if (arE2[i] == Gmax) 
                return E2;
            }
            for (int i = 0; i < arE3.Length; i++)
            {
                arE3[i] -= max;
                arE3[i] = arE3[i] * qj;
                Math.Round(arE3[i], 2);
                if (arE3[i] == Gmax) 
                return E3;
            }

            return error;

        }

        static string SelectProject(double Gmax, double [] ar1, double [] ar2, double [] ar3)
        {
            double[] arE1 = ar1;
            double[] arE2 = ar2;
            double[] arE3 = ar3;
            string E1 = "E1 эффективнее";
            string E2 = "E2 эффективнее";
            string E3 = "E3 эффективнее";
            string error = "Error";

            for (int i = 0; i < arE1.Length; i++)
            {
                
                Math.Round(arE1[i], 2);
                if (arE1[i] == Gmax)
                    return E1;
            }
            for (int i = 0; i < arE2.Length; i++)
            {
                
                Math.Round(arE2[i], 2);
                if (arE2[i] == Gmax)
                    return E2;
            }
            for (int i = 0; i < arE3.Length; i++)
            {
                
                Math.Round(arE3[i], 2);
                if (arE3[i] == Gmax)
                    return E3;
            }

            return error;

        }
        static void InputProject(string Project)
        {
            Console.WriteLine("\nПриходим к выводу что {0}",Project); Console.ReadKey();
        }
        #endregion
        
        static void Main(string[] args)
        {
            double[,] E_1_3 = {
                              { 94, 50, 18 },
                              { 51, 27, 11 },
                              { 19, 11, 7 }
                              };

            double[] E1 = { 94, 50, 18 };           // проект, требующий больших вложений             
            double[] E2 = { 51, 27, 11 };           // проект, требующий средних вложений
            double[] E3 = { 19, 11, 7 };            // проект, требующий малых вложений
            double qj = 0.33;                       // известная вероятность состояния

            while (true)
            {
                Console.Clear();
                Choice();
                string numberChoice = YourСhoice();
                if (numberChoice == "4") { Goodbye(); break; }
                switch (numberChoice)
                {
                    case "1":                                   // параметры по умолчанию
                        Zero(E1, E2, E3);
                        One(E1, E2, E3, qj);
                        double[] Gmin = Two(E1, E2, E3);
                        Two(Gmin);
                        double Gmax = Three(Gmin);
                        Three(Gmax);
                        string Project = SelectProject(Gmax, qj);
                        InputProject(Project);
                        
                        continue;

                    case "2":                                   // ввод параметров от пользователя

                        double[] e1 = new double[3]; FillArray(e1);
                        double[] e2 = new double[3]; FillArray(e2);
                        double[] e3 = new double[3]; FillArray(e3);
                        double qj2 = InputQJ();
                        double[] e1Copy = CopyArray(e1);
                        double[] e2Copy = CopyArray(e2);
                        double[] e3Copy = CopyArray(e3);
                        OutputArray(e1, e2, e3);
                        One(e1, e2, e3, qj2);
                        double[] Gmin2 = Two(e1, e2, e3);
                        Two(Gmin2);
                        double Gmax2 = Three(Gmin2);
                        Three(Gmax2);
                        string Project2 = SelectProject(Gmax2, e1Copy, e2Copy, e3Copy);
                        InputProject(Project2);

                        continue;

                    case "3":                                    // вывод на экран задания

                        Task();
                        Console.Clear(); 
                        continue;

                    case "5":                                     // попытка реализации двухмерного массива

                        One(E_1_3, qj);
                        continue;

                    default:
                        Console.Write("Делается....");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                }
            }



            /*
            Осталось выполнить:
            1. Минимаксный критерий !
            2. Возможность ввода параметров от пользователя +
                Исправлено +
                2.1. В отрицательные значения перенести на шаге 1 +/- Ошибка не выводит лучший проект. Коммент оставил +
            3. Сделать рассчет параметров от пользователя +/- 
                3.1 Реализовать ref/out к варианту 2.: ввод данных 
                3.2 Реализовать трехмерный массив вместо 3 отдельных массивов
            4. Проблема при выборе лучшего проекта, разобратся +, не нужно было умножать числа в массиве, в нем уже сохранилось значение
               после шага 1.Перемножить с известной вероятностью состаяния состоянием РЕШЕНО
            5. Реализовать дружелюбный для пользователя интерфейс +/-
                5.1. Дописать что происходит на каждом шаге+

             */
        }
    }
}
