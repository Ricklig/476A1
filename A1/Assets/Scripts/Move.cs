using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    enum curState {Pursue, Arrive, Flee, Wander};
    private curState myState; 


    private Transform playerPos;
    private Rigidbody playerRb;
    public Vector3 movement;

    public float wanderRadius;
    public float wanderTimer;
    public float timer;

    private bool motion;
    public float step = 0;

    private Vector3 target;

    public GameObject hunted;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = gameObject.transform;
        playerRb = GetComponent<Rigidbody>();

        myState = curState.Wander;

        timer = wanderTimer;
        motion = false;
    }

    // Update is called once per frame
    void Update()
    {
        checkBounds();
        checkState();

        
    }

    public void Pursue(GameObject hunted)
    {
        
    }

    public void Arrive(Vector3 target)
    {
        if (!motion)
        {
            playerPos.position = Vector3.MoveTowards(playerPos.position, movement, 10 * Time.deltaTime);
        }
        else
        {
            Vector3 newDir = Vector3.RotateTowards(transform.forward, target, step, 0.0f);
            playerPos.rotation = Quaternion.LookRotation(newDir);
            playerPos.position = Vector3.MoveTowards(playerPos.position, movement, 10 * Time.deltaTime);
        }
    }

    public void Flee()
    {

    }

    public void Wander()
    {
        if (timer >= wanderTimer)
        {
            timer += Time.deltaTime;
            movement = new Vector3(Random.Range(playerPos.position.x - wanderRadius, playerPos.position.x + wanderRadius), playerPos.position.y, Random.Range(playerPos.position.z - wanderRadius, playerPos.position.z + wanderRadius));
            //playerPos.position = Vector3.MoveTowards(playerPos.position, movement, 10 * Time.deltaTime);
            timer = 0;
        }
    }

    public void pollMotion(Vector3 target)
    {
        if (target == null)
        {

        }
        else
        {
            playerPos.position = Vector3.MoveTowards(playerPos.position, movement, 10 * Time.deltaTime);
        }
    }

    private void checkBounds()
    {
        if (playerPos.position.x < -10)
        {
            playerPos.position = new Vector3(10, playerPos.position.y, playerPos.position.z);
        }
        else if (playerPos.position.x > 10)
        {
            playerPos.position = new Vector3(-10, playerPos.position.y, playerPos.position.z);
        }
        else if (playerPos.position.z < -5)
        {
            playerPos.position = new Vector3(playerPos.position.x, playerPos.position.y, 5);
        }
        else if (playerPos.position.z > 5)
        {
            playerPos.position = new Vector3(playerPos.position.x, playerPos.position.y, -5);
        }
    }

    private void checkState()
    {
        if (myState == curState.Wander)
        {
            Wander();
        }
        else if (myState == curState.Arrive)
        {
            Arrive(target);
        }
        else if (myState == curState.Flee)
        {
            
        }
        else if (myState == curState.Pursue)
        {
            Pursue(hunted);
        }
    }
}
