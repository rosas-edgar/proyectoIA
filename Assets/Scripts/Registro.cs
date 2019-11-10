using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Registro : MonoBehaviour
{
    public InputField campo_nombre;
    public InputField campo_apellido;
    public GameObject messageBox;
    public GameObject btn_Continuar;

    private SqliteHelper db;

    public string ObtenerNombre(){
        return campo_nombre.text;

    }
    public string ObtenerApellido(){
        return campo_apellido.text;
    }
    public void RegistrarUsuario(){

        string nombre = ObtenerNombre();
        string apellido = ObtenerApellido();
        //db = new SqliteHelper();
        //if (db.NuevoUsuario(nombre, apellido) == true)
        //{
        //}
        db.NuevoUsuario(nombre, apellido);

        Debug.Log(ObtenerNombre());

    }
    // Start is called before the first frame update
    void Start()
    {
        db = new SqliteHelper();
        db.CrearBD();

        btn_Continuar = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
