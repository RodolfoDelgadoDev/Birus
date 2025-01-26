using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBubble : MonoBehaviour
{

    [SerializeField] private float endLife = 4.0f;
    [SerializeField] GameObject bubbleParticle;

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
        if(startingLife > endLife)
            destroyBubble();

    }

    public void destroyBubble()
    {
        //Debug.Log("OLA");
        audioSource.Play();
        Instantiate(bubbleParticle, transform.position, Quaternion.identity);
        StartCoroutine(sleep2sec());
        Destroy(this.gameObject);
    }

    IEnumerator sleep2sec()
    {
        yield return new WaitForSeconds(1.5f);
    }
}
