using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pivScr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float angle = 360f / transform.childCount;
        int i = 0;
        foreach(Transform x in transform)
        {
            x.localPosition = new Vector3(2.57f * Mathf.Cos(angle*i / Mathf.Rad2Deg), 2.57f * Mathf.Sin(angle * i / Mathf.Rad2Deg), 0);
            i++;
        }
    }
    private void FixedUpdate()
    {
        transform.Rotate(0,0, 1f, Space.Self);
    }
}
