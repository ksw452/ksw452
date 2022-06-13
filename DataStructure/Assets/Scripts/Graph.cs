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
    //그래프가 가지고 있는 노드
    private List<GraphNode<T>> nodeList;

    public Graph()
    {

        nodeList = new List<GraphNode<T>>();

    }

    //노드 추가
    public GraphNode<T> AddNode(T data)
    {
        GraphNode<T> n = new GraphNode<T>(data);
        nodeList.Add(n);
        return n;



    }

    //노드 이어주기
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

    //전체 탐색해서 길 찾기

    List<GraphNode<T>> findNode = new List<GraphNode<T>>(); // ToArray()는 리스트를 배열로 만들어줌



    private bool check;

    public void FindNode(GraphNode<T> start, GraphNode<T> end)
    {
        if (start == end)
        {
            Debug.Log("경로 : " + start.Data + " -> " + end.Data);
            return;
        }
        //노드 추가
        findNode.Add(start);
        
        //노드의 이웃이 있을 경우
        if (start.Neighbors.Count > 0)
        {
            //이웃 노드들 확인
            foreach (GraphNode<T> node in start.Neighbors)
            {
                for (int i = 0; i < findNode.Count; i++)
                { //이웃 노드가 현재 탐색경로 노드 중에 있으는지 확인
                    if (node.Data.Equals(findNode[i].Data))
                    {
                        check = true;
                    }
                }
                 //현재 탐색경로에 없으면 실행 있으면 다음 노드로 넘어가기
                if (!check)
                {
                    //노드가 목적지 노드일 경우
                    if (node.Data.Equals(end.Data))
                    {   //탐색경로에 끝 노드 추가
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

                        Debug.Log("경로 : " +result);
                        //Debug.Log("총 가중치 : " + sum);

                        // 다음 길 탐색을 위해 끝 노드 제거 후 한칸 회귀
                        findNode.RemoveAt(findNode.Count - 1);
                        //findNode = new List<string>();

                    }
                    else
                    {  //노드가 목적지가 아닐 경우 그 노드의 이웃 검색
                        FindNode(node, end);
                    }
                }
                else
                {
                    check = false;
                }
            } 
        } //노드의 이웃이 없는 경우나  이웃노드 다 검색 후 이전 노드 층으로 돌아가기 위해 제거
        findNode.RemoveAt(findNode.Count - 1);
    }


    List<GraphNode<T>> findMinNode;
    int minWeight = 0;
   

   


    public void FindMinNode(GraphNode<T> start, GraphNode<T> end)
    {
        if (start == end)
        {
            Debug.Log("경로 : "+start.Data + " -> " + end.Data + ", 가중치 : 0");
            return;
        }
        //노드 추가
        findNode.Add(start);
        
        //노드의 이웃이 있을 경우
        if (start.Neighbors.Count > 0)
        {
            //이웃 노드들 확인
            foreach (GraphNode<T> node in start.Neighbors)
            {
       
                //현재 탐색경로에 없으면 실행 있으면 다음 노드로 넘어가기
                if (!findNode.Contains(node))
                {
                    //노드가 목적지 노드일 경우
                    if (node.Data.Equals(end.Data))
                    {   //탐색경로에 끝 노드 추가
                        findNode.Add(node);

                        int sum= 0;
                      
                        for (int i = 0; i < findNode.Count; i++)
                        {
                            if (i < findNode.Count - 1)
                            { 
                                //가중치 연산
                                for (int j = 0; j < findNode[i].Neighbors.Count; j++)
                                {

                                    if (findNode[i].Neighbors[j] == findNode[i + 1])
                                    { //노드들의 가중치 합하기
                                        sum += findNode[i].Weights[j];
                                    }

                                }
                            }
                        }
                        //가중치가 최소 가중치 보다 작을 경우 
                        if (sum < minWeight ||  minWeight == 0)
                        {   //최소 가중치에 sum 값 저장
                            minWeight = sum;

                            //findMinNode에 현재 경로 값 저장
                            findMinNode = findNode.ToList();
                            
                        }
                        // 다음 길 탐색을 위해 끝 노드 제거 후 한칸 회귀
                        findNode.RemoveAt(findNode.Count - 1);
                    }
                    else
                    {  //노드가 목적지가 아닐 경우 그 노드의 이웃 검색
                        FindMinNode(node, end);
                       
                    }
                }
                else
                {
                    check = false;
                }
            }
        } //노드의 이웃이 없는 경우나  이웃노드 다 검색 후 이전 노드 층으로 돌아가기 위해 제거
        findNode.RemoveAt(findNode.Count - 1);
        //함수의 마지막 단계
        if (findNode.Count == 0)
        {   //아무런 경로가 없는 경우
            if (findMinNode== null)
            {
                Debug.Log("경로 없음");
            }// 경로 있는 경우
            else
            {
                //최소경로 출력
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
                Debug.Log("최소경로 : " + result + " , 최소이동 비용: " + minWeight);
                // 최소 가중치 초기화
                minWeight = 0;
            }
        }
    }



    //전체 탐색 후 전체 출력

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
