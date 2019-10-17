using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IdentificarObjeto : MonoBehaviour
{
    public Text textoIdentificado;
    public RegistrarTiempo registrarTiempo = new RegistrarTiempo(5f, 60f);
    private SeleccionarObjeto seleccionarObjeto = new SeleccionarObjeto(3f);
    private string nombreObjetoSeleccionado;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(registrarTiempo.ExcedioTiempoMaximo(Time.time) && !seleccionarObjeto.Identificado())
        {
            //regresar
            textoIdentificado.text = "Tiempo excedido";

        }
        else{
            ObjetoIdentificado();
        }      
    }
    //Establece si el objeto esta siendo observado o no
    //El parametro sera enviado desde el evento
    //PointerEnter = true, PointerLeave = false
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
            textoIdentificado.text = nombreObjetoSeleccionado + " ," 
            + registrarTiempo.ObtenerPuntuacion(Time.time).ToString() + ","
            + registrarTiempo.ObtenerTiempoObjetivo().ToString();
            SceneManager.LoadScene("E1O3");
            //temporal
            enabled = false;
        }
        else
        {
            textoIdentificado.text = "";

        }
    }
}
