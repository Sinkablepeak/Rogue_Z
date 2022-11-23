using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_Camara : MonoBehaviour
{//Inicio de clase Main_Menu
    //variables Publicas
    [Header("Puntos de Camara")]
    public GameObject PosicionInicial;
    public GameObject Tienda;
    public GameObject Objeto1;
    public GameObject Objeto2;
    public GameObject Objeto3;
    public GameObject Objeto4;


    private List<GameObject> cameraPositions = new List<GameObject>();

    void Awake()
    {
        cameraPositions.Add(PosicionInicial);
    }

    void Update()
    {

        MoveToPosition();
    }

    void MoveToPosition()
    {//
        if (cameraPositions.Count > 0)
        {//

            transform.position = Vector3.Lerp(transform.position,
                                            cameraPositions[0].transform.position,
                                            1f * Time.deltaTime);

            transform.rotation = Quaternion.Lerp(transform.rotation,
                                            cameraPositions[0].transform.rotation,
                                            1f * Time.deltaTime);

        }//
    }//

    public void ChangePosition(int _index)
    {//
        cameraPositions.RemoveAt(0);

        if (_index == 0)
        {//
            cameraPositions.Add(PosicionInicial);
        }//
        else if (_index == 1)
        {//
            cameraPositions.Add(Tienda);
        }//
        else if (_index == 2)
        {//
            cameraPositions.Add(Objeto1);
        }//
        else if (_index == 3)
        {//
            cameraPositions.Add(Objeto2);
        }//
        else if (_index == 4)
        {//
            cameraPositions.Add(Objeto3);
        }//
        else if (_index == 5)
        {//
            cameraPositions.Add(Objeto4);
        }//

    }//

}//Fin de clase Main_Menu