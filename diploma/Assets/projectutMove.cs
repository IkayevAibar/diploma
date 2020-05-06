using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectutMove : MonoBehaviour
{
    public float speed = 40f;
    public float fireRate = 1f;
    public Transform chrc;

    // Start is called before the first frame update
    void Start()
    {
        speed = 40f;
        fireRate = 1f;
        chrc = FindObjectOfType<PlayerController>().transform;
        transform.rotation = chrc.rotation;

    }

    // Update is called once per frame
    void Update()
    {
        if (speed >= 0)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        else
        {
            Debug.LogError("No Speed");
        }
        Destroy(gameObject, 4.0f);

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyController>().GetDamage(20);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyController>().GetDamage(20);
            Destroy(gameObject);

        }
    }
}
