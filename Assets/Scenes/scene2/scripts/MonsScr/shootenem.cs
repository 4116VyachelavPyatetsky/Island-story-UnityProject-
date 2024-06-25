using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootenem : MonoBehaviour
{
    public GameObject projectie;
    GameObject target;
    Animator anim,bull;
    public bool moving = false;
    bool whmx = true;
    bool whmy = true;
    public float b;
    float kick = 3.0f; 
    float startpos;
    float posy;
    bool isBusy = false;

    AudioSource au;
    void Start()
    {
        au = gameObject.GetComponent<AudioSource>();
        anim = gameObject.GetComponent<Animator>();
        target = GameObject.Find("plane");
    }
    void Update()
    {
        if (!isBusy && gameObject.transform.position.y <= 4.8f && !wavescript.gamestopped)
        {
            StartCoroutine(Wait());
        }
        if (moving)
        {
            if (gameObject.transform.parent.gameObject.transform.position.y <= -2.56f) {
                if (gameObject.transform.position.x < 0.0f) whmx = false;
                if (whmx)
                {
                    if (gameObject.transform.position.y > kick) whmy = false;
                    if (whmy)
                    {
                        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(2.5f, gameObject.transform.position.y, 0.0f), 3f * Time.deltaTime);
                        if (gameObject.transform.position.x >= 2.5f / 2)
                        {
                            posy = 3 - Mathf.Sqrt(1 - Mathf.Pow(2.5f - gameObject.transform.position.x - Mathf.Sqrt(2.5f), 2) / 2.5f);
                        }
                        else
                        {
                            posy = 3 - Mathf.Sqrt(1 - Mathf.Pow(gameObject.transform.position.x - Mathf.Sqrt(2.5f), 2) / 2.5f);
                        }
                        gameObject.transform.position = new Vector3(gameObject.transform.position.x, posy, 0.0f);
                        if (gameObject.transform.position.x >= 2.5f) whmy = false;
                    }
                    else
                    {
                        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(0.0f, gameObject.transform.position.y, 0.0f), 3f * Time.deltaTime);
                        if (gameObject.transform.position.x >= 2.5f / 2)
                        {
                            posy = 3 + Mathf.Sqrt(1 - Mathf.Pow(2.5f - gameObject.transform.position.x - Mathf.Sqrt(2.5f), 2) / 2.5f);
                        }
                        else
                        {
                            posy = 3 + Mathf.Sqrt(1 - Mathf.Pow(gameObject.transform.position.x - Mathf.Sqrt(2.5f), 2) / 2.5f);
                        }
                        gameObject.transform.position = new Vector3(gameObject.transform.position.x, posy, 0.0f);
                        if (gameObject.transform.position.x == 0.0f)
                        {
                            whmy = true;
                            whmx = false;
                        }
                    }
                }
                else
                {
                    if (gameObject.transform.position.y > kick) whmy = false;
                    if (whmy)
                    {
                        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(-2.5f, gameObject.transform.position.y, 0.0f), 3f * Time.deltaTime);
                        if (gameObject.transform.position.x <= -2.5f / 2)
                        {
                            posy = 3 - Mathf.Sqrt(1 - Mathf.Pow(-2.5f - gameObject.transform.position.x + Mathf.Sqrt(2.5f), 2) / 2.5f);
                        }
                        else
                        {
                            posy = 3 - Mathf.Sqrt(1 - Mathf.Pow(gameObject.transform.position.x + Mathf.Sqrt(2.5f), 2) / 2.5f);
                        }
                        gameObject.transform.position = new Vector3(gameObject.transform.position.x, posy, 0.0f);
                        if (gameObject.transform.position.x <= -2.5f) whmy = false;
                    }
                    else
                    {
                        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, new Vector3(0.0f, gameObject.transform.position.y, 0.0f), 3f * Time.deltaTime);
                        if (gameObject.transform.position.x <= -2.5f / 2)
                        {
                            posy = 3 + Mathf.Sqrt((1 - Mathf.Pow(-2.5f - gameObject.transform.position.x + Mathf.Sqrt(2.5f), 2) / 2.5f));
                        }
                        else
                        {
                            posy = 3 + Mathf.Sqrt((1 - Mathf.Pow(gameObject.transform.position.x + Mathf.Sqrt(2.5f), 2) / 2.5f));
                        }
                        gameObject.transform.position = new Vector3(gameObject.transform.position.x, posy, 0.0f);
                        if (gameObject.transform.position.x == 0.0f)
                        {
                            whmy = true;
                            whmx = true;
                        }
                    }
                }
            }
        }
    }
    IEnumerator Wait()
    {
        isBusy = true;
        anim.SetBool("atack", true);
        yield return new WaitForSeconds(0.83f);
        au.Play();
        GameObject A = Instantiate(projectie, gameObject.transform.position, Quaternion.identity);
        Vector3 promej = target.transform.position;
        A.GetComponent<projscript>().rastoynie = promej + (promej - transform.position) * 10;
        A.GetComponent<projscript>().Vzriv = false;
        A.GetComponent<projscript>().projSpeed = 8f;
        bull = A.GetComponent<Animator>();
        bull.SetBool("bulltype", true);
        A.transform.localScale = new Vector3(0.5f, 0.5f, 1.0f);
        anim.SetBool("atack", false);
        yield return new WaitForSeconds(2.0f);
        isBusy = false;
    }
}
