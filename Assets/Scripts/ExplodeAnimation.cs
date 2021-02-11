using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeAnimation : MonoBehaviour
{
    // Blinking animation of exploding object

    public Color baseColor;
    public Color explodeColor;
    public float startTime;
    public float delayTime;

    void Awake()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = explodeColor;
       
        InvokeRepeating("Blink", startTime, delayTime); 
    }

    public void Blink()
    {             
            if (gameObject.GetComponent<MeshRenderer>().material.color == explodeColor)
            {
                gameObject.GetComponent<MeshRenderer>().material.color = baseColor;
            }
            else
            {
                gameObject.GetComponent<MeshRenderer>().material.color = explodeColor;
            }
    }
}
