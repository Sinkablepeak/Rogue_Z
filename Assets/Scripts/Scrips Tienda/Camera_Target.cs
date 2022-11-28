using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Target : MonoBehaviour
{//START

    [Header("Páneles de UI")]
    public GameObject Personaje;
    public GameObject Panel_Tienda;
    public GameObject Panel_Objeto1;
    public GameObject Panel_Objeto2;
    public GameObject Panel_Objeto3;
    public GameObject Panel_Objeto4;
    public GameObject Panel_Mejoras;

    private Movimiento_Camara movimientoCamara;


    void Awake()
    {//START
        movimientoCamara = Camera.main.GetComponent<Movimiento_Camara>();
    }//END

    public void Tienda()
    {//START
        movimientoCamara.ChangePosition(1);

        Panel_Tienda.SetActive(true);
        Personaje.SetActive(false);
    }//END

    public void Objeto1()
    {//START
        movimientoCamara.ChangePosition(2);

        Panel_Tienda.SetActive(false);

        Panel_Objeto1.SetActive(true);
    }//END
    public void Objeto2()
    {//START
        movimientoCamara.ChangePosition(3);

        Panel_Tienda.SetActive(false);

        Panel_Objeto2.SetActive(true);
    }//END
    public void Objeto3()
    {//START
        movimientoCamara.ChangePosition(4);

        Panel_Tienda.SetActive(false);

        Panel_Objeto3.SetActive(true);
    }//END
    public void Objeto4()
    {//START
        movimientoCamara.ChangePosition(5);

        Panel_Tienda.SetActive(false);

        Panel_Objeto4.SetActive(true);
    }//END
    public void Mejoras()
    {//START
        Panel_Tienda.SetActive(false);

        Panel_Mejoras.SetActive(true);
    }//END
    public void Atras_Mejoras()
    {//START
        Panel_Tienda.SetActive(true);

        Panel_Mejoras.SetActive(false);
    }//END

    public void Atras_Ob1()
    {//START
        movimientoCamara.ChangePosition(1);
        Panel_Tienda.SetActive(true);
        Panel_Objeto1.SetActive(false);
    }//END
    public void Atras_Ob2()
    {//START
        movimientoCamara.ChangePosition(1);
        Panel_Tienda.SetActive(true);
        Panel_Objeto2.SetActive(false);
    }//END
    public void Atras_Ob3()
    {//START
        movimientoCamara.ChangePosition(1);
        Panel_Tienda.SetActive(true);
        Panel_Objeto3.SetActive(false);
    }//END
    public void Atras_Ob4()
    {//START
        movimientoCamara.ChangePosition(1);
        Panel_Tienda.SetActive(true);
        Panel_Objeto4.SetActive(false);
    }//END
    public void Confirmar()
    {//START
        movimientoCamara.ChangePosition(0);
        Panel_Tienda.SetActive(false);
        Personaje.SetActive(true);

    }//END

}//END