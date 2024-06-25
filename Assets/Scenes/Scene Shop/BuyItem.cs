using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyItem : MonoBehaviour
{
    public GameObject item;
    private void OnMouseDown()
    {
        int cost = transform.GetComponent<CostScript>().cost;
        if (planescr.PlaneMoney >= cost)
        {
            GetComponent<AudioSource>().Play();
            planescr.PlaneMoney -= cost;
            GameObject.Find("plane").GetComponent<planescr>().PlusMoney(0);
            Instantiate(item);
            Destroy(gameObject);
        }
    }
}
