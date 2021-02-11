using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingInTheAir : MonoBehaviour
{
    
    void Start()
    {
        
    }
 
    void Update()
    {
        this.gameObject.transform.Rotate(0, 90 * Time.deltaTime, 0);
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + Mathf.Sin(Time.fixedTime * 2) / 150, this.transform.position.z);
    }
}
