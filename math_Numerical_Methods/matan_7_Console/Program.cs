using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matan_7_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] xTable = new double[8];
            xTable[0] = 1;
            xTable[1] = 3;
            xTable[2] = 4;
            xTable[3] = 6;
            xTable[4] = 8;
            xTable[5] = 9;
            xTable[6] = 11;
            xTable[7] = 14;

            double[] yTable = new double[8];
            yTable[0] = 1;
            yTable[1] = 2;
            yTable[2] = 4;
            yTable[3] = 4;
            yTable[4] = 5;
            yTable[5] = 7;
            yTable[6] = 8;
            yTable[7] = 9;

            double xSum = 0;
            for (int i = 0; i < xTable.Length; i++)
            {
                xSum += xTable[i];
            }
            double ySum = 0;
            for (int i = 0; i < yTable.Length; i++)
            {
                ySum += yTable[i];
            }

            double[] firstRaw = new double[5];
            for(int i = 0; i < firstRaw.Length; i++)
            {
                xSum = 0;
                for (int j = 0; j < xTable.Length; j++)
                {
                    xSum += Math.Pow(xTable[j], i);
                }
                firstRaw[i] += xSum;
                if(i == firstRaw.Length - 1)
                {
                    firstRaw[i] = ySum;
                }
                Console.Write(firstRaw[i] + "\t\t");
            }

            Console.Write("\n");
            double[] secondRaw = new double[5];
            ySum = 0;
            for (int i = 0; i < yTable.Length; i++)
            {
                ySum += (yTable[i] * xTable[i]);
            }
            for (int i = 0; i < secondRaw.Length; i++)
            {
                xSum = 0;
                for (int j = 0; j < xTable.Length; j++)
                {
                    xSum += Math.Pow(xTable[j], i + 1);
                }
                secondRaw[i] += xSum;
                if (i == firstRaw.Length - 1)
                {
                    secondRaw[i] = ySum;
                }
                Console.Write(secondRaw[i] + "\t\t");
            }

            Console.Write("\n");
            double[] thirdRaw = new double[5];
            ySum = 0;
            for (int i = 0; i < yTable.Length; i++)
            {
                ySum += (yTable[i] * Math.Pow(xTable[i], 2));
            }
            for (int i = 0; i < thirdRaw.Length; i++)
            {
                xSum = 0;
                for (int j = 0; j < xTable.Length; j++)
                {
                    xSum += Math.Pow(xTable[j], i + 2);
                }
                thirdRaw[i] += xSum;
                if (i == firstRaw.Length - 1)
                {
                    thirdRaw[i] = ySum;
                }
                Console.Write(thirdRaw[i] + "\t\t");
            }

            Console.Write("\n");
            double[] fourthdRaw = new double[5];
            ySum = 0;
            for (int i = 0; i < yTable.Length; i++)
            {
                ySum += (yTable[i] * Math.Pow(xTable[i], 3));
            }
            for (int i = 0; i < fourthdRaw.Length; i++)
            {
                xSum = 0;
                for (int j = 0; j < xTable.Length; j++)
                {
                    xSum += Math.Pow(xTable[j], i + 3);
                }
                fourthdRaw[i] += xSum;
                if (i == firstRaw.Length - 1)
                {
                    fourthdRaw[i] = ySum;
                }
                Console.Write(fourthdRaw[i] + "\t\t");
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("\n\nRownanie: ");
            double[,] initTable = new double[4, 5];
            double[,] editTable = new double[4, 5];

            for(int i = 0; i < initTable.GetLength(1); i++)
            {
                initTable[0, i] = firstRaw[i];
            }
            for (int i = 0; i < initTable.GetLength(1); i++)
            {
                initTable[1, i] = secondRaw[i];
            }
            for (int i = 0; i < initTable.GetLength(1); i++)
            {
                initTable[2, i] = thirdRaw[i];
            }
            for (int i = 0; i < initTable.GetLength(1); i++)
            {
                initTable[3, i] = fourthdRaw[i];
            }

            for (int i = 0; i < initTable.GetLength(0); i++)
            {
                for (int j = 0; j < editTable.GetLength(1); j++)
                {
                    editTable[i, j] = initTable[i, j];
                }
            }

            int strNum = 0;
            int coeffAmount = 3;
            int colNum = 0;

            for (int k = 0; k < initTable.GetLength(0); k++)
            {
                int coeffNum = 0;
                int colNumInStr = 0;

                double[] coeffTable = new double[coeffAmount];
                int length = 0;
                for (int j = k + 1; j < initTable.GetLength(0); j++)
                {
                    for (int c = length; c < coeffTable.Length;)
                    {
                        coeffTable[c] = editTable[j, k] / editTable[strNum, colNum];
                        length++;
                        break;
                    }
                }
                for (int i = 0; i < initTable.GetLength(1); i++)
                {
                    for (int j = k + 1; j < initTable.GetLength(0); j++)
                    {
                        editTable[j, i] = editTable[j, i] - coeffTable[coeffNum] * editTable[strNum, colNumInStr];
                        coeffNum++;
                    }
                    coeffNum = 0;
                    colNumInStr++;
                }
                colNum++;
                strNum++;
                coeffAmount--;
            }

            for (int i = 0; i < editTable.GetLength(0); i++)
            {
                for (int j = 0; j < editTable.GetLength(1); j++)
                {
                    Console.Write($"{editTable[i, j]} ");
                }
                Console.WriteLine();
            }

            double P = editTable[3, 4] / editTable[3, 3];
            Console.WriteLine($"\nP = {P}");
            double Z = (editTable[2, 4] - editTable[2, 3] * P) / editTable[2, 2];
            Console.WriteLine($"Z = {Z}");
            double Y = (editTable[1, 4] - editTable[1, 3] * P - editTable[1, 2] * Z) / editTable[1, 1];
            Console.WriteLine($"P = {Y}");
            double X = (editTable[0, 4] - editTable[0, 3] * P - editTable[0, 2] * Z - editTable[0, 1] * Y) / editTable[0, 0];
            Console.WriteLine($"P = {X}");
            Console.ReadLine();
        }



        //for (int i = 0; i < tab.GetLength(0); i++)
        //{
        //    xSum = 0;
        //    ySum = 0;
        //    for (int p = 0; p < xTable.Length; p++)
        //    {
        //        xSum += Math.Pow(xTable[p], i + 1);
        //    }
        //    for (int p = 0; p < yTable.Length; p++)
        //    {
        //        ySum += yTable[p] * Math.Pow(xTable[p], i);
        //    }

        //    for (int j = 0; j < tab.GetLength(1); j++)
        //    {
        //        if (j == 0 && i >= 1)
        //        {
        //            tab[i, j] = tab[i-1, tab.GetLength(1)/2 - 1];
        //        }
        //        else
        //        {
        //            tab[i, j] = Math.Pow(xSum, j);
        //        }

        //        if (j == tab.GetLength(1) - 1)
        //        {
        //            tab[i, j] = Math.Pow(ySum, (i + 1));
        //        }

        //        tab[0, 0] = xTable.Length;
        //        Console.Write($"{tab[i, j]}   ");
        //    }
        //    Console.WriteLine("");
        //}
    }
}
