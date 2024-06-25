using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnScr : MonoBehaviour
{
    public GameObject[] enemeis;
    public Animation door;
    bool isBusy = false;
    bool pvtbl = false;
    public GameObject pvt;
    int enem = 2;
    GameObject nowEnem;
    AudioSource au;

    private void Start()
    {
        door = transform.GetChild(0).GetComponent<Animation>();
        au = transform.GetChild(0).GetComponent<AudioSource>();
    }
    void FixedUpdate()
    {
        if(!isBusy && transform.position.y <3.7f)StartCoroutine(Wait());
        if (nowEnem != null)
        {
            if (enem != 0 && pvtbl)
            {
                if(nowEnem.transform.position.y > 2.52f && enem == 1)
                {
                    nowEnem.transform.position = Vector3.MoveTowards(nowEnem.transform.position, nowEnem.transform.position - new Vector3(0, 1, 0), 0.07f);
                }
                else if (nowEnem.transform.position.y > -1f && enem == 2)
                {
                    nowEnem.transform.position = Vector3.MoveTowards(nowEnem.transform.position, nowEnem.transform.position - new Vector3(0, 1, 0), 0.07f);
                }
                else if (pvtbl)
                {
                    if(enem == 1) nowEnem.transform.SetParent(pvt.transform);
                    else nowEnem.GetComponent<NFEpvtScr>().move = true;
                    pvtbl = false;
                }
            }
            
        }

    }
    IEnumerator Wait()
    {
        isBusy = true;
        yield return new WaitForSeconds(4.0f);
        enem = Random.Range(0, 3);
        if(enem == 1)
        {
            nowEnem = Instantiate(enemeis[enem], new Vector3(0, 4.2f, 0), Quaternion.identity,transform.parent);
            pvtbl = true;
        }
        else if(enem == 0)
        {
            nowEnem = Instantiate(enemeis[enem], new Vector3(0, 2.6f, 0), Quaternion.identity, transform.parent);
            nowEnem.GetComponent<SnakeEnem>().OprDots();
        }
        else
        {
            nowEnem = Instantiate(enemeis[enem], new Vector3(0, 1.57f, 0), Quaternion.identity, transform.parent);
            nowEnem.GetComponent<NFEpvtScr>().move = false;
            pvtbl = true;
        }
        door.Play("doorAnm");
        au.Play();
        isBusy = false;
    }
}
