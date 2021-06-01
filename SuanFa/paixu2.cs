using System;
using System.Collections.Generic;
using System.Text;

namespace SuanFa
{
    public class paixu2
    {
        /// <summary>
        /// 插入排序 时间复杂度 O2，思想就是前面的序列是排好序的，后面的插入适当的位置
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int[] InsertSort(int[] arr)
        {
            if (arr==null || arr.Length < 2)
                return arr;

            for (var i = 1; i < arr.Length; i++)
            {
                var val = arr[i];
                var j = i - 1;
                while (j >= 0)
                {
                    if (val>arr[j])
                    {
                        break;
                    }
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j+1] = val;
            }

            return arr;
        }

        //第二种插入排序算法--这种方式不好 时间复杂度太高
        public static int[] InsertSort2(int[] arr)
        {
            if (arr == null || arr.Length < 2)
                return arr;

            for (var i = 1; i < arr.Length; i++)
            {
                var val = arr[i];
                var changeIndex = i;
                for (var j = 0; j < i; j++)
                {
                    if (val > arr[j])
                    {
                        continue;
                    }

                    changeIndex = j;
                    yiwei(arr,j,i);
                    break;
                }
                arr[changeIndex] = val;
            }

            return arr;
        }

        public static void yiwei(int[] arr, int start, int end)
        {
            if (arr == null || start >= end || arr.Length<end) return;

            for (var i = end; i > start; i--)
            {
                arr[i] = arr[i - 1];
            }
        }

        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int[] BubbleSort(int[] arr)
        {
            if (arr == null || arr.Length < 2) return arr;
            var j = arr.Length;
            while (j>=1)
            {
                for (var i = 1; i < j; i++)
                {
                    if (arr[i] >= arr[i - 1]) continue;

                    //swap
                    var temp = arr[i - 1];
                    arr[i - 1] = arr[i];
                    arr[i] = temp;
                }

                j--;
            }

            return arr;
        }

        /// <summary>
        /// 算法的时间复杂度仍然是 O2
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int[] SelectSort(int[] arr)
        {
            if (arr == null || arr.Length < 2) return arr;

            for (var j = 0; j < arr.Length; j++)
            {
                var minIndex = j;
                for (var i = j+1; i < arr.Length; i++)
                {
                    if (arr[minIndex] > arr[i])
                    {
                        minIndex = i;
                    }
                }

                if (minIndex != j)
                {
                    var temp = arr[j];
                    arr[j] = arr[minIndex];
                    arr[minIndex] = temp;
                }
            }

            return arr;
        }


        /// <summary>
        /// 递归的思想
        /// </summary>
        /// <param name="arr"></param>
        public static void QuickSort(int[] arr,int start,int end)
        {
            if (start >= end) return;

            var middle = arr[start];
            var i = start;
            var j = end;
            while (i<j)
            {
                while(arr[i] < middle && i<j) i++;
                while (arr[j] >= middle && i<j) j--;
                if (i == j) break;
                Swap(arr, i, j);
            }

            QuickSort(arr, start, i - 1);
            QuickSort(arr, i, end);
        }

        public static void Swap(int[] arr, int index1, int index2)
        {
            var temp = arr[index1];
            arr[index1] = arr[index2];
            arr[index2] = temp;
        }

    }
}
