using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matan_4_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Interpolacja:\n");

            double[] xTable = new double[4];
            double[] yTable = new double[4];

            for (int i = 0; i < xTable.Length; i++)
            {
                Console.Write($"x_{i} = ");
                xTable[i] = double.Parse(Console.ReadLine());
            }
            Console.WriteLine("");
            for (int i = 0; i < xTable.Length; i++)
            {
                Console.Write($"y_{i} = ");
                yTable[i] = double.Parse(Console.ReadLine());
            }
            Console.Write("\nx = ");
            double x = double.Parse(Console.ReadLine());

            Console.WriteLine("\n\tx0-xi   x1-xi   x2-xi   x3-xi   x-xi");
            double[] x0_xi = new double[xTable.Length];
            double[] x1_xi = new double[xTable.Length];
            double[] x2_xi = new double[xTable.Length];
            double[] x3_xi = new double[xTable.Length];
            double[] x_xi = new double[xTable.Length];
            for (int i = 0; i < x0_xi.Length; i++)
            {
                x0_xi[i] = xTable[0] - xTable[i];
                x1_xi[i] = xTable[1] - xTable[i];
                x2_xi[i] = xTable[2] - xTable[i];
                x3_xi[i] = xTable[3] - xTable[i];
                x_xi[i] = x - xTable[i];
                Console.Write("\t" + x0_xi[i] + "\t" + x1_xi[i] + "\t" + x2_xi[i]
                                + "\t" + x3_xi[i] + "\t" + x_xi[i] + "\n");
            }


            double f_1 =
                yTable[0] * (x_xi[1] * x_xi[2] * x_xi[3]) / (x0_xi[1] * x0_xi[2] * x0_xi[3]) +
                yTable[1] * (x_xi[0] * x_xi[2] * x_xi[3]) / (x1_xi[0] * x1_xi[2] * x1_xi[3]) +
                yTable[2] * (x_xi[0] * x_xi[1] * x_xi[3]) / (x2_xi[0] * x2_xi[1] * x2_xi[3]) +
                yTable[3] * (x_xi[0] * x_xi[1] * x_xi[2]) / (x3_xi[0] * x3_xi[1] * x3_xi[2]);

            Console.WriteLine("\nf = " + f_1);

            Console.WriteLine("\n\n32Wielomian Newtona:\n");
            double[] xi_1 = new double[xTable.Length - 1];
            double[] xi_2 = new double[xTable.Length - 2];
            double[] xi_3 = new double[xTable.Length - 3];
            double[] xi = new double[xTable.Length];

            for (int i = 0; i < xTable.Length; i++)
            {
                Console.Write($"x_{i} = ");
                xTable[i] = double.Parse(Console.ReadLine());
            }
            Console.WriteLine("");
            for (int i = 0; i < xTable.Length; i++)
            {
                Console.Write($"y_{i} = ");
                yTable[i] = double.Parse(Console.ReadLine());
            }
            Console.Write("\nx = ");
            x = double.Parse(Console.ReadLine());

            for (int i = 0; i < xi.Length; i++)
            {
                xi[i] = x - xTable[i];
            }
            for(int i = 0; i < xi_1.Length; i++)
            {
                xi_1[i] = (yTable[i + 1] - yTable[i]) / (xTable[i + 1] - xTable[i]);
            }
            for (int i = 0; i < xi_2.Length; i++)
            {
                xi_2[i] = (xi_1[i + 1] - xi_1[i]) / (xTable[i + 2] - xTable[i]);
            }
            for (int i = 0; i < xi_3.Length; i++)
            {
                xi_3[i] = (xi_2[i + 1] - xi_2[i]) / (xTable[i + 3] - xTable[i]);
            }

            Console.WriteLine("\nx-x_i\t\t[x_i,x_i+1]\t\t[x_i,x_i+1,x_i+2]\t\t[x_i,x_i+1,x_i+2,x_i+3]");
            for(int i = 0; i < xi.Length; i++)
            {
                Console.Write($"{xi[i]}\t\t");
                if (i < xi_1.Length)
                {
                    Console.Write($"{xi_1[i]}\t\t\t");
                }
                if (i < xi_2.Length)
                {
                    Console.Write($"{xi_2[i]}\t\t\t\t");
                }
                if (i < xi_3.Length)
                {
                    Console.Write($"{xi_3[i]}");
                }
                Console.WriteLine("");
            }
            double f_2 = yTable[0] + xi_1[0] * xi[0] + xi_2[0] * xi[0] * xi[1] + xi_3[0] * xi[0] * xi[1] * xi[2];
            Console.WriteLine("\nf = " + f_2);
            Console.ReadKey();
        }
    }
}

            /*
            Random rnd = new Random();
            double[] tab = new double[xTable.Length - 1];

            for (int j = 0; j < tab.Length; j++)
            {
                tab[j] = rnd.Next(0, 4);

                for(int p = 0; p < tab.Length; p++)
                {
                    int repeat = 0;
                    do
                    {
                        repeat = 0;
                        for (int k = 0; k < tab.Length; k++)
                        {
                            if (tab[p] == tab[k])
                            {
                                repeat++;
                            }
                        }
                    } while (repeat > 1);
                }
                ///
                for (int i = 0; i < xTable.Length; i++)
                {
                    if (tab[j] == i)
                    {
                        tab[j] = rnd.Next(0, 4);
                    }
                }
                ///
            }

            for (int i = 0; i < xTable.Length; i++)
            {
                f += yTable[i] * (x - x_xi[1]) * (x - x_xi[1]) * (x - x_xi[1]);
            }
            */

