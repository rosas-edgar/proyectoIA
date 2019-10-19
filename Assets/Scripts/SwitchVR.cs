using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class SwitchVR : MonoBehaviour
{
    public bool estadoVR = false;
    //vacio para deshabilitar, cardboard para habilitar
    public string dispositivoVR = "";
    IEnumerator LoadDevice(string newDevice, bool enable)
    {
        XRSettings.LoadDeviceByName(newDevice);
        yield return null;
        XRSettings.enabled = enable;
    }
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(LoadDevice(dispositivoVR, estadoVR));
    }
}
