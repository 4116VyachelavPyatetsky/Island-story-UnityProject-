using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upward : MonoBehaviour
{
    void OnMouseDown()
    {
        gameObject.GetComponent<Animation>().Play("NewKnopAnim");
        mapscr.pprelast[0] = mapscr.p[0];
        mapscr.pprelast[1] = mapscr.p[1];
        mapscr.p[0]++;
    }
    public void Vizov()
    {
        changeback.change();
    }
}
