using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject canvas;
    GameObject[] coin;

    [SerializeField]
    Text sumValue;

    public static int value;

    public static GameObject target;

    IEnumerator CreateCoins(Vector3 coinPos)
    {
        for (int i = 0; i < 5; i++)
        {
           


            yield return new WaitForSeconds(0.1f);
        

            coin[i] = ObjectPool.Instance.get(ObjectFlag.Coin);
            
            coin[i].transform.SetParent(canvas.transform);

        
            coin[i].transform.GetChild(0).GetChild(0).GetComponent<Text>().text = Random.Range(1, 11).ToString();
            Vector3 coinRot = Vector3.forward * Random.Range(-90, 90);
            coin[i].transform.eulerAngles = coinRot;
            coin[i].transform.position = coinPos;
       }
    }




    


    // Start is called before the first frame update
    void Start()
    {
        value = 0;
        target = GameObject.Find("Target");
        coin = new GameObject[6];


     


    }

    private void Update()
    {
        sumValue.text = value.ToString();

        if (Input.GetMouseButtonDown(0))
        {

        
          StartCoroutine( CreateCoins(Input.mousePosition));

        }


    }
}
