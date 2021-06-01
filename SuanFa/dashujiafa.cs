using System;
using System.Collections.Generic;
using System.Text;

namespace SuanFa
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace ConsoleApplication1
    {
        class BigNumberAdd
        {
            static void Test(string[] args)
            {
                Console.WriteLine("please input a number");
                string oneNum = Console.ReadLine();
                Console.WriteLine("please input another number");
                string twoNum = Console.ReadLine();

                string result = BigNumAdd(oneNum, twoNum);
                Console.WriteLine(result);
            }

            static string BigNumAdd(string a, string b)
            {
                int k = 0;
                List<int> array = new List<int>();
                List<int> one = new List<int>();
                List<int> two = new List<int>();

                //将两个数处理成相同长度的字符串，短的小的数字前面补0
                for (int i = 0; i < (a.Length > b.Length ? a.Length : b.Length); i++)
                {
                    if (i >= a.Length)
                        one.Insert(i - a.Length, 0);
                    else
                        one.Add(int.Parse(a[i].ToString()));
                    if (i >= b.Length)
                        two.Insert(i - b.Length, 0);
                    else
                        two.Add(int.Parse(b[i].ToString()));
                }

                //array集合用于存储相加的和，所以长度最大也只会比最大的数长度长1，刚开始全部存0
                for (int i = 0; i <= (a.Length > b.Length ? a.Length : b.Length); i++)
                {
                    array.Add(0);
                }

                //从低位往高位每位开始相加，如果相加 >=10 则进1取余
                for (int i = (a.Length > b.Length ? a.Length : b.Length) - 1; i >= 0; i--)
                {
                    array[i + 1] += (one[i] + two[i]) % 10;
                    k = (one[i] + two[i]) / 10;

                    array[i] += k;
                }

                //如果首位为0，则移除
                if (array[0] == 0)
                {
                    array.RemoveAt(0);
                }

                //将集合转换成字符串返回
                StringBuilder result = new StringBuilder();
                for (int i = 0; i < array.Count; i++)
                {
                    result.Append(array[i]);
                }
                return result.ToString();
            }
        }
    }
}
