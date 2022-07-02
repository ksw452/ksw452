using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Potion : MonoBehaviour
{
    public void UsePotion()
    {
        potionNum -= 1;

    }


    public ObjectFlag myflag;
    public int potionNum = 1;

    private void Update()
    {

        if (potionNum < 1)
        {
            ObjectPool.Instance.Set(this.gameObject, myflag);

        }

        this.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = potionNum.ToString();



    }
}
