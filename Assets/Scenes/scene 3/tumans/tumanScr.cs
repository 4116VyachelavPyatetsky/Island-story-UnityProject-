using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tumanScr : MonoBehaviour
{
    public GameObject videle;
    GameObject vid;
    bool Obvod = false;
    Collider2D coll;
    private void Start()
    {
        coll = transform.GetComponent<Collider2D>();
        coll.enabled = false;
    }
    private void Update()
    {
        if (TubaScr.activated && !Obvod)
        {
            vid = Instantiate(videle, transform.position, Quaternion.identity, transform);
            coll.enabled = true;
            Obvod = true;
        }
        if(!TubaScr.activated && Obvod)
        {
            Destroy(vid);
            Obvod = false;
        }
    }
    private void OnMouseDown()
    {
        if (TubaScr.activated)
        {
            Destroy(gameObject);
            TubaScr.activated = false;
            Saves.TrubaBought -= 1;
            GameObject.Find("SchetTuba").GetComponent<Text>().text = Saves.TrubaBought.ToString();
            if (Saves.TrubaBought == 0) 
            {
                GameObject.Find("Tuba").SetActive(false) ;
            }

        }
    }
}
