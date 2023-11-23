using System;
using System.Net.NetworkInformation;

namespace QuickSort_InCSharp
{

    internal class Program
    {
        public static Random rn;
        public static int opc;
        public static int contador_Intercambios;
        public static int contador_Particiones;
        public static int contador_Recursiones;
        public static int[] arreglo_1 = { 4, 8, -3, 10, -7, -9, 2, -5, 6, 1 };
        public static int[] arreglo_2 = { 4, 8, -3, 10, -7, -9, 2, -5, 6, 1 };
        public static int[] arreglo_3 = { 4, 8, -3, 10, -7, -9, 2, -5, 6, 1 };
        public static int[] arreglo_4 = { 4, 8, -3, 10, -7, -9, 2, -5, 6, 1 };

        static void Main(string[] args)
        {
            rn = new Random();
            //int[] nm = GenerarVector(-10, 10);
            //Console.WriteLine(string.Join(", ", nm));
            //Console.ReadKey();

            opc = 1;
            contador_Intercambios = 1;
            int[] nV = GenerarVector(-10,  10);
            Console.WriteLine("\n Pivote inicial");
            Imprimir(ref arreglo_1);
            Console.ReadKey();

            opc = 2;
            Console.WriteLine("\n Pivote central");
            Imprimir(ref arreglo_2);
            Console.ReadKey();

            opc = 3;
            Console.WriteLine("\n Pivote final");
            Imprimir(ref arreglo_3);
            Console.ReadKey();

            opc = 343454;
            Console.WriteLine("\n Pivote aleatorio");
            Imprimir(ref arreglo_4);
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
            contador_Particiones++;
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
            Console.WriteLine("Partición: " + contador_Particiones);
            Console.WriteLine("Intercambio: " + contador_Intercambios);
            Swap(ref arreglo[menor], ref arreglo[pivot_index]);
            PrintSwap(ref arreglo, menor, mayor);
            contador_Intercambios++;

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
                    Console.WriteLine("Partición: " + contador_Particiones);
                    Console.WriteLine("Intercambio: " + contador_Intercambios);
                    Swap(ref arreglo[izq], ref arreglo[der]);
                    Console.WriteLine();
                    PrintSwap(ref arreglo, menor, mayor);
                    contador_Intercambios++;
                    izq += 1;
                    der -= 1;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("Partición: " + contador_Particiones);
            Console.WriteLine("Intercambi: " + contador_Intercambios);
            Swap(ref arreglo[menor], ref arreglo[der]);
            PrintSwap(ref arreglo, menor, mayor);;
            contador_Intercambios++;
            return der;
        }

        public static void QuickSort(ref int[] arreglo, int menor, int mayor)
        {
            if (menor < mayor)
            {
                contador_Recursiones++;
                int pivot = Partition(ref arreglo, menor, mayor);

                QuickSort(ref arreglo, menor, pivot - 1);
                QuickSort(ref arreglo, pivot + 1, mayor);
            }
        }

        public static void Imprimir(ref int[] arr)
        {
            QuickSort(ref arr, 0, arr.Length - 1);
            foreach (int i in arr)
            {
                Console.Write(" " + i);
            }
            Console.WriteLine();
            contador_Intercambios = 0;
            contador_Particiones = 0;
            contador_Recursiones = 0;
        }

        public static void PrintSwap(ref int[] arr, int izq, int der)
        {
            Console.Write("[");

            for (int i = izq; i <= der; i++)
            {
                Console.Write(arr[i]);
                if (i < der)
                {
                    Console.Write(", ");
                }
            }

            Console.Write("]\n");
            Console.WriteLine();
            //Console.Write("[");
            //Console.Write(string.Join(", ", arr));
            //Console.Write("]\n");
            //Console.WriteLine();
        }

        public static int[] GenerarVector(int menor = 0, int longitud = 10)
        {
            List<int> list = new List<int>();

            for (int i = menor; i < longitud; i++) 
            {
                int nuevoValor = rn.Next(menor, longitud + 1);
                if (list.Contains(nuevoValor))
                {
                    i--;
                    continue;
                }

                list.Add(nuevoValor);
            }

            return list.ToArray();
        }
    }
}