using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscenaUsuarios : MonoBehaviour
{
    private SqliteHelper db;
    [SerializeField]
    private GameObject buttonTemplate;    

    void GenerarBotones(){
        List<Usuario> usuarios = db.ObtenerUsuarios("d");
        foreach(Usuario u in usuarios){
            GameObject boton = Instantiate(buttonTemplate) as GameObject;
            boton.SetActive(true);
            boton.GetComponent<ButtonListButton>().EstablecerTexto(u.ObtenerNombres());
            boton.transform.SetParent(buttonTemplate.transform.parent, false);

        }

    }
    
    // Start is called before the first frame update
    void Start()
    {
        db = new SqliteHelper();
        GenerarBotones();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
