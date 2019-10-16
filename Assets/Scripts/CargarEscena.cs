using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargarEscena : MonoBehaviour
{
    public static void Escena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }

}
