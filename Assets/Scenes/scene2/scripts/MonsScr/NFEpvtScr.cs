using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NFEpvtScr : MonoBehaviour
{
    bool napr = true;
    public bool move = true;
    public GameObject enm;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (move)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position - transform.up, 0.003f);
            if (napr)
            {
                transform.Rotate(0, 0, -1f, Space.Self);
                if (transform.rotation.eulerAngles.z < 322f && transform.rotation.eulerAngles.z > 320f)
                {
                    napr = false;
                    Smena();
                }
            }
            else
            {
                transform.Rotate(0, 0, 1f, Space.Self);
                if (transform.rotation.eulerAngles.z > 50f && transform.rotation.eulerAngles.z < 52f)
                {
                    napr = true;
                    Smena();
                }
            }
        }
    }
    void Smena()
    {
        enm.transform.rotation = Quaternion.Euler(0,0, enm.transform.rotation.eulerAngles.z+180f);
    }
}
