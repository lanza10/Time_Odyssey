using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DialogueEditor;
using System;

public class Dialog : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isPlayerInRange;
    private Map _playersControl = null;
    public NPCConversation MyConversation;
    public ConversationManager convMan;

    private void OnEnable()
    {
        _playersControl.Enable();
    }

    private void OnDisable()
    {
        _playersControl.Disable();
    }

    private void Awake()
    {
        _playersControl = new Map();
        _playersControl.Exploracion.Conversar.performed += Conversar;
       
    }
    // Update is called once per frame
    void Update()
    {
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
            Debug.Log("Entró al colllider");
        }
        
        
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("EvanProvisional"))
        {
            isPlayerInRange = false;
            Debug.Log("Salió del colllider");
        }
    }
}
