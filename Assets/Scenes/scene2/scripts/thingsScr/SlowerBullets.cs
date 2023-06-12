using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowerBullets : MonoBehaviour
{
    public GameObject Name;
    GameObject A;
    void Start()
    {
        A = Instantiate(Name);
        A.transform.SetParent(GameObject.Find("Canvas").transform, false);
        A.GetComponent<Text>().text = "Bullets slowed";
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
        bullscript.Bullspeed *= 0.7f;
        if (!Saves.inshop)
        {
            changemapscene.Change();
        }
    }
}
