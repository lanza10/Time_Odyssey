using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour 
{ 
    public Text textoTimer;
    public int minutos;
    private float totalTime; 
    private float currentTime;

    void Start()
    {
        totalTime = minutos * 60;
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
        {   if (this.gameObject.name == "TimerManagerTutorial")
            {
                currentTime = 0;
                DisplayTime(currentTime);
                SceneManager.LoadScene("TrainSceneBucle");
            }
            else {
                currentTime = 0;
                DisplayTime(currentTime);
                SceneManager.LoadScene("GameOver");
            }
            
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        textoTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
