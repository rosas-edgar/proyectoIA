using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPortrait : MonoBehaviour
{
    // Start is called before the first frame update
    public bool landscape = false;
    void Start()
    {
        if (landscape)
        {
            Landscape();
        }
        else
        {
            Portrait();
        }
        
    }
    private void Portrait()
    {
        Screen.autorotateToPortrait = true;
        Screen.autorotateToLandscapeLeft = false;
        Screen.orientation = ScreenOrientation.Portrait;
    }
    private void Landscape()
    {
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToPortrait = false;
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

}
