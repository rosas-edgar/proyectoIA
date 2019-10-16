using System.Collections;
using System.Collections.Generic;

public class RegistrarTiempo
{
    private float tiempoObjetivo;
    private float tiempoMinimo;
    private float tiempoMaximo;

    public RegistrarTiempo(float tiempoMin, float tiempoMax)
    {
        tiempoMinimo = tiempoMin;
        tiempoMaximo = tiempoMax;
    }

    public float ObtenerTiempoObjetivo()
    {
        return tiempoObjetivo;
    }

    public int ObtenerPuntuacion(float tiempoObj)
    {
        tiempoObjetivo = (int)(tiempoObj * 100.0f) / 100.0f;
        //tiempoObjetivo = Time.time;
        if(tiempoObjetivo <= tiempoMinimo){
            //regresa la puntuacion maxima
            return 10;
        }
        //entre el tiempo minimo y el tiempo maximo
        else if(tiempoMinimo < tiempoObjetivo && tiempoObjetivo < tiempoMaximo){
            return 5;
        }
        else{
            return 0;
        }

    }
    //durante el update de la escena de identificar objetos por tiempo
    public bool ExcedioTiempoMaximo(float tiempoActual){
        if(tiempoActual > tiempoMaximo){
            return true;
        }
        else{
            return false;
        }
    }
}
