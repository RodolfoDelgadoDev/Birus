using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public barSCript corruptionBar; // referencia al script de la barra de corrupcion
    public float corruption = 0; 
    public int enemyDamage = 3;

    private int wormCounter = 14;

    private float secondGame = 0.0f;
    
    private float corruptionTimer = 5.0f;
    [SerializeField] private GameObject pantallazo;

    private void Start()
    {
        pantallazo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        secondGame += Time.deltaTime;
        if(secondGame > corruptionTimer)
        {
        addCorruption();
        secondGame = 0.0f;
        }
    }

    public void addCorruption()
    {
        if (corruption < 100)
        {
            corruption +=  enemyDamage;
            corruptionBar.setCorruption();
            print (corruption);
        }
        else 
        {
            corruption = 100;
            print("GAME OVER");
            pantallazo.SetActive(true);
        }
    }

    public void WormDead()
    {
        wormCounter--;
        if(wormCounter % 5 == 0 )
            enemyDamage--;
        if (wormCounter == 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(2);
        }
        
    }
    
}