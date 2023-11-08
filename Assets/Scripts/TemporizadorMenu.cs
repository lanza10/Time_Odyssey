using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TemporizadorMenu : MonoBehaviour
{
    private float totalTime = 30; //Segundos de espera hasta entrar al menú
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
        }
        else
        {
            currentTime = 0;
            SceneManager.LoadScene("TrainScene");
        }
    }

}
