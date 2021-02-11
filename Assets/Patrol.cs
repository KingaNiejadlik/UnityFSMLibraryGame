using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : StateMachineBehaviour
{
    GameObject NPC;
    GameObject[] waypoints;
    int currentWP;
    
    private void Awake()
    {
        waypoints = GameObject.FindGameObjectsWithTag("waypiontJump");
    }
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC = animator.gameObject;
        currentWP = 0;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC.GetComponent<Rigidbody>().velocity = Vector3.zero;

        if (waypoints.Length == 0) return;

        if(Vector3.Distance(waypoints[currentWP].transform.position, NPC.transform.position) < 1.0f)
        {
            currentWP++;

            if(currentWP >= waypoints.Length)
            {
                currentWP = 0;
            }
        }
      

        var direction = waypoints[currentWP].transform.position - NPC.transform.position;
        NPC.transform.rotation = Quaternion.Slerp(NPC.transform.rotation, Quaternion.LookRotation(direction), 6.0f * Time.deltaTime);
        NPC.transform.Translate(0, 0, Time.deltaTime * 2.0f);
    }
   
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

}
