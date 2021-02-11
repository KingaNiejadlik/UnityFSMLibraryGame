using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class PatrolWithNavMesh : NPCBase
{

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        if(NPCBase.canI == false)
        {
            NPCBase.currentWP = rnd.Next(waypoints.Length);

            agent.SetDestination(waypoints[NPCBase.currentWP].transform.position);
        }
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Pozwala na aktualne sprawdzanie ilości zebranych ksiażek na mapie
        anim.SetInteger("bookTaken", opponent.GetComponent<PlayerMovement>().bookTaken);

        if (waypoints.Length == 0) return;

        if (canI == true && Vector3.Distance(this.waypoints[NPCBase.currentWP].transform.position, NPC.transform.position) < 2.0f)
        {
            NPCBase.currentWP = rnd.Next(waypoints.Length);
            agent.SetDestination(waypoints[NPCBase.currentWP].transform.position);
        }

        if (Vector3.Distance(this.waypoints[NPCBase.currentWP].transform.position, NPC.transform.position) < 2.0f && canI == false)
        {
            NPCBase.currentWP = rnd.Next(waypoints.Length);
            agent.SetDestination(waypoints[NPCBase.currentWP].transform.position);
        } 
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPCBase.canI = true;   
    }

    void LowTilt()
    {
        if (mITrigger >= 1)
        {
            Debug.Log("doing the low tilt method");
            for (float time = 0; time < 700000.1; time += Time.fixedTime)
            {
                if (time > 700000)
                {
                    mITrigger -= 1;
                    time = 0;
                    Debug.Log("Zmniejszenie");
                    break;
                }
            }

        }
    }
}
