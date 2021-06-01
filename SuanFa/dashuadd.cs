using System;
using System.Collections.Generic;
using System.Text;

namespace SuanFa
{
    public class dashuadd
    {
        public static string Add(string num1, string num2)
        {
            var arr1 = num1.ToCharArray();
            var arr2 = num2.ToCharArray();

            var flag = arr1.Length > arr2.Length;
            var length = flag ? arr1.Length : arr2.Length;
            if (flag)
            {
                arr2 = new char[length];
                var sub = num1.Length - num2.Length;
                for (var i = 0; i < length; i++)
                {
                    if (i < sub)
                        arr2[i] = '0';
                    else
                        arr2[i] = num2.ToCharArray()[i - sub];
                }
            }
            else
            {
                arr1 = new char[length];
                var sub = num2.Length - num1.Length;
                for (var i = 0; i < length; i++)
                {
                    if (i < sub)
                        arr1[i] = '0';
                    else
                        arr1[i] = num1.ToCharArray()[i - sub];
                }
            }

            var sumArr = new Char[length + 1];
            var isAddOne = false;
            for (var i = length - 1; i >= -1; i--)
            {
                if (i == -1)
                {
                    if (isAddOne)
                        sumArr[i + 1] = '1';
                }
                else
                {
                    var sumi = int.Parse(arr1[i].ToString()) +
                        int.Parse(arr2[i].ToString()) + (isAddOne ? 1 : 0);

                    isAddOne = sumi > 9;
                    if (isAddOne)
                    {
                        sumArr[i + 1] = sumi.ToString().ToCharArray()[1];
                    }
                    else
                    {
                        sumArr[i + 1] = sumi.ToString().ToCharArray()[0];
                    }
                }
            }

            var sum = sumArr.ToString();
            return sumArr.ToString();
        }
    }
}
