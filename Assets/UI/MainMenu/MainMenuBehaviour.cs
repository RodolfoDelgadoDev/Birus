using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBehaviour : MonoBehaviour
{
    //Starts the Game
    public void PlayGame ()
    {
        SceneManager.LoadScene("GameMap");
    }

    //Quits the Game
    public void QuitGame()
    {
        Application.Quit();
    }
}
