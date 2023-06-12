using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomingBullets : MonoBehaviour
{
    public GameObject Name;
    GameObject A;
    // Start is called before the first frame update
    void Start()
    {
        A = Instantiate(Name);
        A.transform.SetParent(GameObject.Find("Canvas").transform, false);
        A.GetComponent<Text>().text = "Homing bullets";
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
        bullscript.homing = true;
        if (!Saves.inshop)
        {
            changemapscene.Change();
        }
    }
}
