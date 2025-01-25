using UnityEngine;

public class GameManager : MonoBehaviour
{
    public barSCript corruptionBar; // referencia al script de la barra de corrupcion
    public int corruption = 0; 
    public int enemyDamage = 5; 
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            addCorruption();
        }
    }

    public void addCorruption()
    {
        if (corruption < 100)
        {
            corruption += enemyDamage;
            corruptionBar.setCorruption();
            print (corruption);
        }
        else 
        {
            corruption = 100;
            print("GAME OVER"); 
        }
        
    }
}