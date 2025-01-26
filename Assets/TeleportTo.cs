using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TeleportTo : MonoBehaviour
{
    [SerializeField] private Transform end;

    [SerializeField] private GameObject player;

    void OnTriggerEnter (Collider other)
    {
        if(other.tag == "Player")
        {
            player.GetComponent<CharacterController>().enabled = false;
            Debug.Log("OLA");
            player.transform.position = end.position;
            player.GetComponent<CharacterController>().enabled = true;

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
