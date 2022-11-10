using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class New_Game : MonoBehaviour
{
    public bool pasarNivel;
    public int indiceNivel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cambiarNivel(indiceNivel);
        }

        if(pasarNivel)
        {
            cambiarNivel(indiceNivel);
        }
        
    }

    public void cambiarNivel(int indice)
    {
        SceneManager.LoadScene(indice);
    }
}
