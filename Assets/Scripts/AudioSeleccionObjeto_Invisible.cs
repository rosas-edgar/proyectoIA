using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSeleccionObjeto_Invisible : MonoBehaviour
{
    AudioSource opcionSeleccionada;
    public GameObject objeto;

    // Start is called before the first frame update
    void Start()
    {
        opcionSeleccionada = GetComponent<AudioSource>();
    }

    public void playAudio()
    {
        if (!opcionSeleccionada.isPlaying && objeto.GetComponent<Renderer>().enabled)
        {
            opcionSeleccionada.PlayOneShot(opcionSeleccionada.clip);
        }
    }
}
