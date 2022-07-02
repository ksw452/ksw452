using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ObjectFlag myflag;
    public bool selected;
    public void ChangeItem()
    {
        
        for (int i = 0; i < GameManager2.Items.Count; i++)
        {
            GameManager2.Items[i].GetComponent<Item>().selected = false;
            
        }

        if (GameManager2.selectedItem != null)
        {
            
            ObjectPool.Instance.Set(GameManager2.selectedItem, GameManager2.selectedItem.GetComponent<Item>().myflag);
            GameManager2.selectedItem = null;
        }


    }
    public  void SelectItem()
    {

    

        if (!this.transform.GetChild(0).gameObject.activeSelf)
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
            GameManager2.selectItem = true;

            GameManager2.selectedItem = new GameObject();

            GameManager2.selectedItem = ObjectPool.Instance.get(myflag);
            GameManager2.selectedItem.transform.SetParent(this.transform.parent.parent.parent.parent.GetChild(3));
            GameManager2.selectedItem.transform.localPosition = Vector3.zero;
          selected = true;
        }
        else
        {
           
            GameManager2.selectItem = false;
            selected = false;


            this.transform.GetChild(0).gameObject.SetActive(false);
        }

        


    }

    private void Update()
    {
        if (!selected)
        {
            this.transform.GetChild(0).gameObject.SetActive(false);

        }


    }


}
