using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Transform playerPos;
    private Rigidbody playerRb;
    public Vector3 movement;

    public float wanderRadius;
    public float wanderTimer;
    public float timer;


    // Start is called before the first frame update
    void Start()
    {
        playerPos = gameObject.transform;
        playerRb = GetComponent<Rigidbody>();
        timer = wanderTimer;
    }

    // Update is called once per frame
    void Update()
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
            playerPos.position = new Vector3(playerPos.position.x, playerPos.position.y, 5 );
        }
        else if (playerPos.position.z > 5)
        {
            playerPos.position = new Vector3(playerPos.position.x, playerPos.position.y, -5);
        }

        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            movement =  new Vector3(Random.Range(playerPos.position.x - wanderRadius, playerPos.position.x + wanderRadius), playerPos.position.y,  Random.Range(playerPos.position.z - wanderRadius, playerPos.position.z + wanderRadius));
            playerPos.position = Vector3.MoveTowards(playerPos.position, movement, 10 * Time.deltaTime);
            timer = 0;
        }
    }

}
