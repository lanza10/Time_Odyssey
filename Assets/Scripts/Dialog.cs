using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DialogueEditor;
using System;
using Unity.VisualScripting;
using System.Numerics;

public class Dialog : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterControl control;
    private Map _playersControl = null;
    public NPCConversation[] MyConversations;
    public NPCConversation actualConversation;
    private bool conversacionAlexEnd = false;
    private bool conversacionRevEnd = false;
    public bool esRevisor;
    private GameObject objeto;
    public GameObject imagenAviso;
    private bool isPlayerInRange;


    private const int CONVERSACIONALEX = 0;
    private const int CONVERSACIONREVISOR1 = 1;

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
        _playersControl.Exploracion.Conversar.performed += ConversarA;
        _playersControl.Conversacion.Confirmar.performed += Confirmar;
        _playersControl.Conversacion.Siguiente.performed += Siguiente;
        _playersControl.Conversacion.Anterior.performed += Anterior;
        _playersControl.Conversacion.Opcion.performed += CambiaOpcion;

    }
    void Update()
    {
        if (objeto == GameObject.FindGameObjectWithTag("Alex"))
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
        }
        else if (actualConversation == MyConversations[CONVERSACIONREVISOR1])
        {
            conversacionRevEnd = true;
            control.DesactivarMapSoloCamara();
            control.ActivarMap();
        }
    }
    private void ConversarA(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() == 1 && isPlayerInRange)
        {
            ConversationManager.Instance.StartConversation(actualConversation);
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