using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubble_behavior : MonoBehaviour
{
    public GameObject Bubble;
    Rigidbody2D bubbleRB;

    Dictionary<string, Vector3> moveVelocity = new Dictionary<string, Vector3>()
    {
        { "MoveRight", new Vector3(1,0,0) },
        { "MoveLeft", new Vector3(-1,0,0) },
        { "MoveUp", new Vector3(0,1,0) },
        { "MoveDown", new Vector3(0,-1,0) },
        { "MoveFar", new Vector3(0,0,1) },
        { "MoveNear", new Vector3(0,0,-1) }
    };

    void Start()
    {
        bubbleRB = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        FloatBehavior();
    }

    void SpawnBubbles(Vector3 direction) //normalised from the player controls
    {
        //Set a random lifetime
        //
    }

    void FloatBehavior()
    {
        Ray ray = new Ray(this.transform.position, Vector3.down);
        Debug.DrawRay(ray.origin, ray.direction * 1);

        RaycastHit hitData;

        if (Physics.Raycast(ray, out hitData))
        {
            if (hitData.collider.gameObject.tag == "Ground")
            {
                bubbleRB.velocity = new Vector2(0, Random.Range(0f, 1f));
            }

            else
            {
                bubbleRB.velocity = new Vector2(0, 0);
            }
        }
    }

    void AddNoise()
    {

    }




}
