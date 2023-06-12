using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RapidUp : MonoBehaviour
{
    public GameObject Name;
    GameObject A;
    // Start is called before the first frame update
    void Start()
    {
        A = Instantiate(Name);
        A.transform.SetParent(GameObject.Find("Canvas").transform, false);
        A.GetComponent<Text>().text = "RapidUp";
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
        gunscrfirst.timebetweenShots -= 0.06f;
        GameObject.Find("startgun").GetComponent<Animator>().SetTrigger("GetUpgr");
        if (!Saves.inshop)
        {
            changemapscene.Change();
        }
    }
}
