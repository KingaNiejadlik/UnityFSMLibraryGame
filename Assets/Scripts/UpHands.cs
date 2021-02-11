using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpHands : MonoBehaviour
{

    public float howUp;
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            this.gameObject.transform.position = this.gameObject.transform.position + new Vector3(0, howUp, 0);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            this.gameObject.transform.position = this.gameObject.transform.position - new Vector3(0, howUp, 0);
        }

    }
}
