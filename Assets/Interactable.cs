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

    [SerializeField] private Animator animator;
    
    [SerializeField] private Material material;

    [SerializeField] private GameObject sphere;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            animator.Play("Open");
            interactableUI.SetActive(true);
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if(Input.GetKey(KeyCode.E))
            {
                interactableUI.SetActive(false);
                sphere.GetComponent<Renderer>().material = material;
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            interactableUI.SetActive(false);
            animator.Play("Close");
        }
    }

    // Update is called once per frame
    void Update()
    {
        interactableUI.transform.LookAt(player.transform);
        interactableUI.transform.Rotate(0,180,0);
    }
}
