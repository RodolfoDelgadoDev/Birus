using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{

    [SerializeField] Camera playerCamera;
    [SerializeField] float walkSpeed = 6f, stunDur = 1.5f;
    [SerializeField] float runSpeed = 12f;
    [SerializeField] float jumpPower = 7f;
    [SerializeField] float gravity = 9.8f;
    [SerializeField] GameObject stun;
    [SerializeField] float lookSpeed = 2f;  
    [SerializeField] float lookXLimit = 45f;

    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0f;

    public bool canMove = true;

    private CharacterController characterController;




    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        ///Movimiento y direccion
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);


        ///Saltos
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
            moveDirection.y = jumpPower;
        else
            moveDirection.y = movementDirectionY;

        if (!characterController.isGrounded)
            moveDirection.y -= gravity * Time.deltaTime;

        characterController.Move(moveDirection * Time.deltaTime);

        if(canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }



    }
    
    void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.tag == "Platforms")
            Debug.Log("AY SOY PLATAFORMA");
    }

    void playerStun()
    {
        stun.gameObject.SetActive(true);
        stun.gameObject.transform.parent = null;
        StartCoroutine(stunDuration());
    }

    IEnumerator stunDuration()
    {
        yield return new WaitForSeconds(stunDur);
        stun.gameObject.SetActive(false);
        stun.gameObject.transform.parent = gameObject.transform;
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Sword")
        {
            //Debug.Log("RODOLFOOO");
            playerStun();
        }
    }
}
