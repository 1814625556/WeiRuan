using System;
using System.Collections.Generic;
using System.Text;

namespace SuanFa
{
    public class TanXin
    {
        /// <summary>
        /// 问题描述:
        /// 找给顾客sum_money=41分钱，可选择的是25 分、10 分、5 分和 1 分四种硬币
        /// </summary>
        public static void ZhaoLingQian(int number)
        {
            if (number <= 0) return;
            var coin25 = 25;
            var coin10 = 10;
            var coin5 = 5;
            var coin1 = 1;
            var count25 = 0;
            var count10 = 0;
            var count5 = 0; 
            var count1=0;
            while (number >= 25) { number -= coin25;count25++; };
            while (number >= 10) { number -= coin10;count10++; };
            while (number >= 5) { number -= coin5;count5++; };
            while (number >= 1) { number -= coin1; count1++; };

            Console.WriteLine($"coin25:{count25},count10:{count10},count5:{count5},count1:{count1}");
        }
    }
}
