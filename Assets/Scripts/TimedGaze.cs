﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedGaze : MonoBehaviour
{
    public GameObject textoIdentificado;
    public bool siendoObservado = false;
    //cuantos segundos debe ser observado 
    public float duracionTiempo = 1f;
    //cuantos segundos ha sido observado
    public float tiempoObservado = 0f;

    // Start is called before the first frame update
    void Start()
    {
        textoIdentificado.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        IdentificarObjeto();
        
    }
    //Establece si el objeto esta siendo observado o no
    //El parametro sera enviado desde el evento
    //PointerEnter = true, PointerLeave = false
    public void EstablecerObservado(bool observado)
    {
        siendoObservado = observado;
    }

    private void IdentificarObjeto()
    {
        if(siendoObservado)
        {
            tiempoObservado += Time.deltaTime;
            if(tiempoObservado > duracionTiempo)
            {
                textoIdentificado.SetActive(true);
                //Debug.Log("Objeto identificado");
            }

        }
        else
        {
            tiempoObservado = 0f;
            //Debug.Log("Objeto fuera de vista");
        }
    }
}
