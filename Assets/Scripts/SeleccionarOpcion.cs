using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeleccionarOpcion : MonoBehaviour
{
    private SeleccionarObjeto seleccionarObjeto = new SeleccionarObjeto(1f);
    private string nombreObjetoSeleccionado;
    private string nombreNivel = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ObjetoIdentificado();
    }
    public void EstablecerNombreNivel(string nivel)
    {
        nombreNivel = nivel;
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
            double tiempo = Time.timeSinceLevelLoad;
            Puntuacion.tiempoNivel += System.Math.Round(tiempo, 2);
            if (nombreNivel != "") RegistrarPuntuacion(nombreNivel);
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
    public void RegistrarPuntuacion(string nivel)
    {
        SqliteHelper db = new SqliteHelper();
        db.NuevaPuntuacion(nivel, Puntuacion.usuario.ObtenerID(), Puntuacion.tiempoNivel,
            Puntuacion.puntuacionNivel, System.DateTime.Today.ToShortDateString());
        Puntuacion.tiempoNivel = 0;
        Puntuacion.puntuacionNivel = 0;
    }
}
