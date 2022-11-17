using Doozy.Runtime.UIManager.Containers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public UIContainer panelPaus;

    public void PauseControl()
    {
        if (Time.timeScale == 1)
        {
            panelPaus.Show();
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            panelPaus.Hide();

        }
    }

}
