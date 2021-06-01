using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace LeetcodeDemo
{
    public class NanTi1
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static int ArrySplit(int[] arr)
        {
            CountingSort(arr);
            var sum = 0;
            for (var i = 0; i < arr.Length / 2; i++)
            {
                sum += arr[2 * i];
            }
            return sum;
        }

        public static int SwitchLightBulb(int n)
        {
            if (n == 0) return 0;
            return (int)Math.Sqrt(n);
        }
        public static int SwitchLightBulbBak(int n) 
        {
            if (n == 0) return 0;
            if (n == 1 || n==2) return 1;

            var arr = new int[n];

            //第一轮
            for (var i = 0; i < n; i++)
            {
                arr[i] = 1;
            }

            //第二轮到n轮
            for (var i = 2; i <= n; i++)
            {
                for (var j = 1; j <= n / i; j++)
                {
                    arr[j * i - 1] = 1 - arr[j * i - 1];
                }
            }

            var sum = 0;
            for (var i = 0; i < n; i++)
            {
                sum += arr[i];
            }
            return sum;
        }
        public static int GetRainNum(int[] arr)
        {
            if (arr?.Length == 0)
                return 0;
            var count = 0;
            for (var i = 0; i < arr.Length-1; i++)
            {
                if (i == 0 && arr[i] == 0) continue;
                if (arr[i + 1] >= arr[i]) {
                    if (i == arr.Length - 2) return count;
                    continue;
                };

                var leftMaxIndex = i;
                var rightMaxIndex = i+1;

                //查找右边最大值
                for (var z = i+1; z < arr.Length-1; z++)
                {
                    if (arr[z] >= arr[leftMaxIndex]) 
                    {
                        rightMaxIndex = z;
                        break;
                    }
                    if (arr[z + 1] >= arr[rightMaxIndex]) {
                        rightMaxIndex = z + 1;
                    }
                    if (z == arr.Length - 2) break;
                }

                // 计算
                var height = arr[leftMaxIndex] <= arr[rightMaxIndex] ? arr[leftMaxIndex] : arr[rightMaxIndex];
                var subCount = 0;
                for (var e = leftMaxIndex; e <= rightMaxIndex; e++)
                {
                    subCount += arr[e] > height ? height : arr[e];
                }
                count += (rightMaxIndex - leftMaxIndex + 1) * height - subCount;

                if (rightMaxIndex == arr.Length - 1)
                    return count;
                i = rightMaxIndex-1;
            }
            return count;
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
    }
}
