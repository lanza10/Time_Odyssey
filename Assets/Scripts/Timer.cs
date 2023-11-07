using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour 
{ 
    public Text textoTimer;
    private float totalTime = 2* 60; // 8 minutos en segundos
    private float currentTime;

    void Start()
    {
        currentTime = totalTime;
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            DisplayTime(currentTime);
        }
        else
        {
            currentTime = 0;
            DisplayTime(currentTime);
            SceneManager.LoadScene("GameOver");
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        textoTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
