using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum ObjectFlag
{
    Coin,
    Potion,
    Item1,
    Item2,
    Item3,
    Item4


}



public class ObjectPool : MonoBehaviour
{


    
    public static ObjectPool Instance;
    public int[] initCount;
    public List<Queue<GameObject>> queList = new List<Queue<GameObject>>();

    public GameObject[] cpyObject;


    private void init(int count, GameObject gb, int flag)
    {

        for (int i = 0; i < count; i++)
        {

            GameObject tempGB = GameObject.Instantiate(gb, this.transform);
            tempGB.gameObject.SetActive(false);
            queList[flag].Enqueue(tempGB);
        }

    }

    public GameObject get(ObjectFlag flag)
    {

        int index = (int)flag;

        GameObject tempGB;
        if (queList[index].Count > 0)
        {

            tempGB = queList[index].Dequeue();

            tempGB.transform.SetParent(null);
            tempGB.SetActive(true);




        }
        else
        {
            tempGB = GameObject.Instantiate(cpyObject[index], this.transform);
            
        }
        return tempGB;

    }

   


    public void Set(GameObject gb, ObjectFlag flag)
    {
        int index = (int)flag;
        gb.gameObject.SetActive(false);
        gb.transform.SetParent(this.transform);
        queList[index].Enqueue(gb);

    }






    void Awake()
    {
        Instance = this;

        for (int i = 0; i < cpyObject.Length; i++)
        {
            queList.Add(new Queue<GameObject>());

            init(initCount[i], cpyObject[i], i);
        }

    }

  
}
