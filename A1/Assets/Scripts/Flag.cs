using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{



    public bool taken = false;
    public GameObject player;
    public Vector3 init;
    Collider m_Collider;



    // Use this for initialization
    void Start()
    {
        init = transform.position;
        m_Collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (taken)
        {
            transform.position = player.transform.position;
        }
       

    }

    public void pickUp(GameObject taker)
    {
        if(taker.GetComponent<NPC>().stt == NPC.state.FLAG)
        {
            taken = true;
            player = taker;
            m_Collider.enabled = !m_Collider.enabled;
        }
    }

    public void drop()
    {
        taken = false;
        transform.position = init;
        m_Collider.enabled = !m_Collider.enabled;
    }
}