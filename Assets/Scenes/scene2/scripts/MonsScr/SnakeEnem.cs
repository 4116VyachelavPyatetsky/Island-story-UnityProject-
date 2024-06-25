using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeEnem : MonoBehaviour
{
    public GameObject[] bodys;
    public int[] whatDot;
    Vector3[] dots;
    bool shoot = false;
    bool OnScene = false;

    private void FixedUpdate()
    {
        if (OnScene)
        {
            if (!shoot && !wavescript.gamestopped) StartCoroutine(Wait());
            for (int i = 0; i < bodys.Length; i++)
            {
                if (bodys[i] != null)
                {
                    bodys[i].transform.position = Vector3.MoveTowards(bodys[i].transform.position, dots[whatDot[i]], 0.032f);
                    if (bodys[i].transform.position == dots[whatDot[i]])
                    {
                        whatDot[i]++;
                    }
                    if (bodys[i].transform.position.y < -5.56f * wavescript.screenSizePere)
                    {
                        if (transform.childCount == 1)
                        {
                            Destroy(gameObject.GetComponent<enemyhp>().health);
                            Destroy(gameObject);
                        }
                        else
                        {
                            Destroy(bodys[i]);
                            gameObject.GetComponent<enemyhp>().OtherObject = transform.GetChild(transform.childCount / 2 - 1);
                        }
                    }
                }
            }
        }
    }
    IEnumerator Wait()
    {
        shoot = true;
        
        int x = Random.Range(0, bodys.Length);
        for (int i = x; i >= Random.Range(0, x); i--)
        {
            if (bodys[i] != null)
            {
                bodys[i].transform.GetChild(0).gameObject.GetComponent<SnakeShoot>().StartAttack();
                yield return new WaitForSeconds(0.4f);
            }
        }
        yield return new WaitForSeconds(1f);
        shoot = false;
    }

    public void OprDots()
    {
        int x = Random.Range(5, 15);
        if (x % 2 == 0) x++;
        dots = new Vector3[x];
        whatDot = new int[bodys.Length];
        for (int i = 0; i < whatDot.Length; i++)
        {
            whatDot[i] = 0;
        }
        dots[0] = new Vector3(transform.position.x, bodys[bodys.Length - 1].transform.position.y - Random.Range(1.5f, 2f), 0);
        for (int i = 1; i < dots.Length - 1; i++)
        {
            if (i % 2 == 0)
            {
                dots[i] = new Vector3(dots[i - 1].x, dots[i - 1].y - Random.Range(1.0f, 2f), 0);
            }
            else
            {
                float a = 0;
                if (dots[i - 1].x < 0f) a = Random.Range(1.5f, 3.5f);
                else a = Random.Range(-3.5f, -1.5f);
                dots[i] = new Vector3(dots[i - 1].x + a, dots[i - 1].y, 0);
            }
        }
        dots[dots.Length - 1] = new Vector3(dots[dots.Length - 2].x, dots[dots.Length - 2].y - 100f, 0);
        OnScene = true;
    }
}
