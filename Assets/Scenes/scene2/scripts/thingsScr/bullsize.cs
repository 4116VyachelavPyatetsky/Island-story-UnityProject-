using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bullsize : MonoBehaviour
{
    public string b;
    public GameObject Name;
    GameObject player, lil, tetx, canv, A;
    void Start()
    {
        A = Instantiate(Name);
        canv = GameObject.Find("Canvas");
        A.transform.SetParent(canv.transform, false);
        lil = GameObject.Find("lil");
        tetx = GameObject.Find("helattet");
        A.GetComponent<Text>().text = b;
    }
    void OnMouseDown()
    {
        //wavescript.gamestopped = false;
        wavescript.wavescomle = 0;
        gunscrfirst.size += 0.5f;
        bullscript.dmg += 1;
        Destroy(gameObject.transform.parent.gameObject.transform.parent.gameObject);
        Destroy(A);
        if (!Saves.inshop)
        {
            changemapscene.Change();
        }
        //SceneManager.LoadScene("scene map");
    }
}
