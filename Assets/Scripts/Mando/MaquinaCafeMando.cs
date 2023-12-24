using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MaquinaCafeMando : MonoBehaviour
{
    private GameObject cafe;
    public CharacterControlMando evan;
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EvanProvisional"))
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
