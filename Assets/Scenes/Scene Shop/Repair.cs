using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Repair : MonoBehaviour
{
    private void OnMouseDown()
    {
        int cost = transform.GetComponent<CostScript>().cost;
        if (planescr.PlaneMoney >= cost)
        {
            GetComponent<AudioSource>().Play();
            planescr a = GameObject.Find("plane").GetComponent<planescr>();
            planescr.PlaneMoney -= cost;
            planescr.hp = planescr.maxhp + 1;
            Debug.Log(planescr.hp);
            a.PlusMoney(0);
            a.OnDamage();
            Destroy(gameObject);
        }
    }
    /*
    void Tetx()
    {
        GameObject E = Instantiate(Cost, transform.position * 100f, Quaternion.identity, GameObject.Find("Canvas").transform);
        E.GetComponent<Text>().text = cost.ToString();
    }*/
}
