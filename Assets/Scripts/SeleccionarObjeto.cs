using System.Collections;
using System.Collections.Generic;

public class SeleccionarObjeto 
{
    private bool siendoObservado = false;
    //cuantos segundos debe ser observado 
    private float duracionTiempo;
    //cuantos segundos ha sido observado
    private float tiempoObservado = 0f;
    private bool identificado = false;

    public SeleccionarObjeto(float duracionTiempo){
        this.duracionTiempo = duracionTiempo;
    }

    public void EstablecerObservado(bool observado){
        siendoObservado = observado;
    }

    public bool Identificado(){
        return identificado;
    }

    public void ObjetoIdentificado(float deltaTiempo)
    {
        if(siendoObservado)
        {
            tiempoObservado += deltaTiempo;
            if(tiempoObservado > duracionTiempo)
            {
                identificado = true;
            }
            else 
                identificado = false;
        }
        else
        {
            tiempoObservado = 0f;
        }
    }

}
