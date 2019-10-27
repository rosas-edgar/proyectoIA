using UnityEngine;
using System.Data;
using System.Collections.Generic;
using System.Collections;
using Mono.Data.Sqlite;
using System.IO;

public class SqliteHelper
{
    private const string Tag = "Riz: SqliteHelper:\t";

    private const string database_name = "Pasitos_sociales";

    public string db_connection_string;
    public IDbConnection db_connection;

    public SqliteHelper()
    {
        db_connection_string = "URI=file:" + Application.persistentDataPath + "/" + database_name;
        Debug.Log("db_connection_string" + db_connection_string);
        db_connection = new SqliteConnection(db_connection_string);       
    }

    ~SqliteHelper()
    {
        db_connection.Close();
    }
    public void close ()
    {
        db_connection.Close ();
	}
    // Start is called before the first frame update
    public void CrearBD()
    {
        db_connection.Open();
		// Create table
		IDbCommand dbcmd_usuario;
		dbcmd_usuario = db_connection.CreateCommand();
		string q_crearTablaUsuario = "CREATE TABLE IF NOT EXISTS Usuario(idUsuario INTEGER PRIMARY KEY," +
         "nombreUsuario NVARCHAR(45), apellidoUsuario NVARCHAR(45))";
		
		dbcmd_usuario.CommandText = q_crearTablaUsuario;
		dbcmd_usuario.ExecuteReader();
       

        // Create table
		IDbCommand dbcmd_puntuacion;
		dbcmd_puntuacion = db_connection.CreateCommand();
		string q_crearTablaPuntuacion = "CREATE TABLE IF NOT EXISTS Puntuacion(nombreNivel VARCHAR(50)," +
         "idUsuario INTEGER, tiempoNivel DOUBLE, puntuacionNivel INTEGER, fecha VARCHAR(12))";
		
		dbcmd_puntuacion.CommandText = q_crearTablaPuntuacion;
		dbcmd_puntuacion.ExecuteReader();    
        close();   
    }

    public void EliminarTablas()
    {
        db_connection.Open();

		// Create table
		IDbCommand dbcmd_usuario;
		dbcmd_usuario = db_connection.CreateCommand();
		string q_eliminarTablaUsuario = "DROP TABLE Usuario";
		
		dbcmd_usuario.CommandText = q_eliminarTablaUsuario;
		dbcmd_usuario.ExecuteReader();
       

        // Create table
		IDbCommand dbcmd_puntuacion;
		dbcmd_puntuacion = db_connection.CreateCommand();
		string q_eliminarTablaPuntuacion = "DROP TABLE Puntuacion";
		
		dbcmd_puntuacion.CommandText = q_eliminarTablaPuntuacion;
		dbcmd_puntuacion.ExecuteReader();
        close();
    }

    public void NuevaPuntuacion(string nombreNivel, int idUsuario, double tiempoNivel,
                                        int puntuacionNivel, string fecha)
    {
        db_connection.Open();
        // Insert values in table
		IDbCommand cmnd = db_connection.CreateCommand();
		cmnd.CommandText = "INSERT INTO Puntuacion (nombreNivel, idUsuario, tiempoNivel," +
        " puntuacionNivel, fecha) VALUES ('"+nombreNivel+"', '"+idUsuario+"', '"+tiempoNivel+"', '"+
        puntuacionNivel+"', '"+fecha+"')";
		cmnd.ExecuteNonQuery();
        close();
    }

    public void NuevoUsuario(string nombre, string apellido)
    {
        db_connection.Open();
        // Insert values in table
		IDbCommand cmnd = db_connection.CreateCommand();
		cmnd.CommandText = "INSERT INTO Usuario(nombreUsuario, apellidoUsuario) VALUES ('"+nombre+"', '"+apellido+"')";
		cmnd.ExecuteNonQuery();
        close();
    }

    public List<Usuario> ObtenerUsuarios(){
        db_connection.Open();
        List<Usuario> usuarios = new List<Usuario>();
		IDbCommand cmnd_read = db_connection.CreateCommand();
		IDataReader reader;
		string query ="SELECT * FROM Usuario";
		cmnd_read.CommandText = query;
		reader = cmnd_read.ExecuteReader();
		while (reader.Read())       
		{
            Usuario u = new Usuario();
            u.EstablecerIdUsuario(reader[0].ToString());
            u.EstablecerNombres(reader[1].ToString(), reader[2].ToString());
            usuarios.Add(u);
            //Usuario u = new Usuario(reader[0].ToInt32(), reader[1].ToString());
		}
        close();
        return usuarios;

    }
}
