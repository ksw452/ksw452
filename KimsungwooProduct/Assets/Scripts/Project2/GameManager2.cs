using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    public static bool selectItem;
    public static List<GameObject> Items;
    public static GameObject selectedItem;
    [SerializeField]
    GameObject itemParant;
    [SerializeField]
   
    public static GameObject potion;

    public void CreateItem()
    {
        float selectItemNum = Random.Range(1,101);
       
        if (selectItemNum <= 60)
        {
            if (potion == null)
            {
                potion = ObjectPool.Instance.get(ObjectFlag.Potion - 1);
                potion.GetComponent<Potion>().myflag = ObjectFlag.Potion - 1;
                potion.transform.SetParent(itemParant.transform);
            }
            else
            {
                potion.GetComponent<Potion>().potionNum += 1;
            }
        }
        else
        {
            GameObject item;
           if (selectItemNum <= 90)
            {
                item = ObjectPool.Instance.get(ObjectFlag.Item1 - 1);
                item.GetComponent<Item>().myflag = ObjectFlag.Item1 - 1;
            }
            else if (selectItemNum > 90 && selectItemNum <= 98)
            {
                item = ObjectPool.Instance.get(ObjectFlag.Item2 - 1);
                item.GetComponent<Item>().myflag = ObjectFlag.Item2 - 1;
            }
            else if (selectItemNum > 98 && selectItemNum <= 99.5f)
            {
                item = ObjectPool.Instance.get(ObjectFlag.Item3 - 1);
                item.GetComponent<Item>().myflag = ObjectFlag.Item3 - 1;
            }
            else
            {
                item = ObjectPool.Instance.get(ObjectFlag.Item4 - 1);
                item.GetComponent<Item>().myflag = ObjectFlag.Item4 - 1;
            }
            Items.Add(item);

            item.transform.SetParent(itemParant.transform);
        }

     

    }

   




    private void Start()
    {
        Items = new List<GameObject>();
    }




    private void Update()
    {
      


    }


}
