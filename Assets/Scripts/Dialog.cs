using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DialogueEditor;
using System;
using Unity.VisualScripting;

public class Dialog : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterControl control;
    private bool isPlayerInRange;
    private Map _playersControl = null;
    public NPCConversation MyConversation;
    public ConversationManager convMan;
    public bool conversacionAlexEnd = false;
    public GameObject imagenAviso;


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
        _playersControl = new Map();
        _playersControl.Exploracion.Conversar.performed += Conversar;
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
    private void Conversar(InputAction.CallbackContext context) {
        if (context.ReadValue<float>() == 1 && isPlayerInRange) {
            
            ConversationManager.Instance.StartConversation(MyConversation);
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("EvanProvisional")) {
            isPlayerInRange = true;
            imagenAviso.SetActive(true);
            Debug.Log("Entró al colllider");
        }
        
        
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("EvanProvisional"))
        {
            isPlayerInRange = false;
            imagenAviso.SetActive(false);
            Debug.Log("Salió del colllider");
        }
    }

    private void ConversationStart()
    {
        control.DesactivarMap();
    }

    private void ConversationEnd()
    {
        if (this.gameObject.name == "AlexProvisional")
        {
            conversacionAlexEnd = true;
        }
        control.ActivarMap();
    }

    public bool getConversacionAlexEnd()
    {
        return conversacionAlexEnd;
    }

    

}
