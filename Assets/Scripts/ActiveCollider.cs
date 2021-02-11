using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCollider : MonoBehaviour
{
    private BoxCollider collider;
    public float activeTime;

    void Start()
    {
        collider = gameObject.GetComponent<BoxCollider>();
        collider.enabled = false;

        Invoke("Active", activeTime);
    }

    public void Active()
    {
        collider.enabled = true;
    }
}
