using System.Collections;
using System.Collections.Generic;
using System;

public class Usuario
{
    private int idUsuario;
    private string nombreUsuario;

    public Usuario(){

    }

    public Usuario(int id, string nombre){
        idUsuario = id;
        nombreUsuario = nombre;
    }

    public void EstablecerIdUsuario(string id){
        idUsuario = Int32.Parse(id);
    }

    public void EstablecerNombre(string nombre){
        nombreUsuario = nombre;
    }

    public int ObtenerID(){
        return idUsuario;
    }
    public string ObtenerNombre(){
        return nombreUsuario;
    }

}
