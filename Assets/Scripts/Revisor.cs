using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Revisor : MonoBehaviour
{
    public DialogInit dialogo;
    enum ESTADOS {QUIETO, CAMINANDO, REVISANDO, ALTERADO  }
    //Stack<ESTADOS> SSstate = new Stack<ESTADOS>();
    public Transform evan;
    private float velocidad = 2f;
    private bool semaforo;
    private Vector3 posInit;
    private bool estaEnMedio = false
        ;
    private Vector3 medio =  new Vector3(4.5f,0.658f, 15.6f);
    enum CONV { NOINICIADA, INICIADA, ACABADA}
    private CONV _conv;
    CONV conv
    {
        get { return _conv; }
        set { _conv = value;}
    }
    private ESTADOS _estado;
    ESTADOS estado // property
    {
        get { return _estado; }
        set { _estado = value; semaforo = true; }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        //Inicializando el estado de arranque del personaje
        estado = ESTADOS.QUIETO;
        conv = CONV.NOINICIADA;
        Debug.Log("HOLAAAAAAAAAAAA");
        posInit= transform.position;
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
                if (dialogo.getConversacionAlexEnd()) {
                    
                    estado = ESTADOS.CAMINANDO;
                }
                break;
            case ESTADOS.CAMINANDO:
                if(semaforo) {
                    if (!dialogo.getConversacionRevEnd())
                    {
                        desplazamientoHaciaEvan();
                    }
                    else
                    {
                        desplazamientoHaciaInicio();
                    }
                }else
                {
                    estado = ESTADOS.REVISANDO;
                }
                //Debug.Log("Estoy Caminando");
                break;
           case ESTADOS.REVISANDO:
                switch (conv)
                {
                    case CONV.NOINICIADA:
                        dialogo.Conversar();
                        conv = CONV.INICIADA;
                        break;
                    case CONV.INICIADA:
                        if (dialogo.getConversacionRevEnd())
                        {
                            conv = CONV.ACABADA;
                        }
                        break;
                    case CONV.ACABADA:
                        estado = ESTADOS.CAMINANDO;
                        break;
                }
                    
                break;
            case ESTADOS.ALTERADO:
                
                break;
        }
    }

   void desplazamientoHaciaEvan() {
        Vector3 miVector = new Vector3(1f, 0f, 0f);
        Vector3 direccion = (evan.position + miVector ) - transform.position;
        direccion.Normalize();
        Vector3 direccionMedio = medio - transform.position;
         direccionMedio.Normalize();
        if (!estaEnMedio)
        {
            Debug.Log("A");
            transform.Translate(direccionMedio * velocidad * Time.deltaTime);
            if (transform.position == medio)
            {
                estaEnMedio = true;
            }
        }else
        {
            transform.Translate(direccion * velocidad * Time.deltaTime);
            if (transform.position == evan.position + miVector)
            {
                semaforo = false;
                estaEnMedio= false;
            }
        }
        
    }
    void desplazamientoHaciaInicio()
    {
        Vector3 direccion = posInit - transform.position;
        direccion.Normalize();
        Vector3 direccionMedio = medio - transform.position;
        direccionMedio.Normalize();
        if (!estaEnMedio)
        {
            transform.Translate(direccionMedio * velocidad * Time.deltaTime);
            if (transform.position == medio)
            {
                estaEnMedio = true;
            }
        }else
        {
            transform.Translate(direccion * velocidad * Time.deltaTime);
            if (transform.position == posInit)
            {
                semaforo = false;
               
            }
        }
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("EvanProvisional") && dialogo.getHaIdoPuerta())
        {
            dialogo.isInRange();
            dialogo.setActive();
            Debug.Log("Entró al colllider");
        }


    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("EvanProvisional") && dialogo.getHaIdoPuerta())
        {
            dialogo.isNotInRange();
            dialogo.setNotActive();
            Debug.Log("Salió del colllider");
        }
    }


}
