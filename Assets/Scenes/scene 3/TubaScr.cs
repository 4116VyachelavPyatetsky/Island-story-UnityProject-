using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TubaScr : MonoBehaviour
{
    public static bool activated = false;
    public GameObject score;
    private void Start()
    {
        GameObject a = Instantiate(score,GameObject.Find("Canvas").transform);
        a.GetComponent<Text>().text = Saves.TrubaBought.ToString();
    }
    private void OnMouseDown()
    {
        activated = true;
    }
}
