using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 offset;
    public GameObject player;
    private float rotateSpeed = 5f;
    public Transform pivot; 
    
    void Start()
    {
        offset = player.transform.position - transform.position;

        pivot.transform.position = player.transform.position;
        pivot.transform.parent = null;

        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        
        pivot.transform.position = player.transform.position;
        //player rotation
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        pivot.transform.Rotate(0, horizontal, 0);

        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        pivot.transform.Rotate(-vertical,0, 0);

        //limit camera
        if (pivot.rotation.eulerAngles.x > 30f && pivot.rotation.eulerAngles.x < 180f)
        {
            pivot.rotation = Quaternion.Euler(30f, pivot.rotation.eulerAngles.y, pivot.rotation.eulerAngles.z);
        }
        if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 300f)
        {
            pivot.rotation = Quaternion.Euler(300f, 0, 0);
        }

        //camera rotate
        float desiredYAngle = pivot.transform.eulerAngles.y;
        float desiredXAngle;
        if (pivot.transform.eulerAngles.x > 310f && pivot.transform.eulerAngles.x < 360f)
        {
             desiredXAngle = pivot.transform.eulerAngles.x;

        }
        else
        {
            desiredXAngle = 360f;
        }

        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);

        
        transform.position = player.transform.position - (rotation * offset);

        if(transform.position.y < player.transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        }
        //transform.position = player.transform.position + offset;
        transform.LookAt(player.transform);
    }
}
