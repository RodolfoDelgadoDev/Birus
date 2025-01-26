using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Void : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject[] checkpoints;

    private int currentCheckpoint = 0;
    void OnTriggerEnter (Collider other)
    {
        if(other.tag == "Player")
        {
            player.GetComponent<CharacterController>().enabled = false;
            Debug.Log("OLA");
            player.transform.position = checkpoints[currentCheckpoint].transform.position;
            player.GetComponent<CharacterController>().enabled = true;
        }
    }

    public void Checkpoint()
    {
        currentCheckpoint++;
    }

}
