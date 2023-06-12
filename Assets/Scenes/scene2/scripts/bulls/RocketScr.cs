using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScr : MonoBehaviour
{
    GameObject target;
    public GameObject boom;
    bool find = false;
    public static float Radius = 1f;
    public static int RocketDamage = 5;
    public Sprite upgrspr;
    public static bool upgr = false;
    void Start()
    {
        target = DefineTarget();
        if (upgr) gameObject.GetComponent<SpriteRenderer>().sprite = upgrspr;
    }
    void FixedUpdate()
    {
        if (wavescript.gamestopped) Destroy(gameObject);
        if(target == null)
        {
            find = false;
        }
        if (find)
        {
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(target.transform.position.y - transform.position.y, target.transform.position.x - transform.position.x) * Mathf.Rad2Deg - 90);
            transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, 0.1f);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.up, 0.1f);
        }
        objectoutofarena.outofarena(gameObject);

    }
    private void OnTriggerEnter2D(Collider2D lel)
    {
        if (lel.gameObject.tag == "enemy" || lel.gameObject.tag == "drag" || lel.gameObject.tag == "body" || lel.gameObject.tag == "Schield")
        {
            GameObject b = Instantiate(boom, transform.position, Quaternion.identity);
            if (upgr) b.transform.localScale = new Vector3(2, 2, 0);
            Boom();
            Destroy(gameObject);
        }
    }
    GameObject DefineTarget()
    {
        GameObject A = GameObject.Find("Main Camera");
        A = A.GetComponent<wavescript>().wave;
        GameObject Target = gameObject;
        if (A != null)
        {
            find = true;
            float lastMag = 100f;
            foreach (Transform child in A.transform)
            {
                if (child.gameObject.tag == "pvt")
                {
                    if ((child.GetChild(0).position - transform.position).magnitude < lastMag)
                    {
                        lastMag = (child.GetChild(0).position - transform.position).magnitude;
                        Target = child.GetChild(0).gameObject;
                    }
                }
                else if (child.gameObject.tag == "Snake")
                {
                    foreach(Transform x in child)
                    {
                        if ((x.position - transform.position).magnitude < lastMag)
                        {
                            lastMag = (x.position - transform.position).magnitude;
                            Target = x.gameObject;
                        }
                    }
                }
                else
                {
                    if ((child.position - transform.position).magnitude < lastMag)
                    {
                        lastMag = (child.position - transform.position).magnitude;
                        Target = child.gameObject;
                    }
                }
            }
        }
        return (Target);
    }
    void Boom()
    {
        GameObject A = GameObject.Find("Main Camera");
        A = A.GetComponent<wavescript>().wave;
        if (A != null)
        {
            foreach (Transform child in A.transform)
            {
                if(child.gameObject.tag == "pvt")
                {
                    if ((child.GetChild(0).position - transform.position).magnitude < Radius)
                    {
                        child.GetChild(0).GetComponent<enemyhp>().enemIsDamaged(RocketDamage);
                    }
                }
                else if(child.gameObject.tag == "Snake")
                {
                    foreach(Transform x in child)
                    {
                        if((x.position - transform.position).magnitude < Radius)
                        {
                            child.GetComponent<enemyhp>().enemIsDamaged(RocketDamage);
                        }
                    }
                }
                else if ((child.position - transform.position).magnitude < Radius)
                {
                    if(child.tag != "Schield")
                    {
                        child.GetComponent<enemyhp>().enemIsDamaged(RocketDamage);
                    }
                }
            }
        }
    }
}
