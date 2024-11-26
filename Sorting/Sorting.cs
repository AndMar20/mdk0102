using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using ReyRom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

BenchmarkRunner.Run<Sorting>();

namespace ReyRom
{

    public class Sorting
    {

        [Params(0)]
        public int left { get; set; }
        [Params(20)]
        public int right { get; set; }

        static int[] GenerateRandomArray(int size)
        {
            Random random = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(0, 10000);
            }
            return array;
        }

        static int[] random = GenerateRandomArray(21);

        [Benchmark]
        public void RunBubbleSort()
        {
            BubbleSort(random);
        }

        [Benchmark]
        public void RunSort()
        {
            Sort(random);
        }

        [Benchmark]
        public void RunQuickSort()
        {
            QuickSort(random, left, right);
        }
        public static void BubbleSort(int[] data)
        {
            for (int i = 0; i < data.Length - 1; i++)
            {
                for (int j = 0; j < data.Length - i - 1; j++)
                {
                    if (data[j] > data[j + 1])
                    {
                        int temp = data[j];
                        data[j] = data[j + 1];
                        data[j + 1] = temp;
                    }
                }
            }
        }
        public static void QuickSort(int[] data, int left, int right)
        {
            int i = left, j = right;
            int pivot = data[(left + right) / 2];
            while (i <= j)
            {
                while (data[i] < pivot) i++;
                while (data[j] > pivot) j--;
                if (i <= j)
                {
                    int tmp = data[i];
                    data[i] = data[j];
                    data[j] = tmp;
                    i++;
                    j--;
                }
            }
            if (left < j) QuickSort(data, left, j);
            if (i < right) QuickSort(data, i, right);
        }
        public static void Sort(int[] data)
        {
            Array.Sort(random);
        }
    }
}
