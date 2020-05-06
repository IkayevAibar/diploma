using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class SpawnProjectut : MonoBehaviour
{
    public GameObject firepoint;
    public GameObject charc;
    public List<GameObject> vfx = new List<GameObject>();
    public Animator animator;

    private GameObject effectToSpawn;
    private float timeToFire;
    private bool isPunched;

    // Start is called before the first frame update
    void Start()
    {
        effectToSpawn = vfx[0];        
    }

    // Update is called once per frame
    void Update()
    {
        if(charc.transform.rotation.eulerAngles.y>=-3f && charc.transform.rotation.eulerAngles.y <= 3f) {
            if (Input.GetMouseButton(0) && Time.time >= timeToFire)
            {
                timeToFire = Time.time + 1 / effectToSpawn.GetComponent<projectutMove>().fireRate;
                SpawnVFX();
                isPunched = true;
            }

            animator.SetBool("isPunching", isPunched);
            isPunched = false;
        }
    }
    void SpawnVFX()
    {
        GameObject vfx;
        if (firepoint != null)
        {
            vfx = Instantiate(effectToSpawn, firepoint.transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("NoFirePoint");
        }
    }
}
