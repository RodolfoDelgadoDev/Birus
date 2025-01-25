using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform origin;

    private int remainingBullets;
    
    [SerializeField] GameObject weapon;

    

    private Animator animator;


    [SerializeField] private GameObject bubble;

    private GameObject bubbleIn;


    // Start is called before the first frame update
    void Start()
    {
        remainingBullets = 20;
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetMouseButtonDown(0))
        {
            if(remainingBullets > 0)
            {
            bubbleIn = Instantiate(bubble, origin.position, origin.rotation);
            bubbleIn.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0,30f,100f), ForceMode.Force);
            remainingBullets--;
            Debug.Log("CAPITO ME QUEDAN " + remainingBullets + "BALAAAAASSS");
            }
            else
            {
                Debug.Log("TENGO QUE CARGAR LOCO AAAAAAAAAAAAAAAA");
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            remainingBullets = 20;
            Debug.Log("CARGADO MI LOCO!");
        }
    }
}
