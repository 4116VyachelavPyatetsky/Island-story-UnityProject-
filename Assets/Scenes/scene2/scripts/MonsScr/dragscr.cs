using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragscr : MonoBehaviour
{
    public bool napr = false;
    bool change = false;
    float speed = 0.08f;
    public bool straight = true;
    public GameObject b1, b2, b3;
    bool bo1 = true;
    bool bo2 = true;
    bool bo3 = true;
    Vector3 pos = new Vector3(0.0f,0.0f,0.0f);
    Vector3 sus;
    void FixedUpdate()
    {
        if (!straight&& !wavescript.gamestopped)
        {
            if (gameObject.transform.position.x >= 2.6f)
            {
                napr = false;
                change = true;
                b1.transform.parent = null;
                b2.transform.parent = null;
                b3.transform.parent = null;
                bo1 = false;
                bo2 = false;
                bo3 = false;
                gameObject.transform.rotation = Quaternion.Euler(0, 0, -45);
                pos = gameObject.transform.position;
            }
            else if (gameObject.transform.position.x <= -2.6f)
            {
                napr = true;
                change = true;
                b1.transform.parent = null;
                b2.transform.parent = null;
                b3.transform.parent = null;
                bo1 = false;
                bo2 = false;
                bo3 = false;
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 45);
                pos = gameObject.transform.position;
            }
            if (gameObject.transform.parent.gameObject.transform.position.y <= -2.56f)
            {
                if (!napr)
                {
                    gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(gameObject.transform.position.x - 8.0f, gameObject.transform.position.y - 8.0f, 0.0f), speed  );
                }
                else
                {
                    gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(gameObject.transform.position.x + 8.0f, gameObject.transform.position.y - 8.0f, 0.0f), speed );
                }
            }
            if (change)
            {
                if (!bo1)
                {
                    povorot(b1, ref bo1);
                }
                if (!bo2)
                {
                    povorot(b2, ref bo2);
                }
                if (!bo3)
                {
                    povorot(b3, ref bo3);
                }
                if (bo1 && bo2 && bo3)
                {
                    change = false;
                }
            }
        }
        else if(!wavescript.gamestopped)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 18.0f, 0.0f), speed );
        }
        if (gameObject.transform.position.y <= -6.6f)
        {
            Destroy(gameObject.GetComponent<enemyhp>().health);
            Destroy(gameObject);
        }
    }
    void povorot(GameObject a,ref bool c)
    {
        if ((a.transform.position-pos).magnitude < 0.02f)
        {
            if (napr)
            {
                a.transform.rotation = Quaternion.Euler(0, 0, 45);
            }

            else
            {
                a.transform.rotation = Quaternion.Euler(0, 0, -45);
            }
            c = true;
            a.transform.SetParent(gameObject.transform);
            a.transform.localPosition = new Vector3(0, 0.5659999f +((transform.childCount-1) * 0.451f),0);
        }
        else
        {
            a.transform.position = Vector3.MoveTowards(a.transform.position, pos, speed);
        }
    }
    void OnTriggerEnter2D(Collider2D lel)
    {
        if (lel.gameObject.tag == "Player")
        {
            planescr fiv = lel.GetComponent<planescr>();
            fiv.OnDamage();
        }
    }
}
