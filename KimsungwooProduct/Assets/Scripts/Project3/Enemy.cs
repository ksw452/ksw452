using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    [SerializeField]
    public int hp;
    [SerializeField]
    Slider hpSlider;

    [SerializeField]
    GameObject nextStage;


    private void OnEnable()
    {
        hp = int.Parse(hpSlider.maxValue.ToString());
        Vector3 enemyPos = Vector3.zero;
        int num = Random.Range(0, 4);

        Vector3 rPos = Camera.main.WorldToScreenPoint(player.transform.position);

       Vector3 SPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, rPos.z));
       
        switch (num)
        {
            case 0:
                {
                    enemyPos.y = 1;
                    enemyPos.z = SPos.z;
                    enemyPos.x = Random.Range(-SPos.x, SPos.x);
                }
                break;
            case 1:
                {
                    enemyPos.y = 1;
                    enemyPos.z = -SPos.z;
                    enemyPos.x = Random.Range(-SPos.x, SPos.x);
                }
                break;
            case 2:
                {
                    enemyPos.y = 1;
                    enemyPos.x = -SPos.x;
                    enemyPos.z = Random.Range(-SPos.z, SPos.z);
                }
                break;
            case 3:
                {
                    enemyPos.y = 1;
                    enemyPos.z = Random.Range(-SPos.z, SPos.z);
                }
                break;
        }



       
        this.transform.position = enemyPos;
        this.transform.LookAt(player.transform);

        NavMeshAgent agent = this.GetComponent<NavMeshAgent>();
        agent.SetDestination(player.transform.position);

    }

    private void Update()
    {
        hpSlider.value = hp;

        if (hp < 1)
        {
            this.gameObject.SetActive(false);
            this.transform.localPosition = Vector3.zero;
            bool next= false;
            for (int i = 0; i < this.transform.parent.childCount; i++)
            {
                if (this.transform.parent.GetChild(i).gameObject.activeSelf)
                {
                    next = true;
                    break;
                }

            }


            if (!next)
            {
                for (int i = 0; i < this.transform.parent.childCount; i++)
                {
                    this.transform.parent.GetChild(i).gameObject.SetActive(true);

                }
                nextStage.gameObject.SetActive(true);

                if (nextStage.name == "StartButton")
                {
                    player.SetActive(false);
                }
              
                  
               
                
                this.transform.parent.gameObject.SetActive(false);
              


            }
           
        }

    }


}
