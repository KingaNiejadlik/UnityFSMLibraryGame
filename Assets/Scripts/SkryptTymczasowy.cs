using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent2 : MonoBehaviour
{

    public GameObject station3;
    public GameObject station4;
    public GameObject station5;
    public GameObject station6;
    public GameObject station7;
    public GameObject station8;
    private bool active7;
    private bool active4;
    [System.NonSerialized]
    public int course;
    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.transform.position = station3.transform.position;
        course = 1;
        active4 = true;
        active7 = true;
    }


    void Update()
    {
        if (course == 0)
        {
            agent.SetDestination(station3.transform.position);
        }

        if (course == 1)
        {
            agent.SetDestination(station4.transform.position);
        }
        if (course == 2 && active4 == true)
        {
            agent.SetDestination(station5.transform.position);
        }
        if (course == 3)
        {
            agent.SetDestination(station6.transform.position);
        }
        if (course == 4)
        {
            agent.SetDestination(station7.transform.position);
        }
        if (course == 5 && active7 == true)
        {
            agent.SetDestination(station8.transform.position);
        }

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "station3")
        {
            course = 1;
            active7 = true;
            active4 = true;

        }
        if (col.gameObject.tag == "station4")
        {
            course = 2;

        }
        if (col.gameObject.tag == "station5")
        {
            course = 3;

        }
        if (col.gameObject.tag == "station6")
        {
            course = 4;

        }
        if (col.gameObject.tag == "station7")
        {
            course = 5;

        }
        if (col.gameObject.tag == "station8")
        {
            course = 0;
            active7 = false;
            active4 = false;

        }

    }
}