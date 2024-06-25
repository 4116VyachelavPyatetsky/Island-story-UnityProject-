using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddShield : MonoBehaviour
{
    public GameObject Name;
    GameObject A;
    public GameObject shield;
    // Start is called before the first frame update
    void Start()
    {
        A = Instantiate(Name);
        A.transform.SetParent(GameObject.Find("Canvas").transform, false);
        A.GetComponent<Text>().text = "Вы под защитой";
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
        Instantiate(shield, GameObject.Find("plane").transform);
        if (!Saves.inshop)
        {
            changemapscene.Change();
        }
    }
}
