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
    //for vignette effect during stun
    [SerializeField] float fromValue = 1.20f, toValue = 1.5f, vignetteDuration = 1.5f;
    [SerializeField] Material vignetteMat;
    //------------------------------------------------------------------------------------

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
        vignetteMat.SetFloat("_Power", 15);
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
        //stun.gameObject.SetActive(true);
        //stun.gameObject.transform.parent = null;
        
        canMove = false;
        StartCoroutine(stunDuration());
    }

    IEnumerator stunDuration()
    {
        yield return StartCoroutine(LerpMatVignette(fromValue, toValue, vignetteDuration));
        //yield return StartCoroutine(LerpMatVignette(toValue, fromValue, vignetteDuration));
        yield return new WaitForSeconds(stunDur);
        canMove = true;
      //  stun.gameObject.SetActive(false);
      //  stun.gameObject.transform.parent = gameObject.transform;
      //  stun.gameObject.transform.position = new Vector3(0, 0, 0);
        vignetteMat.SetFloat("_Power", 15);

    }

    IEnumerator LerpMatVignette(float start, float end, float time)
    {
        float elapsedTime = 0f;

        while (elapsedTime < time)
        {
            vignetteMat.SetFloat("_Power", Mathf.Lerp(4, 10f, (elapsedTime / time)));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

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
