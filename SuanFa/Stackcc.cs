using System;
using System.Collections.Generic;
using System.Text;

namespace SuanFa
{
    //Stackcc<int> cc = new Stackcc<int>();
    //cc.Push(10);
    //        cc.Push(11);
    //        cc.Push(12);
    //        cc.Push(13);
    //        cc.Push(14);
    //        cc.Push(15);
    //        cc.Push(16);
    //        cc.Push(17);
    //        cc.Push(18);

    //        var count = cc.Count;

    //var entity = cc.Peek();
    //entity = cc.Pop();
    //        entity = cc.Pop();
    //        count = cc.Count;
    public class Stackcc<T>
    {
        //数组容量，初始可以容纳8个元素
        private int capacity = 8;

        T[] ts = null;

        //代表栈中的实际元素个数
        private int count;
        public Stackcc()
        {
            ts = new T[capacity];
            count = 0;
        }

        /// <summary>
        /// push操作将T对象放入数组
        /// </summary>
        /// <param name="entity"></param>
        public void Push(T entity)
        {
            count++;
            if (count >= capacity)
            {
                capacity = capacity * 2;
                var newts = new T[capacity];
                Array.Copy(ts, newts, count - 1);
                ts = newts;
            }
            ts[count - 1] = entity;
        }

        public T Pop()
        {
            if (count == 0) return default(T);
            var rs = ts[count - 1];
            count--;
            if (count < capacity / 2)
            {
                capacity = capacity / 2;
                var newts = new T[capacity];
                Array.Copy(ts, newts, count);
                ts = newts;
            }

            return rs;
        }

        public T Peek()
        {
            if (count == 0) return default(T);
            return ts[count - 1];
        }

        public int Count => count;
    }
}
