using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public DialogInit dialogo;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("EvanProvisional") && !dialogo.getHaIdoPuerta())
        {
            dialogo.isInRange();
            dialogo.setActive();
            Debug.Log("Entr� al colllider");
        }


    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("EvanProvisional"))
        {
            dialogo.isNotInRange();
            dialogo.setNotActive();
            Debug.Log("Sali� del colllider");
        }
    }
}
