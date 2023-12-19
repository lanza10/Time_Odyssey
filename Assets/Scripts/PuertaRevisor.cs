using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class PuertaRevisor : MonoBehaviour
{
   
    public GameObject puertaIzquierda;
    public GameObject puertaDerecha;
    public DialogInit dialog;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {

        //puertaIzquierda.GetComponent<Animator>().enabled = true;
        //puertaDerecha.GetComponent<Animator>().enabled = true;
        if(other.gameObject.CompareTag("EvanProvisional") && dialog.PuertaRev)
        {
            puertaDerecha.GetComponent<Animator>().SetBool("abrir", true);
            puertaIzquierda.GetComponent<Animator>().SetBool("abrir", true);
            puertaDerecha.GetComponent<Animator>().SetBool("cerrar", false);
            puertaIzquierda.GetComponent<Animator>().SetBool("cerrar", false);
        }
        


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("EvanProvisional") && dialog.PuertaRev)
        {
            puertaDerecha.GetComponent<Animator>().SetBool("abrir", false);
            puertaIzquierda.GetComponent<Animator>().SetBool("abrir", false);
            puertaDerecha.GetComponent<Animator>().SetBool("cerrar", true);
            puertaIzquierda.GetComponent<Animator>().SetBool("cerrar", true);
        }

        //puertaIzquierda.GetComponent<Animator>().enabled = false;
        //puertaDerecha.GetComponent<Animator>().enabled = false;

    }
}
