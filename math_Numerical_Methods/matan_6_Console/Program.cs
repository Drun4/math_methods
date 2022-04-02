using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matan_6_Console
{
    class Program
    {
        static double function(double variable, double num1, double num2, double num3, double num4, double num5)
        {
            return num1 * Math.Pow(variable, 4) + num2 * Math.Pow(variable, 3) + num3 * Math.Pow(variable, 2) + num4 * variable + num5;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Rozniczkowanie\n");
            Console.WriteLine("num1 * x^4 + num2 * x^3 + num3 * x^2 + num4 * x + num5 = 0\n");
            double[] num_table = new double[5];
            for (int i = 0; i < num_table.Length; i++)
            {
                Console.Write($"num{i + 1} = ");
                num_table[i] = double.Parse(Console.ReadLine());
            }

            Console.Write("\nx = ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("h = ");
            double h = double.Parse(Console.ReadLine());
            double[] x_tab = new double[5];

            double x_temp = x - (2 * h);
            x_tab[0] = x_temp;
            for (int i = 1; i < x_tab.Length; i++)
            {
                x_tab[i] = x_temp += h;
            }

            Console.WriteLine("");
            double[] f_tab = new double[x_tab.Length];
            for (int i = 0; i < x_tab.Length; i++)
            {
                f_tab[i] = function(x_tab[i], num_table[0], num_table[1], num_table[2], num_table[3], num_table[4]);
                Console.WriteLine($"{x_tab[i]:0.000}\t{f_tab[i]:0.000}");
            }

            int center = x_tab.Length / 2;
            //Perwsze
            double f_1 = (-3 * f_tab[center] + 4 * f_tab[center + 1] - f_tab[center + 2]) / (2 * h);
            double f_2 = (f_tab[center - 2] - 4 * f_tab[center - 1] + 3 * f_tab[center]) / (2 * h);
            double f_3 = (f_tab[center - 2] - 8 * f_tab[center - 1] + 8 
                * f_tab[center + 1] - f_tab[center + 2]) / (12 * h);
            //Drugie
            double f_4 = (f_tab[center] - 2 * f_tab[center + 1] + f_tab[center + 2]) / (Math.Pow(h, 2));
            double f_5 = (f_tab[center - 2] - 2 * f_tab[center - 1] + f_tab[center]) / (Math.Pow(h, 2));
            double f_6 = (f_tab[center - 1] - 2 * f_tab[center] + f_tab[center + 1]) / (Math.Pow(h, 2));

            Console.WriteLine($"\nPierwsze pochodne");
            Console.WriteLine($"Trzypunktowe roznice zwykle: {f_1:0.000}");
            Console.WriteLine($"Trzypunktowe roznice wsteczne: {f_2:0.000}");
            Console.WriteLine($"Czteropunktowe roznice centralne: {f_3:0.000}");

            Console.WriteLine($"\nDrugie pochodne");
            Console.WriteLine($"Trzypunktowe roznice zwykle: {f_4:0.000}");
            Console.WriteLine($"Trzypunktowe roznice wsteczne: {f_5:0.000}");
            Console.WriteLine($"Trzypunktowe roznice centralne: {f_6:0.000}");

            Console.ReadKey();
        }
    }
}
