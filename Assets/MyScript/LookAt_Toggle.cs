using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt_Toggle : MonoBehaviour
{
    public Transform Cam,Trag;
    public bool isLookAt=true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isLookAt) Cam.LookAt(Trag);
    }
}
