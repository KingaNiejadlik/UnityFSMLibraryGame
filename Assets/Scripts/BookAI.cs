using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;
using UnityEngine.AI;

public class BookAI : MonoBehaviour
{

    // Class which contain basic behaviour methods of NPC in game

    public GameObject player;
    public GameObject bullet;
    public GameObject rock;
    public GameObject gate;
    GameObject shot;

    [NonSerialized]
    public GameObject buildGate;
    GameObject actualRock;
    GameObject[] sectors;

    public Light mainLight;

    public NavMeshAgent agent;

    public Vector3 newGatePosition;
    public Vector3 constantVecT;
    public Quaternion constantVecR;
   
    Animator anim;

    public RenderBuffer color;
    public Renderer playerColor;

    public Transform shotplace;
    Rigidbody NPCbody;
    System.Random random;

    public float speed;
    public int bulletSpeed = 700;
    public int x;
    public int y;
    public int forceDodge;
    public float longDodge;
    
    
    public GameObject GetPlayer()
    {
        return player;
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        NPCbody = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        random = new System.Random();
        speed = 50f;
        sectors = GameObject.FindGameObjectsWithTag("sector");
        playerColor = player.GetComponent<Renderer>();
        constantVecT = new Vector3(0, 10, 0);
        constantVecR = new Quaternion(0, 10, 5, 0);

    }

    private void FixedUpdate()
    {
        anim.SetFloat("distance", Vector3.Distance(transform.position, player.transform.position));  
    }
    void Attack()
    {
        shot = Instantiate(bullet, shotplace.position , shotplace.rotation);
        shot.GetComponent<Rigidbody>().AddForce(shotplace.transform.forward * bulletSpeed);
        Destroy(shot, 2f);
    }
    public void StartAttack()
    {
        InvokeRepeating("Attack", 0.2f, 2f);
    }
    public void StopAttack()
    {
        CancelInvoke("Attack");
    }
    public void Dodge()
    {
        //NPC choose random side to dodge
        x = random.Next(1,3);
       
        if(x == 1)
        {
            NPCbody.velocity = -transform.right * forceDodge;
        }
        if (x == 2)
        {
            NPCbody.velocity = transform.right * forceDodge;
        }

        InvokeRepeating("StopForce", 0.5f, 2f);

    }
    public void StartDodge()
    {
        InvokeRepeating("Dodge", 0.1f, 2f);
    }
    public void StopDodge()
    {
        CancelInvoke("Dodge");
    }

    public void LookAtMe()
    {
        transform.LookAt(player.transform);
    }
    public void LookAtTarget(Transform target)
    {
        transform.LookAt(target);
    }

    public void StopForce()
    {
        NPCbody.velocity = Vector3.zero;
        NPCbody.angularVelocity = Vector3.zero; 
    }

    public void CreateGateAndLight()
    {
        buildGate = Instantiate(gate, new Vector3(-0.429978f, -9f, 6.5f), new Quaternion(0,0,0,0));
        newGatePosition = new Vector3(-0.429978f, -4.8f, 6.5f);

        mainLight.transform.position = new Vector3(0f, 40f, 0f);
    }

    public void BounceGate()
    {
        buildGate.transform.position = Vector3.MoveTowards(buildGate.transform.position, newGatePosition, 3.5f * Time.deltaTime);
    }

    public GameObject ChangePrefab(GameObject instantiateMe, Transform where)
    {
        return Instantiate(instantiateMe, where.position, where.rotation);
    }

    public void Rotate(GameObject gameObjectToRotate)
    {
        gameObjectToRotate.gameObject.transform.Rotate(0, Mathf.Sin(200 * Time.deltaTime) * speed, 0); 
    }

    public void FightInTrapp()
    {  
        actualRock = Instantiate(rock, player.transform.position + constantVecT, constantVecR);
        Destroy(actualRock, 15f);
    }

    public void StartFightInTrapp()
    {
        InvokeRepeating("FightInTrapp", 1f, 4f);
    }

    public void StopFightInTrapp()
    {
       CancelInvoke("FightInTrapp");
    }

    public void ChangeColorOfPlayer(GameObject NPC, GameObject opponent)
    {
        if (Vector3.Distance(NPC.transform.position, opponent.transform.position) < 1.0f)
        {
            playerColor.material.SetColor("_Color", new Color(0.7735849f, 0.2607722f, 0.2371841f));
        }
        if (Vector3.Distance(NPC.transform.position, opponent.transform.position) > 1.0f && Vector3.Distance(NPC.transform.position, opponent.transform.position) < 1.2f)
        {
            playerColor.material.SetColor("_Color", new Color(1f, 1f, 1f));

            NPC.GetComponent<BookAI>().StopForce();
        }
    }
}
