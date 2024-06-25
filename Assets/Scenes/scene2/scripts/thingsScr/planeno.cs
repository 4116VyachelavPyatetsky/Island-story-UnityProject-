using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeno : MonoBehaviour
{
    public GameObject[] ups;
    void OnMouseDown()
    {
        GameObject.Find("Button").GetComponent<AudioSource>().Play();
        Destroy(gameObject.transform.parent.gameObject);
        Destroy(GameObject.Find("Text(Clone)"));
        if (!Saves.inshop)
        {
            changemapscene.Change();
        }
        //wavescript.gamestopped = false;
    }
    void Start()
    {
        //GameObject A = Instantiate(ups[Random.Range(0, ups.Length)]);
        int itemId = Random.Range(0, ups.Length);
        while (wavescript.GivedItems.Contains(itemId))
        {
            itemId = Random.Range(0, ups.Length);
        }
        wavescript.GivedItems.Add(itemId);
        GameObject A = Instantiate(ups[itemId]);
        //GameObject A = Instantiate(ups[4]);
        A.transform.SetParent(gameObject.transform.parent.gameObject.transform, false);
    }
}
