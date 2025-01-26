using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    [SerializeField] GameObject[] Trojans;

    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            foreach (GameObject virus in Trojans)
            {
                virus.GetComponent<TroyanController>().TriggerAttack(true, false);
            }
        }
    }

    void OnTriggerStay (Collider other)
    {
        if (other.tag == "Player")
        {
           foreach (GameObject virus in Trojans)
            {
                virus.GetComponent<TroyanController>().TriggerAttack(true, true);
            } 
        }
    }
}
