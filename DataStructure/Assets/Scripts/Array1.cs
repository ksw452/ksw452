using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Array1 : MonoBehaviour
{
    List<int> data = new List<int>();
    void set(int num)
    {
        data.Add(num);
  
    }

    int Get()
    {
        int returnValue = data[0];
        data.RemoveAt(0);
        return returnValue;
    
    }
    int LastGet()
    {
        int returnValue = data[data.Count - 1];
        data.RemoveAt(data.Count - 1);
        return returnValue;

    }
    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < 5; i++)
        {

            set(i);

        }

        for (int i = 0; i < 5; i++)
        {

           Debug.Log(LastGet());
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
