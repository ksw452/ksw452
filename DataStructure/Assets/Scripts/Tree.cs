using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TreeNode<T>
{
    public int Data { get; set; }
    public TreeNode<T> Left { get; set; }
    public TreeNode<T> Right { get; set; }

    public TreeNode(int data)
    {
        Data = data;
    }
}

public class Tree <T>
{



    public TreeNode<T> Root;

    public void PrintAll(TreeNode<T> start)
    {
        if (start == null)
            return;

        Debug.Log(start.Data);
        PrintAll(start.Left);
        PrintAll(start.Right);
    
    }

    public void Add(int num)
    {
        TreeNode<T> uNum = Root;

        while (true)
        {
            if (uNum != null)
            {
                if (uNum.Data > num)
                {
                    if (uNum.Left == null)
                    {
                        uNum.Left = new TreeNode<T>(num);
                        uNum.Left.Data = num;
                        break;
                    }
                    else
                    {
                        uNum = uNum.Left;
                    }
                }
                else
                {
                    if (uNum.Right == null)
                    {
                        uNum.Right = new TreeNode<T>(num);
                        uNum.Right.Data = num;
                        break;
                    }
                    else
                    {
                        uNum = uNum.Right;
                    }


                }
            }
        }
    
    }


}
