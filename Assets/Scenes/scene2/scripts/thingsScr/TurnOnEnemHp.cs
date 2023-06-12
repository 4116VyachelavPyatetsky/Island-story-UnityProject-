using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TurnOnEnemHp : MonoBehaviour
{
    public GameObject Name;
    GameObject A;
    void Start()
    {
        A = Instantiate(Name);
        A.transform.SetParent(GameObject.Find("Canvas").transform, false);
        A.GetComponent<Text>().text = "You see enemy HP";
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
        enemyhp.upgr = true;
        if (!Saves.inshop)
        {
            changemapscene.Change();
        }
    }
}
