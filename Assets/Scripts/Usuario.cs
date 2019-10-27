using System.Collections;
using System.Collections.Generic;
using System;

public class Usuario
{
    private int idUsuario;
    public string nombreUsuario { get; set; }
    public string apellidoUsuario { get; set; }

    public Usuario(){

    }

    public Usuario(int id, string nombre, string apellido){
        idUsuario = id;
        nombreUsuario = nombre;
        apellidoUsuario = apellido;
    }

    public void EstablecerIdUsuario(string id){
        idUsuario = Int32.Parse(id);
    }

    public void EstablecerNombres(string nombre, string apellido){
        nombreUsuario = nombre;
        apellidoUsuario = apellido;
    }

    public int ObtenerID(){
        return idUsuario;
    }
    public string ObtenerNombres(){
        return nombreUsuario + " " + apellidoUsuario;
    }

}
