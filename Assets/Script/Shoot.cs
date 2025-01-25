using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform origin;

    private int remainingBullets;
    
    [SerializeField] GameObject weapon;

    private float timeCharged = 1.5f;

    private float timeHold = 0.0f;
    private bool charging = false;

    private Animator animator;


    [SerializeField] private GameObject smallBubble;

    [SerializeField] private GameObject bigBubble;

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
            charging = true;
            timeHold = 0.0f;
        }
        if (Input.GetMouseButton(0))
        {
            timeHold += Time.deltaTime;
        }
        if (Input.GetMouseButtonUp(0))
        {
            charging = false;
                ShootBubble();
            timeHold = 0.0f;
        }
    }
    
    void ShootSmallBubble()
    {
        bubbleIn = Instantiate(smallBubble, origin.position, origin.rotation);
        bubbleIn.transform.localScale *= timeHold;
        bubbleIn.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0,60f,200f), ForceMode.Force);
        remainingBullets--;

    }

    void ShootBubble()
    {
        bubbleIn = Instantiate(bigBubble, origin.position, origin.rotation);
        bubbleIn.transform.localScale *= timeHold;
    
        bubbleIn.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0,60f,200f), ForceMode.Force);
        remainingBullets--;
    }

}