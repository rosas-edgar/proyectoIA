using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TiempoTransicion : MonoBehaviour
{
    public float tiempoTransicion = 1.5f;
    public static string siguienteEscena = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeSinceLevelLoad > tiempoTransicion)
        {
            SceneManager.LoadScene(siguienteEscena);
        }
    }
}
