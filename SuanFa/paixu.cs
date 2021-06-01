using System;
using System.Collections.Generic;
using System.Text;

namespace SuanFa
{
    public class paixu
    {
        /// <summary>
        /// 插入排序优化方案
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int[] InsertionSort(int[] array)
        {
            if (array == null || array.Length < 2)
                return array;

            for (var i = 1; i < array.Length; i++)
            {
                var key = array[i];
                var j = i - 1;
                while (j >= 0)
                {
                    if (key > array[j])
                        break;

                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }

            return array;
        }

        /// <summary>
        /// 暴力美学，冒泡排序算法
        /// </summary>
        /// <param name="array"></param>
        public static int[] BubbleSort(int[] array)
        {
            if (array == null || array.Length < 2)
                return array;

            for (var i = array.Length; i > 0; i--)
            {
                for (var j = 0; j < i; j++)
                {
                    if (array[j] <= array[j + 1]) continue;

                    var temp = array[j + 1];
                    array[j + 1] = array[j];
                    array[j] = temp;
                }
            }
            return array;
        }

        /// <summary>
        /// 选择排序:这个就是每次都找最小的那个，然后交换，直到最后一个数据
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int[] SelectSort(int[] array)
        {
            if (array == null || array.Length < 2)
                return array;
            for (var i = 0; i < array.Length; i++)
            {
                if (i == array.Length - 1) break;
                var minIndex = i;
                for (var j = i + 1; j < array.Length; j++)
                {
                    if (array[minIndex] > array[j])
                    {
                        minIndex = j;
                    }
                }

                var temp = array[i];
                array[i] = array[minIndex];
                array[minIndex] = temp;
            }

            return array;
        }

        /// <summary>
        /// //快速排序（目标数组，数组的起始位置，数组的结束位置,等于最大值减一）
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public static void QuickSort(int[] nums, int left, int right)
        {
            if (left < right)
            {
                var i = left;
                var j = right;
                var middle = nums[(left + right) / 2];
                while (true)
                {
                    while (i < j && nums[i] < middle) { i++; };
                    while (j > i && nums[j] > middle) { j--; };
                    if (i == j) break;

                    //交换位置
                    nums[i] = nums[i] + nums[j];
                    nums[j] = nums[i] - nums[j];
                    nums[i] = nums[i] - nums[j];
                    if (nums[i] == nums[j]) j--;
                }
                QuickSort(nums, left, i);
                QuickSort(nums, i + 1, right);
            }
        }

        /// <summary>
        /// 归并排序--自己琢磨了半天写出来的归并排序算法，体会：很多东西必须理论上理解了才能清醒的写出来好的代码
        /// </summary>
        /// <param name="array"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        public static int[] MergeSort(int[] array, int left, int right)
        {
            if (right == left)
            {
                return new[] { array[left] };
            }
            var middle = (left + right) / 2;
            var l1 = new int[middle - left + 1];
            var r1 = new int[right - middle];

            if (middle >= left)
            {
                l1 = MergeSort(array, left, middle);
            }
            if (middle < right)
            {
                r1 = MergeSort(array, middle + 1, right);
            }

            //合并l1 和 r1
            var newArray = new int[l1.Length + r1.Length];
            int b = 0, m = 0, j = 0;

            while (b < l1.Length && m < r1.Length)
            {
                if (l1[b] < r1[m])
                {
                    newArray[j] = l1[b];
                    b++;
                }
                else if (l1[b] > r1[m])
                {
                    newArray[j] = r1[m];
                    m++;
                }
                else
                {
                    newArray[j] = l1[b];
                    b++;
                    newArray[j] = r1[m];
                    m++;
                }
                j++;
            }

            if (b == l1.Length && m < r1.Length)
            {
                for (var i = m; i < r1.Length; i++)
                {
                    newArray[j] = r1[i];
                    j++;
                }
            }
            if (m == r1.Length && b < l1.Length)
            {
                for (var i = b; i < l1.Length; i++)
                {
                    newArray[j] = l1[i];
                    j++;
                }
            }
            return newArray;
        }

        /// <summary>
        /// 计数排序，核心思想是 申请内存空间，然后依次放入
        /// </summary>
        /// <param name="array"></param>
        public static void CountingSort(int[] array)
        {
            if (array.Length == 0) return;
            int min = array[0];
            int max = min;
            foreach (int number in array)
            {
                if (number > max)
                {
                    max = number;
                }
                else if (number < min)
                {
                    min = number;
                }
            }

            //属组
            int[] counting = new int[max - min + 1];

            // value就是出现的次数
            for (int i = 0; i < array.Length; i++)
            {
                counting[array[i] - min] += 1;
            }
            int index = -1;
            for (int i = 0; i < counting.Length; i++)
            {
                for (int j = 0; j < counting[i]; j++)
                {
                    index++;
                    array[index] = i + min;
                }
            }
        }

        /// <summary>
        /// 堆排序
        /// </summary>
        /// <param name="array"></param>
        public static void HeapSort(int[] array)
        {
            BuildMaxHeap(array);    //创建大顶推（初始状态看做：整体无序）
            for (int i = array.Length - 1; i > 0; i--)
            {
                Swap(ref array[0], ref array[i]); //将堆顶元素依次与无序区的最后一位交换（使堆顶元素进入有序区）
                MaxHeapify(array, 0, i); //重新将无序区调整为大顶堆
            }
        }

        /// <summary>
        /// 堆排序，核心思想构建大顶堆
        /// 根节点在属组中的下标如果是 i 那个左右子节点在数组中的下标就是 2*i +1 和 2*i +2,满足条件就是 
        /// array[i] > array[2i+1] && array[i] > array[2i+2]
        /// </summary>
        /// <param name="array"></param>
        public static void BuildMaxHeap(int[] array)
        {
            if (array?.Length < 2) return;

            for (var i = (array.Length / 2 - 1); i >= 0; i--)
            {
                MaxHeapify(array, i, array.Length);
            }

        }

        /// <summary>
        /// 大顶堆调整，调整的核心就是保证 currentIndex节点 的二叉树是大顶堆,由于是自底往上排序所以
        /// 只需要递归变化的部分，因为没变化的一开始就调整好了
        /// </summary>
        /// <param name="array"></param>
        /// <param name="currentIndex"></param>
        /// <param name="heapSize"></param>
        private static void MaxHeapify(int[] array, int currentIndex, int heapSize)
        {
            int left = 2 * currentIndex + 1;    //左子节点在数组中的位置
            int right = 2 * currentIndex + 2;   //右子节点在数组中的位置
            int large = currentIndex;   //记录此根节点、左子节点、右子节点 三者中最大值的位置

            if (left < heapSize && array[left] > array[large])  //与左子节点进行比较
            {
                large = left;
            }
            if (right < heapSize && array[right] > array[large])    //与右子节点进行比较
            {
                large = right;
            }
            if (currentIndex != large)  //如果 currentIndex != large 则表明 large 发生变化（即：左右子节点中有大于根节点的情况）
            {
                Swap(ref array[currentIndex], ref array[large]);    //将左右节点中的大者与根节点进行交换（即：实现局部大顶堆）
                MaxHeapify(array, large, heapSize); //以上次调整动作的large位置（为此次调整的根节点位置），进行递归调整
            }
        }
        ///<summary>
        /// 交换函数
        ///</summary>
        ///<param name="a">元素a</param>
        ///<param name="b">元素b</param>
        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
