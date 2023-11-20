using System;
using System.Net.NetworkInformation;

namespace QuickSort_InCSharp
{
    internal class Program
    {
        public static Random rn;
        public static int opc;
        
        static void Main(string[] args)
        {
            int[] arreglo_1 = { 4, 8, -3, 10, -7, -9, 2, -5, 6, 1 };
            int[] arreglo_2 = { 4, 8, -3, 10, -7, -9, 2, -5, 6, 1 };
            int[] arreglo_3 = { 4, 8, -3, 10, -7, -9, 2, -5, 6, 1 };
            rn = new Random();

            opc = 1;
            QuickSort(ref arreglo_1, 0, arreglo_1.Length - 1);
            foreach (int i in arreglo_1)
            {
                Console.Write(" " + i);
            }
            Console.WriteLine();

            opc = 2;
            Console.WriteLine("\n Pivote central");
            QuickSort(ref arreglo_2, 0, arreglo_2.Length - 1);
            foreach (int i in arreglo_2)
            {
                Console.Write(" " + i);
            }
            Console.WriteLine();

            opc = 3;
            Console.WriteLine("\n Pivote final");
            QuickSort(ref arreglo_3, 0, arreglo_3.Length - 1);
            foreach (int i in arreglo_3)
            {
                Console.Write(" " + i);
            }
            Console.ReadKey();
        }

        public static void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        public static int Partition(ref int[] arreglo, int menor, int mayor)
        {
            int pivot_index;
            switch (opc)
            {
                case 1:
                    pivot_index = menor;
                    break;

                case 2:
                    pivot_index = (int)Math.Floor((double)(mayor + menor) / 2);
                    break;

                case 3:
                    pivot_index = mayor;
                    break;

                default:
                    pivot_index = rn.Next(menor, mayor);
                    break;
            }

            Swap(ref arreglo[menor], ref arreglo[pivot_index]);

            int pivot = arreglo[menor];
            int izq = menor + 1;
            int der = mayor;

            while (true)
            {
                while (izq <= der && arreglo[izq] <= pivot)
                {
                    izq += 1;
                }

                while (izq <= der && arreglo[der] >= pivot)
                {
                    der -= 1;
                }

                if (izq <= der)
                {
                    Swap(ref arreglo[izq], ref arreglo[der]);
                    izq += 1;
                    der -= 1;
                }
                else
                {
                    break;
                }
            }
            Swap(ref arreglo[menor], ref arreglo[der]);
            return der;
        }

        public static void QuickSort(ref int[] arreglo, int menor, int mayor)
        {
            if (menor < mayor)
            {
                int pivot = Partition(ref arreglo, menor, mayor);

                QuickSort(ref arreglo, menor, pivot - 1);
                QuickSort(ref arreglo, pivot + 1, mayor);
            }
        }
    }
}