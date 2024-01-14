using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public List<GameObject> objetos = new List<GameObject>();
    private GameObject llave;
    private GameObject sedante;
    private GameObject cafe;

    public GameObject llaveInterfaz;
    public GameObject sedanteInterfaz;
    public GameObject cafeInterfaz;
    private void Start()
    {
        llave = GameObject.Find("Llave");
        cafe = GameObject.Find("Cafe");
        sedante = GameObject.Find("Sedante");
    }

    private void Update()
    {
        if(objetos.Contains(llave))
        {
            llaveInterfaz.SetActive(true);
        }
        if (objetos.Contains(cafe))
        {
            cafeInterfaz.SetActive(true);
        }
        if (objetos.Contains(sedante))
        {
            sedanteInterfaz.SetActive(true);
        }
    }
}
