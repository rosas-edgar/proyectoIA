using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSeleccionObjeto : MonoBehaviour
{
    AudioSource opcionSeleccionada;

    // Start is called before the first frame update
    void Start()
    {
        opcionSeleccionada = GetComponent<AudioSource>();
    }

    public void playAudio()
    {
        if (!opcionSeleccionada.isPlaying)
        {
            opcionSeleccionada.PlayOneShot(opcionSeleccionada.clip);
        }
    }
}
