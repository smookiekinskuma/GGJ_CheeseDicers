using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controls : MonoBehaviour
{
    Rigidbody playerRB;
    int playerSpeed = 15;
    Quaternion aim = Quaternion.Euler(0, 0, 0);

    int playerBreath = 100;
    int playerBreathInc = -5;

    public ParticleSystem bubbles;
    bool bubbleBuffering = false;

    void Start()
    {
        playerRB = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Controls();
        Debug.Log(playerBreath);
        Debug.Log(Input.mouseScrollDelta.y);
    }

    Dictionary<string, Vector3> moveVelocity = new Dictionary<string, Vector3>()
    {
        { "MoveRight", new Vector3(1,0,0) },
        { "MoveLeft", new Vector3(-1,0,0) },
        { "MoveFar", new Vector3(0,0,1) },
        { "MoveNear", new Vector3(0,0,-1) }
    };

    void Controls()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.D))
        {
            direction = moveVelocity["MoveRight"];
            aim = Quaternion.Euler(0, 90, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            direction = moveVelocity["MoveLeft"];
            aim = Quaternion.Euler(0, -90, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            direction = moveVelocity["MoveFar"];
            aim = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            direction = moveVelocity["MoveNear"];
            aim = Quaternion.Euler(0, 180, 0);
        }
        
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            direction = moveVelocity["MoveRight"] + moveVelocity["MoveFar"];
            aim = Quaternion.Euler(0, 45, 0);
        }

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {
            direction = moveVelocity["MoveLeft"] + moveVelocity["MoveFar"];
            aim = Quaternion.Euler(0, -45, 0);
        }

        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            direction = moveVelocity["MoveRight"] + moveVelocity["MoveNear"];
            aim = Quaternion.Euler(0, 135, 0);
        }

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            direction = moveVelocity["MoveLeft"] + moveVelocity["MoveNear"];
            aim = Quaternion.Euler(0, -135, 0);
        }

        direction = direction.normalized;

        playerRB.velocity = new Vector3(direction.x, -9.8f /playerSpeed, direction.z) * playerSpeed;

        if (Input.GetMouseButton(0))
        {
            playerBreathInc = -5;
            StartCoroutine(BubbleBuffer(0.5f));
            bubbleBuffering = true;
            bubbles.transform.rotation = aim;
            bubbles.Play();
        }

        if (Input.mouseScrollDelta.y > 0)
        {
            playerBreathInc = 5;
            StartCoroutine(BubbleBuffer(2.5f));
            bubbleBuffering = true;
        }
    }

    IEnumerator BubbleBuffer(float waitTime)
    {
        if(!bubbleBuffering)
        {
            yield return new WaitForSeconds(waitTime);
            playerBreath += playerBreathInc;
            bubbleBuffering = false;
        }
    }
}
