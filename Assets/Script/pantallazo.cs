using UnityEngine;
using TMPro;
using System.Collections;

public class Pantallazo : MonoBehaviour
{
    public float percentage = 2f;
    public TMP_Text progressText;

    void Start()
    {
        StartCoroutine(SimulateCompilation()); 
    }

    IEnumerator SimulateCompilation()
    {
        while (percentage <= 100f)
        {
            float randomIncrement = Random.Range(0.01f, 0.001f); 
            percentage += randomIncrement;
            progressText.text = "Please wait while the kernel compiles... " + percentage.ToString("F0") + "%"; 
            yield return new WaitForSecondsRealtime(0.0001f); 
        }

        progressText.text = "Kernel compilation complete!"; 
    }
}