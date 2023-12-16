using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class IuAlex : MonoBehaviour
{
    string frase = "ZZZ...";
    public TextMeshProUGUI text;
    void Start()
    {
        StartCoroutine(Reloj());
    }

    IEnumerator Reloj()
    {

            foreach (char c in frase)
            {
                text.text = text.text + c;
            if (text.text.Equals(frase)){
                text.text = "";
                StartCoroutine(Reloj());
            }
                yield return new WaitForSeconds(0.5f);
            }
    }
}
