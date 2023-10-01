using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    public float speed = 6;
    public float jumpSpeed = 8;
    private float gravity = 9.8f;
    private float currentVerticalSpeed = 0;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>() ; 
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move(){
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if(characterController.isGrounded){
            currentVerticalSpeed = 0;
            if(Input.GetAxis("Jump") > 0){
                currentVerticalSpeed = jumpSpeed;
            }
        }
        currentVerticalSpeed -= gravity * Time.deltaTime;
        Vector3 move = transform.forward * verticalInput + transform.right * horizontalInput;
        move.y = currentVerticalSpeed;
        characterController.Move(speed*Time.deltaTime * move);
    }
}
