using System;
using System.IO;
using System.Linq;


namespace Auz_Project
{
    class Program
    {
        /// <summary>
        /// Задание
        /// </summary>
        static void Task() 
        {
            Console.WriteLine(File.ReadAllText(@"c:\Users\kitdim\Desktop\Project\task.txt")+
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
            Console.ReadKey();
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

        #region Критерий Гермейера

        /// <summary>
        /// Шаг 1.
        /// Умножение каждого элемента в матрице
        /// на известную вероятность состояния
        /// </summary>
        /// <param ar="double[]"></param>
        static void One(double[] arE1, double[] arE2, double[] arE3, double qj)
        {
            Console.WriteLine("Шаг 1.");
            Console.Write("E1 = ");
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
            Console.WriteLine("\nШаг 2.\n" +
                                "G1 = {0}\n" +
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
            Console.WriteLine("\nШаг 3." +
                              "\nGmax = {0}", Gmax);
            Console.ReadKey();
        }

        /// <summary>
        /// Определение выгодного проекта
        /// </summary>
        /// <param Gmax=double></param>
        static string SelectProject(double Gmax, double qj)
        {
            double[] arE1 = { 94, 50, 18 };                        
            double[] arE2 = { 51, 27, 11 };           
            double[] arE3 = { 19, 11, 7 };         
            string E1 = "E1 эффективнее";
            string E2 = "E2 эффективнее";
            string E3 = "E3 эффективнее";

            for (int i = 0; i < arE1.Length; i++)
            {
                arE1[i] = arE1[i] * qj;
                Math.Round(arE1[i], 2);
                if (arE1[i] == Gmax)
                return E1;
            }
            for (int i = 0; i < arE2.Length; i++)
            {
                arE2[i] = arE2[i] * qj;
                Math.Round(arE2[i], 2);
                if (arE2[i] == Gmax) 
                return E2;
            }
            for (int i = 0; i < arE3.Length; i++)
            {
                arE3[i] = arE3[i] * qj;
                Math.Round(arE3[i], 2);
                if (arE3[i] == Gmax) 
                return E3;
            }

            return null;

        }
        static void InputProject(string Project)
        {
            Console.WriteLine("\nПриходим к выводу что {0}",Project); Console.ReadKey();
        }
        #endregion
        
        static void Main(string[] args)
        {
            Task();
            Choice();
            string numberChoice = YourСhoice();
            switch(numberChoice)
            {
                case "1":                                   // параметры по умолчанию

                    double[] E1 = { 94, 50, 18 };           // проект, требующий больших вложений             
                    double[] E2 = { 51, 27, 11 };           // проект, требующий средних вложений
                    double[] E3 = { 19, 11, 7 };            // проект, требующий малых вложений
                    double qj = 0.33;                       // известная вероятность состояния

                    One(E1, E2, E3, qj);
                    double[] Gmin = Two(E1, E2, E3);
                    Two(Gmin);
                    double Gmax = Three(Gmin);
                    Three(Gmax);
                    string Project = SelectProject(Gmax, qj);
                    InputProject(Project);
                    break;

                case "2":
                    double[] e1 = new double [3]; FillArray(e1); 
                    double[] e2 = new double [3]; FillArray(e2); 
                    double[] e3 = new double [3]; FillArray(e3);
                    double qj2 = InputQJ();
                    OutputArray(e1,e2,e3);

                    break;

                case "3":
                    Task();
                    Console.Clear();
                    break;


            }
           


            /*
            Осталось выполнить:
            1. Минимаксный критерий
            2. Возможность ввода параметров от пользователя +
            3. Сделать рассчет параметров от пользователя
             */
        }
    }
}
