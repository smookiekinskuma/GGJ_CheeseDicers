using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1_bounds : MonoBehaviour
{
    public GameObject enemyNavMesh;

    private void OnTriggerEnter(Collider other)
    {
        enemyNavMesh.gameObject.GetComponent<enemy1_ai>().chase = true;
    }
    private void OnTriggerExit(Collider other)
    {
        enemyNavMesh.gameObject.GetComponent<enemy1_ai>().chase = false;
    }
}
