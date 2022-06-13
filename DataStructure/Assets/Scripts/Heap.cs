using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Heap  : MonoBehaviour
{
    protected int[] data = {6,5,3,2,1,0,7 };

    public TreeNode<int> Root;


    private List<TreeNode<int>> checkNode = new List<TreeNode<int>>();
    List<TreeNode<int>> newCheckNode = new List<TreeNode<int>>();
    List<TreeNode<int>> MaxCheckNode = new List<TreeNode<int>>();
    public class TreeNode<T>
    {
        public int Data { get; set; }
        public bool check= false;
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }

        public TreeNode(int data)
        {
            Data = data;
        }
    }

    public IEnumerator PrintAll(TreeNode<int> start)
    {
        if (start == null)
            yield break;

        Debug.Log(start.Data);
        yield return new WaitForSeconds(1f);
       StartCoroutine(PrintAll(start.Left));
        StartCoroutine(PrintAll(start.Right));

    }

    public void Add(int num)
    {
        for (int i = 0; i < checkNode.Count; i++)
        {

        
            if (checkNode[i] != null)
            {

                if (checkNode[i].Left == null)
                {
                    checkNode[i].Left = new TreeNode<int>(num);
                    checkNode[i].Left.Data = num;
                    newCheckNode.Add(checkNode[i].Left);
                    MaxCheckNode.Add(checkNode[i].Left);
                    break;
                }
             


                if (checkNode[i].Right == null)
                {

                    checkNode[i].Right = new TreeNode<int>(num);
                    checkNode[i].Right.Data = num;
                    newCheckNode.Add(checkNode[i].Right);
                    MaxCheckNode.Add(checkNode[i].Right);
                    if (i == checkNode.Count - 1)
                    {
                        checkNode = newCheckNode.ToList();
                        newCheckNode = new List<TreeNode<int>>();
                      
                    }
                    break;
                }
             
            }
        }

    }



    public void MaxHeap(TreeNode<int> uNum)
    {

        TreeNode<int> maxNum = uNum;

        List<int> resultHeap = new List<int>();


        while (true)
        {
        
       
            for (int i = 0; i < MaxCheckNode.Count; i++)
            {
               

                if (MaxCheckNode[i] != null)
                {

                   
                        if (MaxCheckNode[i].Data > maxNum.Data)
                        {
                           
                            maxNum = MaxCheckNode[i];
                          
                        }
                        else
                        {
                            continue;
                        }


            }
            }
     

            if (resultHeap.Contains(maxNum.Data))
            {
               
                break;
            }
          
            resultHeap.Add(maxNum.Data);
         


            if (MaxCheckNode[MaxCheckNode.Count - 1] != null)
            {
                if (maxNum.Data != MaxCheckNode[MaxCheckNode.Count - 1].Data)
                {
       
                    maxNum.Data = MaxCheckNode[MaxCheckNode.Count - 1].Data;

                    MaxCheckNode.RemoveAt(MaxCheckNode.Count - 1);
                }
                else
                {
             
                    MaxCheckNode.RemoveAt(MaxCheckNode.Count - 1);
                    if(MaxCheckNode.Count > 0)
                    maxNum = MaxCheckNode[0];
                    

                }
            }
          
      
         
        }
      

        for (int i = 0; i < resultHeap.Count; i++)
        {
            Debug.Log(resultHeap[i]);
        }
    }


    // Start is called before the first frame update
    void Start()
    {


        Root = new TreeNode<int>(data[0]);
        checkNode.Add(Root);
        MaxCheckNode.Add(Root);
 
      

        for (int i = 1; i < data.Length; i++)
        {
            Add(data[i]);
        }


        //StartCoroutine(PrintAll(Root));

        MaxHeap(Root);

      

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
