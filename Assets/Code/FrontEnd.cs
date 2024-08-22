using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FrontEnd : MonoBehaviour
{
    public void OnLoadGameClicked()
    {
        GoToScene("Load Game");
    }
    public void OnNewGameClicked()
    {
        GoToScene("Opening Cutscene");
        
    }

    public void OnControlsClicked()
    {
        GoToScene("Controls");

    }

    public void OnCreditsClicked()
    {
        GoToScene("Credits");

    }

    public void OnQuitGameClicked()
    {
        Application.Quit();
    }

    void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

