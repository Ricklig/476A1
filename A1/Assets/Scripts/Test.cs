using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Vector2 p1 = new Vector2(8, 2);
    public  Vector2 p2 = new Vector2(5, 6);
    public float Vm = 7;
    public float am = 10;
    public Vector2 pc = new Vector2(8.2f, 2.3f);
    public Vector2 vc = new Vector2(0, 0);
    public float t = 0.5f;
    public float velv;
    public float ra = 0.5f;
    public float rs = 6.0f;
    public float t2t = 1.0f;


    





    // Start is called before the first frame update
    void Start()
    {
        Vector2 vd = p1 - p2;
        Debug.Log("vd = " + vd);
        Vector2 Nvd = vd.normalized;
        Debug.Log("Nvd = " +  Nvd);
        velv = vd.magnitude;

        Vector2 a;
        Vector2 v;

        if(velv < rs)
        {
            Vector2 govel = ((velv / rs) * Vm) * Nvd;
            a = (govel - vc) / t2t;

            if(a.magnitude >= am)
            {
                a = a.normalized * Vm;
            }

            if(velv < ra)
            {
                v = new Vector2(0,0);
            }
            else
            {
                v = vc + (a * t);
            }

            if(v.magnitude >= Vm)
            {
                v = v.normalized * Vm;
            }

            pc = pc + (v * t);

            Debug.Log("velv = " + velv);
            Debug.Log("a = " + a);
            Debug.Log("v = " + v);
            Debug.Log("pc = " + pc);
        }
        else
        {
            a = am * Nvd;
            v = vc + a * t;

            if(v.magnitude >= Vm)
            {
                v = v.normalized * Vm;
            }

            pc = pc + (v * t);
            Debug.Log("a = " + a);
            Debug.Log("v = " + v);
            Debug.Log("pc = " + pc);
        }

        Debug.Log("Point 3");
        if (velv < rs)
        {
            Vector2 govel = ((velv / rs) * Vm) * (Nvd);
            a = (govel - vc) / t2t;

            if (a.magnitude >= am)
            {
                a = a.normalized * Vm;
            }

            if (velv < ra)
            {
                v = new Vector2(0, 0);
            }
            else
            {
                v = vc + (a * t);
            }

            if (v.magnitude >= Vm)
            {
                v = (v.normalized) * Vm;
            }

            pc = pc + (v * t);

            Debug.Log("a = " + a);
            Debug.Log("v = " + v);
            Debug.Log("pc = " + pc);
        }
        else
        {
            a = am * Nvd;
            v = vc + a * t;

            if (v.magnitude >= Vm)
            {
                v = (v.normalized) * Vm;
            }

            pc = pc + (v * t);
            Debug.Log("a = " + a);
            Debug.Log("v = " + v);
            Debug.Log("pc = " + pc);
        }

        Debug.Log("Point 2");
        if (velv < rs)
        {
            Vector2 govel = ((velv / rs) * Vm) * (Nvd);
            a = (govel - vc) / t2t;

            if (a.magnitude >= am)
            {
                a = a.normalized * Vm;
            }

            if (velv < ra)
            {
                v = new Vector2(0, 0);
            }
            else
            {
                v = vc + (a * t);
            }

            if (v.magnitude >= Vm)
            {
                v = (v.normalized) * Vm;
            }

            pc = pc + (v * t);

            Debug.Log("a = " + a);
            Debug.Log("v = " + v);
            Debug.Log("pc = " + pc);
        }
        else
        {
            a = am * Nvd;
            v = vc + a * t;

            if (v.magnitude >= Vm)
            {
                v = (v.normalized) * Vm;
            }

            pc = pc + (v * t);
            Debug.Log("a = " + a);
            Debug.Log("v = " + v);
            Debug.Log("pc = " + pc);
        }
        Debug.Log("Point 4");
        if (velv < rs)
        {
            Vector2 govel = ((velv / rs) * Vm) * (Nvd);
            a = (govel - vc) / t2t;

            if (a.magnitude >= am)
            {
                a = a.normalized * Vm;
            }

            if (velv < ra)
            {
                v = new Vector2(0, 0);
            }
            else
            {
                v = vc + (a * t);
            }

            if (v.magnitude >= Vm)
            {
                v = (v.normalized) * Vm;
            }

            pc = pc + (v * t);

            Debug.Log("a = " + a);
            Debug.Log("v = " + v);
            Debug.Log("pc = " + pc);
        }
        else
        {
            a = am * Nvd;
            v = vc + a * t;

            if (v.magnitude >= Vm)
            {
                v = (v.normalized) * Vm;
            }

            pc = pc + (v * t);
            Debug.Log("a = " + a);
            Debug.Log("v = " + v);
            Debug.Log("pc = " + pc);
        }
        Debug.Log("Point 5");
        if (velv < rs)
        {
            Vector2 govel = ((velv / rs) * Vm) * (Nvd);
            a = (govel - vc) / t2t;

            if (a.magnitude >= am)
            {
                a = a.normalized * Vm;
            }

            if (velv < ra)
            {
                v = new Vector2(0, 0);
            }
            else
            {
                v = vc + (a * t);
            }

            if (v.magnitude >= Vm)
            {
                v = (v.normalized) * Vm;
            }

            pc = pc + (v * t);

            Debug.Log("a = " + a);
            Debug.Log("v = " + v);
            Debug.Log("pc = " + pc);
        }
        else
        {
            a = am * Nvd;
            v = vc + a * t;

            if (v.magnitude >= Vm)
            {
                v = (v.normalized) * Vm;
            }

            pc = pc + (v * t);
            Debug.Log("a = " + a);
            Debug.Log("v = " + v);
            Debug.Log("pc = " + pc);
        }

    }

    // Update is called once per frame
    void Update()
    {
        //if (gameObject.GetComponent<Rigidbody>().velocity.magnitude < 0.5)
        {

            //gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * .5f);
        }
    }
}
