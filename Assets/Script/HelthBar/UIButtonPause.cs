using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonPause : MonoBehaviour
{
    public void Resume()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Option()
    {

        SceneManager.LoadScene("Option");
        
    }

    public void ExitGames()
    {
        Application.Quit();
    }
}
