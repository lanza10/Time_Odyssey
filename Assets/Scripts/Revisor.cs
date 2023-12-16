using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class Revisor : MonoBehaviour
{
    public DialogInit dialogo;
    enum ESTADOS {QUIETO, CAMINANDO, REVISANDO, ALTERADO  }
    //Stack<ESTADOS> SSstate = new Stack<ESTADOS>();
    public Transform evan;
    private float velocidad = 1f;
    private bool semaforo;
    private Vector3 posInit;
    private bool estaEnMedio = false;
    Rigidbody rb;
    public GameObject revisorPersonaje;
    Animator anim;

    //private Vector3 medio = new Vector3(19.95f, 4.944584f, 100.04f);
    private Vector3 medio =  new Vector3(8.14f, 6.21f, 116.802f);
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
        anim = revisorPersonaje.GetComponent<Animator>();
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
                                anim.SetBool("andar", true);
                                anim.SetBool("parar", false);
                                anim.SetBool("hablar", false);
                                desplazamientoHaciaInicio();
                            }
                        } else
                        {
                            estado = ESTADOS.REVISANDO;
                        }
                        //Debug.Log("Estoy Caminando");
                        break;
                    case ESTADOS.REVISANDO:
                         anim.SetBool("andar", false);
                         anim.SetBool("hablar", true);
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
                                Quaternion rotacionDeseada = Quaternion.Euler(0.0f, -90.0f, 0.0f);
                                rb.MoveRotation(rotacionDeseada);
                                anim.SetBool("hablar",false);
                                anim.SetBool("andar", true);
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
        Vector3 miVector = new Vector3(-2f, 0f, 0f);
        Vector3 direccion = (evan.position + miVector) - transform.position;
        direccion.Normalize();
        Vector3 direccionMedio = medio - transform.localPosition;
        direccionMedio.Normalize();
        anim.SetBool("andar", true);
        anim.SetBool("parar", false);
        

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
            Quaternion rotacionDeseada = Quaternion.Euler(0.0f, 90.0f, 0.0f);
            rb.MoveRotation(rotacionDeseada);

            if (Vector3.Distance(transform.position, evan.position + miVector)  < 0.1f)
            {
                rotacionDeseada = Quaternion.Euler(0.0f, -45.0f, 0.0f);
                rb.MoveRotation(rotacionDeseada);

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
            Quaternion rotacionDeseada = Quaternion.Euler(0.0f, -90.0f, 0.0f);
            rb.MoveRotation(rotacionDeseada);
            if (Vector3.Distance(transform.position, posInit) < 0.5f)
            {
                Quaternion rotacion2 = Quaternion.Euler(0.0f, 90.0f, 0.0f);
                rb.MoveRotation(rotacion2);
                anim.SetBool("andar", false);
                anim.SetBool("parar", true);
                estado = ESTADOS.QUIETO;
                semaforo = false;
            }
        }
    }


}
