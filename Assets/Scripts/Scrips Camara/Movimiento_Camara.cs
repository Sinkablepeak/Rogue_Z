using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_Camara : MonoBehaviour
{//Inicio de clase Main_Menu
    //variables Publicas
    [Header("Puntos de Camara")]
    public GameObject gameStartPosition;
    public GameObject characterSelectPosition;

    private List<GameObject> cameraPositions = new List<GameObject>();

    void Awake()
    {
        cameraPositions.Add(gameStartPosition);
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
            cameraPositions.Add(gameStartPosition);
        }//
        else if (_index == 1)
        {//
            cameraPositions.Add(characterSelectPosition);
        }//

    }//

}//Fin de clase Main_Menu