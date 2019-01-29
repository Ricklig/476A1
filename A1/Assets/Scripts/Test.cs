using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<Rigidbody>().velocity.magnitude < 0.5)
        {

            gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * .5f);
        }
    }
}
