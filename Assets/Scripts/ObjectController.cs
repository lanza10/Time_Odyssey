using DialogueEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectController : MonoBehaviour
{
    private bool isPlayerInRange;
    public CharacterControl player;
    private Map _playersControl = null;
    public Material materialAccionable;
    public Material materialObjeto;
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
        _playersControl.Exploracion.Coger.performed += Coger;
    }
    private void Coger(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() == 1 && isPlayerInRange)
        {
            player.addObjeto(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("EvanProvisional"))
        {
            isPlayerInRange = true;
            this.gameObject.GetComponent<MeshRenderer>() .material= materialAccionable;
            Debug.Log("Entró al colllider");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("EvanProvisional"))
        {
            isPlayerInRange = false;
            this.gameObject.GetComponent<MeshRenderer>().material = materialObjeto;
            Debug.Log("Salió del colllider");
        }
    }
}
