using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCamara : MonoBehaviour
{
    [Header("Puntos de camara")]
    public GameObject Punto_inicial;

    public GameObject Punto_Opcion;

    private bool reachedGameStartposition;

    private bool reachedOptionPosition;

    private bool canClick;

    private bool backToMainMenu;

    private List<GameObject> camaraPositions = new List<GameObject>();

    private void Awake()
    {
        camaraPositions.Add(Punto_inicial);
    }

    private void Update()
    {
        MoveToPosition();
    }

    void MoveToPosition()
    {
        
        if (camaraPositions.Count > 0)
        {
            
            transform.position = Vector3.Lerp(transform.position, camaraPositions[0].transform.position, 1f * Time.deltaTime);

            transform.rotation = Quaternion.Lerp(transform.rotation, camaraPositions[0].transform.rotation, 1f * Time.deltaTime);


        }
    }

    public void ChangePosition(int _index)
    {
        camaraPositions.RemoveAt(0);

        if(_index == 0)
        {
            camaraPositions.Add(Punto_inicial);
        }
        else if(_index == 1)
        {
            camaraPositions.Add(Punto_Opcion);
        }
    }

    void MoveToGameStartPosition()
    {
        if(!reachedGameStartposition)
        {
            if(Vector3.Distance(transform.position, Punto_inicial.transform.position) < 0.2f)
            {
                reachedGameStartposition = true;

                canClick = true;
            }
        }

        if (!reachedGameStartposition)
        {
            //interpolacion lineal de la camara hacia la posicion inicial de juego
            transform.position = Vector3.Lerp(transform.position, Punto_inicial.transform.position, 1f * Time.deltaTime);

            //rotar linealmente la camara hacia la rotacion inicial del punto inicial de juego
            transform.rotation = Quaternion.Lerp(transform.rotation, Punto_inicial.transform.rotation, 1f * Time.deltaTime);
        }
    }

    void MoveToOptionPositions()
    {

        if (!reachedOptionPosition)
        {
            if (Vector3.Distance(transform.position, Punto_Opcion.transform.position) < 0.2f)
            {
                //Si es el caso, la camara llego a la posicion de opciones
                reachedOptionPosition = true;

                //podemos dar click
                canClick = true;
            }
        }

        if (!reachedOptionPosition)
        {
            //interpolacion lineal de la camara hacia la posicion de opciones
            transform.position = Vector3.Lerp(transform.position, Punto_Opcion.transform.position, 1f * Time.deltaTime);

            //rotar linealmente la camara hacia la rotacion inicial del punto inicial de juego
            transform.rotation = Quaternion.Lerp(transform.rotation, Punto_Opcion.transform.rotation, 1f * Time.deltaTime);


        }
    }

    void MoveBackToMainMenu()
    {
        if (backToMainMenu)
        {
            if (Vector3.Distance(transform.position, Punto_inicial.transform.position) < 0.2f)
            {
                //Si es el caso, no podemos regresar a portada
                backToMainMenu = false;

                //podemos dar click
                canClick = true;
            }
        }


        if (backToMainMenu)
        {
            //interpolacion lineal de la camara hacia la posicion inicial de juego
            transform.position = Vector3.Lerp(transform.position, Punto_inicial.transform.position, 1f * Time.deltaTime);

            //rotar linealmente la camara hacia la rotacion inicial del punto inicial de juego
            transform.rotation = Quaternion.Lerp(transform.rotation, Punto_inicial.transform.rotation, 1f * Time.deltaTime);

        }
    }

    public bool CanClick
    {
        get { return canClick; }
        set { canClick = value; }
    }

    public bool BackToMainMenu
    {
        get { return backToMainMenu; }
        set { backToMainMenu = value; }
    }
}
