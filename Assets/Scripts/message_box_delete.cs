using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class message_box_delete : MonoBehaviour
{
    public GameObject messageBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Delete_Message_Box()
    {
        Destroy(messageBox);
    }
}
