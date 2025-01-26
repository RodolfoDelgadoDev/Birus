using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform origin;
    [SerializeField] float bubbleSizeLimit = 2f;

    private int remainingBullets;
    
    [SerializeField] GameObject weapon;

    private float timeCharged = 1.5f;

    private float timeHold = 0.0f;
    private bool charging = false;

    private Animator animator;

    [SerializeField] AudioClip[] clips;

    [SerializeField] private GameObject bigBubble;

    private GameObject bubbleIn;

    private AudioSource source;


    // Start is called before the first frame update
    void Start()
    {
        remainingBullets = 20;
        animator = gameObject.GetComponent<Animator>();
        source = gameObject.GetComponent<AudioSource>();
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
            int audi = Random.Range(0, 2);
            Debug.Log(audi);
            source.clip = clips[audi];
            source.Play();
            charging = false;
            ShootBubble();
            timeHold = 0.0f;
        }
        if (timeHold > bubbleSizeLimit)
        {
            timeHold = bubbleSizeLimit;
        }
        //Debug.Log(timeHold);
    }  

    void ShootBubble()
    {
        bubbleIn = Instantiate(bigBubble, origin.position, origin.rotation);
        
        bubbleIn.transform.localScale *= timeHold;
        float forceY = Random.Range(-10,30);

        //Debug.Log("HOLA AMIGUIS ME LLAMO Y Y MI FOTOLOG ES " + forceY);
        
        float forceX = Random.Range(-10,30);

       // Debug.Log("HOLA AMIGUIS ME LLAMO X Y MI FOTOLOG ES " + forceX);

        bubbleIn.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(forceX,forceY,150f), ForceMode.Force);
        remainingBullets--;
    }
    

}