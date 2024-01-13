using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

public class MaquinaCafe : MonoBehaviour
{
    private GameObject cafe;
    public CharacterControl evan;
    public GameObject imagenInteract;
    bool isPlayerInRange = false;
    private Map _playersControl = null;


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

        cafe = new GameObject();
        cafe.name = "Cafe";
        _playersControl = new Map();
        _playersControl.Exploracion.Conversar.performed += ObtenerCafe;
    }
    private void ObtenerCafe(InputAction.CallbackContext context)
    {
        if (context.ReadValue<float>() == 1 && isPlayerInRange)
        {
            if (!evan.inventario.objetos.Contains(cafe))
            {
                evan.addObjeto(cafe);
            }
            imagenInteract.SetActive(false);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("EvanProvisional") && !evan.inventario.objetos.Contains(cafe))
        {
            isPlayerInRange = true;
            imagenInteract.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isPlayerInRange = false;
        imagenInteract.SetActive(false);

    }

    public GameObject getCafe()
    {
        return cafe;
    }
}
