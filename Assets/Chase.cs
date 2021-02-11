using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : NPCBase
{
    Renderer color;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator,stateInfo,layerIndex);
        color = opponent.GetComponent<Renderer>();
        
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(opponent.transform.position);
        
        anim.SetInteger("bookTaken", opponent.GetComponent<PlayerMovement>().bookTaken);

        NPC.GetComponent<BookAI>().ChangeColorOfPlayer(NPC, opponent);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPCBase.currentWP = rnd.Next(waypoints.Length);

        agent.SetDestination(waypoints[NPCBase.currentWP].transform.position);
    }   
}
