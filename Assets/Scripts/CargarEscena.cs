using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargarEscena : MonoBehaviour
{
    public void Escena(string nombreEscena)
    {
        if (nombreEscena == "E1O1" || nombreEscena == "E2O1")
        {
            TiempoTransicion.siguienteEscena = nombreEscena;
            SceneManager.LoadScene("CambioRV");
        }
        else
        {
            SceneManager.LoadScene(nombreEscena);
        }
        
    }

}
