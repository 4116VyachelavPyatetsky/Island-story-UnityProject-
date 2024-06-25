using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeachMobe : MonoBehaviour
{
    Transform targ;
    public GameObject leach;
    // Start is called before the first frame update
    void Start()
    {
        targ = GameObject.Find("plane").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y > targ.position.y)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, Mathf.Atan2(targ.position.y - transform.position.y, targ.position.x - transform.position.x) * Mathf.Rad2Deg + 90), 0.06f);
            //transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(targ.position.y - transform.position.y, targ.position.x - transform.position.x) * Mathf.Rad2Deg + 90);
            //transform.position = Vector3.MoveTowards(transform.position, targ.position, 0.03f);
        }
        else if (transform.position.y < -6.12f * wavescript.screenSizePere) Destroy(gameObject);
        if(!wavescript.gamestopped) transform.position = Vector3.MoveTowards(transform.position, transform.position - transform.up, 0.06f);
    }
    public void DopEnemSpawn()
    {
        for (int i = 0; i < Random.Range(3, 6); i++)
        {
            GameObject S = Instantiate(leach, transform.position, Quaternion.Euler(0, 0, Random.Range(0,360)),transform.parent);
            S.GetComponent<DopEnemScr>().trgt = targ;
        }
    }
    private void OnTriggerEnter2D(Collider2D lel)
    {
        if (lel.gameObject.tag == "Player")
        {
            planescr fiv = lel.GetComponent<planescr>();
            fiv.OnDamage();
        }
    }
}
