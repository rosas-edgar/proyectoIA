using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeleccionarOpcion : MonoBehaviour
{
    private SeleccionarObjeto seleccionarObjeto = new SeleccionarObjeto(1f);
    private string nombreObjetoSeleccionado;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ObjetoIdentificado();
    }
    public void EstablecerObservado(bool observado)
    {
        seleccionarObjeto.EstablecerObservado(observado);       
    }

    public void EstablecerNombreObjetoSeleccionado(string nombre)
    {
        nombreObjetoSeleccionado = nombre;
    }

    public void ObjetoIdentificado()
    {
        seleccionarObjeto.ObjetoIdentificado(Time.deltaTime);
        if(seleccionarObjeto.Identificado())
        {
            Escena(nombreObjetoSeleccionado);
            //temporal
            enabled = false;
        }
        else
        {
            

        }
    }
    public void Escena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }
}
