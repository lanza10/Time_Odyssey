using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Revisor : MonoBehaviour
{
    public Dialog dialogoAnterior;
    enum ESTADOS {QUIETO, CAMINANDO, REVISANDO, ALTERADO  }
    //Stack<ESTADOS> SSstate = new Stack<ESTADOS>();
    private Transform destino;
    private GameObject Evan;
    private float velocidad = 2;
    ESTADOS estado // property
    {
        get { return estado; }
        set { estado = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        //Inicializando el estado de arranque del personaje
        estado = ESTADOS.QUIETO;
        Debug.Log("HOLAAAAAAAAAAAA");
        //SSstate.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        MainStateMachine();
    }

    void MainStateMachine()
    {
        switch (estado)
        {
            case ESTADOS.QUIETO:
                if (dialogoAnterior.getConversacionAlexEnd()) {
                    desplazamiento();
                    estado = ESTADOS.CAMINANDO;
                }
                break;
            case ESTADOS.CAMINANDO:
                
                break;
            case ESTADOS.REVISANDO:
              
                break;
            case ESTADOS.ALTERADO:
                
                break;
        }
    }

   void desplazamiento() {
        Vector3 direccion = (dialogoAnterior.control.transform.position - transform.position).normalized;

        // Calcula la distancia entre el objeto y el destino
        float distancia = Vector3.Distance(transform.position, destino.position);

        // Si la distancia es mayor que 0.1, mueve el objeto hacia el destino
        if (distancia > 0.1f)
        {
            // Utiliza transform.Translate para mover el objeto en la dirección calculada
            transform.Translate(direccion * velocidad * Time.deltaTime, Space.World);
        }
    }
}
