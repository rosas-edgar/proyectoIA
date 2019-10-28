using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextListPuntuacion : MonoBehaviour
{
    [SerializeField]
    private Text textoBoton;
    public void EstablecerTexto(string texto)
    {
        textoBoton.text = texto;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
