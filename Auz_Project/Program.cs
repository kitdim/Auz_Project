using System;
using System.IO;
using System.Linq;
using DimaLibrary;


namespace Auz_Project
{
    class Program
    {
        #region Задание, функционал, выбор кейса
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

        static string SelectProject(double Gmax, double qj, double [] ar1, double [] ar2, double [] ar3)
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

            return error;

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

                case "2":                                   // ввод параметров от пользователя

                    double[] e1 = new double [3]; FillArray(e1);
                    double[] e2 = new double [3]; FillArray(e2); 
                    double[] e3 = new double [3]; FillArray(e3);
                    double qj2 = InputQJ();
                    double[] e1Copy = CopyArray(e1);
                    double[] e2Copy = CopyArray(e2);
                    double[] e3Copy = CopyArray(e3);
                    OutputArray(e1,e2,e3);
                    One(e1, e2, e3, qj2);
                    double[] Gmin2 = Two(e1, e2, e3);
                    Two(Gmin2);
                    double Gmax2 = Three(Gmin2);
                    Three(Gmax2);
                    string Project2 = SelectProject(Gmax2, qj2, e1Copy, e2Copy, e3Copy);
                    InputProject(Project2);

                    break;

                case "3":
                    Task();
                    Console.Clear();
                    break;

                default:
                    Console.WriteLine("Делается");
                    Console.Clear();
                    break;


            }
           


            /*
            Осталось выполнить:
            1. Минимаксный критерий
            2. Возможность ввода параметров от пользователя +
            3. Сделать рассчет параметров от пользователя +/- (Реализовать ref/out к варианту 2.: ввод данных )
            4. Проблема при выборе лучшего проекта, разобратся 
             */
        }
    }
}
