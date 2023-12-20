using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Carga : MonoBehaviour
{
    public Text texto;
    AsyncOperation operation;
    public Slider slider;

    void Start()
    {
        operation = SceneManager.LoadSceneAsync("TrainScene");
        operation.allowSceneActivation = false;
    }

    private void Update()
    {
        slider.value = Mathf.Clamp01(operation.progress/0.9f);
         Debug.Log(operation.progress);
        if (operation.progress >= 0.9f)
        {
            texto.text = "PULSA X PARA CONTINUAR";
            if(Input.anyKey)
            {
                StartCoroutine(ActivarEscena());
            }
        }
    }
    IEnumerator ActivarEscena()
    {
        operation.allowSceneActivation = true;
        yield return null;
    }
}

