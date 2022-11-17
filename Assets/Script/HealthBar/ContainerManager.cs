using System.Collections;
using System.Collections.Generic;
using Doozy.Runtime.UIManager.Containers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContainerManager : MonoBehaviour
{
    [SerializeField] UIContainerManager container;
    bool switchBool = true;

    public void ContainernerSwitch()
    {
        if (switchBool)
        {
            switchBool = false;
            container.Show();
            Time.timeScale = 0;
        }

        else
        {
            switchBool = true;
            container.Hide();
            Time.timeScale = 1;
        }
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(0);
    }

    public void PauseGame()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }

    }
}
