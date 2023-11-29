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
    private float velocidad = 3f;
    private bool semaforo;
    private Vector3 posInit;
    private bool estaEnMedio = false;
    Rigidbody rb;
       
    private Vector3 medio =  new Vector3(19.95f, 4.944584f, 100.04f);
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
        rb = GetComponent<Rigidbody>();
        Debug.Log("HOLAAAAAAAAAAAA");
        posInit= transform.position;
        //SSstate.Clear();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MainStateMachine();
    }

    void MainStateMachine()
    {
        switch (estado)
        {
            case ESTADOS.QUIETO:
                if (!dialogo.getConversacionRevEnd())
                {
                    if (dialogo.getConversacionAlexEnd())
                    {
                        estado = ESTADOS.CAMINANDO;
                    }
                }
                else
                {
                    break;   
                }
                break;
            case ESTADOS.CAMINANDO:
                        Debug.Log("AAAA");
                        if (semaforo) {
                            if (!dialogo.getConversacionRevEnd())
                            {
                                desplazamientoHaciaEvan();
                            }
                            else
                            {
                                desplazamientoHaciaInicio();
                            }
                        } else
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

    void desplazamientoHaciaEvan()
    {
        Vector3 miVector = new Vector3(1f, 0f, 0f);
        Vector3 direccion = (evan.position + miVector) - transform.position;
        direccion.Normalize();
        Vector3 direccionMedio = medio - transform.localPosition;
        direccionMedio.Normalize();

        if (!estaEnMedio)
        {
            Debug.Log(direccionMedio);
            Debug.Log("Posición actual: " + transform.position);
            rb.MovePosition(transform.position + direccionMedio * velocidad * Time.deltaTime);

            if (Vector3.Distance(transform.position, medio) < 0.1f)
            {
                estaEnMedio = true;
            }
        }
        else
        {
            rb.MovePosition(transform.position + direccion * velocidad * Time.deltaTime);

            if (Vector3.Distance(transform.position, evan.position + miVector)  < 0.5f)
            {
                
                semaforo = false;
                estaEnMedio = false;
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
            rb.MovePosition(transform.position + direccionMedio * velocidad * Time.deltaTime);

            if (Vector3.Distance(transform.position, medio) < 0.1f)
            {
                estaEnMedio = true;
            }
        }
        else
        {
            rb.MovePosition(transform.position + direccion * velocidad * Time.deltaTime);

            if (Vector3.Distance(transform.position, posInit) < 0.5f)
            {
                estado = ESTADOS.QUIETO;
                semaforo = false;
            }
        }
    }


}
