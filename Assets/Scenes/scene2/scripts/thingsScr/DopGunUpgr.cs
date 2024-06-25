using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DopGunUpgr : MonoBehaviour
{
    public GameObject Name;
    GameObject A;
    public GameObject gun;
    void Start()
    {
        A = Instantiate(Name);
        A.transform.SetParent(GameObject.Find("Canvas").transform, false);
        A.GetComponent<Text>().text = "Странная технология";
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
        Instantiate(gun,GameObject.Find("plane").transform);
        if (!Saves.inshop)
        {
            changemapscene.Change();
        }
    }
}
