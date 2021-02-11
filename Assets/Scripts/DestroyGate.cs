using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGate : MonoBehaviour
{
    public GameObject explodePrefab;
    private GameObject actualPref;
    private void OnTriggerEnter(Collider o)
    {
        if(o.gameObject.tag == "evilBook")
        {
            Destroy(this.gameObject);
            actualPref = Instantiate(explodePrefab, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(actualPref, 2f);
        }
    }
}
