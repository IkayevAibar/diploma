using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timechanger : MonoBehaviour
{
    public Light DirL;
    public Light RimL;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            DirL.transform.rotation = Quaternion.Euler(-90f, DirL.transform.rotation.y, DirL.transform.rotation.z);
            RimL.intensity = 0.3f;
        }
    }
}
