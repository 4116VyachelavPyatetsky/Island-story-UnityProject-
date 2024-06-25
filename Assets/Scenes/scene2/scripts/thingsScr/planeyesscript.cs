using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class planeyesscript : MonoBehaviour
{
    public int id = 0;
    public int hpup;
    public string b;
    public float speedup;
    public Sprite newspr;
    public GameObject Name;
    GameObject player,lil,tetx,canv,A;
    void Start()
    {
        A = Instantiate(Name);
        canv = GameObject.Find("Canvas");
        A.transform.SetParent(canv.transform, false);
        player = GameObject.Find("plane");
        lil = GameObject.Find("lil");
        tetx = GameObject.Find("helattet");
        A.GetComponent<Text>().text = b;
    }
    void OnMouseDown()
    {
        Make();
    }
    void Make()
    {
        GameObject.Find("Button").GetComponent<AudioSource>().Play();
        wavescript.wavescomle = 0;
        planescr.maxhp += hpup;
        planescr.hp += hpup + 1;
        player.GetComponent<planescr>().OnDamage();
        tetx.GetComponent<Text>().text = planescr.hp.ToString() + "/" + planescr.maxhp.ToString();
        if (maijs.speed <= 0.002f)
        {
            maijs.speed += speedup;
        }
        Destroy(gameObject.transform.parent.gameObject.transform.parent.gameObject);
        Destroy(A);
        player.GetComponent<SpriteRenderer>().sprite = newspr;
        //wavescript.stuff.Add(id);
        if (!Saves.inshop)
        {
            changemapscene.Change();
        }
    }
}
