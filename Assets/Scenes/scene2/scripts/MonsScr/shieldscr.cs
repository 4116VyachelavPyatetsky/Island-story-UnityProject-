using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldscr : MonoBehaviour
{
    GameObject parent;
    bool napr = true;
    void Start()
    {
        parent = gameObject.transform.parent.gameObject;
    }
    void Update()
    {
        if (napr)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(2.0f, gameObject.transform.position.y, 0.0f), 2f * Time.deltaTime);
        }
        else
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(-2.0f, gameObject.transform.position.y, 0.0f), 2f * Time.deltaTime);
        }
        if (gameObject.transform.position.x >=2.0f)
        {
            napr = false;
        }
        if (gameObject.transform.position.x <= -2.0f)
        {
            napr = true;
        }
        if (parent.transform.childCount == 1)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D lel)
    {
        if (lel.gameObject.tag == "bull")
        {
            Destroy(lel.gameObject);
        }
        if (lel.gameObject.tag == "Player")
        {
            planescr fiv = lel.GetComponent<planescr>();
            fiv.OnDamage();
        } 
    }
    IEnumerator Wait(GameObject B)
    {
        yield return new WaitForSeconds(1.0f/12.0f);
        Destroy(B);
    }
}
