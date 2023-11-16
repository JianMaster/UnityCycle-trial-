using System;
using System.Collections;
using System.Collections.Generic;

namespace Client
{
    public class MySortedDictionary<T1, T2> : IEnumerable<KeyValuePair<T1,T2>>

    {
        List<T1> list;
        Dictionary<T1, T2> dic;
        int rehashLimit;
        int count;

        public MySortedDictionary(int rehashLimit = 10)
        {
            list = new List<T1>();
            dic = new Dictionary<T1, T2>();
            this.rehashLimit = rehashLimit;
        }

        public void Add(T1 key, T2 value){
            if(dic.ContainsKey(key)){
                Console.WriteLine("键值已存在！");
                return;
            }
            Rehash();
            dic.Add(key, value);
            list.Add(key);
            ++count;
        }
        public void Remove(T1 key){
            dic.Remove(key);
            --count;
        }

        public bool TryGetValue(T1 key, out T2 value){
            if(dic.ContainsKey(key)){
                value = dic[key];
                return true;
            }
            value = default;
            return false;
        }

        private void Rehash(){
            if(list.Count < rehashLimit || count > list.Count/2){
                return;
            }
            List<T1> newlist = new List<T1>();
            foreach(var key in list){
                if(dic.ContainsKey(key)){
                    newlist.Add(key);
                }
            }
            list = newlist;
        }

        public IEnumerator<KeyValuePair<T1,T2>> GetEnumerator()
        {
            foreach(var obj in list){
                if (dic.ContainsKey(obj))
                {
                    yield return new KeyValuePair<T1, T2>(obj, dic[obj]);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T2 this[T1 key]{
            get{
                return dic[key];
            }
            set {
                dic[key] = value;
            }
        }
    }
}