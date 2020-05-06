using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickUp : MonoBehaviour
{
    private int value = 1;
    public GameObject pickup;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Instantiate(pickup, transform.position, transform.rotation);
            FindObjectOfType<game>().AddGold(value);
            Destroy(gameObject);
        }
    }
}
