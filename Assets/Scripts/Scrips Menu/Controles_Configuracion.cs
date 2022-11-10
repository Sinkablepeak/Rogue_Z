using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Controles_Configuracion : MonoBehaviour
{

    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    public TextMeshProUGUI Adelante, Atras, Derecha, Izquierda, Salto;

    private GameObject currentKey;

    void Start()
    {
        keys.Add("Adelante", KeyCode.W);
        keys.Add("Atras", KeyCode.S);
        keys.Add("Derecha", KeyCode.D);
        keys.Add("Izquierda", KeyCode.A);
        keys.Add("Salto", KeyCode.Space);

        Adelante.text = keys["Adelante"].ToString();
        Atras.text = keys["Atras"].ToString();
        Derecha.text = keys["Derecha"].ToString();
        Izquierda.text = keys["Izquierda"].ToString();
        Salto.text = keys["Salto"].ToString();

    }


    private void OnGUI()
    {
        if(currentKey != null) 
        {
            Event e = Event.current;
            if(e.isKey)
            {
                keys[currentKey.name] = e.keyCode;
                currentKey.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = e.keyCode.ToString();
                currentKey = null;

            }
        }
        
    }

    public void Cambio(GameObject clicked)
    {

        currentKey = clicked;

    }
}
