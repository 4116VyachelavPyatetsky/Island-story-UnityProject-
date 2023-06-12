using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class left : MonoBehaviour
{
    void OnMouseDown()
    {
        gameObject.GetComponent<Animation>().Play("NewKnopAnim");
        mapscr.pprelast[0] = mapscr.p[0];
        mapscr.pprelast[1] = mapscr.p[1];
        if (mapscr.p[1] == 0)
        {
            mapscr.p[1] += 1;
            mapscr.p[0] += 1;
        }
        else mapscr.p[1] += 1;
       
    }
    public void Vizov()
    {
        changeback.change();
    }
}
