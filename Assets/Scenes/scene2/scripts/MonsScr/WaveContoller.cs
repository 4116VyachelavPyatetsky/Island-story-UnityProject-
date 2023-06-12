using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveContoller : MonoBehaviour
{
    public GameObject[] drags;
    public GameObject[] snakes;
    bool once = false;
    private void Update()
    {
        if (!once && transform.position.y <= -2.46)
        {
            once = true;
            foreach (GameObject x in snakes)
            {
                x.GetComponent<SnakeEnem>().OprDots();
            }
            foreach (GameObject x in drags)
            {
                x.GetComponent<BokDrag>().onscene = true;
                x.GetComponent<BokDrag>().NewPos();
            }

        }
    }
    public float PosProve(GameObject drag)
    {
        bool notright = true;
        float a = 0; ;
        while (notright)
        {
            a = Random.Range(-1.59f, 4.01f);
            bool b = true;
            foreach (GameObject x in drags)
            {
                if (x != null)
                {
                    if ((drag.transform.position.x < 0 && x.transform.position.x < 0) || (drag.transform.position.x > 0 && x.transform.position.x > 0) && drag != x)
                    {
                        if (a < x.transform.position.y + 0.9f && a > x.transform.position.y - 0.9f)
                        {
                            b = false;
                        }
                    }
                }
            }
            if (b) notright = false;
        }
        return a;
    }
}
