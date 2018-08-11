using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //can load scenes, start active scenes, save scenes, etc

public class MainMenu : MonoBehaviour 
{

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
		Debug.Log("QUIT");
        Application.Quit();
    }
}
