using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pause : MonoBehaviour
{
    // canvas
    public GameObject menupausa;
    public GameObject pauseUI;

    public void voltarMenu()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log("Carregar menu");
        Time.timeScale = 1f;
    }

    public void ClickPauseButton()
    {
        menupausa.SetActive(true);
        pauseUI.SetActive(false);
        Time.timeScale = 0f;
    }

    public void ClickResumeButton()
    {
        menupausa.SetActive(false);
        pauseUI.SetActive(true);
        Time.timeScale = 1f;
    }
}