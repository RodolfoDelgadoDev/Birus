using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBehaviour : MonoBehaviour
{
    public AudioSource menuSound;

    // Starts the game with a smoother transition
    public void PlayGame()
    {
        // Play the menu sound
        menuSound.Play();

        // Start a coroutine to handle the scene change with a slight delay
        StartCoroutine(LoadSceneWithDelay("GameMap", 1.0f ));
    }

    IEnumerator LoadSceneWithDelay(string sceneName, float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Load the target scene
        SceneManager.LoadScene(sceneName);
    }
   
    
    //Quits the Game
    public void QuitGame()
    {
        // Play the menu sound
        menuSound.Play();

        // Start a coroutine to handle the scene change with a slight delay
        StartCoroutine(QuitSceneWithDelay(1.0f));
    }

    IEnumerator QuitSceneWithDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);
        //Quit app
        Debug.Log("app end");
        Application.Quit();
    }
}