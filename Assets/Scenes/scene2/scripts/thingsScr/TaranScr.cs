using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaranScr : MonoBehaviour
{
    public GameObject Name;
    GameObject A;
    void Start()
    {
        A = Instantiate(Name);
        A.transform.SetParent(GameObject.Find("Canvas").transform, false);
        A.GetComponent<Text>().text = "Damage with touch";
    }
    void OnMouseDown()
    {
        Make();
    }
    void Make()
    {
        wavescript.wavescomle = 0;
        Destroy(gameObject.transform.parent.gameObject.transform.parent.gameObject);
        Destroy(A);
        planescr.upgr = true;
        if (!Saves.inshop)
        {
            changemapscene.Change();
        }
    }
}
