using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    GameObject plane;
    public static bool specItem = false;
    public int cost;
    void Start()
    {
        plane = GameObject.Find("plane");
    }
    void FixedUpdate()
    {
        if (wavescript.gamestopped)
        {
            Destroy(gameObject);
        }
        else
        {
            if (specItem || (transform.position - plane.transform.position).magnitude < 1.0f)
            {
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(plane.transform.position.y - transform.position.y, plane.transform.position.x - transform.position.x) * Mathf.Rad2Deg - 90);
                transform.position = Vector3.MoveTowards(gameObject.transform.position, plane.transform.position, 0.2f);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, transform.position + Vector3.down, 0.1f);
            }
            if (transform.position.y < -7f)
            {
                Destroy(gameObject);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D lel)
    {
        if (lel.gameObject.tag == "Player" || lel.gameObject.tag == "DamagedPlayer")
        {
            planescr fiv = lel.GetComponent<planescr>();
            fiv.PlusMoney(cost);
            Destroy(gameObject);
        }
    }
}
