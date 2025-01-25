using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform origin;
    [SerializeField] private GameObject bubble;

    private GameObject bubbleIn;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetMouseButtonDown(0))
        {
            bubbleIn = Instantiate(bubble, origin.position, origin.rotation);
            bubbleIn.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0,30f,100f), ForceMode.Force);
        }
    }
}
