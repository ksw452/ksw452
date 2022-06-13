using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LinkedList <T> // where T : struct( = 값), class (= 참조)
{

    public class Node 
    {
        // 해시 테이블 키
        public string key;
        public  T item;
        public Node next;
        public Node pre;
        public int nextLocation;
        
    }

    public Node head =null;
    public Node tail = null;

    public int Count { get; private set; }

  

    public void Set(T value)
    {
        if (Count == 0)
        {
            head = new Node();
            head.item = value;
        }
        else 
        {

            Node mid = new Node();

            mid = head;
            for (int i = 0; i < Count-1; i++)
            {
                mid = mid.next;
            }
            mid.next = new Node();
            mid.next.pre = mid;
            mid.next.item = value;
        
        }
        Count++;
    }
    public void Set(string key,T value)
    {
        if (Count == 0)
        {
            head = new Node();
            head.item = value;
            head.key = key;
        }
        else
        {

            Node mid = new Node();

            mid = head;
            for (int i = 0; i < Count - 1; i++)
            {
                mid = mid.next;
            }
            mid.next = new Node();
            mid.next.key = key;
            mid.next.pre = mid;
            mid.next.item = value;

        }
        Count++;
    }

    public T GetValue(int idx)
    {




        if (Count <= idx)
         //return defalut(T); 값은 0 , 참조는 null
         // T? a;  or int? a; float? a; 의 ?는 null값 못쓰는 자료형에 null값 허용하게함
            throw new IndexOutOfRangeException("범위를 벗어남.");

        else
        {
            Node mid = new Node();
            mid = head;
            for (int i = 0; i < idx; i++)
            {
                mid = mid.next;

            }
            return mid.item;

        }
    
    }
    public Node GetNode(int idx)
    {




        if (Count <= idx)
            //return defalut(T); 값은 0 , 참조는 null
            // T? a;  or int? a; float? a; 의 ?는 null값 못쓰는 자료형에 null값 허용하게함
            throw new IndexOutOfRangeException("범위를 벗어남.");

        else
        {
            Node mid = new Node();
            mid = head;
            for (int i = 0; i < idx; i++)
            {
                mid = mid.next;

            }
          

   
                return mid;
            

        }

    }

    public void PrintAll()
    {
        Node mid = new Node();
        mid = head;
        for (int i = 0; i < Count; i++)
        {
            Debug.Log(mid.item);
            mid = mid.next;
            

        }


    }

    public T RemoveLast()
    {
        T result;

        if (Count == 1)
        {
            result = head.item;
            head = null;

        }
        else if (Count < 1)
        {

            throw new IndexOutOfRangeException("범위를 벗어남.");
        }
        else
        {


            Node mid = new Node();
            mid = head;
            for (int i = 0; i < Count - 2; i++)
            {
                mid = mid.next;

            }
            result = mid.next.item;
            mid.next = null;
        }
        Count--;

        return result;


    }

    // 2 삭제 (인덱스)
    public T Remove(int index)
    {
        T result =default(T);
        Node mid = new Node();
        mid = head;

        if (Count <= index || index < 0)
        {
            throw new IndexOutOfRangeException("범위를 벗어남.");
        }
        else
        {

            if (index == 0)
            {
                result = head.item;
                head = mid.next;

            }
            else if (index < Count - 1)
            {
                for (int i = 0; i < index; i++)
                {
                    if (i == index - 1)
                    {
                        result = mid.next.item;
                        mid.next = mid.next.next;
                    }
                }
            }
            else { 
                result = RemoveLast();
                Count++;
                }
            }
        
        Count--;
        return result;
    }

    //3 삽입

    public void Insert(int index,T value)
    {

        if (Count == 0)
        {
            head = new Node();
            head.item = value;
        }
        else
        {

                Node mid = new Node();
            if (index == 0)
            {
                mid.item = value;
                mid.next = head;
                head.pre = mid;
                head = mid;
            }
            else 
            { 
            Node temp = new Node();
                temp.item = value;
           

                mid = head;
                for (int i = 0; i < index; i++)
                {
                    if (i == index-1)
                    {
                        
                        temp.next = mid.next;
                        mid.next = temp;
                        temp.pre = mid;
                    }
                    else
                    {
                        mid = mid.next;
                    }
                }
            }
        }
        Count++;

    }
    //4 이 리스트를 이용해서 큐와 스택 구현
    public void Enqueue(T value)
    {
        if (Count == 0)
        {
            head = new Node();
            head.item = value;
        }
        else
        {
            Node mid = new Node();
            mid.item = value;
            mid.next = head;

            head = mid;

        }

        Count++;

    }
    public T Dequeue()
    {

        return Remove(Count-1);

        //Node mid = new Node();
        //if (Count == 1)
        //{         
        //    mid = head;
        //    head = null;
        //}
        //else if (Count < 1)
        //{

        //    throw new IndexOutOfRangeException("범위를 벗어남.");
        //}
        //else
        //{
        //    T result;
        //    mid = head;
        //    for (int i = 0; i < Count - 2; i++)
        //    {
        //        mid = mid.next;

        //    }
        //    result = mid.next.item;
        //    mid.next = null;
        //    Count--;
        //    return result;
        //}

        //Count--;
        //return mid.item;


    }
    public void Push(T value)
    {

        Insert(Count, value);

    }
    public T Pop()
    {
       return RemoveLast();
    }



    //5 양방향 리스트 구현
    // node 건들이기
    // next가 존재한다면 -> 그 다음 노드
    // pre 이전 노드를 향함






    //6 C++로 구현


}
