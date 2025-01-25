using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBubble : MonoBehaviour
{

    private float endLife = 4.0f;

    private float startingLife = 0f;

    private bool emote = false;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(startingLife < endLife)
            startingLife += Time.deltaTime;
        else if (startingLife + 1.0f == endLife)
            audioSource.Play();
        else
            Destroy(this.gameObject);

        


    }
}
