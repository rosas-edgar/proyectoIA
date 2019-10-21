using UnityEngine;
using System.Data;
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
        db_connection.Open();
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

		// Create table
		IDbCommand dbcmd_usuario;
		dbcmd_usuario = db_connection.CreateCommand();
		string q_crearTablaUsuario = "CREATE TABLE IF NOT EXISTS Usuario(idUsuario INTEGER PRIMARY KEY," +
         "nombreUsuario NVARCHAR(90) )";
		
		dbcmd_usuario.CommandText = q_crearTablaUsuario;
		dbcmd_usuario.ExecuteReader();

        // Create table
		IDbCommand dbcmd_nivel;
		dbcmd_nivel = db_connection.CreateCommand();
		string q_crearTablaNivel = "CREATE TABLE IF NOT EXISTS Nivel(idNivel INTEGER PRIMARY KEY," +
         "nombreNivel VARCHAR(50))";
		
		dbcmd_nivel.CommandText = q_crearTablaNivel;
		dbcmd_nivel.ExecuteReader();

        // Create table
		IDbCommand dbcmd_puntuacion;
		dbcmd_puntuacion = db_connection.CreateCommand();
		string q_crearTablaPuntuacion = "CREATE TABLE IF NOT EXISTS Puntuacion(idNivel INTEGER," +
         "idUsuario INTEGER, tiempoNivel DOUBLE, puntuacionNivel INTEGER, fecha VARCHAR(12))";
		
		dbcmd_puntuacion.CommandText = q_crearTablaPuntuacion;
		dbcmd_puntuacion.ExecuteReader();
    }

    public void NuevaPuntuacion(int idNivel, int idUsuario, double tiempoNivel,
                                        int puntuacionNivel, string fecha)
    {
        // Insert values in table
		IDbCommand cmnd = db_connection.CreateCommand();
		cmnd.CommandText = "INSERT INTO Puntuacion (idNivel, idUsuario, tiempoNivel," +
        " puntuacionNivel, fecha) VALUES ("+idNivel+", "+idUsuario+", "+tiempoNivel+", "+
        puntuacionNivel+", "+fecha+")";
		cmnd.ExecuteNonQuery();
    }

    public void NuevoUsuario(string nombre)
    {
        // Insert values in table
		IDbCommand cmnd = db_connection.CreateCommand();
		cmnd.CommandText = "INSERT INTO Usuario(nombreUsuario) VALUES ('"+nombre+"')";
		cmnd.ExecuteNonQuery();
    }

    public Usuario ObtenerUsuario(int id){
        // Read and print all values in table
		IDbCommand cmnd_read = db_connection.CreateCommand();
		IDataReader reader;
		string query ="SELECT * FROM Usuario WHERE idUsuario ='"+id+"'";
		cmnd_read.CommandText = query;
		reader = cmnd_read.ExecuteReader();
        Usuario u = new Usuario();

		while (reader.Read())
		{
            u.EstablecerIdUsuario(reader[0].ToString());
            u.EstablecerNombre(reader[1].ToString());
            //Usuario u = new Usuario(reader[0].ToInt32(), reader[1].ToString());
		}
        return u;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
