using System;

namespace matan_5_Console
{
    class Program
    {
        static double function(double variable, double num1, double num2, double num3, double num4)
        {
            return num1 * Math.Pow(variable, 3) + num2 * Math.Pow(variable, 2) + num3 * variable + num4;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Metoda trapezow & simpsona\n");
            Console.WriteLine("num1 * x^3 + num1 * x^2 + num1 * x + num4 = 0\n");
            double[] num_table = new double[4];
            for (int i = 0; i < num_table.Length; i++)
            {
                Console.Write($"num{i + 1} = ");
                num_table[i] = double.Parse(Console.ReadLine());
            }

            Console.Write("\na = ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("b = ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("number of limits: ");
            int numbeк_of_limits = int.Parse(Console.ReadLine());
            double h = (b - a) / numbeк_of_limits;

            double[] x_tab = new double[numbeк_of_limits + 1];
            x_tab[0] = a;
            for (int i = 1; i < x_tab.Length; i++)
            {
                x_tab[i] = a += h;
            }
            Console.WriteLine("");
            double[] f_tab = new double[numbeк_of_limits + 1];
            for(int i = 0; i < f_tab.Length; i++)
            {
                f_tab[i] = function(x_tab[i], num_table[0], num_table[1], num_table[2], num_table[3]);
                Console.Write($"{x_tab[i]:0.000}\t{f_tab[i]:0.000}\n");
            }
            double f_withoutFirstandLast = 0;
            for(int i = 1; i < f_tab.Length - 1; i++)
            {
                f_withoutFirstandLast += f_tab[i];
            }
            double K_trapez = h * ((f_tab[0] + f_tab[numbeк_of_limits])/2 + f_withoutFirstandLast);

            double f_even = 0, f_odd = 0;
            for(int i = 1; i < f_tab.Length - 1; i++)
            {
                if(i % 2 == 0)
                {
                    f_even += f_tab[i];
                }
                if (i % 2 == 1)
                {
                    f_odd += f_tab[i];
                }
            }

            double K_simpson = h / 3 * (f_tab[0] + f_tab[numbeк_of_limits] + 2 * f_even + 4 * f_odd);
            Console.WriteLine($"\nTrapezoidal method : {K_trapez}");
            Console.WriteLine($"Simpson's method : {K_simpson}");
            Console.ReadKey();
        }
    }
}
