using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Interactable : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject interactableUI;


    
    private TextMeshProUGUI interactText;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
            interactableUI.SetActive(true);
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if(Input.GetKey(KeyCode.E))
            {
                this.gameObject.SetActive(false);
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
            interactableUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        interactableUI.transform.LookAt(player.transform);
        interactableUI.transform.Rotate(0,180,0);
    }
}
