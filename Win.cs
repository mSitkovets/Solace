using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //can load scenes, start active scenes, save scenes, etc

public class Win : MonoBehaviour
{

    public void PlayAgain()
    {
        Debug.Log("Play Again");
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
