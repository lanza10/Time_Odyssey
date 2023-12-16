using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alex : MonoBehaviour
{
    public DialogInit dialogo;
    Animator anim;
    public GameObject alexPersonaje;
    public GameObject IU;
    // Start is called before the first frame update
    void Start()
    {
        anim = alexPersonaje.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogo.getConversacionAlexEnd())
        {
            anim.SetBool("dormir", true);
            IU.SetActive(true);
        }
    }
}
