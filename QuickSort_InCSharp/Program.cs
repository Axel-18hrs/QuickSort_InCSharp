namespace QuickSort_InCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arreglo = { -2, -1, 45, 23, 7, 2, 4, 1, 3, 198 };
            int pivot = arreglo.Length % 2 > 0 ? arreglo.Length / 2 + 1 : arreglo.Length / 2;

            QuickSort(ref arreglo, pivot, arreglo.Length - 1);
            foreach (int i in arreglo) 
            {
                Console.WriteLine(i);
            }
        }

        public static void Swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        public static int Partition(ref int[] arreglo, int aleatorio, int longitud)
        {
            int pivot = arreglo[aleatorio];
            int izq = 0;
            int der = longitud;

            while (true)
            {
                while (izq <= der && arreglo[izq] <= pivot)
                {
                    izq++;
                }

                while (izq <= der && arreglo[der] >= pivot)
                {
                    der--;
                }

                if (der < izq)
                {
                    break;
                }

                Swap(ref arreglo[izq], ref arreglo[der]);
            }
            Swap(ref arreglo[aleatorio], ref arreglo[der]);
            return der;
        }

        public static void QuickSort(ref int[] arreglo, int aleatorio, int longitud)
        {
            if (aleatorio < longitud)
            {
                int pivot = Partition(ref arreglo, aleatorio, longitud);

                QuickSort(ref arreglo, aleatorio, pivot - 1);
                QuickSort(ref arreglo, pivot + 1, longitud);
            }
        }
    }
}