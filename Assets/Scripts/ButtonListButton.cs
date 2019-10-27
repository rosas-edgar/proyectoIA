using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListButton : MonoBehaviour
{
    [SerializeField]
    private Text textoBoton;
    public Usuario usuario;
    public void EstablecerTexto(string texto){
        textoBoton.text = texto;

    }
    public void EstablecerUsuario(Usuario usuario)
    {
        this.usuario = usuario;
    }
    public Usuario ObtenerUsuario()
    {
        return usuario;
    }
    public void OnClick(){
        Puntuacion.usuario = usuario;
        Debug.Log(Puntuacion.usuario.ObtenerNombres());
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
