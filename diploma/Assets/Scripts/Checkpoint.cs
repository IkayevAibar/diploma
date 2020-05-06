using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Start is called before the first frame update
    public HealthManager hm;
    public Checkpoint[] checkpoints;
    public Material chOff;
    public Material chOn;
    public Renderer renderer;
    void Start()
    {
        hm = FindObjectOfType<HealthManager>();
        checkpoints = FindObjectsOfType<Checkpoint>();
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CheckpointOff()
    {
        renderer.material = chOff;
    }
    public void CheckpointOn()
    {
        renderer.material = chOn;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            hm.SetSpawnPoint(transform.position);
            foreach(Checkpoint ch in checkpoints)
            {
                ch.CheckpointOff();
            }
            CheckpointOn();
        }
    }
}
