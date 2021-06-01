using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace SuanFa
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    public static class Practice2
    {
        /// <summary>
        /// 整数转罗马数字
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string IntToRoman(int num)
        {
            StringBuilder sb = new StringBuilder();
            var count = 0;

            count = num / 1000;
            if ( count > 0)
            {
                for (var i = 0; i < count; i++)
                {
                    sb.Append("M");
                }
               num = num - 1000 * count;
            }

            if (num - 900>=0)
            {
                sb.Append("CM");
                num = num - 900;
            }

            if (num - 500 >= 0)
            {
                sb.Append("D");
                num = num - 500;
            }

            if (num - 400 >= 0)
            {
                sb.Append("CD");
                num = num - 400;
            }

            count = num / 100;
            if (count > 0)
            {
                for (var i = 0; i < count; i++)
                {
                    sb.Append("C");
                }
                num = num - 100 * count;
            }

            if (num - 90 >= 0)
            {
                sb.Append("XC");
                num = num - 90;
            }

            if (num - 50 >= 0)
            {
                sb.Append("L");
                num = num - 50;
            }

            if (num - 40 >= 0)
            {
                sb.Append("XL");
                num = num - 40;
            }

            count = num / 10;
            if (count > 0)
            {
                for(var i=0;i<count;i++)
                {
                    sb.Append("X");
                }
                num = num - 10 * count;
            }

            if (num - 9 >= 0)
            {
                sb.Append("IX");
                num = num - 9;
            }

            if (num - 5 >= 0)
            {
                sb.Append("V");
                num = num - 5;
            }

            if (num - 4 >= 0)
            {
                sb.Append("IV");
                num = num - 4;
            }

            count = num;
            if (count > 0)
            {
                for (var i = 0; i < count; i++)
                {
                    sb.Append("I");
                }
            }


            return sb.ToString();
        }

        /// <summary>
        /// K 个一组翻转链表
        /// </summary>
        /// <param name="head"></param>
        /// <param name="k"></param>
        public static ListNode ReverseKGroup(ListNode head, int k)
        {
            //获取元素个数
            var count = 0;
            var tempHead = head;
            var i = 0;
            while (tempHead != null)
            {
                count++;
                tempHead = tempHead.next;
            }
            if (k > count || count<=0) return head;

            //放进数组里面
            var arr = new int[count];
            tempHead = head;
            while (tempHead != null)
            {
                arr[i] = tempHead.val;
                tempHead = tempHead.next;
                i++;
            }

            //进行反转
            i = 1;
            while (k*i <= count)
            {
                // k*(i-1) --> k*i-1
                var begin = k * (i - 1);
                var end = k * i - 1;
                while (begin < end)
                {
                    var temp = arr[begin];
                    arr[begin] = arr[end];
                    arr[end] = temp;

                    begin++;
                    end--;
                }
                i++;
            }

            //组装链表
            i = 0;
            tempHead = head;
            while (tempHead != null)
            {
                tempHead.val = arr[i];
                i++;
                tempHead = tempHead.next;
            }

            return head;
        }
    }
}
