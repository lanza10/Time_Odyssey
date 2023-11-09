using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void cargarMainMenu()
    {

        SceneManager.LoadScene("MainMenu");
    }
    public void cargarEscenaJuego() {

        SceneManager.LoadScene("TrainScene");
    }
    public void cargarCreditos()
    {

        SceneManager.LoadScene("Creditos");
    }
    public void Salir()
    {
        Application.Quit();
    }
}
