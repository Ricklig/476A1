using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject[] redTeam;
    public GameObject[] blueTeam;

    public GameObject rflag;
    public GameObject bflag;
    void Start()
    {
        blueTeam[Random.Range(0, blueTeam.Length)].GetComponent<NPC>().setTarget(rflag);
        redTeam[Random.Range(0, redTeam.Length)].GetComponent<NPC>().setTarget(bflag);
        //Debug.Log("listen");

    }
    private void Update()
    {
        
    }


    public void poll(GameObject go)
    {
        if(go.tag == "BPLAYER")
        {
            for (int i = 0; i < blueTeam.Length; i++)
            {
                if (blueTeam[i].GetComponent<NPC>().stt == NPC.state.FROZEN)
                {
                    go.GetComponent<NPC>().setTarget(blueTeam[i]);
                    return;
                }
            }
            for (int i = 0; i < redTeam.Length; i++)
            {
                if (redTeam[i].GetComponent<NPC>().hasFlag)
                {
                        go.GetComponent<NPC>().setTarget(redTeam[i]);
                        return;
                    
                    
                }
            }
            for (int i = 0; i < blueTeam.Length; i++)
            {
                if (blueTeam[i].GetComponent<NPC>().stt == NPC.state.FLAG)
                {
                    return;
                }
            }
            go.GetComponent<NPC>().setTarget(rflag);
            //Debug.Log(go.name);

        }
        else if (go.tag == "RPLAYER")
        {
            for (int i = 0; i < redTeam.Length; i++)
            {
                if (redTeam[i].GetComponent<NPC>().stt == NPC.state.FROZEN)
                {
                    go.GetComponent<NPC>().setTarget(redTeam[i]);
                    return;
                }
            }
            for (int i = 0; i < blueTeam.Length; i++)
            {
                if (blueTeam[i].GetComponent<NPC>().hasFlag)
                {
                    go.GetComponent<NPC>().setTarget(blueTeam[i]);
                    return;
                }
            }
            for (int i = 0; i < redTeam.Length; i++)
            {
                if (redTeam[i].GetComponent<NPC>().stt == NPC.state.FLAG)
                {
                    return;
                }
            }
            go.GetComponent<NPC>().setTarget(bflag);
            Debug.Log(go.name);

        }

    }
}
