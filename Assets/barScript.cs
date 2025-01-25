using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class barSCript : MonoBehaviour
{

	public Slider slider;
	public Image fill;
    public GameManager gameManager;
    public TMP_Text corruptionText;


    public void setCorruption()
    {
        if (gameManager != null) 
        {
            slider.value = gameManager.corruption; 
            //Debug.Log("MI LOCO EL ESLAIDER BALUE E " + slider.value);
            corruptionText.text = "CORRUPTION: " + gameManager.corruption + "%";
        }
        else 
        {
            Debug.LogError("GameManager is not assigned in the barSCript."); 
        }
    }

}