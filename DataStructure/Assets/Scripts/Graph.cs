using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GraphNode<T>
{


    private List<GraphNode<T>> neighbors;
    private List<int> weights;

    public T Data { get; set; }

    public GraphNode(T data)
    {
        Data = data;

    }

    public List<GraphNode<T>> Neighbors
    { 
            get {
            if (neighbors == null)
            { 
                neighbors = new List<GraphNode<T>>();
            }
            
            
            return neighbors; }
    }
    public List<int> Weights
    {
        get {
            if (weights == null)
            {
                weights = new List<int>();
            }
            return weights; }
    }

}
public class Graph<T>
{
    //�׷����� ������ �ִ� ���
    private List<GraphNode<T>> nodeList;

    public Graph()
    {

        nodeList = new List<GraphNode<T>>();

    }

    //��� �߰�
    public GraphNode<T> AddNode(T data)
    {
        GraphNode<T> n = new GraphNode<T>(data);
        nodeList.Add(n);
        return n;



    }

    //��� �̾��ֱ�
    public void AddLine(GraphNode<T> start, GraphNode<T> end)
    {

        start.Neighbors.Add(end);
        start.Weights.Add(1);

    }
    public void AddLine(GraphNode<T> start, GraphNode<T> end, int weight)
    {

        start.Neighbors.Add(end);
        start.Weights.Add(weight);

    }

    //��ü Ž���ؼ� �� ã��

    List<GraphNode<T>> findNode = new List<GraphNode<T>>(); // ToArray()�� ����Ʈ�� �迭�� �������



    private bool check;

    public void FindNode(GraphNode<T> start, GraphNode<T> end)
    {
        if (start == end)
        {
            Debug.Log("��� : " + start.Data + " -> " + end.Data);
            return;
        }
        //��� �߰�
        findNode.Add(start);
        
        //����� �̿��� ���� ���
        if (start.Neighbors.Count > 0)
        {
            //�̿� ���� Ȯ��
            foreach (GraphNode<T> node in start.Neighbors)
            {
                for (int i = 0; i < findNode.Count; i++)
                { //�̿� ��尡 ���� Ž����� ��� �߿� �������� Ȯ��
                    if (node.Data.Equals(findNode[i].Data))
                    {
                        check = true;
                    }
                }
                 //���� Ž����ο� ������ ���� ������ ���� ���� �Ѿ��
                if (!check)
                {
                    //��尡 ������ ����� ���
                    if (node.Data.Equals(end.Data))
                    {   //Ž����ο� �� ��� �߰�
                        findNode.Add(node);

                      
                        string result = "";
                        for (int i = 0; i < findNode.Count; i++)
                        {
                            if (i == findNode.Count - 1)
                                result += findNode[i].Data.ToString();
                            else
                            {
                                result += findNode[i].Data.ToString() + " -> ";
                            }
                        }

                        Debug.Log("��� : " +result);
                        //Debug.Log("�� ����ġ : " + sum);

                        // ���� �� Ž���� ���� �� ��� ���� �� ��ĭ ȸ��
                        findNode.RemoveAt(findNode.Count - 1);
                        //findNode = new List<string>();

                    }
                    else
                    {  //��尡 �������� �ƴ� ��� �� ����� �̿� �˻�
                        FindNode(node, end);
                    }
                }
                else
                {
                    check = false;
                }
            } 
        } //����� �̿��� ���� ��쳪  �̿���� �� �˻� �� ���� ��� ������ ���ư��� ���� ����
        findNode.RemoveAt(findNode.Count - 1);
    }


    List<GraphNode<T>> findMinNode;
    int minWeight = 0;
   

   


    public void FindMinNode(GraphNode<T> start, GraphNode<T> end)
    {
        if (start == end)
        {
            Debug.Log("��� : "+start.Data + " -> " + end.Data + ", ����ġ : 0");
            return;
        }
        //��� �߰�
        findNode.Add(start);
        
        //����� �̿��� ���� ���
        if (start.Neighbors.Count > 0)
        {
            //�̿� ���� Ȯ��
            foreach (GraphNode<T> node in start.Neighbors)
            {
       
                //���� Ž����ο� ������ ���� ������ ���� ���� �Ѿ��
                if (!findNode.Contains(node))
                {
                    //��尡 ������ ����� ���
                    if (node.Data.Equals(end.Data))
                    {   //Ž����ο� �� ��� �߰�
                        findNode.Add(node);

                        int sum= 0;
                      
                        for (int i = 0; i < findNode.Count; i++)
                        {
                            if (i < findNode.Count - 1)
                            { 
                                //����ġ ����
                                for (int j = 0; j < findNode[i].Neighbors.Count; j++)
                                {

                                    if (findNode[i].Neighbors[j] == findNode[i + 1])
                                    { //������ ����ġ ���ϱ�
                                        sum += findNode[i].Weights[j];
                                    }

                                }
                            }
                        }
                        //����ġ�� �ּ� ����ġ ���� ���� ��� 
                        if (sum < minWeight ||  minWeight == 0)
                        {   //�ּ� ����ġ�� sum �� ����
                            minWeight = sum;

                            //findMinNode�� ���� ��� �� ����
                            findMinNode = findNode.ToList();
                            
                        }
                        // ���� �� Ž���� ���� �� ��� ���� �� ��ĭ ȸ��
                        findNode.RemoveAt(findNode.Count - 1);
                    }
                    else
                    {  //��尡 �������� �ƴ� ��� �� ����� �̿� �˻�
                        FindMinNode(node, end);
                       
                    }
                }
                else
                {
                    check = false;
                }
            }
        } //����� �̿��� ���� ��쳪  �̿���� �� �˻� �� ���� ��� ������ ���ư��� ���� ����
        findNode.RemoveAt(findNode.Count - 1);
        //�Լ��� ������ �ܰ�
        if (findNode.Count == 0)
        {   //�ƹ��� ��ΰ� ���� ���
            if (findMinNode== null)
            {
                Debug.Log("��� ����");
            }// ��� �ִ� ���
            else
            {
                //�ּҰ�� ���
                string result = "";
                for (int i = 0; i < findMinNode.Count; i++)
                {
                    if (i == findMinNode.Count - 1)
                        result += findMinNode[i].Data.ToString();
                    else
                    {
                        result += findMinNode[i].Data.ToString() + " -> ";
                    }
                }
                Debug.Log("�ּҰ�� : " + result + " , �ּ��̵� ���: " + minWeight);
                // �ּ� ����ġ �ʱ�ȭ
                minWeight = 0;
            }
        }
    }



    //��ü Ž�� �� ��ü ���

    public void PrintAll()
    {
        foreach (GraphNode<T> node in nodeList)
        {
            for (int i = 0; i < node.Neighbors.Count; i++)
            {
                Debug.Log(node.Data+" -> "+node.Neighbors[i].Data);
            }
          
        }
    } 



}
