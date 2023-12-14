using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CiudadController : MonoBehaviour
{
    private Vector3 posReini = new Vector3(0f, 0f, 756f);
    private bool estaEnReini = false;
    public float velocidad = 100f;

    void Start()
    {
    }

        // Update is called once per frame
        void FixedUpdate()
    {
        Vector3 direccion = posReini - transform.position;
        direccion.Normalize();
        if (!estaEnReini)
        {
            transform.position += direccion * velocidad * Time.deltaTime;

            if (Vector3.Distance(transform.position, posReini) < 3f)
            {
                estaEnReini = true;
            }
        }else
        {
            transform.position = new Vector3(0f, 0f, 415f);
            estaEnReini = false;
        }
    }
}
