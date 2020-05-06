using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurtPlayer : MonoBehaviour
{
    private int damageToGive = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 hitDir = other.transform.position - transform.position;
            hitDir = hitDir.normalized;
            FindObjectOfType<HealthManager>().DamagePlayer(damageToGive, hitDir);
            //other.gameObject.GetComponent<HealthManager>();
        }
        else if (other.gameObject.tag == "Enemy")
        {
            Vector3 hitDir = other.transform.position - transform.position;
            hitDir = hitDir.normalized;
            //other.gameObject.GetComponent<EnemyController>().DamageEnemy(damageToGive, hitDir);
        }
    }

}
