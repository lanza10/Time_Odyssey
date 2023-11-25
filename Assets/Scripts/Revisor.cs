using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Revisor : MonoBehaviour
{
    public DialogInit dialogoAnterior;
    public DialogInit dialogActual;
    enum ESTADOS {QUIETO, CAMINANDO, REVISANDO, ALTERADO  }
    //Stack<ESTADOS> SSstate = new Stack<ESTADOS>();
    public Transform evan;
    private float velocidad = 2f;
    private bool semaforo;
    private Vector3 posInit;
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
                if (dialogoAnterior.getConversacionAlexEnd()) {
                    
                    estado = ESTADOS.CAMINANDO;
                }
                break;
            case ESTADOS.CAMINANDO:
                if(semaforo) {
                    if (!dialogActual.getConversacionRevEnd())
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
                        dialogActual.Conversar();
                        conv = CONV.INICIADA;
                        break;
                    case CONV.INICIADA:
                        if (dialogActual.getConversacionRevEnd())
                        {
                            conv= CONV.ACABADA;
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
        Debug.Log('C');
        Vector3 miVector = new Vector3(1f, 0f, 0f);
        Vector3 direccion = (evan.position + miVector ) - transform.position;
        direccion.Normalize();
        transform.Translate(direccion * velocidad * Time.deltaTime);
        if (transform.position == evan.position + miVector)
        {
            semaforo = false;
        }
    }
    void desplazamientoHaciaInicio()
    {
        Debug.Log('B');
        Vector3 direccion = posInit - transform.position;
        direccion.Normalize();
        transform.Translate(direccion * velocidad * Time.deltaTime);
        if (transform.position == posInit)
        {
            semaforo = false;
        }
    }


}
