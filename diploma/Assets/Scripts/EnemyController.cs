using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.AI;
using UnityEditor;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    private float lookRadius = 100f;
    private float currentHealth;
    private float maxHealth = 100;
    private float costPoint = 50;
    private float damage = 10;
    public Transform target;
    NavMeshAgent agent;
    bool damaging;
    float damagetimer = 2f;
    public Canvas ph;
    Slider slider;
    public string type = "Goblin";
    public Material[] skins ;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentHealth = maxHealth;
        slider = GetComponentInChildren<Slider>();
        int type_id = Random.Range(0, 2);
        if (type_id == 1)
        {
            type = "HobGoblin";
            maxHealth = 200 * DBManager.diff_status;
            costPoint = 100 * DBManager.diff_status;
            damage = 10 * DBManager.diff_status;
            GetComponentInChildren<MeshRenderer>().material = skins[1];
        }
        else if (type_id == 2)
        {
            type = "HobGoblin+";
            maxHealth = 300 * DBManager.diff_status;
            costPoint = 150 * DBManager.diff_status;
            damage = 15 * DBManager.diff_status;
            GetComponentInChildren<MeshRenderer>().material = skins[2];

        }
        else if (tag=="Boss")
        {
            type = "Boss";
            maxHealth = 1000 * DBManager.diff_status;
            costPoint = 500 * DBManager.diff_status;
            damage = 25 * DBManager.diff_status;
            GetComponentInChildren<MeshRenderer>().material = skins[3];

        }
        else
        {
            type = "Goblin";
            maxHealth = 100 * DBManager.diff_status;
            costPoint = 50 * DBManager.diff_status;
            damage = 5 * DBManager.diff_status;
            GetComponentInChildren<MeshRenderer>().material = skins[0];

        }

    }

    // Update is called once per frame
    private void Update()
    {
        if (currentHealth <= 0)
        {
            ph.GetComponent<game>().IncreaseScore(50);
            Destroy(gameObject);
        }
        slider.value = currentHealth;
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
                if (damaging == false) { 
                    DoDamage();
                }
            }
        }
        if (damaging == true)
        {
            damagetimer -= Time.deltaTime;
            if (damagetimer <= 0f)
            {
                damaging = false;
            }
        }
    }
    void DoDamage()
    {
        damagetimer = 2f;
        damaging = true;
        Vector3 hitDir = target.transform.position - transform.position;
        hitDir = hitDir.normalized;
        ph.GetComponent<HealthManager>().DamagePlayer(damage, hitDir);

    }
    public void GetDamage( int amount)
    {
        if (amount > 0)
        {
            if (currentHealth > 0)
            {
                currentHealth -= amount;
                if (currentHealth <= 0)
                {
                    ph.GetComponent<game>().IncreaseScore(costPoint);
                    Destroy(gameObject);
                }
            }
        }

    }
    /*
    public void DamageEnemy(int amount, Vector3 direction)
    {
        if (invincibilityCounter <= 0)
        {
            currentHealth -= amount;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Respawn();
            }
            else
            {
                pc.KnockBack(direction);
                invincibilityCounter = invincibilityLength;
                playerRenderer.enabled = false;
                flashCounter = flashLength;
            }
        }
    }
    public void KnockBack(Vector3 direction)
    {
        knockBackCounter = knockBackTime;
        moveDir = direction * knockBackForce;
        moveDir.y = knockBackForce / 2;
    }*/
    void FaceTarget()
    {
        Vector3 dir = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
        transform.rotation = Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime*15f);
    }
    private void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
    
}
