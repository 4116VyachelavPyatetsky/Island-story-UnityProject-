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
        A.GetComponent<Text>().text = "Урон при касании";
    }
    void OnMouseDown()
    {
        Make();
    }
    void Make()
    {
        GameObject.Find("Button").GetComponent<AudioSource>().Play();
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
