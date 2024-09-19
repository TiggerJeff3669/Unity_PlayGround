using System.Collections;
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.Timeline; 
public class TestButtonScript : MonoBehaviour
{
    // name list
    // OpenStreetMapLayer
    // MixedRealityPlayspace
    public bool activate; //Checkbox
    GameObject PlayerSpaceCell, OpenStreetMapLayer;


    // Start is called before the first frame update
    void Start()
    {
        try
        {
            OpenStreetMapLayer = GameObject.Find("OpenStreetMapLayer");
            OpenStreetMapLayer.gameObject.SetActive(false);
        }
        catch { Debug.Log("!!!"); }
        PlayerSpaceCell = GameObject.Find("MixedRealityPlayspace");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("s"))
        {
            PlayerSpaceCell.gameObject.transform.Translate(new Vector3(0, -5, 0) * Time.deltaTime);
        }
        if (activate)
        {
            PlayerSpaceCell.gameObject.transform.Translate(new Vector3(0, -5, 0) * Time.deltaTime);
        }
    }
 
}
