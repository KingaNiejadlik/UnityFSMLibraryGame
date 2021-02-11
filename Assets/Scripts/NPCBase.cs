using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCBase : StateMachineBehaviour
{
    public GameObject NPC;
    public GameObject opponent;
    public GameObject player;
    public GameObject enemy;
    public GameObject[] waypoints;
    public System.Random rnd;
    public NavMeshAgent agent;
    public static int currentWP;
    public static bool canI = false;
    public int mITrigger;
    public Animator anim;
    public float chaseTriggerTime;
    public bool transform = false;

    public void Awake()
    {
        mITrigger = 0;
        chaseTriggerTime = 0;
    }
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
        NPC = animator.gameObject;
        opponent = NPC.GetComponent<BookAI>().GetPlayer();
        agent = NPC.GetComponent<NavMeshAgent>();
        rnd = new System.Random();
        anim = NPC.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("player");
        enemy = GameObject.FindGameObjectWithTag("enemy");
    }

}
