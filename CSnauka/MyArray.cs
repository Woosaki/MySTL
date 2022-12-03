using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySTL
{
    internal class MyArray
    {
        public int length;
        private object[] data;
        
        public MyArray()
        {
            length = 0;
            data = new object[1];
        }
        
        public object Get(int index)
        {
            return data[index];
        }
        
        public object[] Push(object item)
        {
            if(data.Length == length)
            {
                object[] temp = new object[length];
                Array.Copy(data, temp, length);
                data = new object[length+ 1];
                Array.Copy(temp, data, length);
            }
            data[length] = item;
            length++;
            return data;
        }
        
        public object Pop()
        {
            var lastItem = data[length - 1];
            data[length - 1] = null;
            length--;
            return lastItem;
        }
        
        public object Delete(int index)
        {
            var item = data[index];
            ShiftItems(index);
            return item;
        }
        
        private void ShiftItems(int index)
        {
            for (int i = index; i < length - 1; i++)
            {
                data[i] = data[i + 1];
            }
            data[length - 1] = null;
            length--;
        }
    }
}
