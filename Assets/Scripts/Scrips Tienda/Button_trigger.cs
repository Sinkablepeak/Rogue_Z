using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Button_trigger : MonoBehaviour
{
    public GameObject texto;
    public GameObject Personaje;
    public GameObject Panel_Tienda;

    private Movimiento_Camara movimientoCamara;
    void Awake()
    {//START
        movimientoCamara = Camera.main.GetComponent<Movimiento_Camara>();
    }//END

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            movimientoCamara.ChangePosition(1);
            texto.SetActive(false);
            Panel_Tienda.SetActive(true);
            Personaje.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("hola");

            texto.SetActive(true);
        }   
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag=="Player")
        {
            texto.SetActive(false);
        }
    }
}
