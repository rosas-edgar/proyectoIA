using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TiempoTransicion : MonoBehaviour
{
    public float tiempoTransicion = 1.5f;
    public bool observado;
    public static string siguienteEscena = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Observado(bool estado)
    {
        observado = estado;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeSinceLevelLoad > tiempoTransicion && observado)
        {
            SceneManager.LoadScene(siguienteEscena);
        }
    }
}
