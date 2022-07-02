using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Coin : MonoBehaviour
{

    bool forwards;
    IEnumerator ChangeTarget()
    {

        yield return new WaitForSeconds(0.1f);

        forwards = true;
    
    }

    private void OnEnable()
    {
        forwards = false;
        StartCoroutine(ChangeTarget());
    }


    // Update is called once per frame
    void Update()
    {

      
    

        if (!forwards)
        {

            this.transform.Translate(Vector3.up * Time.deltaTime * 500);
        }
        else
        {

         
         
                Vector3 tempPos = (GameManager.target.transform.position - this.transform.position).normalized;


                Vector3 sumPos = Vector3.Slerp(tempPos, this.transform.up, 0.99f);

                this.transform.up = sumPos;
                this.transform.Translate(Vector3.up * Time.deltaTime * 500);

            

        }


        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           
           ObjectPool.Instance.Set(this.gameObject, ObjectFlag.Coin);
            GameManager.value += int.Parse(this.transform.GetChild(0).GetChild(0).GetComponent<Text>().text);

        }

    }



}
