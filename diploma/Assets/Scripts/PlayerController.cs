using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    //Rigidbody rb;
    private int speed = 30;
    private int jumpForce = 30;
    private float gravityScale = 5f;
    CharacterController cc;
    private Vector3 moveDir;
    public Animator animator;
    public Transform pivot;
    private float rotateSpeed = 25f;
    public GameObject playerModel;
    private float knockBackForce = 40f;
    private float knockBackTime = 0.55f;
    private float knockBackCounter;
    public game game;
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (knockBackCounter <= 0) { 
            //moveDir = new Vector3(Input.GetAxis("Horizontal") * speed, moveDir.y , Input.GetAxis("Vertical") * speed);
            float yStore = moveDir.y;
            moveDir = (transform.forward * Input.GetAxis("Vertical") ) + (transform.right * Input.GetAxis("Horizontal")) ;
            moveDir = moveDir.normalized * speed;
            moveDir.y = yStore;

            if (cc.isGrounded) {
                moveDir.y = 0f;
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    moveDir.y = jumpForce;
                }
            }

            
        }
        else
        {
            knockBackCounter -= Time.deltaTime;
        }

        moveDir.y += (Physics.gravity.y * gravityScale * Time.deltaTime);
        cc.Move(moveDir*Time.deltaTime);

        //Move the player in different directions based on camera look direction
        if (Input.GetAxis("Horizontal")!=0 || Input.GetAxis("Vertical")!=0) {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDir.x, 0f, moveDir.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation,newRotation,rotateSpeed*Time.deltaTime);
        }

        animator.SetBool("isGrounded", cc.isGrounded);
        animator.SetFloat("speed", Math.Abs(Input.GetAxis("Vertical"))+ Math.Abs(Input.GetAxis("Horizontal")));
    }

    public void KnockBack(Vector3 direction)
    {
        knockBackCounter = knockBackTime;
        moveDir = direction * knockBackForce;
        moveDir.y = knockBackForce/2;
    }
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            game.CallSave();
        }
    }*/
}
