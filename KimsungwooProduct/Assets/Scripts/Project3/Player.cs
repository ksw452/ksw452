using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    LayerMask lm;

    IEnumerator AttackTime()
    {
        yield return new WaitForSeconds(1f);
        attack = false;
    }
    private void OnEnable()
    {
        attack = false;
    }

    bool attack;
    // Update is called once per frame
    void Update()
    {
      Collider[] enemyC =  Physics.OverlapSphere(this.transform.position,2f,lm);

        if (enemyC.Length > 0&&!attack)
        {
            enemyC[0].GetComponent<Enemy>().hp -= 1;
            attack = true;
            StartCoroutine(AttackTime());
        }
    }
}
