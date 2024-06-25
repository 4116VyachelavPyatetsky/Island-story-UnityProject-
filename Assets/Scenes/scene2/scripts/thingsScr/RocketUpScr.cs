using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketUpScr : MonoBehaviour
{
    public GameObject Name;
    GameObject A;
    // Start is called before the first frame update
    void Start()
    {
        A = Instantiate(Name);
        A.transform.SetParent(GameObject.Find("Canvas").transform, false);
        A.GetComponent<Text>().text = "Большие бомбы";
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
        RocketScr.Radius *= 2;
        RocketScr.RocketDamage *= 2;
        RocketScr.upgr = true;
        ShootRocket.amountOfRocket += 3;
        ShootRocket a = GameObject.Find("RocketButton").GetComponent<ShootRocket>();
        a.Upgr();
        a.UpdtText();
        if (!Saves.inshop)
        {
            changemapscene.Change();
        }
    }
}
