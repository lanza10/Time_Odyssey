using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using DialogueEditor;

public class Dialog : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isPlayerInRange;
    private Map _playersControl = null;
    public NPCConversation myConversation;

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
        _playersControl.Exploracion.Conversar.canceled += Conversar;
    }
    // Update is called once per frame
    void Update()
    {
        
    }



    private void Conversar(InputAction.CallbackContext context) {
        if (isPlayerInRange) {
            ConversationManager.Instance.StartConversation(myConversation);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        isPlayerInRange = true;
        
    }

    private void OnTriggerExit(Collider other)
    {
        isPlayerInRange = false;
    }
}
