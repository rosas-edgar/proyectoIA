using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MostrarObjeto : MonoBehaviour
{
    public GameObject objPedir;
    public GameObject objTomar;
    public GameObject objNoTomar;
    public GameObject objSi;
    public GameObject objNo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VisibilidadObjeto(bool visible, string nombre)
    {
        if(nombre == "Pedir")
        {
            objPedir.GetComponent<Renderer>().enabled = visible;
        }
        else if (nombre == "Respuesta")
        {
            objSi.GetComponent<Renderer>().enabled = visible;
            objNo.GetComponent<Renderer>().enabled = visible;
        }
        else if(nombre == "TomarONoTomar")
        {
            objTomar.GetComponent<Renderer>().enabled = visible;
            objNoTomar.GetComponent<Renderer>().enabled = visible;
        }
    }
}
