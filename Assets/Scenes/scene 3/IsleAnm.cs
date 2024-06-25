using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsleAnm : MonoBehaviour
{
    public Vector3 StartPos,EndPos;
    bool up = false;
    private void Start()
    {
        StartPos = transform.position;
        EndPos = StartPos - new Vector3(0, 0.1f+Random.Range(-0.05f,0.05f), 0);
    }
    void FixedUpdate()
    {
        if (up)
        {
            transform.position = Vector3.MoveTowards(transform.position, StartPos, 0.0002f);
            if (transform.position.y+ 0.0002f >= StartPos.y) up = !up;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, EndPos, 0.0002f);
            if (transform.position.y- 0.0002f <= EndPos.y) up = !up;
        }

    }
}
