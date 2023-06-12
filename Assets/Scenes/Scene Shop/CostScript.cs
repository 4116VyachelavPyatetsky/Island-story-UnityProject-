using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CostScript : MonoBehaviour
{
    public int cost;
    public int number;
    public GameObject Costxt;
    GameObject E;
    private void Start()
    {
        E = Instantiate(Costxt, new Vector3(139f + 120f*(number) , 237f, 0), Quaternion.identity,GameObject.Find("Canvas").transform);
        E.GetComponent<Text>().text = cost.ToString();
    }
    private void OnDisable()
    {
        Destroy(E);
    }
}
