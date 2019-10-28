using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IdentificarObjeto : MonoBehaviour
{
    public Text textoIdentificado;
    public string escenaSiguiente;
    public string escenaPrevia;
    public RegistrarTiempo registrarTiempo;
    private SeleccionarObjeto seleccionarObjeto;
    private string nombreObjetoSeleccionado;

    // Start is called before the first frame update
    void Awake()
    {
        registrarTiempo = new RegistrarTiempo(5f, 25f);
        seleccionarObjeto = new SeleccionarObjeto(3f);
    }

    // Update is called once per frame
    void Update()
    {
        if(registrarTiempo.ExcedioTiempoMaximo(Time.timeSinceLevelLoad) && !seleccionarObjeto.Identificado())
        {
            //regresar
            textoIdentificado.text = "Tiempo excedido";
            SceneManager.LoadScene(escenaPrevia);

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
            int puntuacion = registrarTiempo.ObtenerPuntuacion(Time.timeSinceLevelLoad);
            double tiempoObj = registrarTiempo.ObtenerTiempoObjetivo();
            Puntuacion.puntuacionNivel = puntuacion;
            Puntuacion.tiempoNivel += tiempoObj;
            SceneManager.LoadScene(escenaSiguiente);
            //temporal
            enabled = false;
        }
        else
        {
            textoIdentificado.text = "";

        }
    }
}
