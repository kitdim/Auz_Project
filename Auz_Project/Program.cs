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
                                                "\n\nНажмите на любую клавишу для продолжения...");
            Console.ReadKey();
            Console.Clear();
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

            double[] E1 = { 94, 50, 18 };           // проект, требующий больших вложений             
            double[] E2 = { 51, 27, 11 };           // проект, требующий средних вложений
            double[] E3 = { 19, 11, 7  };           // проект, требующий малых вложений
            double qj = 0.33;                       // известная вероятность состояния
            
            One(E1, E2, E3, qj);
            double[] Gmin = Two(E1, E2, E3);
            Two(Gmin);
            double Gmax = Three(Gmin);
            Three(Gmax);
            string Project = SelectProject(Gmax, qj);
            InputProject(Project);


            /*
            Осталось выполнить:
            1. Минимаксный критерии
            2. Возможность ввода параметров от пользователя 
             */
        }
    }
}
