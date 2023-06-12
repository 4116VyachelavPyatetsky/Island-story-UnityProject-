using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyTuba : MonoBehaviour
{
    private void OnMouseDown()
    {
        int cost = transform.GetComponent<CostScript>().cost;
        if (planescr.PlaneMoney >= cost)
        {
            planescr.PlaneMoney -= cost;
            GameObject.Find("plane").GetComponent<planescr>().PlusMoney(0);
            Destroy(gameObject);
            Saves.TrubaBought += 1;
        }
    }
}
