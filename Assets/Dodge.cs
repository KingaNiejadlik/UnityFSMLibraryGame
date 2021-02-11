using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodge : NPCBase
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        NPC.GetComponent<BookAI>().StartAttack();
        NPC.GetComponent<BookAI>().StartDodge();
        NPC.GetComponent<BookAI>().LookAtMe();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(opponent.transform.position);

        anim.SetInteger("bookTaken", opponent.GetComponent<PlayerMovement>().bookTaken);

        NPC.GetComponent<BookAI>().ChangeColorOfPlayer(NPC, opponent);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        NPCBase.currentWP = rnd.Next(waypoints.Length);

        agent.SetDestination(waypoints[NPCBase.currentWP].transform.position);
        NPC.GetComponent<BookAI>().LookAtTarget((waypoints[NPCBase.currentWP].transform));

        NPC.GetComponent<BookAI>().StopAttack();
        NPC.GetComponent<BookAI>().StopDodge();
        NPC.GetComponent<BookAI>().StopForce();
    }
}
