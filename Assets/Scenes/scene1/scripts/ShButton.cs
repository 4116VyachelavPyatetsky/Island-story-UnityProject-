using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShButton : MonoBehaviour
{
    public GameObject cost_txt;
    bool buut=true;
    void OnMouseDown()
    {
        gameObject.GetComponent<Animation>().Play("KnopAnim");
        if (buut)
        {
            buut = false;
            cost_txt.transform.position = new Vector3(cost_txt.transform.position.x + 300.0f, cost_txt.transform.position.y, 0.0f);
            transform.parent.gameObject.transform.position = new Vector3(1.7f, -2.1f, 0.0f);
        }
        else
        {
            buut = true;
            cost_txt.transform.position = new Vector3(cost_txt.transform.position.x - 300.0f, cost_txt.transform.position.y, 0.0f);
            transform.parent.gameObject.transform.position = new Vector3(-2f, -2.1f, 0.0f);
        }
    }
}
