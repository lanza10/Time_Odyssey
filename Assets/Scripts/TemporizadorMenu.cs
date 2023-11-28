using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TemporizadorMenu : MonoBehaviour
{
    private float totalTime = 30; //Segundos de espera hasta entrar al menú
    private float currentTime;
    // private SoundManager soundManager;
    public Canvas canvas;
    private AudioSource audioSource;

    void Start()
    {
        currentTime = totalTime;
        audioSource = canvas.GetComponent<AudioSource>();
        
    }

    /*private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }*/
    void Update()
    {
        if(currentTime <= 6.7 && currentTime>0)
        {
            Debug.Log("JOPETIIIIIIIIIISISSS");
            /*soundManager.SeleccionAudio(1, 0.5f);*/
            if (audioSource != null)
            {
                // Activar el AudioSource
                audioSource.enabled = true;
            }
        }
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;    
        }
        else
        {
            currentTime = 0;
            SceneManager.LoadScene("MainMenu");
        }

    }

}
