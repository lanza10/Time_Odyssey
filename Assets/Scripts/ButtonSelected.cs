using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Asegúrate de agregar esta directiva al principio del archivo

public class ButtonSelected : MonoBehaviour
{ 
    [SerializeField] Animator animator;
    //[SerializeField] AnimatorFunctions animatorFunctions;

    public Button button; // Asigna el botón a través del Inspector

    private void Start() 
    {
       
    }

    private void Update()
    {
        if (button != null)
        {
            Debug.Log(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name + " ");
            if (button.name == UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name)
                //button.IsInteractable() && button.navigation.mode == Navigation.Mode.Explicit)
            {
                // El botón está seleccionado
                // Puedes poner aquí el código que deseas ejecutar cuando el botón está seleccionado.
                
                animator.SetBool("isSelected", true);
                Debug.Log("---------------------------SELECCIONADO---------------------------------");

            }
            else
            {
                // El botón no está seleccionado
                animator.SetBool("isSelected", false);

                //Debug.Log("---------------------------NO SELECCIONADO---------------------------------");

            }
        }
    }
  
}
