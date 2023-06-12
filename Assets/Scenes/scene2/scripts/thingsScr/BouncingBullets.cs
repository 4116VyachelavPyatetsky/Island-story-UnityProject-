using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BouncingBullets : MonoBehaviour
{
    int id = 4;
    public GameObject Name;
    GameObject A;
    // Start is called before the first frame update
    void Start()
    {
        A = Instantiate(Name);
        A.transform.SetParent(GameObject.Find("Canvas").transform, false);
        A.GetComponent<Text>().text = "Bouncing bullets";
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        Make();
    }
    void Make()
    {
        wavescript.wavescomle = 0;
        Destroy(gameObject.transform.parent.gameObject.transform.parent.gameObject);
        Destroy(A);
        bullscript.bouncing = true;
        if (!Saves.inshop)
        {
            changemapscene.Change();
        }
    }
}
