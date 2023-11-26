using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DialogueEditor;
using System;
using Unity.VisualScripting;

public class DialogInit : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterControl control;
    private Map _playersControl = null;
    public NPCConversation[] MyConversations;
    public NPCConversation actualConversation;
    public ConversationManager convMan;
    private bool conversacionAlexEnd = false;
    private bool conversacionRevEnd = false;
    public bool esRevisor;
    private GameObject objeto;

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
        _playersControl = new Map();
        _playersControl.Conversacion.Confirmar.performed += Confirmar;
        _playersControl.Conversacion.Siguiente.performed += Siguiente;
        _playersControl.Conversacion.Anterior.performed += Anterior;
        _playersControl.Conversacion.Opcion.performed += CambiaOpcion;

    }
    // Update is called once per frame


    void Update()
    {
        if(objeto == GameObject.FindGameObjectWithTag("Alex"))
        {
            esRevisor = false;
            actualConversation = MyConversations[0];
        }
        else
        {
            esRevisor = true;
            actualConversation = MyConversations[1];
        }
    }
    private void Start()
    {
        objeto = GameObject.FindGameObjectWithTag("Alex");
        actualConversation = MyConversations[0];
        Conversar();
    }
    private void Confirmar(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() == 1)
        {
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
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("EvanProvisional"))
        {

            if(!conversacionAlexEnd && this.gameObject.name == "AlexProvisional")
            {
                Conversar();
            }
            Debug.Log("Entr� al colllider");
        }
       

    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("EvanProvisional"))
        {
            
            Debug.Log("Sali� del colllider");
        }
    }

    private void ConversationStart()
    {
        control.DesactivarMap();
    }

 
    private void ConversationEnd()
    {
        if (!esRevisor)
        {
            conversacionAlexEnd = true;
            control.ActivarMap();
            objeto = GameObject.FindGameObjectWithTag("Revisor");
        }else
        {
            conversacionRevEnd = true;
            control.ActivarMap();
        }
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