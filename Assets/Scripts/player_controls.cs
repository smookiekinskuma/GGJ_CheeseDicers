using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class player_controls : MonoBehaviour
{
    Rigidbody playerRB;
    int playerSpeed = 15;
    Quaternion aim = Quaternion.Euler(0, 0, 0);

    public int playerBreath = 100;
    public int playerBreathInc = -5;

    public ParticleSystem bubbles;
    public UIScript UiScript;
    bool bubbleBuffering = false;

    //Death Toggle *NEW*
    bool isDeath = false;

    //This is for Aiming.
    private Vector2 turn;

    //Cooldown Tracker
    bool isOnCooldown = false;
    public float cooldownTimer;
    // Moved to UIScript
    public float clickCDTimer;
    public float clickCD = 0.5f;

    //Breath Bar UI Mechanics
    //Moved to UIScript

    //Tutorial Related Stuff
    //Moved to UIScript

    //Crystal Related Stuff
    //Moved to UIScript

    void Awake()
    {
        playerRB = this.GetComponent<Rigidbody>();

        //This is to call the bubbles.
        bubbles = bubbles.GetComponent<ParticleSystem>();
        //Locks the cursor to the center of the screen, thus making it invisible while game is playing.

        //This is recycled code, but it does what it says on the tin for bot UI and such.
        UiScript.SetStartingBreath();

        //To access SimulationSpeed, the playback speed of the bubble anims.

        var main = bubbles.main;
        main.simulationSpeed = 0;

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Controls();
        //I moved the rest of the things here. Can be made into a separate script for readability's sake.
        BubbleAim();
        UiScript.UpdateBreathBar();

        Debug.Log(playerBreath);
        Debug.Log(Input.mouseScrollDelta.y);

        //Death Catch

        if (playerBreath == 0)
        {
            Debug.Log("Death should be here.");
            isDeath = true;
            StopCoroutine(BubbleBuffer(0f));
        }

        if (isOnCooldown)
        {
            cooldownTimer -= Time.deltaTime;

            if (cooldownTimer <= 0)
            {
                isOnCooldown = false;
                cooldownTimer = 0.5f;
                UiScript.cooldownIndicator.sprite = UiScript.activeSprite;
                return;
            }
        }

        if (clickCDTimer <= 0f)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && !UiScript.tutorialObj.activeInHierarchy)
            {
                FireBubble();
                clickCDTimer = clickCD;
            }
        }
        else
        {
            clickCDTimer -= Time.deltaTime;
        }

        
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
        //In Case I need to check something!
        if (!UiScript.tutorialObj.activeInHierarchy)
        {
            Vector3 direction = Vector3.zero;

            if (Input.GetKey(KeyCode.D))
            {
                direction = moveVelocity["MoveRight"];
            }

            if (Input.GetKey(KeyCode.A))
            {
                direction = moveVelocity["MoveLeft"];
            }

            if (Input.GetKey(KeyCode.W))
            {
                direction = moveVelocity["MoveFar"];
            }

            if (Input.GetKey(KeyCode.S))
            {
                direction = moveVelocity["MoveNear"];
            }

            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
            {
                direction = moveVelocity["MoveRight"] + moveVelocity["MoveFar"];
            }

            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
            {
                direction = moveVelocity["MoveLeft"] + moveVelocity["MoveFar"];
            }

            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
            {
                direction = moveVelocity["MoveRight"] + moveVelocity["MoveNear"];
            }

            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
            {
                direction = moveVelocity["MoveLeft"] + moveVelocity["MoveNear"];
            }

            direction = direction.normalized;

            playerRB.velocity = new Vector3(direction.x, -9.8f / playerSpeed, direction.z) * playerSpeed;


            if (Input.mouseScrollDelta.y > 0)
            {
                //Death Catch
                if (!isDeath)
                {
                    playerBreathInc = 5;
                    StartCoroutine(BubbleBuffer(0.5f));
                    bubbleBuffering = true;
                }
            }

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                UiScript.CrystalTesting();
            }
        }

        //Bug: If Held Down, will continue to do the coroutine until death.
        //Update: Fixed it.

        if (Input.GetKey(KeyCode.F2))
        {
            UiScript.tutorialObj.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            UiScript.CloseTutorial();
        }

    }

    void FireBubble()
    {
        // Bug: If Rapid Clicked, will explode.
        // Update: Fixed.

         playerBreathInc = -5;
         StartCoroutine(BubbleBuffer(0.5f));
         bubbleBuffering = true;
         bubbles.transform.rotation = aim;

        //Why didn't I do this earlier?
        cooldownTimer = 0.5f;
        isOnCooldown = true;

        //Allows the bubbles to shoot.
        var main = bubbles.main;
        main.simulationSpeed = 1;

        bubbles.Play();
    }

    void BubbleAim()
    {
        turn.x += Input.GetAxis("Mouse X");
        aim = Quaternion.Euler(0, (turn.x * 5), 0);
        bubbles.transform.rotation = aim;
    }

    IEnumerator BubbleBuffer(float waitTime)
    {
        if (UiScript.cooldownIndicator.sprite != UiScript.cooldownSprite)
        {
            UiScript.cooldownIndicator.sprite = UiScript.cooldownSprite;
        }

        if (!bubbleBuffering)
        {
            yield return new WaitForSeconds(waitTime);
            playerBreath += playerBreathInc;
            bubbleBuffering = false;
        }
    }

}
