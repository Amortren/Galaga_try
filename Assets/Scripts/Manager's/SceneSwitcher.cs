using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void OnPlay()
    {
        SceneManager.LoadScene(1);

    }

    public void OnExit()
    {
        Application.Quit();
    }

    public void OnMenu()
    {
        SceneManager.LoadScene(0);
    }
}
