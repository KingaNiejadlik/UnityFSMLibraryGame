using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformToWorse : NPCBase
{

    public GameObject navMesh;
    GameObject newEvilPosition;
    public GameObject newNpc;
    GameObject newAnimateNpc;
    public GameObject goldenBook;
    public Vector3 goldenVector;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        navMesh = GameObject.FindGameObjectWithTag("navmeshfloor");

        base.OnStateEnter(animator, stateInfo, layerIndex);
        
        //Zmniejszenie obiektu by zrobić go niewidocznym na scenie
        NPC.transform.localScale = new Vector3(0,0,0);

        navMesh.SetActive(false);

        newEvilPosition = GameObject.FindGameObjectWithTag("positionandtransform");

        NPC.transform.position = newEvilPosition.transform.position;

        NPC.GetComponent<BookAI>().CreateGateAndLight();

        // Podlożenie wizualnie nowego NPC-ta
        newAnimateNpc = NPC.GetComponent<BookAI>().ChangePrefab(newNpc, NPC.transform);

        NPC.GetComponent<BookAI>().StartFightInTrapp();

        Instantiate(goldenBook, goldenVector, goldenBook.transform.rotation);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (NPC.GetComponent<BookAI>().buildGate.transform.position != NPC.GetComponent<BookAI>().newGatePosition)
        { 
            NPC.GetComponent<BookAI>().BounceGate();
        }

        NPC.GetComponent<BookAI>().Rotate(newAnimateNpc);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC.GetComponent<BookAI>().StopFightInTrapp();
    }
}
