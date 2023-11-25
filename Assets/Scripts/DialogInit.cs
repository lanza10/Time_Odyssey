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
    public NPCConversation MyConversation;
    public ConversationManager convMan;
    private bool conversacionAlexEnd = false;
    private bool conversacionRevEnd = false;
    public bool esRevisor;

    private void OnEnable()
    {
        _playersControl.Enable();
        if(!esRevisor)
        {
            ConversationManager.OnConversationStarted += ConversationAlexStart;
            ConversationManager.OnConversationEnded += ConversationAlexEnd;
        }
        else
        {
            ConversationManager.OnConversationStarted += ConversationRevStart;
            ConversationManager.OnConversationEnded += ConversationRevEnd;
        }



    }

    private void OnDisable()
    {
        _playersControl.Disable();
        if (!esRevisor)
        {
            ConversationManager.OnConversationStarted -= ConversationAlexStart;
            ConversationManager.OnConversationEnded -= ConversationAlexEnd;
        }
        else
        {
            ConversationManager.OnConversationStarted -= ConversationRevStart;
            ConversationManager.OnConversationEnded -= ConversationRevEnd;
        }
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
       Debug.Log('A');
       ConversationManager.Instance.StartConversation(MyConversation);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("EvanProvisional"))
        {

            if(!conversacionAlexEnd && this.gameObject.name == "AlexProvisional")
            {
                Conversar();
            }
            Debug.Log("Entró al colllider");
        }
       

    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("EvanProvisional"))
        {
            
            Debug.Log("Salió del colllider");
        }
    }

    private void ConversationAlexStart()
    {
        control.DesactivarMap();
    }

   
    private void ConversationRevStart()
    {
        control.DesactivarMap();
    }
    private void ConversationAlexEnd()
    {
        if (!esRevisor)
        {
            conversacionAlexEnd = true;
            control.ActivarMap();
        }
    }

    private void ConversationRevEnd()
    {
        if (esRevisor)
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