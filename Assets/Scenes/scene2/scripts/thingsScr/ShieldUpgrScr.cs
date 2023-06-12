using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUpgrScr : MonoBehaviour
{
    bool right = true;
    private void FixedUpdate()
    {
        if (right)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 80f), 0.02f);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -80f), 0.02f);
        }
        //Debug.Log(transform.rotation.eulerAngles.z);
        if (transform.rotation.eulerAngles.z >= 60f && transform.rotation.eulerAngles.z < 70f)
        {
            right = false;
        }
        else if (transform.rotation.eulerAngles.z <= 300f && transform.rotation.eulerAngles.z > 270f)
        {
            right = true;
        }
    }
}
