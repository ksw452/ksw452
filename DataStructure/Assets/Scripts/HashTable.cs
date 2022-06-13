using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class HashTable <T> 
{
    // ���� ���� ���ϸ� �ڵ����� ���� 16
    private const int HASH_TABLE_SIZE = 16;

    // �� ���̺��� �� ����
    private int hashTableSize;

    private Node[] buckets;

    //private int[,] dupli;
    bool oneTime;
    private int count =0 ;
    public class Node
    {
        // �ؽ� ���̺� Ű
        public string key;
        public T item;
        public int next;
        
    }
    // ��ũ�� ����Ʈ�� �迭�� ����
    //private LinkedList<T>[] buckets;
    public HashTable(int size)
    { 
        hashTableSize = size;    
        //    //buckets = new LinkedList<T>[hashTableSize];
        buckets = new Node[hashTableSize];
        //    //dupli = new int[hashTableSize, hashTableSize];
    }

    // ���� �ۼ� ������ ��
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
            throw new IndexOutOfRangeException("ũ�⸦ �Ѿ��");
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
        // Ű �����κ��� ������ �������� 

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
        throw new IndexOutOfRangeException("���� ã�� ����");
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
