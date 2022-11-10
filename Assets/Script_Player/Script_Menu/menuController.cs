using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuController : MonoBehaviour
{
    [Header("Paneles de UI")]
    public GameObject menuPanel;

    public GameObject optionsPanel;

    public GameObject configurationPanel;


    public void StartGame()
    {
        menuPanel.SetActive(true);
    }

    public void OptionsPanel()
    {
        optionsPanel.SetActive(true);

        menuPanel.SetActive(false);
    }

    public void ConfigurationPanel()
    {
        configurationPanel.SetActive(true);

        optionsPanel.SetActive(false);
    }

    public void Confirm()
    {
        optionsPanel.SetActive(false);

        menuPanel.SetActive(true);
    }

    public void Aceptar()
    {
        configurationPanel.SetActive(false);

        optionsPanel.SetActive(true);
    }

    public void SetResolution()
    {
        //Llamar a un metodo que se encarga de cambiar las resoluciones 
        ChangeResolution();
    }

    //metodo encargado de cambiar resoluciones
    void ChangeResolution()
    {
        //Indice local que surge de la seleccione de un gameobject en el engine
        string _resolutionIndex = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        //switch para abordar casos del string
        switch (_resolutionIndex)
        {
            //caso 1: boton 0 
            case "1152 x 648":
                //Vamos a accerder a la funcionalidad de resoluciones de pantalla para asignar una resolucion especifica
                //el SetResolution se llena (W, H, pantalla completa? Y/N)
                Screen.SetResolution(1152, 648, true);
                break;

            //caso 2: boton 1
            case "1280 x 720":
                //Asignar resolucion 1280 x 720
                Screen.SetResolution(1280, 720, true);
                break;

            //caso 3: boton 2
            case "1360 x 768":
                //Asignar resolucion 1360 x 768
                Screen.SetResolution(1360, 768, true);
                break;

            //caso 4: boton 3
            case "1920 x 1080":
                //Asignar resolucion 1920 x 1080
                Screen.SetResolution(1920, 1080, true);
                break;
        }
    }
}
