using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class HashTable <T> 
{
    // 길이 설정 안하면 자동으로 길이 16
    private const int HASH_TABLE_SIZE = 16;

    // 이 테이블의 총 길이
    private int hashTableSize;

    private Node[] buckets;

    //private int[,] dupli;
    bool oneTime;
    private int count =0 ;
    public class Node
    {
        // 해시 테이블 키
        public string key;
        public T item;
        public int next;
        
    }
    // 링크드 리스트를 배열로 만듦
    //private LinkedList<T>[] buckets;
    public HashTable(int size)
    { 
        hashTableSize = size;    
        //    //buckets = new LinkedList<T>[hashTableSize];
        buckets = new Node[hashTableSize];
        //    //dupli = new int[hashTableSize, hashTableSize];
    }

    // 길이 작성 안했을 때
    public HashTable()
    {
        hashTableSize = HASH_TABLE_SIZE;
        //    //buckets = new LinkedList<T>[hashTableSize];
        buckets = new Node[hashTableSize];
        //    //dupli = new int[hashTableSize, hashTableSize];
    }

    private int GetHashCode(string key)
    {
       
        return Mathf.Abs(key.GetHashCode() % hashTableSize);
    }

    public void Put(string key, T value)
    {
        
        int index = GetHashCode(key);

        count++;

        if (count > hashTableSize)
        {
            throw new IndexOutOfRangeException("크기를 넘어서다");
        }
        if (buckets[index] == null)
        {
            buckets[index] = new Node();
            buckets[index].item = value;
            buckets[index].key = key;
        }
        else
        {
            for (int i = index; i < hashTableSize; i++)
            {

                if (buckets[i] == null)
                {
                    buckets[index].next = i;
                    buckets[i] = new Node();
                    buckets[i].item = value;
                    buckets[i].key = key;
                    break;
                }
                if (i == hashTableSize - 1 && oneTime ==false)
                {
                    i = 0;
                    oneTime = true;
                }

            }
            //for (int i = 0; i < length; i++)
            //{
            //}
            //mid.nextLocation = ;
        }
        //else
        //{
            
        //    for (int i = 0; i < hashTableSize; i++)
        //    {
        //        if (mid.next == null)
        //        {
        //            mid.next = new LinkedList<T>.Node();
        //            mid.next.item = value;
        //            mid.next.key = key;

        //            for (int j = 0; j < hashTableSize; j++)
        //            {
        //                object bValue = buckets[j];

                        
        //                if ((int)bValue == 0)
        //                {
        //                    mid.next.realLocation = j;
        //                    buckets[j] = value;

        //                }
        //            }
        //        }
        //        else
        //        {
        //            mid = mid.next;
        //        }
        //    }
        //}
        //if (dupli[index,index] == 0)
        //{  
        //    buckets[index] = value;
        //    dupli[index, index] = key.GetHashCode();
        //}
        //else
        //{
        //    for (int i = 0; i < dupli.GetLength(1); i++)
        //    {
        //        if (dupli[index,i] == 0 && dupli[i,i]==0)
        //        {

        //            buckets[i] = value;

        //            dupli[index, i] = key.GetHashCode();

        //            dupli[i, i] = key.GetHashCode();
        //            break;
        //        }

        //    }

        //}

        //if (buckets[index] == null)
        //{
        //    buckets[index] = new LinkedList<T>();
        //}
        //buckets[index].Set(key,value);
    }
        // 키 값으로부터 벨류값 가져오기 

        public T Get(string key)
    {     
        int index = GetHashCode(key);

        while (true)
        {
            if (buckets[index].key == key)
            {
                return buckets[index].item;
            }
            else
            {
                index = buckets[index].next;

                if (buckets[index] == null)
                    break;
            }
        }
        throw new IndexOutOfRangeException("값을 찾지 못함");
        //for (int i = 0; i < dupli.GetLength(1); i++)
        //{
        //    if (dupli[index, i] == key.GetHashCode())
        //    {
        //        return buckets[i];

        //    }
        //}
        //return buckets[index];

        //for (int i = 0; i < buckets[index].Count; i++)
        //{
        //    if (buckets[index].GetNode(i).key == key)
        //        return buckets[index].GetValue(i);
        //}
        //return buckets[index].GetValue(0);
    }
}
