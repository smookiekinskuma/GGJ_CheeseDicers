using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1_ai : MonoBehaviour
{
    public Transform player;
    public Transform idleStation;
    public bool chase = false;

    private UnityEngine.AI.NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (chase) withinBounds();
        else outOfBounds();
    }

    void withinBounds()
    {
        agent.destination = player.position;
    }

    void outOfBounds()
    {
        agent.destination = idleStation.position;
    }
}
