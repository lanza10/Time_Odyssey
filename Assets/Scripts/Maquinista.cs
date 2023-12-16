using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maquinista : MonoBehaviour
{
    Animator anim;
    public GameObject personaje;
    public GameObject Evan;
    Rigidbody rb;
    bool entra = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = personaje.GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EvanProvisional"))
        {
            entra = true;
            StartCoroutine(Levantar());
        }
    }
    IEnumerator Levantar()
    {
        anim.SetBool("levantar", true);
        yield return new WaitForSeconds(2f);
        if(entra)
        {
            rb.MoveRotation(Quaternion.Euler(0.0f, 180f, 0.0f));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("EvanProvisional"))
        {
            entra= false;
            rb.MoveRotation(Quaternion.Euler(0.0f, 0f, 0.0f));
            anim.SetBool("levantar", false);
            
        }
    }
}
