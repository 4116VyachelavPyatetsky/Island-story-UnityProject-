using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullscript : MonoBehaviour
{
    GameObject A;
    public float Angle = 0;
    public static bool bouncing = false;
    public static bool homing = false;
    public Sprite upgrSpr;
    GameObject Wave;
    float homingDistance = 2.0f;
    public static float Bullspeed = 10.8f;
    int amountOfBounces = 1;
    public static int dmg = 2;
    public Vector3 target;
    private void Start()
    {
        if (homing)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = upgrSpr;
        }
        Wave = GameObject.Find("Main Camera").GetComponent<wavescript>().wave;
        target = transform.position + new Vector3(Mathf.Cos((90 - Angle) * Mathf.Deg2Rad) * 16.0f, Mathf.Sin((90 - Angle) * Mathf.Deg2Rad) * 16.0f, 0);
        if (PlayerPrefs.HasKey("dmg")) dmg = PlayerPrefs.GetInt("dmg");
    }
    void Update()
    {
        if (homing && amountOfBounces == 1)
        {
            FindingOfTarget();
            if (transform.position == target) target = transform.position + transform.up ;
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(target.y - transform.position.y, target.x - transform.position.x) * Mathf.Rad2Deg - 90);
        }
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target, Bullspeed * Time.deltaTime);
        objectoutofarena.outofarena(gameObject);
    }
    void OnTriggerEnter2D(Collider2D lel)
    {
        if (lel.gameObject.tag == "enemy" || lel.gameObject.tag == "drag")
        {
            if (bouncing && amountOfBounces != 0)
            {
                amountOfBounces -= 1;
                float ang = Random.Range(-90, 90);
                target = transform.position + transform.up * 10f;
            }
            else
            {
                Destroy(gameObject);
            }
            enemyhp fiv = lel.GetComponent<enemyhp>();
            fiv.enemIsDamaged(dmg);
        }
        if (lel.gameObject.tag == "body")
        {
            if (amountOfBounces == 0 || !bouncing)
            {
                Destroy(gameObject);
            }
            else
            {
                amountOfBounces -= 1;
                float ang = Random.Range(-90, 90);
                target = transform.position + transform.up * 10f;
            }
            if (lel.transform.parent != null)
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
    void FindingOfTarget()
    {
        float lastMag = 100f;
        if (Wave != null)
        {
            foreach (Transform child in Wave.transform)
            {
                if (child.gameObject.tag == "pvt")
                {
                    if ((child.GetChild(0).position - transform.position).magnitude < lastMag && (child.GetChild(0).position - transform.position).magnitude < homingDistance)
                    {
                        lastMag = (child.GetChild(0).position - transform.position).magnitude;
                        target = child.GetChild(0).position;
                    }
                }
                else if (child.gameObject.tag == "Snake")
                {
                    foreach (Transform x in child)
                    {
                        if ((x.position - transform.position).magnitude < lastMag && (x.position - transform.position).magnitude < homingDistance)
                        {
                            lastMag = (x.position - transform.position).magnitude;
                            target = x.position;
                        }
                    }
                }
                else
                {
                    if ((child.position - transform.position).magnitude < lastMag && (child.position - transform.position).magnitude < homingDistance)
                    {
                        lastMag = (child.position - transform.position).magnitude;
                        target = child.position;
                    }
                }
            }
        }
    }
}
