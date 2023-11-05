using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Aseg�rate de agregar esta directiva al principio del archivo

public class ButtonSelected : MonoBehaviour
{ 
    [SerializeField] Animator animator;
    //[SerializeField] AnimatorFunctions animatorFunctions;

    public Button button; // Asigna el bot�n a trav�s del Inspector

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
                // El bot�n est� seleccionado
                // Puedes poner aqu� el c�digo que deseas ejecutar cuando el bot�n est� seleccionado.
                
                animator.SetBool("isSelected", true);
                Debug.Log("---------------------------SELECCIONADO---------------------------------");

            }
            else
            {
                // El bot�n no est� seleccionado
                animator.SetBool("isSelected", false);

                //Debug.Log("---------------------------NO SELECCIONADO---------------------------------");

            }
        }
    }
  
}
