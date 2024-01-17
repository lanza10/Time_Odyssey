using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DialogueEditor;
using System;
using Unity.VisualScripting;
using System.Runtime.ConstrainedExecution;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices.WindowsRuntime;

public class DialogInit : MonoBehaviour
{
    // Start is called before the first frame update
    //public CharacterControlMando control;
    public CharacterControl control;
    private Map _playersControl = null;
    public NPCConversation[] MyConversations;
    public NPCConversation actualConversation;
    public ConversationManager convMan;
    private bool conversacionAlexEnd = false;
    private bool conversacionRevEnd = false;
    public bool esRevisor;
    private GameObject llave;
    private GameObject objeto;
    public GameObject imagenAviso;
    public GameObject imagenInteract;
    private bool isPlayerInRange;
    public MaquinaCafe maquina;
    bool puertaRev = false;
    public bool  PuertaRev{
        get { return puertaRev; } }
  

    //Indices para las conversaciones
    private const int CONVERSACIONALEX = 0;
    private const int CONVERSACIONREVISOR1 = 1;
    private const  int CONVERSACIONPUERTA = 2;
    private const int CONVERSACIONREVISOR2 = 3;
    private const int CONVERSACIONMAQUINISTA = 4;
    private const int CONVERSACIONFINAL = 5;
    private const int CONVERSACIONKIT = 6;
    private const int CONVERSACIONCAFE = 7;

    //Kit
    private GameObject sedante;

    //Animaciones
    public Animator animMaqui;
    public Animator animRevi;
    private void OnEnable()
    {
        _playersControl.Enable();
            ConversationManager.OnConversationStarted += ConversationStart;
            ConversationManager.OnConversationEnded += ConversationEnd;
    }

    private void OnDisable()
    {
        _playersControl.Disable();
            ConversationManager.OnConversationStarted -= ConversationStart;
            ConversationManager.OnConversationEnded -= ConversationEnd;
    }

    private void Awake()
    {
       
        esRevisor = this.gameObject.name == "RevisorProvisional";
        llave = new GameObject();
        llave.name = "Llave";
        sedante = new GameObject();
        sedante.name = "Sedante";
        _playersControl = new Map();
        _playersControl.Exploracion.Conversar.performed += ConversarA;
        _playersControl.Conversacion.Confirmar.performed += Confirmar;
        _playersControl.Conversacion.Siguiente.performed += Siguiente;
        _playersControl.Conversacion.Anterior.performed += Anterior;
        _playersControl.Conversacion.Opcion.performed += CambiaOpcion;

    }

    void Update()
    {
        if(objeto == GameObject.FindGameObjectWithTag("Alex"))
        {
            esRevisor = false;
            actualConversation = MyConversations[CONVERSACIONALEX];
        }
        else
        {
            esRevisor = true;
            if (!conversacionRevEnd)
            {
                actualConversation = MyConversations[CONVERSACIONREVISOR1];
            }   
        }
    }
    private void Start()
    {
        objeto = GameObject.FindGameObjectWithTag("Alex");
        control.ActivarMapSoloCamara();
        actualConversation = MyConversations[0];
        Conversar();
    }
    private void Confirmar(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() == 1)
        {
            if (actualConversation == MyConversations[CONVERSACIONFINAL])
            {
                ConversationManager.Instance.PressSelectedOption();
                if (ConversationManager.Instance.GetBool("DaSedante"))
                {
                    animMaqui.gameObject.transform.position = new Vector3(7.653449f, 5.392f, 68.83143f);
                    animMaqui.SetBool("dormir", true);
                }
            }
            ConversationManager.Instance.PressSelectedOption();
        }
    }

    private void CambiaOpcion(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() < 0)
        {
            ConversationManager.Instance.SelectNextOption();
        }
        else if (context.ReadValue<float>() > 0)
        {
            ConversationManager.Instance.SelectPreviousOption();
        }
    }

    private void Siguiente(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() == 1)
        {
            ConversationManager.Instance.SelectNextOption();
        }
    }

    private void Anterior(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() == 1)
        {
            ConversationManager.Instance.SelectPreviousOption();
        }
    }
    public void Conversar()
    {
       ConversationManager.Instance.StartConversation(actualConversation);
    }

    private void ConversationStart()
    {
        control.DesactivarMap();
    }

 
    private void ConversationEnd()
    {
        if (actualConversation == MyConversations[CONVERSACIONALEX])
        {
            conversacionAlexEnd = true;
            control.DesactivarMap();
            control.ActivarMapSoloCamara();
            objeto = GameObject.FindGameObjectWithTag("Revisor");
        }else if (actualConversation == MyConversations[CONVERSACIONREVISOR1])
        {
            conversacionRevEnd = true;
            control.DesactivarMapSoloCamara();
            control.ActivarMap();
        } else if (actualConversation == MyConversations[CONVERSACIONREVISOR2])
        {
            if (ConversationManager.Instance.GetBool("RobaLlave"))
            {
                control.addObjeto(llave);
            }
            if (ConversationManager.Instance.GetBool("Agrede"))
            {
                animRevi.SetBool("alterar", true);
            }
            animRevi.SetBool("hablar", false);
            control.DesactivarMapSoloCamara();
            control.ActivarMap();
        }
        else if(actualConversation == MyConversations[CONVERSACIONCAFE])
        {
            animMaqui.SetBool("hablar", false);
            control.removeObjeto(maquina.getCafe());
            control.DesactivarMapSoloCamara();
            control.ActivarMap();
        }
        else if (actualConversation == MyConversations[CONVERSACIONFINAL])
        {
            animMaqui.SetBool("hablar", false);
            control.removeObjeto(maquina.getCafe());
            control.DesactivarMapSoloCamara();
            control.ActivarMap();
            if(ConversationManager.Instance.GetBool("DaSedante") && ConversationManager.Instance.GetBool("Gana"))
            {
                SceneManager.LoadScene("GameWin");
            }
            else if(ConversationManager.Instance.GetBool("DaSedante") && !ConversationManager.Instance.GetBool("Gana"))
            {
                SceneManager.LoadScene("GameOver");
            }
        }
        else if (actualConversation == MyConversations[CONVERSACIONMAQUINISTA])
        {
            animMaqui.SetBool("hablar", false);
            control.DesactivarMapSoloCamara();
            control.ActivarMap();
        }  
        else if (actualConversation == MyConversations[CONVERSACIONKIT])
        {
            Debug.Log(ConversationManager.Instance.GetBool("CogeSedante"));
            if (ConversationManager.Instance.GetBool("CogeSedante"))
            {
                control.addObjeto(sedante);
            }
            control.DesactivarMapSoloCamara();
            control.ActivarMap();
        }
        else {
            control.DesactivarMapSoloCamara();
            control.ActivarMap();
        }

            
    }

    private void ConversarA(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() == 1 && isPlayerInRange)
        {
            if (control.inventario.objetos.Contains(llave) && objeto.CompareTag("Puerta"))
            {
                puertaRev = true;
                control.removeObjeto(llave);
                imagenInteract.SetActive(false);
            } 
            else if(actualConversation==MyConversations[CONVERSACIONFINAL] || actualConversation == MyConversations[CONVERSACIONMAQUINISTA] || actualConversation == MyConversations[CONVERSACIONCAFE])
            {
                animMaqui.SetBool("hablar", true);
                ConversationManager.Instance.StartConversation(actualConversation);
            }
            else if (actualConversation == MyConversations[CONVERSACIONREVISOR2])
            {
                animRevi.SetBool("hablar", true);
                animRevi.SetBool("parar", false);
                ConversationManager.Instance.StartConversation(actualConversation);
            }
            else
            {
                ConversationManager.Instance.StartConversation(actualConversation);
            }
           
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Revisor") && !control.inventario.objetos.Contains(llave))
        {
            if (conversacionRevEnd)
            {
                //Evan habla con el revisor(en libertad)
                isPlayerInRange = true;
                imagenAviso.SetActive(true);
                actualConversation = MyConversations[CONVERSACIONREVISOR2];
            }
        }
        else if (other.CompareTag("Puerta"))
        {
            if (conversacionRevEnd)
            {
                if (!puertaRev)
                {
                    if (control.inventario.objetos.Contains(llave))
                    {
                        //Evan llega a la puerta con la llave
                        isPlayerInRange = true;
                        imagenInteract.SetActive(true);
                        objeto = other.gameObject;
                    }
                    else
                    {
                        //Evan llega a la puerta sin la llave
                        actualConversation = MyConversations[CONVERSACIONPUERTA];
                        isPlayerInRange = true;
                        imagenAviso.SetActive(true);
                    }
                }
            }
        }
        else if (other.CompareTag("Maquinista"))
        {
            isPlayerInRange = true;
            imagenAviso.SetActive(true);

            if (!control.inventario.objetos.Contains(maquina.getCafe()))
            {
                actualConversation = MyConversations[CONVERSACIONMAQUINISTA];
            }
            else
            {
                actualConversation = control.inventario.objetos.Contains(sedante)
                    ? MyConversations[CONVERSACIONFINAL]
                    : MyConversations[CONVERSACIONCAFE];
            }
        }
        else if (other.CompareTag("Kit"))
        {
            //Evan llega al kit médico
            if (!control.inventario.objetos.Contains(sedante))
            {
                actualConversation = MyConversations[CONVERSACIONKIT];
                isPlayerInRange = true;
                imagenInteract.SetActive(true);
            }
            
        }


    }

    private void OnTriggerExit(Collider other)
    {
        isPlayerInRange = false;
        imagenAviso.SetActive(false);
        imagenInteract.SetActive(false);

    }

        public bool getConversacionAlexEnd()
    {
        return conversacionAlexEnd;
    }
    public bool getConversacionRevEnd()
    {
        return conversacionRevEnd;
    }

}