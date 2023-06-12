using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DopGunBull : MonoBehaviour
{
    int dmg = 1;
    void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, gameObject.transform.position+ transform.up, 10.8f * Time.deltaTime);
        objectoutofarena.outofarena(gameObject);
    }
    void OnTriggerEnter2D(Collider2D lel)
    {
        if (lel.gameObject.tag == "enemy" || lel.gameObject.tag == "drag")
        {
            Destroy(gameObject);
            enemyhp fiv = lel.GetComponent<enemyhp>();
            fiv.enemIsDamaged(dmg);
        }
        if (lel.gameObject.tag == "body")
        {
            Destroy(gameObject);
            if (lel.transform.parent.gameObject != null)
            {
                lel.gameObject.transform.parent.gameObject.GetComponent<enemyhp>().enemIsDamaged(dmg);
            }
            else lel.gameObject.GetComponent<dragbodyscr>().head.GetComponent<enemyhp>().enemIsDamaged(dmg);
            /*
            dragbodyscr fiv = lel.GetComponent<dragbodyscr>();
            A = fiv.head;
            enemyhp health = A.GetComponent<enemyhp>();
            health.enemIsDamaged(dmg);*/
        }
    }
}
