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
    private SeleccionarObjeto seleccionarVisual;
    private string nombreObjetoSeleccionado;

    private int permiso = 2; //0 para no, 1 para si, 2 para no definido aun
    // Start is called before the first frame update

    public GameObject objPedir;
    public GameObject objTomar;
    public GameObject objNoTomar;
    public GameObject objSi;
    public GameObject objNo;
    void Awake()
    {
        registrarTiempo = new RegistrarTiempo(25f, 60f);
        seleccionarObjeto = new SeleccionarObjeto(3f);
        seleccionarVisual = new SeleccionarObjeto(1f);
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

    public void EstablecerVisualObservado(bool observado)
    {
        seleccionarVisual.EstablecerObservado(observado);
    }

    public void EstablecerNombreObjetoSeleccionado(string nombre)
    {
        nombreObjetoSeleccionado = nombre;
    }

    public void ObjetoIdentificado()
    {
        seleccionarObjeto.ObjetoIdentificado(Time.deltaTime);
        seleccionarVisual.ObjetoIdentificado(Time.deltaTime);
        if (seleccionarObjeto.Identificado())
        {
            if(nombreObjetoSeleccionado == "Tomar" ) 
            {
                if(permiso == 1) //ya tiene permiso
                {
                    FinConPermiso();
                }
                else if(permiso == 0) //no tiene permiso
                {
                    //tocar audio de que debe pedir permiso antes
                    
                }
            }
            else if (nombreObjetoSeleccionado == "NoTomar")
            {
                if (permiso == 1) //ya tiene permiso
                {
                    Puntuacion.puntuacionNivel += 3;
                    FinConPermiso();
                }
                else if (permiso == 0) //no tiene permiso
                {
                    Puntuacion.puntuacionNivel += 5;
                    FinConPermiso();

                }
            }
        }
        if (seleccionarVisual.Identificado())
        {
            if (nombreObjetoSeleccionado == "Pedir")
            {
                if (permiso == 2)//esta solcitando permiso por primera vez
                {
                    permiso = DecisionPermiso();
                    //mostrar algo que indique el estado del permiso
                    
                }
                else if (permiso == 1) //ya tiene permiso, tocar audio de nuevo?
                {
                    objSi.GetComponent<AudioSource>().Play();
                }
                else if (permiso == 0) //no tiene permiso, tocar audio de nuevo?
                {
                    objNo.GetComponent<AudioSource>().Play();
                }

            }
            else if (nombreObjetoSeleccionado == "Persona")
            {
                if (permiso == 1) //ya tiene permiso
                {

                }
                else if (permiso == 0) //no tiene permiso
                {

                }
                else if (permiso == 2) //no ha solicitado permiso
                {
                    VisibilidadObjeto(true, objPedir);
                }
            }
            else if (nombreObjetoSeleccionado == "Carreola")
            {
                if (permiso == 1) //ya tiene permiso
                {
                    VisibilidadObjeto(true, objTomar);
                    VisibilidadObjeto(true, objNoTomar);
                }
                else if (permiso == 0) //no tiene permiso
                {
                    //audio de recordar pedir permiso
                    objNo.GetComponent<AudioSource>().Play();
                    VisibilidadObjeto(true, objTomar);
                    VisibilidadObjeto(true, objNoTomar);
                }
                else if (permiso == 2) //no ha solicitado permiso
                {
                    //audio de pedir permiso
                }
            }
        }

    }

    private void FinConPermiso()
    {
        int puntuacion = registrarTiempo.ObtenerPuntuacion(Time.timeSinceLevelLoad);
        double tiempoObj = registrarTiempo.ObtenerTiempoObjetivo();
        Puntuacion.puntuacionNivel += puntuacion;
        Puntuacion.tiempoNivel += tiempoObj;
        RegistrarPuntuacion("Nivel 2");
        SceneManager.LoadScene(escenaSiguiente);
    }

    private int DecisionPermiso()
    {
        int r = Random.Range(0, 100);
        if (r > 35)
        {
            VisibilidadObjeto(true, objSi);
            return 1; //si permiso 
        }
        else
        {
            VisibilidadObjeto(true, objNo);
            return 0; //no
        }
            
    }
    public void RegistrarPuntuacion(string nivel)
    {
        SqliteHelper db = new SqliteHelper();
        db.NuevaPuntuacion(nivel, Puntuacion.usuario.ObtenerID(), Puntuacion.tiempoNivel,
            Puntuacion.puntuacionNivel, System.DateTime.Today.ToShortDateString());
        Puntuacion.tiempoNivel = 0;
        Puntuacion.puntuacionNivel = 0;
    }

    public void VisibilidadObjeto(bool visible, GameObject objeto)
    {

        objeto.SetActive(visible);
    }
}
