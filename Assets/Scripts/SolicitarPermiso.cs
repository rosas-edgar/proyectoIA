using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SolicitarPermiso : MonoBehaviour
{
    public string escenaSiguiente;
    public string escenaPrevia;
    public RegistrarTiempo registrarTiempo;
    private SeleccionarObjeto seleccionarObjeto;
    private string nombreObjetoSeleccionado;

    private int permiso = 2; //0 para no, 1 para si, 2 para no definido aun
    // Start is called before the first frame update
    void Awake()
    {
        registrarTiempo = new RegistrarTiempo(25f, 60f);
        seleccionarObjeto = new SeleccionarObjeto(3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (registrarTiempo.ExcedioTiempoMaximo(Time.timeSinceLevelLoad) && !seleccionarObjeto.Identificado())
        {
            //regresar
            SceneManager.LoadScene(escenaPrevia);

        }
        else
        {
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
        Debug.Log(permiso + nombreObjetoSeleccionado + " Observando");
        if (seleccionarObjeto.Identificado())
        {
            Debug.Log(permiso + nombreObjetoSeleccionado + "Identificado");
            if(nombreObjetoSeleccionado == "Permiso" && permiso == 2) //esta solcitando permiso por primera vez
            {
                permiso = DecisionPermiso();
                //mostrar algo que indique el estado del permiso
            }

            if(nombreObjetoSeleccionado == "Objeto" ) 
            {
                if(permiso == 1) //ya tiene permiso
                {
                    Debug.Log(permiso + nombreObjetoSeleccionado + "Con permiso");
                    int puntuacion = registrarTiempo.ObtenerPuntuacion(Time.timeSinceLevelLoad);
                    double tiempoObj = registrarTiempo.ObtenerTiempoObjetivo();
                    Puntuacion.puntuacionNivel = puntuacion;
                    Puntuacion.tiempoNivel += tiempoObj;
                    RegistrarPuntuacion("Nivel 2");
                    SceneManager.LoadScene(escenaSiguiente);
                }
                else if(permiso == 0 || permiso == 2) //no tiene permiso o no ha solicitado
                {
                    Debug.Log(permiso + nombreObjetoSeleccionado + "Sin permiso");
                    //tocar audio de que debe pedir permiso antes
                    SceneManager.LoadScene(escenaPrevia);
                }
            }

        }
        else
        {
            

        }
    }

    private int DecisionPermiso()
    {
        int r = Random.Range(0, 100);
        if (r > 30) return 1; //si permiso
        else return 0; //no
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
