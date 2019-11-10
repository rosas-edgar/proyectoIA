using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message_Box_Caller : MonoBehaviour
{
    // Referencia al prefab de MessageBox
    public GameObject messageBox;

    // Instanciar el prefab
    public void InstanciarMessageBox()
    {
        Instantiate(messageBox, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
