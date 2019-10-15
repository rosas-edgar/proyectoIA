using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegistrarTiempo : MonoBehaviour
{
    public float tiempoObjetivo = 0f;
    public float tiempoMinimo = 5f;
    public float tiempoMaximo = 60f;

    public static int ObtenerPuntuacion()
    {
        tiempoObjetivo = Time.time;
        if(tiempoObjetivo <= tiempoMinimo){
            //regresa la puntuacion maxima
            return 10;
        }
        else if(tiempoMinimo < tiempoObjetivo && tiempoObjetivo < tiempoMaximo){
            return 5;
        }
        else{
            return 0;
        }

    }
}
