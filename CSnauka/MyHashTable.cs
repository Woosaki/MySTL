using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySTL
{
    internal class MyKeyValuePair
    {
        public string Key { get; set; }
        public int Value { get; set; }
        
        public MyKeyValuePair(string key, int value)
        {
            Key = key;
            Value = value;
        }
    }
    internal class MyHashTable
    {
        private class MyKeyValuePairs : List<MyKeyValuePair> { }
        private MyKeyValuePairs[] Data { get; set; }
        public int Length { get; private set; }
        
        public MyHashTable(int size)
        {
            Length = size;
            Data = new MyKeyValuePairs[size];
        }
        
        private int Hash(string key)
        {
            int hash = 0;
            
            for (int i = 0; i < key.Length; i++)
                hash = (hash + (int)key[i] * i) % Length;
            
            return hash;
        }
        
        public void Add(string key, int value)
        {
            int address = Hash(key);
            
            if (Data[address] == null)
                Data[address] = new MyKeyValuePairs();
            
            Data[address].Add(new MyKeyValuePair(key, value));
        }
        
        public int Get(string key) 
        { 
            int address = Hash(key);
            
            if (Data[address] == null)
                return 0;
            
            foreach (MyKeyValuePair node in Data[address])
                if(node.Key.Equals(key))
                    return node.Value;
            
            return 0;
        }
        
        public List<string> Keys()
        {
            var keysList = new List<string>();
            
            for (int i = 0; i < Length; i++)
                if (Data[i] != null)
                {
                    for (int j = 0; j < Data[i].Count; j++)
                        keysList.Add(Data[i][j].Key);
                }                 
            return keysList;
        }
    }
}
