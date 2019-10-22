using System.Collections;
using System.Collections.Generic;

public class Puntuacion 
{
    private int idNivel;
    private int idUsuario;
    private double tiempoNivel;
    private int puntuacionNivel;
    private string fecha;

    public Puntuacion(int nivel, int usuario, double tiempo,
                        int puntuacion, string fecha)
            {
                idNivel = nivel;
                idUsuario = usuario;
                tiempoNivel = tiempo;
                puntuacionNivel = puntuacion;
                this.fecha = fecha;

            }

}
