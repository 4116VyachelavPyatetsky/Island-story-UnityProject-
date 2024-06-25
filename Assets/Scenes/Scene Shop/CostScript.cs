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
        E = Instantiate(Costxt, new Vector2(135f + 200f * (number), -285f), Quaternion.identity);
        E.transform.SetParent(GameObject.Find("CanvasShP").transform, false);
        E.GetComponent<Text>().text = cost.ToString();
    }
    private void OnDisable()
    {
        Destroy(E);
    }
}
