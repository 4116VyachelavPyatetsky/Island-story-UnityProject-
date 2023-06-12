using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PricelSbit : MonoBehaviour
{
    int id = 3;
    public GameObject Name;
    GameObject A;
    // Start is called before the first frame update
    void Start()
    {
        A = Instantiate(Name);
        A.transform.SetParent(GameObject.Find("Canvas").transform, false);
        A.GetComponent<Text>().text = "Scope is broken";
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
        if (Random.Range(0, 2) == 0) gunscrfirst.angle = Random.Range(-30, -20);
        else gunscrfirst.angle = Random.Range(30, 20);
        if (!Saves.inshop)
        {
            changemapscene.Change();
        }
    }
}
