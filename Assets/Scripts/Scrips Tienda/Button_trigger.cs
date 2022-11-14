using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Button_trigger : MonoBehaviour
{
    public GameObject texto;
    public GameObject boton;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        { 
            texto.SetActive(false);
            boton.SetActive(true);
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
            boton.SetActive(false);
        }
    }
}
