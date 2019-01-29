using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public enum state { FREE, FLAG, FROZEN, UNFREEZING, FOLLOW };
    public state stt;

    private Rigidbody rb;
    
    public float thrust = 6f;

    public bool away = false;
    public bool frozen = false;
    public bool blue = false;
    public bool hasFlag = false;


    public GameObject homeFlag;
    public GameObject awayFlag;
    public GameObject target;
    public GameObject home;

    public string etag;
    public string ehome;

    public GameController gc;

    public Vector3 worldDir;
    public Vector3 destination;
    public Vector3 direction;

    
   

    void Start()
    {

        if (gameObject.tag == "BPLAYER")
            blue = true;
        //target = GameObject.FindGameObjectWithTag("RPLAYER");
        gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        rb = GetComponent<Rigidbody>();
        //destination = target.transform.position;
        if (blue)
        {
            home = GameObject.FindGameObjectWithTag("BHOME");
            homeFlag = GameObject.FindGameObjectWithTag("BFLAG");
            awayFlag = GameObject.FindGameObjectWithTag("RFLAG");
            etag = "RPLAYER";
            ehome = "RHOME";
        }

        else
        {
            home = GameObject.FindGameObjectWithTag("RHOME");
            homeFlag = GameObject.FindGameObjectWithTag("RFLAG");
            awayFlag = GameObject.FindGameObjectWithTag("BFLAG");
            etag = "BPLAYER";
            ehome = "BHOME";
        }
    }
    
    void Update()
    {
        if (target == null)
        {
            if(direction.magnitude < 1)
            {
                wander();
            }
            gc.poll(gameObject);
        }
        else
        {
            destination = target.transform.position;
        }
        worldDir = rb.velocity;
        direction =  destination - transform.position;
        Quaternion angle = Quaternion.LookRotation(direction);
        Debug.DrawRay(transform.position, direction, Color.red);
        float angleE = Vector3.Angle(worldDir, direction);
        var str = Mathf.Min(1F * Time.deltaTime, 1);
        checkBounds();

        if (!frozen)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, angle, str);

            if (rb.velocity.magnitude < .6f && angleE < 120)
            {
                rb.AddForce(transform.forward * thrust);
            }
            else
                rb.AddForce(transform.forward * 0.001f);
        }
        else
        {
        }


        //Debug.Log(direction.magnitude);
        //Debug.Log(destination);
        //Debug.Log(angleE);
        //Debug.Log(rb.velocity.magnitude);
    }

    public void freeze()
    {
        if (stt != state.FROZEN)
        {

            stt = state.FROZEN;

            //Debug.Log("I AM FROZEN");
            frozen = true;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            gameObject.layer = gameObject.layer + 3;
            Debug.Log(gameObject.layer);
        }


    }

    public void unfreeze()
    {
        stt = state.UNFREEZING;

       // Debug.Log("I AM UNFROZEN");
        frozen = false ;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        target = home;
        gameObject.layer = gameObject.layer - 3;
    }

    public void wander()
    {
        stt = state.FREE;
        target = null;
        if(etag == "BPLAYER")
            destination = new Vector3(Random.Range(0, 10), transform.position.y, Random.Range(-5, 5));
        else
            destination = new Vector3(Random.Range(-10, 0), transform.position.y, Random.Range(-5, 5));
    }

    public void setTarget(GameObject go)
    {
        if(go.tag == etag)
        {
            stt = state.FOLLOW;
        }
        else if (go.tag == gameObject.tag)
        {
            stt = state.UNFREEZING;
        }
        else if(go.tag == awayFlag.tag)
        {
            stt = state.FLAG;
            
        }
        target = go;
        Debug.Log(gameObject.name + stt);
    }

    public void checkBounds()
    {
        if (transform.position.x < -10)
        {
            transform.position = new Vector3(10, transform.position.y, transform.position.z);
        }
        else if(transform.position.x > 10){
            
                transform.position = new Vector3(-10, transform.position.y, transform.position.z);
            }
        else if (transform.position.z < -5)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 5);
        }
        else if (transform.position.z > 5)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -5);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == awayFlag.tag)
        {
            collision.gameObject.GetComponent<Flag>().pickUp(gameObject);
            target = home;
            hasFlag = true;
            
        }
        else if(collision.gameObject.tag == gameObject.tag)
        {
            if(away)
            {
                if (collision.gameObject.GetComponent<NPC>().frozen)
                {
                    collision.gameObject.GetComponent<NPC>().unfreeze();
                    target = home;
                }
            }
            //or just change wander direciton
        }
        else if(collision.gameObject.tag == etag)
        {
            if (away)
            {
                freeze();
                hasFlag = false;
                awayFlag.GetComponent<Flag>().drop();
                //Destroy(collision.gameObject);
            }
            else
            {
                wander();
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ehome)
        {
            //Debug.Log("entered red");
            away = true;
        }
        if (other.gameObject.tag == home.tag)
        {
            //Debug.Log("entered blue");
            wander();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == ehome)
        {
            //Debug.Log("left");
            away = false ;
        }
    }



}
