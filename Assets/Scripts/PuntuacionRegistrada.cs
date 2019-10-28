using System.Collections;
using System.Collections.Generic;


public class PuntuacionRegistrada
{
    public string nombresUsuario { get; set; }
    public string nombreNivel { get; set; }
    public double tiempoNivel { get; set; }
    public int puntuacionNivel { get; set; }
    public string fecha { get; set; }

    public string ObtenerDescripcion()
    {
        return nombresUsuario + " " + nombreNivel + " " + tiempoNivel.ToString() +
            " " + puntuacionNivel.ToString() + " " + fecha;
    }

}
