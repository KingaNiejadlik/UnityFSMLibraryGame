using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideBehind : MonoBehaviour
{
    public float transparency;
    public GameObject transparencyObj;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "player") {

            Color color = transparencyObj.GetComponent<MeshRenderer>().material.color;
            color.a -= Time.deltaTime * transparency;
            transparencyObj.GetComponent<MeshRenderer>().material.color = color;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            Color color = transparencyObj.GetComponent<MeshRenderer>().material.color;
            color.a += Time.deltaTime * transparency;
            transparencyObj.GetComponent<MeshRenderer>().material.color = color;
        }
    }

}
