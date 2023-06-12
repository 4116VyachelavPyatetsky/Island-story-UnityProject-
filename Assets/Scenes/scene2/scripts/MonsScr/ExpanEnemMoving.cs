using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpanEnemMoving : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D lel)
    {
        if (lel.gameObject.tag == "Player")
        {
            planescr fiv = lel.GetComponent<planescr>();
            fiv.OnDamage();
        }
    }
}
