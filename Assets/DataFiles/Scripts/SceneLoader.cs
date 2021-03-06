﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void GoToScene(string scene)
    {
        if (scene == "Quit")
            Application.Quit();
        else
        {
            SceneManager.LoadScene(scene);
            Time.timeScale = 1;
        }
    }
}
