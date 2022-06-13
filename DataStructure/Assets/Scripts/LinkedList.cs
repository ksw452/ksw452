using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LinkedList <T> // where T : struct( = ��), class (= ����)
{

    public class Node 
    {
        // �ؽ� ���̺� Ű
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
         //return defalut(T); ���� 0 , ������ null
         // T? a;  or int? a; float? a; �� ?�� null�� ������ �ڷ����� null�� ����ϰ���
            throw new IndexOutOfRangeException("������ ���.");

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
            //return defalut(T); ���� 0 , ������ null
            // T? a;  or int? a; float? a; �� ?�� null�� ������ �ڷ����� null�� ����ϰ���
            throw new IndexOutOfRangeException("������ ���.");

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

            throw new IndexOutOfRangeException("������ ���.");
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

    // 2 ���� (�ε���)
    public T Remove(int index)
    {
        T result =default(T);
        Node mid = new Node();
        mid = head;

        if (Count <= index || index < 0)
        {
            throw new IndexOutOfRangeException("������ ���.");
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

    //3 ����

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
    //4 �� ����Ʈ�� �̿��ؼ� ť�� ���� ����
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

        //    throw new IndexOutOfRangeException("������ ���.");
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



    //5 ����� ����Ʈ ����
    // node �ǵ��̱�
    // next�� �����Ѵٸ� -> �� ���� ���
    // pre ���� ��带 ����






    //6 C++�� ����


}
