using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager3 : MonoBehaviour
{
    [SerializeField]
    GameObject[] enemys;

    public void EnemyEnable()
    {
        for (int i = 0; i < enemys.Length; i++)
        {
            enemys[i].gameObject.SetActive(true);

        }
    }

}
